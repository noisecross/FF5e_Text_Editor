/**
* |------------------------------------------|
* | FF5e_Text_editor                         |
* | File: Form3.cs                           |
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
    public partial class Form3 : Form
    {
        public bool     ok = false;
        public String text = "";

        public Form3(String input)
        {
            InitializeComponent();
            textBoxSpeech.Text = input;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ok = true;
            text = textBoxSpeech.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
