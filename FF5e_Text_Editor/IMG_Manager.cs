using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FF5e_Text_Editor
{



    public class IMG_Manager
    {

    }



    public static class Palettes
    {
        public static Color[] palette1b = new Color[2]{
            Color.FromArgb(0x00,0x00,0xC1),
            Color.FromArgb(0xFF,0xFF,0xFF)
        };

        public static Color[] palette2b = new Color[4]{
            Color.FromArgb(0x00,0x00,0x00),
            Color.FromArgb(0x00,0x00,0xC1),
            Color.FromArgb(0xAD,0xD8,0xE6),
            Color.FromArgb(0xFF,0xFF,0xFF)
        };

        public static Color[] palette3b = new Color[8]{
            Color.FromArgb(0x00,0x00,0xFF),
            Color.FromArgb(0x20,0x20,0x20),
            Color.FromArgb(0x40,0x40,0x40),
            Color.FromArgb(0x60,0x60,0x60),
            Color.FromArgb(0x80,0x80,0x80),
            Color.FromArgb(0xA0,0xA0,0xA0),
            Color.FromArgb(0xC0,0xC0,0xC0),
            Color.FromArgb(0xFF,0xFF,0xFF)
        };

        public static Color[] palette4b = new Color[16]{
            Color.FromArgb(0x00,0x00,0x00),
            Color.FromArgb(0x11,0x11,0x11),
            Color.FromArgb(0x22,0x22,0x22),
            Color.FromArgb(0x33,0x33,0x33),

            Color.FromArgb(0x44,0x44,0x44),
            Color.FromArgb(0x55,0x55,0x55),
            Color.FromArgb(0x66,0x66,0x66),
            Color.FromArgb(0x77,0x77,0x77),

            Color.FromArgb(0x88,0x88,0x88),
            Color.FromArgb(0x99,0x99,0x99),
            Color.FromArgb(0xAA,0xAA,0xAA),
            Color.FromArgb(0xBB,0xBB,0xBB),

            Color.FromArgb(0xCC,0xCC,0xCC),
            Color.FromArgb(0xDD,0xDD,0xDD),
            Color.FromArgb(0xEE,0xEE,0xEE),
            Color.FromArgb(0xFF,0xFF,0xFF)
        };
    }



    public class Transformations
    {
        /* Offset 0x03EB00 */
        /* Size   0x0012C0 */
        public static Bitmap transform1bpp(List<byte> byteMap, int offset, int size)
        {
            int maxY = (int)((size * 16 * 8) / 2048);
            Bitmap newBitmap = new Bitmap(16 * 8, maxY);

            int i = offset;
            int end = i + size;

            int x = 0;
            int y = 0;
            byte mask = 0x80;

            while (i < end) for (int yi = 0; yi < 128 / 12; yi++)
                {
                    if (y + 12 > newBitmap.Height)
                    {
                        i = int.MaxValue;
                        break;
                    }

                    /* Draw a line of tiles (1b) */
                    for (int xi = 0; xi < 128 / 8; xi++)
                    {

                        /* Draw a tile (1b) */
                        for (int j = 0; j < 12; j++)
                        {
                            if (i >= byteMap.Count || i >= end)
                                return newBitmap;

                            byte pixel1b = byteMap[i];

                            for (int k = 0; k < 8; k++)
                            {
                                newBitmap.SetPixel(x, y, ((pixel1b & mask) == 0) ? Palettes.palette1b[0] : Palettes.palette1b[1]);
                                x++;
                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;
                            }
                            x -= 8;
                            y++;
                            i++; //Next byte
                        }
                        x += 8;
                        y -= 12;

                    }
                    x = 0;
                    y += 12;
                }

            return newBitmap;
        }



        /* Offset 0x11F000 */
        /* Size   0x001000 */
        public static Bitmap transform2bpp(List<byte> byteMap, int offset, int size)
        {
            int maxY = (int)((size * 16 * 8) / 4096);
            Bitmap newBitmap = new Bitmap(16 * 8, maxY);

            int i = offset;
            int end = i + size;

            int x = 0;
            int y = 0;
            int cIndex = 0;

            while (i < end) for (int yi = 0; yi < 128 / 8; yi++)
                {
                    if (y + 8 > newBitmap.Height)
                    {
                        i = int.MaxValue;
                        break;
                    }

                    /* Draw a line of tiles (2b,8x8) */
                    for (int xi = 0; xi < 128 / 8; xi++)
                    {

                        /* Draw a tile (2b,8x8) */
                        for (int j = 0; j < 8; j++)
                        {
                            if (i >= byteMap.Count - 1 || i >= end)
                                return newBitmap;

                            byte pixel2b_00 = byteMap[i++];
                            byte pixel2b_01 = byteMap[i++];
                            byte mask = 0x80;

                            for (int k = 0; k < 8; k++)
                            {
                                cIndex = ((pixel2b_00 & mask) == 0) ? 0 : 1;
                                cIndex += ((pixel2b_01 & mask) == 0) ? 0 : 2;
                                newBitmap.SetPixel(x, y, Palettes.palette2b[cIndex]);
                                x++;
                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;
                            }
                            x -= 8;
                            y++;

                        }
                        x += 8;
                        y -= 8;

                    }
                    x = 0;
                    y += 8;
                }

            return newBitmap;
        }



        public static Bitmap transform3bpp(List<byte> byteMap, int offset, int size)
        {
            int maxY = (int)((size * 16 * 8) / 6144);
            Bitmap newBitmap = new Bitmap(16 * 8, maxY);

            int i = offset;
            int end = i + size;

            int x = 0;
            int y = 0;
            int cIndex = 0;

            while (i < end) for (int yi = 0; yi < 128 / 8; yi++)
                {
                    if (y + 8 > newBitmap.Height)
                    {
                        i = int.MaxValue;
                        break;
                    }

                    /* Draw a line of tiles (3b,8x8) */
                    for (int xi = 0; xi < 128 / 8; xi++)
                    {

                        /* Draw a tile (3b,8x8) */
                        int l = i + 16;

                        for (int j = 0; j < 8; j++)
                        {
                            if (i >= byteMap.Count - 1 || i >= end)
                                return newBitmap;

                            byte pixel3b_00 = byteMap[i++];
                            byte pixel3b_01 = byteMap[i++];
                            byte pixel3b_02 = byteMap[l++];
                            byte mask = 0x80;

                            for (int k = 0; k < 8; k++)
                            {
                                cIndex = ((pixel3b_00 & mask) == 0) ? 0 : 1;
                                cIndex += ((pixel3b_01 & mask) == 0) ? 0 : 2;
                                cIndex += ((pixel3b_02 & mask) == 0) ? 0 : 4;
                                newBitmap.SetPixel(x, y, Palettes.palette3b[cIndex]);
                                x++;
                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;
                            }
                            x -= 8;
                            y++;

                        }
                        i += 8;
                        x += 8;
                        y -= 8;

                    }
                    x = 0;
                    y += 8;
                }

            return newBitmap;
        }



        public static Bitmap transform4b(List<byte> byteMap, int offset, int size)
        {
            int maxY = (int)((size * 16 * 8) / 8192);
            Bitmap newBitmap = new Bitmap(16 * 8, maxY);

            int i = offset;
            int end = i + size;

            int x = 0;
            int y = 0;
            int cIndex = 0;
            int bpl23;

            while (i < end) for (int yi = 0; yi < 128 / 8; yi++)
                {
                    if (y + 8 > newBitmap.Height)
                    {
                        i = int.MaxValue;
                        break;
                    }

                    /* Draw a line of tiles (4b,8x8) */
                    for (int xi = 0; xi < 128 / 8; xi++)
                    {

                        /* Draw a tile (4b,8x8) */
                        bpl23 = i + 8 * 2;
                        for (int j = 0; j < 8; j++)
                        {
                            if (bpl23 >= byteMap.Count - 1 || bpl23 >= end)
                                return newBitmap;

                            byte pixel4b_00 = byteMap[i++];
                            byte pixel4b_01 = byteMap[i++];
                            byte pixel4b_02 = byteMap[bpl23++];
                            byte pixel4b_03 = byteMap[bpl23++];
                            byte mask = 0x80;

                            for (int k = 0; k < 8; k++)
                            {
                                cIndex = (pixel4b_00 & mask) == 0 ? 0 : 1;
                                cIndex += (pixel4b_01 & mask) == 0 ? 0 : 2;
                                cIndex += (pixel4b_02 & mask) == 0 ? 0 : 4;
                                cIndex += (pixel4b_03 & mask) == 0 ? 0 : 8;
                                newBitmap.SetPixel(x, y, Palettes.palette4b[cIndex]);
                                //outBytes[x, y] = (byte)cIndex;
                                x++;
                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;
                            }
                            x -= 8;
                            y++;

                        }
                        x += 8;
                        y -= 8;
                        i += 8 * 2; //Discard the 16 bytes of the bpl2 & bpl3 (previously readen)

                    }
                    x = 0;
                    y += 8;
                }

            return newBitmap;
        }
    }



    public class InvertingTransformations
    {


        public static List<byte> import1bpp(byte[] input, int widthX, int widthY, int size)
        {
            size = size / 8;

            List<byte> output = new List<byte>(size);
            for (int j = 0; j < size; j++)
            {
                output.Add(0);
            }

            /* Input is a pixel array. First 8 bytes represent the first output byte */
            byte mask = 0x80;
            byte pixel1b = 0;
            int i = 0;
            int x = 0;
            int y = 0;

            while (i < size) for (int yi = 0; yi < 128 / widthY; yi++)
                {
                    /* Draw a line of tiles (1b) */
                    for (int xi = 0; xi < 128 / widthX; xi++)
                    {

                        /* Draw a tile (1b) */
                        for (int j = 0; j < widthY; j++)
                        {
                            if (i >= size)
                            {
                                return output;
                            }
                            //mask = 0x80;

                            for (int k = 0; k < widthX; k++)
                            {
                                pixel1b = input[x + (y * 128)];
                                output[i] += (byte)(pixel1b * mask);
                                x++;
                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;
                            }
                            x -= widthX;
                            y++;
                            i++; //Next byte
                        }
                        x += widthX;
                        y -= widthY;

                    }
                    x = 0;
                    y += widthY;
                }

            return output;
        }



        public static List<byte> import2bpp(byte[] input, int widthX, int widthY, int size)
        {
            size = size / 4;

            List<byte> output = new List<byte>(size);
            for (int j = 0; j < size; j++)
            {
                output.Add(0);
            }

            /* Input is a pixel array. First 8 bytes represent the first output byte */
            byte mask = 0x80;
            byte pixel1b = 0;
            int i = 0;
            int x = 0;
            int y = 0;

            while (i < size) for (int yi = 0; yi < 128 / widthY; yi++)
                {
                    /* Draw a line of tiles (1b) */
                    for (int xi = 0; xi < 128 / widthX; xi++)
                    {

                        /* Draw a tile (1b) */
                        for (int j = 0; j < widthY; j++)
                        {
                            if (i >= size)
                                return output;

                            mask = 0x80;

                            for (int k = 0; k < widthX; k++)
                            {
                                pixel1b = input[(x + y * 128)];
                                output[i] += (byte)((pixel1b & 0x01) * mask);
                                output[i + 1] += (byte)(((pixel1b & 0x02) >> 1) * mask);

                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;

                                x++;
                            }

                            x -= widthX;
                            y++;
                            i += 2; //Next byte
                        }
                        x += widthX;
                        y -= widthY;
                    }
                    x = 0;
                    y += widthY;
                }

            return output;
        }



        public static List<byte> import3bpp(byte[] input, int widthX, int widthY, int size)
        {
            size = (int)(3 * (size / 8));

            List<byte> output = new List<byte>(size);
            for (int j = 0; j < size; j++)
            {
                output.Add(0);
            }

            /* Input is a pixel array. First 8 bytes represent the first output byte */
            byte mask = 0x80;
            byte pixel1b = 0;
            int i = 0;
            int i3 = 0;
            int x = 0;
            int y = 0;

            while (i + (widthY * 2) < size) for (int yi = 0; yi < 128 / widthY; yi++)
                {
                    /* Draw a line of tiles (1b) */
                    for (int xi = 0; xi < 128 / widthX; xi++)
                    {
                        i3 = i + (widthY * 2);

                        /* Draw a tile (1b) */
                        for (int j = 0; j < widthY; j++)
                        {
                            if (i3 >= size)
                                return output;

                            mask = 0x80;

                            for (int k = 0; k < widthX; k++)
                            {
                                pixel1b = input[(x + y * 128)];
                                output[i] += (byte)((pixel1b & 0x01) * mask);
                                output[i + 1] += (byte)(((pixel1b & 0x02) >> 1) * mask);
                                output[i3] += (byte)(((pixel1b & 0x04) >> 2) * mask);

                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;

                                x++;
                            }
                            x -= widthX;
                            y++;
                            i += 2; //Next byte
                            i3++;
                        }
                        i += widthY;
                        x += widthX;
                        y -= widthY;
                    }
                    x = 0;
                    y += widthY;
                }

            return output;
        }
        


        public static List<byte> import4bpp(byte[] input, int widthX, int widthY, int size)
        {
            size = (int)(size / 2);

            List<byte> output = new List<byte>(size);
            for (int j = 0; j < size; j++)
            {
                output.Add(0);
            }

            /* Input is a pixel array. First 8 bytes represent the first output byte */
            byte mask = 0x80;
            byte pixel1b = 0;
            int i = 0;
            int i4 = 0;
            int x = 0;
            int y = 0;

            while (i + (widthY * 2) < size) for (int yi = 0; yi < 128 / widthY; yi++)
                {
                    /* Draw a line of tiles (1b) */
                    for (int xi = 0; xi < 128 / widthX; xi++)
                    {
                        i4 = i + (widthY * 2);

                        /* Draw a tile (1b) */
                        for (int j = 0; j < widthY; j++)
                        {
                            if (i4 >= size)
                                return output;

                            mask = 0x80;

                            for (int k = 0; k < widthX; k++)
                            {
                                pixel1b = input[(x + y * 128)];
                                output[i] += (byte)((pixel1b & 0x01) * mask);
                                output[i + 1] += (byte)(((pixel1b & 0x02) >> 1) * mask);
                                output[i4] += (byte)(((pixel1b & 0x04) >> 2) * mask);
                                output[i4 + 1] += (byte)(((pixel1b & 0x08) >> 3) * mask);

                                mask = (byte)(mask >> 1);
                                if (mask == 0)
                                    mask = 0x80;

                                x++;
                            }
                            x -= widthX;
                            y++;
                            i += 2; //Next byte
                            i4 += 2;
                        }
                        i += widthY * 2;
                        x += widthX;
                        y -= widthY;
                    }
                    x = 0;
                    y += widthY;
                }

            return output;
        }



    }



    public class ManageBMP
    {



        public static void exportBPM(String fileName, Bitmap bitmap, Color[] palette)
        {
            /* Displays an OpenFileDialog so the user can select a res */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG File|*.png";
            saveFileDialog.Title = "Choose a PNG file";
            saveFileDialog.FileName = fileName;

            int bytesToExport = 0;

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    try
                    {
                        bytesToExport = bitmap.Height * bitmap.Width;

                        byte[] byteArray = new byte[bytesToExport];
                        int i = 0;

                        /* Set bytemap */
                        for (int k = 0; k < bitmap.Height; k++)
                        {
                            for (int j = 0; j < bitmap.Width; j++)
                            {
                                byteArray[i++] = BitConverter.GetBytes(Array.FindIndex(palette.ToArray(), x => x == bitmap.GetPixel(j, k)))[0];
                            }
                        }

                        /* Create a new 8bpp Bitmap */
                        Bitmap newBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Open it to edit */
                        System.Drawing.Imaging.BitmapData data = newBitmap.LockBits(
                            new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                            System.Drawing.Imaging.ImageLockMode.WriteOnly,
                            System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                        /* Recover the original values (now lost because of the conversion) */
                        System.Runtime.InteropServices.Marshal.Copy(byteArray, 0, data.Scan0, bytesToExport);
                        newBitmap.UnlockBits(data);

                        /* Set current palette */
                        System.Drawing.Imaging.ColorPalette pal = newBitmap.Palette;

                        for (int j = 0; j < palette.Length ; j++)
                        {
                            pal.Entries[j] = palette[j];
                        }
                        for (int j = palette.Length; j < pal.Entries.Length; j++)
                        {
                            pal.Entries[j] = System.Drawing.Color.Magenta;
                        }
                        newBitmap.Palette = pal;

                        /* Save file */
                        newBitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);

                        newBitmap.Dispose();
                        bitmap.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                    }
                }
            }
            saveFileDialog.Dispose();
            saveFileDialog = null;

        }



        public static List<Byte> importBPM(int nBytesExpected, int bpp) {
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
                        newBytes = importBPM(bitmap, nBytesExpected, bpp);
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

            return newBytes;
        }



        public static List<Byte> importBPM(Bitmap bitmap, int nBytesExpected, int bpp)
        {
            List<Byte> newBytes = new List<Byte>();

            try
            {
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
                if (size == nBytesExpected * 2 || nBytesExpected <= 0)
                {
                    try
                    {
                        switch (bpp)
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
                                MessageBox.Show("Unexpected bpp.", "Error");
                                newBytes = new List<Byte>();
                                break;
                        };
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("The image cannot be transformed: " + e.ToString(), "Error");
                    }
                }
                else
                {
                    MessageBox.Show("It won't work\r\nBPM size is different than expected.\r\n" +
                    size.ToString("X4") + " bytes received and " + (nBytesExpected * 2).ToString("X4") +
                    " expected.", "Info");
                    newBytes = new List<Byte>();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            return newBytes;
        }



    }



}
