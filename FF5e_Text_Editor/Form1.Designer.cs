namespace FF5e_Text_Editor
{
    partial class Form1
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

        public partial class BufferPanel : System.Windows.Forms.Panel
        {
            public BufferPanel()
            {
                SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
                UpdateStyles();
            }
        }

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("00");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "10",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("20");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("30");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("40");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("50");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("60");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("70");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("80");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("90");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("A0");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("B0");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("C0");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("D0");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem("E0");
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("F0");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonNamingDeleteABC = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.buttonCSVImportNaming = new System.Windows.Forms.Button();
            this.buttonCSVExportNamingTemplate = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelMonsters = new System.Windows.Forms.Label();
            this.labelConcepts = new System.Windows.Forms.Label();
            this.buttonCSVImportConcepts = new System.Windows.Forms.Button();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.buttonCSVImportCharacters = new System.Windows.Forms.Button();
            this.labelItems = new System.Windows.Forms.Label();
            this.buttonCSVImportItems = new System.Windows.Forms.Button();
            this.labelCommands = new System.Windows.Forms.Label();
            this.buttonCSVImportCommands = new System.Windows.Forms.Button();
            this.labelSkillsB = new System.Windows.Forms.Label();
            this.buttonCSVImportSkillsB = new System.Windows.Forms.Button();
            this.labelSkillsM = new System.Windows.Forms.Label();
            this.buttonCSVImportSkillsM = new System.Windows.Forms.Button();
            this.labelMonAttacks = new System.Windows.Forms.Label();
            this.buttonCSVImportMonsterAttacks = new System.Windows.Forms.Button();
            this.buttonCSVExportMonsters = new System.Windows.Forms.Button();
            this.buttonCSVImportMonsters = new System.Windows.Forms.Button();
            this.buttonCSVExportMonsterAttacks = new System.Windows.Forms.Button();
            this.buttonCSVExportConcepts = new System.Windows.Forms.Button();
            this.buttonCSVExportSkillsM = new System.Windows.Forms.Button();
            this.buttonCSVExportCharacters = new System.Windows.Forms.Button();
            this.buttonCSVExportSkillsB = new System.Windows.Forms.Button();
            this.buttonCSVExportItems = new System.Windows.Forms.Button();
            this.buttonCSVExportCommands = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMiscTextSell = new System.Windows.Forms.Button();
            this.textBoxMiscTextSell = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBoxMiscTextExp = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextMP = new System.Windows.Forms.TextBox();
            this.buttonMiscTextHpMpExp = new System.Windows.Forms.Button();
            this.textBoxMiscTextHP = new System.Windows.Forms.TextBox();
            this.buttonMiscTextUsesMP = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxMiscTextUsesMP = new System.Windows.Forms.TextBox();
            this.buttonMiscTextInjectL = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectLv = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.textBoxMiscTextL = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextLv = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.buttonMiscTextInjectPause = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectAny = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectMaster = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectEqp = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectDef = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectDefense = new System.Windows.Forms.Button();
            this.buttonMiscTextInjectEmpty = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxMiscTextPause = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextAny = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextMaster = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextEmpty = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextEqp = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextDef = new System.Windows.Forms.TextBox();
            this.textBoxMiscTextDefense = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonEditSpeech = new System.Windows.Forms.Button();
            this.labelSubsSpeech = new System.Windows.Forms.Label();
            this.comboBoxSubSpeech = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.numericUpDownIdSpeech = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.panelMainSpeech = new FF5e_Text_Editor.Form1.BufferPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonCSVExportSpeech = new System.Windows.Forms.Button();
            this.buttonCSVImportSpeech = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCSVExportBattleSpeech = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonCSVImportConceptsV = new System.Windows.Forms.Button();
            this.labelBattleMsg = new System.Windows.Forms.Label();
            this.buttonCSVImportLocations = new System.Windows.Forms.Button();
            this.labelBattleSpeech = new System.Windows.Forms.Label();
            this.buttonCSVImportJobsDesc = new System.Windows.Forms.Button();
            this.buttonCSVExportBattleMsg = new System.Windows.Forms.Button();
            this.buttonCSVExportConceptsV = new System.Windows.Forms.Button();
            this.buttonCSVImportItempDesc = new System.Windows.Forms.Button();
            this.buttonCSVExportLocations = new System.Windows.Forms.Button();
            this.buttonCSVExportItempDesc = new System.Windows.Forms.Button();
            this.buttonCSVExportJobsDesc = new System.Windows.Forms.Button();
            this.buttonCSVImportBattleMsg = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonCSVImportBattleSpeech = new System.Windows.Forms.Button();
            this.labelLocations = new System.Windows.Forms.Label();
            this.labelConceptsVar = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox1bppFont = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.buttonLoadWidths = new System.Windows.Forms.Button();
            this.buttonSaveWidths = new System.Windows.Forms.Button();
            this.buttonUpdateWidths = new System.Windows.Forms.Button();
            this.listViewTextWidths = new System.Windows.Forms.ListView();
            this.FirstColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader00 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader01 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader03 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader04 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader05 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader06 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader07 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader08 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader09 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0A = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0B = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0C = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0D = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0E = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader0F = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelMuteSpell = new FF5e_Text_Editor.Form1.BufferPanel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.buttonMuteExport = new System.Windows.Forms.Button();
            this.buttonMuteImport = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonCSVImportPOL = new System.Windows.Forms.Button();
            this.buttonCSVExportPOL = new System.Windows.Forms.Button();
            this.buttonSynchroIndexInject = new System.Windows.Forms.Button();
            this.textBoxSynchroIndexInject = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.buttonOtherFontExport = new System.Windows.Forms.Button();
            this.buttonOtherFontImport = new System.Windows.Forms.Button();
            this.buttonDamageFontExport = new System.Windows.Forms.Button();
            this.buttonDamageFontImport = new System.Windows.Forms.Button();
            this.button1bppFontExport = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.button1bppFontImport = new System.Windows.Forms.Button();
            this.button2bppFontImport = new System.Windows.Forms.Button();
            this.button2bppFontExport = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.buttonPoemOfLightFontExport = new System.Windows.Forms.Button();
            this.buttonPoemOfLightFontImport = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2bpp = new FF5e_Text_Editor.Form1.BufferPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonSRAM = new System.Windows.Forms.Button();
            this.buttonEveryDraw = new System.Windows.Forms.Button();
            this.comboBoxWinGrouping = new System.Windows.Forms.ComboBox();
            this.buttonWindowsCtrl = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonWindowsInfo = new System.Windows.Forms.Button();
            this.textBoxWindowInfoAddress = new System.Windows.Forms.TextBox();
            this.textBoxWindowInfo = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.checkBoxDisplayW2 = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplayW1 = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplayW0 = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.textBoxWindowFunction = new System.Windows.Forms.TextBox();
            this.textBoxWindowAddress = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownWindowT = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowH = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowW = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownWindowX = new System.Windows.Forms.NumericUpDown();
            this.labelWindowFunction = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewWindows = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxWindowsMenu = new System.Windows.Forms.ComboBox();
            this.panelWindowDisplay = new FF5e_Text_Editor.Form1.BufferPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonExportGenericCompress = new System.Windows.Forms.Button();
            this.progressBarCompress = new System.Windows.Forms.ProgressBar();
            this.buttonCSVImportStaffFont = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.buttonCSVExportStaffFont = new System.Windows.Forms.Button();
            this.buttonImageImportGenericCompress = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.textBoxCompressedPlace = new System.Windows.Forms.TextBox();
            this.buttonImageImportTheEnd = new System.Windows.Forms.Button();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.textBoxCompressedLimit = new System.Windows.Forms.TextBox();
            this.buttonImageExportTheEnd = new System.Windows.Forms.Button();
            this.buttonImageImportDragon = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.buttonImageExportDragon = new System.Windows.Forms.Button();
            this.buttonCSVImportCredits = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.buttonCSVExportCredits = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.buttonCSVExportStaff = new System.Windows.Forms.Button();
            this.buttonCSVImportStaff = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonStoresMenuEnlarge = new System.Windows.Forms.Button();
            this.comboBoxStoresMenuEnlarge = new System.Windows.Forms.ComboBox();
            this.buttonMagicMenuEnlarge = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonMenuEnlarge = new System.Windows.Forms.Button();
            this.comboBoxMenuEnlarge = new System.Windows.Forms.ComboBox();
            this.comboBoxMagicMenuEnlarge = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBugFixChecksum = new System.Windows.Forms.Button();
            this.buttonBugFixAll = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.buttonBugBerserkChicen = new System.Windows.Forms.Button();
            this.buttonBugCatchMonsterDisplay = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.buttonBugObserve = new System.Windows.Forms.Button();
            this.buttonBugCatchMonster = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.buttonBugBlueMageSprite = new System.Windows.Forms.Button();
            this.buttonBugKissOfBlessing = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.buttonBugPowerDrink = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSMCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTBLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTBL1bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTBL2bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTBL1bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportTBL2bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultTBL1bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDefaultTBL2bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.displayCurrentTBL1bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayCurrentTBL2bppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFonts = new FF5e_Text_Editor.Form1.BufferPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.checkBoxShowWidths = new System.Windows.Forms.CheckBox();
            this.buttonDummy = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdSpeech)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowX)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 375);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fixed sized tables";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonNamingDeleteABC);
            this.groupBox5.Controls.Add(this.label43);
            this.groupBox5.Controls.Add(this.buttonCSVImportNaming);
            this.groupBox5.Controls.Add(this.buttonCSVExportNamingTemplate);
            this.groupBox5.Controls.Add(this.label42);
            this.groupBox5.Location = new System.Drawing.Point(6, 263);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(249, 80);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Naming screen";
            // 
            // buttonNamingDeleteABC
            // 
            this.buttonNamingDeleteABC.Location = new System.Drawing.Point(151, 51);
            this.buttonNamingDeleteABC.Name = "buttonNamingDeleteABC";
            this.buttonNamingDeleteABC.Size = new System.Drawing.Size(75, 23);
            this.buttonNamingDeleteABC.TabIndex = 38;
            this.buttonNamingDeleteABC.Text = "Delete";
            this.buttonNamingDeleteABC.UseVisualStyleBackColor = true;
            this.buttonNamingDeleteABC.Click += new System.EventHandler(this.buttonNamingDeleteABC_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 56);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(123, 13);
            this.label43.TabIndex = 37;
            this.label43.Text = "Delete ABC/abc buttons";
            // 
            // buttonCSVImportNaming
            // 
            this.buttonCSVImportNaming.Location = new System.Drawing.Point(163, 19);
            this.buttonCSVImportNaming.Name = "buttonCSVImportNaming";
            this.buttonCSVImportNaming.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportNaming.TabIndex = 36;
            this.buttonCSVImportNaming.Text = "Inject";
            this.buttonCSVImportNaming.UseVisualStyleBackColor = true;
            this.buttonCSVImportNaming.Click += new System.EventHandler(this.buttonCSVImportNaming_Click);
            // 
            // buttonCSVExportNamingTemplate
            // 
            this.buttonCSVExportNamingTemplate.Location = new System.Drawing.Point(82, 19);
            this.buttonCSVExportNamingTemplate.Name = "buttonCSVExportNamingTemplate";
            this.buttonCSVExportNamingTemplate.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportNamingTemplate.TabIndex = 35;
            this.buttonCSVExportNamingTemplate.Text = "Get template";
            this.buttonCSVExportNamingTemplate.UseVisualStyleBackColor = true;
            this.buttonCSVExportNamingTemplate.Click += new System.EventHandler(this.buttonCSVExportNamingTemplate_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(43, 13);
            this.label42.TabIndex = 34;
            this.label42.Text = "Naming";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelMonsters);
            this.groupBox2.Controls.Add(this.labelConcepts);
            this.groupBox2.Controls.Add(this.buttonCSVImportConcepts);
            this.groupBox2.Controls.Add(this.labelCharacters);
            this.groupBox2.Controls.Add(this.buttonCSVImportCharacters);
            this.groupBox2.Controls.Add(this.labelItems);
            this.groupBox2.Controls.Add(this.buttonCSVImportItems);
            this.groupBox2.Controls.Add(this.labelCommands);
            this.groupBox2.Controls.Add(this.buttonCSVImportCommands);
            this.groupBox2.Controls.Add(this.labelSkillsB);
            this.groupBox2.Controls.Add(this.buttonCSVImportSkillsB);
            this.groupBox2.Controls.Add(this.labelSkillsM);
            this.groupBox2.Controls.Add(this.buttonCSVImportSkillsM);
            this.groupBox2.Controls.Add(this.labelMonAttacks);
            this.groupBox2.Controls.Add(this.buttonCSVImportMonsterAttacks);
            this.groupBox2.Controls.Add(this.buttonCSVExportMonsters);
            this.groupBox2.Controls.Add(this.buttonCSVImportMonsters);
            this.groupBox2.Controls.Add(this.buttonCSVExportMonsterAttacks);
            this.groupBox2.Controls.Add(this.buttonCSVExportConcepts);
            this.groupBox2.Controls.Add(this.buttonCSVExportSkillsM);
            this.groupBox2.Controls.Add(this.buttonCSVExportCharacters);
            this.groupBox2.Controls.Add(this.buttonCSVExportSkillsB);
            this.groupBox2.Controls.Add(this.buttonCSVExportItems);
            this.groupBox2.Controls.Add(this.buttonCSVExportCommands);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 251);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fixed sized tables";
            // 
            // labelMonsters
            // 
            this.labelMonsters.AutoSize = true;
            this.labelMonsters.Location = new System.Drawing.Point(6, 24);
            this.labelMonsters.Name = "labelMonsters";
            this.labelMonsters.Size = new System.Drawing.Size(50, 13);
            this.labelMonsters.TabIndex = 10;
            this.labelMonsters.Text = "Monsters";
            this.labelMonsters.Click += new System.EventHandler(this.labelMonsters_Click);
            // 
            // labelConcepts
            // 
            this.labelConcepts.AutoSize = true;
            this.labelConcepts.Location = new System.Drawing.Point(6, 227);
            this.labelConcepts.Name = "labelConcepts";
            this.labelConcepts.Size = new System.Drawing.Size(52, 13);
            this.labelConcepts.TabIndex = 17;
            this.labelConcepts.Text = "Concepts";
            this.labelConcepts.Click += new System.EventHandler(this.labelConcepts_Click);
            // 
            // buttonCSVImportConcepts
            // 
            this.buttonCSVImportConcepts.Location = new System.Drawing.Point(163, 222);
            this.buttonCSVImportConcepts.Name = "buttonCSVImportConcepts";
            this.buttonCSVImportConcepts.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportConcepts.TabIndex = 33;
            this.buttonCSVImportConcepts.Text = "Inject";
            this.buttonCSVImportConcepts.UseVisualStyleBackColor = true;
            this.buttonCSVImportConcepts.Click += new System.EventHandler(this.buttonCSVImportConcepts_Click);
            // 
            // labelCharacters
            // 
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.Location = new System.Drawing.Point(6, 198);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(58, 13);
            this.labelCharacters.TabIndex = 16;
            this.labelCharacters.Text = "Characters";
            this.labelCharacters.Click += new System.EventHandler(this.labelCharacters_Click);
            // 
            // buttonCSVImportCharacters
            // 
            this.buttonCSVImportCharacters.Location = new System.Drawing.Point(163, 193);
            this.buttonCSVImportCharacters.Name = "buttonCSVImportCharacters";
            this.buttonCSVImportCharacters.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportCharacters.TabIndex = 32;
            this.buttonCSVImportCharacters.Text = "Inject";
            this.buttonCSVImportCharacters.UseVisualStyleBackColor = true;
            this.buttonCSVImportCharacters.Click += new System.EventHandler(this.buttonCSVImportCharacters_Click);
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.Location = new System.Drawing.Point(6, 169);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(32, 13);
            this.labelItems.TabIndex = 15;
            this.labelItems.Text = "Items";
            this.labelItems.Click += new System.EventHandler(this.labelItems_Click);
            // 
            // buttonCSVImportItems
            // 
            this.buttonCSVImportItems.Location = new System.Drawing.Point(163, 164);
            this.buttonCSVImportItems.Name = "buttonCSVImportItems";
            this.buttonCSVImportItems.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportItems.TabIndex = 31;
            this.buttonCSVImportItems.Text = "Inject";
            this.buttonCSVImportItems.UseVisualStyleBackColor = true;
            this.buttonCSVImportItems.Click += new System.EventHandler(this.buttonCSVImportItems_Click);
            // 
            // labelCommands
            // 
            this.labelCommands.AutoSize = true;
            this.labelCommands.Location = new System.Drawing.Point(6, 140);
            this.labelCommands.Name = "labelCommands";
            this.labelCommands.Size = new System.Drawing.Size(59, 13);
            this.labelCommands.TabIndex = 14;
            this.labelCommands.Text = "Commands";
            this.labelCommands.Click += new System.EventHandler(this.labelCommands_Click);
            // 
            // buttonCSVImportCommands
            // 
            this.buttonCSVImportCommands.Location = new System.Drawing.Point(163, 135);
            this.buttonCSVImportCommands.Name = "buttonCSVImportCommands";
            this.buttonCSVImportCommands.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportCommands.TabIndex = 30;
            this.buttonCSVImportCommands.Text = "Inject";
            this.buttonCSVImportCommands.UseVisualStyleBackColor = true;
            this.buttonCSVImportCommands.Click += new System.EventHandler(this.buttonCSVImportCommands_Click);
            // 
            // labelSkillsB
            // 
            this.labelSkillsB.AutoSize = true;
            this.labelSkillsB.Location = new System.Drawing.Point(6, 111);
            this.labelSkillsB.Name = "labelSkillsB";
            this.labelSkillsB.Size = new System.Drawing.Size(44, 13);
            this.labelSkillsB.TabIndex = 13;
            this.labelSkillsB.Text = "Skills(B)";
            this.labelSkillsB.Click += new System.EventHandler(this.labelSkillsB_Click);
            // 
            // buttonCSVImportSkillsB
            // 
            this.buttonCSVImportSkillsB.Location = new System.Drawing.Point(163, 106);
            this.buttonCSVImportSkillsB.Name = "buttonCSVImportSkillsB";
            this.buttonCSVImportSkillsB.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportSkillsB.TabIndex = 29;
            this.buttonCSVImportSkillsB.Text = "Inject";
            this.buttonCSVImportSkillsB.UseVisualStyleBackColor = true;
            this.buttonCSVImportSkillsB.Click += new System.EventHandler(this.buttonCSVImportSkillsB_Click);
            // 
            // labelSkillsM
            // 
            this.labelSkillsM.AutoSize = true;
            this.labelSkillsM.Location = new System.Drawing.Point(6, 82);
            this.labelSkillsM.Name = "labelSkillsM";
            this.labelSkillsM.Size = new System.Drawing.Size(46, 13);
            this.labelSkillsM.TabIndex = 12;
            this.labelSkillsM.Text = "Skills(M)";
            this.labelSkillsM.Click += new System.EventHandler(this.labelSkillsM_Click);
            // 
            // buttonCSVImportSkillsM
            // 
            this.buttonCSVImportSkillsM.Location = new System.Drawing.Point(163, 77);
            this.buttonCSVImportSkillsM.Name = "buttonCSVImportSkillsM";
            this.buttonCSVImportSkillsM.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportSkillsM.TabIndex = 28;
            this.buttonCSVImportSkillsM.Text = "Inject";
            this.buttonCSVImportSkillsM.UseVisualStyleBackColor = true;
            this.buttonCSVImportSkillsM.Click += new System.EventHandler(this.buttonCSVImportSkillsM_Click);
            // 
            // labelMonAttacks
            // 
            this.labelMonAttacks.AutoSize = true;
            this.labelMonAttacks.Location = new System.Drawing.Point(6, 53);
            this.labelMonAttacks.Name = "labelMonAttacks";
            this.labelMonAttacks.Size = new System.Drawing.Size(70, 13);
            this.labelMonAttacks.TabIndex = 11;
            this.labelMonAttacks.Text = "Mon. Attacks";
            this.labelMonAttacks.Click += new System.EventHandler(this.labelMonAttacks_Click);
            // 
            // buttonCSVImportMonsterAttacks
            // 
            this.buttonCSVImportMonsterAttacks.Location = new System.Drawing.Point(163, 48);
            this.buttonCSVImportMonsterAttacks.Name = "buttonCSVImportMonsterAttacks";
            this.buttonCSVImportMonsterAttacks.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportMonsterAttacks.TabIndex = 27;
            this.buttonCSVImportMonsterAttacks.Text = "Inject";
            this.buttonCSVImportMonsterAttacks.UseVisualStyleBackColor = true;
            this.buttonCSVImportMonsterAttacks.Click += new System.EventHandler(this.buttonCSVImportMonsterAttacks_Click);
            // 
            // buttonCSVExportMonsters
            // 
            this.buttonCSVExportMonsters.Location = new System.Drawing.Point(82, 19);
            this.buttonCSVExportMonsters.Name = "buttonCSVExportMonsters";
            this.buttonCSVExportMonsters.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportMonsters.TabIndex = 18;
            this.buttonCSVExportMonsters.Text = "Get template";
            this.buttonCSVExportMonsters.UseVisualStyleBackColor = true;
            this.buttonCSVExportMonsters.Click += new System.EventHandler(this.buttonCSVExportMonsters_Click);
            // 
            // buttonCSVImportMonsters
            // 
            this.buttonCSVImportMonsters.Location = new System.Drawing.Point(163, 19);
            this.buttonCSVImportMonsters.Name = "buttonCSVImportMonsters";
            this.buttonCSVImportMonsters.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportMonsters.TabIndex = 26;
            this.buttonCSVImportMonsters.Text = "Inject";
            this.buttonCSVImportMonsters.UseVisualStyleBackColor = true;
            this.buttonCSVImportMonsters.Click += new System.EventHandler(this.buttonCSVImportMonsters_Click);
            // 
            // buttonCSVExportMonsterAttacks
            // 
            this.buttonCSVExportMonsterAttacks.Location = new System.Drawing.Point(82, 48);
            this.buttonCSVExportMonsterAttacks.Name = "buttonCSVExportMonsterAttacks";
            this.buttonCSVExportMonsterAttacks.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportMonsterAttacks.TabIndex = 19;
            this.buttonCSVExportMonsterAttacks.Text = "Get template";
            this.buttonCSVExportMonsterAttacks.UseVisualStyleBackColor = true;
            this.buttonCSVExportMonsterAttacks.Click += new System.EventHandler(this.buttonCSVExportMonsterAttacks_Click);
            // 
            // buttonCSVExportConcepts
            // 
            this.buttonCSVExportConcepts.Location = new System.Drawing.Point(82, 222);
            this.buttonCSVExportConcepts.Name = "buttonCSVExportConcepts";
            this.buttonCSVExportConcepts.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportConcepts.TabIndex = 25;
            this.buttonCSVExportConcepts.Text = "Get template";
            this.buttonCSVExportConcepts.UseVisualStyleBackColor = true;
            this.buttonCSVExportConcepts.Click += new System.EventHandler(this.buttonCSVExportConcepts_Click);
            // 
            // buttonCSVExportSkillsM
            // 
            this.buttonCSVExportSkillsM.Location = new System.Drawing.Point(82, 77);
            this.buttonCSVExportSkillsM.Name = "buttonCSVExportSkillsM";
            this.buttonCSVExportSkillsM.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportSkillsM.TabIndex = 20;
            this.buttonCSVExportSkillsM.Text = "Get template";
            this.buttonCSVExportSkillsM.UseVisualStyleBackColor = true;
            this.buttonCSVExportSkillsM.Click += new System.EventHandler(this.buttonCSVExportSkillsM_Click);
            // 
            // buttonCSVExportCharacters
            // 
            this.buttonCSVExportCharacters.Location = new System.Drawing.Point(82, 193);
            this.buttonCSVExportCharacters.Name = "buttonCSVExportCharacters";
            this.buttonCSVExportCharacters.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportCharacters.TabIndex = 24;
            this.buttonCSVExportCharacters.Text = "Get template";
            this.buttonCSVExportCharacters.UseVisualStyleBackColor = true;
            this.buttonCSVExportCharacters.Click += new System.EventHandler(this.buttonCSVExportCharacters_Click);
            // 
            // buttonCSVExportSkillsB
            // 
            this.buttonCSVExportSkillsB.Location = new System.Drawing.Point(82, 106);
            this.buttonCSVExportSkillsB.Name = "buttonCSVExportSkillsB";
            this.buttonCSVExportSkillsB.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportSkillsB.TabIndex = 21;
            this.buttonCSVExportSkillsB.Text = "Get template";
            this.buttonCSVExportSkillsB.UseVisualStyleBackColor = true;
            this.buttonCSVExportSkillsB.Click += new System.EventHandler(this.buttonCSVExportSkillsB_Click);
            // 
            // buttonCSVExportItems
            // 
            this.buttonCSVExportItems.Location = new System.Drawing.Point(82, 164);
            this.buttonCSVExportItems.Name = "buttonCSVExportItems";
            this.buttonCSVExportItems.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportItems.TabIndex = 23;
            this.buttonCSVExportItems.Text = "Get template";
            this.buttonCSVExportItems.UseVisualStyleBackColor = true;
            this.buttonCSVExportItems.Click += new System.EventHandler(this.buttonCSVExportItems_Click);
            // 
            // buttonCSVExportCommands
            // 
            this.buttonCSVExportCommands.Location = new System.Drawing.Point(82, 135);
            this.buttonCSVExportCommands.Name = "buttonCSVExportCommands";
            this.buttonCSVExportCommands.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportCommands.TabIndex = 22;
            this.buttonCSVExportCommands.Text = "Get template";
            this.buttonCSVExportCommands.UseVisualStyleBackColor = true;
            this.buttonCSVExportCommands.Click += new System.EventHandler(this.buttonCSVExportCommands_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonMiscTextSell);
            this.groupBox1.Controls.Add(this.textBoxMiscTextSell);
            this.groupBox1.Controls.Add(this.label50);
            this.groupBox1.Controls.Add(this.textBoxMiscTextExp);
            this.groupBox1.Controls.Add(this.textBoxMiscTextMP);
            this.groupBox1.Controls.Add(this.buttonMiscTextHpMpExp);
            this.groupBox1.Controls.Add(this.textBoxMiscTextHP);
            this.groupBox1.Controls.Add(this.buttonMiscTextUsesMP);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.textBoxMiscTextUsesMP);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectL);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectLv);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.textBoxMiscTextL);
            this.groupBox1.Controls.Add(this.textBoxMiscTextLv);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectPause);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectAny);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectMaster);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectEqp);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectDef);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectDefense);
            this.groupBox1.Controls.Add(this.buttonMiscTextInjectEmpty);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.textBoxMiscTextPause);
            this.groupBox1.Controls.Add(this.textBoxMiscTextAny);
            this.groupBox1.Controls.Add(this.textBoxMiscTextMaster);
            this.groupBox1.Controls.Add(this.textBoxMiscTextEmpty);
            this.groupBox1.Controls.Add(this.textBoxMiscTextEqp);
            this.groupBox1.Controls.Add(this.textBoxMiscTextDef);
            this.groupBox1.Controls.Add(this.textBoxMiscTextDefense);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Location = new System.Drawing.Point(261, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 337);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fixed sized miscs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Sell";
            // 
            // buttonMiscTextSell
            // 
            this.buttonMiscTextSell.Enabled = false;
            this.buttonMiscTextSell.Location = new System.Drawing.Point(139, 308);
            this.buttonMiscTextSell.Name = "buttonMiscTextSell";
            this.buttonMiscTextSell.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextSell.TabIndex = 58;
            this.buttonMiscTextSell.Text = "Inject";
            this.buttonMiscTextSell.UseVisualStyleBackColor = true;
            this.buttonMiscTextSell.Click += new System.EventHandler(this.buttonMiscTexSell_Click);
            // 
            // textBoxMiscTextSell
            // 
            this.textBoxMiscTextSell.Location = new System.Drawing.Point(67, 307);
            this.textBoxMiscTextSell.MaxLength = 40;
            this.textBoxMiscTextSell.Name = "textBoxMiscTextSell";
            this.textBoxMiscTextSell.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextSell.TabIndex = 56;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 284);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 13);
            this.label50.TabIndex = 55;
            this.label50.Text = "Hp Mp Exp";
            // 
            // textBoxMiscTextExp
            // 
            this.textBoxMiscTextExp.Location = new System.Drawing.Point(111, 281);
            this.textBoxMiscTextExp.MaxLength = 3;
            this.textBoxMiscTextExp.Name = "textBoxMiscTextExp";
            this.textBoxMiscTextExp.Size = new System.Drawing.Size(22, 20);
            this.textBoxMiscTextExp.TabIndex = 54;
            // 
            // textBoxMiscTextMP
            // 
            this.textBoxMiscTextMP.Location = new System.Drawing.Point(89, 281);
            this.textBoxMiscTextMP.MaxLength = 2;
            this.textBoxMiscTextMP.Name = "textBoxMiscTextMP";
            this.textBoxMiscTextMP.Size = new System.Drawing.Size(16, 20);
            this.textBoxMiscTextMP.TabIndex = 53;
            // 
            // buttonMiscTextHpMpExp
            // 
            this.buttonMiscTextHpMpExp.Enabled = false;
            this.buttonMiscTextHpMpExp.Location = new System.Drawing.Point(139, 279);
            this.buttonMiscTextHpMpExp.Name = "buttonMiscTextHpMpExp";
            this.buttonMiscTextHpMpExp.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextHpMpExp.TabIndex = 52;
            this.buttonMiscTextHpMpExp.Text = "Inject";
            this.buttonMiscTextHpMpExp.UseVisualStyleBackColor = true;
            this.buttonMiscTextHpMpExp.Click += new System.EventHandler(this.buttonMiscTextHpMpExp_Click);
            // 
            // textBoxMiscTextHP
            // 
            this.textBoxMiscTextHP.Location = new System.Drawing.Point(67, 281);
            this.textBoxMiscTextHP.MaxLength = 2;
            this.textBoxMiscTextHP.Name = "textBoxMiscTextHP";
            this.textBoxMiscTextHP.Size = new System.Drawing.Size(16, 20);
            this.textBoxMiscTextHP.TabIndex = 51;
            // 
            // buttonMiscTextUsesMP
            // 
            this.buttonMiscTextUsesMP.Enabled = false;
            this.buttonMiscTextUsesMP.Location = new System.Drawing.Point(139, 251);
            this.buttonMiscTextUsesMP.Name = "buttonMiscTextUsesMP";
            this.buttonMiscTextUsesMP.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextUsesMP.TabIndex = 50;
            this.buttonMiscTextUsesMP.Text = "Inject";
            this.buttonMiscTextUsesMP.UseVisualStyleBackColor = true;
            this.buttonMiscTextUsesMP.Click += new System.EventHandler(this.buttonMiscTextUsesMP_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 256);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 13);
            this.label32.TabIndex = 49;
            this.label32.Text = "Uses MP";
            // 
            // textBoxMiscTextUsesMP
            // 
            this.textBoxMiscTextUsesMP.Location = new System.Drawing.Point(67, 253);
            this.textBoxMiscTextUsesMP.MaxLength = 40;
            this.textBoxMiscTextUsesMP.Name = "textBoxMiscTextUsesMP";
            this.textBoxMiscTextUsesMP.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextUsesMP.TabIndex = 48;
            // 
            // buttonMiscTextInjectL
            // 
            this.buttonMiscTextInjectL.Enabled = false;
            this.buttonMiscTextInjectL.Location = new System.Drawing.Point(139, 225);
            this.buttonMiscTextInjectL.Name = "buttonMiscTextInjectL";
            this.buttonMiscTextInjectL.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectL.TabIndex = 47;
            this.buttonMiscTextInjectL.Text = "Inject";
            this.buttonMiscTextInjectL.UseVisualStyleBackColor = true;
            // 
            // buttonMiscTextInjectLv
            // 
            this.buttonMiscTextInjectLv.Enabled = false;
            this.buttonMiscTextInjectLv.Location = new System.Drawing.Point(139, 199);
            this.buttonMiscTextInjectLv.Name = "buttonMiscTextInjectLv";
            this.buttonMiscTextInjectLv.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectLv.TabIndex = 46;
            this.buttonMiscTextInjectLv.Text = "Inject";
            this.buttonMiscTextInjectLv.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectLv.Click += new System.EventHandler(this.buttonMiscTextInjectLv_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 230);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(13, 13);
            this.label31.TabIndex = 45;
            this.label31.Text = "L";
            // 
            // textBoxMiscTextL
            // 
            this.textBoxMiscTextL.Location = new System.Drawing.Point(67, 227);
            this.textBoxMiscTextL.MaxLength = 40;
            this.textBoxMiscTextL.Name = "textBoxMiscTextL";
            this.textBoxMiscTextL.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextL.TabIndex = 44;
            // 
            // textBoxMiscTextLv
            // 
            this.textBoxMiscTextLv.Location = new System.Drawing.Point(67, 201);
            this.textBoxMiscTextLv.MaxLength = 40;
            this.textBoxMiscTextLv.Name = "textBoxMiscTextLv";
            this.textBoxMiscTextLv.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextLv.TabIndex = 43;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 204);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(20, 13);
            this.label30.TabIndex = 42;
            this.label30.Text = "LV";
            // 
            // buttonMiscTextInjectPause
            // 
            this.buttonMiscTextInjectPause.Enabled = false;
            this.buttonMiscTextInjectPause.Location = new System.Drawing.Point(139, 174);
            this.buttonMiscTextInjectPause.Name = "buttonMiscTextInjectPause";
            this.buttonMiscTextInjectPause.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectPause.TabIndex = 41;
            this.buttonMiscTextInjectPause.Text = "Inject";
            this.buttonMiscTextInjectPause.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectPause.Click += new System.EventHandler(this.buttonMiscTextInjectPause_Click);
            // 
            // buttonMiscTextInjectAny
            // 
            this.buttonMiscTextInjectAny.Enabled = false;
            this.buttonMiscTextInjectAny.Location = new System.Drawing.Point(139, 147);
            this.buttonMiscTextInjectAny.Name = "buttonMiscTextInjectAny";
            this.buttonMiscTextInjectAny.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectAny.TabIndex = 40;
            this.buttonMiscTextInjectAny.Text = "Inject";
            this.buttonMiscTextInjectAny.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectAny.Click += new System.EventHandler(this.buttonMiscTextInjectAny_Click);
            // 
            // buttonMiscTextInjectMaster
            // 
            this.buttonMiscTextInjectMaster.Enabled = false;
            this.buttonMiscTextInjectMaster.Location = new System.Drawing.Point(139, 121);
            this.buttonMiscTextInjectMaster.Name = "buttonMiscTextInjectMaster";
            this.buttonMiscTextInjectMaster.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectMaster.TabIndex = 39;
            this.buttonMiscTextInjectMaster.Text = "Inject";
            this.buttonMiscTextInjectMaster.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectMaster.Click += new System.EventHandler(this.buttonMiscTextInjectMaster_Click);
            // 
            // buttonMiscTextInjectEqp
            // 
            this.buttonMiscTextInjectEqp.Enabled = false;
            this.buttonMiscTextInjectEqp.Location = new System.Drawing.Point(139, 69);
            this.buttonMiscTextInjectEqp.Name = "buttonMiscTextInjectEqp";
            this.buttonMiscTextInjectEqp.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectEqp.TabIndex = 38;
            this.buttonMiscTextInjectEqp.Text = "Inject";
            this.buttonMiscTextInjectEqp.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectEqp.Click += new System.EventHandler(this.buttonMiscTextInjectEqp_Click);
            // 
            // buttonMiscTextInjectDef
            // 
            this.buttonMiscTextInjectDef.Enabled = false;
            this.buttonMiscTextInjectDef.Location = new System.Drawing.Point(139, 43);
            this.buttonMiscTextInjectDef.Name = "buttonMiscTextInjectDef";
            this.buttonMiscTextInjectDef.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectDef.TabIndex = 37;
            this.buttonMiscTextInjectDef.Text = "Inject";
            this.buttonMiscTextInjectDef.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectDef.Click += new System.EventHandler(this.buttonMiscTextInjectDef_Click);
            // 
            // buttonMiscTextInjectDefense
            // 
            this.buttonMiscTextInjectDefense.Enabled = false;
            this.buttonMiscTextInjectDefense.Location = new System.Drawing.Point(139, 17);
            this.buttonMiscTextInjectDefense.Name = "buttonMiscTextInjectDefense";
            this.buttonMiscTextInjectDefense.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectDefense.TabIndex = 36;
            this.buttonMiscTextInjectDefense.Text = "Inject";
            this.buttonMiscTextInjectDefense.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectDefense.Click += new System.EventHandler(this.buttonMiscTextInjectDefense_Click);
            // 
            // buttonMiscTextInjectEmpty
            // 
            this.buttonMiscTextInjectEmpty.Enabled = false;
            this.buttonMiscTextInjectEmpty.Location = new System.Drawing.Point(139, 95);
            this.buttonMiscTextInjectEmpty.Name = "buttonMiscTextInjectEmpty";
            this.buttonMiscTextInjectEmpty.Size = new System.Drawing.Size(60, 23);
            this.buttonMiscTextInjectEmpty.TabIndex = 35;
            this.buttonMiscTextInjectEmpty.Text = "Inject";
            this.buttonMiscTextInjectEmpty.UseVisualStyleBackColor = true;
            this.buttonMiscTextInjectEmpty.Click += new System.EventHandler(this.buttonMiscTextInjectEmpty_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 178);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(43, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "PAUSE";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 152);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(25, 13);
            this.label28.TabIndex = 12;
            this.label28.Text = "Any";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 126);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 11;
            this.label27.Text = "MASTER!";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(36, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "Empty";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 9;
            this.label25.Text = "Eqp.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 13);
            this.label24.TabIndex = 8;
            this.label24.Text = ".Def";
            // 
            // textBoxMiscTextPause
            // 
            this.textBoxMiscTextPause.Location = new System.Drawing.Point(67, 175);
            this.textBoxMiscTextPause.MaxLength = 40;
            this.textBoxMiscTextPause.Name = "textBoxMiscTextPause";
            this.textBoxMiscTextPause.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextPause.TabIndex = 7;
            // 
            // textBoxMiscTextAny
            // 
            this.textBoxMiscTextAny.Location = new System.Drawing.Point(67, 149);
            this.textBoxMiscTextAny.MaxLength = 40;
            this.textBoxMiscTextAny.Name = "textBoxMiscTextAny";
            this.textBoxMiscTextAny.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextAny.TabIndex = 6;
            // 
            // textBoxMiscTextMaster
            // 
            this.textBoxMiscTextMaster.Location = new System.Drawing.Point(67, 123);
            this.textBoxMiscTextMaster.MaxLength = 40;
            this.textBoxMiscTextMaster.Name = "textBoxMiscTextMaster";
            this.textBoxMiscTextMaster.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextMaster.TabIndex = 5;
            // 
            // textBoxMiscTextEmpty
            // 
            this.textBoxMiscTextEmpty.Location = new System.Drawing.Point(67, 97);
            this.textBoxMiscTextEmpty.MaxLength = 40;
            this.textBoxMiscTextEmpty.Name = "textBoxMiscTextEmpty";
            this.textBoxMiscTextEmpty.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextEmpty.TabIndex = 4;
            // 
            // textBoxMiscTextEqp
            // 
            this.textBoxMiscTextEqp.Location = new System.Drawing.Point(67, 71);
            this.textBoxMiscTextEqp.MaxLength = 40;
            this.textBoxMiscTextEqp.Name = "textBoxMiscTextEqp";
            this.textBoxMiscTextEqp.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextEqp.TabIndex = 3;
            // 
            // textBoxMiscTextDef
            // 
            this.textBoxMiscTextDef.Location = new System.Drawing.Point(67, 45);
            this.textBoxMiscTextDef.MaxLength = 40;
            this.textBoxMiscTextDef.Name = "textBoxMiscTextDef";
            this.textBoxMiscTextDef.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextDef.TabIndex = 2;
            // 
            // textBoxMiscTextDefense
            // 
            this.textBoxMiscTextDefense.Location = new System.Drawing.Point(67, 19);
            this.textBoxMiscTextDefense.MaxLength = 40;
            this.textBoxMiscTextDefense.Name = "textBoxMiscTextDefense";
            this.textBoxMiscTextDefense.Size = new System.Drawing.Size(66, 20);
            this.textBoxMiscTextDefense.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Defense";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Variable sized tables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonEditSpeech);
            this.groupBox4.Controls.Add(this.labelSubsSpeech);
            this.groupBox4.Controls.Add(this.comboBoxSubSpeech);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.numericUpDownIdSpeech);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.panelMainSpeech);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.buttonCSVExportSpeech);
            this.groupBox4.Controls.Add(this.buttonCSVImportSpeech);
            this.groupBox4.Location = new System.Drawing.Point(6, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(460, 220);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Main speech";
            // 
            // buttonEditSpeech
            // 
            this.buttonEditSpeech.Location = new System.Drawing.Point(180, 19);
            this.buttonEditSpeech.Name = "buttonEditSpeech";
            this.buttonEditSpeech.Size = new System.Drawing.Size(33, 23);
            this.buttonEditSpeech.TabIndex = 47;
            this.buttonEditSpeech.Text = "Edit";
            this.buttonEditSpeech.UseVisualStyleBackColor = true;
            this.buttonEditSpeech.Click += new System.EventHandler(this.buttonEditSpeech_Click);
            // 
            // labelSubsSpeech
            // 
            this.labelSubsSpeech.AutoSize = true;
            this.labelSubsSpeech.Location = new System.Drawing.Point(149, 24);
            this.labelSubsSpeech.Name = "labelSubsSpeech";
            this.labelSubsSpeech.Size = new System.Drawing.Size(25, 13);
            this.labelSubsSpeech.TabIndex = 46;
            this.labelSubsSpeech.Text = "of 0";
            // 
            // comboBoxSubSpeech
            // 
            this.comboBoxSubSpeech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubSpeech.FormattingEnabled = true;
            this.comboBoxSubSpeech.Items.AddRange(new object[] {
            "0"});
            this.comboBoxSubSpeech.Location = new System.Drawing.Point(113, 21);
            this.comboBoxSubSpeech.Name = "comboBoxSubSpeech";
            this.comboBoxSubSpeech.Size = new System.Drawing.Size(30, 21);
            this.comboBoxSubSpeech.TabIndex = 45;
            this.comboBoxSubSpeech.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubSpeech_SelectedIndexChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(83, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(24, 13);
            this.label41.TabIndex = 44;
            this.label41.Text = "sub";
            // 
            // numericUpDownIdSpeech
            // 
            this.numericUpDownIdSpeech.Location = new System.Drawing.Point(28, 22);
            this.numericUpDownIdSpeech.Maximum = new decimal(new int[] {
            2159,
            0,
            0,
            0});
            this.numericUpDownIdSpeech.Name = "numericUpDownIdSpeech";
            this.numericUpDownIdSpeech.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownIdSpeech.TabIndex = 43;
            this.numericUpDownIdSpeech.ValueChanged += new System.EventHandler(this.numericUpDownIdSpeech_ValueChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(16, 13);
            this.label40.TabIndex = 42;
            this.label40.Text = "Id";
            // 
            // panelMainSpeech
            // 
            this.panelMainSpeech.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMainSpeech.BackgroundImage")));
            this.panelMainSpeech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMainSpeech.Location = new System.Drawing.Point(6, 54);
            this.panelMainSpeech.Name = "panelMainSpeech";
            this.panelMainSpeech.Size = new System.Drawing.Size(448, 160);
            this.panelMainSpeech.TabIndex = 41;
            this.panelMainSpeech.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMainSpeech_Paint);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(261, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Speech";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // buttonCSVExportSpeech
            // 
            this.buttonCSVExportSpeech.Location = new System.Drawing.Point(327, 19);
            this.buttonCSVExportSpeech.Name = "buttonCSVExportSpeech";
            this.buttonCSVExportSpeech.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportSpeech.TabIndex = 33;
            this.buttonCSVExportSpeech.Text = "Get template";
            this.buttonCSVExportSpeech.UseVisualStyleBackColor = true;
            this.buttonCSVExportSpeech.Click += new System.EventHandler(this.buttonCSVExportSpeech_Click);
            // 
            // buttonCSVImportSpeech
            // 
            this.buttonCSVImportSpeech.Location = new System.Drawing.Point(408, 19);
            this.buttonCSVImportSpeech.Name = "buttonCSVImportSpeech";
            this.buttonCSVImportSpeech.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportSpeech.TabIndex = 40;
            this.buttonCSVImportSpeech.Text = "Inject";
            this.buttonCSVImportSpeech.UseVisualStyleBackColor = true;
            this.buttonCSVImportSpeech.Click += new System.EventHandler(this.buttonCSVImportSpeech_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCSVExportBattleSpeech);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.buttonCSVImportConceptsV);
            this.groupBox3.Controls.Add(this.labelBattleMsg);
            this.groupBox3.Controls.Add(this.buttonCSVImportLocations);
            this.groupBox3.Controls.Add(this.labelBattleSpeech);
            this.groupBox3.Controls.Add(this.buttonCSVImportJobsDesc);
            this.groupBox3.Controls.Add(this.buttonCSVExportBattleMsg);
            this.groupBox3.Controls.Add(this.buttonCSVExportConceptsV);
            this.groupBox3.Controls.Add(this.buttonCSVImportItempDesc);
            this.groupBox3.Controls.Add(this.buttonCSVExportLocations);
            this.groupBox3.Controls.Add(this.buttonCSVExportItempDesc);
            this.groupBox3.Controls.Add(this.buttonCSVExportJobsDesc);
            this.groupBox3.Controls.Add(this.buttonCSVImportBattleMsg);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.buttonCSVImportBattleSpeech);
            this.groupBox3.Controls.Add(this.labelLocations);
            this.groupBox3.Controls.Add(this.labelConceptsVar);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 111);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variable sized tables";
            // 
            // buttonCSVExportBattleSpeech
            // 
            this.buttonCSVExportBattleSpeech.Location = new System.Drawing.Point(86, 19);
            this.buttonCSVExportBattleSpeech.Name = "buttonCSVExportBattleSpeech";
            this.buttonCSVExportBattleSpeech.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportBattleSpeech.TabIndex = 26;
            this.buttonCSVExportBattleSpeech.Text = "Get template";
            this.buttonCSVExportBattleSpeech.UseVisualStyleBackColor = true;
            this.buttonCSVExportBattleSpeech.Click += new System.EventHandler(this.buttonCSVExportBattleSpeech_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Item Desc.";
            // 
            // buttonCSVImportConceptsV
            // 
            this.buttonCSVImportConceptsV.Location = new System.Drawing.Point(408, 77);
            this.buttonCSVImportConceptsV.Name = "buttonCSVImportConceptsV";
            this.buttonCSVImportConceptsV.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportConceptsV.TabIndex = 39;
            this.buttonCSVImportConceptsV.Text = "Inject";
            this.buttonCSVImportConceptsV.UseVisualStyleBackColor = true;
            this.buttonCSVImportConceptsV.Click += new System.EventHandler(this.buttonCSVImportConceptsV_Click);
            // 
            // labelBattleMsg
            // 
            this.labelBattleMsg.AutoSize = true;
            this.labelBattleMsg.Location = new System.Drawing.Point(6, 53);
            this.labelBattleMsg.Name = "labelBattleMsg";
            this.labelBattleMsg.Size = new System.Drawing.Size(60, 13);
            this.labelBattleMsg.TabIndex = 19;
            this.labelBattleMsg.Text = "Battle Msg.";
            this.labelBattleMsg.Click += new System.EventHandler(this.labelBattleMsg_Click);
            // 
            // buttonCSVImportLocations
            // 
            this.buttonCSVImportLocations.Location = new System.Drawing.Point(408, 48);
            this.buttonCSVImportLocations.Name = "buttonCSVImportLocations";
            this.buttonCSVImportLocations.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportLocations.TabIndex = 38;
            this.buttonCSVImportLocations.Text = "Inject";
            this.buttonCSVImportLocations.UseVisualStyleBackColor = true;
            this.buttonCSVImportLocations.Click += new System.EventHandler(this.buttonCSVImportLocations_Click);
            // 
            // labelBattleSpeech
            // 
            this.labelBattleSpeech.AutoSize = true;
            this.labelBattleSpeech.Location = new System.Drawing.Point(6, 24);
            this.labelBattleSpeech.Name = "labelBattleSpeech";
            this.labelBattleSpeech.Size = new System.Drawing.Size(74, 13);
            this.labelBattleSpeech.TabIndex = 18;
            this.labelBattleSpeech.Text = "Battle Speech";
            this.labelBattleSpeech.Click += new System.EventHandler(this.labelBattleSpeech_Click);
            // 
            // buttonCSVImportJobsDesc
            // 
            this.buttonCSVImportJobsDesc.Location = new System.Drawing.Point(408, 19);
            this.buttonCSVImportJobsDesc.Name = "buttonCSVImportJobsDesc";
            this.buttonCSVImportJobsDesc.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportJobsDesc.TabIndex = 37;
            this.buttonCSVImportJobsDesc.Text = "Inject";
            this.buttonCSVImportJobsDesc.UseVisualStyleBackColor = true;
            this.buttonCSVImportJobsDesc.Click += new System.EventHandler(this.buttonCSVImportJobsDesc_Click);
            // 
            // buttonCSVExportBattleMsg
            // 
            this.buttonCSVExportBattleMsg.Location = new System.Drawing.Point(86, 48);
            this.buttonCSVExportBattleMsg.Name = "buttonCSVExportBattleMsg";
            this.buttonCSVExportBattleMsg.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportBattleMsg.TabIndex = 27;
            this.buttonCSVExportBattleMsg.Text = "Get template";
            this.buttonCSVExportBattleMsg.UseVisualStyleBackColor = true;
            this.buttonCSVExportBattleMsg.Click += new System.EventHandler(this.buttonCSVExportBattleMsg_Click);
            // 
            // buttonCSVExportConceptsV
            // 
            this.buttonCSVExportConceptsV.Location = new System.Drawing.Point(327, 77);
            this.buttonCSVExportConceptsV.Name = "buttonCSVExportConceptsV";
            this.buttonCSVExportConceptsV.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportConceptsV.TabIndex = 32;
            this.buttonCSVExportConceptsV.Text = "Get template";
            this.buttonCSVExportConceptsV.UseVisualStyleBackColor = true;
            this.buttonCSVExportConceptsV.Click += new System.EventHandler(this.buttonCSVExportConceptsV_Click);
            // 
            // buttonCSVImportItempDesc
            // 
            this.buttonCSVImportItempDesc.Location = new System.Drawing.Point(167, 77);
            this.buttonCSVImportItempDesc.Name = "buttonCSVImportItempDesc";
            this.buttonCSVImportItempDesc.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportItempDesc.TabIndex = 36;
            this.buttonCSVImportItempDesc.Text = "Inject";
            this.buttonCSVImportItempDesc.UseVisualStyleBackColor = true;
            this.buttonCSVImportItempDesc.Click += new System.EventHandler(this.buttonCSVImportItempDesc_Click);
            // 
            // buttonCSVExportLocations
            // 
            this.buttonCSVExportLocations.Location = new System.Drawing.Point(327, 48);
            this.buttonCSVExportLocations.Name = "buttonCSVExportLocations";
            this.buttonCSVExportLocations.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportLocations.TabIndex = 31;
            this.buttonCSVExportLocations.Text = "Get template";
            this.buttonCSVExportLocations.UseVisualStyleBackColor = true;
            this.buttonCSVExportLocations.Click += new System.EventHandler(this.buttonCSVExportLocations_Click);
            // 
            // buttonCSVExportItempDesc
            // 
            this.buttonCSVExportItempDesc.Location = new System.Drawing.Point(86, 77);
            this.buttonCSVExportItempDesc.Name = "buttonCSVExportItempDesc";
            this.buttonCSVExportItempDesc.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportItempDesc.TabIndex = 28;
            this.buttonCSVExportItempDesc.Text = "Get template";
            this.buttonCSVExportItempDesc.UseVisualStyleBackColor = true;
            this.buttonCSVExportItempDesc.Click += new System.EventHandler(this.buttonCSVExportItempDesc_Click);
            // 
            // buttonCSVExportJobsDesc
            // 
            this.buttonCSVExportJobsDesc.Location = new System.Drawing.Point(327, 19);
            this.buttonCSVExportJobsDesc.Name = "buttonCSVExportJobsDesc";
            this.buttonCSVExportJobsDesc.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportJobsDesc.TabIndex = 29;
            this.buttonCSVExportJobsDesc.Text = "Get template";
            this.buttonCSVExportJobsDesc.UseVisualStyleBackColor = true;
            this.buttonCSVExportJobsDesc.Click += new System.EventHandler(this.buttonCSVExportJobsDesc_Click);
            // 
            // buttonCSVImportBattleMsg
            // 
            this.buttonCSVImportBattleMsg.Location = new System.Drawing.Point(167, 48);
            this.buttonCSVImportBattleMsg.Name = "buttonCSVImportBattleMsg";
            this.buttonCSVImportBattleMsg.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportBattleMsg.TabIndex = 35;
            this.buttonCSVImportBattleMsg.Text = "Inject";
            this.buttonCSVImportBattleMsg.UseVisualStyleBackColor = true;
            this.buttonCSVImportBattleMsg.Click += new System.EventHandler(this.buttonCSVImportBattleMsg_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Jobs Desc.";
            // 
            // buttonCSVImportBattleSpeech
            // 
            this.buttonCSVImportBattleSpeech.Location = new System.Drawing.Point(167, 19);
            this.buttonCSVImportBattleSpeech.Name = "buttonCSVImportBattleSpeech";
            this.buttonCSVImportBattleSpeech.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportBattleSpeech.TabIndex = 34;
            this.buttonCSVImportBattleSpeech.Text = "Inject";
            this.buttonCSVImportBattleSpeech.UseVisualStyleBackColor = true;
            this.buttonCSVImportBattleSpeech.Click += new System.EventHandler(this.buttonCSVImportBattleSpeech_Click);
            // 
            // labelLocations
            // 
            this.labelLocations.AutoSize = true;
            this.labelLocations.Location = new System.Drawing.Point(261, 53);
            this.labelLocations.Name = "labelLocations";
            this.labelLocations.Size = new System.Drawing.Size(53, 13);
            this.labelLocations.TabIndex = 23;
            this.labelLocations.Text = "Locations";
            this.labelLocations.Click += new System.EventHandler(this.labelLocations_Click);
            // 
            // labelConceptsVar
            // 
            this.labelConceptsVar.AutoSize = true;
            this.labelConceptsVar.Location = new System.Drawing.Point(261, 82);
            this.labelConceptsVar.Name = "labelConceptsVar";
            this.labelConceptsVar.Size = new System.Drawing.Size(52, 13);
            this.labelConceptsVar.TabIndex = 24;
            this.labelConceptsVar.Text = "Concepts";
            this.labelConceptsVar.Click += new System.EventHandler(this.labelConceptsVar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox1bppFont);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.buttonLoadWidths);
            this.tabPage3.Controls.Add(this.buttonSaveWidths);
            this.tabPage3.Controls.Add(this.buttonUpdateWidths);
            this.tabPage3.Controls.Add(this.listViewTextWidths);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(472, 349);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Font widths";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox1bppFont
            // 
            this.comboBox1bppFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1bppFont.FormattingEnabled = true;
            this.comboBox1bppFont.Items.AddRange(new object[] {
            "Standard",
            "Poem"});
            this.comboBox1bppFont.Location = new System.Drawing.Point(61, 319);
            this.comboBox1bppFont.Name = "comboBox1bppFont";
            this.comboBox1bppFont.Size = new System.Drawing.Size(78, 21);
            this.comboBox1bppFont.TabIndex = 42;
            this.comboBox1bppFont.SelectedIndexChanged += new System.EventHandler(this.comboBox1bppFont_SelectedIndexChanged);
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(3, 322);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(52, 13);
            this.label46.TabIndex = 43;
            this.label46.Text = "1bpp font";
            // 
            // buttonLoadWidths
            // 
            this.buttonLoadWidths.Location = new System.Drawing.Point(296, 317);
            this.buttonLoadWidths.Name = "buttonLoadWidths";
            this.buttonLoadWidths.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadWidths.TabIndex = 4;
            this.buttonLoadWidths.Text = "Load";
            this.buttonLoadWidths.UseVisualStyleBackColor = true;
            this.buttonLoadWidths.Click += new System.EventHandler(this.buttonLoadWidths_Click);
            // 
            // buttonSaveWidths
            // 
            this.buttonSaveWidths.Location = new System.Drawing.Point(377, 317);
            this.buttonSaveWidths.Name = "buttonSaveWidths";
            this.buttonSaveWidths.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveWidths.TabIndex = 3;
            this.buttonSaveWidths.Text = "Save";
            this.buttonSaveWidths.UseVisualStyleBackColor = true;
            this.buttonSaveWidths.Click += new System.EventHandler(this.buttonSaveWidths_Click);
            // 
            // buttonUpdateWidths
            // 
            this.buttonUpdateWidths.Location = new System.Drawing.Point(145, 317);
            this.buttonUpdateWidths.Name = "buttonUpdateWidths";
            this.buttonUpdateWidths.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateWidths.TabIndex = 1;
            this.buttonUpdateWidths.Text = "Inject";
            this.buttonUpdateWidths.UseVisualStyleBackColor = true;
            this.buttonUpdateWidths.Click += new System.EventHandler(this.buttonUpdateWidths_Click);
            // 
            // listViewTextWidths
            // 
            this.listViewTextWidths.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewTextWidths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstColumn,
            this.columnHeader00,
            this.columnHeader01,
            this.columnHeader02,
            this.columnHeader03,
            this.columnHeader04,
            this.columnHeader05,
            this.columnHeader06,
            this.columnHeader07,
            this.columnHeader08,
            this.columnHeader09,
            this.columnHeader0A,
            this.columnHeader0B,
            this.columnHeader0C,
            this.columnHeader0D,
            this.columnHeader0E,
            this.columnHeader0F});
            this.listViewTextWidths.GridLines = true;
            this.listViewTextWidths.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem1.UseItemStyleForSubItems = false;
            listViewItem2.UseItemStyleForSubItems = false;
            listViewItem3.UseItemStyleForSubItems = false;
            listViewItem4.UseItemStyleForSubItems = false;
            listViewItem5.UseItemStyleForSubItems = false;
            listViewItem6.UseItemStyleForSubItems = false;
            listViewItem7.UseItemStyleForSubItems = false;
            listViewItem8.UseItemStyleForSubItems = false;
            listViewItem9.UseItemStyleForSubItems = false;
            listViewItem10.UseItemStyleForSubItems = false;
            listViewItem11.UseItemStyleForSubItems = false;
            listViewItem12.UseItemStyleForSubItems = false;
            listViewItem13.UseItemStyleForSubItems = false;
            listViewItem14.UseItemStyleForSubItems = false;
            listViewItem15.UseItemStyleForSubItems = false;
            listViewItem16.UseItemStyleForSubItems = false;
            this.listViewTextWidths.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16});
            this.listViewTextWidths.Location = new System.Drawing.Point(6, 11);
            this.listViewTextWidths.MultiSelect = false;
            this.listViewTextWidths.Name = "listViewTextWidths";
            this.listViewTextWidths.Size = new System.Drawing.Size(446, 300);
            this.listViewTextWidths.TabIndex = 0;
            this.listViewTextWidths.Tag = "";
            this.listViewTextWidths.TileSize = new System.Drawing.Size(26, 26);
            this.listViewTextWidths.UseCompatibleStateImageBehavior = false;
            this.listViewTextWidths.View = System.Windows.Forms.View.Details;
            // 
            // FirstColumn
            // 
            this.FirstColumn.Text = "";
            this.FirstColumn.Width = 26;
            // 
            // columnHeader00
            // 
            this.columnHeader00.Text = "00";
            this.columnHeader00.Width = 26;
            // 
            // columnHeader01
            // 
            this.columnHeader01.Text = "01";
            this.columnHeader01.Width = 26;
            // 
            // columnHeader02
            // 
            this.columnHeader02.Text = "02";
            this.columnHeader02.Width = 26;
            // 
            // columnHeader03
            // 
            this.columnHeader03.Text = "03";
            this.columnHeader03.Width = 26;
            // 
            // columnHeader04
            // 
            this.columnHeader04.Text = "04";
            this.columnHeader04.Width = 26;
            // 
            // columnHeader05
            // 
            this.columnHeader05.Text = "05";
            this.columnHeader05.Width = 26;
            // 
            // columnHeader06
            // 
            this.columnHeader06.Text = "06";
            this.columnHeader06.Width = 26;
            // 
            // columnHeader07
            // 
            this.columnHeader07.Text = "07";
            this.columnHeader07.Width = 26;
            // 
            // columnHeader08
            // 
            this.columnHeader08.Text = "08";
            this.columnHeader08.Width = 26;
            // 
            // columnHeader09
            // 
            this.columnHeader09.Text = "09";
            this.columnHeader09.Width = 26;
            // 
            // columnHeader0A
            // 
            this.columnHeader0A.Text = "0A";
            this.columnHeader0A.Width = 26;
            // 
            // columnHeader0B
            // 
            this.columnHeader0B.Text = "0B";
            this.columnHeader0B.Width = 26;
            // 
            // columnHeader0C
            // 
            this.columnHeader0C.Text = "0C";
            this.columnHeader0C.Width = 26;
            // 
            // columnHeader0D
            // 
            this.columnHeader0D.Text = "0D";
            this.columnHeader0D.Width = 26;
            // 
            // columnHeader0E
            // 
            this.columnHeader0E.Text = "0E";
            this.columnHeader0E.Width = 26;
            // 
            // columnHeader0F
            // 
            this.columnHeader0F.Text = "0F";
            this.columnHeader0F.Width = 26;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelMuteSpell);
            this.tabPage4.Controls.Add(this.groupBox11);
            this.tabPage4.Controls.Add(this.groupBox10);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.panel2bpp);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(472, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Images";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelMuteSpell
            // 
            this.panelMuteSpell.BackColor = System.Drawing.Color.Black;
            this.panelMuteSpell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMuteSpell.Location = new System.Drawing.Point(400, 267);
            this.panelMuteSpell.Name = "panelMuteSpell";
            this.panelMuteSpell.Size = new System.Drawing.Size(69, 69);
            this.panelMuteSpell.TabIndex = 5;
            this.panelMuteSpell.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMuteSpell_Paint);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.buttonMuteExport);
            this.groupBox11.Controls.Add(this.buttonMuteImport);
            this.groupBox11.Location = new System.Drawing.Point(272, 259);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(122, 77);
            this.groupBox11.TabIndex = 51;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Mute spell";
            // 
            // buttonMuteExport
            // 
            this.buttonMuteExport.Location = new System.Drawing.Point(41, 19);
            this.buttonMuteExport.Name = "buttonMuteExport";
            this.buttonMuteExport.Size = new System.Drawing.Size(75, 23);
            this.buttonMuteExport.TabIndex = 49;
            this.buttonMuteExport.Text = "Get template";
            this.buttonMuteExport.UseVisualStyleBackColor = true;
            this.buttonMuteExport.Click += new System.EventHandler(this.buttonMuteExport_Click);
            // 
            // buttonMuteImport
            // 
            this.buttonMuteImport.Location = new System.Drawing.Point(70, 48);
            this.buttonMuteImport.Name = "buttonMuteImport";
            this.buttonMuteImport.Size = new System.Drawing.Size(46, 23);
            this.buttonMuteImport.TabIndex = 17;
            this.buttonMuteImport.Text = "Inject";
            this.buttonMuteImport.UseVisualStyleBackColor = true;
            this.buttonMuteImport.Click += new System.EventHandler(this.buttonMuteImport_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonCSVImportPOL);
            this.groupBox10.Controls.Add(this.buttonCSVExportPOL);
            this.groupBox10.Controls.Add(this.buttonSynchroIndexInject);
            this.groupBox10.Controls.Add(this.textBoxSynchroIndexInject);
            this.groupBox10.Controls.Add(this.label56);
            this.groupBox10.Location = new System.Drawing.Point(272, 176);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(197, 77);
            this.groupBox10.TabIndex = 50;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Poem of Light";
            // 
            // buttonCSVImportPOL
            // 
            this.buttonCSVImportPOL.Location = new System.Drawing.Point(145, 19);
            this.buttonCSVImportPOL.Name = "buttonCSVImportPOL";
            this.buttonCSVImportPOL.Size = new System.Drawing.Size(46, 23);
            this.buttonCSVImportPOL.TabIndex = 43;
            this.buttonCSVImportPOL.Text = "Inject";
            this.buttonCSVImportPOL.UseVisualStyleBackColor = true;
            this.buttonCSVImportPOL.Click += new System.EventHandler(this.buttonCSVImportPOL_Click);
            // 
            // buttonCSVExportPOL
            // 
            this.buttonCSVExportPOL.Location = new System.Drawing.Point(64, 19);
            this.buttonCSVExportPOL.Name = "buttonCSVExportPOL";
            this.buttonCSVExportPOL.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportPOL.TabIndex = 42;
            this.buttonCSVExportPOL.Text = "Get template";
            this.buttonCSVExportPOL.UseVisualStyleBackColor = true;
            this.buttonCSVExportPOL.Click += new System.EventHandler(this.buttonCSVExportPOL_Click);
            // 
            // buttonSynchroIndexInject
            // 
            this.buttonSynchroIndexInject.Location = new System.Drawing.Point(145, 48);
            this.buttonSynchroIndexInject.Name = "buttonSynchroIndexInject";
            this.buttonSynchroIndexInject.Size = new System.Drawing.Size(46, 23);
            this.buttonSynchroIndexInject.TabIndex = 44;
            this.buttonSynchroIndexInject.Text = "Inject";
            this.buttonSynchroIndexInject.UseVisualStyleBackColor = true;
            this.buttonSynchroIndexInject.Click += new System.EventHandler(this.buttonSynchroIndexInject_Click);
            // 
            // textBoxSynchroIndexInject
            // 
            this.textBoxSynchroIndexInject.Location = new System.Drawing.Point(113, 50);
            this.textBoxSynchroIndexInject.MaxLength = 2;
            this.textBoxSynchroIndexInject.Name = "textBoxSynchroIndexInject";
            this.textBoxSynchroIndexInject.Size = new System.Drawing.Size(26, 20);
            this.textBoxSynchroIndexInject.TabIndex = 45;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(64, 52);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(43, 13);
            this.label56.TabIndex = 46;
            this.label56.Text = "S.Index";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label59);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Controls.Add(this.buttonOtherFontExport);
            this.groupBox9.Controls.Add(this.buttonOtherFontImport);
            this.groupBox9.Controls.Add(this.buttonDamageFontExport);
            this.groupBox9.Controls.Add(this.buttonDamageFontImport);
            this.groupBox9.Controls.Add(this.button1bppFontExport);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.button1bppFontImport);
            this.groupBox9.Controls.Add(this.button2bppFontImport);
            this.groupBox9.Controls.Add(this.button2bppFontExport);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.label45);
            this.groupBox9.Controls.Add(this.buttonPoemOfLightFontExport);
            this.groupBox9.Controls.Add(this.buttonPoemOfLightFontImport);
            this.groupBox9.Location = new System.Drawing.Point(272, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(197, 164);
            this.groupBox9.TabIndex = 47;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Fonts";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(6, 140);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(33, 13);
            this.label59.TabIndex = 16;
            this.label59.Text = "Other";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 111);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(47, 13);
            this.label58.TabIndex = 15;
            this.label58.Text = "Damage";
            // 
            // buttonOtherFontExport
            // 
            this.buttonOtherFontExport.Location = new System.Drawing.Point(64, 135);
            this.buttonOtherFontExport.Name = "buttonOtherFontExport";
            this.buttonOtherFontExport.Size = new System.Drawing.Size(75, 23);
            this.buttonOtherFontExport.TabIndex = 13;
            this.buttonOtherFontExport.Text = "Get template";
            this.buttonOtherFontExport.UseVisualStyleBackColor = true;
            this.buttonOtherFontExport.Click += new System.EventHandler(this.buttonOtherFontExport_Click);
            // 
            // buttonOtherFontImport
            // 
            this.buttonOtherFontImport.Location = new System.Drawing.Point(145, 135);
            this.buttonOtherFontImport.Name = "buttonOtherFontImport";
            this.buttonOtherFontImport.Size = new System.Drawing.Size(46, 23);
            this.buttonOtherFontImport.TabIndex = 14;
            this.buttonOtherFontImport.Text = "Inject";
            this.buttonOtherFontImport.UseVisualStyleBackColor = true;
            this.buttonOtherFontImport.Click += new System.EventHandler(this.buttonOtherFontImport_Click);
            // 
            // buttonDamageFontExport
            // 
            this.buttonDamageFontExport.Location = new System.Drawing.Point(64, 106);
            this.buttonDamageFontExport.Name = "buttonDamageFontExport";
            this.buttonDamageFontExport.Size = new System.Drawing.Size(75, 23);
            this.buttonDamageFontExport.TabIndex = 11;
            this.buttonDamageFontExport.Text = "Get template";
            this.buttonDamageFontExport.UseVisualStyleBackColor = true;
            this.buttonDamageFontExport.Click += new System.EventHandler(this.buttonDamageFontExport_Click);
            // 
            // buttonDamageFontImport
            // 
            this.buttonDamageFontImport.Location = new System.Drawing.Point(145, 106);
            this.buttonDamageFontImport.Name = "buttonDamageFontImport";
            this.buttonDamageFontImport.Size = new System.Drawing.Size(46, 23);
            this.buttonDamageFontImport.TabIndex = 12;
            this.buttonDamageFontImport.Text = "Inject";
            this.buttonDamageFontImport.UseVisualStyleBackColor = true;
            this.buttonDamageFontImport.Click += new System.EventHandler(this.buttonDamageFontImport_Click);
            // 
            // button1bppFontExport
            // 
            this.button1bppFontExport.Location = new System.Drawing.Point(64, 19);
            this.button1bppFontExport.Name = "button1bppFontExport";
            this.button1bppFontExport.Size = new System.Drawing.Size(75, 23);
            this.button1bppFontExport.TabIndex = 2;
            this.button1bppFontExport.Text = "Get template";
            this.button1bppFontExport.UseVisualStyleBackColor = true;
            this.button1bppFontExport.Click += new System.EventHandler(this.button1bppFontExport_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "1bpp";
            // 
            // button1bppFontImport
            // 
            this.button1bppFontImport.Location = new System.Drawing.Point(145, 19);
            this.button1bppFontImport.Name = "button1bppFontImport";
            this.button1bppFontImport.Size = new System.Drawing.Size(46, 23);
            this.button1bppFontImport.TabIndex = 0;
            this.button1bppFontImport.Text = "Inject";
            this.button1bppFontImport.UseVisualStyleBackColor = true;
            this.button1bppFontImport.Click += new System.EventHandler(this.button1bppFontImport_Click);
            // 
            // button2bppFontImport
            // 
            this.button2bppFontImport.Location = new System.Drawing.Point(145, 48);
            this.button2bppFontImport.Name = "button2bppFontImport";
            this.button2bppFontImport.Size = new System.Drawing.Size(46, 23);
            this.button2bppFontImport.TabIndex = 1;
            this.button2bppFontImport.Text = "Inject";
            this.button2bppFontImport.UseVisualStyleBackColor = true;
            this.button2bppFontImport.Click += new System.EventHandler(this.button2bppFontImport_Click);
            // 
            // button2bppFontExport
            // 
            this.button2bppFontExport.Location = new System.Drawing.Point(64, 48);
            this.button2bppFontExport.Name = "button2bppFontExport";
            this.button2bppFontExport.Size = new System.Drawing.Size(75, 23);
            this.button2bppFontExport.TabIndex = 3;
            this.button2bppFontExport.Text = "Get template";
            this.button2bppFontExport.UseVisualStyleBackColor = true;
            this.button2bppFontExport.Click += new System.EventHandler(this.button2bppFontExport_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "2bpp";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 82);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(34, 13);
            this.label45.TabIndex = 8;
            this.label45.Text = "Poem";
            // 
            // buttonPoemOfLightFontExport
            // 
            this.buttonPoemOfLightFontExport.Location = new System.Drawing.Point(64, 77);
            this.buttonPoemOfLightFontExport.Name = "buttonPoemOfLightFontExport";
            this.buttonPoemOfLightFontExport.Size = new System.Drawing.Size(75, 23);
            this.buttonPoemOfLightFontExport.TabIndex = 9;
            this.buttonPoemOfLightFontExport.Text = "Get template";
            this.buttonPoemOfLightFontExport.UseVisualStyleBackColor = true;
            this.buttonPoemOfLightFontExport.Click += new System.EventHandler(this.buttonPoemOfLightFontExport_Click);
            // 
            // buttonPoemOfLightFontImport
            // 
            this.buttonPoemOfLightFontImport.Location = new System.Drawing.Point(145, 77);
            this.buttonPoemOfLightFontImport.Name = "buttonPoemOfLightFontImport";
            this.buttonPoemOfLightFontImport.Size = new System.Drawing.Size(46, 23);
            this.buttonPoemOfLightFontImport.TabIndex = 10;
            this.buttonPoemOfLightFontImport.Text = "Inject";
            this.buttonPoemOfLightFontImport.UseVisualStyleBackColor = true;
            this.buttonPoemOfLightFontImport.Click += new System.EventHandler(this.buttonPoemOfLightFontImport_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "2bpp font";
            // 
            // panel2bpp
            // 
            this.panel2bpp.BackColor = System.Drawing.Color.Black;
            this.panel2bpp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2bpp.Location = new System.Drawing.Point(6, 22);
            this.panel2bpp.Name = "panel2bpp";
            this.panel2bpp.Size = new System.Drawing.Size(260, 260);
            this.panel2bpp.TabIndex = 4;
            this.panel2bpp.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2bpp_Paint);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.buttonSRAM);
            this.tabPage5.Controls.Add(this.buttonEveryDraw);
            this.tabPage5.Controls.Add(this.comboBoxWinGrouping);
            this.tabPage5.Controls.Add(this.buttonWindowsCtrl);
            this.tabPage5.Controls.Add(this.label22);
            this.tabPage5.Controls.Add(this.label21);
            this.tabPage5.Controls.Add(this.buttonWindowsInfo);
            this.tabPage5.Controls.Add(this.textBoxWindowInfoAddress);
            this.tabPage5.Controls.Add(this.textBoxWindowInfo);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(472, 349);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Windows";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonSRAM
            // 
            this.buttonSRAM.Location = new System.Drawing.Point(394, 3);
            this.buttonSRAM.Name = "buttonSRAM";
            this.buttonSRAM.Size = new System.Drawing.Size(75, 23);
            this.buttonSRAM.TabIndex = 52;
            this.buttonSRAM.Text = "SRAM";
            this.buttonSRAM.UseVisualStyleBackColor = true;
            this.buttonSRAM.Click += new System.EventHandler(this.buttonSRAM_Click);
            // 
            // buttonEveryDraw
            // 
            this.buttonEveryDraw.Location = new System.Drawing.Point(394, 74);
            this.buttonEveryDraw.Name = "buttonEveryDraw";
            this.buttonEveryDraw.Size = new System.Drawing.Size(75, 23);
            this.buttonEveryDraw.TabIndex = 51;
            this.buttonEveryDraw.Text = "Every draw";
            this.buttonEveryDraw.UseVisualStyleBackColor = true;
            this.buttonEveryDraw.Click += new System.EventHandler(this.buttonEveryDraw_Click);
            // 
            // comboBoxWinGrouping
            // 
            this.comboBoxWinGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWinGrouping.FormattingEnabled = true;
            this.comboBoxWinGrouping.Items.AddRange(new object[] {
            "3",
            "4"});
            this.comboBoxWinGrouping.Location = new System.Drawing.Point(87, 26);
            this.comboBoxWinGrouping.Name = "comboBoxWinGrouping";
            this.comboBoxWinGrouping.Size = new System.Drawing.Size(43, 21);
            this.comboBoxWinGrouping.TabIndex = 50;
            // 
            // buttonWindowsCtrl
            // 
            this.buttonWindowsCtrl.Location = new System.Drawing.Point(87, 74);
            this.buttonWindowsCtrl.Name = "buttonWindowsCtrl";
            this.buttonWindowsCtrl.Size = new System.Drawing.Size(75, 23);
            this.buttonWindowsCtrl.TabIndex = 49;
            this.buttonWindowsCtrl.Text = "Win control";
            this.buttonWindowsCtrl.UseVisualStyleBackColor = true;
            this.buttonWindowsCtrl.Click += new System.EventHandler(this.buttonWindowsCtrl_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "Decode as:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(127, 13);
            this.label21.TabIndex = 47;
            this.label21.Text = "Window function address";
            // 
            // buttonWindowsInfo
            // 
            this.buttonWindowsInfo.Location = new System.Drawing.Point(6, 74);
            this.buttonWindowsInfo.Name = "buttonWindowsInfo";
            this.buttonWindowsInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonWindowsInfo.TabIndex = 46;
            this.buttonWindowsInfo.Text = "Win draw";
            this.buttonWindowsInfo.UseVisualStyleBackColor = true;
            this.buttonWindowsInfo.Click += new System.EventHandler(this.buttonWindowsInfo_Click);
            // 
            // textBoxWindowInfoAddress
            // 
            this.textBoxWindowInfoAddress.Location = new System.Drawing.Point(6, 27);
            this.textBoxWindowInfoAddress.MaxLength = 4;
            this.textBoxWindowInfoAddress.Name = "textBoxWindowInfoAddress";
            this.textBoxWindowInfoAddress.Size = new System.Drawing.Size(75, 20);
            this.textBoxWindowInfoAddress.TabIndex = 45;
            // 
            // textBoxWindowInfo
            // 
            this.textBoxWindowInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWindowInfo.Location = new System.Drawing.Point(3, 103);
            this.textBoxWindowInfo.Multiline = true;
            this.textBoxWindowInfo.Name = "textBoxWindowInfo";
            this.textBoxWindowInfo.ReadOnly = true;
            this.textBoxWindowInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxWindowInfo.Size = new System.Drawing.Size(466, 243);
            this.textBoxWindowInfo.TabIndex = 44;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.buttonDummy);
            this.tabPage7.Controls.Add(this.checkBoxDisplayW2);
            this.tabPage7.Controls.Add(this.checkBoxDisplayW1);
            this.tabPage7.Controls.Add(this.checkBoxDisplayW0);
            this.tabPage7.Controls.Add(this.label62);
            this.tabPage7.Controls.Add(this.label61);
            this.tabPage7.Controls.Add(this.textBoxWindowFunction);
            this.tabPage7.Controls.Add(this.textBoxWindowAddress);
            this.tabPage7.Controls.Add(this.label60);
            this.tabPage7.Controls.Add(this.label57);
            this.tabPage7.Controls.Add(this.label9);
            this.tabPage7.Controls.Add(this.numericUpDownWindowT);
            this.tabPage7.Controls.Add(this.numericUpDownWindowH);
            this.tabPage7.Controls.Add(this.numericUpDownWindowW);
            this.tabPage7.Controls.Add(this.numericUpDownWindowY);
            this.tabPage7.Controls.Add(this.label8);
            this.tabPage7.Controls.Add(this.labelX);
            this.tabPage7.Controls.Add(this.numericUpDownWindowX);
            this.tabPage7.Controls.Add(this.labelWindowFunction);
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Controls.Add(this.listViewWindows);
            this.tabPage7.Controls.Add(this.comboBoxWindowsMenu);
            this.tabPage7.Controls.Add(this.panelWindowDisplay);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(472, 349);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Windows";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplayW2
            // 
            this.checkBoxDisplayW2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDisplayW2.AutoSize = true;
            this.checkBoxDisplayW2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDisplayW2.Checked = true;
            this.checkBoxDisplayW2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayW2.Location = new System.Drawing.Point(416, 329);
            this.checkBoxDisplayW2.Name = "checkBoxDisplayW2";
            this.checkBoxDisplayW2.Size = new System.Drawing.Size(43, 17);
            this.checkBoxDisplayW2.TabIndex = 70;
            this.checkBoxDisplayW2.Text = "W2";
            this.checkBoxDisplayW2.UseVisualStyleBackColor = true;
            this.checkBoxDisplayW2.CheckedChanged += new System.EventHandler(this.checkBoxDisplayW_CheckedChanged);
            // 
            // checkBoxDisplayW1
            // 
            this.checkBoxDisplayW1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDisplayW1.AutoSize = true;
            this.checkBoxDisplayW1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDisplayW1.Checked = true;
            this.checkBoxDisplayW1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayW1.Location = new System.Drawing.Point(416, 315);
            this.checkBoxDisplayW1.Name = "checkBoxDisplayW1";
            this.checkBoxDisplayW1.Size = new System.Drawing.Size(43, 17);
            this.checkBoxDisplayW1.TabIndex = 69;
            this.checkBoxDisplayW1.Text = "W1";
            this.checkBoxDisplayW1.UseVisualStyleBackColor = true;
            this.checkBoxDisplayW1.CheckedChanged += new System.EventHandler(this.checkBoxDisplayW_CheckedChanged);
            // 
            // checkBoxDisplayW0
            // 
            this.checkBoxDisplayW0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDisplayW0.AutoSize = true;
            this.checkBoxDisplayW0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDisplayW0.Checked = true;
            this.checkBoxDisplayW0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayW0.Location = new System.Drawing.Point(379, 301);
            this.checkBoxDisplayW0.Name = "checkBoxDisplayW0";
            this.checkBoxDisplayW0.Size = new System.Drawing.Size(80, 17);
            this.checkBoxDisplayW0.TabIndex = 10;
            this.checkBoxDisplayW0.Text = "Display W0";
            this.checkBoxDisplayW0.UseVisualStyleBackColor = true;
            this.checkBoxDisplayW0.CheckedChanged += new System.EventHandler(this.checkBoxDisplayW_CheckedChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(51, 299);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(48, 13);
            this.label62.TabIndex = 68;
            this.label62.Text = "Function";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(0, 299);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(45, 13);
            this.label61.TabIndex = 67;
            this.label61.Text = "Address";
            // 
            // textBoxWindowFunction
            // 
            this.textBoxWindowFunction.Location = new System.Drawing.Point(54, 316);
            this.textBoxWindowFunction.Name = "textBoxWindowFunction";
            this.textBoxWindowFunction.ReadOnly = true;
            this.textBoxWindowFunction.Size = new System.Drawing.Size(45, 20);
            this.textBoxWindowFunction.TabIndex = 66;
            // 
            // textBoxWindowAddress
            // 
            this.textBoxWindowAddress.Location = new System.Drawing.Point(3, 316);
            this.textBoxWindowAddress.Name = "textBoxWindowAddress";
            this.textBoxWindowAddress.ReadOnly = true;
            this.textBoxWindowAddress.Size = new System.Drawing.Size(45, 20);
            this.textBoxWindowAddress.TabIndex = 65;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(282, 300);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(14, 13);
            this.label60.TabIndex = 64;
            this.label60.Text = "T";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(237, 300);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(38, 13);
            this.label57.TabIndex = 63;
            this.label57.Text = "Height";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "Width";
            // 
            // numericUpDownWindowT
            // 
            this.numericUpDownWindowT.Enabled = false;
            this.numericUpDownWindowT.Hexadecimal = true;
            this.numericUpDownWindowT.Location = new System.Drawing.Point(285, 316);
            this.numericUpDownWindowT.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWindowT.Name = "numericUpDownWindowT";
            this.numericUpDownWindowT.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWindowT.TabIndex = 61;
            this.numericUpDownWindowT.ValueChanged += new System.EventHandler(this.numericUpDownWindowT_ValueChanged);
            // 
            // numericUpDownWindowH
            // 
            this.numericUpDownWindowH.Enabled = false;
            this.numericUpDownWindowH.Hexadecimal = true;
            this.numericUpDownWindowH.Location = new System.Drawing.Point(240, 316);
            this.numericUpDownWindowH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWindowH.Name = "numericUpDownWindowH";
            this.numericUpDownWindowH.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWindowH.TabIndex = 60;
            this.numericUpDownWindowH.ValueChanged += new System.EventHandler(this.numericUpDownWindowH_ValueChanged);
            // 
            // numericUpDownWindowW
            // 
            this.numericUpDownWindowW.Enabled = false;
            this.numericUpDownWindowW.Hexadecimal = true;
            this.numericUpDownWindowW.Location = new System.Drawing.Point(195, 316);
            this.numericUpDownWindowW.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWindowW.Name = "numericUpDownWindowW";
            this.numericUpDownWindowW.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWindowW.TabIndex = 59;
            this.numericUpDownWindowW.ValueChanged += new System.EventHandler(this.numericUpDownWindowW_ValueChanged);
            // 
            // numericUpDownWindowY
            // 
            this.numericUpDownWindowY.Enabled = false;
            this.numericUpDownWindowY.Hexadecimal = true;
            this.numericUpDownWindowY.Location = new System.Drawing.Point(150, 316);
            this.numericUpDownWindowY.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWindowY.Name = "numericUpDownWindowY";
            this.numericUpDownWindowY.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWindowY.TabIndex = 58;
            this.numericUpDownWindowY.ValueChanged += new System.EventHandler(this.numericUpDownWindowY_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 57;
            this.label8.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(102, 300);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 56;
            this.labelX.Text = "X";
            // 
            // numericUpDownWindowX
            // 
            this.numericUpDownWindowX.Enabled = false;
            this.numericUpDownWindowX.Hexadecimal = true;
            this.numericUpDownWindowX.Location = new System.Drawing.Point(105, 316);
            this.numericUpDownWindowX.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWindowX.Name = "numericUpDownWindowX";
            this.numericUpDownWindowX.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownWindowX.TabIndex = 55;
            this.numericUpDownWindowX.ValueChanged += new System.EventHandler(this.numericUpDownWindowX_ValueChanged);
            // 
            // labelWindowFunction
            // 
            this.labelWindowFunction.AutoSize = true;
            this.labelWindowFunction.Location = new System.Drawing.Point(205, 11);
            this.labelWindowFunction.Name = "labelWindowFunction";
            this.labelWindowFunction.Size = new System.Drawing.Size(147, 13);
            this.labelWindowFunction.TabIndex = 54;
            this.labelWindowFunction.Text = "Please choose a function row";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Window function";
            // 
            // listViewWindows
            // 
            this.listViewWindows.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewWindows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewWindows.FullRowSelect = true;
            this.listViewWindows.GridLines = true;
            this.listViewWindows.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewWindows.Location = new System.Drawing.Point(3, 35);
            this.listViewWindows.MultiSelect = false;
            this.listViewWindows.Name = "listViewWindows";
            this.listViewWindows.Size = new System.Drawing.Size(199, 261);
            this.listViewWindows.TabIndex = 52;
            this.listViewWindows.UseCompatibleStateImageBehavior = false;
            this.listViewWindows.View = System.Windows.Forms.View.Details;
            this.listViewWindows.SelectedIndexChanged += new System.EventHandler(this.listViewWindows_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 22;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 35;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 22;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 22;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 22;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 22;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 22;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 22;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            this.columnHeader9.Width = 22;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            this.columnHeader10.Width = 120;
            // 
            // comboBoxWindowsMenu
            // 
            this.comboBoxWindowsMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWindowsMenu.FormattingEnabled = true;
            this.comboBoxWindowsMenu.Items.AddRange(new object[] {
            "Main",
            "Abil",
            "Job",
            "Equip",
            "Stats",
            "Store",
            "Item",
            "Magic",
            "Confg",
            "Find",
            "Save",
            "Load",
            "Name",
            "AD4A",
            "AD5D",
            "ADC7",
            "ADD8",
            "AE37",
            "AE53",
            "AE62",
            "AE6D",
            "AE98",
            "AEB0",
            "AEC8",
            "AED9",
            "AF1A",
            "AF2B",
            "B005",
            "B016",
            "B01D",
            "B024",
            "B036",
            "B065",
            "B07D",
            "B185",
            "B195",
            "B1E0",
            "B242",
            "B254",
            "B25F",
            "B26A",
            "B275",
            "B287",
            "B298",
            "B2A9",
            "B2BA",
            "B2CB",
            "B2DC",
            "B2ED",
            "B2FE",
            "B310",
            "B31B",
            "B332",
            "B349",
            "B3A9",
            "B3C2",
            "B3FE",
            "B409",
            "B413",
            "B41E",
            "B429",
            "B499",
            "B4A4",
            "B4AF",
            "B4BF",
            "B4CF",
            "B4D9",
            "B4E3",
            "B4F3",
            "B4FD",
            "B50D",
            "B518",
            "B523",
            "B59E",
            "B5B1",
            "B5B8",
            "B5CF",
            "B5DF",
            "B62B",
            "B710",
            "B739",
            "B740",
            "B7D2",
            "B7E9",
            "B807"});
            this.comboBoxWindowsMenu.Location = new System.Drawing.Point(96, 8);
            this.comboBoxWindowsMenu.Name = "comboBoxWindowsMenu";
            this.comboBoxWindowsMenu.Size = new System.Drawing.Size(106, 21);
            this.comboBoxWindowsMenu.TabIndex = 51;
            this.comboBoxWindowsMenu.SelectedIndexChanged += new System.EventHandler(this.comboBoxWindowsMenu_SelectedIndexChanged);
            // 
            // panelWindowDisplay
            // 
            this.panelWindowDisplay.BackColor = System.Drawing.Color.Black;
            this.panelWindowDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelWindowDisplay.Location = new System.Drawing.Point(208, 35);
            this.panelWindowDisplay.Name = "panelWindowDisplay";
            this.panelWindowDisplay.Size = new System.Drawing.Size(261, 261);
            this.panelWindowDisplay.TabIndex = 0;
            this.panelWindowDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.panelWindowDisplay_Paint);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox8);
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(472, 349);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Miscs";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.buttonExportGenericCompress);
            this.groupBox8.Controls.Add(this.progressBarCompress);
            this.groupBox8.Controls.Add(this.buttonCSVImportStaffFont);
            this.groupBox8.Controls.Add(this.label52);
            this.groupBox8.Controls.Add(this.buttonCSVExportStaffFont);
            this.groupBox8.Controls.Add(this.buttonImageImportGenericCompress);
            this.groupBox8.Controls.Add(this.label55);
            this.groupBox8.Controls.Add(this.textBoxCompressedPlace);
            this.groupBox8.Controls.Add(this.buttonImageImportTheEnd);
            this.groupBox8.Controls.Add(this.label53);
            this.groupBox8.Controls.Add(this.label54);
            this.groupBox8.Controls.Add(this.textBoxCompressedLimit);
            this.groupBox8.Controls.Add(this.buttonImageExportTheEnd);
            this.groupBox8.Controls.Add(this.buttonImageImportDragon);
            this.groupBox8.Controls.Add(this.label51);
            this.groupBox8.Controls.Add(this.buttonImageExportDragon);
            this.groupBox8.Controls.Add(this.buttonCSVImportCredits);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.buttonCSVExportCredits);
            this.groupBox8.Controls.Add(this.label48);
            this.groupBox8.Controls.Add(this.buttonCSVExportStaff);
            this.groupBox8.Controls.Add(this.buttonCSVImportStaff);
            this.groupBox8.Location = new System.Drawing.Point(214, 117);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(255, 229);
            this.groupBox8.TabIndex = 49;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Compressed data";
            // 
            // buttonExportGenericCompress
            // 
            this.buttonExportGenericCompress.Location = new System.Drawing.Point(6, 200);
            this.buttonExportGenericCompress.Name = "buttonExportGenericCompress";
            this.buttonExportGenericCompress.Size = new System.Drawing.Size(63, 23);
            this.buttonExportGenericCompress.TabIndex = 68;
            this.buttonExportGenericCompress.Text = "Get";
            this.buttonExportGenericCompress.UseVisualStyleBackColor = true;
            this.buttonExportGenericCompress.Click += new System.EventHandler(this.buttonExportGenericCompress_Click);
            // 
            // progressBarCompress
            // 
            this.progressBarCompress.Location = new System.Drawing.Point(75, 200);
            this.progressBarCompress.Name = "progressBarCompress";
            this.progressBarCompress.Size = new System.Drawing.Size(105, 23);
            this.progressBarCompress.TabIndex = 56;
            // 
            // buttonCSVImportStaffFont
            // 
            this.buttonCSVImportStaffFont.Location = new System.Drawing.Point(186, 48);
            this.buttonCSVImportStaffFont.Name = "buttonCSVImportStaffFont";
            this.buttonCSVImportStaffFont.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportStaffFont.TabIndex = 67;
            this.buttonCSVImportStaffFont.Text = "Inject";
            this.buttonCSVImportStaffFont.UseVisualStyleBackColor = true;
            this.buttonCSVImportStaffFont.Click += new System.EventHandler(this.buttonCSVImportStaffFont_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 177);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(76, 13);
            this.label52.TabIndex = 57;
            this.label52.Text = "Adressed in 0x";
            // 
            // buttonCSVExportStaffFont
            // 
            this.buttonCSVExportStaffFont.Location = new System.Drawing.Point(105, 48);
            this.buttonCSVExportStaffFont.Name = "buttonCSVExportStaffFont";
            this.buttonCSVExportStaffFont.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportStaffFont.TabIndex = 66;
            this.buttonCSVExportStaffFont.Text = "Get template";
            this.buttonCSVExportStaffFont.UseVisualStyleBackColor = true;
            this.buttonCSVExportStaffFont.Click += new System.EventHandler(this.buttonCSVExportStaffFont_Click);
            // 
            // buttonImageImportGenericCompress
            // 
            this.buttonImageImportGenericCompress.Location = new System.Drawing.Point(186, 200);
            this.buttonImageImportGenericCompress.Name = "buttonImageImportGenericCompress";
            this.buttonImageImportGenericCompress.Size = new System.Drawing.Size(63, 23);
            this.buttonImageImportGenericCompress.TabIndex = 58;
            this.buttonImageImportGenericCompress.Text = "Inject";
            this.buttonImageImportGenericCompress.UseVisualStyleBackColor = true;
            this.buttonImageImportGenericCompress.Click += new System.EventHandler(this.buttonImageImportGenericCompress_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 53);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(50, 13);
            this.label55.TabIndex = 65;
            this.label55.Text = "Staff font";
            // 
            // textBoxCompressedPlace
            // 
            this.textBoxCompressedPlace.Location = new System.Drawing.Point(83, 174);
            this.textBoxCompressedPlace.MaxLength = 6;
            this.textBoxCompressedPlace.Name = "textBoxCompressedPlace";
            this.textBoxCompressedPlace.Size = new System.Drawing.Size(47, 20);
            this.textBoxCompressedPlace.TabIndex = 59;
            this.textBoxCompressedPlace.Text = "000000";
            // 
            // buttonImageImportTheEnd
            // 
            this.buttonImageImportTheEnd.Location = new System.Drawing.Point(186, 135);
            this.buttonImageImportTheEnd.Name = "buttonImageImportTheEnd";
            this.buttonImageImportTheEnd.Size = new System.Drawing.Size(63, 23);
            this.buttonImageImportTheEnd.TabIndex = 64;
            this.buttonImageImportTheEnd.Text = "Inject";
            this.buttonImageImportTheEnd.UseVisualStyleBackColor = true;
            this.buttonImageImportTheEnd.Click += new System.EventHandler(this.buttonImageImportTheEnd_Click);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(151, 177);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(64, 13);
            this.label53.TabIndex = 60;
            this.label53.Text = "# max bytes";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 140);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(48, 13);
            this.label54.TabIndex = 63;
            this.label54.Text = "The End";
            // 
            // textBoxCompressedLimit
            // 
            this.textBoxCompressedLimit.Location = new System.Drawing.Point(215, 174);
            this.textBoxCompressedLimit.MaxLength = 4;
            this.textBoxCompressedLimit.Name = "textBoxCompressedLimit";
            this.textBoxCompressedLimit.Size = new System.Drawing.Size(34, 20);
            this.textBoxCompressedLimit.TabIndex = 61;
            this.textBoxCompressedLimit.Text = "0000";
            // 
            // buttonImageExportTheEnd
            // 
            this.buttonImageExportTheEnd.Location = new System.Drawing.Point(105, 135);
            this.buttonImageExportTheEnd.Name = "buttonImageExportTheEnd";
            this.buttonImageExportTheEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonImageExportTheEnd.TabIndex = 62;
            this.buttonImageExportTheEnd.Text = "Get template";
            this.buttonImageExportTheEnd.UseVisualStyleBackColor = true;
            this.buttonImageExportTheEnd.Click += new System.EventHandler(this.buttonImageExportTheEnd_Click);
            // 
            // buttonImageImportDragon
            // 
            this.buttonImageImportDragon.Location = new System.Drawing.Point(186, 106);
            this.buttonImageImportDragon.Name = "buttonImageImportDragon";
            this.buttonImageImportDragon.Size = new System.Drawing.Size(63, 23);
            this.buttonImageImportDragon.TabIndex = 55;
            this.buttonImageImportDragon.Text = "Inject";
            this.buttonImageImportDragon.UseVisualStyleBackColor = true;
            this.buttonImageImportDragon.Click += new System.EventHandler(this.buttonImageImportDragon_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 111);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 13);
            this.label51.TabIndex = 54;
            this.label51.Text = "Title dragon";
            // 
            // buttonImageExportDragon
            // 
            this.buttonImageExportDragon.Location = new System.Drawing.Point(105, 106);
            this.buttonImageExportDragon.Name = "buttonImageExportDragon";
            this.buttonImageExportDragon.Size = new System.Drawing.Size(75, 23);
            this.buttonImageExportDragon.TabIndex = 53;
            this.buttonImageExportDragon.Text = "Get template";
            this.buttonImageExportDragon.UseVisualStyleBackColor = true;
            this.buttonImageExportDragon.Click += new System.EventHandler(this.buttonImageExportDragon_Click);
            // 
            // buttonCSVImportCredits
            // 
            this.buttonCSVImportCredits.Location = new System.Drawing.Point(186, 77);
            this.buttonCSVImportCredits.Name = "buttonCSVImportCredits";
            this.buttonCSVImportCredits.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportCredits.TabIndex = 52;
            this.buttonCSVImportCredits.Text = "Inject";
            this.buttonCSVImportCredits.UseVisualStyleBackColor = true;
            this.buttonCSVImportCredits.Click += new System.EventHandler(this.buttonCSVImportCredits_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 82);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(39, 13);
            this.label49.TabIndex = 51;
            this.label49.Text = "Credits";
            // 
            // buttonCSVExportCredits
            // 
            this.buttonCSVExportCredits.Location = new System.Drawing.Point(105, 77);
            this.buttonCSVExportCredits.Name = "buttonCSVExportCredits";
            this.buttonCSVExportCredits.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportCredits.TabIndex = 50;
            this.buttonCSVExportCredits.Text = "Get template";
            this.buttonCSVExportCredits.UseVisualStyleBackColor = true;
            this.buttonCSVExportCredits.Click += new System.EventHandler(this.buttonCSVExportCredits_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(29, 13);
            this.label48.TabIndex = 49;
            this.label48.Text = "Staff";
            // 
            // buttonCSVExportStaff
            // 
            this.buttonCSVExportStaff.Location = new System.Drawing.Point(105, 19);
            this.buttonCSVExportStaff.Name = "buttonCSVExportStaff";
            this.buttonCSVExportStaff.Size = new System.Drawing.Size(75, 23);
            this.buttonCSVExportStaff.TabIndex = 47;
            this.buttonCSVExportStaff.Text = "Get template";
            this.buttonCSVExportStaff.UseVisualStyleBackColor = true;
            this.buttonCSVExportStaff.Click += new System.EventHandler(this.buttonCSVExportStaff_Click);
            // 
            // buttonCSVImportStaff
            // 
            this.buttonCSVImportStaff.Location = new System.Drawing.Point(186, 19);
            this.buttonCSVImportStaff.Name = "buttonCSVImportStaff";
            this.buttonCSVImportStaff.Size = new System.Drawing.Size(63, 23);
            this.buttonCSVImportStaff.TabIndex = 48;
            this.buttonCSVImportStaff.Text = "Inject";
            this.buttonCSVImportStaff.UseVisualStyleBackColor = true;
            this.buttonCSVImportStaff.Click += new System.EventHandler(this.buttonCSVImportStaff_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.buttonStoresMenuEnlarge);
            this.groupBox7.Controls.Add(this.comboBoxStoresMenuEnlarge);
            this.groupBox7.Controls.Add(this.buttonMagicMenuEnlarge);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.buttonMenuEnlarge);
            this.groupBox7.Controls.Add(this.comboBoxMenuEnlarge);
            this.groupBox7.Controls.Add(this.comboBoxMagicMenuEnlarge);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Location = new System.Drawing.Point(214, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(255, 108);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Menu extender";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Stores balance width";
            // 
            // buttonStoresMenuEnlarge
            // 
            this.buttonStoresMenuEnlarge.Location = new System.Drawing.Point(186, 79);
            this.buttonStoresMenuEnlarge.Name = "buttonStoresMenuEnlarge";
            this.buttonStoresMenuEnlarge.Size = new System.Drawing.Size(63, 23);
            this.buttonStoresMenuEnlarge.TabIndex = 48;
            this.buttonStoresMenuEnlarge.Text = "Inject";
            this.buttonStoresMenuEnlarge.UseVisualStyleBackColor = true;
            this.buttonStoresMenuEnlarge.Click += new System.EventHandler(this.buttonStoresMenuEnlarge_Click);
            // 
            // comboBoxStoresMenuEnlarge
            // 
            this.comboBoxStoresMenuEnlarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStoresMenuEnlarge.FormattingEnabled = true;
            this.comboBoxStoresMenuEnlarge.Items.AddRange(new object[] {
            "+0",
            "+1",
            "+2",
            "+3"});
            this.comboBoxStoresMenuEnlarge.Location = new System.Drawing.Point(139, 81);
            this.comboBoxStoresMenuEnlarge.Name = "comboBoxStoresMenuEnlarge";
            this.comboBoxStoresMenuEnlarge.Size = new System.Drawing.Size(41, 21);
            this.comboBoxStoresMenuEnlarge.TabIndex = 47;
            // 
            // buttonMagicMenuEnlarge
            // 
            this.buttonMagicMenuEnlarge.Location = new System.Drawing.Point(186, 50);
            this.buttonMagicMenuEnlarge.Name = "buttonMagicMenuEnlarge";
            this.buttonMagicMenuEnlarge.Size = new System.Drawing.Size(63, 23);
            this.buttonMagicMenuEnlarge.TabIndex = 46;
            this.buttonMagicMenuEnlarge.Text = "Inject";
            this.buttonMagicMenuEnlarge.UseVisualStyleBackColor = true;
            this.buttonMagicMenuEnlarge.Click += new System.EventHandler(this.buttonMagicMenuEnlarge_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Main menu add width";
            // 
            // buttonMenuEnlarge
            // 
            this.buttonMenuEnlarge.Location = new System.Drawing.Point(186, 21);
            this.buttonMenuEnlarge.Name = "buttonMenuEnlarge";
            this.buttonMenuEnlarge.Size = new System.Drawing.Size(63, 23);
            this.buttonMenuEnlarge.TabIndex = 42;
            this.buttonMenuEnlarge.Text = "Inject";
            this.buttonMenuEnlarge.UseVisualStyleBackColor = true;
            this.buttonMenuEnlarge.Click += new System.EventHandler(this.buttonMenuEnlarge_Click);
            // 
            // comboBoxMenuEnlarge
            // 
            this.comboBoxMenuEnlarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenuEnlarge.FormattingEnabled = true;
            this.comboBoxMenuEnlarge.Items.AddRange(new object[] {
            "+0",
            "+1",
            "+2"});
            this.comboBoxMenuEnlarge.Location = new System.Drawing.Point(139, 23);
            this.comboBoxMenuEnlarge.Name = "comboBoxMenuEnlarge";
            this.comboBoxMenuEnlarge.Size = new System.Drawing.Size(41, 21);
            this.comboBoxMenuEnlarge.TabIndex = 41;
            // 
            // comboBoxMagicMenuEnlarge
            // 
            this.comboBoxMagicMenuEnlarge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMagicMenuEnlarge.FormattingEnabled = true;
            this.comboBoxMagicMenuEnlarge.Items.AddRange(new object[] {
            "+0",
            "+1",
            "+2"});
            this.comboBoxMagicMenuEnlarge.Location = new System.Drawing.Point(139, 52);
            this.comboBoxMagicMenuEnlarge.Name = "comboBoxMagicMenuEnlarge";
            this.comboBoxMagicMenuEnlarge.Size = new System.Drawing.Size(41, 21);
            this.comboBoxMagicMenuEnlarge.TabIndex = 45;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 55);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(114, 13);
            this.label33.TabIndex = 44;
            this.label33.Text = "Magic menu add width";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.buttonBugFixChecksum);
            this.groupBox6.Controls.Add(this.buttonBugFixAll);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.buttonBugBerserkChicen);
            this.groupBox6.Controls.Add(this.buttonBugCatchMonsterDisplay);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.buttonBugObserve);
            this.groupBox6.Controls.Add(this.buttonBugCatchMonster);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.buttonBugBlueMageSprite);
            this.groupBox6.Controls.Add(this.buttonBugKissOfBlessing);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.buttonBugPowerDrink);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(205, 343);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bugs fixes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Checksum repair";
            // 
            // buttonBugFixChecksum
            // 
            this.buttonBugFixChecksum.Location = new System.Drawing.Point(124, 285);
            this.buttonBugFixChecksum.Name = "buttonBugFixChecksum";
            this.buttonBugFixChecksum.Size = new System.Drawing.Size(75, 23);
            this.buttonBugFixChecksum.TabIndex = 16;
            this.buttonBugFixChecksum.Text = "Fix";
            this.buttonBugFixChecksum.UseVisualStyleBackColor = true;
            this.buttonBugFixChecksum.Click += new System.EventHandler(this.buttonBugFixChecksum_Click);
            // 
            // buttonBugFixAll
            // 
            this.buttonBugFixAll.Location = new System.Drawing.Point(124, 314);
            this.buttonBugFixAll.Name = "buttonBugFixAll";
            this.buttonBugFixAll.Size = new System.Drawing.Size(75, 23);
            this.buttonBugFixAll.TabIndex = 15;
            this.buttonBugFixAll.Text = "Fix";
            this.buttonBugFixAll.UseVisualStyleBackColor = true;
            this.buttonBugFixAll.Click += new System.EventHandler(this.buttonBugFixAll_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(8, 319);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(33, 13);
            this.label47.TabIndex = 14;
            this.label47.Text = "Fix all";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(8, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(116, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Caught monster display";
            // 
            // buttonBugBerserkChicen
            // 
            this.buttonBugBerserkChicen.Location = new System.Drawing.Point(124, 193);
            this.buttonBugBerserkChicen.Name = "buttonBugBerserkChicen";
            this.buttonBugBerserkChicen.Size = new System.Drawing.Size(75, 23);
            this.buttonBugBerserkChicen.TabIndex = 13;
            this.buttonBugBerserkChicen.Text = "Fix";
            this.buttonBugBerserkChicen.UseVisualStyleBackColor = true;
            this.buttonBugBerserkChicen.Click += new System.EventHandler(this.buttonBugBerserkChicen_Click);
            // 
            // buttonBugCatchMonsterDisplay
            // 
            this.buttonBugCatchMonsterDisplay.Location = new System.Drawing.Point(124, 19);
            this.buttonBugCatchMonsterDisplay.Name = "buttonBugCatchMonsterDisplay";
            this.buttonBugCatchMonsterDisplay.Size = new System.Drawing.Size(75, 23);
            this.buttonBugCatchMonsterDisplay.TabIndex = 1;
            this.buttonBugCatchMonsterDisplay.Text = "Fix";
            this.buttonBugCatchMonsterDisplay.UseVisualStyleBackColor = true;
            this.buttonBugCatchMonsterDisplay.Click += new System.EventHandler(this.buttonBugCatchMonsterDisplay_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 198);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(84, 13);
            this.label44.TabIndex = 12;
            this.label44.Text = "Berserk chicken";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(8, 53);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 13);
            this.label35.TabIndex = 2;
            this.label35.Text = "Catch bug";
            // 
            // buttonBugObserve
            // 
            this.buttonBugObserve.Location = new System.Drawing.Point(124, 135);
            this.buttonBugObserve.Name = "buttonBugObserve";
            this.buttonBugObserve.Size = new System.Drawing.Size(75, 23);
            this.buttonBugObserve.TabIndex = 11;
            this.buttonBugObserve.Text = "Fix";
            this.buttonBugObserve.UseVisualStyleBackColor = true;
            this.buttonBugObserve.Click += new System.EventHandler(this.buttonBugObserve_Click);
            // 
            // buttonBugCatchMonster
            // 
            this.buttonBugCatchMonster.Location = new System.Drawing.Point(124, 48);
            this.buttonBugCatchMonster.Name = "buttonBugCatchMonster";
            this.buttonBugCatchMonster.Size = new System.Drawing.Size(75, 23);
            this.buttonBugCatchMonster.TabIndex = 3;
            this.buttonBugCatchMonster.Text = "Fix";
            this.buttonBugCatchMonster.UseVisualStyleBackColor = true;
            this.buttonBugCatchMonster.Click += new System.EventHandler(this.buttonBugCatchMonster_Click);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(8, 140);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(68, 13);
            this.label39.TabIndex = 10;
            this.label39.Text = "Observe bug";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 82);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 13);
            this.label36.TabIndex = 4;
            this.label36.Text = "Kiss of Blessing bug";
            // 
            // buttonBugBlueMageSprite
            // 
            this.buttonBugBlueMageSprite.Location = new System.Drawing.Point(124, 164);
            this.buttonBugBlueMageSprite.Name = "buttonBugBlueMageSprite";
            this.buttonBugBlueMageSprite.Size = new System.Drawing.Size(75, 23);
            this.buttonBugBlueMageSprite.TabIndex = 9;
            this.buttonBugBlueMageSprite.Text = "Fix";
            this.buttonBugBlueMageSprite.UseVisualStyleBackColor = true;
            this.buttonBugBlueMageSprite.Click += new System.EventHandler(this.buttonBugBlueMageSprite_Click);
            // 
            // buttonBugKissOfBlessing
            // 
            this.buttonBugKissOfBlessing.Location = new System.Drawing.Point(124, 77);
            this.buttonBugKissOfBlessing.Name = "buttonBugKissOfBlessing";
            this.buttonBugKissOfBlessing.Size = new System.Drawing.Size(75, 23);
            this.buttonBugKissOfBlessing.TabIndex = 5;
            this.buttonBugKissOfBlessing.Text = "Fix";
            this.buttonBugKissOfBlessing.UseVisualStyleBackColor = true;
            this.buttonBugKissOfBlessing.Click += new System.EventHandler(this.buttonBugKissOfBlessing_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(8, 169);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(85, 13);
            this.label38.TabIndex = 8;
            this.label38.Text = "Blue mage sprite";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(8, 111);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(86, 13);
            this.label37.TabIndex = 6;
            this.label37.Text = "Power Drink bug";
            // 
            // buttonBugPowerDrink
            // 
            this.buttonBugPowerDrink.Location = new System.Drawing.Point(124, 106);
            this.buttonBugPowerDrink.Name = "buttonBugPowerDrink";
            this.buttonBugPowerDrink.Size = new System.Drawing.Size(75, 23);
            this.buttonBugPowerDrink.TabIndex = 7;
            this.buttonBugPowerDrink.Text = "Fix";
            this.buttonBugPowerDrink.UseVisualStyleBackColor = true;
            this.buttonBugPowerDrink.Click += new System.EventHandler(this.buttonBugPowerDrink_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(642, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSMCToolStripMenuItem,
            this.openTBLToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSMCToolStripMenuItem
            // 
            this.openSMCToolStripMenuItem.Name = "openSMCToolStripMenuItem";
            this.openSMCToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openSMCToolStripMenuItem.Text = "Open ROM";
            this.openSMCToolStripMenuItem.Click += new System.EventHandler(this.openSMCToolStripMenuItem_Click);
            // 
            // openTBLToolStripMenuItem
            // 
            this.openTBLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTBL1bppToolStripMenuItem,
            this.loadTBL2bppToolStripMenuItem,
            this.exportTBL1bppToolStripMenuItem,
            this.exportTBL2bppToolStripMenuItem,
            this.loadDefaultTBL1bppToolStripMenuItem,
            this.loadDefaultTBL2bppToolStripMenuItem,
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem,
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem,
            this.toolStripSeparator2,
            this.displayCurrentTBL1bppToolStripMenuItem,
            this.displayCurrentTBL2bppToolStripMenuItem});
            this.openTBLToolStripMenuItem.Name = "openTBLToolStripMenuItem";
            this.openTBLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openTBLToolStripMenuItem.Text = "TBL";
            // 
            // importTBL1bppToolStripMenuItem
            // 
            this.importTBL1bppToolStripMenuItem.Name = "importTBL1bppToolStripMenuItem";
            this.importTBL1bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.importTBL1bppToolStripMenuItem.Text = "Import TBL 1bpp";
            this.importTBL1bppToolStripMenuItem.Click += new System.EventHandler(this.importTBL1bppToolStripMenuItem_Click);
            // 
            // loadTBL2bppToolStripMenuItem
            // 
            this.loadTBL2bppToolStripMenuItem.Name = "loadTBL2bppToolStripMenuItem";
            this.loadTBL2bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.loadTBL2bppToolStripMenuItem.Text = "Import TBL 2bpp";
            this.loadTBL2bppToolStripMenuItem.Click += new System.EventHandler(this.loadTBLToolStripMenuItem_Click);
            // 
            // exportTBL1bppToolStripMenuItem
            // 
            this.exportTBL1bppToolStripMenuItem.Name = "exportTBL1bppToolStripMenuItem";
            this.exportTBL1bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exportTBL1bppToolStripMenuItem.Text = "Export TBL 1bpp";
            this.exportTBL1bppToolStripMenuItem.Click += new System.EventHandler(this.exportTBL1bppToolStripMenuItem_Click);
            // 
            // exportTBL2bppToolStripMenuItem
            // 
            this.exportTBL2bppToolStripMenuItem.Name = "exportTBL2bppToolStripMenuItem";
            this.exportTBL2bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.exportTBL2bppToolStripMenuItem.Text = "Export TBL 2bpp";
            this.exportTBL2bppToolStripMenuItem.Click += new System.EventHandler(this.exportTBLToolStripMenuItem_Click);
            // 
            // loadDefaultTBL1bppToolStripMenuItem
            // 
            this.loadDefaultTBL1bppToolStripMenuItem.Name = "loadDefaultTBL1bppToolStripMenuItem";
            this.loadDefaultTBL1bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.loadDefaultTBL1bppToolStripMenuItem.Text = "Load default TBL 1bpp";
            this.loadDefaultTBL1bppToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultTBL1bppToolStripMenuItem_Click);
            // 
            // loadDefaultTBL2bppToolStripMenuItem
            // 
            this.loadDefaultTBL2bppToolStripMenuItem.Name = "loadDefaultTBL2bppToolStripMenuItem";
            this.loadDefaultTBL2bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.loadDefaultTBL2bppToolStripMenuItem.Text = "Load default TBL 2bpp";
            this.loadDefaultTBL2bppToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultTBLToolStripMenuItem_Click);
            // 
            // setCurrentAsDefaultTBL1bppToolStripMenuItem
            // 
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem.Name = "setCurrentAsDefaultTBL1bppToolStripMenuItem";
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem.Text = "Set current as default TBL 1bpp";
            this.setCurrentAsDefaultTBL1bppToolStripMenuItem.Click += new System.EventHandler(this.setCurrentAsDefaultTBL1bppToolStripMenuItem_Click);
            // 
            // setCurrentAsDefaultTBL2bppToolStripMenuItem
            // 
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem.Name = "setCurrentAsDefaultTBL2bppToolStripMenuItem";
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem.Text = "Set current as default TBL 2bpp";
            this.setCurrentAsDefaultTBL2bppToolStripMenuItem.Click += new System.EventHandler(this.setCurrentAsDefaultTBLToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(235, 6);
            // 
            // displayCurrentTBL1bppToolStripMenuItem
            // 
            this.displayCurrentTBL1bppToolStripMenuItem.Name = "displayCurrentTBL1bppToolStripMenuItem";
            this.displayCurrentTBL1bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.displayCurrentTBL1bppToolStripMenuItem.Text = "Display current TBL 1bpp";
            this.displayCurrentTBL1bppToolStripMenuItem.Click += new System.EventHandler(this.displayCurrentTBL1bppToolStripMenuItem_Click);
            // 
            // displayCurrentTBL2bppToolStripMenuItem
            // 
            this.displayCurrentTBL2bppToolStripMenuItem.Name = "displayCurrentTBL2bppToolStripMenuItem";
            this.displayCurrentTBL2bppToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.displayCurrentTBL2bppToolStripMenuItem.Text = "Display current TBL 2bpp";
            this.displayCurrentTBL2bppToolStripMenuItem.Click += new System.EventHandler(this.displayCurrentTBLToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelFonts
            // 
            this.panelFonts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFonts.BackColor = System.Drawing.Color.Black;
            this.panelFonts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFonts.Location = new System.Drawing.Point(498, 74);
            this.panelFonts.Name = "panelFonts";
            this.panelFonts.Size = new System.Drawing.Size(133, 305);
            this.panelFonts.TabIndex = 4;
            this.panelFonts.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFonts_Paint);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(578, 58);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "1bpp font";
            // 
            // checkBoxShowWidths
            // 
            this.checkBoxShowWidths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowWidths.AutoSize = true;
            this.checkBoxShowWidths.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxShowWidths.Checked = true;
            this.checkBoxShowWidths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowWidths.Location = new System.Drawing.Point(537, 385);
            this.checkBoxShowWidths.Name = "checkBoxShowWidths";
            this.checkBoxShowWidths.Size = new System.Drawing.Size(93, 17);
            this.checkBoxShowWidths.TabIndex = 9;
            this.checkBoxShowWidths.Text = "Display widths";
            this.checkBoxShowWidths.UseVisualStyleBackColor = true;
            this.checkBoxShowWidths.CheckedChanged += new System.EventHandler(this.checkBoxShowWidths_CheckedChanged);
            // 
            // buttonDummy
            // 
            this.buttonDummy.Location = new System.Drawing.Point(394, 3);
            this.buttonDummy.Name = "buttonDummy";
            this.buttonDummy.Size = new System.Drawing.Size(75, 23);
            this.buttonDummy.TabIndex = 71;
            this.buttonDummy.Text = "IPS Table";
            this.buttonDummy.UseVisualStyleBackColor = true;
            this.buttonDummy.Click += new System.EventHandler(this.buttonDummy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 426);
            this.Controls.Add(this.checkBoxShowWidths);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panelFonts);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FF5e_Text_Editor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdSpeech)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowX)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ListView listViewTextWidths;
        private System.Windows.Forms.ColumnHeader FirstColumn;
        private System.Windows.Forms.ColumnHeader columnHeader00;
        private System.Windows.Forms.ColumnHeader columnHeader01;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader02;
        private System.Windows.Forms.ColumnHeader columnHeader03;
        private System.Windows.Forms.ColumnHeader columnHeader04;
        private System.Windows.Forms.ColumnHeader columnHeader05;
        private System.Windows.Forms.ColumnHeader columnHeader06;
        private System.Windows.Forms.ColumnHeader columnHeader07;
        private System.Windows.Forms.ColumnHeader columnHeader08;
        private System.Windows.Forms.ColumnHeader columnHeader09;
        private System.Windows.Forms.ColumnHeader columnHeader0A;
        private System.Windows.Forms.ColumnHeader columnHeader0B;
        private System.Windows.Forms.ColumnHeader columnHeader0C;
        private System.Windows.Forms.ColumnHeader columnHeader0D;
        private System.Windows.Forms.ColumnHeader columnHeader0E;
        private System.Windows.Forms.ColumnHeader columnHeader0F;
        private System.Windows.Forms.ToolStripMenuItem openSMCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTBLToolStripMenuItem;
        private System.Windows.Forms.Button buttonCSVExportConcepts;
        private System.Windows.Forms.Button buttonCSVExportCharacters;
        private System.Windows.Forms.Button buttonCSVExportItems;
        private System.Windows.Forms.Button buttonCSVExportCommands;
        private System.Windows.Forms.Button buttonCSVExportSkillsB;
        private System.Windows.Forms.Button buttonCSVExportSkillsM;
        private System.Windows.Forms.Button buttonCSVExportMonsterAttacks;
        private System.Windows.Forms.Button buttonCSVExportMonsters;
        private System.Windows.Forms.Label labelMonsters;
        private System.Windows.Forms.Label labelMonAttacks;
        private System.Windows.Forms.Label labelSkillsM;
        private System.Windows.Forms.Label labelSkillsB;
        private System.Windows.Forms.Label labelCommands;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Label labelConcepts;
        private System.Windows.Forms.Button buttonCSVExportSpeech;
        private System.Windows.Forms.Button buttonCSVExportConceptsV;
        private System.Windows.Forms.Button buttonCSVExportLocations;
        private System.Windows.Forms.Button buttonCSVExportJobsDesc;
        private System.Windows.Forms.Button buttonCSVExportItempDesc;
        private System.Windows.Forms.Button buttonCSVExportBattleMsg;
        private System.Windows.Forms.Button buttonCSVExportBattleSpeech;
        private System.Windows.Forms.Label labelBattleSpeech;
        private System.Windows.Forms.Label labelBattleMsg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelLocations;
        private System.Windows.Forms.Label labelConceptsVar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button buttonCSVImportConcepts;
        private System.Windows.Forms.Button buttonCSVImportCharacters;
        private System.Windows.Forms.Button buttonCSVImportItems;
        private System.Windows.Forms.Button buttonCSVImportCommands;
        private System.Windows.Forms.Button buttonCSVImportSkillsB;
        private System.Windows.Forms.Button buttonCSVImportSkillsM;
        private System.Windows.Forms.Button buttonCSVImportMonsterAttacks;
        private System.Windows.Forms.Button buttonCSVImportMonsters;
        private System.Windows.Forms.Button buttonCSVImportSpeech;
        private System.Windows.Forms.Button buttonCSVImportConceptsV;
        private System.Windows.Forms.Button buttonCSVImportLocations;
        private System.Windows.Forms.Button buttonCSVImportJobsDesc;
        private System.Windows.Forms.Button buttonCSVImportItempDesc;
        private System.Windows.Forms.Button buttonCSVImportBattleMsg;
        private System.Windows.Forms.Button buttonCSVImportBattleSpeech;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button2bppFontImport;
        private System.Windows.Forms.Button button1bppFontImport;
        private System.Windows.Forms.Button button2bppFontExport;
        private System.Windows.Forms.Button button1bppFontExport;
        private System.Windows.Forms.Button buttonUpdateWidths;
        private System.Windows.Forms.Button buttonLoadWidths;
        private System.Windows.Forms.Button buttonSaveWidths;
        private System.Windows.Forms.Button buttonMenuEnlarge;
        private System.Windows.Forms.ComboBox comboBoxMenuEnlarge;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private Form1.BufferPanel panel2bpp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonWindowsInfo;
        private System.Windows.Forms.TextBox textBoxWindowInfoAddress;
        private System.Windows.Forms.TextBox textBoxWindowInfo;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonWindowsCtrl;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxWinGrouping;
        private System.Windows.Forms.CheckBox checkBoxShowWidths;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMiscTextInjectPause;
        private System.Windows.Forms.Button buttonMiscTextInjectAny;
        private System.Windows.Forms.Button buttonMiscTextInjectMaster;
        private System.Windows.Forms.Button buttonMiscTextInjectEqp;
        private System.Windows.Forms.Button buttonMiscTextInjectDef;
        private System.Windows.Forms.Button buttonMiscTextInjectDefense;
        private System.Windows.Forms.Button buttonMiscTextInjectEmpty;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxMiscTextPause;
        private System.Windows.Forms.TextBox textBoxMiscTextAny;
        private System.Windows.Forms.TextBox textBoxMiscTextMaster;
        private System.Windows.Forms.TextBox textBoxMiscTextEmpty;
        private System.Windows.Forms.TextBox textBoxMiscTextEqp;
        private System.Windows.Forms.TextBox textBoxMiscTextDef;
        private System.Windows.Forms.TextBox textBoxMiscTextDefense;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonMiscTextInjectL;
        private System.Windows.Forms.Button buttonMiscTextInjectLv;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox textBoxMiscTextL;
        private System.Windows.Forms.TextBox textBoxMiscTextLv;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button buttonMiscTextUsesMP;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxMiscTextUsesMP;
        private System.Windows.Forms.Button buttonMagicMenuEnlarge;
        private System.Windows.Forms.ComboBox comboBoxMagicMenuEnlarge;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button buttonBugCatchMonsterDisplay;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button buttonBugBlueMageSprite;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button buttonBugPowerDrink;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button buttonBugKissOfBlessing;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button buttonBugCatchMonster;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button buttonBugObserve;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBoxSubSpeech;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.NumericUpDown numericUpDownIdSpeech;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonCSVImportNaming;
        private System.Windows.Forms.Button buttonCSVExportNamingTemplate;
        private System.Windows.Forms.Label label42;
        private Form1.BufferPanel panelFonts;
        private Form1.BufferPanel panelMainSpeech;
        private System.Windows.Forms.Button buttonNamingDeleteABC;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button buttonBugBerserkChicen;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label labelSubsSpeech;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button buttonPoemOfLightFontImport;
        private System.Windows.Forms.Button buttonPoemOfLightFontExport;
        private System.Windows.Forms.ComboBox comboBox1bppFont;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button buttonCSVExportPOL;
        private System.Windows.Forms.Button buttonCSVImportPOL;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTBL2bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTBL2bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultTBL2bppToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ToolStripMenuItem setCurrentAsDefaultTBL2bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem displayCurrentTBL2bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button buttonCSVExportStaff;
        private System.Windows.Forms.Button buttonCSVImportStaff;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Button buttonCSVExportCredits;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button buttonCSVImportCredits;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox textBoxMiscTextExp;
        private System.Windows.Forms.TextBox textBoxMiscTextMP;
        private System.Windows.Forms.Button buttonMiscTextHpMpExp;
        private System.Windows.Forms.TextBox textBoxMiscTextHP;
        private System.Windows.Forms.Button buttonEditSpeech;
        private System.Windows.Forms.Button buttonImageImportDragon;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Button buttonImageExportDragon;
        private System.Windows.Forms.ProgressBar progressBarCompress;
        private System.Windows.Forms.TextBox textBoxCompressedLimit;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox textBoxCompressedPlace;
        private System.Windows.Forms.Button buttonImageImportGenericCompress;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button buttonImageImportTheEnd;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button buttonImageExportTheEnd;
        private System.Windows.Forms.Button buttonCSVExportStaffFont;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button buttonCSVImportStaffFont;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox textBoxSynchroIndexInject;
        private System.Windows.Forms.Button buttonSynchroIndexInject;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button buttonMuteExport;
        private System.Windows.Forms.Button buttonMuteImport;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button buttonOtherFontExport;
        private System.Windows.Forms.Button buttonOtherFontImport;
        private System.Windows.Forms.Button buttonDamageFontExport;
        private System.Windows.Forms.Button buttonDamageFontImport;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button buttonExportGenericCompress;
        private System.Windows.Forms.GroupBox groupBox11;
        private Form1.BufferPanel panelMuteSpell;
        private System.Windows.Forms.Button buttonBugFixAll;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ToolStripMenuItem importTBL1bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportTBL1bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultTBL1bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCurrentAsDefaultTBL1bppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayCurrentTBL1bppToolStripMenuItem;
        private System.Windows.Forms.Button buttonEveryDraw;
        private System.Windows.Forms.Button buttonSRAM;
        private System.Windows.Forms.Button buttonMiscTextSell;
        private System.Windows.Forms.Button buttonBugFixChecksum;
        private System.Windows.Forms.TextBox textBoxMiscTextSell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonStoresMenuEnlarge;
        private System.Windows.Forms.ComboBox comboBoxStoresMenuEnlarge;
        private System.Windows.Forms.TabPage tabPage7;
        private Form1.BufferPanel panelWindowDisplay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewWindows;
        private System.Windows.Forms.ComboBox comboBoxWindowsMenu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label labelWindowFunction;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowT;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowH;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowW;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowX;
        private System.Windows.Forms.TextBox textBoxWindowAddress;
        private System.Windows.Forms.TextBox textBoxWindowFunction;
        private System.Windows.Forms.CheckBox checkBoxDisplayW2;
        private System.Windows.Forms.CheckBox checkBoxDisplayW1;
        private System.Windows.Forms.CheckBox checkBoxDisplayW0;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Button buttonDummy;
    }
}

