namespace FF5e_Text_Editor
{
    partial class Form4
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.radioButtonHeaded = new System.Windows.Forms.RadioButton();
            this.radioButtonUnheaded = new System.Windows.Forms.RadioButton();
            this.comboBoxCompressionType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonRawData = new System.Windows.Forms.RadioButton();
            this.comboBoxBppFormat = new System.Windows.Forms.ComboBox();
            this.radioButtonPNG = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonHeaded
            // 
            this.radioButtonHeaded.AutoSize = true;
            this.radioButtonHeaded.Checked = true;
            this.radioButtonHeaded.Location = new System.Drawing.Point(6, 19);
            this.radioButtonHeaded.Name = "radioButtonHeaded";
            this.radioButtonHeaded.Size = new System.Drawing.Size(63, 17);
            this.radioButtonHeaded.TabIndex = 0;
            this.radioButtonHeaded.TabStop = true;
            this.radioButtonHeaded.Text = "Headed";
            this.radioButtonHeaded.UseVisualStyleBackColor = true;
            this.radioButtonHeaded.CheckedChanged += new System.EventHandler(this.radioButtonHeaded_CheckedChanged);
            // 
            // radioButtonUnheaded
            // 
            this.radioButtonUnheaded.AutoSize = true;
            this.radioButtonUnheaded.Location = new System.Drawing.Point(6, 42);
            this.radioButtonUnheaded.Name = "radioButtonUnheaded";
            this.radioButtonUnheaded.Size = new System.Drawing.Size(75, 17);
            this.radioButtonUnheaded.TabIndex = 1;
            this.radioButtonUnheaded.Text = "Unheaded";
            this.radioButtonUnheaded.UseVisualStyleBackColor = true;
            this.radioButtonUnheaded.CheckedChanged += new System.EventHandler(this.radioButtonUnheaded_CheckedChanged);
            // 
            // comboBoxCompressionType
            // 
            this.comboBoxCompressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompressionType.FormattingEnabled = true;
            this.comboBoxCompressionType.Items.AddRange(new object[] {
            "00 None",
            "01 RLE",
            "02 LZSS"});
            this.comboBoxCompressionType.Location = new System.Drawing.Point(87, 18);
            this.comboBoxCompressionType.Name = "comboBoxCompressionType";
            this.comboBoxCompressionType.Size = new System.Drawing.Size(79, 21);
            this.comboBoxCompressionType.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonHeaded);
            this.groupBox1.Controls.Add(this.comboBoxCompressionType);
            this.groupBox1.Controls.Add(this.radioButtonUnheaded);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compression format";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonRawData);
            this.groupBox2.Controls.Add(this.comboBoxBppFormat);
            this.groupBox2.Controls.Add(this.radioButtonPNG);
            this.groupBox2.Location = new System.Drawing.Point(12, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 68);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data type";
            // 
            // radioButtonRawData
            // 
            this.radioButtonRawData.AutoSize = true;
            this.radioButtonRawData.Checked = true;
            this.radioButtonRawData.Location = new System.Drawing.Point(6, 19);
            this.radioButtonRawData.Name = "radioButtonRawData";
            this.radioButtonRawData.Size = new System.Drawing.Size(71, 17);
            this.radioButtonRawData.TabIndex = 0;
            this.radioButtonRawData.TabStop = true;
            this.radioButtonRawData.Text = "Raw data";
            this.radioButtonRawData.UseVisualStyleBackColor = true;
            this.radioButtonRawData.CheckedChanged += new System.EventHandler(this.radioButtonRawData_CheckedChanged);
            // 
            // comboBoxBppFormat
            // 
            this.comboBoxBppFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBppFormat.FormattingEnabled = true;
            this.comboBoxBppFormat.Items.AddRange(new object[] {
            "1bpp 8x8",
            "2bpp 8x8",
            "3bpp 8x8",
            "4bpp 8x8"});
            this.comboBoxBppFormat.Location = new System.Drawing.Point(87, 41);
            this.comboBoxBppFormat.Name = "comboBoxBppFormat";
            this.comboBoxBppFormat.Size = new System.Drawing.Size(79, 21);
            this.comboBoxBppFormat.TabIndex = 2;
            // 
            // radioButtonPNG
            // 
            this.radioButtonPNG.AutoSize = true;
            this.radioButtonPNG.Location = new System.Drawing.Point(6, 42);
            this.radioButtonPNG.Name = "radioButtonPNG";
            this.radioButtonPNG.Size = new System.Drawing.Size(54, 17);
            this.radioButtonPNG.TabIndex = 1;
            this.radioButtonPNG.Text = "Image";
            this.radioButtonPNG.UseVisualStyleBackColor = true;
            this.radioButtonPNG.CheckedChanged += new System.EventHandler(this.radioButtonPNG_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(112, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 160);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 195);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Criteria";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonHeaded;
        private System.Windows.Forms.RadioButton radioButtonUnheaded;
        private System.Windows.Forms.ComboBox comboBoxCompressionType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonRawData;
        private System.Windows.Forms.ComboBox comboBoxBppFormat;
        private System.Windows.Forms.RadioButton radioButtonPNG;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}