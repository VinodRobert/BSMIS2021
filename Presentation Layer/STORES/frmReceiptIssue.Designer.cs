namespace BSMIS 
{
    partial class frmReceiptIssue
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridRegister = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbToPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFromPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblPeriod = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.chkUnchkZone = new System.Windows.Forms.CheckBox();
            this.chkUnChkProject = new System.Windows.Forms.CheckBox();
            this.listProject = new System.Windows.Forms.CheckedListBox();
            this.listZone = new System.Windows.Forms.CheckedListBox();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(497, -1);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(279, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Receipt-Issue Register";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(1168, 40);
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
            this.btnExport.Location = new System.Drawing.Point(1168, 68);
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
            this.btnClose.Location = new System.Drawing.Point(1168, 101);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridRegister);
            this.panel1.Location = new System.Drawing.Point(7, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 411);
            this.panel1.TabIndex = 41;
            // 
            // gridRegister
            // 
            this.gridRegister.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridRegister.BackColor = System.Drawing.SystemColors.Window;
            this.gridRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRegister.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridRegister.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridRegister.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridRegister.Location = new System.Drawing.Point(0, 0);
            this.gridRegister.Name = "gridRegister";
            this.gridRegister.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridRegister.Size = new System.Drawing.Size(1261, 411);
            this.gridRegister.TabIndex = 2;
            this.gridRegister.Text = "gridGroupingControl1";
            this.gridRegister.UseRightToLeftCompatibleTextBox = true;
            this.gridRegister.VersionInfo = "9.403.0.62";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerate.Location = new System.Drawing.Point(1168, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(100, 23);
            this.btnGenerate.TabIndex = 42;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(435, 42);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(61, 13);
            this.autoLabel1.TabIndex = 62;
            this.autoLabel1.Text = "Fin Year";
            // 
            // cmbToPeriod
            // 
            this.cmbToPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbToPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToPeriod.Location = new System.Drawing.Point(497, 103);
            this.cmbToPeriod.Name = "cmbToPeriod";
            this.cmbToPeriod.Size = new System.Drawing.Size(127, 21);
            this.cmbToPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbToPeriod.TabIndex = 61;
            this.cmbToPeriod.Text = "comboBoxAdv1";
            // 
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(497, 42);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(79, 21);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 60;
            this.cmbFinYear.Text = "comboBoxAdv1";
            // 
            // cmbFromPeriod
            // 
            this.cmbFromPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromPeriod.Location = new System.Drawing.Point(497, 74);
            this.cmbFromPeriod.Name = "cmbFromPeriod";
            this.cmbFromPeriod.Size = new System.Drawing.Size(127, 21);
            this.cmbFromPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromPeriod.TabIndex = 59;
            this.cmbFromPeriod.Text = "comboBoxAdv1";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(435, 74);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(56, 13);
            this.lblPeriod.TabIndex = 58;
            this.lblPeriod.Text = "Periods";
            // 
            // chkUnchkZone
            // 
            this.chkUnchkZone.AutoSize = true;
            this.chkUnchkZone.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnchkZone.Location = new System.Drawing.Point(678, 37);
            this.chkUnchkZone.Name = "chkUnchkZone";
            this.chkUnchkZone.Size = new System.Drawing.Size(98, 19);
            this.chkUnchkZone.TabIndex = 68;
            this.chkUnchkZone.Text = "Check/Un Check";
            this.chkUnchkZone.UseVisualStyleBackColor = true;
            this.chkUnchkZone.CheckedChanged += new System.EventHandler(this.chkUnchkZone_CheckedChanged);
            // 
            // chkUnChkProject
            // 
            this.chkUnChkProject.AutoSize = true;
            this.chkUnChkProject.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkProject.Location = new System.Drawing.Point(1027, 21);
            this.chkUnChkProject.Name = "chkUnChkProject";
            this.chkUnChkProject.Size = new System.Drawing.Size(98, 19);
            this.chkUnChkProject.TabIndex = 67;
            this.chkUnChkProject.Text = "Check/Un Check";
            this.chkUnChkProject.UseVisualStyleBackColor = true;
            this.chkUnChkProject.CheckedChanged += new System.EventHandler(this.chkUnChkProject_CheckedChanged);
            // 
            // listProject
            // 
            this.listProject.CheckOnClick = true;
            this.listProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProject.FormattingEnabled = true;
            this.listProject.Location = new System.Drawing.Point(781, 40);
            this.listProject.Name = "listProject";
            this.listProject.ScrollAlwaysVisible = true;
            this.listProject.Size = new System.Drawing.Size(337, 132);
            this.listProject.TabIndex = 66;
            // 
            // listZone
            // 
            this.listZone.CheckOnClick = true;
            this.listZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listZone.FormattingEnabled = true;
            this.listZone.Location = new System.Drawing.Point(638, 56);
            this.listZone.Name = "listZone";
            this.listZone.ScrollAlwaysVisible = true;
            this.listZone.Size = new System.Drawing.Size(138, 100);
            this.listZone.TabIndex = 65;
            this.listZone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listZone_MouseUp);
            // 
            // lblProject
            // 
            this.lblProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(781, 21);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 13);
            this.lblProject.TabIndex = 64;
            this.lblProject.Text = "Project";
            // 
            // autoLabel5
            // 
            this.autoLabel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel5.Location = new System.Drawing.Point(635, 37);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(39, 13);
            this.autoLabel5.TabIndex = 63;
            this.autoLabel5.Text = "Zone";
            // 
            // frmReceiptIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.chkUnchkZone);
            this.Controls.Add(this.chkUnChkProject);
            this.Controls.Add(this.listProject);
            this.Controls.Add(this.listZone);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.cmbToPeriod);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.cmbFromPeriod);
            this.Controls.Add(this.lblPeriod);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmReceiptIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt-Issue Register";
            this.Load += new System.EventHandler(this.frmReceiptIssue_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbToPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGenerate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbToPeriod;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromPeriod;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPeriod;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridRegister;
        private System.Windows.Forms.CheckBox chkUnchkZone;
        private System.Windows.Forms.CheckBox chkUnChkProject;
        private System.Windows.Forms.CheckedListBox listProject;
        private System.Windows.Forms.CheckedListBox listZone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
    }
}