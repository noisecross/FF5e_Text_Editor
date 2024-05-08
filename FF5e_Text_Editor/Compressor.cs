using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FF5e_Text_Editor
{
    public class Compressor
    {



        private static int findInBuffer(List<Byte> input, Byte[] inputBuffer, int writtenData, int initBuffer, int bufferSize)
        {
            int output = -1;
            int condition = 0;

            if (writtenData < input.Count || input.Count < 3)
                return output;

            condition = initBuffer + writtenData - input.Count + 1;

            for (int i = initBuffer; i < condition; i++)
            {
                List<Byte> rangeToCheck = new List<byte>();
                for (int j = 0; j < input.Count; j++)
                {
                    rangeToCheck.Add(inputBuffer[(i + j) & (bufferSize - 1)]);
                }

                if (rangeToCheck.SequenceEqual(input))
                {
                    output = i & (bufferSize - 1);
                    break;
                }
            }

            return output;
        }



        public static List<Byte> compress(List<Byte> input, System.Windows.Forms.ProgressBar progress = null, int initBuffer = 0x07DE, int bufferSize = 0x0800)
        {
            List<Byte> output = new List<Byte>();
            List<Byte> compressionBuffer = new List<Byte>();
            List<bool> bitmap = new List<bool>();
            Byte[] buffer = new Byte[bufferSize];

            if (progress != null)
                progress.Maximum = input.Count;

            /* Compress */
            /* init index 0x07DE */
            /* buffer mask 0x07FF */
            int bufferMask = bufferSize - 1;
            int index = initBuffer;
            int prevCandidate = -1;
            int candidate = -1;
            int writtenData = 0;
            int nextByteToBuffer = -1;
            int compressedBytes = 0;

            /* Optimize compression: begin_with_zeros */
            int firstNonzero = input.FindIndex(x => x != 0);
            if (firstNonzero > 2)
            {
                if (firstNonzero > 34)
                    firstNonzero = 34;

                compressedBytes += compressionBuffer.Count;
                int sizeToRead   = firstNonzero - 3;
                int offsetToRead = 0;
                Byte firstByte   = (Byte)(offsetToRead & 0x00FF);
                Byte secondByte  = (Byte)(sizeToRead + ((offsetToRead >> 3) & 0x00E0));

                output.Add(firstByte);
                output.Add(secondByte);

                bitmap.Add(true);
                input.RemoveRange(0, firstNonzero);

                writtenData += firstNonzero;
                index       += firstNonzero;
                index       &= bufferMask;
            }


            /* Read input buffer */
            while (input.Count > 0 || compressionBuffer.Count > 0)
            {
                if (input.Count > 0)
                {
                    nextByteToBuffer = input[0];
                    compressionBuffer.Add((Byte)nextByteToBuffer);
                    input.RemoveAt(0);
                }
                else
                {
                    nextByteToBuffer = -1;
                }


                if (compressionBuffer.Count > 2 || input.Count == 0)
                {
                    candidate = findInBuffer(compressionBuffer, buffer, writtenData, initBuffer, bufferSize);

                    if (candidate < 0 || compressionBuffer.Count == 34 || input.Count == 0)
                    {
                        if (candidate >= 0)
                        {
                            /* This is candidate */
                            /* Last string or 34 matches in a row */
                            compressedBytes += compressionBuffer.Count;
                            int sizeToRead = compressionBuffer.Count - 3; /* (secondByte & 0x1F) + 3; */
                            int offsetToRead = (candidate) /*& bufferMask*/;  /* (firstByte + (secondByte >> 5) * 0x0100) & 0x07FF;*/
                            Byte firstByte = (Byte)(offsetToRead & 0x00FF);
                            Byte secondByte = (Byte)(sizeToRead + ((offsetToRead >> 3) & 0x00E0));

                            output.Add(firstByte);
                            output.Add(secondByte);

                            compressionBuffer.Clear();
                            candidate = -1;
                            bitmap.Add(true);
                        }
                        else if (prevCandidate < 0)
                        {
                            /* Uncompressed byte */
                            compressedBytes++;
                            output.Add(compressionBuffer[0]);
                            compressionBuffer.RemoveAt(0);
                            bitmap.Add(false);
                        }
                        else
                        {
                            /* Prev one was candidate */
                            compressedBytes += compressionBuffer.Count - 1;
                            int sizeToRead = compressionBuffer.Count - 4;    /* (secondByte & 0x1F) + 3; */
                            int offsetToRead = prevCandidate /* & bufferMask*/; /* (firstByte + (secondByte >> 5) * 0x0100) & 0x07FF;*/
                            Byte firstByte = (Byte)(offsetToRead & 0x00FF);
                            Byte secondByte = (Byte)(sizeToRead + ((offsetToRead >> 3) & 0x00E0));

                            output.Add(firstByte);
                            output.Add(secondByte);

                            compressionBuffer.RemoveRange(0, compressionBuffer.Count - 1);
                            bitmap.Add(true);
                        }
                    }

                    prevCandidate = candidate;
                }


                if (nextByteToBuffer >= 0)
                {
                    buffer[index] = (Byte)nextByteToBuffer;
                    index = (index + 1) & bufferMask;
                    writtenData++;

                    if (writtenData > bufferSize)
                    {
                        initBuffer = (initBuffer + 1) & bufferMask;
                        writtenData = bufferSize;
                    }
                }


                if (progress != null && compressedBytes % 0x40 == 0)
                {
                    progress.Value = compressedBytes;
                }
            }


            index = 0;
            while (index < output.Count)
            {
                int nextGroupSize = 9;

                Byte newMask = 0xFF;
                for (int i = 0; i < 8; i++)
                {
                    newMask = (byte)(newMask >> 1);

                    if (bitmap.Count > 0)
                    {
                        if (bitmap[0])
                        {
                            /* Compressed */
                            nextGroupSize++;
                        }
                        else
                        {
                            newMask += 0x80;
                        }
                        bitmap.RemoveAt(0);
                    }
                    else
                    {
                        newMask += 0x80;
                    }
                }

                output.Insert(index, newMask);
                index += nextGroupSize;
                index &= bufferMask;
            }


            if (progress != null)
                progress.Value = 0;

            return output;
        }



        public static List<Byte> compressType01(List<Byte> input)
        {
            List<Byte> output    = new List<Byte>();
            List<Byte> bufferRep = new List<Byte>();
            List<Byte> bufferNRe = new List<Byte>();

            if (input.Count == 0)
            {
                output.Add(0);
                return output;
            }


            int candidate   = -1;

            foreach (Byte item in input)
            {
                /* Choose list to insert in */
                if (item == candidate)
                {
                    /* Repeated byte */
                    /* Delete the last item from  */
                    if (bufferNRe.Count > 0 && bufferNRe.Last() == item)
                    {
                        bufferNRe.RemoveAt(bufferNRe.Count - 1);
                    }
                    bufferRep.Add(item);

                    /* Send bufferNRe to output if bufferRep > 2 */
                    if (bufferRep.Count > 2 && bufferNRe.Count > 0)
                    {
                        output.Add(BitConverter.GetBytes(bufferNRe.Count)[0]);
                        output.AddRange(bufferNRe);
                        bufferNRe.Clear();
                    }
                }
                else
                {
                    /* Non repeated byte */
                    
                    if (bufferRep.Count < 3 && bufferRep.Count > 0)
                    {
                        /* Insert items in NRe */
                        bufferNRe.AddRange(bufferRep);
                        bufferRep.Clear();
                    }
                    else if (bufferRep.Count > 3)
                    {
                        /* Insert items in output */
                        output.Add(BitConverter.GetBytes(bufferRep.Count + 0x80)[0]);
                        output.Add(bufferRep[0]);
                        bufferRep.Clear();
                    }

                    bufferNRe.Add(item);
                }
                candidate = item;

                /* 0x7F elements reached */
                if (bufferRep.Count == 0x7F)
                {
                    output.Add(BitConverter.GetBytes(bufferRep.Count + 0x80)[0]);
                    output.Add(bufferRep[0]);
                    bufferRep.Clear();
                    candidate = -1;
                }
                else if (bufferNRe.Count >= 0x7F)
                {
                    output.Add(BitConverter.GetBytes(Math.Min(0x7F, bufferNRe.Count))[0]);
                    output.AddRange(bufferNRe.GetRange(0, 0x7F));
                    bufferNRe.RemoveRange(0, 0x0F);
                }
            }

            /* All items read. Flush buffer elements */
            if (bufferNRe.Count > 0)
            {
                /* Add bufferRep to bufferNRe */
                bufferNRe.AddRange(bufferRep);
                bufferRep.Clear();

                /* Write bufferNRe in output */
                output.Add(BitConverter.GetBytes(Math.Min(0x7F, bufferNRe.Count))[0]);
                output.AddRange(bufferNRe.GetRange(0, Math.Min(0x7F, bufferNRe.Count)));
                bufferNRe.RemoveRange(0, Math.Min(0x7F, bufferNRe.Count));

                /* Write bufferNRe again if some elements remains */
                if (bufferNRe.Count > 0)
                {
                    output.Add(BitConverter.GetBytes(bufferNRe.Count)[0]);
                    output.AddRange(bufferNRe);
                    bufferNRe.Clear();
                }
            }
            else if (bufferRep.Count > 0)
            {
                /* Write buffer rep */
                output.Add(BitConverter.GetBytes(bufferRep.Count + 0x80)[0]);
                output.Add(bufferRep[0]);
                bufferRep.Clear();
            }

            /* Return compressed data */
            return output;
        }



        public static List<Byte> uncompress(long address, System.IO.BinaryReader br, int headerOffset, bool unheaded = false, bool silent = false)
        {
            long size = 0;
            return uncompress(address, br, headerOffset, out size, unheaded, silent);
        }



        public static List<Byte> uncompress(long address, System.IO.BinaryReader br, int headerOffset, out long size, bool unheaded = false, bool silent = false)
        {
            Byte compressionType;
            size = 0;

            try
            {
                br.BaseStream.Position = address + headerOffset;

                if (unheaded)
                {
                    /* Unheaded compressed files are decompressed as Type 02 by function C3/0053 */
                    return uncompressType02(br, out size, false, silent);
                }
                else
                {
                    /* Headed compressed can be decompressed in three flavours by function 7F/C00D */
                    compressionType = br.ReadByte();

                    switch (compressionType)
                    {
                        case 00:
                            return uncompressType00(br);
                        case 01:
                            return uncompressType01(br);
                        case 02:
                            return uncompressType02(br, out size, true, silent);
                        default:
                            return new List<Byte>();
                    };

                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error reading the file: " + e.ToString(), "Error");
            }

            return new List<Byte>();
        }



        public static List<Byte> uncompressType00(System.IO.BinaryReader br)
        {
            List<Byte> output = new List<Byte>();

            int remainingBytes = 0;

            try
            {
                remainingBytes = (br.ReadByte() + br.ReadByte() * 0x0100);

                while (remainingBytes-- > 0)
                {
                    output.Add(br.ReadByte());
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
                output.Clear();
            }

            if (output.Count > 0)
            {
                long endData = br.BaseStream.Position;
                System.Windows.Forms.MessageBox.Show("Compression Type 00.\r\nThe compressed data ends at " +
                    (endData - 1).ToString("X6") + "\r\nAddress " + endData.ToString("X6") +
                    " and forward must never be overwritten if this data\r\nis edited and re-imported.", "Info");
            }

            return output;
        }



        public static List<Byte> uncompressType01(System.IO.BinaryReader br)
        {
            List<Byte> output = new List<Byte>();

            Byte remainingBytes = 0;
            Byte nextAction     = 0;
            Byte byteToRepeat   = 0;

            try
            {

                while (true)
                {
                    nextAction = br.ReadByte();

                    if (nextAction == 0)
                    {
                        if (output.Count > 0)
                        {
                            long endData = br.BaseStream.Position;
                            System.Windows.Forms.MessageBox.Show("Compression Type 01.\r\nThe compressed data ends at " +
                                (endData - 1).ToString("X6") + "\r\nAddress " + endData.ToString("X6") +
                                " and forward must never be overwritten if this data\r\nis edited and re-imported.", "Info");
                        } 
                        
                        return output;
                    }
                    else if (nextAction < 0x80)
                    {
                        remainingBytes = nextAction;
                        byteToRepeat = br.ReadByte();
                        while (remainingBytes-- > 0)
                        {
                            output.Add(byteToRepeat);
                        }
                    }
                    else
                    {
                        remainingBytes = (Byte)(nextAction & 0x7F);
                        while (remainingBytes-- > 0)
                        {
                            output.Add(br.ReadByte());
                        }
                    }
                }

            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
                output.Clear();
            }

            return output;
        }



        public static List<Byte> uncompressType02(System.IO.BinaryReader br, out long size, bool headed = false, bool silent = false)
        {
            List<Byte> output = new List<Byte>();

            Byte[] buffer = new Byte[0x0800];
            int index = 0x07DE;
            long initAddress = br.BaseStream.Position;

            try
            {
                int remainingBytes = (br.ReadByte() + br.ReadByte() * 0x0100);

                while (remainingBytes > 0)
                {
                    byte bitmap = br.ReadByte();

                    for (int i = 0; i < 8; i++)
                    {
                        if ((bitmap & 0x01) != 0)
                        {
                            /* Non compressed value */
                            byte nextChar = br.ReadByte();
                            output.Add(nextChar);
                            buffer[index] = nextChar;
                            index = (++index) & 0x07FF;
                            remainingBytes--;
                        }
                        else
                        {
                            /* Compressed value */
                            int firstByte = br.ReadByte();
                            int secondByte = br.ReadByte();
                            int sizeToRead = (secondByte & 0x1F) + 3;
                            int offsetToRead = (firstByte + (secondByte >> 5) * 0x0100) & 0x07FF;

                            for (int j = 0; j < sizeToRead; j++)
                            {
                                buffer[index] = buffer[offsetToRead];
                                output.Add(buffer[offsetToRead]);
                                offsetToRead = (++offsetToRead) & 0x07FF;
                                index = (++index) & 0x07FF;
                            }

                            remainingBytes -= sizeToRead;
                        }

                        bitmap = (byte)(((int)bitmap) >> 1);

                        if (remainingBytes < 1)
                            break;
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Error reading the file: " + err.ToString(), "Error");
                output.Clear();
            }

            long endData = br.BaseStream.Position;
            long extension = endData - initAddress;

            if (headed)
                extension += 1;

            size = extension;

            if (output.Count > 0 && !silent)
            {

                System.Windows.Forms.MessageBox.Show("Compression Type 02.\r\nThe compressed data ends at " +
                    (endData - 1).ToString("X6") + "\r\nAddress " + endData.ToString("X6") +
                    " and forward must never be overwritten if this data\r\nis edited and re-imported.\r\nThe" +
                    " maximum extension of the injecion must be lesser or equal than " + extension.ToString("X4") +
                    ".", "Info");
            }

            return output;
        }



        public static List<Byte> uncompressType02(List<Byte> input)
        {
            List<Byte> output = new List<Byte>();

            Byte[] buffer = new Byte[0x0800];
            int index = 0x07DE;

            try
            {
                int remainingBytes = (input[1] + input[2] * 0x0100);
                input.RemoveRange(0, 3);

                while (remainingBytes > 0)
                {
                    byte bitmap = input[0];
                    input.Remove(0);

                    for (int i = 0; i < 8; i++)
                    {
                        if ((bitmap & 0x01) != 0)
                        {
                            /* Non compressed value */
                            byte nextChar = input[0];
                            input.Remove(0);
                            output.Add(nextChar);
                            buffer[index] = nextChar;
                            index = (++index) & 0x07FF;
                            remainingBytes--;
                        }
                        else
                        {
                            /* Compressed value */
                            int firstByte = input[0];
                            input.Remove(0);
                            int secondByte = input[0];
                            input.Remove(0);
                            int sizeToRead = (secondByte & 0x1F) + 3;
                            int offsetToRead = (firstByte + (secondByte >> 5) * 0x0100) & 0x07FF;

                            for (int j = 0; j < sizeToRead; j++)
                            {
                                buffer[index] = buffer[offsetToRead];
                                output.Add(buffer[offsetToRead]);
                                offsetToRead = (++offsetToRead) & 0x07FF;
                                index = (++index) & 0x07FF;
                            }

                            remainingBytes -= sizeToRead;
                        }

                        bitmap = (byte)(((int)bitmap) >> 1);

                        if (remainingBytes < 1)
                            break;
                    }
                }
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show("Error reading the stream: " + err.ToString(), "Error");
                output.Clear();
            }

            return output;
        }



    }
}
