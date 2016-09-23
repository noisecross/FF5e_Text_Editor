using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace FF5e_Text_Editor
{
    class Dummy
    {



        public static void displayCompressedTable(System.IO.BinaryReader br, long address, int headerOffset, bool unheaded = false)
        {
            //Dummy.displayCompressedTable(br, 0x033342, headerOffset); /* C SQUARE 1992 + Dragon : OAM mapping */
            //Dummy.displayCompressedTable(br, 0x031DFE, headerOffset); /* I dunno... Not graphics */
            //Dummy.displayCompressedTable(br, 0x031243, headerOffset); /* I dunno... Not graphics */

            List<Byte> table = Compressor.uncompress(address, br, headerOffset, unheaded);

            String message = "";
            int i = 1;
            foreach (Byte item in table)
            {
                message += item.ToString("X2") + " ";
                if (i == 0)
                    message += "\r\n";
                i = (i + 1) % 16;
            }
            System.Windows.Forms.MessageBox.Show(message);
        }



        /* public static void exportCompressedImage(System.IO.BinaryReader br, long address, int headerOffset, int type, bool unheaded = false)
        {
            //Dummy.exportCompressedImage(0x031E83, br, headerOffset, 4); // Chocobo Haryuu and PJs

            List<Byte> picture = Compressor.uncompress(address, br, headerOffset, unheaded);
            System.Drawing.Bitmap newBitmap = new System.Drawing.Bitmap(0, 0);

            //System.IO.File.WriteAllBytes("DummyImage.smc", picture.ToArray());

            switch (type)
            {
                case 01:
                    newBitmap = Transformations.transform1bpp(picture, 0, picture.Count);
                    ManageBMP.exportBPM("1bpp", newBitmap, Palettes.palette1b);
                    break;
                case 02:
                    newBitmap = Transformations.transform2bpp(picture, 0, picture.Count);
                    ManageBMP.exportBPM("2bpp", newBitmap, Palettes.palette2b);
                    break;
                case 03:
                    newBitmap = Transformations.transform3bpp(picture, 0, picture.Count);
                    ManageBMP.exportBPM("3bpp", newBitmap, Palettes.palette3b);
                    break;
                case 04:
                    newBitmap = Transformations.transform4b(picture, 0, picture.Count);
                    ManageBMP.exportBPM("4bpp", newBitmap, Palettes.palette4b);
                    break;
                default:
                    break;
            };
        }
        */



        /* public static void injectImage(System.IO.BinaryWriter bw, long address, int headerOffset, int type, int imageSize, int maxCompSize, bool unheaded = false)
        {
            //Dummy.injectImage(bw, 0x105C0A, headerOffset, 0x04, 0x1400, 0x0BF5); // New Title

            List<Byte> newBytes = new List<Byte>();
            Byte size00 = BitConverter.GetBytes(imageSize)[1];
            Byte size01 = BitConverter.GetBytes(imageSize)[0];

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "PNG File|*.png|BMP File|*.bmp";
            openFileDialog.Title = "Choose a file";

            // Show the Dialog
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    try
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(openFileDialog.FileName);
                        int size = bitmap.Width * bitmap.Height;
                        byte[] bitmapPixels = new byte[size];

                        // Open it to edit
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                            new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        // Recover the original values (now lost because of the conversion)
                        for (int i = 0; i < size; i++)
                        {
                            bitmapPixels[i] = System.Runtime.InteropServices.Marshal.ReadByte(data.Scan0, i);
                        }

                        int nColumns = (int)Math.Truncate(128.0 / 8);
                        size = (size - (size % ((8 * nColumns) * 8)));
                        if (size == imageSize * 2)
                        {
                            switch (type)
                            {
                                case 01:
                                    newBytes = InvertingTransformations.import1bpp(bitmapPixels, 8, 8, size);
                                    break;
                                case 02:
                                    newBytes = InvertingTransformations.import2bpp(bitmapPixels, 8, 8, size);
                                    break;
                                case 03:
                                    newBytes = InvertingTransformations.import3bpp(bitmapPixels, 8, 8, size);
                                    break;
                                case 04:
                                    newBytes = InvertingTransformations.import4bpp(bitmapPixels, 8, 8, size);
                                    break;
                                default:
                                    break;
                            };
                        }
                        else
                        {
                            newBytes = new List<Byte>();
                        }
                    }
                    catch (Exception error)
                    {
                        System.Windows.Forms.MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                    }
                }
            }

            openFileDialog.Dispose();
            openFileDialog = null;

            newBytes = Compressor.compress(newBytes, null);
            newBytes.Insert(0, BitConverter.GetBytes(imageSize)[1]);
            newBytes.Insert(0, BitConverter.GetBytes(imageSize)[0]);

            if(!unheaded)
              newBytes.Insert(0, 0x02);

            if (newBytes.Count <= maxCompSize)
            {
                try
                {
                    bw.BaseStream.Position = address + headerOffset;

                    foreach (Byte item in newBytes)
                    {
                        bw.BaseStream.WriteByte(item);
                    }

                    System.Windows.Forms.MessageBox.Show("Operation done successfully.", "Info");
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Compressed data is bigger than expected.", "Error");
            }
        }
        */



        public static void injectNewTitleOAM(System.IO.BinaryWriter bw, int headerOffset)
        {
            List<Byte> newTable = new List<byte>(){
              //  Ac    AX    AY    TL    Fl    B1    B2
              //----------------------------------------
                0x40, 0x58, 0xB8, 0x80, 0x38, 0x00, 0x00, // (C)
                0x8F, 0x10, 0x00, 0x81, 0x38, 0x00, 0x00, // S
                0x8F, 0x08, 0x00, 0x82, 0x38, 0x00, 0x00, // Q
                0x8F, 0x08, 0x00, 0x83, 0x38, 0x00, 0x00, // U
                0x8F, 0x08, 0x00, 0x84, 0x38, 0x00, 0x00, // A
                0x8F, 0x08, 0x00, 0x85, 0x38, 0x00, 0x00, // R
                0x8F, 0x08, 0x00, 0x86, 0x38, 0x00, 0x00, // E
                0x8F, 0x10, 0x00, 0x87, 0x38, 0x00, 0x00, // 19
                0x8F, 0x08, 0x00, 0x88, 0x38, 0x00, 0x00, // 92
                0x49, 0x20, 0x00, 0x00, 0x0C, 0x08, 0x00, // Dragon
                0x8F, 0x10, 0x00, 0x02, 0x0C, 0x20, 0x00, 
                0x8F, 0x10, 0x00, 0x04, 0x0C, 0x80, 0x00, 
                0x8F, 0x10, 0x00, 0x06, 0x0C, 0x00, 0x02, 
                0x8F, 0x10, 0x00, 0x08, 0x0C, 0x00, 0x08, 
                0x8F, 0x10, 0x00, 0x0A, 0x0C, 0x00, 0x20, 
                0x8F, 0x10, 0x00, 0x0C, 0x0C, 0x00, 0x80, 
                0x8F, 0xA0, 0x10, 0x20, 0x0C, 0x02, 0x00, 
                0x8F, 0x10, 0x00, 0x22, 0x0C, 0x08, 0x00, 
                0x8F, 0x10, 0x00, 0x24, 0x0C, 0x20, 0x00, 
                0x8F, 0x10, 0x00, 0x26, 0x0C, 0x80, 0x00, 
                0x8F, 0x10, 0x00, 0x28, 0x0C, 0x00, 0x02, 
                0x8F, 0x10, 0x00, 0x2A, 0x0C, 0x00, 0x08, 
                0x8F, 0x10, 0x00, 0x2C, 0x0C, 0x00, 0x20, 
                0x8F, 0x10, 0x00, 0x2E, 0x0C, 0x00, 0x80, 
                0x8F, 0x90, 0x10, 0x40, 0x0C, 0x02, 0x00, 
                0x8F, 0x10, 0x00, 0x42, 0x0C, 0x08, 0x00, 
                0x8F, 0x10, 0x00, 0x44, 0x0C, 0x20, 0x00, 
                0x8F, 0x10, 0x00, 0x46, 0x0C, 0x80, 0x00, 
                0x8F, 0x10, 0x00, 0x48, 0x0C, 0x00, 0x02, 
                0x8F, 0x10, 0x00, 0x4A, 0x0C, 0x00, 0x08, 
                0x8F, 0x10, 0x00, 0x4C, 0x0C, 0x00, 0x20, 
                0x8F, 0x10, 0x00, 0x4E, 0x0C, 0x00, 0x80, 
                0x8F, 0x90, 0x10, 0x60, 0x0C, 0x02, 0x00, 
                0x8F, 0x10, 0x00, 0x62, 0x0C, 0x08, 0x00, 
                0x8F, 0x10, 0x00, 0x64, 0x0C, 0x20, 0x00, 
                0x8F, 0x10, 0x00, 0x66, 0x0C, 0x80, 0x00, 
                0x8F, 0x10, 0x00, 0x68, 0x0C, 0x00, 0x02, 
                0x8F, 0x10, 0x00, 0x6A, 0x0C, 0x00, 0x08, 
                0x8F, 0x10, 0x00, 0x6C, 0x0C, 0x00, 0x20, 
                0x8F, 0x10, 0x00, 0x6E, 0x0C, 0x00, 0x80, 
                0x8F, 0x10, 0xE0, 0x0E, 0x0C, 0x02, 0x00, 
                0x70, 0x69, 0xC2, 0x8A, 0x38, 0x00, 0x00, // noisecross
                0x8F, 0x08, 0x00, 0x8B, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x8C, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x8D, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x8E, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x8F, 0x38, 0x00, 0x00, 
                0x76, 0x69, 0xCB, 0x9A, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x9B, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x9C, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x9D, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x9E, 0x38, 0x00, 0x00, 
                0x8F, 0x08, 0x00, 0x9F, 0x38, 0x00, 0x00, 
                0x7C, 0xA0, 0xC7, 0x97, 0x38, 0x00, 0x00, // 2015
                0x8F, 0x08, 0x00, 0x98, 0x38, 0x00, 0x00, 
                0x80            
            };
            int imageSize = newTable.Count;

            newTable = Compressor.compress(newTable, null);

            newTable.Insert(0, BitConverter.GetBytes(imageSize)[1]);
            newTable.Insert(0, BitConverter.GetBytes(imageSize)[0]);
            newTable.Insert(0, 0x02);

            if (newTable.Count <= 0x450)
            {
                try
                {
                    bw.BaseStream.Position = 0x105C0A + headerOffset;

                    foreach (Byte item in newTable)
                    {
                        bw.BaseStream.WriteByte(item);
                    }

                    System.Windows.Forms.MessageBox.Show("Operation done successfully.", "Info");
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Compressed data is bigger than expected.", "Error");
            }
        }



        /*public static void mapDecypher(System.IO.BinaryReader br, int headerOffset, int id)
        {
            /*
            09 1115 used in $C0/591A (DC2D84,((00:1115 & 0x3F (6 bits)) * 4) + DC/2E24)                 First  [4bpp 8x8] Graphics load
            .. .... used in $C0/596A (DC2D84,(Invert_Bytes((00:1115..16 & 0FC0) * 4) * 4) + DC/2E24)    Second [4bpp 8x8] Graphics load
            0A 1116 used in $C0/59D7 (DC2D84,((00:1116..7 & 03F0)/4) + DC/2E24)                         Third  [4bpp 8x8] Graphics load
            0B 1117 used in $C0/5A45 (DC0000,((00:1117 & #$FC) / 2) + DC/0024)                                 [2bpp 8x8] Graphics load

            0C 1118 used in $C0/5877 (CB0000,(((00:1118 & 0x03FF) - 1) * 2) + CB...CC.../0000???)              [unheaded Type02] (I.e. CC/344B) -> Bytemap decompressed in 7F:0000
            0D 1119 used in $C0/588D (if (((00:1119 & 0x0FFC) / 4) - 1) == 0xFFFF => 0-> 7F0000:7F0FFF)        [unheaded Type02] -> Bytemap ???? decompressed in 7F:1000 ????
            0E 111A used in $C0/58B6 (CB0000,(((00:111A & 0x3FF0)/16) - 1) * 2) + CB...CC.../0000???)          [unheaded Type02] (I.e. CC/344B) -> Bytemap ???? decompressed in 7F:2000 ????
            0F 111B " 
            
            16 1122 Used in $C0/58DB (Sent 0x100 bytes C3BB00,([17] * 0x0100 [16]) (i.e. C3:C400) -> to 00:0C00 [Palette])
            // 

            int offset = 0;
            br.BaseStream.Position = 0x0E9C00 + headerOffset + (id * 0x1A);
            List<Byte> mapDescriptors = br.ReadBytes(0x1A).ToList();



            br.BaseStream.Position = 0x03BB00 + headerOffset + (mapDescriptors[0x16] + mapDescriptors[0x17] * 0x0100);
            Byte[]  bytePal = br.ReadBytes(0x0100);
            Color[] palette = new Color[0x0100];
            for (int i = 0; i < 0x0100; i += 2)
            {
                int color = bytePal[i] + bytePal[i + 1] * 0x0100;
                int r = ((color /    1) % 32) * 8;
                int g = ((color /   32) % 32) * 8;
                int b = ((color / 1024) % 32) * 8;
                r = r + r / 32;
                g = g + g / 32;
                b = b + b / 32;

                palette[i] = Color.FromArgb(r, g, b);
            }

            br.BaseStream.Position = 0x1C2D84 + headerOffset + ((mapDescriptors[0x09] & 0x3F) * 4);
            offset = br.ReadByte() + (br.ReadByte() * 0x0100) + (br.ReadByte() * 0x010000) + 0x1C2E24 + headerOffset;
            br.BaseStream.Position = offset;
            Bitmap firstBitmap = Transformations.transform4b(br.ReadBytes(0x2000).ToList(), 0, 0x2000);
            ManageBMP.exportBPM("firstBitmap.png", firstBitmap, palette);

            br.BaseStream.Position = 0x1C2D84 + headerOffset + ((((mapDescriptors[0x09] & 0xC0) / 4)  + (mapDescriptors[0x0A] & 0x0F)) * 4);
            offset = br.ReadByte() + (br.ReadByte() * 0x0100) + (br.ReadByte() * 0x010000) + 0x1C2E24 + headerOffset;
            br.BaseStream.Position = offset;
            Bitmap secondBitmap = Transformations.transform4b(br.ReadBytes(0x2000).ToList(), 0, 0x2000);
            ManageBMP.exportBPM("secondBitmap.png", secondBitmap, palette);

            br.BaseStream.Position = 0x1C2D84 + headerOffset + (((mapDescriptors[0x0A] + (mapDescriptors[0x0B] * 0x0100)) & 0x03F0) / 4);
            offset = br.ReadByte() + (br.ReadByte() * 0x0100) + (br.ReadByte() * 0x010000) + 0x1C2E24 + headerOffset;
            br.BaseStream.Position = offset;
            Bitmap thirdBitmap = Transformations.transform4b(br.ReadBytes(0x2000).ToList(), 0, 0x2000);
            ManageBMP.exportBPM("thirdBitmap.png", thirdBitmap, palette);

            br.BaseStream.Position = 0x1C0000 + headerOffset + ((mapDescriptors[0x0B] & 0xFC) / 2);
            offset = br.ReadByte() + (br.ReadByte() * 0x0100) + 0x1C0024 + headerOffset;
            br.BaseStream.Position = offset;
            Bitmap forthBitmap = Transformations.transform2bpp(br.ReadBytes(0x2000).ToList(), 0, 0x1000);
            ManageBMP.exportBPM("forthBitmap.png", forthBitmap, Palettes.palette2b);
        }
        */



        public static void editSRM(){
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "SRM File|*.srm";
            openFileDialog.Title = "Choose a file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = new System.IO.FileStream(openFileDialog.FileName, System.IO.FileMode.Open);
                    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, new UnicodeEncoding());
                    System.IO.BinaryReader br = new System.IO.BinaryReader(fs, new UnicodeEncoding());

                    // Compare checksum
                    int accumulator = 0;
                    //int currrentChecksum = 0;

                    // Edit items
                    bw.BaseStream.Position = 0x0140;
                    for (int i = 0; i < 0x100; i++)
                    {
                        bw.BaseStream.WriteByte(BitConverter.GetBytes(i)[0]);
                    }
                    for (int i = 0; i < 0x100; i++)
                    {
                        bw.BaseStream.WriteByte(0x08);
                    }

                    br.BaseStream.Position = 0x0000;

                    for (int i = 0; i < 0x300; i++)
                    {
                        accumulator += br.ReadByte() + br.ReadByte() * 0x0100;
                        if (accumulator > 0xFFFF) accumulator -= 0xFFFF; // or(0x010000)
                    }

                    /*
                    FFVI
 
                    for(int i = 0 ; i < 0x09FE ; i++) {
	                    accumulator += br.ReadByte() + br.ReadByte() * 0x0100;
	                    if (accumulator > 0xFFFF) accumulator -= 0xFFFF; // or(0x010000)	
                    }

                    bw.BaseStream.Position = 0x09FE;
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(accumulator)[0]);
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(accumulator)[1]);
                    */

                    bw.BaseStream.Position = 0x1FF0;
                    //currrentChecksum = br.ReadByte() + br.ReadByte() * 0x0100;
                    //System.Windows.Forms.MessageBox.Show(currrentChecksum.ToString("X4"), accumulator.ToString("X4"));
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(accumulator)[0]);
                    bw.BaseStream.WriteByte(BitConverter.GetBytes(accumulator)[1]);

                    bw.Close();
                    bw.Dispose();
                    br.Close();
                    br.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }

            openFileDialog.Dispose();
            openFileDialog = null;
        }



        public static Bitmap displaySkillsM(System.IO.BinaryReader br, Bitmap font2bppBitmap, Dictionary<Byte, String> inputTBL)
        {
            Bitmap output = new Bitmap(1024, 1024);

            // Set the tile characters
            Bitmap[] font2bppChars = new Bitmap[256];

            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < 16; i++)
                {
                    Rectangle cloneRect = new Rectangle(i * 8, j * 8, 8, 8);
                    font2bppChars[(j * 16) + i] = font2bppBitmap.Clone(cloneRect, font2bppBitmap.PixelFormat);
                }
            }


            // SkillsM 01
            //0x111C80, 87regs, 6 bytes
            List<List<Byte>> skillsM01 = new List<List<byte>>();
            br.BaseStream.Position = 0x111C80;
            for (int i = 0; i < 87; i++)
            {
                skillsM01.Add(br.ReadBytes(6).ToList());
            }


            // SkillsM 02
            //0x270F90, 169regs, 12 bytes
            List<List<Byte>> skillsM02 = new List<List<byte>>();
            br.BaseStream.Position = 0x270F90;
            for (int i = 0; i < 169; i++)
            {
                skillsM02.Add(br.ReadBytes(12).ToList());
            }


            // SkillsM Blue
            //0x11200D, 30regs, 9 bytes
            List<List<Byte>> skillsMBlue = new List<List<byte>>();
            br.BaseStream.Position = 0x11200D;
            for (int i = 0; i < 30; i++)
            {
                skillsMBlue.Add(br.ReadBytes(9).ToList());
            }


            // SkillsM Songs
            //0x111E8A, 8regs, 9 bytes
            List<List<Byte>> skillsMSongs = new List<List<Byte>>();
            br.BaseStream.Position = 0x111E8A;
            for (int i = 0; i < 8; i++)
            {
                skillsMSongs.Add(br.ReadBytes(9).ToList());
            }




            // appendToExportList


            /*
            Graphics g = Graphics.FromImage(output);
            for (int j = 0; j < 169; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    Bitmap tile = font2bppChars[skillsM02[j][i]];
                    g.DrawImage(tile, i * 8, j * 8, new Rectangle(0, 0, 8, 8), GraphicsUnit.Pixel);
                }
            }
            g.Dispose();
            */

            return output;
        }



        public static void createIpsFromCSV(int nRegisters, int sizeRegisters, int address, Dictionary<String, Byte> inputTBL)
        {
            List<String> inputStr = CSV_Manager.openFixedSizedTableCSV();

            if (inputStr.Count != nRegisters)
                return;

            List<Byte> byteStream = new List<Byte>();
            Byte addressL = (Byte)((address >> 0x00) & 0x0000FF);
            Byte addressM = (Byte)((address >> 0x08) & 0x0000FF);
            Byte addressH = (Byte)((address >> 0x10) & 0x0000FF);
            Byte sizeL = (Byte)(((nRegisters * sizeRegisters) >> 0x00) & 0x0000FF);
            Byte sizeH = (Byte)(((nRegisters * sizeRegisters) >> 0x08) & 0x0000FF);

            byteStream.Add(0x50); //P
            byteStream.Add(0x41); //A
            byteStream.Add(0x54); //T
            byteStream.Add(0x43); //C
            byteStream.Add(0x48); //H

            byteStream.Add(addressH); //address H
            byteStream.Add(addressM); //address M
            byteStream.Add(addressL); //address L
            byteStream.Add(sizeH); //size H
            byteStream.Add(sizeL); //size L

            foreach (String item in inputStr)
            {
                byteStream.AddRange(parseStringList(item, inputTBL, sizeRegisters)); //Byte table
            }

            byteStream.Add(0x45); //E
            byteStream.Add(0x4F); //O
            byteStream.Add(0x46); //F

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter   = "IPS File|*.ips";
            saveFileDialog.Title    = "Choose a IPS file";
            saveFileDialog.FileName = "newTable" + address.ToString("X6");

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);

                    try
                    {
                        bw.Write(byteStream.ToArray());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error writing the file: \r\n" + e.ToString(), "Error");
                    }

                    bw.Close();
                    fs.Close();
                }
            }
        }



        private static List<Byte> parseStringList(String inputString, Dictionary<String, Byte> inputTBL, int size = 0, byte fillCharacter = 0xFF, bool forceBlankToFF = false)
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



    }
}
