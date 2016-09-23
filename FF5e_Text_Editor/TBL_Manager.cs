using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FF5e_Text_Editor
{
    public class TBL_Manager
    {
        String[] defaultTBL1bpp = {
            "[00]", "[EOL]", "[Bartz]", "[03]", "[04]", "[05]", "[06]", "[07]", "[08]", "[09]", "[0A]", "[0B]", "[Delay]", "[0D]", "[0E]", "[0F]",
            "[10]", "[11]", "[12]", "[13]", "[14]", "[15]", "[16]", "[Wait]", "[18]", "[19]", "[1A]", "[1B]", "[1C]", "[1D]", "[1E]", "[1F]",
            "A_", "B_", "C_", "D_", "E_", "F_", "G_", "H_", "I_", "J_", "K_", "L_", "M_", "N_", "O_", "P_",
            "Q_", "R_", "S_", "T_", "U_", "V_", "W_", "X_", "Y_", "Z_", "[3A]", "[3B]", "[3C]", "[3D]", "[3E]", "[3F]",
            "[40]", "[41]", "[42]", "[43]", "[44]", "[45]", "[46]", "[47]", "[48]", "[49]", "[4A]", "[4B]", "[4C]", "[4D]", "[4E]", "[4F]",
			"[50]", "[51]", "[52]", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\"m\"", "\"H\"", "\"P\"",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f",
            "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
            "w", "x", "y", "z", "il", "it", "[96]", "li", "ll", "'", "[9A]", ":", "[9C]", ",", "(", ")",
            "/", "!", "?", ".", "ti", "fi", "[A6]", "[A7]", "[A8]", "[A9]", "[AA]", "[AB]", "if", "It", "tl", "ir",
            "tt", "[B1]", "[B2]", "[B3]", "[B4]", "[B5]", "[B6]", "[B7]", "[B8]", "[B9]", "[BA]", "[BB]", "[Key]", "[Shoe]", "[Misc]", "[Hamr]",
            "[Tent]", "[Ribn]", "[Drnk]", "[Suit]", "[Song]", "-", "[Shur]", "...", "[Scrl]", "!", "[Claw]", "?", "[Glov]", "%", "/", ":",
            "|-", "_|", "[_.]", "[_A]", "[_B]", "[_X]", "[_Y]", "[_L]", "[_R]", "[_E]", "[_H]", "[_M]", "[_P]", "[_S]", "[_C]", "[_T]",
            "/\\", "-}", "+", "[Swrd]", "[Whit]", "[Blak]", "[Dimn]", "[Knif]", "[Sper]", "[Axe]", "[Katn]", "[Rod]", "[Staf]", "[Bow]", "[Harp]", "[Whip]",
            "[Bell]", "[Shld]", "[Helm]", "[Armr]", "[Ring]", "[_U]", "[F6]", "=1", "=2", "=3", "=4", "=5", "=6", "=7", "=8", " "};

        String[] defaultTBL2bpp = {
            "[00]", "[EOL]", "[Bartz]", "[03]", "[04]", "[05]", "[06]", "[07]", "[08]", "[09]", "[0A]", "[0B]", "[Delay]", "[0D]", "[0E]", "[0F]",
            "[10]", "[11]", "[12]", "[13]", "[14]", "[15]", "[16]", "[Wait]", "[18]", "[19]", "[1A]", "[1B]", "[1C]", "[1D]", "[1E]", "[1F]",
            "A ", "B ", "C ", "D ", "E ", "F ", "G ", "H ", "I ", "J ", "K ", "L ", "M ", "N ", "O ", "P ",
            "Q ", "R ", "S ", "T ", "U ", "V ", "W ", "X ", "Y ", "Z ", "[3A]", "[3B]", "[3C]", "[3D]", "[3E]", "[3F]",
            "[40]", "[41]", "[42]", "[43]", "[44]", "[45]", "[46]", "[47]", "[48]", "[49]", "[4A]", "[4B]", "[4C]", "[4D]", "[4E]", "[4F]", "[50]",
            "  ", "  ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "\"m\"", "\"H\"", "\"P\"",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f",
            "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
            "w", "x", "y", "z", "il", "it", " ", "li", "ll", "'", "[9A]", ":", "[9C]", ",", "(", ")",
            "/", "!", "?", ".", "ti", "fi", "Bla", "", "pel", "", "'", "[AB]", "if", "It", "tl", "ir",
            "tt", "[B1]", "[B2]", "[B3]", "[B4]", "[B5]", "[B6]", "[B7]", "[B8]", "[B9]", "[BA]", "[BB]", "[Key]", "[Shoe]", "[Misc]", "[Hamr]",
            "[Tent]", "[Ribn]", "[Drnk]", "[Suit]", "[Song]", "-", "[Shur]", "...", "[Scrl]", "!", "[Claw]", "?", "[Glov]", "%", "/", ":",
            "|-", "_|", "[_.]", "[_A]", "[_B]", "[_X]", "[_Y]", "[_L]", "[_R]", "[_E]", "[_H]", "[_M]", "[_P]", "[_S]", "[_C]", "[_T]",
            "/\\", "-]", "+", "[Swrd]", "[Whit]", "[Blak]", "[Dimn]", "[Knif]", "[Sper]", "[Axe]", "[Katn]", "[Rod]", "[Staf]", "[Bow]", "[Harp]", "[Whip]",
            "[Bell]", "[Shld]", "[Helm]", "[Armr]", "[Ring]", "[_U]", "[F6]", "=1", "=2", "=3", "=4", "=5", "=6", "=7", "=8", "[FF]"};
        /*
        String[] defaultTBL = {
                "[00]", "[EOL]", "[Bartz]", "[03]", "[04]", "[05]", "[06]", "[07]", "[08]", "[09]", "[0A]", "[0B]", "[Delay]", "[0D]", "[0E]", "[0F]",
                "[10]", "[11]", "[12]", "[13]", "[14]", "[15]", "[16]", "[Wait]", "[18]", "[19]", "[1A]", "[1B]", "[1C]", "[1D]", "[1E]", "[1F]",
                "[A_]", "[B_]", "[C_]", "[D_]", "[E_]", "[F_]", "[G_]", "[H_]", "[I_]", "[J_]", "[K_]", "[L_]", "[M_]", "[N_]", "[O_]", "[P_]",
                "[Q_]", "[R_]", "[S_]", "[T_]", "[U_]", "[V_]", "[W_]", "[X_]", "[Y_]", "[Z_]", "[3A]", "[3B]", "[3C]", "[3D]", "[3E]", "[3F]",
                "[40]", "[41]", "[42]", "[43]", "[44]", "[45]", "[46]", "[47]", "[48]", "[49]", "[4A]", "[4B]", "[4C]", "[4D]", "[4E]", "[4F]",
                "[50]", "[51]", " ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "[m]", "[v]", "[P]",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f",
                "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
                "w", "x", "y", "z", "Á", "É", "Í", "Ó", "Ú", "á", "é", "í", "ó", "ú", "ñ", "ü",
                "/", "!", "?", "¡", "¿", ".", "[_d]", "[e_]", "...", "gi", "si", ":", ";", ",", "(", ")",
                "il", "it", "li", "ll", "ti", "fi", "if", "lt", "tl", "ir", "ni", "in", "[Key]", "[Shoe]", "[Misc]", "[Hamr]",
                "[Tent]", "[Ribn]", "[Drnk]", "[Suit]", "[Song]", "-", "[Shur]", "...", "[Scrl]", "[!]", "[Claw]", "[?]", "[Glov]", "%", "[/]", "[:]",
                "'", "_|", "[Gour]", "ki", "ij", "pi", "ci", "rt", "lo", "Hi", "Ti", "In", "Bl", "Al", "Fl", "Ul",
                "[<-]", "[->]", "+", "[Swrd]", "[Whit]", "[Blak]", "[Dimn]", "[Knif]", "[Sper]", "[Axe]", "[Katn]", "[Rod]", "[Staf]", "[Bow]", "[Harp]", "[Whip]",
                "[Bell]", "[Shld]", "[Helm]", "[Armr]", "[Ring]", "U", "[F6]", "=1", "=2", "=3", "=4", "=5", "=6", "=7", "=8", "[FF]"};
        //*/

        public bool result;

        public Dictionary<Byte, String> TBL_Reader2bpp   = new Dictionary<Byte, String>();
        public Dictionary<String, Byte> TBL_Injector2bpp = new Dictionary<String, Byte>();

        public Dictionary<Byte, String> TBL_Reader1bpp = new Dictionary<Byte, String>();
        public Dictionary<String, Byte> TBL_Injector1bpp = new Dictionary<String, Byte>();



        public TBL_Manager()
        {
            bool syntaxError = false;
            result = true;

            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default1bpp.tbl", System.IO.FileMode.Open);
                System.IO.StreamReader sr = new System.IO.StreamReader(fs, new UnicodeEncoding());

                syntaxError = loadTBL1bpp(sr);
                sanitizeTBL1bpp();

                sr.Close();
                fs.Close();

            }
            catch (/* System.IO.FileNotFoundException*/ Exception)
            {
                MessageBox.Show("TBL 1bpp not found. Generating default TBL.", "Warning");
                result = createNewTBL1bpp();
                readDefaultTBL1bpp();
            }

            if (syntaxError)
            {
                readDefaultTBL1bpp();
            }


            syntaxError = false;

            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default2bpp.tbl", System.IO.FileMode.Open);
                System.IO.StreamReader sr = new System.IO.StreamReader(fs, new UnicodeEncoding());

                syntaxError = loadTBL2bpp(sr);
                sanitizeTBL2bpp();

                sr.Close();
                fs.Close();

            }
            catch (/* System.IO.FileNotFoundException*/ Exception)
            {
                MessageBox.Show("TBL 2bpp not found. Generating default TBL.", "Warning");
                result = createNewTBL2bpp();
                readDefaultTBL2bpp();
            }

            if (syntaxError)
            {
                readDefaultTBL2bpp();
            }
        }



        public void readCustomTBL2bpp()
        {
            /* Displays an OpenFileDialog so the user can select a res */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TBL File|*.tbl";
            openFileDialog.Title = "Choose a TBL file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    bool syntaxError = false;

                    System.IO.FileStream fs = System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open);
                    System.IO.StreamReader sr = new System.IO.StreamReader(fs, new UnicodeEncoding());

                    try
                    {
                        TBL_Reader2bpp.Clear();
                        TBL_Injector2bpp.Clear();

                        syntaxError = loadTBL2bpp(sr);
                        sanitizeTBL2bpp();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("TBL not found. Generating default TBL.", "Warning");
                        result = createNewTBL2bpp();
                        readDefaultTBL2bpp();
                    }

                    sr.Close();
                    fs.Close();

                    if (syntaxError)
                    {
                        MessageBox.Show("TBL syntax error. Generating default TBL.", "Warning");
                        readDefaultTBL2bpp();
                    }
                }
            }

            sanitizeTBL2bpp();
        }



        public void exportCurrentTBL2bpp()
        {
            /* Displays an SaveFileDialog so the user can select a widths file */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TBL File|*.tbl";
            saveFileDialog.Title = "Choose a TBL file";

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);

                    try
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            String newString = i.ToString("X2") + "=" + TBL_Reader2bpp[(Byte)i];
                            sw.WriteLine(newString);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                    }

                    sw.Close();
                }
            }
        }



        public void setCurrentAsDefaultTBL2bpp()
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default2bpp.tbl", System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, new UnicodeEncoding());

                for (int i = 0; i < 256; i++)
                {
                    String newString = i.ToString("X2") + "=" + TBL_Reader2bpp[(Byte)i];
                    sw.WriteLine(newString);
                }

                sw.Close();
                fs.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
            }
        }



        private bool loadTBL2bpp(System.IO.StreamReader sr)
        {
            bool syntaxError = false;

            while (sr.Peek() >= 0)
            {
                byte value;
                byte nonValue;
                String newString = sr.ReadLine();

                if (newString.Length == 0)
                    continue;

                if (newString.Length < 3)
                {
                    syntaxError = true;
                    break;
                }

                if (!Byte.TryParse(newString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, null, out value))
                {
                    syntaxError = true;
                    break;
                }

                if (!TBL_Injector2bpp.TryGetValue(newString.Substring(3), out nonValue))
                {
                    TBL_Injector2bpp.Add(newString.Substring(3), value);
                }
                TBL_Reader2bpp.Add(value, newString.Substring(3));
            }

            return syntaxError;
        }



        private bool createNewTBL2bpp(){
            bool output = true;

            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default2bpp.tbl", System.IO.FileMode.CreateNew);
                System.IO.StreamWriter sr = new System.IO.StreamWriter(fs, new UnicodeEncoding());

                byte i = 0;
                foreach (String item in defaultTBL2bpp)
                {
                    sr.WriteLine(i++.ToString("X2") + "=" + item);
                }

                sr.Close();
                fs.Close();

            }
            catch (Exception)
            {
                output = false;
            }
            
            return output;
        }



        public void readDefaultTBL2bpp()
        {
            Byte i = 0;
            Byte nonValue;

            TBL_Injector2bpp.Clear();
            TBL_Reader2bpp.Clear();

            foreach (String item in defaultTBL2bpp)
            {
                if (!TBL_Injector2bpp.TryGetValue(item, out nonValue))
                {
                    TBL_Injector2bpp.Add(item, i);
                }
                TBL_Reader2bpp.Add(i, item);
                i++;
            }
        }



        private void sanitizeTBL2bpp()
        {
            String exit;

            /* If a byte is not found set as "[byte]" */
            for (int i = 0; i < 256; i++)
            {
                if (!TBL_Reader2bpp.TryGetValue((Byte)i, out exit))
                {
                    String item = "[" + i.ToString("X2") + "]";
                    TBL_Injector2bpp.Add(item, (Byte)i);
                    TBL_Reader2bpp.Add((Byte)i, item);
                }
            }
        }



        public List<String> getCurrentTBL2bpp()
        {
            List<String> output = new List<string>();

            for (int i = 0; i < 256; i++)
            {
                String newString = i.ToString("X2") + "=" + TBL_Reader2bpp[(Byte)i];
                output.Add(newString);
            }

            return output;
        }



        public void readCustomTBL1bpp()
        {
            /* Displays an OpenFileDialog so the user can select a res */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TBL File|*.tbl";
            openFileDialog.Title = "Choose a TBL file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    bool syntaxError = false;

                    System.IO.FileStream fs = System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open);
                    System.IO.StreamReader sr = new System.IO.StreamReader(fs, new UnicodeEncoding());

                    try
                    {
                        TBL_Reader1bpp.Clear();
                        TBL_Injector1bpp.Clear();

                        syntaxError = loadTBL1bpp(sr);
                        sanitizeTBL1bpp();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("TBL not found. Generating default TBL.", "Warning");
                        result = createNewTBL1bpp();
                        readDefaultTBL1bpp();
                    }

                    sr.Close();
                    fs.Close();

                    if (syntaxError)
                    {
                        MessageBox.Show("TBL syntax error. Generating default TBL.", "Warning");
                        readDefaultTBL1bpp();
                    }
                }
            }

            sanitizeTBL1bpp();
        }



        public void exportCurrentTBL1bpp()
        {
            /* Displays an SaveFileDialog so the user can select a widths file */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TBL File|*.tbl";
            saveFileDialog.Title = "Choose a TBL file";

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);

                    try
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            String newString = i.ToString("X2") + "=" + TBL_Reader1bpp[(Byte)i];
                            sw.WriteLine(newString);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                    }

                    sw.Close();
                }
            }
        }



        public void setCurrentAsDefaultTBL1bpp()
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default1bpp.tbl", System.IO.FileMode.OpenOrCreate);
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, new UnicodeEncoding());

                for (int i = 0; i < 256; i++)
                {
                    String newString = i.ToString("X2") + "=" + TBL_Reader1bpp[(Byte)i];
                    sw.WriteLine(newString);
                }

                sw.Close();
                fs.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing the file: " + e.ToString(), "Error");
            }
        }



        private bool loadTBL1bpp(System.IO.StreamReader sr)
        {
            bool syntaxError = false;

            while (sr.Peek() >= 0)
            {
                byte value;
                byte nonValue;
                String newString = sr.ReadLine();

                if (newString.Length == 0)
                    continue;

                if (newString.Length < 3)
                {
                    syntaxError = true;
                    break;
                }

                if (!Byte.TryParse(newString.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, null, out value))
                {
                    syntaxError = true;
                    break;
                }

                if (!TBL_Injector1bpp.TryGetValue(newString.Substring(3), out nonValue))
                {
                    TBL_Injector1bpp.Add(newString.Substring(3), value);
                }
                TBL_Reader1bpp.Add(value, newString.Substring(3));
            }

            return syntaxError;
        }



        private bool createNewTBL1bpp()
        {
            bool output = true;

            try
            {
                System.IO.FileStream fs = System.IO.File.Open(System.IO.Directory.GetCurrentDirectory() + "/Default1bpp.tbl", System.IO.FileMode.CreateNew);
                System.IO.StreamWriter sr = new System.IO.StreamWriter(fs, new UnicodeEncoding());

                byte i = 0;
                foreach (String item in defaultTBL1bpp)
                {
                    sr.WriteLine(i++.ToString("X2") + "=" + item);
                }

                sr.Close();
                fs.Close();

            }
            catch (Exception)
            {
                output = false;
            }

            return output;
        }



        public void readDefaultTBL1bpp()
        {
            Byte i = 0;
            Byte nonValue;

            TBL_Injector1bpp.Clear();
            TBL_Reader1bpp.Clear();

            foreach (String item in defaultTBL1bpp)
            {
                if (!TBL_Injector1bpp.TryGetValue(item, out nonValue))
                {
                    TBL_Injector1bpp.Add(item, i);
                }
                TBL_Reader1bpp.Add(i, item);
                i++;
            }
        }



        private void sanitizeTBL1bpp()
        {
            String exit;

            /* If a byte is not found set as "[byte]" */
            for (int i = 0; i < 256; i++)
            {
                if (!TBL_Reader1bpp.TryGetValue((Byte)i, out exit))
                {
                    String item = "[" + i.ToString("X2") + "]";
                    TBL_Injector1bpp.Add(item, (Byte)i);
                    TBL_Reader1bpp.Add((Byte)i, item);
                }
            }
        }



        public List<String> getCurrentTBL1bpp()
        {
            List<String> output = new List<string>();

            for (int i = 0; i < 256; i++)
            {
                String newString = i.ToString("X2") + "=" + TBL_Reader1bpp[(Byte)i];
                output.Add(newString);
            }

            return output;
        }
    }
}
