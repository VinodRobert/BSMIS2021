namespace BSMIS 
{
    partial class frmMasterCategoryList
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
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnGetIt = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cmbMaterType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggMasterCategoryList = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblValidated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterType)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggMasterCategoryList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(372, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(327, 32);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Master Category List";
            // 
            // btnGetIt
            // 
            this.btnGetIt.BackColor = System.Drawing.Color.Blue;
            this.btnGetIt.BeforeTouchSize = new System.Drawing.Size(107, 36);
            this.btnGetIt.ForeColor = System.Drawing.Color.White;
            this.btnGetIt.Location = new System.Drawing.Point(277, 45);
            this.btnGetIt.Name = "btnGetIt";
            this.btnGetIt.Size = new System.Drawing.Size(107, 36);
            this.btnGetIt.TabIndex = 82;
            this.btnGetIt.Text = "Get";
            this.btnGetIt.Click += new System.EventHandler(this.btnGetIt_Click);
            // 
            // cmbMaterType
            // 
            this.cmbMaterType.BeforeTouchSize = new System.Drawing.Size(197, 26);
            this.cmbMaterType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbMaterType.Items.AddRange(new object[] {
            "Please Select",
            "Creditors",
            "Sub Contractors"});
            this.cmbMaterType.Location = new System.Drawing.Point(74, 49);
            this.cmbMaterType.Name = "cmbMaterType";
            this.cmbMaterType.Size = new System.Drawing.Size(197, 26);
            this.cmbMaterType.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cmbMaterType.TabIndex = 81;
            this.cmbMaterType.ThemeName = "Office2007Outlook";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 80;
            this.label4.Text = "Mater";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "Attach Excel File ";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(176, 111);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(48, 23);
            this.btnBrowse.TabIndex = 84;
            this.btnBrowse.Text = "....";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggMasterCategoryList);
            this.panel1.Location = new System.Drawing.Point(15, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 493);
            this.panel1.TabIndex = 85;
            // 
            // ggMasterCategoryList
            // 
            this.ggMasterCategoryList.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggMasterCategoryList.BackColor = System.Drawing.SystemColors.Window;
            this.ggMasterCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggMasterCategoryList.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggMasterCategoryList.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggMasterCategoryList.Location = new System.Drawing.Point(0, 0);
            this.ggMasterCategoryList.Margin = new System.Windows.Forms.Padding(4);
            this.ggMasterCategoryList.Name = "ggMasterCategoryList";
            this.ggMasterCategoryList.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggMasterCategoryList.Size = new System.Drawing.Size(1024, 493);
            this.ggMasterCategoryList.TabIndex = 5;
            this.ggMasterCategoryList.Text = "gridGroupingControl1";
            this.ggMasterCategoryList.UseRightToLeftCompatibleTextBox = true;
            this.ggMasterCategoryList.VersionInfo = "9.403.0.62";
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(703, 103);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(108, 34);
            this.btnRead.TabIndex = 86;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.Location = new System.Drawing.Point(817, 103);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(108, 34);
            this.btnValidate.TabIndex = 87;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(931, 103);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(108, 34);
            this.btnUpload.TabIndex = 88;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(176, 141);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(54, 17);
            this.lblFileName.TabIndex = 89;
            this.lblFileName.Text = "label2";
            // 
            // lblValidated
            // 
            this.lblValidated.AutoSize = true;
            this.lblValidated.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidated.ForeColor = System.Drawing.Color.Red;
            this.lblValidated.Location = new System.Drawing.Point(841, 140);
            this.lblValidated.Name = "lblValidated";
            this.lblValidated.Size = new System.Drawing.Size(84, 20);
            this.lblValidated.TabIndex = 90;
            this.lblValidated.Text = "Valid !!! ";
            // 
            // frmMasterCategoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 711);
            this.Controls.Add(this.lblValidated);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetIt);
            this.Controls.Add(this.cmbMaterType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmMasterCategoryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master Category List";
            this.Load += new System.EventHandler(this.frmMasterCategoryList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterType)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggMasterCategoryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.ButtonAdv btnGetIt;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbMaterType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggMasterCategoryList;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblValidated;
    }
}