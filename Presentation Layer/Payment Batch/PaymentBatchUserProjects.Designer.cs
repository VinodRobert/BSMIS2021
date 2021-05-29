namespace BSMIS 
{
    partial class PaymentBatchUserProjects
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.cmbBSUsers = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggBSUserMapping = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.chkListProjects = new System.Windows.Forms.CheckedListBox();
            this.lblUserRole = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.chkListProcess = new System.Windows.Forms.CheckedListBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBSUsers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggBSUserMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(271, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(428, 32);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Attaching Users to Projects";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel3.Location = new System.Drawing.Point(13, 46);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(125, 17);
            this.autoLabel3.TabIndex = 3;
            this.autoLabel3.Text = "PB Login Name";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.Blue;
            this.autoLabel1.Location = new System.Drawing.Point(12, 308);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(139, 17);
            this.autoLabel1.TabIndex = 45;
            this.autoLabel1.Text = "Current Mapping";
            // 
            // cmbBSUsers
            // 
            this.cmbBSUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbBSUsers.BeforeTouchSize = new System.Drawing.Size(423, 25);
            this.cmbBSUsers.DisplayMember = "USERNAME";
            this.cmbBSUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBSUsers.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBSUsers.Location = new System.Drawing.Point(13, 66);
            this.cmbBSUsers.Name = "cmbBSUsers";
            this.cmbBSUsers.Size = new System.Drawing.Size(423, 25);
            this.cmbBSUsers.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbBSUsers.TabIndex = 47;
            this.cmbBSUsers.ThemeName = "Office2007";
            this.cmbBSUsers.ValueMember = "LOGINID";
            this.cmbBSUsers.SelectedValueChanged += new System.EventHandler(this.cmbBSUsers_SelectedValueChanged);
            // 
            // autoLabel2
            // 
            this.autoLabel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel2.Location = new System.Drawing.Point(12, 145);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(154, 17);
            this.autoLabel2.TabIndex = 48;
            this.autoLabel2.Text = "Pay Batch Projects";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggBSUserMapping);
            this.panel1.Location = new System.Drawing.Point(13, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 344);
            this.panel1.TabIndex = 50;
            // 
            // ggBSUserMapping
            // 
            this.ggBSUserMapping.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggBSUserMapping.BackColor = System.Drawing.SystemColors.Window;
            this.ggBSUserMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggBSUserMapping.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggBSUserMapping.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggBSUserMapping.Location = new System.Drawing.Point(0, 0);
            this.ggBSUserMapping.Name = "ggBSUserMapping";
            this.ggBSUserMapping.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggBSUserMapping.Size = new System.Drawing.Size(950, 344);
            this.ggBSUserMapping.TabIndex = 6;
            this.ggBSUserMapping.Text = "gridGroupingControl1";
            this.ggBSUserMapping.UseRightToLeftCompatibleTextBox = true;
            this.ggBSUserMapping.VersionInfo = "9.403.0.62";
            // 
            // chkListProjects
            // 
            this.chkListProjects.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListProjects.FormattingEnabled = true;
            this.chkListProjects.Location = new System.Drawing.Point(13, 165);
            this.chkListProjects.Name = "chkListProjects";
            this.chkListProjects.Size = new System.Drawing.Size(423, 130);
            this.chkListProjects.TabIndex = 51;
            // 
            // lblUserRole
            // 
            this.lblUserRole.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.Red;
            this.lblUserRole.Location = new System.Drawing.Point(13, 105);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(15, 17);
            this.lblUserRole.TabIndex = 52;
            this.lblUserRole.Text = "-";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel4.Location = new System.Drawing.Point(503, 145);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(150, 17);
            this.autoLabel4.TabIndex = 53;
            this.autoLabel4.Text = "Pay Batch Process";
            // 
            // chkListProcess
            // 
            this.chkListProcess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkListProcess.FormattingEnabled = true;
            this.chkListProcess.Location = new System.Drawing.Point(503, 165);
            this.chkListProcess.Name = "chkListProcess";
            this.chkListProcess.Size = new System.Drawing.Size(322, 67);
            this.chkListProcess.TabIndex = 54;
            // 
            // btnFetch
            // 
            this.btnFetch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetch.Location = new System.Drawing.Point(503, 57);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(122, 34);
            this.btnFetch.TabIndex = 55;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Red;
            this.btnReset.Location = new System.Drawing.Point(631, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(122, 34);
            this.btnReset.TabIndex = 56;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(841, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 34);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Blue;
            this.btnAdd.Location = new System.Drawing.Point(503, 277);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 34);
            this.btnAdd.TabIndex = 58;
            this.btnAdd.Text = "Append";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.Location = new System.Drawing.Point(297, 140);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(139, 23);
            this.btnCheckAll.TabIndex = 59;
            this.btnCheckAll.Text = "Select All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // PaymentBatchUserProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 684);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.chkListProcess);
            this.Controls.Add(this.autoLabel4);
            this.Controls.Add(this.lblUserRole);
            this.Controls.Add(this.chkListProjects);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.cmbBSUsers);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.autoLabel3);
            this.Controls.Add(this.lblHeader);
            this.Name = "PaymentBatchUserProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Batch - Users";
            this.Load += new System.EventHandler(this.PaymentBatchUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBSUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggBSUserMapping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbBSUsers;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chkListProjects;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggBSUserMapping;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblUserRole;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private System.Windows.Forms.CheckedListBox chkListProcess;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCheckAll;
    }
}