namespace BSMIS
{
    partial class frmBudgetVsActual
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
            this.cmbProjects = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.ggBudget = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(514, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(211, 25);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Budget vs Actual";
            // 
            // cmbProjects
            // 
            this.cmbProjects.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjects.Location = new System.Drawing.Point(98, 44);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(478, 22);
            this.cmbProjects.TabIndex = 49;
            // 
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(12, 44);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(80, 22);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 48;
            this.cmbFinYear.Text = "comboBoxAdv1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Blue;
            this.btnGenerate.Location = new System.Drawing.Point(582, 44);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(105, 23);
            this.btnGenerate.TabIndex = 53;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(882, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnExport.Location = new System.Drawing.Point(685, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 51;
            this.btnExport.Text = "Excel ";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(784, 44);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 50;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // ggBudget
            // 
            this.ggBudget.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggBudget.BackColor = System.Drawing.SystemColors.Window;
            this.ggBudget.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggBudget.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggBudget.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggBudget.Location = new System.Drawing.Point(12, 87);
            this.ggBudget.Name = "ggBudget";
            this.ggBudget.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggBudget.Size = new System.Drawing.Size(1267, 505);
            this.ggBudget.TabIndex = 54;
            this.ggBudget.Text = "gridGroupingControl1";
            this.ggBudget.UseRightToLeftCompatibleTextBox = true;
            this.ggBudget.VersionInfo = "9.403.0.62";
            // 
            // frmBudgetVsActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.ggBudget);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmBudgetVsActual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Budget Vs Actual";
            this.Load += new System.EventHandler(this.frmBudgetVsActual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProjects;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReset;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggBudget;
    }
}