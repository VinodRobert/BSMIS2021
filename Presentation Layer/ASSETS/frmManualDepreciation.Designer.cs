namespace BSMIS
{
    partial class frmManualDepreciation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmount = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnExit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cmbAssetCategory = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbAssets = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnLoad = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtFinYear = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.cmbPeriods = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.gridResult = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(200, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manual Depreciation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Asset Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Asset Name  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Depreciation Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = " and Period";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtAmount.CurrencySymbol = "Rs";
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(149, 144);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.NullString = "";
            this.txtAmount.Size = new System.Drawing.Size(100, 21);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.Text = "Rs 0.00";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(270, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 31);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(355, 134);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 31);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbAssetCategory
            // 
            this.cmbAssetCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssetCategory.Location = new System.Drawing.Point(149, 39);
            this.cmbAssetCategory.Name = "cmbAssetCategory";
            this.cmbAssetCategory.Size = new System.Drawing.Size(339, 22);
            this.cmbAssetCategory.TabIndex = 19;
            // 
            // cmbAssets
            // 
            this.cmbAssets.Border3DStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.cmbAssets.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssets.Location = new System.Drawing.Point(149, 66);
            this.cmbAssets.Name = "cmbAssets";
            this.cmbAssets.ReadOnly = true;
            this.cmbAssets.Size = new System.Drawing.Size(445, 22);
            this.cmbAssets.Sorted = true;
            this.cmbAssets.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cmbAssets.TabIndex = 20;
            this.cmbAssets.Text = " ";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(494, 38);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtFinYear
            // 
            this.txtFinYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFinYear.Enabled = false;
            this.txtFinYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinYear.Location = new System.Drawing.Point(149, 102);
            this.txtFinYear.Name = "txtFinYear";
            this.txtFinYear.ReadOnly = true;
            this.txtFinYear.Size = new System.Drawing.Size(100, 22);
            this.txtFinYear.TabIndex = 22;
            this.txtFinYear.Text = " ";
            // 
            // cmbPeriods
            // 
            this.cmbPeriods.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriods.Location = new System.Drawing.Point(371, 102);
            this.cmbPeriods.Name = "cmbPeriods";
            this.cmbPeriods.Size = new System.Drawing.Size(154, 22);
            this.cmbPeriods.TabIndex = 23;
            this.cmbPeriods.Text = " ";
            // 
            // gridResult
            // 
            this.gridResult.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridResult.BackColor = System.Drawing.SystemColors.Window;
            this.gridResult.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridResult.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridResult.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Black;
            this.gridResult.Location = new System.Drawing.Point(13, 210);
            this.gridResult.Name = "gridResult";
            this.gridResult.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridResult.ShowNestedPropertiesFields = false;
            this.gridResult.Size = new System.Drawing.Size(581, 297);
            this.gridResult.TabIndex = 24;
            this.gridResult.Text = "gridGroupingControl1";
            this.gridResult.UseRightToLeftCompatibleTextBox = true;
            this.gridResult.VersionInfo = "9.403.0.62";
            // 
            // frmManualDepreciation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 519);
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.cmbPeriods);
            this.Controls.Add(this.txtFinYear);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbAssets);
            this.Controls.Add(this.cmbAssetCategory);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmManualDepreciation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Depreciation";
            this.Load += new System.EventHandler(this.frmManualDepreciation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtAmount;
        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
        private Syncfusion.Windows.Forms.ButtonAdv btnExit;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAssetCategory;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAssets;
        private Syncfusion.Windows.Forms.ButtonAdv btnLoad;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtFinYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbPeriods;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridResult;
    }
}