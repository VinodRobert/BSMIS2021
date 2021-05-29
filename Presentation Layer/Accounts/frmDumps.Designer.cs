namespace BSMIS 
{
    partial class frmDumps
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
            this.lblPeriodFrom = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblSearch = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFromPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
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
            this.panelMoreSelectionCriteria = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
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
            this.ggDetail = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbDumpOf = new System.Windows.Forms.GroupBox();
            this.rdTransaction = new System.Windows.Forms.RadioButton();
            this.rdLedger = new System.Windows.Forms.RadioButton();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.rdPeriod = new System.Windows.Forms.RadioButton();
            this.rdDateRange = new System.Windows.Forms.RadioButton();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.cmbToPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkMoreSelection = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelMoreSelectionCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToLedgerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromLedgerCode)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).BeginInit();
            this.gbDumpOf.SuspendLayout();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(484, 3);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(233, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Ledger Dumps";
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodFrom.Location = new System.Drawing.Point(114, 50);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(89, 17);
            this.lblPeriodFrom.TabIndex = 1;
            this.lblPeriodFrom.Text = "For Period";
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(325, 31);
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
            this.lblProject.Location = new System.Drawing.Point(931, 31);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(64, 17);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Project";
            // 
            // cmbFromPeriod
            // 
            this.cmbFromPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromPeriod.BeforeTouchSize = new System.Drawing.Size(120, 25);
            this.cmbFromPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromPeriod.Location = new System.Drawing.Point(114, 68);
            this.cmbFromPeriod.Name = "cmbFromPeriod";
            this.cmbFromPeriod.Size = new System.Drawing.Size(120, 25);
            this.cmbFromPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromPeriod.TabIndex = 17;
            this.cmbFromPeriod.Text = "comboBoxAdv1";
            this.cmbFromPeriod.ThemeName = "Office2007";
            // 
            // dtToDate
            // 
            this.dtToDate.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToDate.Location = new System.Drawing.Point(111, 156);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(106, 24);
            this.dtToDate.TabIndex = 22;
            // 
            // listLedgers
            // 
            this.listLedgers.CheckOnClick = true;
            this.listLedgers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLedgers.FormattingEnabled = true;
            this.listLedgers.Location = new System.Drawing.Point(325, 67);
            this.listLedgers.Name = "listLedgers";
            this.listLedgers.ScrollAlwaysVisible = true;
            this.listLedgers.Size = new System.Drawing.Size(458, 99);
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
            this.listZone.Size = new System.Drawing.Size(131, 137);
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
            this.listProject.Size = new System.Drawing.Size(337, 137);
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
            this.txtSearchCreditor.Location = new System.Drawing.Point(325, 47);
            this.txtSearchCreditor.Name = "txtSearchCreditor";
            this.txtSearchCreditor.Size = new System.Drawing.Size(357, 23);
            this.txtSearchCreditor.TabIndex = 35;
            this.txtSearchCreditor.TextChanged += new System.EventHandler(this.txtSearchCreditor_TextChanged);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(240, 107);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 27);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.Location = new System.Drawing.Point(240, 150);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 27);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "Excel ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(240, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMoreSelectionCriteria);
            this.panel1.Controls.Add(this.ggDetail);
            this.panel1.Location = new System.Drawing.Point(5, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 401);
            this.panel1.TabIndex = 41;
            // 
            // panelMoreSelectionCriteria
            // 
            this.panelMoreSelectionCriteria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMoreSelectionCriteria.Controls.Add(this.btnClear);
            this.panelMoreSelectionCriteria.Controls.Add(this.autoLabel2);
            this.panelMoreSelectionCriteria.Controls.Add(this.cmbToLedgerCode);
            this.panelMoreSelectionCriteria.Controls.Add(this.cmbFromLedgerCode);
            this.panelMoreSelectionCriteria.Controls.Add(this.panel2);
            this.panelMoreSelectionCriteria.Controls.Add(this.btnAddList);
            this.panelMoreSelectionCriteria.Controls.Add(this.txtLedgerCodesCommaSeperated);
            this.panelMoreSelectionCriteria.Controls.Add(this.label3);
            this.panelMoreSelectionCriteria.Controls.Add(this.btnAddRange);
            this.panelMoreSelectionCriteria.Controls.Add(this.label2);
            this.panelMoreSelectionCriteria.Controls.Add(this.label1);
            this.panelMoreSelectionCriteria.Controls.Add(this.btnCloseMore);
            this.panelMoreSelectionCriteria.Location = new System.Drawing.Point(254, 6);
            this.panelMoreSelectionCriteria.Name = "panelMoreSelectionCriteria";
            this.panelMoreSelectionCriteria.Size = new System.Drawing.Size(758, 389);
            this.panelMoreSelectionCriteria.TabIndex = 2;
            this.panelMoreSelectionCriteria.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnClear.Location = new System.Drawing.Point(661, 225);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 23);
            this.btnClear.TabIndex = 60;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.ForeColor = System.Drawing.Color.Red;
            this.autoLabel2.Location = new System.Drawing.Point(295, 3);
            this.autoLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(169, 17);
            this.autoLabel2.TabIndex = 59;
            this.autoLabel2.Text = "Additional Selections";
            // 
            // cmbToLedgerCode
            // 
            this.cmbToLedgerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToLedgerCode.BeforeTouchSize = new System.Drawing.Size(512, 25);
            this.cmbToLedgerCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToLedgerCode.Items.AddRange(new object[] {
            "Trial Balance",
            "Profit and Loss",
            "Ledger Code",
            "Creditors",
            "Sub Contractors",
            "Debtors",
            " "});
            this.cmbToLedgerCode.Location = new System.Drawing.Point(106, 66);
            this.cmbToLedgerCode.Name = "cmbToLedgerCode";
            this.cmbToLedgerCode.Size = new System.Drawing.Size(512, 25);
            this.cmbToLedgerCode.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToLedgerCode.TabIndex = 58;
            this.cmbToLedgerCode.Text = "comboBoxAdv2";
            this.cmbToLedgerCode.ThemeName = "Office2007";
            // 
            // cmbFromLedgerCode
            // 
            this.cmbFromLedgerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromLedgerCode.BeforeTouchSize = new System.Drawing.Size(512, 25);
            this.cmbFromLedgerCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromLedgerCode.Items.AddRange(new object[] {
            "Trial Balance",
            "Profit and Loss",
            "Ledger Code",
            "Creditors",
            "Sub Contractors",
            "Debtors",
            " "});
            this.cmbFromLedgerCode.Location = new System.Drawing.Point(106, 34);
            this.cmbFromLedgerCode.Name = "cmbFromLedgerCode";
            this.cmbFromLedgerCode.Size = new System.Drawing.Size(512, 25);
            this.cmbFromLedgerCode.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromLedgerCode.TabIndex = 57;
            this.cmbFromLedgerCode.Text = "comboBoxAdv1";
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
            this.gridLedgerSelection.BackColor = System.Drawing.SystemColors.Window;
            this.gridLedgerSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLedgerSelection.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.gridLedgerSelection.Location = new System.Drawing.Point(0, 0);
            this.gridLedgerSelection.Name = "gridLedgerSelection";
            this.gridLedgerSelection.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridLedgerSelection.Size = new System.Drawing.Size(648, 149);
            this.gridLedgerSelection.TabIndex = 1;
            this.gridLedgerSelection.Text = "gridGroupingControl1";
            this.gridLedgerSelection.UseRightToLeftCompatibleTextBox = true;
            this.gridLedgerSelection.VersionInfo = "9.403.0.62";
            // 
            // btnAddList
            // 
            this.btnAddList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddList.ForeColor = System.Drawing.Color.Blue;
            this.btnAddList.Location = new System.Drawing.Point(661, 144);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(91, 23);
            this.btnAddList.TabIndex = 6;
            this.btnAddList.Text = "Add List";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // txtLedgerCodesCommaSeperated
            // 
            this.txtLedgerCodesCommaSeperated.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(4, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ledger List (Ledger Code Comma Sepearted):";
            // 
            // btnAddRange
            // 
            this.btnAddRange.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRange.ForeColor = System.Drawing.Color.Red;
            this.btnAddRange.Location = new System.Drawing.Point(661, 57);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(91, 23);
            this.btnAddRange.TabIndex = 3;
            this.btnAddRange.Text = "Add Range";
            this.btnAddRange.UseVisualStyleBackColor = true;
            this.btnAddRange.Click += new System.EventHandler(this.btnAddRange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ledger To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ledger From:";
            // 
            // btnCloseMore
            // 
            this.btnCloseMore.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseMore.Location = new System.Drawing.Point(660, 270);
            this.btnCloseMore.Name = "btnCloseMore";
            this.btnCloseMore.Size = new System.Drawing.Size(91, 23);
            this.btnCloseMore.TabIndex = 0;
            this.btnCloseMore.Text = "Close";
            this.btnCloseMore.UseVisualStyleBackColor = true;
            this.btnCloseMore.Click += new System.EventHandler(this.btnCloseMore_Click);
            // 
            // ggDetail
            // 
            this.ggDetail.BackColor = System.Drawing.SystemColors.Window;
            this.ggDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggDetail.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggDetail.Location = new System.Drawing.Point(0, 0);
            this.ggDetail.Name = "ggDetail";
            this.ggDetail.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggDetail.Size = new System.Drawing.Size(1267, 401);
            this.ggDetail.TabIndex = 0;
            this.ggDetail.Text = "gridGroupingControl1";
            this.ggDetail.UseRightToLeftCompatibleTextBox = true;
            this.ggDetail.VersionInfo = "9.403.0.62";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerate.Location = new System.Drawing.Point(240, 44);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(84, 23);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // gbDumpOf
            // 
            this.gbDumpOf.Controls.Add(this.rdTransaction);
            this.gbDumpOf.Controls.Add(this.rdLedger);
            this.gbDumpOf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDumpOf.Location = new System.Drawing.Point(5, 21);
            this.gbDumpOf.Name = "gbDumpOf";
            this.gbDumpOf.Size = new System.Drawing.Size(103, 80);
            this.gbDumpOf.TabIndex = 48;
            this.gbDumpOf.TabStop = false;
            this.gbDumpOf.Text = "Dump Of";
            // 
            // rdTransaction
            // 
            this.rdTransaction.AutoSize = true;
            this.rdTransaction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdTransaction.Location = new System.Drawing.Point(7, 46);
            this.rdTransaction.Name = "rdTransaction";
            this.rdTransaction.Size = new System.Drawing.Size(110, 21);
            this.rdTransaction.TabIndex = 1;
            this.rdTransaction.TabStop = true;
            this.rdTransaction.Text = "Transaction";
            this.rdTransaction.UseVisualStyleBackColor = true;
            this.rdTransaction.CheckedChanged += new System.EventHandler(this.rdTransaction_CheckedChanged);
            // 
            // rdLedger
            // 
            this.rdLedger.AutoSize = true;
            this.rdLedger.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLedger.Location = new System.Drawing.Point(7, 21);
            this.rdLedger.Name = "rdLedger";
            this.rdLedger.Size = new System.Drawing.Size(77, 21);
            this.rdLedger.TabIndex = 0;
            this.rdLedger.TabStop = true;
            this.rdLedger.Text = "Ledger";
            this.rdLedger.UseVisualStyleBackColor = true;
            this.rdLedger.CheckedChanged += new System.EventHandler(this.rdLedger_CheckedChanged);
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.rdPeriod);
            this.gbRange.Controls.Add(this.rdDateRange);
            this.gbRange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRange.Location = new System.Drawing.Point(5, 110);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(103, 73);
            this.gbRange.TabIndex = 49;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Range";
            // 
            // rdPeriod
            // 
            this.rdPeriod.AutoSize = true;
            this.rdPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPeriod.Location = new System.Drawing.Point(7, 46);
            this.rdPeriod.Name = "rdPeriod";
            this.rdPeriod.Size = new System.Drawing.Size(72, 21);
            this.rdPeriod.TabIndex = 1;
            this.rdPeriod.TabStop = true;
            this.rdPeriod.Text = "Period";
            this.rdPeriod.UseVisualStyleBackColor = true;
            this.rdPeriod.CheckedChanged += new System.EventHandler(this.rdPeriod_CheckedChanged);
            // 
            // rdDateRange
            // 
            this.rdDateRange.AutoSize = true;
            this.rdDateRange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDateRange.Location = new System.Drawing.Point(7, 21);
            this.rdDateRange.Name = "rdDateRange";
            this.rdDateRange.Size = new System.Drawing.Size(62, 21);
            this.rdDateRange.TabIndex = 0;
            this.rdDateRange.TabStop = true;
            this.rdDateRange.Text = "Date";
            this.rdDateRange.UseVisualStyleBackColor = true;
            this.rdDateRange.CheckedChanged += new System.EventHandler(this.rdDateRange_CheckedChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFromDate.Location = new System.Drawing.Point(111, 131);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(106, 24);
            this.dtFromDate.TabIndex = 50;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(111, 117);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(136, 17);
            this.lblDate.TabIndex = 52;
            this.lblDate.Text = "Date (From-To )";
            // 
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.BeforeTouchSize = new System.Drawing.Size(80, 25);
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(114, 23);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(80, 25);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 53;
            this.cmbFinYear.Text = "comboBoxAdv1";
            this.cmbFinYear.ThemeName = "Office2007";
            this.cmbFinYear.SelectedIndexChanged += new System.EventHandler(this.cmbFinYear_SelectedIndexChanged);
            this.cmbFinYear.SelectionChangeCommitted += new System.EventHandler(this.cmbFinYear_SelectionChangeCommitted);
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(884, 3);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(384, 23);
            this.pbar.TabIndex = 54;
            // 
            // cmbToPeriod
            // 
            this.cmbToPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToPeriod.BeforeTouchSize = new System.Drawing.Size(120, 25);
            this.cmbToPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToPeriod.Location = new System.Drawing.Point(114, 93);
            this.cmbToPeriod.Name = "cmbToPeriod";
            this.cmbToPeriod.Size = new System.Drawing.Size(120, 25);
            this.cmbToPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToPeriod.TabIndex = 55;
            this.cmbToPeriod.Text = "comboBoxAdv1";
            this.cmbToPeriod.ThemeName = "Office2007";
            // 
            // chkMoreSelection
            // 
            this.chkMoreSelection.AutoSize = true;
            this.chkMoreSelection.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMoreSelection.Location = new System.Drawing.Point(325, 166);
            this.chkMoreSelection.Name = "chkMoreSelection";
            this.chkMoreSelection.Size = new System.Drawing.Size(238, 24);
            this.chkMoreSelection.TabIndex = 59;
            this.chkMoreSelection.Text = "More Seletion Criteria";
            this.chkMoreSelection.UseVisualStyleBackColor = true;
            this.chkMoreSelection.CheckedChanged += new System.EventHandler(this.chkMoreSelection_CheckedChanged);
            // 
            // frmDumps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.chkMoreSelection);
            this.Controls.Add(this.cmbToPeriod);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.gbDumpOf);
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
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.cmbFromPeriod);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDumps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction/Ledger Dumps";
            this.Load += new System.EventHandler(this.frmCreditorAge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelMoreSelectionCriteria.ResumeLayout(false);
            this.panelMoreSelectionCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToLedgerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromLedgerCode)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLedgerSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).EndInit();
            this.gbDumpOf.ResumeLayout(false);
            this.gbDumpOf.PerformLayout();
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPeriodFrom;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblSearch;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromPeriod;
        private System.Windows.Forms.DateTimePicker dtToDate;
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
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggDetail;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbDumpOf;
        private System.Windows.Forms.RadioButton rdTransaction;
        private System.Windows.Forms.RadioButton rdLedger;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.RadioButton rdPeriod;
        private System.Windows.Forms.RadioButton rdDateRange;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private System.Windows.Forms.ProgressBar pbar;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToPeriod;
        private System.Windows.Forms.CheckBox chkMoreSelection;
        private System.Windows.Forms.Panel panelMoreSelectionCriteria;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
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
        private System.Windows.Forms.Button btnCloseMore;
        private System.Windows.Forms.Button btnClear;
    }
}