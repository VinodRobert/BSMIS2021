namespace BSMIS
{
    partial class frmDetachUsers
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
            this.cmbLoginUsers = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listACC = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listPOS = new System.Windows.Forms.CheckedListBox();
            this.chkUnChkAcc = new System.Windows.Forms.CheckBox();
            this.chkUnChkPOS = new System.Windows.Forms.CheckBox();
            this.lblAccountAccess = new System.Windows.Forms.Label();
            this.lblPOSAccess = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoginUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(355, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detach Users";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Login ID :";
            // 
            // cmbLoginUsers
            // 
            this.cmbLoginUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbLoginUsers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoginUsers.Location = new System.Drawing.Point(106, 30);
            this.cmbLoginUsers.Name = "cmbLoginUsers";
            this.cmbLoginUsers.Size = new System.Drawing.Size(389, 24);
            this.cmbLoginUsers.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbLoginUsers.TabIndex = 44;
            this.cmbLoginUsers.Text = "comboBoxAdv1";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.Red;
            this.btnShow.Location = new System.Drawing.Point(522, 31);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 45;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(27, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 14);
            this.label3.TabIndex = 46;
            this.label3.Text = "Accounts Access";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listACC);
            this.panel1.Location = new System.Drawing.Point(30, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 369);
            this.panel1.TabIndex = 47;
            // 
            // listACC
            // 
            this.listACC.CheckOnClick = true;
            this.listACC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listACC.FormattingEnabled = true;
            this.listACC.Location = new System.Drawing.Point(-1, 7);
            this.listACC.Name = "listACC";
            this.listACC.ScrollAlwaysVisible = true;
            this.listACC.Size = new System.Drawing.Size(342, 356);
            this.listACC.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(411, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "Procurement Access";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.listPOS);
            this.panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(414, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 369);
            this.panel2.TabIndex = 49;
            // 
            // listPOS
            // 
            this.listPOS.CheckOnClick = true;
            this.listPOS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPOS.FormattingEnabled = true;
            this.listPOS.Location = new System.Drawing.Point(1, 5);
            this.listPOS.Name = "listPOS";
            this.listPOS.ScrollAlwaysVisible = true;
            this.listPOS.Size = new System.Drawing.Size(342, 356);
            this.listPOS.TabIndex = 37;
            // 
            // chkUnChkAcc
            // 
            this.chkUnChkAcc.AutoSize = true;
            this.chkUnChkAcc.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkAcc.Location = new System.Drawing.Point(278, 99);
            this.chkUnChkAcc.Name = "chkUnChkAcc";
            this.chkUnChkAcc.Size = new System.Drawing.Size(98, 19);
            this.chkUnChkAcc.TabIndex = 50;
            this.chkUnChkAcc.Text = "Check/Un Check";
            this.chkUnChkAcc.UseVisualStyleBackColor = true;
            this.chkUnChkAcc.CheckedChanged += new System.EventHandler(this.chkUnChkAcc_CheckedChanged);
            // 
            // chkUnChkPOS
            // 
            this.chkUnChkPOS.AutoSize = true;
            this.chkUnChkPOS.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUnChkPOS.Location = new System.Drawing.Point(660, 99);
            this.chkUnChkPOS.Name = "chkUnChkPOS";
            this.chkUnChkPOS.Size = new System.Drawing.Size(98, 19);
            this.chkUnChkPOS.TabIndex = 38;
            this.chkUnChkPOS.Text = "Check/Un Check";
            this.chkUnChkPOS.UseVisualStyleBackColor = true;
            this.chkUnChkPOS.CheckedChanged += new System.EventHandler(this.chkUnChkPOS_CheckedChanged);
            // 
            // lblAccountAccess
            // 
            this.lblAccountAccess.AutoSize = true;
            this.lblAccountAccess.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountAccess.ForeColor = System.Drawing.Color.Red;
            this.lblAccountAccess.Location = new System.Drawing.Point(138, 99);
            this.lblAccountAccess.Name = "lblAccountAccess";
            this.lblAccountAccess.Size = new System.Drawing.Size(47, 13);
            this.lblAccountAccess.TabIndex = 51;
            this.lblAccountAccess.Text = "label5";
            this.lblAccountAccess.Visible = false;
            // 
            // lblPOSAccess
            // 
            this.lblPOSAccess.AutoSize = true;
            this.lblPOSAccess.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOSAccess.ForeColor = System.Drawing.Color.Blue;
            this.lblPOSAccess.Location = new System.Drawing.Point(550, 99);
            this.lblPOSAccess.Name = "lblPOSAccess";
            this.lblPOSAccess.Size = new System.Drawing.Size(47, 13);
            this.lblPOSAccess.TabIndex = 52;
            this.lblPOSAccess.Text = "label6";
            this.lblPOSAccess.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(103, 66);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(76, 16);
            this.lblUserName.TabIndex = 53;
            this.lblUserName.Text = "Login ID :";
            this.lblUserName.Visible = false;
            // 
            // frmDetachUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 508);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPOSAccess);
            this.Controls.Add(this.lblAccountAccess);
            this.Controls.Add(this.chkUnChkPOS);
            this.Controls.Add(this.chkUnChkAcc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbLoginUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDetachUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detach Users";
            this.Load += new System.EventHandler(this.frmDetachUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbLoginUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbLoginUsers;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox listACC;
        private System.Windows.Forms.CheckedListBox listPOS;
        private System.Windows.Forms.CheckBox chkUnChkAcc;
        private System.Windows.Forms.CheckBox chkUnChkPOS;
        private System.Windows.Forms.Label lblAccountAccess;
        private System.Windows.Forms.Label lblPOSAccess;
        private System.Windows.Forms.Label lblUserName;
    }
}