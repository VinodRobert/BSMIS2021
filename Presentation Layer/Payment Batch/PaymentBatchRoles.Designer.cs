namespace BSMIS 
{
    partial class PaymentBatchRoles
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
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggProjects = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbPBRoleLevel = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPBRoleLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(158, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(405, 32);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Payment Batching - Roles";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(12, 69);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(129, 17);
            this.autoLabel3.TabIndex = 3;
            this.autoLabel3.Text = "New Role Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(611, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 25);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "Add To List";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggProjects);
            this.panel1.Location = new System.Drawing.Point(13, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 482);
            this.panel1.TabIndex = 44;
            // 
            // ggProjects
            // 
            this.ggProjects.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggProjects.BackColor = System.Drawing.SystemColors.Window;
            this.ggProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggProjects.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggProjects.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggProjects.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggProjects.Location = new System.Drawing.Point(0, 0);
            this.ggProjects.Name = "ggProjects";
            this.ggProjects.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggProjects.Size = new System.Drawing.Size(719, 482);
            this.ggProjects.TabIndex = 3;
            this.ggProjects.Text = "gridGroupingControl1";
            this.ggProjects.UseRightToLeftCompatibleTextBox = true;
            this.ggProjects.VersionInfo = "9.403.0.62";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(13, 146);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(171, 17);
            this.autoLabel1.TabIndex = 45;
            this.autoLabel1.Text = "Payment Batch Roles";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(611, 135);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 25);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(158, 69);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(405, 22);
            this.txtRoleName.TabIndex = 47;
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(12, 113);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(87, 17);
            this.autoLabel2.TabIndex = 48;
            this.autoLabel2.Text = "Role Level";
            // 
            // cmbPBRoleLevel
            // 
            this.cmbPBRoleLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbPBRoleLevel.DisplayMember = " ";
            this.cmbPBRoleLevel.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPBRoleLevel.Items.AddRange(new object[] {
            "Initiator- Level Zero",
            "First Level Approver - Level One",
            "Second Level Approver - Level Two",
            "Cheque Printing / Posting - Level Three"});
            this.cmbPBRoleLevel.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbPBRoleLevel, "Initiator- Level Zero"));
            this.cmbPBRoleLevel.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbPBRoleLevel, "First Level Approver - Level One"));
            this.cmbPBRoleLevel.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbPBRoleLevel, "Second Level Approver - Level Two"));
            this.cmbPBRoleLevel.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbPBRoleLevel, "Cheque Printing / Posting - Level Three"));
            this.cmbPBRoleLevel.Location = new System.Drawing.Point(158, 105);
            this.cmbPBRoleLevel.Name = "cmbPBRoleLevel";
            this.cmbPBRoleLevel.Size = new System.Drawing.Size(405, 28);
            this.cmbPBRoleLevel.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbPBRoleLevel.TabIndex = 50;
            this.cmbPBRoleLevel.ValueMember = " ";
            // 
            // PaymentBatchRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 684);
            this.Controls.Add(this.cmbPBRoleLevel);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.lblHeader);
            this.Name = "PaymentBatchRoles";
            this.Text = "Payment Batch - Roles";
            this.Load += new System.EventHandler(this.PaymentBatchProjects_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPBRoleLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggProjects;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRoleName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbPBRoleLevel;
    }
}