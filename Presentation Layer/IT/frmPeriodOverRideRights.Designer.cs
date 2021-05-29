namespace BSMIS 
{
    partial class frmPeriodOverRideRights
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblListofUsers = new System.Windows.Forms.Label();
            this.cmbUsers = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnRevokeNow = new System.Windows.Forms.Button();
            this.lblNIL = new System.Windows.Forms.Label();
            this.gridPeriodOverRide = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodOverRide)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(275, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Users With Period Over Rider Rights - LIVE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(35, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(692, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Following User Logins are Having Period Over Ride Rights. They Can Post Entries t" +
    "o ALL OPEN PERIODS.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(35, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(568, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "However They Cannot Do Any Transactions ON Closed Periods ( Closed After Audit )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(518, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Period Over Ride Rights will be Revoked Automatically at the End of the DAY.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridPeriodOverRide);
            this.panel1.Location = new System.Drawing.Point(38, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 348);
            this.panel1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(476, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblListofUsers
            // 
            this.lblListofUsers.AutoSize = true;
            this.lblListofUsers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListofUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblListofUsers.Location = new System.Drawing.Point(473, 226);
            this.lblListofUsers.Name = "lblListofUsers";
            this.lblListofUsers.Size = new System.Drawing.Size(246, 14);
            this.lblListofUsers.TabIndex = 7;
            this.lblListofUsers.Text = "Revoke Period Over Ride Rights  Of ";
            // 
            // cmbUsers
            // 
            this.cmbUsers.Location = new System.Drawing.Point(476, 254);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(436, 22);
            this.cmbUsers.TabIndex = 8;
            this.cmbUsers.Text = "comboBoxAdv1";
            // 
            // btnRevokeNow
            // 
            this.btnRevokeNow.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevokeNow.Location = new System.Drawing.Point(777, 282);
            this.btnRevokeNow.Name = "btnRevokeNow";
            this.btnRevokeNow.Size = new System.Drawing.Size(135, 28);
            this.btnRevokeNow.TabIndex = 9;
            this.btnRevokeNow.Text = "Revoke Now";
            this.btnRevokeNow.UseVisualStyleBackColor = true;
            this.btnRevokeNow.Click += new System.EventHandler(this.btnRevokeNow_Click);
            // 
            // lblNIL
            // 
            this.lblNIL.AutoSize = true;
            this.lblNIL.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIL.Location = new System.Drawing.Point(473, 450);
            this.lblNIL.Name = "lblNIL";
            this.lblNIL.Size = new System.Drawing.Size(239, 16);
            this.lblNIL.TabIndex = 10;
            this.lblNIL.Text = "No Body Having The Rightst NOW. ";
            // 
            // gridPeriodOverRide
            // 
            this.gridPeriodOverRide.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridPeriodOverRide.BackColor = System.Drawing.SystemColors.Window;
            this.gridPeriodOverRide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPeriodOverRide.ForeColor = System.Drawing.Color.Blue;
            this.gridPeriodOverRide.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridPeriodOverRide.Location = new System.Drawing.Point(0, 0);
            this.gridPeriodOverRide.Name = "gridPeriodOverRide";
            this.gridPeriodOverRide.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridPeriodOverRide.Size = new System.Drawing.Size(432, 348);
            this.gridPeriodOverRide.TabIndex = 5;
            this.gridPeriodOverRide.Text = "gridGroupingControl1";
            this.gridPeriodOverRide.UseRightToLeftCompatibleTextBox = true;
            this.gridPeriodOverRide.VersionInfo = "9.403.0.62";
            this.gridPeriodOverRide.WantTabKey = false;
            // 
            // frmPeriodOverRideRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 527);
            this.Controls.Add(this.lblNIL);
            this.Controls.Add(this.btnRevokeNow);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.lblListofUsers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPeriodOverRideRights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Period Over Ride Rights";
            this.Load += new System.EventHandler(this.frmPeriodOverRideRights_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPeriodOverRide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblListofUsers;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbUsers;
        private System.Windows.Forms.Button btnRevokeNow;
        private System.Windows.Forms.Label lblNIL;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridPeriodOverRide;
    }
}