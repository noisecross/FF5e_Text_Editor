namespace FF5e_Text_Editor
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.listViewPreviews = new System.Windows.Forms.ListView();
            this.Column00 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column01 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonInject = new System.Windows.Forms.Button();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxNewText = new System.Windows.Forms.TextBox();
            this.textBoxHex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewPreviews
            // 
            this.listViewPreviews.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPreviews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column00,
            this.Column01,
            this.Column02});
            this.listViewPreviews.FullRowSelect = true;
            this.listViewPreviews.GridLines = true;
            this.listViewPreviews.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPreviews.Location = new System.Drawing.Point(12, 12);
            this.listViewPreviews.MultiSelect = false;
            this.listViewPreviews.Name = "listViewPreviews";
            this.listViewPreviews.Size = new System.Drawing.Size(610, 303);
            this.listViewPreviews.TabIndex = 0;
            this.listViewPreviews.UseCompatibleStateImageBehavior = false;
            this.listViewPreviews.View = System.Windows.Forms.View.Details;
            this.listViewPreviews.SelectedIndexChanged += new System.EventHandler(this.listViewPreviews_SelectedIndexChanged);
            // 
            // Column00
            // 
            this.Column00.Text = "In-game preview";
            this.Column00.Width = 200;
            // 
            // Column01
            // 
            this.Column01.Text = "Bytes";
            this.Column01.Width = 175;
            // 
            // Column02
            // 
            this.Column02.Text = "Text (TBL translated)";
            this.Column02.Width = 231;
            // 
            // buttonInject
            // 
            this.buttonInject.Location = new System.Drawing.Point(562, 321);
            this.buttonInject.Name = "buttonInject";
            this.buttonInject.Size = new System.Drawing.Size(60, 23);
            this.buttonInject.TabIndex = 1;
            this.buttonInject.Text = "Inject";
            this.buttonInject.UseVisualStyleBackColor = true;
            this.buttonInject.Click += new System.EventHandler(this.buttonInject_Click);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(12, 323);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(80, 20);
            this.textBoxAddress.TabIndex = 2;
            // 
            // textBoxNewText
            // 
            this.textBoxNewText.Location = new System.Drawing.Point(395, 323);
            this.textBoxNewText.Name = "textBoxNewText";
            this.textBoxNewText.Size = new System.Drawing.Size(161, 20);
            this.textBoxNewText.TabIndex = 3;
            this.textBoxNewText.TextChanged += new System.EventHandler(this.textBoxNewText_TextChanged);
            // 
            // textBoxHex
            // 
            this.textBoxHex.Location = new System.Drawing.Point(98, 323);
            this.textBoxHex.Name = "textBoxHex";
            this.textBoxHex.ReadOnly = true;
            this.textBoxHex.Size = new System.Drawing.Size(291, 20);
            this.textBoxHex.TabIndex = 4;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 356);
            this.Controls.Add(this.textBoxHex);
            this.Controls.Add(this.textBoxNewText);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.buttonInject);
            this.Controls.Add(this.listViewPreviews);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "List previewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPreviews;
        private System.Windows.Forms.ColumnHeader Column00;
        private System.Windows.Forms.ColumnHeader Column01;
        private System.Windows.Forms.ColumnHeader Column02;
        private System.Windows.Forms.Button buttonInject;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxNewText;
        private System.Windows.Forms.TextBox textBoxHex;
    }
}