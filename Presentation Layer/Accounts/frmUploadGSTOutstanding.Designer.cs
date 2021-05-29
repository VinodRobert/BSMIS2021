namespace BSMIS 
{
    partial class frmUploadGSTOutstanding
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridTransID = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lblValidated = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransID)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(231, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "GST Un Paid Uploading";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Name ?";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(146, 61);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(60, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = ".....";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(142, 97);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(15, 20);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = ".";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(34, 133);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(172, 34);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Read File";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(206, 133);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(172, 34);
            this.btnValidate.TabIndex = 5;
            this.btnValidate.Text = "Validate File";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(377, 133);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(172, 34);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload File";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridTransID);
            this.panel1.Location = new System.Drawing.Point(34, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 528);
            this.panel1.TabIndex = 7;
            // 
            // gridTransID
            // 
            this.gridTransID.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.gridTransID.BackColor = System.Drawing.SystemColors.Window;
            this.gridTransID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTransID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTransID.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.gridTransID.Location = new System.Drawing.Point(0, 0);
            this.gridTransID.Name = "gridTransID";
            this.gridTransID.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridTransID.Size = new System.Drawing.Size(528, 528);
            this.gridTransID.TabIndex = 5;
            this.gridTransID.Text = "gridGroupingControl1";
            this.gridTransID.UseRightToLeftCompatibleTextBox = true;
            this.gridTransID.VersionInfo = "9.403.0.62";
            // 
            // lblValidated
            // 
            this.lblValidated.AutoSize = true;
            this.lblValidated.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidated.ForeColor = System.Drawing.Color.Red;
            this.lblValidated.Location = new System.Drawing.Point(202, 110);
            this.lblValidated.Name = "lblValidated";
            this.lblValidated.Size = new System.Drawing.Size(32, 25);
            this.lblValidated.TabIndex = 8;
            this.lblValidated.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(29, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Existing Entries will be Overwritten";
            // 
            // frmUploadGSTOutstanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 724);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblValidated);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUploadGSTOutstanding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GST - Un Paid Outstanding";
            this.Load += new System.EventHandler(this.frmUploadForTransactionMatching_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridTransID;
        private System.Windows.Forms.Label lblValidated;
        private System.Windows.Forms.Label label3;
    }
}