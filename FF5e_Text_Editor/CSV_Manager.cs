using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace FF5e_Text_Editor
{
    public class CSV_Manager
    {
        public static void exportCSV(String fileName, List<String> listString){
            /* Displays an OpenFileDialog so the user can select a res */
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter   = "CSV File|*.csv";
            saveFileDialog.Title    = "Choose a CSV file";
            saveFileDialog.FileName = fileName;

            /* Show the Dialog */
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, new UnicodeEncoding());

                    try
                    {
                        foreach (String item in listString)
                        {
                            /*
                            string newItem = "";
                            
                            for (int i = 0; i < columnsToExport; i++)
                            {
                                string newSubstring = (item.SubItems[i].Text.Replace("\"", "\"\""));;
                                newItem += "\"" + newSubstring + "\"\t";
                            }
                             
                            sw.WriteLine(newItem);
                            */
                            sw.WriteLine(item);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error writing the file: " + error.ToString(), "Error");
                    }

                    sw.Close();
                    fs.Close();
                }
            }
            saveFileDialog.Dispose();
            saveFileDialog = null;
        }


        public static List<String> openFixedSizedTableCSV()
        {
            List<String> output = new List<String>();

            /* Displays an OpenFileDialog so the user can select a res */
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV File|*.csv";
            openFileDialog.Title = "Choose a CSV file";

            /* Show the Dialog */
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    System.IO.FileStream fs = new System.IO.FileStream(openFileDialog.FileName,
                        System.IO.FileMode.Open,
                        System.IO.FileAccess.Read,
                        System.IO.FileShare.Read);
                    //System.IO.BinaryReader br = new System.IO.BinaryReader(sr);
                    //System.IO.FileStream fs = (System.IO.FileStream)openFileDialog.OpenFile();
                    System.IO.StreamReader sr = new System.IO.StreamReader(fs, new UnicodeEncoding());
                    
                    try
                    {
                        while (sr.Peek() >= 0)
                        {
                            String newString = sr.ReadLine()/*.Replace(" de ","[A6][A7]")*/;

                            if (newString.Length > 0 && newString[0] == '\"')
                            {
                                while (sr.Peek() >= 0)
                                {
                                    String nextString = sr.ReadLine();
                                    newString += "[01]" + nextString;
                                    if (nextString.Length > 0 && nextString[nextString.Length - 1] == '\"')
                                    {
                                        break;
                                    }
                                }

                                newString = newString.Substring(1, newString.Length - 2);
                                newString = newString.Replace("\r\n", "[52]");
                                newString = newString.Replace("\r",   "[52]");
                                newString = newString.Replace("\n",   "[52]");
                            }

                            output.Add(newString);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error reading the file: " + error.ToString(), "Error");
                        output.Clear();
                    }

                    sr.Close();
                    fs.Close();
                }
            }
            openFileDialog.Dispose();
            openFileDialog = null;

            return output;
        }
    }
}
