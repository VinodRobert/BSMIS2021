namespace BSMIS
{
    partial class frmMasterCategory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetIt = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cmbMaterType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnDelete = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.ggMasterCategory = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggMasterCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(255, -2);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(273, 32);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Master Category ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggMasterCategory);
            this.panel1.Location = new System.Drawing.Point(16, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 370);
            this.panel1.TabIndex = 3;
            // 
            // btnGetIt
            // 
            this.btnGetIt.BackColor = System.Drawing.Color.Blue;
            this.btnGetIt.BeforeTouchSize = new System.Drawing.Size(78, 36);
            this.btnGetIt.ForeColor = System.Drawing.Color.White;
            this.btnGetIt.Location = new System.Drawing.Point(320, 47);
            this.btnGetIt.Name = "btnGetIt";
            this.btnGetIt.Size = new System.Drawing.Size(78, 36);
            this.btnGetIt.TabIndex = 79;
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
            this.cmbMaterType.Location = new System.Drawing.Point(117, 47);
            this.cmbMaterType.Name = "cmbMaterType";
            this.cmbMaterType.Size = new System.Drawing.Size(197, 26);
            this.cmbMaterType.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cmbMaterType.TabIndex = 78;
            this.cmbMaterType.ThemeName = "Office2007Outlook";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(170, 108);
            this.txtCategoryName.Multiline = true;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(618, 31);
            this.txtCategoryName.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Category Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 75;
            this.label4.Text = "Master  ";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnNew.BeforeTouchSize = new System.Drawing.Size(78, 36);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(542, 47);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(78, 36);
            this.btnNew.TabIndex = 80;
            this.btnNew.Text = "Update";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.BeforeTouchSize = new System.Drawing.Size(78, 36);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(626, 47);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 36);
            this.btnDelete.TabIndex = 81;
            this.btnDelete.Text = "Cancel";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(78, 36);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(710, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 36);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.Text = "Update";
            // 
            // ggMasterCategory
            // 
            this.ggMasterCategory.BackColor = System.Drawing.SystemColors.Window;
            this.ggMasterCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggMasterCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggMasterCategory.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggMasterCategory.Location = new System.Drawing.Point(0, 0);
            this.ggMasterCategory.Margin = new System.Windows.Forms.Padding(4);
            this.ggMasterCategory.Name = "ggMasterCategory";
            this.ggMasterCategory.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggMasterCategory.Size = new System.Drawing.Size(772, 370);
            this.ggMasterCategory.TabIndex = 4;
            this.ggMasterCategory.Text = "gridGroupingControl1";
            this.ggMasterCategory.UseRightToLeftCompatibleTextBox = true;
            this.ggMasterCategory.VersionInfo = "9.403.0.62";
            // 
            // frmMasterCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnGetIt);
            this.Controls.Add(this.cmbMaterType);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmMasterCategory";
            this.Text = "Master Category | List";
            this.Load += new System.EventHandler(this.frmMasterCategory_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMaterType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ggMasterCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnGetIt;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbMaterType;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.ButtonAdv btnNew;
        private Syncfusion.Windows.Forms.ButtonAdv btnDelete;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggMasterCategory;
    }
}