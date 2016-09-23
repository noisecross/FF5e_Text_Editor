/**
* |------------------------------------------|
* | FF5e_Text_editor                         |
* | File: Form4.cs                           |
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
    public partial class Form4 : Form
    {
        public bool isOk       = false;
        public bool isUnheaded = false;
        public bool isImage    = false;
        public int  ctype      = 0;
        public int  bpp        = 1;


        bool export;



        public Form4(bool export)
        {
            this.export = export;
            InitializeComponent();
        }



        private void Form4_Load(object sender, EventArgs e)
        {
            radioButtonHeaded.Checked = true;
            radioButtonRawData.Checked = true;
            comboBoxCompressionType.SelectedIndex = 0;
            comboBoxBppFormat.SelectedIndex = 0;
            comboBoxBppFormat.Enabled = false;

            if (export)
            {
                comboBoxCompressionType.Items.Clear();
                comboBoxCompressionType.Items.Add("Auto detect");
                comboBoxCompressionType.SelectedIndex = 0;
                comboBoxCompressionType.Enabled = false;
            }
        }



        private void buttonOk_Click(object sender, EventArgs e)
        {
            isOk       = true;
            isUnheaded = radioButtonUnheaded.Checked;
            isImage    = radioButtonPNG.Checked;
            ctype      = comboBoxCompressionType.SelectedIndex;
            bpp        = comboBoxBppFormat.SelectedIndex + 1;
            this.Close();
        }



        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void radioButtonUnheaded_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUnheaded.Checked)
            {
                comboBoxCompressionType.Enabled = false;
            }
        }

        private void radioButtonHeaded_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHeaded.Checked && !export)
            {
                comboBoxCompressionType.Enabled = true;
            }
        }

        private void radioButtonRawData_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRawData.Checked)
            {
                comboBoxBppFormat.Enabled = false;
            }
        }

        private void radioButtonPNG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPNG.Checked)
            {
                comboBoxBppFormat.Enabled = true;
            }
        }



    }
}
