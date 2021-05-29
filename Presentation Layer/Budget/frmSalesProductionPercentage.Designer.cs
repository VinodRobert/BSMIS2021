namespace BSMIS 
{
    partial class frmSalesProductionPercentage
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProjects = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFinYear = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbFromPeriod = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.salesPercentage = new Syncfusion.Windows.Forms.Tools.PercentTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.gridViewLedgers = new System.Windows.Forms.DataGridView();
            this.gridViewPercentage = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLedgers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales  - Percentage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(340, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Month :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(340, 145);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update %";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sales  : ";
            // 
            // cmbProjects
            // 
            this.cmbProjects.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjects.Location = new System.Drawing.Point(79, 52);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(444, 22);
            this.cmbProjects.TabIndex = 50;
            this.cmbProjects.SelectionChangeCommitted += new System.EventHandler(this.cmbProjects_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(23, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "Year:";
            // 
            // cmbFinYear
            // 
            this.cmbFinYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFinYear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFinYear.Location = new System.Drawing.Point(79, 97);
            this.cmbFinYear.Name = "cmbFinYear";
            this.cmbFinYear.Size = new System.Drawing.Size(80, 22);
            this.cmbFinYear.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFinYear.TabIndex = 54;
            this.cmbFinYear.Text = "comboBoxAdv1";
            // 
            // cmbFromPeriod
            // 
            this.cmbFromPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbFromPeriod.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromPeriod.Location = new System.Drawing.Point(396, 96);
            this.cmbFromPeriod.Name = "cmbFromPeriod";
            this.cmbFromPeriod.Size = new System.Drawing.Size(127, 22);
            this.cmbFromPeriod.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbFromPeriod.TabIndex = 55;
            this.cmbFromPeriod.Text = "comboBoxAdv1";
            // 
            // salesPercentage
            // 
            this.salesPercentage.BackGroundColor = System.Drawing.SystemColors.Window;
            this.salesPercentage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.salesPercentage.DoubleValue = 0D;
            this.salesPercentage.Location = new System.Drawing.Point(79, 145);
            this.salesPercentage.MaxValue = 200D;
            this.salesPercentage.MinValue = -100D;
            this.salesPercentage.Name = "salesPercentage";
            this.salesPercentage.NullString = "";
            this.salesPercentage.PercentDecimalDigits = 3;
            this.salesPercentage.Size = new System.Drawing.Size(100, 20);
            this.salesPercentage.TabIndex = 57;
            this.salesPercentage.Text = "0.000 %";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(432, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 23);
            this.btnExit.TabIndex = 58;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridViewLedgers
            // 
            this.gridViewLedgers.AllowUserToAddRows = false;
            this.gridViewLedgers.AllowUserToDeleteRows = false;
            this.gridViewLedgers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewLedgers.Location = new System.Drawing.Point(26, 214);
            this.gridViewLedgers.Name = "gridViewLedgers";
            this.gridViewLedgers.ReadOnly = true;
            this.gridViewLedgers.Size = new System.Drawing.Size(304, 278);
            this.gridViewLedgers.TabIndex = 59;
            // 
            // gridViewPercentage
            // 
            this.gridViewPercentage.AllowUserToAddRows = false;
            this.gridViewPercentage.AllowUserToDeleteRows = false;
            this.gridViewPercentage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewPercentage.Location = new System.Drawing.Point(340, 214);
            this.gridViewPercentage.Name = "gridViewPercentage";
            this.gridViewPercentage.ReadOnly = true;
            this.gridViewPercentage.Size = new System.Drawing.Size(318, 278);
            this.gridViewPercentage.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Ledgers Having % Impact";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(337, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "Current Percentage";
            // 
            // frmSalesProductionPercentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 518);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gridViewPercentage);
            this.Controls.Add(this.gridViewLedgers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.salesPercentage);
            this.Controls.Add(this.cmbFromPeriod);
            this.Controls.Add(this.cmbFinYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSalesProductionPercentage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Production";
            this.Load += new System.EventHandler(this.frmSalesProductionPercentage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFromPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLedgers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbProjects;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFinYear;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbFromPeriod;
        private Syncfusion.Windows.Forms.Tools.PercentTextBox salesPercentage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView gridViewLedgers;
        private System.Windows.Forms.DataGridView gridViewPercentage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}