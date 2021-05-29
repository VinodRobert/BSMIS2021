namespace BSMIS 
{
    partial class frmSubContractorAge
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.lblProject = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbAgingOf = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbAgedTo = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.dtAgedTo = new System.Windows.Forms.DateTimePicker();
            this.cmbPeriods = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.listCreditors = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkCreditor = new System.Windows.Forms.CheckBox();
            this.listZone = new System.Windows.Forms.CheckedListBox();
            this.listProject = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkProject = new System.Windows.Forms.CheckBox();
            this.chkUnchkZone = new System.Windows.Forms.CheckBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnProjectWise = new System.Windows.Forms.Button();
            this.btnEnterpriseWise = new System.Windows.Forms.Button();
            this.txtSearchCreditor = new System.Windows.Forms.TextBox();
            this.ggResult = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgingOf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggResult)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.Blue;
            this.autoLabel1.Location = new System.Drawing.Point(431, 3);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(352, 25);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Sub Contractor-Aging Report";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(114, 31);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(61, 13);
            this.autoLabel2.TabIndex = 1;
            this.autoLabel2.Text = "Fin Year";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(5, 31);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(60, 13);
            this.autoLabel3.TabIndex = 2;
            this.autoLabel3.Text = "Aged To";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(325, 31);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(111, 13);
            this.autoLabel4.TabIndex = 6;
            this.autoLabel4.Text = "Sub Contractors";
            // 
            // autoLabel5
            // 
            this.autoLabel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel5.Location = new System.Drawing.Point(793, 31);
            this.autoLabel5.Name = "autoLabel5";
            this.autoLabel5.Size = new System.Drawing.Size(39, 13);
            this.autoLabel5.TabIndex = 7;
            this.autoLabel5.Text = "Zone";
            // 
            // lblProject
            // 
            this.lblProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProject.Location = new System.Drawing.Point(931, 31);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(54, 13);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Project";
            // 
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(114, 51);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(80, 21);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 17;
            this.cmbFinYear.Text = "comboBoxAdv1";
            // 
            // cmbAgingOf
            // 
            this.cmbAgingOf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbAgingOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgingOf.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgingOf.Location = new System.Drawing.Point(194, 51);
            this.cmbAgingOf.Name = "cmbAgingOf";
            this.cmbAgingOf.Size = new System.Drawing.Size(125, 21);
            this.cmbAgingOf.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbAgingOf.TabIndex = 18;
            // 
            // cmbAgedTo
            // 
            this.cmbAgedTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbAgedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAgedTo.Location = new System.Drawing.Point(6, 51);
            this.cmbAgedTo.Name = "cmbAgedTo";
            this.cmbAgedTo.Size = new System.Drawing.Size(106, 21);
            this.cmbAgedTo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbAgedTo.TabIndex = 19;
            this.cmbAgedTo.SelectedIndexChanged += new System.EventHandler(this.cmbAgingOn_SelectedIndexChanged);
            // 
            // autoLabel6
            // 
            this.autoLabel6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel6.Location = new System.Drawing.Point(194, 31);
            this.autoLabel6.Name = "autoLabel6";
            this.autoLabel6.Size = new System.Drawing.Size(50, 13);
            this.autoLabel6.TabIndex = 20;
            this.autoLabel6.Text = "Age Of";
            // 
            // dtAgedTo
            // 
            this.dtAgedTo.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAgedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtAgedTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAgedTo.Location = new System.Drawing.Point(5, 75);
            this.dtAgedTo.Name = "dtAgedTo";
            this.dtAgedTo.Size = new System.Drawing.Size(106, 21);
            this.dtAgedTo.TabIndex = 22;
            this.dtAgedTo.Visible = false;
            this.dtAgedTo.ValueChanged += new System.EventHandler(this.dtAgedTo_ValueChanged);
            // 
            // cmbPeriods
            // 
            this.cmbPeriods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbPeriods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriods.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriods.Location = new System.Drawing.Point(6, 78);
            this.cmbPeriods.Name = "cmbPeriods";
            this.cmbPeriods.Size = new System.Drawing.Size(106, 21);
            this.cmbPeriods.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbPeriods.TabIndex = 23;
            // 
            // listCreditors
            // 
            this.listCreditors.CheckOnClick = true;
            this.listCreditors.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCreditors.FormattingEnabled = true;
            this.listCreditors.Location = new System.Drawing.Point(325, 67);
            this.listCreditors.Name = "listCreditors";
            this.listCreditors.ScrollAlwaysVisible = true;
            this.listCreditors.Size = new System.Drawing.Size(458, 84);
            this.listCreditors.TabIndex = 24;
            // 
            // chkUnChkCreditor
            // 
            this.chkUnChkCreditor.AutoSize = true;
            this.chkUnChkCreditor.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkCreditor.Location = new System.Drawing.Point(688, 31);
            this.chkUnChkCreditor.Name = "chkUnChkCreditor";
            this.chkUnChkCreditor.Size = new System.Drawing.Size(98, 19);
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
            this.listZone.Size = new System.Drawing.Size(131, 68);
            this.listZone.TabIndex = 26;
            this.listZone.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listZone_MouseUp);
            // 
            // listProject
            // 
            this.listProject.CheckOnClick = true;
            this.listProject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProject.FormattingEnabled = true;
            this.listProject.Location = new System.Drawing.Point(935, 51);
            this.listProject.Name = "listProject";
            this.listProject.ScrollAlwaysVisible = true;
            this.listProject.Size = new System.Drawing.Size(337, 100);
            this.listProject.TabIndex = 27;
            // 
            // chkUnChkProject
            // 
            this.chkUnChkProject.AutoSize = true;
            this.chkUnChkProject.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkProject.Location = new System.Drawing.Point(1177, 31);
            this.chkUnChkProject.Name = "chkUnChkProject";
            this.chkUnChkProject.Size = new System.Drawing.Size(98, 19);
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
            this.chkUnchkZone.Size = new System.Drawing.Size(98, 19);
            this.chkUnchkZone.TabIndex = 30;
            this.chkUnchkZone.Text = "Check/Un Check";
            this.chkUnchkZone.UseVisualStyleBackColor = true;
            this.chkUnchkZone.CheckedChanged += new System.EventHandler(this.chkUnchkZone_CheckedChanged);
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.Location = new System.Drawing.Point(6, 121);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(92, 27);
            this.btnDetail.TabIndex = 31;
            this.btnDetail.Text = "Detail";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnProjectWise
            // 
            this.btnProjectWise.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectWise.Location = new System.Drawing.Point(104, 121);
            this.btnProjectWise.Name = "btnProjectWise";
            this.btnProjectWise.Size = new System.Drawing.Size(102, 27);
            this.btnProjectWise.TabIndex = 32;
            this.btnProjectWise.Text = "ProjectWise";
            this.btnProjectWise.UseVisualStyleBackColor = true;
            this.btnProjectWise.Click += new System.EventHandler(this.btnProjectWise_Click);
            // 
            // btnEnterpriseWise
            // 
            this.btnEnterpriseWise.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnterpriseWise.Location = new System.Drawing.Point(214, 121);
            this.btnEnterpriseWise.Name = "btnEnterpriseWise";
            this.btnEnterpriseWise.Size = new System.Drawing.Size(100, 27);
            this.btnEnterpriseWise.TabIndex = 33;
            this.btnEnterpriseWise.Text = "Consolidated";
            this.btnEnterpriseWise.UseVisualStyleBackColor = true;
            this.btnEnterpriseWise.Click += new System.EventHandler(this.btnEnterpriseWise_Click);
            // 
            // txtSearchCreditor
            // 
            this.txtSearchCreditor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCreditor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSearchCreditor.Location = new System.Drawing.Point(325, 47);
            this.txtSearchCreditor.Name = "txtSearchCreditor";
            this.txtSearchCreditor.Size = new System.Drawing.Size(357, 20);
            this.txtSearchCreditor.TabIndex = 35;
            this.txtSearchCreditor.TextChanged += new System.EventHandler(this.txtSearchCreditor_TextChanged);
            // 
            // ggResult
            // 
            this.ggResult.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggResult.BackColor = System.Drawing.SystemColors.Window;
            this.ggResult.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggResult.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggResult.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggResult.HorizontalScrollTips = true;
            this.ggResult.Location = new System.Drawing.Point(5, 193);
            this.ggResult.Name = "ggResult";
            this.ggResult.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggResult.Size = new System.Drawing.Size(1267, 387);
            this.ggResult.TabIndex = 36;
            this.ggResult.TableDescriptor.AllowEdit = false;
            this.ggResult.TableDescriptor.AllowNew = false;
            this.ggResult.TableDescriptor.AllowRemove = false;
            this.ggResult.Text = "gridGroupingControl1";
            this.ggResult.UseRightToLeftCompatibleTextBox = true;
            this.ggResult.VersionInfo = "9.403.0.62";
            this.ggResult.VerticalScrollTips = true;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(214, 121);
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
            this.btnExport.Location = new System.Drawing.Point(104, 121);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(104, 27);
            this.btnExport.TabIndex = 39;
            this.btnExport.Text = "Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(214, 92);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSubContractorAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.ggResult);
            this.Controls.Add(this.txtSearchCreditor);
            this.Controls.Add(this.btnEnterpriseWise);
            this.Controls.Add(this.btnProjectWise);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.chkUnchkZone);
            this.Controls.Add(this.chkUnChkProject);
            this.Controls.Add(this.listProject);
            this.Controls.Add(this.listZone);
            this.Controls.Add(this.chkUnChkCreditor);
            this.Controls.Add(this.listCreditors);
            this.Controls.Add(this.cmbPeriods);
            this.Controls.Add(this.dtAgedTo);
            this.Controls.Add(this.autoLabel6);
            this.Controls.Add(this.cmbAgedTo);
            this.Controls.Add(this.cmbAgingOf);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.autoLabel5);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.autoLabel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmSubContractorAge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creditor Age";
            this.Load += new System.EventHandler(this.frmCreditorAge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgingOf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAgedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblProject;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAgingOf;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAgedTo;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private System.Windows.Forms.DateTimePicker dtAgedTo;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbPeriods;
        private System.Windows.Forms.CheckedListBox listCreditors;
        private System.Windows.Forms.CheckBox chkUnChkCreditor;
        private System.Windows.Forms.CheckedListBox listZone;
        private System.Windows.Forms.CheckedListBox listProject;
        private System.Windows.Forms.CheckBox chkUnChkProject;
        private System.Windows.Forms.CheckBox chkUnchkZone;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnProjectWise;
        private System.Windows.Forms.Button btnEnterpriseWise;
        private System.Windows.Forms.TextBox txtSearchCreditor;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggResult;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
    }
}