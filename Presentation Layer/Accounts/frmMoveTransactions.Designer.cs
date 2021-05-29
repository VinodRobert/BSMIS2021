namespace BSMIS
{
    partial class frmMoveTransactions
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrangrp = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ggTransGroup = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtYesNo = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.panelTransfer = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewPeriod = new System.Windows.Forms.TextBox();
            this.txtNewYear = new System.Windows.Forms.TextBox();
            this.dtNewDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggTransGroup)).BeginInit();
            this.panelTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(446, 18);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(230, 25);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Move Transactions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trans Group";
            // 
            // txtTrangrp
            // 
            this.txtTrangrp.Location = new System.Drawing.Point(132, 49);
            this.txtTrangrp.Name = "txtTrangrp";
            this.txtTrangrp.Size = new System.Drawing.Size(100, 20);
            this.txtTrangrp.TabIndex = 4;
            this.txtTrangrp.Visible = false;
            this.txtTrangrp.TextChanged += new System.EventHandler(this.txtTrangrp_TextChanged);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(256, 47);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show ";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggTransGroup);
            this.panel1.Location = new System.Drawing.Point(31, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 270);
            this.panel1.TabIndex = 6;
            // 
            // ggTransGroup
            // 
            this.ggTransGroup.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggTransGroup.BackColor = System.Drawing.SystemColors.Window;
            this.ggTransGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggTransGroup.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggTransGroup.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggTransGroup.Location = new System.Drawing.Point(0, 0);
            this.ggTransGroup.Name = "ggTransGroup";
            this.ggTransGroup.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggTransGroup.Size = new System.Drawing.Size(956, 270);
            this.ggTransGroup.TabIndex = 1;
            this.ggTransGroup.Text = "gridGroupingControl1";
            this.ggTransGroup.UseRightToLeftCompatibleTextBox = true;
            this.ggTransGroup.VersionInfo = "9.403.0.62";
            this.ggTransGroup.Visible = false;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(717, 372);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(121, 16);
            this.lblConfirm.TabIndex = 7;
            this.lblConfirm.Text = "Confirm (Yes/No)";
            this.lblConfirm.Visible = false;
            // 
            // txtYesNo
            // 
            this.txtYesNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYesNo.Location = new System.Drawing.Point(858, 370);
            this.txtYesNo.Name = "txtYesNo";
            this.txtYesNo.Size = new System.Drawing.Size(100, 22);
            this.txtYesNo.TabIndex = 2;
            this.txtYesNo.Text = "No";
            this.txtYesNo.Visible = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(720, 401);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(75, 23);
            this.btnTransfer.TabIndex = 3;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Visible = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // panelTransfer
            // 
            this.panelTransfer.Controls.Add(this.label6);
            this.panelTransfer.Controls.Add(this.txtNewPeriod);
            this.panelTransfer.Controls.Add(this.txtNewYear);
            this.panelTransfer.Controls.Add(this.dtNewDate);
            this.panelTransfer.Controls.Add(this.label5);
            this.panelTransfer.Controls.Add(this.label4);
            this.panelTransfer.Controls.Add(this.label3);
            this.panelTransfer.Controls.Add(this.label2);
            this.panelTransfer.Location = new System.Drawing.Point(276, 370);
            this.panelTransfer.Name = "panelTransfer";
            this.panelTransfer.Size = new System.Drawing.Size(427, 145);
            this.panelTransfer.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(13, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(362, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "No Validations Done. Correctness is your responsibility";
            // 
            // txtNewPeriod
            // 
            this.txtNewPeriod.Location = new System.Drawing.Point(104, 69);
            this.txtNewPeriod.Name = "txtNewPeriod";
            this.txtNewPeriod.Size = new System.Drawing.Size(74, 20);
            this.txtNewPeriod.TabIndex = 2;
            // 
            // txtNewYear
            // 
            this.txtNewYear.Location = new System.Drawing.Point(104, 34);
            this.txtNewYear.Name = "txtNewYear";
            this.txtNewYear.Size = new System.Drawing.Size(74, 20);
            this.txtNewYear.TabIndex = 1;
            // 
            // dtNewDate
            // 
            this.dtNewDate.Location = new System.Drawing.Point(104, 105);
            this.dtNewDate.Name = "dtNewDate";
            this.dtNewDate.Size = new System.Drawing.Size(238, 20);
            this.dtNewDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Period :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Year :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "New :";
            // 
            // frmMoveTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 518);
            this.Controls.Add(this.panelTransfer);
            this.Controls.Add(this.txtYesNo);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtTrangrp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHeader);
            this.Name = "frmMoveTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Transactions";
            this.Load += new System.EventHandler(this.frmMoveTransactions_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggTransGroup)).EndInit();
            this.panelTransfer.ResumeLayout(false);
            this.panelTransfer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrangrp;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggTransGroup;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtYesNo;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Panel panelTransfer;
        private System.Windows.Forms.TextBox txtNewPeriod;
        private System.Windows.Forms.TextBox txtNewYear;
        private System.Windows.Forms.DateTimePicker dtNewDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}