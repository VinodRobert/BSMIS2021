namespace BSMIS 
{
    partial class frmMasterDump
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblPeriod = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblSearch = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFromPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.listLedgers = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkCreditor = new System.Windows.Forms.CheckBox();
            this.listZone = new System.Windows.Forms.CheckedListBox();
            this.listProject = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkProject = new System.Windows.Forms.CheckBox();
            this.chkUnchkZone = new System.Windows.Forms.CheckBox();
            this.txtSearchCreditor = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggDetail = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.cmbToLedgerCode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFromLedgerCode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridLedgerSelection = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnAddList = new System.Windows.Forms.Button();
            this.txtLedgerCodesCommaSeperated = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddRange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseMore = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbFromYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbToPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbToYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkCreditors = new System.Windows.Forms.CheckBox();
            this.chkSubContractors = new System.Windows.Forms.CheckBox();
            this.chkDebtors = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToLedgerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromLedgerCode)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(488, 0);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(216, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Master Dump";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(5, 125);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(103, 17);
            this.lblPeriod.TabIndex = 1;
            this.lblPeriod.Text = "From Period";
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(325, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(91, 17);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search .....";
            // 
            // autoLabel5
            // 
            this.autoLabel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel5.Location = new System.Drawing.Point(793, 31);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(47, 17);
            this.autoLabel5.TabIndex = 7;
            this.autoLabel5.Text = "Zone";
            // 
            // lblProject
            // 
            this.lblProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(953, 31);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(64, 17);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Project";
            // 
            // cmbFromPeriod
            // 
            this.cmbFromPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromPeriod.BeforeTouchSize = new System.Drawing.Size(107, 25);
            this.cmbFromPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromPeriod.Location = new System.Drawing.Point(106, 125);
            this.cmbFromPeriod.Name = "cmbFromPeriod";
            this.cmbFromPeriod.Size = new System.Drawing.Size(107, 25);
            this.cmbFromPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromPeriod.TabIndex = 17;
            this.cmbFromPeriod.Text = "comboBoxAdv1";
            this.cmbFromPeriod.ThemeName = "Office2007";
            // 
            // listLedgers
            // 
            this.listLedgers.CheckOnClick = true;
            this.listLedgers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLedgers.FormattingEnabled = true;
            this.listLedgers.Location = new System.Drawing.Point(325, 67);
            this.listLedgers.Name = "listLedgers";
            this.listLedgers.ScrollAlwaysVisible = true;
            this.listLedgers.Size = new System.Drawing.Size(458, 156);
            this.listLedgers.TabIndex = 24;
            // 
            // chkUnChkCreditor
            // 
            this.chkUnChkCreditor.AutoSize = true;
            this.chkUnChkCreditor.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkCreditor.Location = new System.Drawing.Point(688, 31);
            this.chkUnChkCreditor.Name = "chkUnChkCreditor";
            this.chkUnChkCreditor.Size = new System.Drawing.Size(114, 21);
            this.chkUnChkCreditor.TabIndex = 25;
            this.chkUnChkCreditor.Text = "Check/Un Check";
            this.chkUnChkCreditor.UseVisualStyleBackColor = true;
            this.chkUnChkCreditor.CheckedChanged += new System.EventHandler(this.chkUnChkCreditor_CheckedChanged);
            // 
            // listZone
            // 
            this.listZone.CheckOnClick = true;
            this.listZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listZone.FormattingEnabled = true;
            this.listZone.Location = new System.Drawing.Point(793, 51);
            this.listZone.Name = "listZone";
            this.listZone.ScrollAlwaysVisible = true;
            this.listZone.Size = new System.Drawing.Size(131, 175);
            this.listZone.TabIndex = 26;
            this.listZone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listZone_MouseUp);
            // 
            // listProject
            // 
            this.listProject.CheckOnClick = true;
            this.listProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProject.FormattingEnabled = true;
            this.listProject.Location = new System.Drawing.Point(931, 50);
            this.listProject.Name = "listProject";
            this.listProject.ScrollAlwaysVisible = true;
            this.listProject.Size = new System.Drawing.Size(337, 175);
            this.listProject.TabIndex = 27;
            // 
            // chkUnChkProject
            // 
            this.chkUnChkProject.AutoSize = true;
            this.chkUnChkProject.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkProject.Location = new System.Drawing.Point(1177, 31);
            this.chkUnChkProject.Name = "chkUnChkProject";
            this.chkUnChkProject.Size = new System.Drawing.Size(114, 21);
            this.chkUnChkProject.TabIndex = 29;
            this.chkUnChkProject.Text = "Check/Un Check";
            this.chkUnChkProject.UseVisualStyleBackColor = true;
            this.chkUnChkProject.CheckedChanged += new System.EventHandler(this.chkUnChkProject_CheckedChanged);
            // 
            // chkUnchkZone
            // 
            this.chkUnchkZone.AutoSize = true;
            this.chkUnchkZone.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnchkZone.Location = new System.Drawing.Point(833, 31);
            this.chkUnchkZone.Name = "chkUnchkZone";
            this.chkUnchkZone.Size = new System.Drawing.Size(114, 21);
            this.chkUnchkZone.TabIndex = 30;
            this.chkUnchkZone.Text = "Check/Un Check";
            this.chkUnchkZone.UseVisualStyleBackColor = true;
            this.chkUnchkZone.CheckedChanged += new System.EventHandler(this.chkUnchkZone_CheckedChanged);
            // 
            // txtSearchCreditor
            // 
            this.txtSearchCreditor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCreditor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearchCreditor.Location = new System.Drawing.Point(325, 43);
            this.txtSearchCreditor.Name = "txtSearchCreditor";
            this.txtSearchCreditor.Size = new System.Drawing.Size(357, 23);
            this.txtSearchCreditor.TabIndex = 35;
            this.txtSearchCreditor.TextChanged += new System.EventHandler(this.txtSearchCreditor_TextChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(219, 135);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 38);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.Location = new System.Drawing.Point(219, 176);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 36);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "Excel ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(219, 88);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 41);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggDetail);
            this.panel1.Location = new System.Drawing.Point(5, 234);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 355);
            this.panel1.TabIndex = 41;
            // 
            // ggDetail
            // 
            this.ggDetail.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggDetail.BackColor = System.Drawing.SystemColors.Window;
            this.ggDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggDetail.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggDetail.Location = new System.Drawing.Point(0, 0);
            this.ggDetail.Name = "ggDetail";
            this.ggDetail.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggDetail.Size = new System.Drawing.Size(1267, 355);
            this.ggDetail.TabIndex = 1;
            this.ggDetail.Text = "gridGroupingControl1";
            this.ggDetail.UseRightToLeftCompatibleTextBox = true;
            this.ggDetail.VersionInfo = "9.403.0.62";
            // 
            // cmbToLedgerCode
            // 
            this.cmbToLedgerCode.BackColor = System.Drawing.SystemColors.Control;
            this.cmbToLedgerCode.BeforeTouchSize = new System.Drawing.Size(121, 24);
            this.cmbToLedgerCode.Location = new System.Drawing.Point(0, 0);
            this.cmbToLedgerCode.Name = "cmbToLedgerCode";
            this.cmbToLedgerCode.Size = new System.Drawing.Size(121, 21);
            this.cmbToLedgerCode.TabIndex = 0;
            // 
            // cmbFromLedgerCode
            // 
            this.cmbFromLedgerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromLedgerCode.BeforeTouchSize = new System.Drawing.Size(512, 25);
            this.cmbFromLedgerCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromLedgerCode.Items.AddRange(new object[] {
            " "});
            this.cmbFromLedgerCode.Location = new System.Drawing.Point(106, 34);
            this.cmbFromLedgerCode.Name = "cmbFromLedgerCode";
            this.cmbFromLedgerCode.Size = new System.Drawing.Size(512, 25);
            this.cmbFromLedgerCode.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromLedgerCode.TabIndex = 57;
            this.cmbFromLedgerCode.ThemeName = "Office2007";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridLedgerSelection);
            this.panel2.Location = new System.Drawing.Point(7, 225);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(648, 149);
            this.panel2.TabIndex = 7;
            // 
            // gridLedgerSelection
            // 
            this.gridLedgerSelection.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.gridLedgerSelection.BackColor = System.Drawing.SystemColors.Window;
            this.gridLedgerSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLedgerSelection.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.gridLedgerSelection.Location = new System.Drawing.Point(0, 0);
            this.gridLedgerSelection.Name = "gridLedgerSelection";
            this.gridLedgerSelection.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridLedgerSelection.Size = new System.Drawing.Size(648, 149);
            this.gridLedgerSelection.TabIndex = 1;
            this.gridLedgerSelection.UseRightToLeftCompatibleTextBox = true;
            this.gridLedgerSelection.VersionInfo = "9.403.0.62";
            // 
            // btnAddList
            // 
            this.btnAddList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddList.Location = new System.Drawing.Point(661, 144);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(91, 23);
            this.btnAddList.TabIndex = 6;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            // 
            // txtLedgerCodesCommaSeperated
            // 
            this.txtLedgerCodesCommaSeperated.Location = new System.Drawing.Point(4, 124);
            this.txtLedgerCodesCommaSeperated.Multiline = true;
            this.txtLedgerCodesCommaSeperated.Name = "txtLedgerCodesCommaSeperated";
            this.txtLedgerCodesCommaSeperated.Size = new System.Drawing.Size(651, 81);
            this.txtLedgerCodesCommaSeperated.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 14);
            this.label3.TabIndex = 4;
            // 
            // btnAddRange
            // 
            this.btnAddRange.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRange.Location = new System.Drawing.Point(661, 57);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(91, 23);
            this.btnAddRange.TabIndex = 3;
            this.btnAddRange.Text = "Add Range";
            this.btnAddRange.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 1;
            // 
            // btnCloseMore
            // 
            this.btnCloseMore.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseMore.Location = new System.Drawing.Point(661, 3);
            this.btnCloseMore.Name = "btnCloseMore";
            this.btnCloseMore.Size = new System.Drawing.Size(91, 23);
            this.btnCloseMore.TabIndex = 0;
            this.btnCloseMore.Text = "Close";
            this.btnCloseMore.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerate.Location = new System.Drawing.Point(219, 40);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 42);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbFromYear
            // 
            this.cmbFromYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromYear.BeforeTouchSize = new System.Drawing.Size(79, 25);
            this.cmbFromYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromYear.Location = new System.Drawing.Point(134, 88);
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Size = new System.Drawing.Size(79, 25);
            this.cmbFromYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromYear.TabIndex = 53;
            this.cmbFromYear.Text = "comboBoxAdv1";
            this.cmbFromYear.ThemeName = "Office2007";
            this.cmbFromYear.SelectedIndexChanged += new System.EventHandler(this.cmbFinYear_SelectedIndexChanged);
            this.cmbFromYear.SelectionChangeCommitted += new System.EventHandler(this.cmbFinYear_SelectionChangeCommitted);
            // 
            // cmbToPeriod
            // 
            this.cmbToPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToPeriod.BeforeTouchSize = new System.Drawing.Size(128, 25);
            this.cmbToPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToPeriod.Location = new System.Drawing.Point(85, 195);
            this.cmbToPeriod.Name = "cmbToPeriod";
            this.cmbToPeriod.Size = new System.Drawing.Size(128, 25);
            this.cmbToPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToPeriod.TabIndex = 55;
            this.cmbToPeriod.Text = "comboBoxAdv1";
            this.cmbToPeriod.ThemeName = "Office2007";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(5, 88);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(88, 17);
            this.autoLabel1.TabIndex = 57;
            this.autoLabel1.Text = "From Year";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(5, 156);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(73, 17);
            this.autoLabel2.TabIndex = 58;
            this.autoLabel2.Text = "To  Year";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(5, 195);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(83, 17);
            this.autoLabel3.TabIndex = 59;
            this.autoLabel3.Text = "To Period";
            // 
            // cmbToYear
            // 
            this.cmbToYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToYear.BeforeTouchSize = new System.Drawing.Size(79, 25);
            this.cmbToYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToYear.Location = new System.Drawing.Point(134, 156);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(79, 25);
            this.cmbToYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToYear.TabIndex = 60;
            this.cmbToYear.Text = "comboBoxAdv1";
            this.cmbToYear.ThemeName = "Office2007";
            // 
            // chkCreditors
            // 
            this.chkCreditors.AutoSize = true;
            this.chkCreditors.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCreditors.Location = new System.Drawing.Point(5, 4);
            this.chkCreditors.Name = "chkCreditors";
            this.chkCreditors.Size = new System.Drawing.Size(95, 21);
            this.chkCreditors.TabIndex = 61;
            this.chkCreditors.Text = "Creditors";
            this.chkCreditors.UseVisualStyleBackColor = true;
            this.chkCreditors.CheckedChanged += new System.EventHandler(this.chkCreditors_CheckedChanged);
            // 
            // chkSubContractors
            // 
            this.chkSubContractors.AutoSize = true;
            this.chkSubContractors.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubContractors.Location = new System.Drawing.Point(5, 23);
            this.chkSubContractors.Name = "chkSubContractors";
            this.chkSubContractors.Size = new System.Drawing.Size(149, 21);
            this.chkSubContractors.TabIndex = 62;
            this.chkSubContractors.Text = "Sub-Contractors";
            this.chkSubContractors.UseVisualStyleBackColor = true;
            this.chkSubContractors.CheckedChanged += new System.EventHandler(this.chkSubContractors_CheckedChanged);
            // 
            // chkDebtors
            // 
            this.chkDebtors.AutoSize = true;
            this.chkDebtors.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDebtors.Location = new System.Drawing.Point(5, 45);
            this.chkDebtors.Name = "chkDebtors";
            this.chkDebtors.Size = new System.Drawing.Size(87, 21);
            this.chkDebtors.TabIndex = 63;
            this.chkDebtors.Text = "Debtors";
            this.chkDebtors.UseVisualStyleBackColor = true;
            this.chkDebtors.CheckedChanged += new System.EventHandler(this.chkDebtors_CheckedChanged);
            // 
            // frmMasterDump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.chkDebtors);
            this.Controls.Add(this.chkSubContractors);
            this.Controls.Add(this.chkCreditors);
            this.Controls.Add(this.cmbToYear);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.cmbToPeriod);
            this.Controls.Add(this.cmbFromYear);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearchCreditor);
            this.Controls.Add(this.chkUnchkZone);
            this.Controls.Add(this.chkUnChkProject);
            this.Controls.Add(this.listProject);
            this.Controls.Add(this.listZone);
            this.Controls.Add(this.chkUnChkCreditor);
            this.Controls.Add(this.listLedgers);
            this.Controls.Add(this.cmbFromPeriod);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMasterDump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Dump";
            this.Load += new System.EventHandler(this.frmCreditorAge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToLedgerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromLedgerCode)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPeriod;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblSearch;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromPeriod;
        private System.Windows.Forms.CheckedListBox listLedgers;
        private System.Windows.Forms.CheckBox chkUnChkCreditor;
        private System.Windows.Forms.CheckedListBox listZone;
        private System.Windows.Forms.CheckedListBox listProject;
        private System.Windows.Forms.CheckBox chkUnChkProject;
        private System.Windows.Forms.CheckBox chkUnchkZone;
        private System.Windows.Forms.TextBox txtSearchCreditor;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToPeriod;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Button btnCloseMore;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToLedgerCode;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromLedgerCode;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridLedgerSelection;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.TextBox txtLedgerCodesCommaSeperated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToYear;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggDetail;
        private System.Windows.Forms.CheckBox chkCreditors;
        private System.Windows.Forms.CheckBox chkSubContractors;
        private System.Windows.Forms.CheckBox chkDebtors;
    }
}