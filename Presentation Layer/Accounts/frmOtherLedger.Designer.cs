namespace BSMIS 
{
    partial class frmOtherLedger
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
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFromYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.listZone = new System.Windows.Forms.CheckedListBox();
            this.listProject = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkProject = new System.Windows.Forms.CheckBox();
            this.chkUnchkZone = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggDetail = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFromPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbToYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbToPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbParty = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnResetAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(521, -2);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(273, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Ledger Summary";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(11, 88);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(162, 17);
            this.autoLabel2.TabIndex = 1;
            this.autoLabel2.Text = "To Year and Period ";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(11, 31);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(187, 17);
            this.autoLabel3.TabIndex = 2;
            this.autoLabel3.Text = "From Year and  Period ";
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
            // cmbFromYear
            // 
            this.cmbFromYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromYear.BeforeTouchSize = new System.Drawing.Size(80, 25);
            this.cmbFromYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromYear.Location = new System.Drawing.Point(11, 46);
            this.cmbFromYear.Name = "cmbFromYear";
            this.cmbFromYear.Size = new System.Drawing.Size(80, 25);
            this.cmbFromYear.Sorted = true;
            this.cmbFromYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromYear.TabIndex = 17;
            this.cmbFromYear.Text = "comboBoxAdv1";
            this.cmbFromYear.ThemeName = "Office2007";
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
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(512, 99);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 27);
            this.btnReset.TabIndex = 38;
            this.btnReset.Text = "Print";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.Location = new System.Drawing.Point(419, 99);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 27);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "Excel ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(692, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 27);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggDetail);
            this.panel1.Location = new System.Drawing.Point(5, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1267, 401);
            this.panel1.TabIndex = 41;
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
            this.btnGenerate.Location = new System.Drawing.Point(323, 99);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(98, 27);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(194, 31);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(110, 17);
            this.autoLabel1.TabIndex = 49;
            this.autoLabel1.Text = "Ledger Name";
            // 
            // cmbFromPeriod
            // 
            this.cmbFromPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromPeriod.BeforeTouchSize = new System.Drawing.Size(93, 25);
            this.cmbFromPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromPeriod.Location = new System.Drawing.Point(95, 45);
            this.cmbFromPeriod.Name = "cmbFromPeriod";
            this.cmbFromPeriod.Size = new System.Drawing.Size(93, 25);
            this.cmbFromPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromPeriod.TabIndex = 50;
            this.cmbFromPeriod.Text = "comboBoxAdv1";
            this.cmbFromPeriod.ThemeName = "Office2007";
            // 
            // cmbToYear
            // 
            this.cmbToYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToYear.BeforeTouchSize = new System.Drawing.Size(80, 25);
            this.cmbToYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToYear.Location = new System.Drawing.Point(11, 105);
            this.cmbToYear.Name = "cmbToYear";
            this.cmbToYear.Size = new System.Drawing.Size(80, 25);
            this.cmbToYear.Sorted = true;
            this.cmbToYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToYear.TabIndex = 51;
            this.cmbToYear.Text = "comboBoxAdv1";
            this.cmbToYear.ThemeName = "Office2007";
            // 
            // cmbToPeriod
            // 
            this.cmbToPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToPeriod.BeforeTouchSize = new System.Drawing.Size(93, 25);
            this.cmbToPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToPeriod.Location = new System.Drawing.Point(95, 105);
            this.cmbToPeriod.Name = "cmbToPeriod";
            this.cmbToPeriod.Size = new System.Drawing.Size(93, 25);
            this.cmbToPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToPeriod.TabIndex = 52;
            this.cmbToPeriod.Text = "comboBoxAdv1";
            this.cmbToPeriod.ThemeName = "Office2007";
            // 
            // cmbParty
            // 
            this.cmbParty.AllowDrop = true;
            this.cmbParty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbParty.BeforeTouchSize = new System.Drawing.Size(476, 25);
            this.cmbParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParty.Items.AddRange(new object[] {
            " "});
            this.cmbParty.Location = new System.Drawing.Point(194, 46);
            this.cmbParty.MatchFirstCharacterOnly = false;
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Size = new System.Drawing.Size(476, 25);
            this.cmbParty.Sorted = true;
            this.cmbParty.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbParty.TabIndex = 53;
            this.cmbParty.Text = " ";
            this.cmbParty.ThemeName = "Office2007";
            // 
            // btnResetAll
            // 
            this.btnResetAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAll.ForeColor = System.Drawing.Color.Blue;
            this.btnResetAll.Location = new System.Drawing.Point(607, 99);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(86, 27);
            this.btnResetAll.TabIndex = 55;
            this.btnResetAll.Text = "Reset";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // frmOtherLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.btnResetAll);
            this.Controls.Add(this.cmbParty);
            this.Controls.Add(this.cmbToPeriod);
            this.Controls.Add(this.cmbToYear);
            this.Controls.Add(this.cmbFromPeriod);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkUnchkZone);
            this.Controls.Add(this.chkUnChkProject);
            this.Controls.Add(this.listProject);
            this.Controls.Add(this.listZone);
            this.Controls.Add(this.cmbFromYear);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmOtherLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditor Age";
            this.Load += new System.EventHandler(this.frmMastersLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromYear)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromYear;
        private System.Windows.Forms.CheckedListBox listZone;
        private System.Windows.Forms.CheckedListBox listProject;
        private System.Windows.Forms.CheckBox chkUnChkProject;
        private System.Windows.Forms.CheckBox chkUnchkZone;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggDetail;
        private System.Windows.Forms.Button btnGenerate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromPeriod;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToPeriod;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbParty;
        private System.Windows.Forms.Button btnResetAll;
    }
}