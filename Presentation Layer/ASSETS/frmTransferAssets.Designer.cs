namespace BSMIS 
{
    partial class frmTransferAssets
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggDetail = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridGroupingControl1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.gridGroupingControl2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbAssetNumber = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbNewLocation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblAssetLocation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.lblAssetName = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNewLocation = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNewLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(550, 3);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(181, 25);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Asset Transfer";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggDetail);
            this.panel1.Location = new System.Drawing.Point(9, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 495);
            this.panel1.TabIndex = 43;
            // 
            // ggDetail
            // 
            this.ggDetail.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggDetail.BackColor = System.Drawing.SystemColors.Window;
            this.ggDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggDetail.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggDetail.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggDetail.Location = new System.Drawing.Point(0, 0);
            this.ggDetail.Name = "ggDetail";
            this.ggDetail.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggDetail.Size = new System.Drawing.Size(665, 495);
            this.ggDetail.TabIndex = 3;
            this.ggDetail.Text = "gridGroupingControl1";
            this.ggDetail.UseRightToLeftCompatibleTextBox = true;
            this.ggDetail.VersionInfo = "9.403.0.62";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridGroupingControl1);
            this.panel2.Controls.Add(this.gridGroupingControl2);
            this.panel2.Location = new System.Drawing.Point(8, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1267, 525);
            this.panel2.TabIndex = 42;
            // 
            // gridGroupingControl1
            // 
            this.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridGroupingControl1.BackColor = System.Drawing.SystemColors.Window;
            this.gridGroupingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroupingControl1.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Silver;
            this.gridGroupingControl1.Location = new System.Drawing.Point(0, 0);
            this.gridGroupingControl1.Name = "gridGroupingControl1";
            this.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridGroupingControl1.Size = new System.Drawing.Size(1267, 525);
            this.gridGroupingControl1.TabIndex = 1;
            this.gridGroupingControl1.Text = "gridGroupingControl1";
            this.gridGroupingControl1.UseRightToLeftCompatibleTextBox = true;
            this.gridGroupingControl1.VersionInfo = "9.403.0.62";
            // 
            // gridGroupingControl2
            // 
            this.gridGroupingControl2.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridGroupingControl2.BackColor = System.Drawing.SystemColors.Window;
            this.gridGroupingControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGroupingControl2.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridGroupingControl2.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.gridGroupingControl2.Location = new System.Drawing.Point(0, 0);
            this.gridGroupingControl2.Name = "gridGroupingControl2";
            this.gridGroupingControl2.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridGroupingControl2.Size = new System.Drawing.Size(1267, 525);
            this.gridGroupingControl2.TabIndex = 0;
            this.gridGroupingControl2.Text = "gridGroupingControl1";
            this.gridGroupingControl2.UseRightToLeftCompatibleTextBox = true;
            this.gridGroupingControl2.VersionInfo = "9.403.0.62";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(691, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Asset Number ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Asset Current Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(691, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Asset New Location";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(1149, 265);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 47;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbAssetNumber
            // 
            this.cmbAssetNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAssetNumber.Location = new System.Drawing.Point(869, 64);
            this.cmbAssetNumber.Name = "cmbAssetNumber";
            this.cmbAssetNumber.Size = new System.Drawing.Size(140, 22);
            this.cmbAssetNumber.TabIndex = 48;
            this.cmbAssetNumber.Text = " ";
            // 
            // cmbNewLocation
            // 
            this.cmbNewLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNewLocation.Location = new System.Drawing.Point(869, 214);
            this.cmbNewLocation.Name = "cmbNewLocation";
            this.cmbNewLocation.Size = new System.Drawing.Size(274, 22);
            this.cmbNewLocation.TabIndex = 49;
            this.cmbNewLocation.Text = " ";
            // 
            // lblAssetLocation
            // 
            this.lblAssetLocation.AutoSize = true;
            this.lblAssetLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetLocation.Location = new System.Drawing.Point(866, 171);
            this.lblAssetLocation.Name = "lblAssetLocation";
            this.lblAssetLocation.Size = new System.Drawing.Size(13, 16);
            this.lblAssetLocation.TabIndex = 50;
            this.lblAssetLocation.Text = ".";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(691, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Asset Name";
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Location = new System.Drawing.Point(1015, 64);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(44, 23);
            this.btnGet.TabIndex = 52;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // lblAssetName
            // 
            this.lblAssetName.AutoSize = true;
            this.lblAssetName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssetName.Location = new System.Drawing.Point(866, 117);
            this.lblAssetName.Name = "lblAssetName";
            this.lblAssetName.Size = new System.Drawing.Size(18, 16);
            this.lblAssetName.TabIndex = 53;
            this.lblAssetName.Text = ". ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(1149, 213);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 54;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(691, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 55;
            this.label5.Text = "Asset New Location";
            // 
            // lblNewLocation
            // 
            this.lblNewLocation.AutoSize = true;
            this.lblNewLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewLocation.Location = new System.Drawing.Point(866, 268);
            this.lblNewLocation.Name = "lblNewLocation";
            this.lblNewLocation.Size = new System.Drawing.Size(13, 16);
            this.lblNewLocation.TabIndex = 56;
            this.lblNewLocation.Text = ".";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(694, 340);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(83, 23);
            this.btnClear.TabIndex = 57;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmTransferAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 592);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblNewLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblAssetName);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAssetLocation);
            this.Controls.Add(this.cmbNewLocation);
            this.Controls.Add(this.cmbAssetNumber);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmTransferAssets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asset Location Change";
            this.Load += new System.EventHandler(this.frmAssetMaster_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggDetail)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGroupingControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNewLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridGroupingControl2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbAssetNumber;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbNewLocation;
        private System.Windows.Forms.Label lblAssetLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label lblAssetName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNewLocation;
        private System.Windows.Forms.Button btnClear;
    }
}