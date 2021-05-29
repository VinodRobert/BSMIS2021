namespace BSMIS 
{
    partial class PaymentBatchUsers
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbBSUsers = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbPBRole = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggBSUsers = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBSUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPBRole)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggBSUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(271, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(407, 32);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Payment Batching - Users";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(12, 61);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(125, 17);
            this.autoLabel3.TabIndex = 3;
            this.autoLabel3.Text = "BS Login Name";
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
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(13, 172);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(172, 17);
            this.autoLabel1.TabIndex = 45;
            this.autoLabel1.Text = "Payment Batch Users";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(611, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 25);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbBSUsers
            // 
            this.cmbBSUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbBSUsers.BeforeTouchSize = new System.Drawing.Size(437, 25);
            this.cmbBSUsers.DisplayMember = "USERNAME";
            this.cmbBSUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBSUsers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBSUsers.Location = new System.Drawing.Point(158, 61);
            this.cmbBSUsers.Name = "cmbBSUsers";
            this.cmbBSUsers.Size = new System.Drawing.Size(437, 25);
            this.cmbBSUsers.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbBSUsers.TabIndex = 47;
            this.cmbBSUsers.ThemeName = "Office2007";
            this.cmbBSUsers.ValueMember = "LOGINID";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(13, 104);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(124, 17);
            this.autoLabel2.TabIndex = 48;
            this.autoLabel2.Text = "Pay Batch Role";
            // 
            // cmbPBRole
            // 
            this.cmbPBRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbPBRole.BeforeTouchSize = new System.Drawing.Size(437, 25);
            this.cmbPBRole.DisplayMember = "LEVELNAME";
            this.cmbPBRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPBRole.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPBRole.Location = new System.Drawing.Point(158, 104);
            this.cmbPBRole.Name = "cmbPBRole";
            this.cmbPBRole.Size = new System.Drawing.Size(437, 25);
            this.cmbPBRole.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbPBRole.TabIndex = 49;
            this.cmbPBRole.ThemeName = "Office2007";
            this.cmbPBRole.ValueMember = "APPROVERLEVELID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggBSUsers);
            this.panel1.Location = new System.Drawing.Point(13, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 471);
            this.panel1.TabIndex = 50;
            // 
            // ggBSUsers
            // 
            this.ggBSUsers.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggBSUsers.BackColor = System.Drawing.SystemColors.Window;
            this.ggBSUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggBSUsers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggBSUsers.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggBSUsers.Location = new System.Drawing.Point(0, 0);
            this.ggBSUsers.Name = "ggBSUsers";
            this.ggBSUsers.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggBSUsers.Size = new System.Drawing.Size(950, 471);
            this.ggBSUsers.TabIndex = 4;
            this.ggBSUsers.Text = "gridGroupingControl1";
            this.ggBSUsers.UseRightToLeftCompatibleTextBox = true;
            this.ggBSUsers.VersionInfo = "9.403.0.62";
            // 
            // PaymentBatchUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 684);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbPBRole);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.cmbBSUsers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.lblHeader);
            this.Name = "PaymentBatchUsers";
            this.Text = "Payment Batch - Users";
            this.Load += new System.EventHandler(this.PaymentBatchUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBSUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPBRole)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggBSUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.Button btnAdd;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.Button btnClose;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbBSUsers;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbPBRole;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggBSUsers;
    }
}