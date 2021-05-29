namespace BSMIS 
{
    partial class frmSubbieAge
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
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbAgingOf = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbAgedTo = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblAgeOf = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtAgedTo = new System.Windows.Forms.DateTimePicker();
            this.cmbPeriods = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.listCreditors = new System.Windows.Forms.CheckedListBox();
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
            this.ggConsolidated = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.ggProject = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.ggDetail = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rdConsolidated = new System.Windows.Forms.RadioButton();
            this.rdProject = new System.Windows.Forms.RadioButton();
            this.rdDetail = new System.Windows.Forms.RadioButton();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.cmbDebtors = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgingOf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggConsolidated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).BeginInit();
            this.gbView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDebtors)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(484, 3);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(345, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Creditor Aging Report";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(114, 31);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(71, 17);
            this.autoLabel2.TabIndex = 1;
            this.autoLabel2.Text = "Fin Year";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(5, 31);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(73, 17);
            this.autoLabel3.TabIndex = 2;
            this.autoLabel3.Text = "Aged To";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(325, 31);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(91, 17);
            this.autoLabel4.TabIndex = 6;
            this.autoLabel4.Text = "Search .....";
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
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.BeforeTouchSize = new System.Drawing.Size(80, 25);
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(114, 51);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(80, 25);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 17;
            this.cmbFinYear.Text = "comboBoxAdv1";
            this.cmbFinYear.ThemeName = "Office2007";
            // 
            // cmbAgingOf
            // 
            this.cmbAgingOf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbAgingOf.BeforeTouchSize = new System.Drawing.Size(125, 25);
            this.cmbAgingOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgingOf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgingOf.Location = new System.Drawing.Point(194, 51);
            this.cmbAgingOf.Name = "cmbAgingOf";
            this.cmbAgingOf.Size = new System.Drawing.Size(125, 25);
            this.cmbAgingOf.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbAgingOf.TabIndex = 18;
            this.cmbAgingOf.ThemeName = "Office2007";
            // 
            // cmbAgedTo
            // 
            this.cmbAgedTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbAgedTo.BeforeTouchSize = new System.Drawing.Size(106, 25);
            this.cmbAgedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgedTo.Location = new System.Drawing.Point(6, 51);
            this.cmbAgedTo.Name = "cmbAgedTo";
            this.cmbAgedTo.Size = new System.Drawing.Size(106, 25);
            this.cmbAgedTo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbAgedTo.TabIndex = 19;
            this.cmbAgedTo.ThemeName = "Office2007";
            this.cmbAgedTo.SelectedIndexChanged += new System.EventHandler(this.cmbAgingOn_SelectedIndexChanged);
            // 
            // lblAgeOf
            // 
            this.lblAgeOf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeOf.Location = new System.Drawing.Point(194, 31);
            this.lblAgeOf.Name = "lblAgeOf";
            this.lblAgeOf.Size = new System.Drawing.Size(61, 17);
            this.lblAgeOf.TabIndex = 20;
            this.lblAgeOf.Text = "Age Of";
            // 
            // dtAgedTo
            // 
            this.dtAgedTo.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAgedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAgedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgedTo.Location = new System.Drawing.Point(5, 75);
            this.dtAgedTo.Name = "dtAgedTo";
            this.dtAgedTo.Size = new System.Drawing.Size(106, 24);
            this.dtAgedTo.TabIndex = 22;
            this.dtAgedTo.Visible = false;
            this.dtAgedTo.ValueChanged += new System.EventHandler(this.dtAgedTo_ValueChanged);
            // 
            // cmbPeriods
            // 
            this.cmbPeriods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbPeriods.BeforeTouchSize = new System.Drawing.Size(106, 25);
            this.cmbPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriods.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriods.Location = new System.Drawing.Point(6, 78);
            this.cmbPeriods.Name = "cmbPeriods";
            this.cmbPeriods.Size = new System.Drawing.Size(106, 25);
            this.cmbPeriods.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbPeriods.TabIndex = 23;
            this.cmbPeriods.ThemeName = "Office2007";
            // 
            // listCreditors
            // 
            this.listCreditors.CheckOnClick = true;
            this.listCreditors.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCreditors.FormattingEnabled = true;
            this.listCreditors.Location = new System.Drawing.Point(325, 67);
            this.listCreditors.Name = "listCreditors";
            this.listCreditors.ScrollAlwaysVisible = true;
            this.listCreditors.Size = new System.Drawing.Size(458, 99);
            this.listCreditors.TabIndex = 24;
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
            this.listProject.Size = new System.Drawing.Size(337, 118);
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
            this.btnReset.Location = new System.Drawing.Point(219, 107);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 27);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.Location = new System.Drawing.Point(219, 150);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 27);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "Excel ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(219, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggConsolidated);
            this.panel1.Controls.Add(this.ggProject);
            this.panel1.Controls.Add(this.ggDetail);
            this.panel1.Location = new System.Drawing.Point(5, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 401);
            this.panel1.TabIndex = 41;
            // 
            // ggConsolidated
            // 
            this.ggConsolidated.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggConsolidated.BackColor = System.Drawing.SystemColors.Window;
            this.ggConsolidated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggConsolidated.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggConsolidated.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggConsolidated.Location = new System.Drawing.Point(0, 0);
            this.ggConsolidated.Name = "ggConsolidated";
            this.ggConsolidated.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggConsolidated.Size = new System.Drawing.Size(1267, 401);
            this.ggConsolidated.TabIndex = 2;
            this.ggConsolidated.Text = "gridGroupingControl1";
            this.ggConsolidated.UseRightToLeftCompatibleTextBox = true;
            this.ggConsolidated.VersionInfo = "9.403.0.62";
            // 
            // ggProject
            // 
            this.ggProject.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggProject.BackColor = System.Drawing.SystemColors.Window;
            this.ggProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggProject.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Silver;
            this.ggProject.Location = new System.Drawing.Point(0, 0);
            this.ggProject.Name = "ggProject";
            this.ggProject.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggProject.Size = new System.Drawing.Size(1267, 401);
            this.ggProject.TabIndex = 1;
            this.ggProject.Text = "gridGroupingControl1";
            this.ggProject.UseRightToLeftCompatibleTextBox = true;
            this.ggProject.VersionInfo = "9.403.0.62";
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
            this.btnGenerate.Location = new System.Drawing.Point(114, 78);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rdConsolidated
            // 
            this.rdConsolidated.AutoSize = true;
            this.rdConsolidated.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdConsolidated.ForeColor = System.Drawing.Color.Red;
            this.rdConsolidated.Location = new System.Drawing.Point(42, 50);
            this.rdConsolidated.Name = "rdConsolidated";
            this.rdConsolidated.Size = new System.Drawing.Size(173, 21);
            this.rdConsolidated.TabIndex = 43;
            this.rdConsolidated.TabStop = true;
            this.rdConsolidated.Text = "Consolidated View";
            this.rdConsolidated.UseVisualStyleBackColor = true;
            this.rdConsolidated.Click += new System.EventHandler(this.rdConsolidated_Click);
            // 
            // rdProject
            // 
            this.rdProject.AutoSize = true;
            this.rdProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdProject.ForeColor = System.Drawing.Color.Red;
            this.rdProject.Location = new System.Drawing.Point(42, 32);
            this.rdProject.Name = "rdProject";
            this.rdProject.Size = new System.Drawing.Size(127, 21);
            this.rdProject.TabIndex = 44;
            this.rdProject.TabStop = true;
            this.rdProject.Text = "Project Wise";
            this.rdProject.UseVisualStyleBackColor = true;
            this.rdProject.Click += new System.EventHandler(this.rdProject_Click);
            // 
            // rdDetail
            // 
            this.rdDetail.AutoSize = true;
            this.rdDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDetail.ForeColor = System.Drawing.Color.Red;
            this.rdDetail.Location = new System.Drawing.Point(42, 12);
            this.rdDetail.Name = "rdDetail";
            this.rdDetail.Size = new System.Drawing.Size(134, 21);
            this.rdDetail.TabIndex = 45;
            this.rdDetail.TabStop = true;
            this.rdDetail.Text = "Detailed View";
            this.rdDetail.UseVisualStyleBackColor = true;
            this.rdDetail.Click += new System.EventHandler(this.rdDetail_Click);
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.rdDetail);
            this.gbView.Controls.Add(this.rdConsolidated);
            this.gbView.Controls.Add(this.rdProject);
            this.gbView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbView.ForeColor = System.Drawing.Color.Red;
            this.gbView.Location = new System.Drawing.Point(6, 110);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(200, 72);
            this.gbView.TabIndex = 46;
            this.gbView.TabStop = false;
            this.gbView.Text = "View";
            // 
            // cmbDebtors
            // 
            this.cmbDebtors.BeforeTouchSize = new System.Drawing.Size(125, 25);
            this.cmbDebtors.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDebtors.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDebtors.Location = new System.Drawing.Point(200, 51);
            this.cmbDebtors.Name = "cmbDebtors";
            this.cmbDebtors.Size = new System.Drawing.Size(125, 25);
            this.cmbDebtors.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010;
            this.cmbDebtors.TabIndex = 47;
            this.cmbDebtors.ThemeName = "VS2010";
            this.cmbDebtors.SelectionChangeCommitted += new System.EventHandler(this.cmbDebtors_SelectionChangeCommitted);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.ForeColor = System.Drawing.Color.Purple;
            this.chkAll.Location = new System.Drawing.Point(325, 167);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(210, 21);
            this.chkAll.TabIndex = 48;
            this.chkAll.Text = "Ignore Selection/All Party for All Orgs";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // frmSubbieAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.cmbDebtors);
            this.Controls.Add(this.gbView);
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
            this.Controls.Add(this.listCreditors);
            this.Controls.Add(this.cmbPeriods);
            this.Controls.Add(this.dtAgedTo);
            this.Controls.Add(this.lblAgeOf);
            this.Controls.Add(this.cmbAgedTo);
            this.Controls.Add(this.cmbAgingOf);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmSubbieAge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditor Age";
            this.Load += new System.EventHandler(this.frmCreditorAge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgingOf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggConsolidated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).EndInit();
            this.gbView.ResumeLayout(false);
            this.gbView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDebtors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAgingOf;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAgedTo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblAgeOf;
        private System.Windows.Forms.DateTimePicker dtAgedTo;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbPeriods;
        private System.Windows.Forms.CheckedListBox listCreditors;
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
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggConsolidated;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggProject;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggDetail;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton rdConsolidated;
        private System.Windows.Forms.RadioButton rdProject;
        private System.Windows.Forms.RadioButton rdDetail;
        private System.Windows.Forms.GroupBox gbView;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbDebtors;
        private System.Windows.Forms.CheckBox chkAll;
    }
}