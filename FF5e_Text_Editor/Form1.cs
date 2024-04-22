/**
* |------------------------------------------|
* | FF5e_Text_editor                         |
* | File: Form1.cs                           |
* | v1.06, November 2015                     |
* | Author: noisecross                       |
* |------------------------------------------|
* 
* @author noisecross
* @version 1.06
* 
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;





/*
* ------------------------------------------
* |                                        |
* | RPGe text tables                       |
* |                                        |
* ------------------------------------------
*/

//
// Variable text tables:
//

// Speech: 2160 pointers (3 bytes):				0x2013F0 & 2160 texts	(E1/0000-E6/FFFF = 393216 bytes) (Take care about the last bytes of every bank. A speech cannot be splited)
// Battle speech: 234 offsets (2 bytes):		0x10F000 & E7/0000		(E7/3B00-50FF = 5632 bytes)
// Battle msgs: 81 offsets (2 bytes):			0x1139A9 & E7/0000		(E7/2760-2DCD = 1646 bytes)
// Item descriptions: 128 offsets (2 bytes):	0x275100 & E7/0000		(E7/5200-57BD = 1470 bytes)
// Jobs descriptions: 100 offsets (2 bytes):	0x117140 & D1/0000		(D1/724A-7FA0 = 3414 bytes)
// Areas: 164 offsets (2 bytes):				0x107000 & E7/0000		(E7/0000-08FF = 2304 bytes)
// Concepts: 139 offsets (2 bytes)				0x00F987 & E7/0000		(E7/2F00-3560 = 1632 bytes)

//
// Fixed text tables:
//

// Battle records:		0x275800 (4 registers of 17 bytes)
// Shop names:			0x112D00 (8 registers of 8  bytes) -> Greater don't fit.
// Monster names:		0x200050 (384 registers of 10 bytes) (E0/0000-0F40 no se puede extender)
// Monster attacks:		0x273700 (64 registers of 16 bytes) (E7/3700-3AF0 no se puede extender)
// SkillsM:				0x111C80 (87 registers of 6 bytes) + 0x270F90 (169 registers of 12 bytes) and 0x271780 (169 registers of 24 bytes)
// SkillsB:				0x270900 (105 registers of 16 bytes)
// Commands:			0x201150 (95 registers of 7 bytes) + 0x277060 (33 registers of 24 bytes)
// ItemsM:				0x111380 (256 registers of 9 bytes) + 0x273568 (24 registers of 13 bytes) and 0x275860 (256 registers of 24 bytes) (Battle message)
// Characters:			0x115500 (5 registers of 6 bytes) + 0x115600 (22 registers of 8 bytes) -> Greater doesn't fit.
// Concepts:			0x1128B6 (24 registers of 8 bytes)

// E7/73A0-751F: Crystal prophecy

// E0/3100-3140: Misc. menu text fields
// E7/FAD9-FFFF: Misc. menu text fields



namespace FF5e_Text_Editor
{
    public partial class Form1 : Form
    {
        /* Global variables */
        const string windowName      = "FF5e_Text_Editor";
        int          headerOffset    = 0;
        TBL_Manager  tblManager;

        Bitmap       font1bppBitmap  = new Bitmap(1,1);
        Bitmap       font1bppBitmapW = new Bitmap(1,1);
        Bitmap[]     font1bppChars   = new Bitmap[256];
        Bitmap       font2bppBitmap  = new Bitmap(1, 1);
        Bitmap[]     font2bppChars   = new Bitmap[256];
        Bitmap       muteSpell       = new Bitmap(1, 1);
        Bitmap       speechBmDisplay = FF5e_Text_Editor.Properties.Resources.SpeechWindow;
        Bitmap[]     windowsBmp      = new Bitmap[3];

        List<int> speechPtr = new List<int>();
        List<List<Byte>> speech = new List<List<byte>>();

        /* SMC file to edit */
        String fileUnderEdition = "";
        bool   fileToEditIsAvailable = false;



        /* ListView edition - Functional appends */
        private ListViewHitTestInfo hitinfo;
        private NumericUpDown editBox = new NumericUpDown();


        
        public Form1()
        {
            InitializeComponent();

            /* ListView edition - Functional appends */
            editBox.Parent = listViewTextWidths;
            editBox.Hide();

            editBox.LostFocus += new EventHandler(editbox_LostFocus);
            listViewTextWidths.MouseDoubleClick += new MouseEventHandler(listViewTextWidths_MouseDoubleClick);
            listViewTextWidths.FullRowSelect = true;
            /* Do hexadecimal */
            editBox.Maximum = 0x10;
            editBox.Minimum = 0x03;
            editBox.Hexadecimal = true;

            /* Images buffering */
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            tblManager = new TBL_Manager();

            comboBoxMenuEnlarge.SelectedIndex = 0;
            comboBoxMagicMenuEnlarge.SelectedIndex = 0;
            comboBoxStoresMenuEnlarge.SelectedIndex = 0;
            comboBoxWinGrouping.SelectedIndex = 0;
            comboBox1bppFont.SelectedIndex = 0;

            tabControl1.TabPages[4].Dispose();
            label2.Dispose();
            buttonBugFixChecksum.Dispose();

            windowsBmp[0] = new Bitmap(256, 256);
            windowsBmp[1] = new Bitmap(256, 256);
            windowsBmp[2] = new Bitmap(256, 256);
        }



        #region auxiliarLoadingFunctions



        private bool checkSNESHeader(System.IO.BinaryReader br)
        {
            /* Too small size */
            if (br.BaseStream.Length < 0x200000)
                return false;

            if (br.BaseStream.Length % 1024 == 0)
            {
                headerOffset = 0x0000;
                br.BaseStream.Position = 0xFFC0;
                byte[] headerName = br.ReadBytes(21);
                return System.Text.Encoding.UTF8.GetString(headerName) == "FINAL FANTASY 5      ";
            }
            else if (br.BaseStream.Length % 1024 == 512)
            {
                headerOffset = 0x0200;
                br.BaseStream.Position = (0xFFB0 + 0x0200);
                byte[] headerName = br.ReadBytes(21);
                return System.Text.Encoding.UTF8.GetString(headerName) == "FINAL FANTASY 5      ";
            }
            else
            {
                return false;
            }
        }



        private void loadFont(System.IO.BinaryReader br, int tableToReadFrom)
        {
            List<Byte> byteMap = new List<byte>();
            int table = (tableToReadFrom < 1) ? 0x03EB00 : 0x203724;

            br.BaseStream.Position = table + headerOffset;

            for (int i = 0; i < 0x0012C0; i++)
            {
                byteMap.Add((Byte)br.BaseStream.ReadByte());
            }
            font1bppBitmap = Transformations.transform1bpp(byteMap, 0, 0x0012C0);
        }



        private void load2bppFont(System.IO.BinaryReader br)
        {
            List<Byte> byteMap = new List<byte>();

            br.BaseStream.Position = 0x11F000 + headerOffset;

            for (int i = 0; i < 0x001000; i++)
            {
                byteMap.Add((Byte)br.BaseStream.ReadByte());
            }
            font2bppBitmap = Transformations.transform2bpp(byteMap, 0, 0x001000);
        }



        private void loadWidths(System.IO.BinaryReader br, int tableToReadFrom)
        {
            /* Load widths */
            long fileSize = br.BaseStream.Length;
            int table     = (tableToReadFrom < 1) ? 0x203225 : 0x203325;

            if (fileSize > 0x200000)
            {
                br.BaseStream.Position = table + headerOffset;
                for (int i = 0; i < 16; i++)
                {
                    listViewTextWidths.Items[i].SubItems.Clear();
                    listViewTextWidths.Items[i].Text = (i * 0x10).ToString("X2");

                    for (int j = 0; j < 16; j++)
                    {
                        byte newByte = br.ReadByte();
                        listViewTextWidths.Items[i].SubItems.Add(newByte.ToString("X2"));
                    }
                }

                /* Create font1bppBitmapW */
                font1bppBitmapW = generateWidthsPreview();
                panelFonts.Refresh();
            }
        }



        public void loadSpeech(System.IO.BinaryReader br) {
            Byte newChar = 0x00;

            /* Const (Bartz) */
            List<Byte> bartz = new List<Byte>();
            if (tblManager.TBL_Injector1bpp.TryGetValue("(", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue("B", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue("a", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue("r", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue("t", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue("z", out newChar)) bartz.Add(newChar);
            if (tblManager.TBL_Injector1bpp.TryGetValue(")", out newChar)) bartz.Add(newChar);

            /* Reset speech */
            speechPtr.Clear();
            speech.Clear();

            /* Read Speech */
            br.BaseStream.Position = 0x2013F0 + headerOffset;

            for (int i = 0; i < 2160; i++)
            {
                int newPtr = br.ReadByte() + br.ReadByte() * 0x0100 + (br.ReadByte() - 0xC0) * 0x010000;
                speechPtr.Add(newPtr);
            }

            foreach (int item in speechPtr)
            {
                List<Byte> newRegister = new List<byte>();
                br.BaseStream.Position = item;

                Byte newByte = br.ReadByte();
                while (newByte != 0)
                {
                    if (newByte != 0x02)
                    {
                        newRegister.Add(newByte);
                    }
                    else
                    {
                        /* (Bartz)*/
                        newRegister.AddRange(bartz);
                    }
                    newByte = br.ReadByte();
                }

                speech.Add(newRegister);

            }
        }



        #endregion auxiliarLoadingFunctions



        private void openSMCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Displays an OpenFileDialog so the user can select a res */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SNES ROM Files (*.smc, *.sfc)|*.smc;*.sfc";
            openFileDialog.Title  = "Choose a ROM file";

            long fileSize = 0;

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open));

                    try
                    {
                        /*
                        Temas para el inyector:

                        Leer primera tabla de tamaños: E03325 is the size table of 03EB00 font (1bpp)
                        Leer segunda tabla de tamaños: E03225 is the size table of E03725 font (1bpp)(At the beggining there was "Void")
                        */
                        if (!checkSNESHeader(br))
                        {
                            br.Close();
                            openFileDialog.Dispose();
                            openFileDialog = null;
                            return;
                        }
                        else
                        {
                            fileToEditIsAvailable = false;
                            comboBox1bppFont.SelectedIndex = 0;
                            fileSize = br.BaseStream.Length;

                            /* Reset speech */
                            speechPtr.Clear();
                            speech.Clear();

                            /* Load font */
                            loadFont(br, 0);

                            /* Load 2bpp font */
                            load2bppFont(br);

                            /* Get mute spell */
                            muteSpell = getMuteSpellBitmap(br);

                            /* Load font1bppChars */
	                        for(int j = 0 ; j < 25 ; j++){
		                        for(int i = 0 ; i < 8 ; i++){
			                        Rectangle cloneRect = new Rectangle(i * 16, j * 12, 16, 12);
			                        font1bppChars[(j * 8) + i] = font1bppBitmap.Clone(cloneRect, font1bppBitmap.PixelFormat);
		                        }
	                        }

                            /* Load font2bppChars */
                            for (int j = 0; j < 16; j++)
                            {
                                for (int i = 0; i < 16; i++)
                                {
                                    Rectangle cloneRect = new Rectangle(i * 8, j * 8, 8, 8);
                                    font2bppChars[(j * 16) + i] = font2bppBitmap.Clone(cloneRect, font2bppBitmap.PixelFormat);
                                }
                            }


                            loadWidths(br, 0);


                            if (fileSize > 0x200000)
                            {
                                panel2bpp.Refresh();
                            }
                        }

                        fileUnderEdition = openFileDialog.FileName;
                        fileToEditIsAvailable = true;
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error loading the file: " + error.ToString(), "Error");
                    }

                    if (fileToEditIsAvailable && fileSize > 0x200000)
                    {
                        loadSpeech(br);

                        numericUpDownIdSpeech.Value = 0;
                        comboBoxSubSpeech.SelectedIndex = 0;


                        /* Load misc texts */
                        br.Close();
                        loadMiscTexts();

                    }

                    br.Close();
                }
            }
            openFileDialog.Dispose();
            openFileDialog = null;

            panelMuteSpell.Refresh();
        }



        private Bitmap generateWidthsPreview()
        {
            Bitmap fonts1bppWidths = new Bitmap(128, 300);
            fonts1bppWidths.MakeTransparent();

            Pen semiTransPen = new Pen(Color.FromArgb(0x80, 0xFF, 0xFF, 0xFF), 1);

            using (Graphics g = Graphics.FromImage(fonts1bppWidths))
            {
                int k = 0x20;
                for (int j = 0; j < 25; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Byte x = Byte.Parse(listViewTextWidths.Items[(k / 16) % 16].SubItems[(k % 16) + 1].Text, System.Globalization.NumberStyles.HexNumber);
                        g.DrawLine(semiTransPen, 16 * i + x, j * 12, 16 * i + x, 12 + j * 12);
                        k++;
                    }
                }
            }

            return fonts1bppWidths;
        }



        private void loadMiscTexts()
        {
            List<String> output = new List<String>();

            /*
            E03103 Defense	(10byte 0xFF filled)
            E0310E .Def 	(4byte 0xFF filled)
            E03113 Eqp. 	(4byte 0xFF filled)
            E03118 Empty 	(5byte 0xFF filled)
            C0EA6C MASTER!	(7byte 0xFF filled)
            C0F7A8 Any      (4byte 0xFF filled)
            C115C4 PAUSE	(5byte 0xFF filled)
            C0EA74 LV	    (2byte)
            C0EAF7 ¿L?	    (1byte)
            CEFFBC UsesMP   (6byte 0xFF filled)
            D0E181 HP       (2byte)(Credits)
            D0E189 MP       (2byte)(Credits)
            D0E191 EXP      (3byte)(Credits)
            */

            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x203103, 1 /* nRegisters */, 10 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x20310E, 1 /* nRegisters */, 4 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x203113, 1 /* nRegisters */, 4 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x203118, 1 /* nRegisters */, 5 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00EA6C, 1 /* nRegisters */, 7 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00F7A8, 1 /* nRegisters */, 4 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x0115C4, 1 /* nRegisters */, 5 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00EA74, 1 /* nRegisters */, 2 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00EAF7, 1 /* nRegisters */, 1 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x0EFFBC, 1 /* nRegisters */, 6 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x10E181, 1 /* nRegisters */, 2 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x10E189, 1 /* nRegisters */, 2 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x10E191, 1 /* nRegisters */, 3 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x01F868, 1 /* nRegisters */, 1 /* registersSize */);
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00FAA0, 1 /* nRegisters */, 3 /* registersSize */);

            textBoxMiscTextDefense.Text = output[0];
            textBoxMiscTextDef.Text = output[1];
            textBoxMiscTextEqp.Text = output[2];
            textBoxMiscTextEmpty.Text = output[3];
            textBoxMiscTextMaster.Text = output[4];
            textBoxMiscTextAny.Text = output[5];
            textBoxMiscTextPause.Text = output[6];
            textBoxMiscTextLv.Text = output[7];
            //textBoxMiscTextL.Text = output[8];
            textBoxMiscTextUsesMP.Text = output[9];
            textBoxMiscTextHP.Text = output[10];
            textBoxMiscTextMP.Text = output[11];
            textBoxMiscTextExp.Text = output[12];
            textBoxSynchroIndexInject.Text = tblManager.TBL_Injector2bpp[output[13]].ToString("X2");
            textBoxMiscTextSell.Text = output[14];

            buttonMiscTextInjectDefense.Enabled = true;
            buttonMiscTextInjectDef.Enabled = true;
            buttonMiscTextInjectEqp.Enabled = true;
            buttonMiscTextInjectEmpty.Enabled = true;
            buttonMiscTextInjectMaster.Enabled = true;
            buttonMiscTextInjectAny.Enabled = true;
            buttonMiscTextInjectPause.Enabled = true;
            buttonMiscTextInjectLv.Enabled = true;
            buttonMiscTextInjectL.Enabled = true;
            buttonMiscTextUsesMP.Enabled = true;
            buttonMiscTextHpMpExp.Enabled = true;
            buttonMiscTextSell.Enabled = true;
        }



        #region auxiliarListTransformingFunctions



        private List<List<Byte>> parseStringList(List<String> listString, Dictionary<String, Byte> inputTBL, int size = 0, byte fillCharacter = 0xFF, bool forceBlankToFF = false)
        {
            List<List<Byte>> output = new List<List<Byte>>();
            bool syntaxError = false;
            int nErrorCount = 0;
            int maxDictItemSize = (inputTBL.Keys).OrderByDescending(s => s.Length).First().Length;
            String syntaxErrors = "";

            foreach (String item in listString)
            {
                String currentString = item;
                List<Byte> newByteLs = new List<byte>();
                //int newWidth = 0; //DEBUG

                while (currentString.Length > 0)
                {
                    bool found = false;
                    byte newByte = 0x00;

                    if (currentString[0] == '[' && currentString.Length > 3 && currentString[3] == ']')
                    {
                        Byte newForcedByte = 0;
                        if (Byte.TryParse(currentString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber, null, out newForcedByte))
                        {
                            newByteLs.Add(newForcedByte);
                            //if (newForcedByte != 0xFF) //DEBUG
                            //    newWidth += Int16.Parse(listViewTextWidths.Items[(newForcedByte & 0x00F0) / 16].SubItems[(newForcedByte & 0x000F) + 1].Text, System.Globalization.NumberStyles.HexNumber);

                            currentString = currentString.Substring(4);
                            continue;
                        }
                    }

                    for (int i = Math.Min(maxDictItemSize, currentString.Length); i > 0; i--)
                    {
                        if (forceBlankToFF && i == 1 && currentString[0] == ' ')
                        {
                            newByteLs.Add(0xFF);
                            currentString = currentString.Substring(1);
                            found = true;
                            break;
                        }

                        if (inputTBL.TryGetValue(currentString.Substring(0, i), out newByte))
                        {
                            newByteLs.Add(newByte);
                            //if (newByte != 0xFF)//DEBUG
                            //    newWidth += Int16.Parse(listViewTextWidths.Items[(newByte & 0x00F0) / 16].SubItems[(newByte & 0x000F) + 1].Text, System.Globalization.NumberStyles.HexNumber);

                            currentString = currentString.Substring(i);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        syntaxErrors += "The register " + item + " cannot be parsed\r\n";
                        syntaxError = true;
                        break;
                    }
                }

                //if (newWidth >= 117)//DEBUG
                //    MessageBox.Show("Item \"" + item + "\" is too long.\r\nIt hava a width of " + newWidth.ToString() + " pixels.");

                if (newByteLs.Count > size)
                {
                    syntaxErrors += "The register " + item + " is too long (may be " + size + " bytes long)\r\n";
                    syntaxError = true;
                }
                else
                {
                    for (int i = newByteLs.Count; i < size; i++)
                    {
                        newByteLs.Add(fillCharacter);
                    }
                    output.Add(newByteLs);
                }

                if (syntaxError)
                {
                    if (nErrorCount < 11)
                    {
                        nErrorCount++;
                        output.Clear();
                    }
                    else
                    {
                        output.Clear();
                        break;
                    }
                }
            }

            if (syntaxError)
            {
                syntaxErrors += "[...]\r\nMaybe there are more error(s)...\r\n";
                MessageBox.Show(syntaxErrors, "Invalid file");
            }
            return output;
        }



        private List<List<Byte>> parseStringList(List<String> listString, Dictionary<String, Byte> inputTBL, bool addEol = true, byte eol = 0x00)
        {
            List<List<Byte>> output = new List<List<Byte>>();
            bool syntaxError = false;
            int nErrorCount = 0;
            int maxDictItemSize = (inputTBL.Keys).OrderByDescending(s => s.Length).First().Length;
            String syntaxErrors = "";

            foreach (String item in listString)
            {
                String currentString = item;
                List<Byte> newByteLs = new List<byte>();

                while (currentString.Length > 0)
                {
                    bool found = false;
                    byte newByte = 0x00;

                    if (currentString[0] == '[' && currentString.Length > 3 && currentString[3] == ']')
                    {
                        Byte newForcedByte = 0;
                        if (Byte.TryParse(currentString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber, null, out newForcedByte))
                        {
                            newByteLs.Add(newForcedByte);
                            currentString = currentString.Substring(4);
                            continue;
                        }
                    }

                    for (int i = Math.Min(maxDictItemSize, currentString.Length); i > 0; i--)
                    {
                        if (inputTBL.TryGetValue(currentString.Substring(0, i), out newByte))
                        {
                            newByteLs.Add(newByte);
                            currentString = currentString.Substring(i);
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        syntaxError = true;
                        syntaxErrors += "The register " + item + " cannot be parsed\r\n";
                        nErrorCount++;
                        break;
                    }
                }

                if (syntaxError)
                {
                    output.Clear();
                    if (nErrorCount > 5){
                        break;
                    }
                }else{
                    if (addEol)
                    {
                        newByteLs.Add(eol);
                    }
                    output.Add(newByteLs);
                }
            }

            if (syntaxError)
            {
                syntaxErrors += "[...]\r\nMaybe there are more error(s)...\r\n";
                MessageBox.Show(syntaxErrors, "Invalid file");
            }
            return output;
        }



        private List<String> appendToExportList(List<String> inputList, Dictionary<Byte, String> inputTBL, int address, int nRegisters, int registersSize)
        {
            List<String> output = inputList;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return output;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = address + headerOffset;

                for (int i = 0; i < nRegisters; i++)
                {
                    String newLine = "";

                    for (int j = 0; j < registersSize; j++)
                    {
                        newLine += inputTBL[br.ReadByte()];
                    }

                    output.Add(newLine);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            return output;
        }



        private List<String> appendToExportList(List<String> inputList, Dictionary<Byte, String> inputTBL, int offsetsAdress, int address, int nRegisters, byte eolByte, bool speech = false, byte escapeByte = 0x00)
        {
            List<String> output = inputList;
            List<int> offsets = new List<int>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return output;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                if (!fileToEditIsAvailable)
                    return output;

                br.BaseStream.Position = headerOffset + offsetsAdress;

                if (speech)
                    for (int i = 0; i < nRegisters; i++)
                        offsets.Add(br.ReadByte() + 0x000100 * br.ReadByte() + 0x010000 * br.ReadByte());
                else
                    for (int i = 0; i < nRegisters; i++)
                        offsets.Add(br.ReadByte() + 0x0100 * br.ReadByte());

                foreach (int item in offsets)
                {
                    if (speech)
                        br.BaseStream.Position = headerOffset + item - 0xC00000;
                    else
                        br.BaseStream.Position = address + headerOffset + item; 
                    
                    String newLine = "";

                    byte newByte = br.ReadByte();
                    byte preByte = 0x00;

                    do
                    {
                        while (newByte != eolByte)
                        {
                            newLine += inputTBL[newByte];
                            preByte = newByte;
                            newByte = br.ReadByte();
                        }

                        if (escapeByte == 0x00 || preByte != escapeByte)
                            break;

                        newLine += inputTBL[newByte];
                        preByte = newByte;
                        newByte = br.ReadByte();
                    } while (true);

                    output.Add(newLine);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            return output;
        }



        private List<String> appendToExportListSU(List<String> inputList, Dictionary<Byte, String> inputTBL, int offsetsAdress, int address, int nRegisters)
        {
            List<String> output = inputList;
            List<int> offsets = new List<int>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return output;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                if (!fileToEditIsAvailable)
                    return output;

                br.BaseStream.Position = offsetsAdress + headerOffset;
                for (int i = 0; i < nRegisters; i++)
                {
                    offsets.Add(br.ReadByte() + 0x0100 * br.ReadByte());
                }

                offsets.Add(2304);

                for (int i = 0; i < nRegisters; i++)
                {
                    br.BaseStream.Position = address + headerOffset + offsets[i];
                    String newLine = "";

                    byte newByte = br.ReadByte();
                    for(int j = 0 ; j < offsets[i + 1] - offsets[i] ; j++){
                        newLine += inputTBL[newByte];
                        newByte = br.ReadByte();
                    }

                    output.Add(newLine);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            return output;
        }



        private List<String> exportList(Dictionary<Byte, String> inputTBL, int offsetsAdress, int nRegisters, byte eolByte)
        {
            List<String> output = new List<String>();
            List<int> pointers = new List<int>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return output;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                if (!fileToEditIsAvailable)
                    return output;

                br.BaseStream.Position = offsetsAdress + headerOffset;
                for (int i = 0; i < nRegisters; i++)
                {
                    pointers.Add(br.ReadByte() + 0x000100 * br.ReadByte() + 0x010000 * (br.ReadByte() - 0xC0));
                }

                foreach (int item in pointers)
                {
                    br.BaseStream.Position = headerOffset + item;
                    String newLine = "";
                    byte newByte = br.ReadByte();

                    while (newByte != eolByte)
                    {
                        newLine += inputTBL[newByte];
                        newByte = br.ReadByte();
                    }

                    output.Add(newLine);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            return output;
        }



        #endregion auxiliarListTransformingFunctions



        #region auxiliarWritingFunctions



        private void importPNG(int importIn)
        {
            /*
            importIn
            0- 1bpp field font
            1- 2bpp menu font
            2- 1bpp poem font
            3- ...
            */

            /*
             * The expected Bitmaps have a size of n x fileSize and a PixelFormat of Format8bppIndexed
             */

            /* Displays an OpenFileDialog so the user can select a res */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                        int size = bitmap.Width * bitmap.Height;
                        byte[] bitmapPixels = new byte[size];

                        /* Open it to edit */
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Recover the original values (now lost because of the conversion) */
                        for (int i = 0; i < size; i++)
                        {
                            bitmapPixels[i] = System.Runtime.InteropServices.Marshal.ReadByte(data.Scan0, i);
                        }


                        List<byte> newBytes;
                        int offset = 0;
                        int nColumns = 0;

                        switch (importIn)
                        {
                            case 0:
                                /* 1bbp */
                                /* Offset 0x03EB00 */
                                /* Size   0x0012C0 */
                                offset = 0x03EB00;
                                nColumns = (int)Math.Truncate(128.0 / 8);
                                size = (size - (size % ((8 * nColumns) * 12)));
                                if (size == (0x0012C0 * 8))
                                    newBytes = InvertingTransformations.import1bpp(bitmapPixels, 8, 12, size);
                                else
                                    newBytes = new List<byte>();
                                break;
                            case 1:
                                /* 2bbp */
                                /* Offset 0x11F000 */
                                /* Size   0x001000 */
                                offset = 0x11F000;
                                nColumns = (int)Math.Truncate(128.0 / 8);
                                size = size - (size % ((8 * nColumns) * 8));
                                if (size == 0x004000)
                                    newBytes = InvertingTransformations.import2bpp(bitmapPixels, 8, 8, size);
                                else
                                    newBytes = new List<byte>();
                                break;
                            case 2:
                                /* 1bpp */
                                /* Offset 0x203724 */
                                /* Size   0x001380 */
                                offset = 0x203724;
                                nColumns = (int)Math.Truncate(128.0 / 8);
                                size = (size - (size % ((8 * nColumns) * 12)));
                                if (size == (0x001380 * 8))
                                    newBytes = InvertingTransformations.import1bpp(bitmapPixels, 8, 12, size);
                                else
                                    newBytes = new List<byte>();
                                break;
                            default:
                                newBytes = new List<byte>();
                                break;
                        }

                        bitmap.Dispose();

                        if (newBytes.Count > 0)
                        {
                            /* Inject */
                            injectImageOn(newBytes, offset);
                        }

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                    }
                }
            }
            openFileDialog.Dispose();
            openFileDialog = null;
        }



        private bool injectOn(List<List<Byte>> input, int address)
        {
            bool output = true;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {

                bw.BaseStream.Position = address + headerOffset;

                foreach (List<Byte> item in input)
                {
                    foreach (Byte subItem in item)
                    {
                        bw.BaseStream.WriteByte(subItem);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                output = false;
            }

            if (output)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            bw.Close();
            fs.Close();

            return output;
        }



        private List<Byte> sanityEOLs(List<Byte> input, List<Byte> sizes)
        {
            List<Byte> output = new List<byte>(input);
            int accumulated   = 0;
            int lastBlank     = 65535;
            int lastBlankUsed = 0;

            try
            {
                /* Const (Bartz) */
                int bartzWidth = 0;
                Byte newChar = 0;
                
                if (tblManager.TBL_Injector1bpp.TryGetValue("(", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue("B", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue("a", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue("r", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue("t", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue("z", out newChar)) bartzWidth += sizes[newChar];
                if (tblManager.TBL_Injector1bpp.TryGetValue(")", out newChar)) bartzWidth += sizes[newChar];

                for (int i = 0; i < input.Count; i++)
                {
                    if (output[i] == 0x01)
                    {
                        accumulated = 0;
                    }
                    else if (output[i] == 0x02)
                    {
                        accumulated += bartzWidth;
                    }
                    else if (output[i] == 0x52 || output[i] == 0xFF)
                    {
                        lastBlank = i;
                        accumulated += sizes[output[i]];
                    }
                    else if (output[i] < 0x20 || output[i] > 0xE7)
                    {
                        ;
                    }
                    else
                    {
                        accumulated += sizes[output[i]];
                    }

                    //167???
                    if (accumulated > 207 && lastBlank < 65535)
                    {
                        i = lastBlank;
                        if (lastBlankUsed == lastBlank)
                        {
                            break;
                        }
                        lastBlankUsed = lastBlank;
                        output[i] = 0x01;
                        accumulated = 0;
                    }
                }
            }
            catch (Exception)
            {
                output = input;
            }

            return output;
        }



        private int getSize(List<Byte> input, List<Byte> sizes)
        {
            int output = 0;

            try
            {
                /* Const (Bartz) */
                int bartzWidth = sizes[0xAE] + sizes[0x61] + sizes[0x7A] +
                    sizes[0x8B] + sizes[0x8D] + sizes[0x93] + sizes[0xAF];

                foreach (Byte item in input)
                {
                    switch (item)
                    {
                        case 0x00:
                            break;
                        case 0x01:
                            break;
                        case 0x02:
                            output += bartzWidth;
                            break;
                        default:
                            output += sizes[item];
                            break;
                    };
                }
            }
            catch (Exception)
            {
                output = 0xFFFF;
            }

            return output;
        }



        private void fixRPGeSpeechASM(System.IO.BinaryWriter bw)
        {
            /*
            Transform $E0/31A8 to:
              $E0/31A8 A9 42       LDA $#42        ; .
              $E0/31AA 85 A7       STA $A7         ; writeBufferFlag = 42
              $E0/31AC 6B          RTL             ; return
              $E0/31AD EA EA EA EA NOP NOP NOP NOP ; ...
              $E0/31B1 EA          NOP             ; ...

            Transform $C0/8E23 to:
	            $C0/8E23 64 A7       STZ $A7 -> EA EA       NOP NOP

            Transform $C0/8ECE
	            $C0/8ECE A5 06       LDA $06  -> 22 30 4C E0  JSL E0 4C 30
	            $C0/8ED0 E2 20       SEP #$20 ..

            Write $E0/4C30
	            A5 A7       LDA A7     ; .
	            29 FF 00    AND #$00FF ; .
	            C9 40 00    CMP #$0040 ; .
	            90 08       BCC $08    ; if (writeBufferFlag >= 0x40){
	            A5 A9       LDA $A9    ;   .
	            38          SEC        ;   .
	            E9 40 00    SBC #$0040 ;   Pointer to paint -= 0x40;
	            85 A9       STA $A9    ; }
	            A5 06       LDA $06    ; // Normal routine solving
	            E2 20       SEP #$20   ; // A width set to 8 bit
	            85 A7       STA $A7    ; writeBufferFlag = A = 0;
	            6B          RTL        ; return; 
            */
            List<Byte> E031A8 = new List<Byte>(){
	            0xA9, 0x42, 0x85, 0xA7, 0x6B, 0xEA, 0xEA, 0xEA,
	            0xEA, 0xEA};

            List<Byte> C08E23 = new List<Byte>(){
	            0xEA, 0xEA};

            List<Byte> C08ECE = new List<Byte>(){
	            0x22, 0x30, 0x4C, 0xE0};

            List<Byte> E04C30 = new List<Byte>(){
	            0xA5, 0xA7,	0x29, 0xFF, 0x00, 0xC9, 0x40, 0x00,
	            0x90, 0x08, 0xA5, 0xA9, 0x38, 0xE9, 0x40, 0x00,
	            0x85, 0xA9, 0xA5, 0x06, 0xE2, 0x20, 0x85, 0xA7,
	            0x6B};

            bw.BaseStream.Position = 0x2031A8 + headerOffset;
            foreach (Byte item in E031A8) { bw.BaseStream.WriteByte(item); }
            bw.BaseStream.Position = 0x008E23 + headerOffset;
            foreach (Byte item in C08E23) { bw.BaseStream.WriteByte(item); }
            bw.BaseStream.Position = 0x008ECE + headerOffset;
            foreach (Byte item in C08ECE) { bw.BaseStream.WriteByte(item); }
            bw.BaseStream.Position = 0x204C30 + headerOffset;
            foreach (Byte item in E04C30) { bw.BaseStream.WriteByte(item); }


            // Fix the RPGe buffer overflow issue

            // E0/0F51 18 -> 38 ; CLC -> SEC
            // E0/0F57 71 -> 70 ; LDA $E00F71,x -> LDA $E00F70,x
            bw.BaseStream.Position = 0x200F51 + headerOffset;
            bw.BaseStream.WriteByte(0x38);
            bw.BaseStream.Position = 0x200F57 + headerOffset;
            bw.BaseStream.WriteByte(0x70);

            // Fix the RPGe text of "You found '[MAGIC]'!" which displays 6 bytes instead of 5.
            bw.BaseStream.Position = 0x008AAF + headerOffset;
            bw.BaseStream.WriteByte(0x05);
        }
        


        private bool injectSpeechOn(List<List<Byte>> input, int offsetsAddress, int initialAddress, bool silent = false)
        {
            //offsets  0xE0/13F0 (to E0/2D3F)
            //address  0xE1/0000
            //number   2160
            //max size 0x050000
            //addEOL   true
            //eol      0x00
            //speech   true

            bool output = true;
            List<long> offsets = new List<long>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                // Fix the RPGe speech issues
                fixRPGeSpeechASM(bw);

                /* Get sizes */
                List<Byte> sizes = new List<byte>();
                bw.BaseStream.Position = 0x203225 + headerOffset;
                for (int k = 0; k < 0x0100; k++)
                {
                    sizes.Add(BitConverter.GetBytes(bw.BaseStream.ReadByte())[0]);
                }

                /* Write offsets */
                int position  = initialAddress;
                int increment = input[0].Count;
                
                bw.BaseStream.Position = offsetsAddress + headerOffset;

                for (int i = 0; i < input.Count; i++)
                {
                    input[i] = sanityEOLs(input[i], sizes);
                    increment = input[i].Count;

                    if (BitConverter.GetBytes(position)[2] != BitConverter.GetBytes(position + increment)[2])
                    {
                        position = BitConverter.GetBytes(position + increment)[2] * 0x010000;
                    }

                    bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[0]);
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[1]);
                    bw.BaseStream.WriteByte((Byte)(BitConverter.GetBytes(position)[2] + 0xC0));
                    offsets.Add(position);

                    position += increment;
                } 

                /* Write data */
                int j = 0;

                foreach (List<Byte> item in input)
                {
                    bw.BaseStream.Position = offsets[j++] + headerOffset;
                    bw.BaseStream.Write(item.ToArray(), 0, item.Count);
                }

                bw.Close();

                System.IO.FileStream fs2 = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs2, new UnicodeEncoding());
                loadSpeech(br);

                br.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                output = false;
            }

            if (output && !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return output;
        }

        

        private bool injectOn(List<List<Byte>> input, int offsetsAddress, int initialAddress)
        {

            bool output = true;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                /* Write offsets */
                int position = initialAddress % 0x010000;
                bw.BaseStream.Position = offsetsAddress + headerOffset;

                bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[0]);
                bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[1]);

                for (int i = 1; i < input.Count; i++)
                {
                    position += input[i - 1].Count;
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[0]);
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(position)[1]);
                }

                /* Write data */
                bw.BaseStream.Position = initialAddress + headerOffset;

                foreach (List<Byte> item in input)
                {
                    foreach (Byte subItem in item)
                    {
                        bw.BaseStream.WriteByte(subItem);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                output = false;
            }

            bw.Close();
            fs.Close();

            if (output)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return output;
        }



        private bool injectImageOn(List<byte> newBytes, int address)
        {

            bool output = true;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = address + headerOffset;

                foreach (Byte item in newBytes)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                output = false;
            }

            bw.Close();
            fs.Close();

            System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.Open(fileUnderEdition, System.IO.FileMode.Open));
            loadFont(br, comboBox1bppFont.SelectedIndex);
            load2bppFont(br);
            muteSpell = getMuteSpellBitmap(br);

            br.Close();

            panelFonts.Refresh();
            panel2bpp.Refresh();
            panelMuteSpell.Refresh();

            if (output)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return output;
        }



        private void ImportFixedSizeTable(List<String> inputStr, Dictionary<String, Byte> inputTLB, int address, int expectedNumber, int registerSize, byte fillCharacter = 0xFF, bool forceBlankToFF = false)
        {

            List<List<Byte>> inputBytes = parseStringList(inputStr, inputTLB, registerSize, fillCharacter);

            if (inputBytes.Count < expectedNumber)
            {
                MessageBox.Show(expectedNumber + " registers were expected, but there are\r\nonly " +
                                inputBytes.Count + " registers on the file.", "Invalid file");
                return;
            }

            if (inputBytes.Count == 0)
            {
                /* Syntax error management */

                String syntaxErrors = "";
                int nErrorCount = 0;
                List<String> newString = new List<String>();
                List<List<Byte>> newBytes = new List<List<Byte>>();

                foreach (String item in inputStr)
                {
                    newString.Clear();
                    newString.Add(item);
                    newBytes = parseStringList(inputStr, inputTLB, registerSize, fillCharacter, forceBlankToFF);

                    if (newBytes.Count == 0)
                    {
                        /* Add syntax error */
                        nErrorCount += 1;
                        if (nErrorCount < 6)
                        {
                            syntaxErrors += "The register " + item + " cannot be parsed\r\n";
                        }
                    }
                }

                if (nErrorCount > 5)
                {
                    syntaxErrors += "[...]\r\n\r\n" + (nErrorCount - 5) + " more error(s)...\r\n";
                }
                MessageBox.Show(syntaxErrors, "Invalid file");

                return;
            }

            /* Everything OK. Inject data. */
            injectOn(inputBytes, address);
        }



        private bool checkForImporting(List<String> inputStr, List<List<Byte>> inputBytes, Dictionary<String, Byte> inputTLB, int expectedNumber, int maxSize, bool addEol = true, byte eol = 0x00, bool silent = false)
        {
            if (inputBytes.Count < expectedNumber)
            {
                MessageBox.Show(expectedNumber + " registers were expected, but there are\r\nonly " +
                                inputBytes.Count + " registers on the file.", "Invalid file");
                return false;
            }


            if (inputBytes.Count == 0)
            {
                /* Syntax error management */

                String syntaxErrors = "";
                int nErrorCount = 0;
                List<String> newString = new List<String>();
                List<List<Byte>> newBytes = new List<List<Byte>>();

                foreach (String item in inputStr)
                {
                    newString.Clear();
                    newString.Add(item);
                    newBytes = parseStringList(inputStr, inputTLB, addEol, eol);

                    if (newBytes.Count == 0)
                    {
                        /* Add syntax error */
                        nErrorCount += 1;
                        if (nErrorCount < 6)
                        {
                            syntaxErrors += "The register " + item + " cannot be parsed\r\n";
                        }
                    }
                }

                if (nErrorCount > 5)
                {
                    syntaxErrors += "[...]\r\n\r\n" + (nErrorCount - 5) + " more error(s)...\r\n";
                }
                MessageBox.Show(syntaxErrors, "Invalid file");

                return false;
            }


            /* Check overflow */
            int listSize = 0;
            foreach (List<Byte> item in inputBytes)
            {
                listSize += item.Count;
            }
            if (listSize > maxSize)
            {
                /* Overflow */
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\n" + maxSize + " bytes long were expected.",
                                "Invalid file");
                return false;
            }
            else if (!silent)
            {
                MessageBox.Show("The file is ok:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\nLess than " + maxSize + " bytes long were expected.",
                                "Sucessfully parsed!");
            }

            return true;
        }



        private void ImportVariableSizeTable(List<String> inputStr, Dictionary<String, Byte> inputTLB, int offsetAddress, int address, int expectedNumber, int maxSize, bool addEol = true, byte eol = 0x00, bool speech = false, bool silent = false)
        {
            List<List<Byte>> inputBytes = parseStringList(inputStr, inputTLB, addEol, eol);

            //offsets  0x2013F0
            //address  0x210000
            //number   2160
            //max size 0x050000
            //addEOL   true
            //eol      0x00
            //speech   true

            /* Check if everything OK. */
            if (!checkForImporting(inputStr, inputBytes, inputTLB, expectedNumber, maxSize, addEol, eol, silent))
                return;

            /* Everything OK. Inject data. */
            if (speech)
            {
                injectSpeechOn(inputBytes, offsetAddress, address, silent);
            }
            else
            {
                injectOn(inputBytes, offsetAddress, address);
            }
        }



        private void ImportBattleSpeechTable(List<String> inputStr, Dictionary<String, Byte> inputTLB, int offsetAddress, int address, int expectedNumber, int maxSize, bool addEol = true, byte eol = 0x00)
        {
            List<List<Byte>> inputBytes = parseStringList(inputStr, inputTLB, addEol, eol);

            /* Check if everything OK. */
            if (!checkForImporting(inputStr, inputBytes, inputTLB, expectedNumber, maxSize, addEol, eol))
                return;


            /* Check widths */
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool readOk = true;
            System.IO.FileStream fs   = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> sizes = new List<byte>();

            try
            {
                br.BaseStream.Position = 0x203225 + headerOffset;
                sizes = br.ReadBytes(0x0100).ToList();
            }
            catch (Exception e)
            {
                readOk = false;
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            if (!readOk)
                return;

            int    width;
            String message  = "The text will be imported, but some registers will not be correctly displayed\r\n\r\n";
            int    warnings = 0;
            for (int i = 0; i < inputStr.Count; i++)
            {
                width = getSize(inputBytes[i], sizes);
                if (width > 208)
                {
                    message += "\"" + inputStr[i] + "\" won't fit in box. ("+ width.ToString() +" px)\r\n";
                    warnings++;
                    if (warnings > 10)
                    {
                        message += "[...]\r\nMore registers may be affected by this issue.";
                        break;
                    }
                }
            }

            if (warnings > 0)
                MessageBox.Show(message,"Info");

            /* Everything OK. Inject data. */
            injectOn(inputBytes, offsetAddress, address);
        }



        #endregion auxiliarWritingFunctions



        #region exportfixedSizedTemplates



        private void buttonCSVExportMonsters_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Monster names */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x200050, 384 /* nRegisters */, 10 /* registersSize */);

            if (output.Count == 384)
            {
                CSV_Manager.exportCSV("Monsters", output);
            }
        }



        private void labelMonsters_Click(object sender, EventArgs e)
        {
            List<String> monsters = new List<String>();

            /* Monster names */
            monsters = appendToExportList(monsters, tblManager.TBL_Reader2bpp, 0x200050, 384 /* nRegisters */, 10 /* registersSize */);

            if (monsters.Count == 384)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Monster names
                //0x200050, 384regs, 10bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x200050 + headerOffset;
                for (int i = 0; i < 384; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(10).ToList());
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, monsters, font2bppChars, 10);
                form.ShowDialog();
                form.Dispose();
            }
        }

        

        private void buttonCSVExportMonsterAttacks_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Monster Attacks */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x273700, 64 /* nRegisters */, 16 /* registersSize */);

            if (output.Count == 64)
            {
                CSV_Manager.exportCSV("MonsterAttacks", output);
            }
        }



        private void labelMonAttacks_Click(object sender, EventArgs e)
        {
            List<String> monsterAttacks = new List<String>();

            /* Monster attacks names */
            monsterAttacks = appendToExportList(monsterAttacks, tblManager.TBL_Reader1bpp, 0x273700, 64 /* nRegisters */, 16 /* registersSize */);

            if (monsterAttacks.Count == 64)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Monster names
                //0x273700, 64regs, 16bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x273700 + headerOffset;
                for (int i = 0; i < 64; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(16).ToList());
                }

                br.Close();
                fs.Close();

                int[] fontWidths = new int[256];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    for (int j = 0; j < 16; j++)
                        fontWidths[k++] = Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber);
                Bitmap[] newFont1bppChars = new Bitmap[256];
                for (int i = 0; i < 0xD0; i++)
                    newFont1bppChars[i + 0x20] = font1bppChars[i];


                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector1bpp, addresses, bytesList, monsterAttacks, newFont1bppChars, 16, false, fontWidths);
                form.ShowDialog();
                form.Dispose();
            }

        }
        


        private void buttonCSVExportSkillsM_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* SkillsM 01 */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x111C80, 87 /* nRegisters */, 6 /* registersSize */);

            /* SkillsM 02 */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x270F90, 169 /* nRegisters */, 12 /* registersSize */);

            /* SkillsM Blue */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x11200D, 30 /* nRegisters */, 9 /* registersSize */);

            /* SkillsM Songs */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x111E8A, 8 /* nRegisters */, 9 /* registersSize */);

            if (output.Count == 294)
            {
                CSV_Manager.exportCSV("SkillsM", output);
            }
        }



        private void labelSkillsM_Click(object sender, EventArgs e)
        {
            List<String> skillsM = new List<String>();

            /* SkillsM */
            skillsM = appendToExportList(skillsM, tblManager.TBL_Reader2bpp, 0x111C80, 87 /* nRegisters */, 6 /* registersSize */);
            skillsM = appendToExportList(skillsM, tblManager.TBL_Reader2bpp, 0x270F90, 169 /* nRegisters */, 12 /* registersSize */);
            skillsM = appendToExportList(skillsM, tblManager.TBL_Reader2bpp, 0x11200D, 30 /* nRegisters */, 9 /* registersSize */);
            skillsM = appendToExportList(skillsM, tblManager.TBL_Reader2bpp, 0x111E8A, 8 /* nRegisters */, 9 /* registersSize */);

            if (skillsM.Count == 294)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // SkillsM
                //0x111C80, 87  regs, 6  bytes
                //0x270F90, 169 regs, 12 bytes
                //0x11200D, 30  regs, 9  bytes
                //0x111E8A, 8   regs, 9  bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x111C80 + headerOffset;
                for (int i = 0; i < 87; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(6).ToList());
                }
                br.BaseStream.Position = 0x270F90 + headerOffset;
                for (int i = 0; i < 169; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(12).ToList());
                }
                br.BaseStream.Position = 0x11200D + headerOffset;
                for (int i = 0; i < 30; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(9).ToList());
                }
                br.BaseStream.Position = 0x111E8A + headerOffset;
                for (int i = 0; i < 8; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(9).ToList());
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, skillsM, font2bppChars, 12);
                form.ShowDialog();
                form.Dispose();
            }

        }



        private void buttonCSVExportSkillsB_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* SkillsB */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x270900, 105 /* nRegisters */, 16 /* registersSize */);

            /* SkillsB 02 */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x271780, 169 /* nRegisters */, 24 /* registersSize */);

            if (output.Count == 274)
            {
                CSV_Manager.exportCSV("SkillsB", output);
            }
        }



        private void labelSkillsB_Click(object sender, EventArgs e)
        {
            List<String> skillsB = new List<String>();

            /* SkillsB */
            skillsB = appendToExportList(skillsB, tblManager.TBL_Reader1bpp, 0x270900, 105 /* nRegisters */, 16 /* registersSize */);

            /* SkillsB 02 */
            skillsB = appendToExportList(skillsB, tblManager.TBL_Reader1bpp, 0x271780, 169 /* nRegisters */, 24 /* registersSize */);

            if (skillsB.Count == 274)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Monster names
                //0x273700, 64regs, 16bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x270900 + headerOffset;
                for (int i = 0; i < 105; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(16).ToList());
                }
                br.BaseStream.Position = 0x271780 + headerOffset;
                for (int i = 0; i < 169; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(24).ToList());
                }

                br.Close();
                fs.Close();

                int[] fontWidths = new int[256];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    for (int j = 0; j < 16; j++)
                        fontWidths[k++] = Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber);
                Bitmap[] newFont1bppChars = new Bitmap[256];
                for (int i = 0; i < 0xD0; i++)
                    newFont1bppChars[i + 0x20] = font1bppChars[i];


                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector1bpp, addresses, bytesList, skillsB, newFont1bppChars, 24, false, fontWidths);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportCommands_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Commands */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x201150, 95 /* nRegisters */, 7 /* registersSize */);

            /* Abilities (menu) */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x116200, 33 /* nRegisters */, 8 /* registersSize */);

            /* Abilities (Battle) */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x277060, 33 /* nRegisters */, 24 /* registersSize */);

            if (output.Count == 161)
            {
                CSV_Manager.exportCSV("Commands", output);
            }
        }



        private void labelCommands_Click(object sender, EventArgs e)
        {
            List<String> commands = new List<String>();

            /* Commands */
            commands = appendToExportList(commands, tblManager.TBL_Reader2bpp, 0x201150, 95 /* nRegisters */, 7  /* registersSize */);
            commands = appendToExportList(commands, tblManager.TBL_Reader2bpp, 0x116200, 33 /* nRegisters */, 8  /* registersSize */);
            commands = appendToExportList(commands, tblManager.TBL_Reader2bpp, 0x277060, 33 /* nRegisters */, 24 /* registersSize */);

            if (commands.Count == 161)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Commands
                //0x201150, 95 regs, 7  bytes
                //0x116200, 33 regs, 8  bytes
                //0x277060, 33 regs, 24 bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x201150 + headerOffset;
                for (int i = 0; i < 95; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(7).ToList());
                }
                br.BaseStream.Position = 0x116200 + headerOffset;
                for (int i = 0; i < 33; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(8).ToList());
                }
                br.BaseStream.Position = 0x277060 + headerOffset;
                for (int i = 0; i < 33; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(24).ToList());
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, commands, font2bppChars, 8);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportItems_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Items (menu) */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x111380, 256 /* nRegisters */, 9 /* registersSize */);

            /* Rare items (menu) */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x273568, 24 /* nRegisters */, 13 /* registersSize */);

            /* Items (battle) */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x275860, 256 /* nRegisters */, 24 /* registersSize */);

            if (output.Count == 536)
            {
                CSV_Manager.exportCSV("Items", output);
            }
        }



        private void labelItems_Click(object sender, EventArgs e)
        {
            List<String> items = new List<String>();

            /* Items */
            items = appendToExportList(items, tblManager.TBL_Reader2bpp, 0x111380, 256 /* nRegisters */, 9 /* registersSize */);
            items = appendToExportList(items, tblManager.TBL_Reader2bpp, 0x273568, 24 /* nRegisters */, 13 /* registersSize */);

            if (items.Count == 280)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Items
                //0x111380, 256 regs,  9 bytes
                //0x273568, 24  regs, 13 bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x111380 + headerOffset;
                for (int i = 0; i < 256; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(9).ToList());
                }
                br.BaseStream.Position = 0x273568 + headerOffset;
                for (int i = 0; i < 24; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(13).ToList());
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, items, font2bppChars, 13);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportCharacters_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Characters */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x115500, 5 /* nRegisters */, 6 /* registersSize */);

            /* Characters */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x115600, 22 /* nRegisters */, 8 /* registersSize */);

            if (output.Count == 27)
            {
                CSV_Manager.exportCSV("Characters", output);
            }
        }



        private void labelCharacters_Click(object sender, EventArgs e)
        {
            List<String> characters = new List<String>();

            /* Characters */
            characters = appendToExportList(characters, tblManager.TBL_Reader2bpp, 0x115500, 5 /* nRegisters */, 6 /* registersSize */);
            characters = appendToExportList(characters, tblManager.TBL_Reader2bpp, 0x115600, 22 /* nRegisters */, 8 /* registersSize */);

            if (characters.Count == 27)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Characters
                //0x115500, 5  regs, 6 bytes
                //0x115600, 22 regs, 8 bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x115500 + headerOffset;
                for (int i = 0; i < 5; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(6).ToList());
                }
                br.BaseStream.Position = 0x115600 + headerOffset;
                for (int i = 0; i < 22; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(8).ToList());
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, characters, font2bppChars, 8);
                form.ShowDialog();
                form.Dispose();

            }
        }



        private void buttonCSVExportConcepts_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Battle records */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x275800, 5 /* nRegisters */, 17 /* registersSize */);

            /* Shop names */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x112D00, 8 /* nRegisters */, 8 /* registersSize */);

            /* Concepts */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x1128B6, 24 /* nRegisters */, 8 /* registersSize */);

            if (output.Count == 37)
            {
                CSV_Manager.exportCSV("FConcepts", output);
            }
        }



        private void labelConcepts_Click(object sender, EventArgs e)
        {
            List<String> concepts = new List<String>();

            /* Concepts */
            concepts = appendToExportList(concepts, tblManager.TBL_Reader2bpp, 0x112D00, 8 /* nRegisters */, 8 /* registersSize */);
            concepts = appendToExportList(concepts, tblManager.TBL_Reader2bpp, 0x1128B6, 24 /* nRegisters */, 8 /* registersSize */);
            concepts = appendToExportList(concepts, tblManager.TBL_Reader2bpp, 0x275800, 5 /* nRegisters */, 17 /* registersSize */);

            if (concepts.Count == 37)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Concepts
                //0x112D00, 8  regs, 8  bytes
                //0x1128B6, 24 regs, 8  bytes
                //0x275800, 5  regs, 17 bytes
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();
                br.BaseStream.Position = 0x112D00 + headerOffset;
                for (int i = 0; i < 8; i++){
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(8).ToList());
                }
                br.BaseStream.Position = 0x1128B6 + headerOffset;
                for (int i = 0; i < 24; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(8).ToList());
                }
                br.BaseStream.Position = 0x275800 + headerOffset;
                for (int i = 0; i < 5; i++)
                {
                    addresses.Add(br.BaseStream.Position - headerOffset);
                    bytesList.Add(br.ReadBytes(17).ToList());
                }
                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, concepts, font2bppChars, 17);
                form.ShowDialog();
                form.Dispose();

            }

        }



        private void buttonCSVExportNamingTemplate_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            //0x00F414
            //0x00F474

            /* Battle records */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00F414, 100 /* nRegisters */, 1 /* registersSize */);

            if (output.Count == 100)
            {
                CSV_Manager.exportCSV("NamingScreen", output);
            }
        }



        private void buttonNamingDeleteABC_Click(object sender, EventArgs e)
        {
            /*
            Naming screen cursor info
            (0040)
                      IT IP CX CY   U  D  L  R
                   ----------------------------
            (00) A9E6 18 02 40 0E / 00 03 00 01 -> ABC cursor -> Avoid displaying
            (01) A9EE 18 01 70 0E / 01 03 00 02 -> abc cursor -> Avoid displaying
            (02) A9F6 18 03 C0 0E / 02 03 01 02 -> End cursor
            (03) A9FE 19 01 40 30 / 04 05 06 07 
            (04) AA06 87 01 00 00 / 00 00 00 00 
            (05) AA0E 87 02 00 00 / 00 00 00 00 
            (06) AA16 87 03 00 00 / 00 00 00 00 
            (07) AA16 87 04 00 00 / 00 00 00 00 

            Naming screen BG3
            B5F5 01 (00 00 )				; Fill Current Layer
            B5F8 06 (0E 00 09 05 16 1A )	; Draw Indent Box
            B5FF 06 (0E 00 01 05 08 09 )	; Draw Indent Box
            B606 06 (0E 00 09 01 16 04 )	; Draw Indent Box
            B60D 04 (4E 00 0A 03 00 )		; Draw Text: (ABC) (#String, Color, X, Y, Rem) -> Avoid displaying
            B613 04 (4F 00 10 03 00 )		; Draw Text: (abc) (#String, Color, X, Y, Rem) -> Avoid displaying
            B619 04 (50 00 1A 03 00 )		; Draw Text: (End) (#String, Color, X, Y, Rem)
            B61F 00 ()						; End of Function
            */

            /* Avoid ABC display C2/B60D */
            /* Avoid abc display C2/B613 */
            Byte[] avoidDisplay = { 0x04, 0x50, 0x00, 0x1A, 0x03, 0x00 };

            /* Avoid ABC and abc cursors C2/A9E6 */
            Byte[] avoidCursors = { 0x18, 0x03, 0xC0, 0x0E, 0x00, 0x03, 0x00, 0x00 }; /* End cursor only */

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                /* Set new displays */
                bw.BaseStream.Position = 0x03B60D + headerOffset;
                foreach (Byte item in avoidDisplay)
                {
                    bw.BaseStream.WriteByte(item);
                }
                /* Position = 0x02B613 */
                foreach (Byte item in avoidDisplay)
                {
                    bw.BaseStream.WriteByte(item);
                }

                /* Set new cursor */
                bw.BaseStream.Position = 0x03A9E6 + headerOffset;
                foreach (Byte item in avoidCursors)
                {
                    bw.BaseStream.WriteByte(item);
                }

                /* Resize "End" window */
                /* B606 XX (XX XX 17 XX 8 XX ) */
                bw.BaseStream.Position = 0x03B609 + headerOffset;
                bw.BaseStream.WriteByte(0x17);  /* X = 0x17 */
                bw.BaseStream.Position = 0x03B60B + headerOffset;
                bw.BaseStream.WriteByte(0x08);  /* W = 0x08 */

            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            bw.Close();
            fs.Close();
        }



        #endregion



        #region exportVariableSizedTemplates



        private void buttonCSVExportPOL_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x2773A0 + headerOffset;

                Byte   newByte = br.ReadByte();
                String newLine = "";

                while(newByte != 0x00){
                    newLine += tblManager.TBL_Reader1bpp[newByte];
                    newByte = br.ReadByte();
                }
                
                output.Add(newLine);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            CSV_Manager.exportCSV("PoemOfLight", output);
        }



        private void buttonCSVExportBattleSpeech_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Battle Speech */
            /* 3B00 + 5632 bytes */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x10F000, 0x270000, 234, 0x00);

            if (output.Count == 234)
            {
                CSV_Manager.exportCSV("BattleSpeech", output);
            }

        }



        private void labelBattleSpeech_Click(object sender, EventArgs e)
        {
            /* Battle Speech */
            /* 3B00 + 5632 bytes */
            
            List<String> battleSpeech = new List<String>();

            battleSpeech = appendToExportList(battleSpeech, tblManager.TBL_Reader1bpp, 0x10F000, 0x270000, 234, 0x00);

            if (battleSpeech.Count == 234)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                //0x10F000, 0x270000, 234regs, XX
                long nextAddressToRead = 0x10F000 + headerOffset;
                int offset = 0;
                int nextOffset = 0;
                int size = 0;
                int maxSize = 0;
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();

                br.BaseStream.Position = nextAddressToRead;
                offset = br.ReadByte() + (br.ReadByte() * 0x0100);
                nextAddressToRead = br.BaseStream.Position;
                addresses.Add(br.BaseStream.Position - headerOffset);

                for (int i = 0; i < 234; i++)
                {
                    br.BaseStream.Position = nextAddressToRead;
                    nextOffset = br.ReadByte() + (br.ReadByte() * 0x0100);
                    nextAddressToRead = br.BaseStream.Position;

                    addresses.Add(br.BaseStream.Position - headerOffset);

                    br.BaseStream.Position = offset + 0x270000 + headerOffset;
                    size = Math.Max(nextOffset - offset, 1);
                    if (size > maxSize) maxSize = size;
                    bytesList.Add(br.ReadBytes(size).ToList());

                    offset = nextOffset;
                }

                br.Close();
                fs.Close();

                int[] fontWidths = new int[256];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    for (int j = 0; j < 16; j++)
                        fontWidths[k++] = Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber);
                Bitmap[] newFont1bppChars = new Bitmap[256];
                for (int i = 0; i < 0xD0; i++)
                    newFont1bppChars[i + 0x20] = font1bppChars[i];


                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector1bpp, addresses, bytesList, battleSpeech, newFont1bppChars, maxSize, true, fontWidths);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportBattleMsg_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Battle Speech */
            /* 2760 + 1646 bytes */
            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x1139A9, 0x270000, 81, 0x00, false, 0x10);

            if (output.Count == 81)
            {
                CSV_Manager.exportCSV("BattleMessages", output);
            }

        }



        private void labelBattleMsg_Click(object sender, EventArgs e)
        {
            /* Battle Speech */
            /* 2760 + 1646 bytes */

            List<String> battleMsg = new List<String>();

            battleMsg = appendToExportList(battleMsg, tblManager.TBL_Reader1bpp, 0x1139A9, 0x270000, 81, 0x00);
            //battleSpeech = appendToExportList(battleSpeech, tblManager.TBL_Reader1bpp, 0x10F000, 0x270000, 234, 0x00);

            if (battleMsg.Count == 81)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Locations
                //0x1139A9, 0x270000, 81regs, XX
                long nextAddressToRead = 0x1139A9 + headerOffset;
                int offset = 0;
                int nextOffset = 0;
                int size = 0;
                int maxSize = 0;
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();

                br.BaseStream.Position = nextAddressToRead;
                offset = br.ReadByte() + (br.ReadByte() * 0x0100);
                nextAddressToRead = br.BaseStream.Position;
                addresses.Add(br.BaseStream.Position - headerOffset);

                for (int i = 0; i < 81; i++)
                {
                    br.BaseStream.Position = nextAddressToRead;
                    nextOffset = br.ReadByte() + (br.ReadByte() * 0x0100);
                    nextAddressToRead = br.BaseStream.Position;

                    addresses.Add(br.BaseStream.Position - headerOffset);

                    br.BaseStream.Position = offset + 0x270000 + headerOffset;
                    size = Math.Max(nextOffset - offset, 1);
                    if (size > maxSize) maxSize = size;
                    bytesList.Add(br.ReadBytes(size).ToList());

                    offset = nextOffset;
                }

                br.Close();
                fs.Close();

                int[] fontWidths = new int[256];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    for (int j = 0; j < 16; j++)
                        fontWidths[k++] = Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber);
                Bitmap[] newFont1bppChars = new Bitmap[256];
                for (int i = 0; i < 0xD0; i++)
                    newFont1bppChars[i + 0x20] = font1bppChars[i];


                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector1bpp, addresses, bytesList, battleMsg, newFont1bppChars, maxSize, true, fontWidths);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportItempDesc_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Item descriptions */
            /* 5200 + 1470 bytes */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x275100, 0x270000, 128, 0x00);

            if (output.Count == 128)
            {
                CSV_Manager.exportCSV("ItemDescriptions", output);
            }
        }



        private void buttonCSVExportJobsDesc_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Jobs descriptions */
            /* 724A + 3414 bytes */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x117140, 0x110000, 133, 0x00);

            if (output.Count == 133)
            {
                CSV_Manager.exportCSV("JobsDescriptions", output);
            }
        }



        private void buttonCSVExportLocations_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Locations */
            /* 0000 + 2304 bytes */
            output = appendToExportListSU(output, tblManager.TBL_Reader1bpp, 0x107000, 0x270000, 164);

            if (output.Count == 164)
            {
                CSV_Manager.exportCSV("Locations", output);
            }
        }



        private void labelLocations_Click(object sender, EventArgs e)
        {
            List<String> locations = new List<String>();

            /* Monster attacks names */
            locations = appendToExportListSU(locations, tblManager.TBL_Reader1bpp, 0x107000, 0x270000, 164);
            //monsterAttacks = appendToExportList(monsterAttacks, tblManager.TBL_Reader1bpp, 0x273700, 64 /* nRegisters */, 16 /* registersSize */);

            if (locations.Count == 164)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Locations
                //0x107000, 0x270000, 164regs, XX
                long nextAddressToRead = 0x107000 + headerOffset;
                int  offset = 0;
                int  nextOffset = 0;
                int  size = 0;
                int  maxSize = 0;
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();

                br.BaseStream.Position = nextAddressToRead;
                offset = br.ReadByte() + (br.ReadByte() * 0x0100);
                nextAddressToRead = br.BaseStream.Position;
                addresses.Add(br.BaseStream.Position - headerOffset);

                for (int i = 0; i < 164; i++)
                {
                    br.BaseStream.Position = nextAddressToRead;
                    nextOffset = br.ReadByte() + (br.ReadByte() * 0x0100);
                    nextAddressToRead = br.BaseStream.Position;

                    addresses.Add(br.BaseStream.Position - headerOffset);

                    br.BaseStream.Position = offset + 0x270000 + headerOffset;
                    size = Math.Max(nextOffset - offset, 1);
                    if (size > maxSize) maxSize = size;
                    bytesList.Add(br.ReadBytes(size).ToList());

                    offset = nextOffset;
                }

                br.Close();
                fs.Close();

                int[] fontWidths = new int[256];
                int k = 0;
                for (int i = 0; i < 16; i++)
                    for (int j = 0; j < 16; j++)
                        fontWidths[k++] = Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber);
                Bitmap[] newFont1bppChars = new Bitmap[256];
                for (int i = 0; i < 0xD0; i++)
                    newFont1bppChars[i + 0x20] = font1bppChars[i];


                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector1bpp, addresses, bytesList, locations, newFont1bppChars, maxSize, true, fontWidths);
                form.ShowDialog();
                form.Dispose();
            }
        }



        private void buttonCSVExportConceptsV_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Concepts */
            /* 2F00 + 1632 bytes */
            output = appendToExportList(output, tblManager.TBL_Reader2bpp, 0x00F987, 0x270000, 139, 0x00);

            if (output.Count == 139)
            {
                CSV_Manager.exportCSV("VConcepts", output);
            }

        }

        
        
        private void labelConceptsVar_Click(object sender, EventArgs e)
        {
            /* Concepts */
            /* 2F00 + 1632 bytes */
            List<String> concepts = new List<String>();

            /* Monster attacks names */
            concepts = appendToExportList(concepts, tblManager.TBL_Reader2bpp, 0x00F987, 0x270000, 139, 0x00);
            //locations = appendToExportListSU(locations, tblManager.TBL_Reader1bpp, 0x107000, 0x270000, 164);

            if (concepts.Count == 139)
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                // Locations
                //0x00F987, 0x270000, 139regs, XX
                long nextAddressToRead = 0x00F987 + headerOffset;
                int offset = 0;
                int nextOffset = 0;
                int size = 0;
                int maxSize = 0;
                List<long> addresses = new List<long>();
                List<List<Byte>> bytesList = new List<List<byte>>();

                br.BaseStream.Position = nextAddressToRead;
                offset = br.ReadByte() + (br.ReadByte() * 0x0100);
                nextAddressToRead = br.BaseStream.Position;
                addresses.Add(br.BaseStream.Position - headerOffset);

                for (int i = 0; i < 139; i++)
                {
                    br.BaseStream.Position = nextAddressToRead;
                    nextOffset = br.ReadByte() + (br.ReadByte() * 0x0100);
                    nextAddressToRead = br.BaseStream.Position;

                    addresses.Add(br.BaseStream.Position - headerOffset);

                    br.BaseStream.Position = offset + 0x270000 + headerOffset;
                    size = Math.Max(nextOffset - offset, 1);
                    if (size > maxSize) maxSize = size;
                    bytesList.Add(br.ReadBytes(size).ToList());

                    offset = nextOffset;
                }

                br.Close();
                fs.Close();

                Form5 form = new Form5(fileUnderEdition, headerOffset, tblManager.TBL_Injector2bpp, addresses, bytesList, concepts, font2bppChars, maxSize, true);
                form.ShowDialog();
                form.Dispose();
            }

        }



        private void buttonCSVExportSpeech_Click(object sender, EventArgs e)
        {
            List<String> output = new List<String>();

            /* Speech */
            /* 21/0000 + 393216 bytes */
            /* Take care about the last bytes of every bank. A speech cannot be splited */

            output = appendToExportList(output, tblManager.TBL_Reader1bpp, 0x2013F0, 0x210000, 2160, 0x00, true);

            if (output.Count == 2160)
            {
                CSV_Manager.exportCSV("Speech", output);
            }
        }



        private void buttonEditSpeech_Click(object sender, EventArgs e)
        {
            List<String> list         = new List<String>();
            String       current      = "";
            int          currentValue = (int)numericUpDownIdSpeech.Value;

            /* Speech */
            /* 21/0000 + 393216 bytes */
            /* Take care about the last bytes of every bank. A speech cannot be splited */
            list = appendToExportList(list, tblManager.TBL_Reader1bpp, 0x2013F0, 0x210000, 2160, 0x00, true);
            current = list[currentValue];
            current = current.Replace(tblManager.TBL_Reader1bpp[0x01], "\r\n");

            Form3 form3 = new Form3(current);
            form3.ShowDialog();

            if (form3.ok)
            {
                current = form3.text;
                current = current.Replace("\r\n", tblManager.TBL_Reader1bpp[0x01]);
                list[(int)numericUpDownIdSpeech.Value] = current;
                /* Speech */
                /* 0xE10000 + 0x060000 bytes */
                ImportVariableSizeTable(list, tblManager.TBL_Injector1bpp, 0x2013F0, 0x210000, 2160, 0x050000, true, 0x00, true, true);

                numericUpDownIdSpeech_ValueChanged(null, null);
                panelMainSpeech.Refresh();
            }

            form3.Dispose();
        }



        private void buttonCSVImportCredits_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            /* C3/7B92, Compressed, 02 CE 03 + Sequences */
            /* C3/7E4A */
            /* Max Size = 0x2B7 */

            List<Byte> first = new List<Byte>();
            String syntaxErrors = "";
            bool   syntaxError  = false;

            foreach (String item in inputStr)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    try
                    {
                        if (item[i] == '[')
                        {
                            first.Add(Byte.Parse(item.Substring(i + 1, 2), System.Globalization.NumberStyles.HexNumber));
                            i += 3;
                        }
                        else if (item[i] == ' ')
                        {
                            first.Add(0x00);
                        }
                        else
                        {
                            first.Add((byte)(item[i] - 0x40));
                        }
                    }
                    catch (Exception)
                    {
                        syntaxErrors += "The register " + item + " cannot be parsed\r\n";
                        syntaxError = true;
                        break;
                    }
                }
            }
            /*
            else
            {
                first.Add(0x85);
                foreach (char subitem in item)
                {
                    if (subitem == ' ')
                        first.Add(0x00);
                    else
                        
                }
            }*/

            if (syntaxError)
            {
                /* Error in syntax of file */
                MessageBox.Show(syntaxErrors, "Invalid file");
                return;

            }


            Byte firstSizeByte = (Byte)((first.Count & 0x00FF));
            Byte secondSizeByte = (Byte)((first.Count & 0xFF00) >> 8);

            /* C3/7B92, Compressed, 02 + Size + Sequences */
            /* Size = CE 03 */
            /* C3/7E4A */
            /* Max Size = 0x2B7 */

            List<Byte> compressed = Compressor.compress(first, progressBarCompress, 0x07DE, 0x0800);
            int listSize = compressed.Count;
            int maxSize = 0x2B7;
            compressed.Insert(0, secondSizeByte);
            compressed.Insert(0, firstSizeByte);

            if (listSize > maxSize)
            {
                /* Overflow */
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\n" + maxSize + " bytes long were expected.",
                                "Invalid file");
                return;
            }
            else
            {
                /* Size is right! */
                MessageBox.Show("The file is ok:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\nLess than " + maxSize + " bytes long were expected.",
                                "Sucessfully parsed!");
            }

            /* Everything OK. Inject data. */
            injectOn(new List<List<Byte>>() { compressed }, 0x037B93);
        }



        private void buttonCSVImportStaff_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            /* Staff */
            /* C3/362B, Compressed, 02 EA 02 + Sequences */
            /* C3/383B, Is the last character after that, there are another compressed table */
            /* Max Size = 0x210 */

            List<Byte> first = new List<Byte>();

            foreach (String item in inputStr)
            {
                if (item == "")
                {
                    first.Add(0x86);
                }
                else
                {
                    first.Add(0x85);
                    foreach (char subitem in item)
                    {
                        if (subitem == ' ')
                            first.Add(0x00);
                        else
                            first.Add((byte)(subitem - 0x40));
                    }
                }

            }
            first.Add(0x80);

            Byte firstSizeByte = (Byte)((first.Count & 0x00FF));
            Byte secondSizeByte = (Byte)((first.Count & 0xFF00) >> 8);

            /* C3/362B, Compressed, 02 + Size + Sequences */
            /* Size = EA 02 */
            /* C3/383B */

            List<Byte> compressed = Compressor.compress(first, progressBarCompress, 0x07DE, 0x0800);
            int listSize = compressed.Count;
            int maxSize = 0x20F;
            compressed.Insert(0, secondSizeByte);
            compressed.Insert(0, firstSizeByte);

            if (listSize > maxSize)
            {
                /* Overflow */
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\n" + maxSize + " bytes long were expected.",
                                "Invalid file");
                return;
            }
            else
            {
                /* Size is right! */
                MessageBox.Show("The file is ok:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\nLess than " + maxSize + " bytes long were expected.",
                                "Sucessfully parsed!");
            }

            /* Everything OK. Inject data. */
            injectOn(new List<List<Byte>>() { compressed }, 0x03362C);
        }


        
        private void buttonCSVExportStaffFont_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            if (!fileToEditIsAvailable)
                return;

            /* Staff font */
            /* C3/33F6, Compressed 02, 00, 08 */
            /* C3/362A, Table size <= 0x0235 */

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> staffFont4bpp = Compressor.uncompress(0x0333F6, br, headerOffset);

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform4b(staffFont4bpp, 0, staffFont4bpp.Count);
            ManageBMP.exportBPM("Staff font", newBitmap, Palettes.palette4b);
            newBitmap.Dispose();
        }



        private void buttonCSVImportStaffFont_Click(object sender, EventArgs e)
        {
            /* Staff font */
            /* C3/33F6, Compressed 02, 00, 08 */
            /* C3/362A, Table size <= 0x0234 */
            List<Byte> newBytes = new List<Byte>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                        int size = bitmap.Width * bitmap.Height;
                        byte[] bitmapPixels = new byte[size];

                        /* Open it to edit */
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Recover the original values (now lost because of the conversion) */
                        for (int i = 0; i < size; i++)
                        {
                            bitmapPixels[i] = System.Runtime.InteropServices.Marshal.ReadByte(data.Scan0, i);
                        }

                        bitmap.Dispose();

                        int nColumns = (int)Math.Truncate(128.0 / 8);
                        size = (size - (size % ((8 * nColumns) * 8)));
                        if (size == 0x000800 * 2)
                            newBytes = InvertingTransformations.import4bpp(bitmapPixels, 8, 8, size);
                        else
                            newBytes = new List<Byte>();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                    }
                }
            }

            openFileDialog.Dispose();
            openFileDialog = null;

            newBytes = Compressor.compress(newBytes, progressBarCompress);
            newBytes.Insert(0, 0x08);
            newBytes.Insert(0, 0x00);
            newBytes.Insert(0, 0x02);

            /* Staff font */
            /* C3/33F6, Compressed 02, 00, 08 */
            /* C3/362A, Table size <= 0x0234 */
            if (newBytes.Count <= 0x0235)
            {
                injectOn(new List<List<Byte>>() { newBytes }, 0x0333F6);
            }
            else
            {
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + newBytes.Count +
                                " bytes long.\r\n565 bytes long were expected.",
                                "Invalid file");
            }
        }



        private void buttonCSVExportStaff_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            if (!fileToEditIsAvailable)
                return;

            /* Staff */
            /* C3/362B, Compressed, 02 EA 02 + Sequences */
            /* C3/383F */

            System.IO.FileStream fs   = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> input    = Compressor.uncompress(0x03362B, br, headerOffset);

            br.Close();
            fs.Close();

            List<String> output = new List<String>();
            String words = "";

            foreach (Byte item in input)
            {
                if (item == 0)
                {
                    words += " ";
                }
                else if (item < 0x5B)
                {
                    words += (char)(item + 0x40);
                }
                else
                {
                    //words += "[" + item.ToString("X2") + "]";
                    //0x85 Before every line
                    //0x86 After a group
                    //0x80 To finish
                    output.Add(words);
                    words = "";
                }
            }

            output = output.GetRange(1, output.Count - 2);

            CSV_Manager.exportCSV("Staff", output);
        }



        private void buttonCSVExportCredits_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            if (!fileToEditIsAvailable)
                return;

            /* Credits */
            /* C3/7B92, Compressed, 02 CE 03 + Sequences */
            /* C3/7E4A */

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> input = Compressor.uncompress(0x037B92, br, headerOffset);

            br.Close();
            fs.Close();

            List<String> output = new List<String>();
            String words = "";

            foreach (Byte item in input)
            {
                if (item == 0)
                {
                    words += " ";
                }
                else if (item < 0x1E)
                {
                    words += (char)(item + 0x40);
                }
                else
                {
                    words += "[" + item.ToString("X2") + "]";
                    //0x85 Before every line
                    //0x86 After a group
                    //0x80 To finish
                    output.Add(words);
                    words = "";
                }
            }

            CSV_Manager.exportCSV("Credits", output);
        }



        private void buttonImageExportDragon_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            if (!fileToEditIsAvailable)
                return;

            /* Title dragon */
            /* C3/2D22, Compressed */
            /* C3/331E */

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> dragon4bpp = Compressor.uncompress(0x032D22, br, headerOffset);

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform4b(dragon4bpp, 0, dragon4bpp.Count);
            ManageBMP.exportBPM("Title Dragon", newBitmap, Palettes.palette4b);
            newBitmap.Dispose();
        }



        private void buttonImageExportTheEnd_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            /* The End */
            /* D0/E4CB, Compressed */
            /* D0/EBE4, < 0x071A */

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());
            
            //Dummy.displayCompressedTable(br, 0x1063AF, headerOffset); /* C SQUARE 1992 + Dragon : OAM mapping */
            //System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            //Dummy.injectImage(bw, 0x105CF5, headerOffset, 0x04, 0x1400, 0x0BF5); /* New Title */
            //Dummy.injectNewTitleOAM(bw, headerOffset); /* D0/5C0A */
            //bw.Close();
            //return;
            //Dummy.mapDecypher(br, headerOffset, 0x0F);

            List<Byte> theEnd = Compressor.uncompress(0x10E4CB, br, headerOffset, true);

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform4b(theEnd, 0, theEnd.Count);
            ManageBMP.exportBPM("The End", newBitmap, Palettes.palette4b);
            newBitmap.Dispose();
        }
        
        

        private void buttonImageImportDragon_Click(object sender, EventArgs e)
        {
            /* Title dragon */
            /* C3/2D22, Compressed */
            /* C3/331E */
            /* 5FC */
            List<Byte> newBytes = new List<Byte>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        Bitmap bitmap = new Bitmap(openFileDialog.FileName);

                        int size = bitmap.Width * bitmap.Height;
                        byte[] bitmapPixels = new byte[size];

                        /* Open it to edit */
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Recover the original values (now lost because of the conversion) */
                        for (int i = 0; i < size; i++)
                        {
                            bitmapPixels[i] = System.Runtime.InteropServices.Marshal.ReadByte(data.Scan0, i);
                        }

                        int nColumns = (int)Math.Truncate(128.0 / 8);
                        size = (size - (size % ((8 * nColumns) * 8)));
                        if (size == 0x001200 * 2)
                            newBytes = InvertingTransformations.import4bpp(bitmapPixels, 8, 8, size);
                        else
                            newBytes = new List<Byte>();

                        bitmap.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                    }
                }
            }

            openFileDialog.Dispose();
            openFileDialog = null;

            newBytes = Compressor.compress(newBytes, progressBarCompress);
            newBytes.Insert(0, 0x12);
            newBytes.Insert(0, 0x00);
            newBytes.Insert(0, 0x02);

            if (newBytes.Count <= 0x05FD)
            {
                injectOn(new List<List<Byte>>() { newBytes }, 0x032D23);
            }
            else
            {
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + newBytes.Count +
                                " bytes long.\r\n1533 bytes long were expected.",
                                "Invalid file");
            }
        }



        private void buttonImageImportTheEnd_Click(object sender, EventArgs e)
        {
            /* The End */
            /* D0/E4CB, Compressed */
            /* D0/EBE4, < 0x071A */

            List<Byte> newBytes = new List<Byte>();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                        int size = bitmap.Width * bitmap.Height;
                        byte[] bitmapPixels = new byte[size];

                        /* Open it to edit */
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Recover the original values (now lost because of the conversion) */
                        for (int i = 0; i < size; i++)
                        {
                            bitmapPixels[i] = System.Runtime.InteropServices.Marshal.ReadByte(data.Scan0, i);
                        }

                        int nColumns = (int)Math.Truncate(128.0 / 8);
                        size = (size - (size % ((8 * nColumns) * 8)));
                        if (size == 0x001000 * 2)
                            newBytes = InvertingTransformations.import4bpp(bitmapPixels, 8, 8, size);
                        else
                            newBytes = new List<Byte>();

                        bitmap.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                    }
                }
            }

            openFileDialog.Dispose();
            openFileDialog = null;

            newBytes = Compressor.compress(newBytes, progressBarCompress);
            newBytes.Insert(0, 0x10);
            newBytes.Insert(0, 0x00);

            if (newBytes.Count <= 0x071A)
            {
                injectOn(new List<List<Byte>>() { newBytes }, 0x10E4CB);
            }
            else
            {
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + newBytes.Count +
                                " bytes long.\r\n1818 bytes long were expected.",
                                "Invalid file");
            }
        }



        private void buttonExportGenericCompress_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(true);
            form4.ShowDialog();

            bool isOk       = form4.isOk;
            bool isUnheaded = form4.isUnheaded;
            bool isImage    = form4.isImage;
            int  ctype      = form4.ctype;
            int  bpp        = form4.bpp;

            form4.Dispose();

            if (!isOk)
                return;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            int maxSize = 0;
            int placeToReadFrom = 0;
            Int32.TryParse(textBoxCompressedLimit.Text, System.Globalization.NumberStyles.HexNumber, null, out maxSize);
            Int32.TryParse(textBoxCompressedPlace.Text, System.Globalization.NumberStyles.HexNumber, null, out placeToReadFrom);

            if (placeToReadFrom <= 0)
                return;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            List<Byte> first = Compressor.uncompress(placeToReadFrom, br, headerOffset, isUnheaded);

            br.Close();
            fs.Close();

            if (isImage)
            {
                Bitmap newBitmap = new Bitmap(1, 1);

                switch (bpp)
                {
                    case 01:
                        newBitmap = Transformations.transform1bpp(first, 0, first.Count);
                        ManageBMP.exportBPM("Compressed 1pbb", newBitmap, Palettes.palette1b);
                        break;
                    case 02:
                        newBitmap = Transformations.transform2bpp(first, 0, first.Count);
                        ManageBMP.exportBPM("Compressed 2pbb", newBitmap, Palettes.palette2b);
                        break;
                    case 03:
                        newBitmap = Transformations.transform3bpp(first, 0, first.Count);
                        ManageBMP.exportBPM("Compressed 3pbb", newBitmap, Palettes.palette3b);
                        break;
                    case 04:
                        newBitmap = Transformations.transform4b(first, 0, first.Count);
                        ManageBMP.exportBPM("Compressed 4pbb", newBitmap, Palettes.palette4b);
                        break;
                    default:
                        break;
                };

                newBitmap.Dispose();
            }
            else
            {
                /* Displays an SaveFileDialog so the user can select a file */
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Choose a file";

                /* Show the Dialog */
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                    {
                        System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open(saveFileDialog.FileName, System.IO.FileMode.OpenOrCreate));

                        try
                        {
                            bw.Write(first.ToArray());
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                        }

                        bw.Close();
                    }
                }

                saveFileDialog.Dispose();
                saveFileDialog = null;
            }
        }

        

        private void buttonImageImportGenericCompress_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(false);
            form4.ShowDialog();

            bool isOk       = form4.isOk;
            bool isUnheaded = form4.isUnheaded;
            bool isImage    = form4.isImage;
            int  ctype      = form4.ctype;
            int  bpp        = form4.bpp;

            form4.Dispose();

            if (!isOk)
                return;

            List<Byte> first = new List<Byte>();

            if (isImage)
            {
                first = ManageBMP.importBPM(0, bpp);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Choose a file";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog.FileName != "")
                    {
                        try
                        {
                            first = System.IO.File.ReadAllBytes(openFileDialog.FileName).ToList();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }

                openFileDialog.Dispose();
            }


            Byte firstSizeByte = (Byte)((first.Count & 0x00FF));
            Byte secondSizeByte = (Byte)((first.Count & 0xFF00) >> 8);

            int maxSize        = 0;
            int placeToWriteOn = 0;
            Int32.TryParse(textBoxCompressedLimit.Text, System.Globalization.NumberStyles.HexNumber, null, out maxSize);
            Int32.TryParse(textBoxCompressedPlace.Text, System.Globalization.NumberStyles.HexNumber, null, out placeToWriteOn);

            if (placeToWriteOn <= 0)
                return;

            int listSize = 0;
            List<Byte> compressed = new List<byte>();

            if (isUnheaded || ctype == 2)
            {
                /* Compressor Type 02 */
                compressed = Compressor.compress(first, progressBarCompress, 0x07DE, 0x0800);

                compressed.Insert(0, secondSizeByte);
                compressed.Insert(0, firstSizeByte);
            }
            else if (ctype == 0)
            {
                /* Compressor Type 00 */
                compressed = first;

                compressed.Insert(0, secondSizeByte);
                compressed.Insert(0, firstSizeByte);
            }
            else if (ctype == 1){
                /* Compressor Type 01 */;
                compressed = Compressor.compressType01(first);
            }

            /* Head if required and calculate size of compressed data */
            if (!isUnheaded)
                compressed.Insert(0, BitConverter.GetBytes(ctype)[0]);
            listSize = compressed.Count;


            if (listSize > maxSize)
            {
                /* Overflow */
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\n" + maxSize + " bytes long were expected.",
                                "Invalid file");
                return;
            }
            else
            {
                /* Size is right! */
                MessageBox.Show("The file is ok:\r\n\r\nThe file is " + listSize +
                                " bytes long.\r\nLess than " + maxSize + " bytes long were expected.",
                                "Sucessfully compressed!");
            }

            DialogResult dr = MessageBox.Show("This utility is VERY experimental.\r\nYou can damage permanently the ROM file.\r\nAre you sure to proceed?", "Warning!", MessageBoxButtons.YesNo);

            if (dr != DialogResult.Yes)
                return;

            /* Everything OK. Inject data. */
            injectOn(new List<List<Byte>>() { compressed }, placeToWriteOn);
        }
        


        #endregion



        private void listViewTextWidths_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // E0/3100-3140: Misc. menu text fields
            // E7/FAD9-FFFF: Misc. menu text fields

            /* ListView edition - Functional appends */
            hitinfo = listViewTextWidths.HitTest(e.X, e.Y);

            if (hitinfo.SubItem != null)
            {
                editBox.Bounds = new Rectangle(hitinfo.SubItem.Bounds.X - 2,
                    hitinfo.SubItem.Bounds.Y - 2,
                    hitinfo.SubItem.Bounds.Width + 9,
                    hitinfo.SubItem.Bounds.Height + 9);
                editBox.Text = hitinfo.SubItem.Text;
                editBox.Focus();
                editBox.Show();
            }
        }



        void editbox_LostFocus(object sender, EventArgs e)
        {
            hitinfo.SubItem.Text = Byte.Parse(editBox.Text, System.Globalization.NumberStyles.HexNumber).ToString("X2");
            font1bppBitmapW = generateWidthsPreview();
            panelFonts.Refresh();
            panel2bpp.Refresh();
            panelMuteSpell.Refresh();
            editBox.Hide();
        }



        #region importFixedSizedTextTables



        private void buttonCSVImportMonsters_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            /* Monster names */
            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x200050, 384, 10, 0xFF);
        }



        private void buttonCSVImportMonsterAttacks_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            /* Monster Attacks */
            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector1bpp, 0x273700, 64, 16, 0xFF);
        }



        private void buttonCSVImportSkillsM_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 294)
            {
                return;
            }

            /* SkillsM 01 */
            ImportFixedSizeTable(inputStr.GetRange(0, 87), tblManager.TBL_Injector2bpp, 0x111C80, 87, 6, 0xFF);

            /* SkillsM 02 */
            ImportFixedSizeTable(inputStr.GetRange(87, 169), tblManager.TBL_Injector2bpp, 0x270F90, 169, 12, 0xFF, true);

            /* SkillsM Blue */
            ImportFixedSizeTable(inputStr.GetRange(256, 30), tblManager.TBL_Injector2bpp, 0x11200D, 30, 9, 0xFF);	

            /* SkillsM Songs */
            ImportFixedSizeTable(inputStr.GetRange(286, 8), tblManager.TBL_Injector2bpp, 0x111E8A, 8, 9, 0xFF, true);
        }



        private void buttonCSVImportSkillsB_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 274)
            {
                return;
            }

            /* SkillsB */
            ImportFixedSizeTable(inputStr.GetRange(0, 105), tblManager.TBL_Injector1bpp, 0x270900, 105, 16, 0xFF);

            /* SkillsB 02 */
            ImportFixedSizeTable(inputStr.GetRange(105, 169), tblManager.TBL_Injector1bpp, 0x271780, 169, 24, 0xFF);
        }



        private void buttonCSVImportCommands_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 161)
            {
                return;
            }

            /* Commands */
            ImportFixedSizeTable(inputStr.GetRange(0, 95), tblManager.TBL_Injector2bpp, 0x201150, 95, 7, 0xFF);

            /* Abilities (menu) */
            ImportFixedSizeTable(inputStr.GetRange(95, 33), tblManager.TBL_Injector2bpp, 0x116200, 33, 8, 0xFF);

            /* Abilities (Battle) */
            ImportFixedSizeTable(inputStr.GetRange(128, 33), tblManager.TBL_Injector1bpp, 0x277060, 33, 24, 0xFF);	
        }



        private void buttonCSVImportItems_Click(object sender, EventArgs e)
        {
             List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 536)
            {
                return;
            }

            /* Fix the blanks translating them to 0xFF */
            for(int i = 0 ; i < 256 ; i++){
                inputStr[i] = inputStr[i].Replace(" ", "[FF]");
            }

            /* Items (menu) */
            ImportFixedSizeTable(inputStr.GetRange(0, 256), tblManager.TBL_Injector2bpp, 0x111380, 256, 9, 0xFF);

            /* Rare items (menu) */
            ImportFixedSizeTable(inputStr.GetRange(256, 24), tblManager.TBL_Injector2bpp, 0x273568, 24, 13, 0xFF);

            /* Items (battle) */
            ImportFixedSizeTable(inputStr.GetRange(280, 256), tblManager.TBL_Injector1bpp, 0x275860, 256, 24, 0xFF);
        }



        private void buttonCSVImportCharacters_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 27)
            {
                return;
            }

            /* Characters */
            ImportFixedSizeTable(inputStr.GetRange(0, 5), tblManager.TBL_Injector2bpp, 0x115500, 5, 6, 0xFF);

            /* Characters */
            ImportFixedSizeTable(inputStr.GetRange(5, 22), tblManager.TBL_Injector2bpp, 0x115600, 22, 8, 0xFF);
        }



        private void buttonCSVImportConcepts_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 37)
            {
                return;
            }

            /* Battle records */
            ImportFixedSizeTable(inputStr.GetRange(0, 4), tblManager.TBL_Injector2bpp, 0x275800, 5, 17, 0xFF);

            /* Shop names */
            ImportFixedSizeTable(inputStr.GetRange(4, 8), tblManager.TBL_Injector2bpp, 0x112D00, 8, 8, 0xFF);

            /* Concepts */
            ImportFixedSizeTable(inputStr.GetRange(12, 24), tblManager.TBL_Injector2bpp, 0x1128B6, 24, 8, 0xFF);
        }



        private void buttonCSVImportNaming_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count == 0)
                return;

            if (inputStr.Count < 100)
            {
                return;
            }

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00F414, 100, 1, 0xFF);
        }



        #endregion



        #region importVariableSizedTextTables



        private void buttonCSVImportBattleSpeech_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            /* Battle Speech */
            /* 3B00 + 5632 bytes */
            ImportBattleSpeechTable(inputStr, tblManager.TBL_Injector1bpp, 0x10F000, 0x273B00, 234, 5632);
        }



        private void buttonCSVImportBattleMsg_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            for (int i = 0; i < inputStr.Count; i++)
            {
                inputStr[i] = inputStr[i].Replace(" ", "[FF]");
            }

            /* Battle Speech */
            /* 2760 + 1646 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector1bpp, 0x1139A9, 0x272760, 81, 1646);
        }



        private void buttonCSVImportItempDesc_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            for (int i = 0; i < inputStr.Count; i++)
            {
                inputStr[i] = inputStr[i].Replace(" ", "[FF]");
            }

            /* Item descriptions */
            /* 5200 + 1470 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x275100, 0x275200, 128, 1470);
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x114000, 0x114100, 128, 1470);
        }



        private void buttonCSVImportJobsDesc_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            /*
            Offsets	D1/7140 to 724A (133 of 2 bytes)
	        Texts	D1/724A to 7FA0 (3414 bytes)
            */
            for (int i = 0; i < inputStr.Count; i++)
            {
                inputStr[i] = inputStr[i].Replace(" ", "[FF]");
            }

            /* Jobs descriptions */
            /* 724A + 3414 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x117140, 0x11724A, 133, 3414);
        }



        private void buttonCSVImportLocations_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            /* Areas */
            /* 0000 + 2304 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector1bpp, 0x107000, 0x270000, 164, 2304, false);
        }



        private void buttonCSVImportConceptsV_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            for (int i = 0; i < inputStr.Count ; i++)
            {
                inputStr[i] = inputStr[i].Replace(" ", "[FF]");
            }

            /* Concepts */
            /* 2F00 + 1632 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00F987, 0x272F00, 139, 1632);
        }



        private void buttonCSVImportSpeech_Click(object sender, EventArgs e)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            /* Speech */
            /* 0xE10000 + 0x060000 bytes */
            ImportVariableSizeTable(inputStr, tblManager.TBL_Injector1bpp, 0x2013F0, 0x210000, 2160, 0x050000, true, 0x00, true);
        }



        #endregion



        #region exportImages



        private void button2bppFontExport_Click(object sender, EventArgs e)
        {
            /* 2bbp */
            /* Offset 0x11F000 */
            /* Size   0x001000 */

            List<byte> byteMap = new List<byte>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x11F000 + headerOffset;

                for (int i = 0; i < 0x001000; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform2bpp(byteMap, 0, 0x001000);

            ManageBMP.exportBPM("2bpp Font", newBitmap, Palettes.palette2b);

            newBitmap.Dispose();
        }



        private void button1bppFontExport_Click(object sender, EventArgs e)
        {
            /* Offset 0x03EB00 */
            /* Size   0x0012C0 */

            List<byte> byteMap = new List<byte>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x03EB00 + headerOffset;

                for (int i = 0 ; i < 0x0012C0 ; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform1bpp(byteMap, 0, 0x0012C0);

            ManageBMP.exportBPM("1bpp Font", newBitmap, Palettes.palette1b);

            newBitmap.Dispose();
        }



        private void buttonPoemOfLightFontExport_Click(object sender, EventArgs e)
        {
            /* Offset 0x203724 */
            /* Size   0x001380 */

            List<byte> byteMap = new List<byte>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x203724 + headerOffset;

                for (int i = 0; i < 0x001380; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform1bpp(byteMap, 0, 0x001380);

            ManageBMP.exportBPM("1bpp Poem Font", newBitmap, Palettes.palette1b);

            newBitmap.Dispose();
        }


        
        private void buttonDamageFontExport_Click(object sender, EventArgs e)
        {
            /* 3bbp */
            /* Offset 0x149E20 */
            /* Size   0x000180 */

            List<byte> byteMap = new List<byte>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x149E20 + headerOffset;

                for (int i = 0; i < 0x000180; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform3bpp(byteMap, 0, 0x000180);

            ManageBMP.exportBPM("3bpp Damage Font", newBitmap, Palettes.palette3b);

            newBitmap.Dispose();
        }



        private void buttonOtherFontExport_Click(object sender, EventArgs e)
        {
            /* 4bbp */
            /* Offset 0x00D380 */
            /* Size   0x000600 */

            List<byte> byteMap = new List<byte>();

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x0000D380 + headerOffset;

                for (int i = 0; i < 0x000600; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            Bitmap newBitmap = Transformations.transform4b(byteMap, 0, 0x000600);

            ManageBMP.exportBPM("4bpp Other Font", newBitmap, Palettes.palette4b);

            newBitmap.Dispose();
        }



        private Bitmap getMuteSpellBitmap()
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return new Bitmap(1, 1);
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            Bitmap output = getMuteSpellBitmap(br);

            br.Close();
            fs.Close();

            return output;
        }



        private Bitmap getMuteSpellBitmap(System.IO.BinaryReader br)
        {
            List<byte> byteMap = new List<byte>();

            try
            {
                br.BaseStream.Position = 0x193D98 + headerOffset;

                for (int i = 0; i < 0x000300; i++)
                {
                    byteMap.Add((Byte)br.BaseStream.ReadByte());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                byteMap.Clear();
            }

            if (byteMap.Count == 0)
                return new Bitmap(1, 1);


            Bitmap newBitmap = Transformations.transform3bpp(byteMap, 0, 0x000300);
            Bitmap output = new Bitmap(32, 32);

            List<int> xTilesToOutput = new List<int>() { 0x20, 0x28, 0x30, 0x10, 0x40, 0x48, 0x50, 0x58, 0x18, 0x20, 0x28, 0x30, 0x60, 0x68, 0x70, 0x78 };
            List<int> yTilesToOutput = new List<int>() { 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x08, 0x08, 0x08, 0x08, 0x00, 0x00, 0x00, 0x00 };

            int index = 0;

            for (int l = 0; l < 32; l += 8)
                for (int k = 0; k < 32; k += 8)
                {
                    int di = xTilesToOutput[index];
                    int dj = yTilesToOutput[index++];
                    for (int j = 0; j < 8; j++)
                        for (int i = 0; i < 8; i++)
                            output.SetPixel(k + i, l + j, newBitmap.GetPixel(i + di, j + dj));
                }

            newBitmap.Dispose();
            return output;
        }



        private void buttonMuteExport_Click(object sender, EventArgs e)
        {
            /* Mute 3bpp 8x8 */
            /* D9/3D98 */

            Bitmap output = getMuteSpellBitmap();
            if (output.Width != 32 || output.Height != 32)
                return;

            ManageBMP.exportBPM("3bpp Mute Spell", output, Palettes.palette3b);

            output.Dispose();
        }



        #endregion exportImages
        

        
        #region importImages
        
        

        private void button1bppFontImport_Click(object sender, EventArgs e)
        {
            importPNG(0);
        }



        private void buttonPoemOfLightFontImport_Click(object sender, EventArgs e)
        {
            importPNG(2);
        }



        private void button2bppFontImport_Click(object sender, EventArgs e)
        {
            importPNG(1);
        }



        private void buttonDamageFontImport_Click(object sender, EventArgs e)
        {
            /* 3bbp */
            /* Offset 0x149E20 */
            /* Size   0x000180 */

            List<Byte> newBytes = ManageBMP.importBPM(0x0200, 3);

            if (newBytes.Count == 0)
                return;

            injectOn(new List<List<Byte>>() { newBytes }, 0x149E20);
        }



        private void buttonOtherFontImport_Click(object sender, EventArgs e)
        {
            /* 4bbp */
            /* Offset 0x00D380 */
            /* Size   0x000600 */

            List<Byte> newBytes = ManageBMP.importBPM(0x0600, 4);

            if (newBytes.Count == 0)
                return;

            injectOn(new List<List<Byte>>() { newBytes }, 0x00D380);
        }



        private void buttonMuteImport_Click(object sender, EventArgs e)
        {
            /* Mute 3bpp 8x8 */
            /* D9/3D98 */

            Bitmap muteBitmap;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        muteBitmap = new Bitmap(openFileDialog.FileName);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            if (muteBitmap.Width != 32 || muteBitmap.Height != 32)
            {
                MessageBox.Show("Not valid Mute Spell bitmap.", "Error");
                return;
            }


            int index = 0;
            Byte[] byteMap = new Byte[0x0400];

            List<Color> palette = muteBitmap.Palette.Entries.ToList();

            for (int j = 0; j < 0x08; j++)
                for (int l = 0; l < 0x04; l++)
                    for (int k = 0; k < 0x04; k++)
                        for (int i = 0; i < 0x08; i++)
                        {
                            int newValue = palette.IndexOf(muteBitmap.GetPixel(i + (k * 8), j + (l * 8)));
                            byteMap[index++] = BitConverter.GetBytes(newValue)[0];
                        }
            
            List<Byte> newBytes = InvertingTransformations.import3bpp(byteMap, 8, 8, 0x0400);

            /* 0x18 bytes per tile */
            List<int> offsets = new List<int>() { 0x04, 0x05, 0x06, 0x12, 0x08, 0x09, 0x0A, 0x0B, 0x13, 0x14, 0x15, 0x16, 0x0C, 0x0D, 0x0E, 0x0F };

            /* Import */
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            muteBitmap.Dispose();

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                index = 0;

                foreach (int item in offsets)
                {
                    bw.BaseStream.Position = 0x193D98 + (item * 0x18) + headerOffset;

                    for (int i = 0 ; i < 0x18 ; i++)
                    {
                        bw.BaseStream.WriteByte(newBytes[index++]);
                    }
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                return;
            }

            MessageBox.Show("Operation successfully completed.", "Success!");

            bw.Close();
            fs.Close();

            muteSpell = getMuteSpellBitmap();
            panelMuteSpell.Refresh();
        }



        #endregion importImages
        


        private void buttonUpdateWidths_Click(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool success = false;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                int table = (comboBox1bppFont.SelectedIndex < 1) ? 0x203225 : 0x203325;
                bw.BaseStream.Position = table + headerOffset;

                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        bw.BaseStream.WriteByte(Byte.Parse(listViewTextWidths.Items[i].SubItems[j + 1].Text,
                            System.Globalization.NumberStyles.HexNumber));
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                success = false;
            }

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            bw.Close();
            fs.Close();
        }



        private void panelFonts_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(font1bppBitmap, 1, 1, 128, 300);
            if(checkBoxShowWidths.Checked)
                e.Graphics.DrawImage(font1bppBitmapW, 1, 1, 128, 300);
        }



        private void panel2bpp_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(font2bppBitmap, 0, 0, 255, 255);
        }



        private void panelMuteSpell_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(muteSpell, 1, 1, 64, 64);
        }



        private void buttonSaveWidths_Click(object sender, EventArgs e)
        {
            if (listViewTextWidths.Items[2].SubItems.Count < 2)
            {
                MessageBox.Show("There are not items to save.","Warning");
                return;
            }

            /* Displays an SaveFileDialog so the user can select a widths file */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "BIN File|*.bin";
            saveFileDialog.Title = "Choose a bin file";

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open(saveFileDialog.FileName, System.IO.FileMode.OpenOrCreate));

                    try
                    {
                        for (int j = 0; j < 16; j++)
                            for (int i = 1; i < 17; i++)
                                bw.BaseStream.WriteByte(Byte.Parse(listViewTextWidths.Items[j].SubItems[i].Text,
                                    System.Globalization.NumberStyles.HexNumber));
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error loading the file: " + error.ToString(), "Error");
                    }

                    bw.Close();
                }
            }

            saveFileDialog.Dispose();
            saveFileDialog = null;
        }



        private void buttonLoadWidths_Click(object sender, EventArgs e)
        {
            if (listViewTextWidths.Items[2].SubItems.Count < 2)
            {
                MessageBox.Show("Load a SMC before loading the font widths.", "Warning");
                return;
            }

            /* Displays an OpenFileDialog so the user can select a widths file */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "BIN File|*.bin";
            openFileDialog.Title = "Choose a bin file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open));

                    try
                    {
                        if (br.BaseStream.Length != 0x0100)
                        {
                            MessageBox.Show("This file will not fit.", "Warning");
                        }
                        else
                        {
                            for (int j = 0; j < 16; j++)
                                for (int i = 1; i < 17; i++)
                                {
                                    Byte newByte = br.ReadByte();
                                    if (newByte < 0x03) newByte = 0x03;
                                    if (newByte > 0x10) newByte = 0x10;
                                    listViewTextWidths.Items[j].SubItems[i].Text = newByte.ToString("X2");
                                }

                            font1bppBitmapW = generateWidthsPreview();
                            panelFonts.Refresh();
                            panel2bpp.Refresh();
                            panelMuteSpell.Refresh();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error loading the file: " + error.ToString(), "Error");
                    }

                    br.Close();
                }
            }
            openFileDialog.Dispose();
            openFileDialog = null;
        }



        private void buttonMenuEnlarge_Click(object sender, EventArgs e)
        {
            Byte  extraWidth   = (Byte)comboBoxMenuEnlarge.SelectedIndex;

            int[] windowXBound = { /* Main menu */ 0xAD6B, 0xAD7E,
                                   /* Habs */ 0xAE01,
                                   /* Jobs */ 0xAEF7,
                                   /* Equip */ 0xAF42, 0xB072,
                                   /* Stats */ 0xB0E3,
                                   /* Config*/ 0xB67B};
            /* 0x18 - extraWidth */
            int[] windowXWidth = { /* Main menu */ 0xAD6D, 0xAD80,
                                   /* Habs */ 0xAE03,
                                   /* Jobs */ 0xAEF9,
                                   /* Equip */ 0xAF44, 0xB074,
                                   /* Stats */ 0xB0E5,
                                   /* Config*/ 0xB67D};
            /* 0x07 + extraWidth */
            int[] textXPosition = { /* Main menu */ 0xAD72, 0xAD78, 0xAD85, 0xAD8B, 0xAD91, 0xAD97, 0xAD9D, 0xADA3,
                                   /* Habs */ 0xAE08,
                                   /* Jobs */ 0xAEFE,
                                   /* Equip */ 0xAF49, 0xB079,
                                   /* Stats */ 0xB0EA,
                                   /* Config*/ 0xB682};
            /* 0x19 - extraWidth */
            int[] cursXPosition = { /* Main menu */ 0xA304, 0xA30C, 0xA314, 0xA31C, 0xA324, 0xA32C, 0xA334, 0xA33C };
            /* 0xB8 - (width * 8) */
            int[] maskXPosition = { /* Main menu */ 0xAC8A, 0xAC8D };
            /* 0xBF - (width * 8) */;

            /* 0x030000 */

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool success = true;
            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                /* Set new bounds */
                foreach (int item in windowXBound)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x18 - extraWidth));
                }

                /* Set new widths */
                foreach (int item in windowXWidth)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x07 + extraWidth));
                }

                /* Set new text positions */
                foreach (int item in textXPosition)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x19 - extraWidth));
                }

                /* Set new cursor positions */
                foreach (int item in cursXPosition)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0xB8 - (extraWidth * 8)));
                }

                /* Move mask */
                foreach (int item in maskXPosition)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0xBF - (extraWidth * 8)));
                }

                /* Adjust item windows */
                bw.BaseStream.Position = 0x03B372 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x06 + extraWidth + 1));
                bw.BaseStream.Position = 0x03B37D + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x07 + extraWidth + 1));
                bw.BaseStream.Position = 0x03B37F + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x18 - extraWidth - 1));

                /* Job grey mask */
                bw.BaseStream.Position = 0x02D01D + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0xF2 - (extraWidth * 2)));
                bw.BaseStream.Position = 0x02D020 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x04 + extraWidth));

                /* Abilities grey mask */
                bw.BaseStream.Position = 0x02D02E + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x72 - (extraWidth * 2)));
                bw.BaseStream.Position = 0x02D031 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x05 + extraWidth));

                /* Save grey mask */
                /*
                C2/D001: A2 F2 64     LDX #$64F2    ; <--- Tile to set grey
                C2/D004: A9 04 01     LDA #$0104    ; <--- aabb, aa is the flag to set grey and bb the number of characters to set grey
                C2/D007: 20 DC D6     JSR $D6DC     ; <--- Look for this jump.
                */
                bw.BaseStream.Position = 0x02D002 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0xF2 - (extraWidth * 2)));
                bw.BaseStream.Position = 0x02D005 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x05 + extraWidth));
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            bw.Close();
            fs.Close();
        }



        private void buttonMagicMenuEnlarge_Click(object sender, EventArgs e)
        {
            Byte extraWidth = (Byte)comboBoxMagicMenuEnlarge.SelectedIndex;

            int[] windowXBound = { 0xB494};
            /* 0x08 + extraWidth */
            int[] windowXWidth = { 0xB443, 0xB44A, 0xB4AC, /* Clear window */ 0xB4A1 };
            /* 0x07 + extraWidth */

            /* 0x030000 */

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                /*
                B409 05 (00 60 )			    ; Change Layer
                B40C 04 (48 00 12 03 00 )	    ; Draw Text: (Cost[FF][M_][P_]:)
                B412 00 ()				    	; End of Function
                */
                /*
                B437 02 (FF 00 02 02 05 0E )	; Draw Fill Box
                B43E 03 (02 00 01 01 07 07 )	; Draw Static Box
                B445 03 (02 00 01 08 07 09 )	; Draw Static Box
                */

                /* Fill boxes */
                bw.BaseStream.Position = 0x03B43C + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x05 + extraWidth));

                /* Set the new "Cost[FF][M_][P_]:" X position */
                bw.BaseStream.Position = 0x03B40F + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x12 + extraWidth));

                /* Set new bounds */
                foreach (int item in windowXBound)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x08 + extraWidth));
                }

                /* Set new widths */
                foreach (int item in windowXWidth)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x07 + extraWidth));
                }

                /* Reduce upper box width*/
                bw.BaseStream.Position = 0x03B496 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x17 - extraWidth));

                /* Set new position of selected magic name */
                /* C2/AD89: A0D260 ldy #60D2 */
                bw.BaseStream.Position = 0x02AD8A + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0xD2 + (extraWidth * 2)));
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }
        }



        private void buttonStoresMenuEnlarge_Click(object sender, EventArgs e)
        {
            Byte extraWidth = (Byte)comboBoxStoresMenuEnlarge.SelectedIndex;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            bool success = true;
            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            /*
            Merchant messages window Width = 15 - extraWidth
            C3/B28F, C3/B2A0, C3/B2B1, C3/B2C2
            C3/B2D3, C3/B2E4, C3/B2F5, C3/B323
            C3/B33A
            */
            int[] windowWidths = {
                0xB28F, 0xB2A0, 0xB2B1, 0xB2C2,
                0xB2D3, 0xB2E4, 0xB2F5, 0xB323,
                0xB33A };

            /*
            Merchant messages X = 09 + extraWidth
            C3/B28D, C3/B29E, C3/B2AF, C3/B2C0,
            C3/B2D1, C3/B2E2, C3/B2F3, C3/B321,
            C3/B338, C3/B206, C3/B294, C3/B2A5,
            C3/B2C7, C3/B2D8, C3/B2E9, C3/B2FA,
            C3/B328, C3/B33F, C3/B2B6
            */
            int[] messagesXs = {
                0xB28D, 0xB29E, 0xB2AF, 0xB2C0,
                0xB2D1, 0xB2E2, 0xB2F3, 0xB321,
                0xB338, 0xB206, 0xB294, 0xB2A5,
                0xB2C7, 0xB2D8, 0xB2E9, 0xB2FA,
                0xB328, 0xB33F, 0xB2B6 };

            /* 0x030000 */
            try
            {
                /*
                Store name window X = 07 + extraWidth
                C3/B1FA
                */
                bw.BaseStream.Position = 0x03B1FA + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x07 + extraWidth));

                /*
                Merchant messages window X = 08 + extraWidth
                C3/B1FF
                */
                bw.BaseStream.Position = 0x03B1FF + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x08 + extraWidth));

                /*
                Merchant messages window Width = 17 - extraWidth
                C3/B201
                */
                bw.BaseStream.Position = 0x03B201 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x17 - extraWidth));

                /*
                Store name = 05 + extraWidth
                C2/F176
                */
                bw.BaseStream.Position = 0x02F176 + headerOffset;
                bw.BaseStream.WriteByte((Byte)(0x05 + extraWidth));

                /* Set new message bounds */
                foreach (int item in messagesXs)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x09 + extraWidth));
                }

                /* Set new widths */
                foreach (int item in windowWidths)
                {
                    bw.BaseStream.Position = 0x030000 + item + headerOffset;
                    bw.BaseStream.WriteByte((Byte)(0x15 - extraWidth));
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            bw.Close();
            fs.Close();
        }



        private void buttonEveryDraw_Click(object sender, EventArgs e)
        {
            /* Concepts */
            /* 2F00 + 1632 bytes */
            List<String> conceptsVar = new List<string>();
            conceptsVar = appendToExportList(conceptsVar, tblManager.TBL_Reader2bpp, 0x00F987, 0x270000, 139, 0x00);

            String output = "";

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x030000 + headerOffset + 0xAD3F;
                while (br.BaseStream.Position < 0x03B815)
                {
                    output += getWindowsInfo(br, conceptsVar);
                    output += "\r\n";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            textBoxWindowInfo.Text = output;
        }



        private void buttonSRAM_Click(object sender, EventArgs e)
        {
            Dummy.editSRM();
        }



        private void buttonWindowsInfo_Click(object sender, EventArgs e)
        {
            /*
            Menu ID  | BG1  BG2  BG3  BG4  | BGS1 BGS2 BGS3 BGS4 | Msk1 Msk2 Curs Sett     
            --------------------------------------------------------------------------
            01 Main  | 0000 0000 AD3F AD65 | 0000 0000 B816 B822 | AC86 AC98 A300 ABBA
            02 Abil  | 0000 ADE3 ADF4 AE5E | 0000 B82C B82F B84F | ACCE 0000 A382 ABCB 
            03 Job   | 0000 0000 AEEA AF0F | 0000 0000 B85C B862 | 0000 0000 A434 ABDC 
            04 Equip | 0000 AF3C AF4D B02B | 0000 B868 B87A B88C | ACDA 0000 A4EE ABED 
            05 Stats | 0000 0000 B095 B0D3 | 0000 0000 B89A B8A0 | ACE6 0000 A598 ABFE
            06 Store | 0000 B19F B1EB B237 | 0000 B8B0 B8BB B8D1 | ACF2 0000 A5A2 AC0F 
            07 Item  | 0000 0000 B363 B3B7 | 0000 0000 B8C9 B8D1 | ACF2 AD01 A73C AC20 
            08 Magic | 0000 0000 B3D6 B3F3 | 0000 0000 B8E0 B8E6 | 0000 0000 A856 AC31 
            09 Confg | 0000 0000 B66E 0000 | 0000 0000 B93E 0000 | 0000 0000 AA38 AC75 
            0A Find  | 0000 0000 B636 0000 | 0000 0000 B919 0000 | 0000 0000 AA26 AC64 
            0B Save  | 0000 B536 AD3F 0000 | 0000 B8FD B816 B905 | AD1F 0000 A978 AC42 
            0C Load  | 0000 B56A AD3F 0000 | 0000 B8FD B816 B905 | AD1F 0000 A9AA AC42 
            0D Name  | 0000 0000 B5F5 B620 | 0000 0000 B90F 0000 | AD10 0000 A9E4 AC53

            Menu ID  | BG1  BG2  BG3  BG4 
            ------------------------------
            01 Main  | 0000 0000 AD3F AD65	; AD3F, AD65
            02 Abil  | 0000 ADE3 ADF4 AE5E	; ADE3, ADF4, AE5E
            03 Job   | 0000 0000 AEEA AF0F	; AEEA, AF0F
            04 Equip | 0000 AF3C AF4D B02B	; AF3C, AF4D, B02B
            05 Stats | 0000 0000 B095 B0D3	; B095, B0D3
            06 Store | 0000 B19F B1EB B237	; B19F, B1EB, B237
            07 Item  | 0000 0000 B363 B3B7	; B363, B3B7
            08 Magic | 0000 0000 B3D6 B3F3	; B3D6, B3F3
            09 Confg | 0000 0000 B66E 0000	; B66E
            0A Find  | 0000 0000 B636 0000	; B636
            0B Save  | 0000 B536 AD3F 0000	; B536, AD3F
            0C Load  | 0000 B56A AD3F 0000	; B56A, AD3F
            0D Name  | 0000 0000 B5F5 B620	; B5F5, B620
            */

            /* Concepts */
            /* 2F00 + 1632 bytes */
            List<String> conceptsVar = new List<string>();
            conceptsVar = appendToExportList(conceptsVar, tblManager.TBL_Reader2bpp, 0x00F987, 0x270000, 139, 0x00);

            String output = "";

            /* Go to function */
            UInt16 address;
            if(!UInt16.TryParse(textBoxWindowInfoAddress.Text, System.Globalization.NumberStyles.HexNumber, null, out address))
                return;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x030000 + headerOffset + address;
                output = getWindowsInfo(br, conceptsVar);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            textBoxWindowInfo.Text = output;
        }



        private String getWindowsInfo(System.IO.BinaryReader br, List<String> conceptsVar)
        {
            Byte[] sizes = { 0, 2, 6, 6, 5, 2, 6 };
            String[] funcs = { "End of Function",
				               "Fill Current Layer",
				               "Draw Fill Box",
				               "Draw Static Box",
				               "Draw Text: ",
				               "Change Layer",
				               "Draw Indent Box"};

            String output ="";

            /* Deprecated - Read size (2 bytes) */
            int pos = 0;
            //int funcSize = br.BaseStream.ReadByte() + (br.BaseStream.ReadByte() * 0x0100);
            //output += "(" + funcSize.ToString("X4") + ")\r\n";

            /* Read */
            Byte nextFunc = 0xFF;
            while (nextFunc != 0x00)
            {
                int i = 0;
                Byte textId = 0;

                String nextOutput = "  C3/";
                nextOutput += (br.BaseStream.Position & 0x0000FFFF).ToString("X4") + " ";

                nextFunc = br.ReadByte();
                nextOutput += nextFunc.ToString("X2") + " (";
                pos++;

                if (nextFunc == 0x04)
                {
                    textId = br.ReadByte();
                    nextOutput += textId.ToString("X2") + " ";
                    i++;
                    pos++;
                }

                for (; i < sizes[nextFunc]; i++)
                {
                    nextOutput += br.BaseStream.ReadByte().ToString("X2") + " ";
                    pos++;
                }

                nextOutput += ")";
                nextOutput = nextOutput.PadRight(34, ' ');
                nextOutput += "; " + funcs[nextFunc];

                if (nextFunc == 0x04)
                {
                    if (textId < conceptsVar.Count)
                        nextOutput += "(" + conceptsVar[textId] + ")";
                    else
                        nextOutput += "(<UNKNOWN>)";
                }

                output += nextOutput + "\r\n";
            }

            return output;
        }



        private void buttonWindowsCtrl_Click(object sender, EventArgs e)
        {
            String output = "";

            /* Go to function */
            UInt16 address;
            if (!UInt16.TryParse(textBoxWindowInfoAddress.Text, System.Globalization.NumberStyles.HexNumber, null, out address))
                return;

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                br.BaseStream.Position = 0x030000 + headerOffset + address;

                int grouping = comboBoxWinGrouping.SelectedIndex + 3;

                /* Read size (2 bytes) */
                int pos = 0;
                int funcSize = br.BaseStream.ReadByte() + (br.BaseStream.ReadByte() * 0x0100);
                output += "(" + funcSize.ToString("X4") + ")\r\n";
                output += (br.BaseStream.Position & 0x0000FFFF).ToString("X4") + " ";

                /* Read */
                while (pos < funcSize)
                {
                    output += br.ReadByte().ToString("X2") + " ";
                    pos++;

                    if (pos % (grouping * 4) == 0)
                    {
                        output += "\r\n";
                        output += (br.BaseStream.Position & 0x0000FFFF).ToString("X4") + " ";
                    }else if (pos % grouping == 0)
                        output += "/ ";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            textBoxWindowInfo.Text = output;
        }



        private void checkBoxShowWidths_CheckedChanged(object sender, EventArgs e)
        {
            panelFonts.Refresh();
        }



        #region MiscTexts



        private void buttonMiscTextInjectDefense_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextDefense.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x203103, 1, 10, 0xFF);
        }



        private void buttonMiscTextInjectDef_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextDef.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x20310E, 1, 4, 0xFF);
        }



        private void buttonMiscTextInjectEqp_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextEqp.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x203113, 1, 4, 0xFF);
        }



        private void buttonMiscTextInjectEmpty_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextEmpty.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x203118, 1, 5, 0xFF);
        }



        private void buttonMiscTextInjectMaster_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextMaster.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00EA6C, 1, 7, 0xFF);
        }



        private void buttonMiscTextInjectAny_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextAny.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00F7A8, 1, 4, 0xFF);
        }



        private void buttonMiscTextInjectPause_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextPause.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x0115C4, 1, 5, 0xFF);
        }



        private void buttonMiscTextInjectLv_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextLv.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00EA74, 1, 2, 0xFF);
        }



        private void buttonMiscTextUsesMP_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextUsesMP.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x0EFFBC, 1, 6, 0xFF);
        }



        private void buttonMiscTextHpMpExp_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            /*
            DA DC    TiBl   -> HP  (10E181) -> 6F 75
            DB DC    InBl   -> MP  (10E189) -> 6F 6C
            D9 D5 DC HiPiBl -> EXP (10E191) -> 64 77 6F
            */

            inputStr.Add(textBoxMiscTextHP.Text);
            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x10E181, 1, 2, 0xFF);

            inputStr.Clear();
            inputStr.Add(textBoxMiscTextMP.Text);
            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x10E189, 1, 2, 0xFF);

            inputStr.Clear();
            inputStr.Add(textBoxMiscTextExp.Text);
            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x10E191, 1, 3, 0xFF);
        }



        private void buttonMiscTexSell_Click(object sender, EventArgs e)
        {
            List<String> inputStr = new List<string>();

            inputStr.Add(textBoxMiscTextSell.Text);

            ImportFixedSizeTable(inputStr, tblManager.TBL_Injector2bpp, 0x00FAA0, 1, 3, 0x00);

        }



        #endregion MiscTexts



        #region bugs



        private void buttonBugCatchMonsterDisplay_Click(object sender, EventArgs e)
        {
            bugCatchMonsterDisplay();
        }

        private void buttonBugCatchMonster_Click(object sender, EventArgs e)
        {
            bugCatchMonster();
        }

        private void buttonBugKissOfBlessing_Click(object sender, EventArgs e)
        {
            bugKissOfBlessing();
        }

        private void buttonBugPowerDrink_Click(object sender, EventArgs e)
        {
            bugPowerDrink();
        }

        private void buttonBugObserve_Click(object sender, EventArgs e)
        {
            bugObserve();
        }

        private void buttonBugBlueMageSprite_Click(object sender, EventArgs e)
        {
            bugBlueMageSprite();
        }

        private void buttonBugBerserkChicen_Click(object sender, EventArgs e)
        {
            bugBerserkChicken();
        }

        private void buttonBugFixChecksum_Click(object sender, EventArgs e)
        {
            fixChecksum();
        }



        private bool bugCatchMonsterDisplay(bool silent = false)
        {
            /*
            Monsters in Jap  D0/5C00
            Monsters in RPGe E0/0050

            C2/CA04:	68      	pla 		; Monster index
            C2/CA05:	0A      	asl A		; .
            C2/CA06:	0A      	asl A		; .
            C2/CA07:	0A      	asl A		; *8 (must be *10)
            C2/CA08:	18      	clc 
            C2/CA09:	69005C  	adc #$5C00	; Monster offset in bank D0 (must be 0050 in bank E0)
            C2/CA0C:	A8      	tay			; Y is offset to the monster
            C2/CA0D:	A2C856  	ldx #$56C8	; X is pointer to the RAM tile to write the text (0x7E56C8)
            C2/CA10:	A908D0  	lda #$D008	; aabb: aa = Bank, bb = #characters (must be -> E00A)
            C2/CA13:	209DE5  	jsr $E59D	; Dump

            C2/CA05 22 00 5C D0 (jsr D05C00)
            C2/CA0A 50 00
            C2/CA11 0A E0

            [...]
            asmMultBy10:
            D0/5C00:	0A      asl
            D0/5C01:	48		pha
            D0/5C02:	0A      asl
            D0/5C03:	0A      asl
            D0/5C04:	18      clc
            D0/5C05:	6301	adc $01,S		; A = A + Stack[1] (Stack[1] is current width)
            D0/5C07:	FA      plx
            D0/5C08:	18      clc
            D0/5C09:	6B      rtl
            */

            Byte[] asmMultBy10 = { 0x0A, 0x48, 0x0A, 0x0A, 0x18, 0x63, 0x01, 0xFA, 0x18, 0x6B };

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                /* C2/CA05 22 00 5C D0 (jsr D05C00) */
                bw.BaseStream.Position = 0x02CA05 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0x00);
                bw.BaseStream.WriteByte(0x5C);
                bw.BaseStream.WriteByte(0xD0);

                /* C2/CA0A 50 00 */
                bw.BaseStream.Position = 0x02CA0A + headerOffset;
                bw.BaseStream.WriteByte(0x50);
                bw.BaseStream.WriteByte(0x00);

                /* C2/CA11 0A E0 */
                bw.BaseStream.Position = 0x02CA11 + headerOffset;
                bw.BaseStream.WriteByte(0x0A);
                bw.BaseStream.WriteByte(0xE0);

                /* D0/5C00 asmMultBy10 */
                bw.BaseStream.Position = 0x105C00 + headerOffset;
                foreach (Byte item in asmMultBy10)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugCatchMonster(bool silent = false)
        {
            /*
            ------------------------------------------
            -
            - Releasing Moss fungus or Gel fish
            -
            ------------------------------------------
            $D086C5: 47
            $D086E0: 47
            */

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x1086C5 + headerOffset;
                bw.BaseStream.WriteByte(0x47);

                bw.BaseStream.Position = 0x1086E0 + headerOffset;
                bw.BaseStream.WriteByte(0x47);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugKissOfBlessing(bool silent = false)
        {
            /*
            0xC29047
            5C E3 2E D0 29 20 D0 02
            80 1A A5 59 49 08 85 59
            80 62 00

            0xD02EE3
            A5 48 C9 04 90 07 BD 36
            20 29 08 D0 11 BD 1B 20
            1D 71 20 29 18 D0 07 BD
            1D 20 5C 4B 90 C2 5C 51
            90 C2
            */

            Byte[] overwrite ={0x5C, 0xE3, 0x2E, 0xD0, 0x29, 0x20, 0xD0, 0x02,
                               0x80, 0x1A, 0xA5, 0x59, 0x49, 0x08, 0x85, 0x59,
                               0x80, 0x62, 0x00};

            Byte[] newSubs ={0xA5, 0x48, 0xC9, 0x04, 0x90, 0x07, 0xBD, 0x36,
                             0x20, 0x29, 0x08, 0xD0, 0x11, 0xBD, 0x1B, 0x20,
                             0x1D, 0x71, 0x20, 0x29, 0x18, 0xD0, 0x07, 0xBD,
                             0x1D, 0x20, 0x5C, 0x4B, 0x90, 0xC2, 0x5C, 0x51,
                             0x90, 0xC2};

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x029047 + headerOffset;
                foreach (Byte item in overwrite)
                {
                    bw.BaseStream.WriteByte(item);
                }

                bw.BaseStream.Position = 0x102EE3 + headerOffset;
                foreach (Byte item in newSubs)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugPowerDrink(bool silent = false)
        {
            /*
            ------------------------------------------
            -
            - Power drink
            -
            ------------------------------------------

            $C27FFE: 22 AB 2E D0
            $C28040: 22 AB 2E D0
            $C280D6: 22 AB 2E D0
            $C2812D: 22 AB 2E D0

            $C282B0: 22 B9 2E D0

            $C28584: 22 AF 2E D0

            $C28588: EA EA  
    
            $C285AF: 22 C9 2E D0 80 08 00 00 00 00 00 00 00 00  

            $C28626: 22 C1 2E D0

            $C2919B: 76 
    
            $C291A4: 76

            $C291A6: 60

            $D02E9A
            AA BD 03 7A DA A6 32 18
            7D 76 20 90 02 A9 FF FA
            60 20 9A 2E 6B 20 9E 2E
            AA 86 50 AD E5 7B 6B BF
            07 00 D1 20 9E 2E 6B AD
            75 7C 4A 20 9E 2E 6B BD
            44 20 20 9E 2E 85 0E 7B
            BD 45 20 20 9E 2E 64 0F
            C2 20 65 0E 85 50 E2 20
            6B 
             */

            Byte[] overwrite = { 0x22, 0xC9, 0x2E, 0xD0, 0x80, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Byte[] newCode = {0xAA, 0xBD, 0x03, 0x7A, 0xDA, 0xA6, 0x32, 0x18, 0x7D, 0x76, 0x20, 0x90, 0x02, 0xA9, 0xFF, 0xFA,
                                    0x60, 0x20, 0x9A, 0x2E, 0x6B, 0x20, 0x9E, 0x2E, 0xAA, 0x86, 0x50, 0xAD, 0xE5, 0x7B, 0x6B, 0xBF,
                                    0x07, 0x00, 0xD1, 0x20, 0x9E, 0x2E, 0x6B, 0xAD, 0x75, 0x7C, 0x4A, 0x20, 0x9E, 0x2E, 0x6B, 0xBD,
                                    0x44, 0x20, 0x20, 0x9E, 0x2E, 0x85, 0x0E, 0x7B, 0xBD, 0x45, 0x20, 0x20, 0x9E, 0x2E, 0x64, 0x0F,
                                    0xC2, 0x20, 0x65, 0x0E, 0x85, 0x50, 0xE2, 0x20, 0x6B};

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x027FFE + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xAB);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x028040 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xAB);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x0280D6 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xAB);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x02812D + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xAB);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x0282B0 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xB9);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x028584 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xAF);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x028588 + headerOffset;
                bw.BaseStream.WriteByte(0xEA);
                bw.BaseStream.WriteByte(0xEA);

                bw.BaseStream.Position = 0x028626 + headerOffset;
                bw.BaseStream.WriteByte(0x22);
                bw.BaseStream.WriteByte(0xC1);
                bw.BaseStream.WriteByte(0x2E);
                bw.BaseStream.WriteByte(0xD0);

                bw.BaseStream.Position = 0x02919B + headerOffset;
                bw.BaseStream.WriteByte(0x76);

                bw.BaseStream.Position = 0x0291A4 + headerOffset;
                bw.BaseStream.WriteByte(0x76);

                bw.BaseStream.Position = 0x0291A6 + headerOffset;
                bw.BaseStream.WriteByte(0x60);

                bw.BaseStream.Position = 0x0285AF + headerOffset;
                foreach (Byte item in overwrite)
                {
                    bw.BaseStream.WriteByte(item);
                }

                bw.BaseStream.Position = 0x102E9A + headerOffset;
                foreach (Byte item in newCode)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugObserve(bool silent = false)
        {
            /*
            ------------------------------------------
            -
            - Observe Fix
            -
            ------------------------------------------
            $C26C94: 10
            */

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x026C94 + headerOffset;
                bw.BaseStream.WriteByte(0x10);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugBlueMageSprite(bool silent = false)
        {
            /* D25080 */
            Byte[] newSprite = {0x7D, 0x0F, 0x56, 0x26, 0x70, 0x00, 0x79, 0x20, 0x3E, 0x09, 0x18, 0x0F, 0x0D, 0x07, 0x0F, 0x00,
                                0x09, 0x00, 0x26, 0x29, 0x2C, 0x23, 0x24, 0x22, 0x01, 0x08, 0x07, 0x08, 0x03, 0x04, 0x00, 0x00,
                                0x1F, 0x06, 0x1E, 0x0C, 0xFD, 0x10, 0xFB, 0x7A, 0x5F, 0x3C, 0x77, 0x08, 0x37, 0x08, 0x19, 0x00,
                                0x02, 0x06, 0x05, 0x0D, 0x12, 0x02, 0x2E, 0x76, 0x3D, 0x15, 0x0B, 0x03, 0x09, 0x01, 0x00, 0x00};

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {

                bw.BaseStream.Position = 0x125080 + headerOffset;
                foreach (Byte item in newSprite)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool bugBerserkChicken(bool silent = false)
        {
            /*
            C2/4665: 20 A2 02    JSR $02A2   (0 to 99)
            C2/4668: A6 0E       LDX $0E
            C2/466A: DD 8F 40    CMP $408F,X 
            C2/466D: B0 06       BCS $4675	 -> Jump to not execute the weapon special ability
            C2/466F: BD 90 40    LDA $4090,x -> A = Weapon special ability
            C2/4672: 4C D5 49    JMP $49D5   -> Force new command

            C2/466F Overwrite with 5C XX XX XX EA EA
            */

            int patchPlace = 0xD02F05;

            Byte[] newCode = {0xBD, 0x90, 0x40,       /* LDA $4090,X *//* Read weapon special command */
                              0xC9, 0x0A,             /* CMP #$0A    */
                              0xD0, 0x0B,             /* BNE #$0B    *//* If (command != 'Escape') return command; */
                              0xA6, 0x32,             /* LDX $32     */
                              0xBD, 0x21, 0x20,       /* LDA $2021,X */
                              0x29, 0x08,             /* AND #$08    */
                              0xD0, 0x06,             /* BNE #$06    *//* If (!Attacker.Berserk) load A and return */
                              0xA9, 0x0A,             /* LDA #$0A    *//* Run command !Escape */
                              0x5C, 0xD5, 0x49, 0xC2, /* JMP $C249D5 */
                              0xAD, 0xF0, 0x3E,       /* LDA $3EF0   *//* (Check if can run)   */
                              0x30, 0xF5,             /* BMI #$F5    *//* Cannot run, so choose !Escape command */
                              0xA9, 0x01,             /* LDA #$01    *//* Load 'Hidden' status */
                              0x8D, 0x1D, 0x20,       /* STA $201D   *//* Set 'Hidden' to PC1  */
                              0x8D, 0x9D, 0x20,       /* STA $209D   *//* Set 'Hidden' to PC2  */
                              0x8D, 0x1D, 0x21,       /* STA $211D   *//* Set 'Hidden' to PC3  */
                              0x8D, 0x9D, 0x21,       /* STA $219D   *//* Set 'Hidden' to PC4  */
                              0xA9, 0x25,             /* LDA #$25    *//* Run command !Hide    */
                              0x5C, 0xD5, 0x49, 0xC2, /* JMP $C249D5 */
                             };

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = (patchPlace - 0xC00000) + headerOffset;
                foreach (Byte item in newCode)
                {
                    bw.BaseStream.WriteByte(item);
                }

                bw.BaseStream.Position = 0x02466F + headerOffset;
                bw.BaseStream.WriteByte(0x5C);
                bw.BaseStream.WriteByte(BitConverter.GetBytes(patchPlace)[0]);
                bw.BaseStream.WriteByte(BitConverter.GetBytes(patchPlace)[1]);
                bw.BaseStream.WriteByte(BitConverter.GetBytes(patchPlace)[2]);
                bw.BaseStream.WriteByte(0xEA);
                bw.BaseStream.WriteByte(0xEA);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            bw.Close();
            fs.Close();

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private bool fixChecksum(bool silent = false)
        {
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return false;
            }

            bool success = true;

            try
            {
                List<Byte> listBytes = System.IO.File.ReadAllBytes(fileUnderEdition).ToList();
                if (headerOffset > 0){
                    listBytes = listBytes.GetRange(0x0200, listBytes.Count - 0x0200);
                }

                UInt64 offset = 0;
                UInt64 iOffset = 0;

                foreach (Byte item in listBytes)
                {
                    offset += item;
                }
                offset = offset & 0xFFFF;
                //offset -= 0x200;

                /*
                System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                br.BaseStream.Position = headerOffset;
                
                for (int i = 0 ; i < 0x7FB0 ; i += 2)
                {
                    offset = offset + (listBytes[i] + (listBytes[i + 1] * 0x0100));
                }
                */
                for (int i = 0x7FE0 ; i < 2 * 1024 * 1024 ; i += 2)
                {
                   // offset = offset + (listBytes[i] + (listBytes[i + 1] * 0x0100));
                }

                for (int i = (2 * 1024 * 1024) ; i < listBytes.Count ; i += 2)
                {
                    // offset = offset + (listBytes[i] + (listBytes[i + 1] * 0x0100)) * 1;
                }

                offset = offset & 0xFFFF;
                iOffset = offset ^ 0xFFFF;

                MessageBox.Show("New offset = " + offset.ToString("X4") + "\r\n" +
                    "New inverse offset = " + iOffset.ToString("X4"), "Offset");

                // C0/FFDC-C0/FFDD => Checksum complement, which is the bitwise-xor of the checksum and $ffff.
                // C0/FFDE-C0/FFDF => SNES checksum, an unsigned 16-bit checksum of bytes.
                //br.BaseStream.Position = 0x00FFDC + headerOffset;

                //br.BaseStream.WriteByte(BitConverter.GetBytes(iOffset)[0]);
                //br.BaseStream.WriteByte(BitConverter.GetBytes(iOffset)[1]);
                //br.BaseStream.WriteByte(BitConverter.GetBytes(offset)[0]);
                //br.BaseStream.WriteByte(BitConverter.GetBytes(offset)[1]);

                //br.Close();
                //fs.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                success = false;
            }

            if (success & !silent)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }

            return success;
        }



        private void buttonBugFixAll_Click(object sender, EventArgs e)
        {
            bool success = true;

            if (success) success = bugCatchMonsterDisplay(true);
            if (success) success = bugKissOfBlessing(true);
            if (success) success = bugPowerDrink(true);
            if (success) success = bugObserve(true);
            if (success) success = bugBlueMageSprite(true);
            if (success) success = bugBerserkChicken(true);
            if (success) success = fixChecksum(true);

            if (success)
            {
                MessageBox.Show("Operation successfully completed.", "Success!");
            }
            else
            {
                MessageBox.Show("Error writing the file.", "Error");
            }
        }



        #endregion



        #region SpeechDisplay



        private void numericUpDownIdSpeech_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDownIdSpeech.Value;

            if (speech.Count == 0 || speech.Count < numericUpDownIdSpeech.Value)
                return;

            int nWindows = ((speech[value].Count(x => x == 0x01)) / 4) + 1;
            comboBoxSubSpeech.Items.Clear();

            for (int i = 1 ; i <= nWindows ; i++)
            {
                comboBoxSubSpeech.Items.Add(i.ToString());
            }

            comboBoxSubSpeech.SelectedIndex = 0;
            labelSubsSpeech.Text = "of " + nWindows.ToString();
        }



        private void comboBoxSubSpeech_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speech.Count == 0 || speech.Count < numericUpDownIdSpeech.Value)
                return;

            panelMainSpeech.Refresh();
        }



        private void label16_Click(object sender, EventArgs e)
        {
            if (speech.Count == 0)
                return;

            calculateBrokenWindows();
        }



        private void calculateBrokenWindows()
        {
            String message = "Speech ids which may break the speech display window:\r\n";

            for (int value = 0; value < 2160; value++)
            {
                int[] maxWidth = {0, 0, 0, 0};
                int   width = 0;
                int   i = 0;
                int   nLine = 0;
                while (i < speech[value].Count)
                {
                    if (speech[value][i] == 0x01) {
                        width = 0;
                        nLine = (nLine + 1) % 4;
                    }
                    else if (speech[value][i] > 32)
                    {
                        width += (Byte.Parse(listViewTextWidths.Items[((speech[value][i] & 0x00F0) / 16) + 0].SubItems[(speech[value][i] & 0x000F) + 1].Text,
                            System.Globalization.NumberStyles.HexNumber));

                        if (width > maxWidth[nLine]) {
                            maxWidth[nLine] = width;
                        }
                    }

                    i++;
                }

                if (maxWidth[3] >= 204)
                    message += value.ToString() + ", ";
            }

            MessageBox.Show(message);
        }
        

        
        private void panelMainSpeech_Paint(object sender, PaintEventArgs e)
        {
            Bitmap rightWindow = speechBmDisplay.Clone(new Rectangle(216, 0, 8, 80), speechBmDisplay.PixelFormat);
            
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(speechBmDisplay, 0, 0, 448, 160);

            if (speech.Count == 0 || speech.Count < numericUpDownIdSpeech.Value)
                return;

            int x = 16;
            int y = 24;
            int i = 0;
            int eols = 0;
            int nLine = 0;
            int value = (int)numericUpDownIdSpeech.Value;

            /* Choose starting character */
            eols = comboBoxSubSpeech.SelectedIndex * 4;
            while (i < speech[value].Count && eols > 0)
            {
                if (speech[value][i] == 0x01)
                {
                    eols--;
                    nLine = (nLine + 1) % 4;
                }
                i++;
            }

            /* Write text */
            int maxWidth = 16;
            while (i < speech[value].Count)
            {
                if (speech[value][i] == 0x01)
                {
                    x = 16;
                    y += 32;
                    nLine = (nLine + 1) % 4;
                    eols++;
                    if (eols > 3)
                        break;
                }
                else if (speech[value][i] > 32)
                {
                    if (speech[value][i] != 255)
                    {
                        e.Graphics.DrawImage(font1bppChars[speech[value][i] - 0x20], x, y, 33, 25);
                    }

                    x += (Byte.Parse(listViewTextWidths.Items[((speech[value][i] & 0x00F0) / 16) + 0].SubItems[(speech[value][i] & 0x000F) + 1].Text,
                        System.Globalization.NumberStyles.HexNumber)) * 2;

                    if (x > maxWidth && nLine == 3) { maxWidth = x; }

                    if (x > 426)
                    {
                        while (i < speech[value].Count && speech[value][i] != 0x01)
                        {
                            if (nLine == 3) maxWidth += (Byte.Parse(listViewTextWidths.Items[((speech[value][i] & 0x00F0) / 16) + 0].SubItems[(speech[value][i] & 0x000F) + 1].Text,
                                System.Globalization.NumberStyles.HexNumber)) * 2;
                            i++;
                        }

                        x = 16;
                        y += 32;
                        eols++;
                        nLine = (nLine + 1) % 4;
                        if (eols > 3)
                            break;
                    }
                }

                i++;
            }

            maxWidth -= 16;
            maxWidth /= 2; //204
            if (maxWidth >= 204) MessageBox.Show("The last line of this window is " + maxWidth.ToString() + " pixels width and may break the display window.", "Info");

            //label16.Text = maxWidth.ToString();
            e.Graphics.DrawImage(rightWindow, 432, 0, 16, 160);
        }



        private void comboBox1bppFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fileToEditIsAvailable)
                return;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            try
            {
                loadFont(br, comboBox1bppFont.SelectedIndex);
                loadWidths(br, comboBox1bppFont.SelectedIndex);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
            }

            br.Close();
            fs.Close();

            panelFonts.Update();
        }



        #endregion



        private void buttonCSVImportPOL_Click(object sender, EventArgs e)
        {
            /* Poem of light */
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count < 1)
                return;

            String currentString = inputStr[0];
            List<Byte> newByteLs = new List<byte>();
            
            while (currentString.Length > 0)
            {
                bool found = false;
                byte newByte = 0x00;

                /* Check if [XX] where XX in a hex number */
                if (currentString[0] == '[' && currentString.Length > 3 && currentString[3] == ']')
                {
                    Byte newForcedByte = 0;
                    if (Byte.TryParse(currentString.Substring(1, 2), System.Globalization.NumberStyles.HexNumber, null, out newForcedByte))
                    {
                        newByteLs.Add(newForcedByte);
                        currentString = currentString.Substring(4);
                        continue;
                    }
                }

                /* Check if is a multiple chars byte */
                if (currentString[0] == '[')
                {
                    int i = 0;
                    while (i < currentString.Length && currentString[i] != ']')
                    {
                        i++;
                    }

                    if (i < currentString.Length && tblManager.TBL_Injector1bpp.TryGetValue(currentString.Substring(0, i), out newByte))
                    {
                        newByteLs.Add(newByte);
                        currentString = currentString.Substring(i);
                        found = true;
                    }
                } /* Check if is a parseable character */
                else if (tblManager.TBL_Injector1bpp.TryGetValue(currentString.Substring(0, 1), out newByte))
                {
                    newByteLs.Add(newByte);
                    currentString = currentString.Substring(1);
                    found = true;
                }

                if (!found)
                {
                    MessageBox.Show("The character " + currentString.Substring(0, 1) + " cannot be parsed.", "Error");
                    return;
                }
            }

            /* Check overflow */
            if (newByteLs.Count > 1416)
            {
                /* Overflow */
                MessageBox.Show("The file is too big:\r\n\r\nThe file is " + newByteLs.Count +
                                " bytes long.\r\n1416 bytes long were expected.",
                                "Invalid file");
                return;
            }
            else
            {
                MessageBox.Show("The file is ok:\r\n\r\nThe file is " + newByteLs.Count +
                                " bytes long.\r\nLess than 1416 bytes long were expected.",
                                "Sucessfully parsed!");

            }

            /* Everything OK. Inject data. */
            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x2773A0 + headerOffset;

                foreach (Byte item in newByteLs)
                {
                    bw.BaseStream.WriteByte(item);
                }

                while (bw.BaseStream.Position != 0x2773A0 + 1416)
                {
                    bw.BaseStream.WriteByte(00);
                }

                bw.BaseStream.WriteByte(0x00);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error writing the file: " + err.ToString(), "Error");
            }

            bw.Close();
            fs.Close();
        }



        private void buttonSynchroIndexInject_Click(object sender, EventArgs e)
        {
            Byte newIndex;

            if (Byte.TryParse(textBoxSynchroIndexInject.Text, System.Globalization.NumberStyles.HexNumber, null, out newIndex))
            {
                injectOn(new List<List<Byte>>() { new List<Byte>() { newIndex } }, 0x01F868);
            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #region TBLFunctions



        private void importTBL1bppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.readCustomTBL1bpp();
        }
        
        private void loadTBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.readCustomTBL2bpp();
        }



        private void exportTBL1bppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.exportCurrentTBL1bpp();
        }

        private void exportTBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.exportCurrentTBL2bpp();
        }



        private void loadDefaultTBL1bppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.readDefaultTBL1bpp();
        }

        private void loadDefaultTBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.readDefaultTBL2bpp();
        }



        private void setCurrentAsDefaultTBL1bppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.setCurrentAsDefaultTBL1bpp();
        }
        
        private void setCurrentAsDefaultTBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tblManager.setCurrentAsDefaultTBL2bpp();
        }



        private void displayCurrentTBL1bppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String display = "";
            int i = 1;

            foreach (String item in tblManager.getCurrentTBL1bpp())
            {
                display += item.PadRight(24);
                if (i++ % 8 == 0)
                {
                    display += "\r\n";
                }
            }

            Form2 displayForm = new Form2();
            displayForm.label1.Text = display;
            displayForm.ShowDialog();
        }
        
        private void displayCurrentTBLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String display = "";
            int i = 1;

            foreach (String item in tblManager.getCurrentTBL2bpp())
            {
                display += item.PadRight(24);
                if (i++ % 8 == 0)
                {
                    display += "\r\n";
                }
            }

            Form2 displayForm = new Form2();
            displayForm.label1.Text = display;
            displayForm.ShowDialog();
        }



        #endregion



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String outputMessage = "";

            outputMessage += "Developed by Noisecross:";
            outputMessage += "\r\n";
            outputMessage += "Ver. v1.07 (April 2024)";
            outputMessage += "\r\n";
            outputMessage += "\r\n";
            outputMessage += "This tool is not under any kind of support, but for any questions please read the readme.docx file or contact the developer by email (dalastnecromancer@gmail.com)";

            MessageBox.Show(outputMessage, "About");
        }



        private void comboBoxWindowsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadWindowsInfo();
        }



        private void loadWindowsInfo()
        {
            List<List<int>> groupAddresses = new List<List<int>>(){
              new List<int>(){0xAD3F, 0xAD65},         //Main
              new List<int>(){0xADE3, 0xAE5E, 0xADF4}, //Abil
              new List<int>(){0xAEEA, 0xAF0F},         //Job
              new List<int>(){0xAF3C, 0xB02B, 0xAF4D}, //Equip
              new List<int>(){0xB095, 0xB0D3},         //Stats
              new List<int>(){0xB19F, 0xB237, 0xB1EB}, //Store
              new List<int>(){0xB363, 0xB3B7},         //Item
              new List<int>(){0xB3D6, 0xB3F3},         //Magic
              new List<int>(){0xB66E},                 //Confg
              new List<int>(){0xB636},                 //Find
              new List<int>(){0xB536, 0xAD3F},         //Save
              new List<int>(){0xB56A, 0xAD3F},         //Load
              new List<int>(){0xB5F5, 0xB620}          //Name
            };

            int index = comboBoxWindowsMenu.SelectedIndex;
            List<int> addresses = new List<int>();
            if (comboBoxWindowsMenu.SelectedIndex < 13)
            {
                addresses = new List<int>(groupAddresses[index]);
            }
            else
            {
                int address;
                int.TryParse(comboBoxWindowsMenu.Text, System.Globalization.NumberStyles.HexNumber, null, out address);
                addresses.Add(address);
            }

            resetNumericUpDownWindow();
            writeWindowsInfo(addresses);
            drawWindowInfo();
            panelWindowDisplay.Refresh();
        }



        private void writeWindowsInfo(List<int> addresses)
        {
            Byte[] sizes = { 0, 2, 6, 6, 5, 2, 6 };
            String[] funcs = { "End of Function",
				               "Fill Current Layer",
				               "Draw Fill Box",
				               "Draw Static Box",
				               "Draw Text: ",
				               "Change Layer",
				               "Draw Indent Box"};

            if (!fileToEditIsAvailable)
            {
                openSMCToolStripMenuItem_Click(null, null);
                if (!fileToEditIsAvailable)
                    return;
            }

            /* Concepts */
            /* 2F00 + 1632 bytes */
            List<String> conceptsVar = new List<string>();
            conceptsVar = appendToExportList(conceptsVar, tblManager.TBL_Reader2bpp, 0x00F987, 0x270000, 139, 0x00);

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            listViewWindows.Items.Clear();

            foreach (int item in addresses)
            {
                try
                {
                    br.BaseStream.Position = 0x030000 + headerOffset + item;
                    
                    /* Deprecated - Read size (2 bytes) */
                    int pos = 0;

                    /* Read */
                    Byte nextFunc = 0xFF;
                    while (nextFunc != 0x00)
                    {
                        int i = 0;
                        Byte textId = 0;
                        listViewWindows.Items.Add("C3");
                        int current = listViewWindows.Items.Count - 1;
                        
                        listViewWindows.Items[current].SubItems.Add((br.BaseStream.Position & 0x0000FFFF).ToString("X4"));
                        nextFunc = br.ReadByte();

                        listViewWindows.Items[current].SubItems.Add(nextFunc.ToString("X2"));
                        pos++;

                        if (nextFunc == 0x04)
                        {
                            textId = br.ReadByte();
                            listViewWindows.Items[current].SubItems.Add(textId.ToString("X2"));
                            i++;
                            pos++;
                        }

                        for (; i < sizes[nextFunc]; i++)
                        {
                            listViewWindows.Items[current].SubItems.Add(br.BaseStream.ReadByte().ToString("X2"));
                            pos++;
                        }
                        for (; i < 6; i++)
                        {
                            listViewWindows.Items[current].SubItems.Add("");
                        }

                        

                        if (nextFunc == 0x04)
                        {
                            if (textId < conceptsVar.Count)
                                listViewWindows.Items[current].SubItems.Add(funcs[nextFunc] + " " + conceptsVar[textId]);
                            else
                                listViewWindows.Items[current].SubItems.Add(funcs[nextFunc] + " (<UNKNOWN>)");
                        }
                        else
                        {
                            listViewWindows.Items[current].SubItems.Add(funcs[nextFunc]);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                }
            }

            br.Close();
            fs.Close();
        }



        private void listViewWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetNumericUpDownWindow();

            if (listViewWindows.SelectedItems.Count < 1) return;
            labelWindowFunction.Text = listViewWindows.SelectedItems[0].SubItems[9].Text;

            Byte[] sizes = { 0, 2, 6, 6, 5, 2, 6 };

            // 00 | End of Inst. List  | 0b |
            // 01 | Fill Current Layer | 2b | Char#, Color
            // 02 | Draw Box           | 6b | Char#, Color, X, Y, Width, Height
            // 03 | Draw Bordered Box  | 6b | Char#, Color, X, Y, Width, Height
            // 04 | Draw Text          | 5b | String#, Color, X, Y, Removed (Note: Color non-functional)
            // 05 | Change Layer       | 2b |
            // 06 | Draw Indented Box  | 6b | Char#, Color, X, Y, Width, Height (Calls 03/02)            
            
            int function;
            if (!int.TryParse(listViewWindows.SelectedItems[0].SubItems[2].Text, System.Globalization.NumberStyles.HexNumber, null, out function)) return;
            textBoxWindowAddress.Text = listViewWindows.SelectedItems[0].SubItems[1].Text;
            textBoxWindowFunction.Text = listViewWindows.SelectedItems[0].SubItems[2].Text;

            List<int> parameters = new List<int>();
            for (int i = 0; i < sizes[function]; i++)
            {
                int newParam;
                int.TryParse(listViewWindows.SelectedItems[0].SubItems[3 + i].Text, System.Globalization.NumberStyles.HexNumber, null, out newParam);
                parameters.Add(newParam);
            }

            switch (function)
            {
                case 0x00: //End of Function (0)
                    break;
                case 0x01: //Fill Current Layer (2)
                    break;
                case 0x02: //Draw Fill Box (6)
                case 0x03: //Draw Static Box (6)
                    numericUpDownWindowX.Value = parameters[2];
                    numericUpDownWindowY.Value = parameters[3];
                    numericUpDownWindowW.Value = parameters[4];
                    numericUpDownWindowH.Value = parameters[5];
                    numericUpDownWindowX.Enabled = true;
                    numericUpDownWindowY.Enabled = true;
                    numericUpDownWindowW.Enabled = true;
                    numericUpDownWindowH.Enabled = true;
                    break;
                case 0x04: //Draw Text (5)
                    numericUpDownWindowX.Value = parameters[2];
                    numericUpDownWindowY.Value = parameters[3];
                    numericUpDownWindowT.Value = parameters[0];
                    numericUpDownWindowX.Enabled = true;
                    numericUpDownWindowY.Enabled = true;
                    numericUpDownWindowT.Enabled = true;
                    break;
                case 0x05: //Change Layer (2)
                    break;
                case 0x06: //Draw Indent Box (6)
                    numericUpDownWindowX.Value = parameters[2];
                    numericUpDownWindowY.Value = parameters[3];
                    numericUpDownWindowW.Value = parameters[4];
                    numericUpDownWindowH.Value = parameters[5];
                    numericUpDownWindowX.Enabled = true;
                    numericUpDownWindowY.Enabled = true;
                    numericUpDownWindowW.Enabled = true;
                    numericUpDownWindowH.Enabled = true;
                    break;
                default:
                    break;
            }
        }



        private void resetNumericUpDownWindow()
        {
            numericUpDownWindowX.Enabled = false;
            numericUpDownWindowY.Enabled = false;
            numericUpDownWindowW.Enabled = false;
            numericUpDownWindowH.Enabled = false;
            numericUpDownWindowT.Enabled = false;
            numericUpDownWindowX.Value = 0;
            numericUpDownWindowY.Value = 0;
            numericUpDownWindowW.Value = 0;
            numericUpDownWindowH.Value = 0;
            numericUpDownWindowT.Value = 0;
            textBoxWindowAddress.Text = "";
            textBoxWindowFunction.Text = "";
        }



        private void drawWindowInfo()
        {
            int index = 0;
            Byte[] sizes = { 0, 2, 6, 6, 5, 2, 6 };
            windowsBmp[0] = new Bitmap(256, 256);
            windowsBmp[1] = new Bitmap(256, 256);
            windowsBmp[2] = new Bitmap(256, 256);
            List<List<Byte>> conceptsVar = readConceptsVar();
            Graphics g = Graphics.FromImage(windowsBmp[0]);

            foreach (ListViewItem item in listViewWindows.Items)
            {
                int function;
                if(!int.TryParse(item.SubItems[2].Text, System.Globalization.NumberStyles.HexNumber, null, out function)) continue;

                List<int> parameters = new List<int>();
                for(int i = 0 ; i < sizes[function] ; i++){
                    int newParam;
                    int.TryParse(item.SubItems[3 + i].Text, System.Globalization.NumberStyles.HexNumber, null, out newParam);
                    parameters.Add(newParam);
                }

                switch (function)
                {
                    case 0x00: //End of Function (0)
                        index++;
                        if (index < 3) g = Graphics.FromImage(windowsBmp[index]);
                        break;
                    case 0x01: //Fill Current Layer (2)
                        break;
                    case 0x02: //Draw Fill Box (6)
                        drawWindowBox(g, parameters[2], parameters[3], parameters[4] - 1, parameters[5] - 1);
                        break;
                    case 0x03: //Draw Static Box (6)
                        drawWindowBox(g, parameters[2], parameters[3], parameters[4] - 1, parameters[5] - 1);
                        break;
                    case 0x04: //Draw Text (5)
                        drawWindowText(g, conceptsVar[parameters[0]], parameters[2], parameters[3]);
                        break;
                    case 0x05: //Change Layer (2)
                        break;
                    case 0x06: //Draw Indent Box (6)
                        drawWindowBox(g, parameters[2], parameters[3], parameters[4] - 1, parameters[5] - 1);
                        break;
                    default:
                        break;
                }
            }

            g.Dispose();
        }



        private List<List<Byte>> readConceptsVar()
        {
            //conceptsVar
            //Count:    139
            //Addreses: 0x00F987
            //Offset:   0x270000
            List<List<Byte>> output = new List<List<Byte>>();
            List<int> addresses = new List<int>();

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

            br.BaseStream.Position = 0x00F987 + headerOffset;
            for (int i = 0; i < 139; i++)
            {
                addresses.Add(br.ReadByte() + br.ReadByte() * 0x0100);
            }
            foreach (int item in addresses)
            {
                List<Byte> newConcept = new List<Byte>();
                br.BaseStream.Position = 0x270000 + item + headerOffset;

                Byte newByte;
                while((newByte = br.ReadByte())!= 0x00 ){
                    newConcept.Add(newByte);
                }

                output.Add(newConcept);
            }

            br.Close();
            fs.Close();
            
            return output;
        }



        private void drawWindowBox(Graphics g, int x, int y, int width, int height)
        {
            //Draw background
            for (int i = x * 8; i < (x + width) * 8; i += 8)
                for (int j = y * 8; j < (y + height) * 8; j += 8)
                    g.DrawImage(font2bppChars[0x09], i, j, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);

            //Draw vertical bars
            for (int i = x * 8; i < (x + width) * 8; i += 8)
            {
                g.DrawImage(font2bppChars[0x02], i, y * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                g.DrawImage(font2bppChars[0x07], i, (y + height) * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
            }

            //Draw horizontal bars
            for (int j = y * 8; j < (y + height) * 8; j += 8)
            {
                g.DrawImage(font2bppChars[0x04], x * 8, j, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                g.DrawImage(font2bppChars[0x05], (x + width) * 8, j, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
            }

            //Draw corners
            g.DrawImage(font2bppChars[0x01], x * 8, y * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
            g.DrawImage(font2bppChars[0x03], (x + width) * 8, y * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
            g.DrawImage(font2bppChars[0x06], x * 8, (y + height) * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
            g.DrawImage(font2bppChars[0x08], (x + width) * 8, (y + height) * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
        }



        private void drawWindowText(Graphics g, List<Byte> str, int x, int y)
        {
            foreach (Byte item in str)
            {
                g.DrawImage(font2bppChars[item], x * 8, y * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                x++;
            }
        }



        private void panelWindowDisplay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (checkBoxDisplayW0.Checked) e.Graphics.DrawImage(windowsBmp[0], 1, 1, 256, 256);
            if (checkBoxDisplayW1.Checked) e.Graphics.DrawImage(windowsBmp[1], 1, 1, 256, 256);
            if (checkBoxDisplayW2.Checked) e.Graphics.DrawImage(windowsBmp[2], 1, 1, 256, 256);
        }



        private void numericUpDownWindowX_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWindowX.Enabled == true) numericUpDownWindowChangeHandler();
        }
        private void numericUpDownWindowY_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWindowY.Enabled == true) numericUpDownWindowChangeHandler();
        }
        private void numericUpDownWindowW_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWindowW.Enabled == true) numericUpDownWindowChangeHandler();
        }
        private void numericUpDownWindowH_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWindowH.Enabled == true) numericUpDownWindowChangeHandler();
        }
        private void numericUpDownWindowT_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownWindowT.Enabled == true) numericUpDownWindowChangeHandler();
        }
        private void numericUpDownWindowChangeHandler()
        {
            int address;
            int function;
            if (!int.TryParse(textBoxWindowAddress.Text, System.Globalization.NumberStyles.HexNumber, null, out address)) return;
            if (!int.TryParse(textBoxWindowFunction.Text, System.Globalization.NumberStyles.HexNumber, null, out function)) return;

            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = 0x030001 + address + headerOffset;

                switch (function)
                {
                    case 0x00: //End of Function (0)
                        break;
                    case 0x01: //Fill Current Layer (2)
                        break;
                    case 0x02: //Draw Fill Box (6)
                    case 0x03: //Draw Static Box (6)
                        bw.BaseStream.Position += 2;
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowX.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowY.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowW.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowH.Value);
                        break;
                    case 0x04: //Draw Text (5)
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowT.Value);
                        bw.BaseStream.Position += 1;
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowX.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowY.Value);
                        break;
                    case 0x05: //Change Layer (2)
                        break;
                    case 0x06: //Draw Indent Box (6)
                        bw.BaseStream.Position += 2;
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowX.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowY.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowW.Value);
                        bw.BaseStream.WriteByte((Byte)numericUpDownWindowH.Value);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error writing the file: " + err.ToString(), "Error");
            }

            bw.Close();
            fs.Close();

            int index = -1;
            if (listViewWindows.SelectedItems.Count > 0)
                index = listViewWindows.Items.IndexOf(listViewWindows.SelectedItems[0]);

            loadWindowsInfo();

            if (index >= 0)
            {
                listViewWindows.Items[index].Selected = true;
                listViewWindows.Select();
            }
        }



        private void checkBoxDisplayW_CheckedChanged(object sender, EventArgs e)
        {
            panelWindowDisplay.Refresh();
        }



        private void buttonDummy_Click(object sender, EventArgs e)
        {
            Dummy.createIpsFromCSV(72, 8, 0x260000, tblManager.TBL_Injector1bpp);
        }


        
    }
}
