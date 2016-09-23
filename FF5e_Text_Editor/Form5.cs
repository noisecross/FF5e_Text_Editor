/**
* |------------------------------------------|
* | FF5e_Text_editor                         |
* | File: Form5.cs                           |
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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FF5e_Text_Editor
{
    public partial class Form5 : Form
    {
        List<long> addresses;
        List<List<Byte>> byteList;
        List<String> stringList;
        List<Bitmap> BitmapList;
        ImageList imgList = new ImageList();

        Bitmap[] fontBitmap;
        int[] fontWidths;
        int byteWidth = 0;
        int selectedIndex = -1;

        String fileUnderEdition = "";
        //TBL_Manager tblManager;
        Dictionary<String, Byte> dictionary;
        int headerOffset = 0;
        int imgSizeWidth = 16;
        


        public Form5(String fileUnderEdition, int headerOffset, Dictionary<String, Byte> dictionary, List<long> addresses, List<List<Byte>> byteList, List<String> stringList, Bitmap[] fontBitmap, int byteWidth, bool forbidEdition = false, int[] fontWidths = null)
        {
            InitializeComponent();

            this.fileUnderEdition = fileUnderEdition;
            this.headerOffset = headerOffset;
            this.dictionary = dictionary;
            this.addresses = addresses;
            this.byteList = byteList;
            this.stringList = stringList;
            this.fontBitmap = fontBitmap;
            this.byteWidth = byteWidth;
            this.fontWidths = fontWidths;

            if (forbidEdition) buttonInject.Enabled = false;
            
            BitmapList = new List<Bitmap>();
            if (this.fontWidths == null)
            {
                imgSizeWidth = 8;
                this.fontWidths = Enumerable.Repeat(8, 256).ToArray();
            }

            imgList.ImageSize = new Size(Math.Min(imgSizeWidth * (byteWidth + 2), 256), 12 + (int)(imgSizeWidth * 0.5));
            listViewPreviews.SmallImageList = imgList;

            for (int i = 0; i < byteList.Count; i++)
            {
                listViewPreviews.Items.Add(new System.Windows.Forms.ListViewItem(new string[] {
                    "",
                    hexToString(byteList[i]),
                    stringList[i] }, -1));
                listViewPreviews.Items[listViewPreviews.Items.Count - 1].ImageIndex = i;
            }

            initializeBitmapList();
        }



        private void initializeBitmapList()
        {
            int i = 0;
            foreach (List<Byte> item in byteList)
            {
                Bitmap newBitmap = generateBitmap(item);
                imgList.Images.Add(new Bitmap(1, 1));
                imgList.Images[i++] = newBitmap;
            }
        }



        private Bitmap generateBitmap(List<Byte> item)
        {
            Bitmap newBitmap = new Bitmap(imgSizeWidth * (byteWidth + 2), 12 + (int)(imgSizeWidth * 0.5));

            Graphics g = Graphics.FromImage(newBitmap);
            g.FillRectangle(new SolidBrush(Color.FromArgb(0x00, 0x00, 0xC1)), new Rectangle(0, 0, imgSizeWidth * (byteWidth + 2), imgSizeWidth * 2));

            int i = 8;

            foreach (Byte subItem in item)
            {
                if (fontBitmap[subItem] != null)
                {
                    g.DrawImage(fontBitmap[subItem],
                        i,
                        4,
                        new Rectangle(0, 0, imgSizeWidth, imgSizeWidth), GraphicsUnit.Pixel);
                }
                i += fontWidths[subItem];
            }
            g.Dispose();

            return newBitmap;
        }



        private String hexToString(List<Byte> input)
        {
            String output = "";
            if (input.Count < 1) return "n/a";

            foreach(Byte item in input){
                output += item.ToString("X2") + " ";
            }

            return output;
        }



        private List<Byte> parseStringList(String inputString, Dictionary<String, Byte> inputTBL, int size = 0, byte fillCharacter = 0xFF, bool forceBlankToFF = false)
        {
            bool syntaxError = false;
            int maxDictItemSize = (inputTBL.Keys).OrderByDescending(s => s.Length).First().Length;
            String syntaxErrors = "";

            String currentString = inputString;
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

						currentString = currentString.Substring(i);
						found = true;
						break;
					}
				}

				if (!found)
				{
                    syntaxErrors += "The register " + inputString + " cannot be parsed\r\n";
					syntaxError = true;
					break;
				}
			}

			if (newByteLs.Count > size)
			{
                syntaxErrors += "The register " + inputString + " is too long (may be " + inputString + " bytes long)\r\n";
				syntaxError = true;
			}
			else
			{
				for (int i = newByteLs.Count; i < size; i++)
				{
					newByteLs.Add(fillCharacter);
				}
			}

			if (syntaxError)
			{
				newByteLs.Clear();
			}

            return newByteLs;
        }



        private void listViewPreviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPreviews.SelectedItems.Count < 1) return;
            selectedIndex = listViewPreviews.Items.IndexOf(listViewPreviews.SelectedItems[0]);

            //Draw texts inside the TextBoxes
            textBoxAddress.Text = (addresses[selectedIndex] + 0xC00000).ToString("X6");
            textBoxNewText.Text = listViewPreviews.SelectedItems[0].SubItems[2].Text;
            textBoxHex.Text = listViewPreviews.SelectedItems[0].SubItems[1].Text;
        }



        private void textBoxNewText_TextChanged(object sender, EventArgs e)
        {
            textBoxHex.Text = hexToString(parseStringList(textBoxNewText.Text, dictionary, byteList[selectedIndex].Count));
        }



        private void buttonInject_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0) return;

            List<Byte> newHex = parseStringList(textBoxNewText.Text, dictionary, byteList[selectedIndex].Count);
            if (newHex.Count < 1) return;

            byteList[selectedIndex] = newHex;

            if (updateFile(addresses[selectedIndex], newHex))
            {
                imgList.Images[selectedIndex] = generateBitmap(newHex);
                listViewPreviews.SelectedItems[0].SubItems[1].Text = hexToString(newHex);
                listViewPreviews.SelectedItems[0].SubItems[2].Text = textBoxNewText.Text;
            }
        }



        private bool updateFile(long address, List<Byte> bytesToWrite)
        {
            bool output = true;
            
            System.IO.FileStream fs = new System.IO.FileStream(fileUnderEdition, System.IO.FileMode.Open);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());

            try
            {
                bw.BaseStream.Position = address + headerOffset;
                foreach (Byte item in bytesToWrite)
                {
                    bw.BaseStream.WriteByte(item);
                }
            }
            catch (Exception err)
            {
                output = false;
                MessageBox.Show("Error writing the file: " + err.ToString(), "Error");
            }

            bw.Close();
            fs.Close();
            
            return output;
        }



    }
}
