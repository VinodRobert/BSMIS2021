namespace BSMIS 
{
    partial class PaymentBatchBanks
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
            this.panelAddress = new System.Windows.Forms.Panel();
            this.btnUpdateBankAddress = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.panelReference = new System.Windows.Forms.Panel();
            this.btnReference = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtYearReference = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelPayMode = new System.Windows.Forms.Panel();
            this.btnPayMode = new System.Windows.Forms.Button();
            this.rdAPI = new System.Windows.Forms.RadioButton();
            this.rdRTGS = new System.Windows.Forms.RadioButton();
            this.rdCheque = new System.Windows.Forms.RadioButton();
            this.ggProjects = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panel1.SuspendLayout();
            this.panelAddress.SuspendLayout();
            this.panelReference.SuspendLayout();
            this.panelPayMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(564, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(414, 32);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Payment Batching - Banks";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggProjects);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1592, 261);
            this.panel1.TabIndex = 44;
            // 
            // panelAddress
            // 
            this.panelAddress.Controls.Add(this.btnUpdateBankAddress);
            this.panelAddress.Controls.Add(this.label5);
            this.panelAddress.Controls.Add(this.label4);
            this.panelAddress.Controls.Add(this.label3);
            this.panelAddress.Controls.Add(this.txtPIN);
            this.panelAddress.Controls.Add(this.txtState);
            this.panelAddress.Controls.Add(this.txtAddress3);
            this.panelAddress.Controls.Add(this.txtAddress2);
            this.panelAddress.Controls.Add(this.label2);
            this.panelAddress.Controls.Add(this.txtAddress1);
            this.panelAddress.Controls.Add(this.label1);
            this.panelAddress.Location = new System.Drawing.Point(3, 382);
            this.panelAddress.Name = "panelAddress";
            this.panelAddress.Size = new System.Drawing.Size(805, 290);
            this.panelAddress.TabIndex = 45;
            this.panelAddress.Visible = false;
            // 
            // btnUpdateBankAddress
            // 
            this.btnUpdateBankAddress.Location = new System.Drawing.Point(550, 246);
            this.btnUpdateBankAddress.Name = "btnUpdateBankAddress";
            this.btnUpdateBankAddress.Size = new System.Drawing.Size(252, 39);
            this.btnUpdateBankAddress.TabIndex = 10;
            this.btnUpdateBankAddress.Text = "Update Bank Address";
            this.btnUpdateBankAddress.UseVisualStyleBackColor = true;
            this.btnUpdateBankAddress.Click += new System.EventHandler(this.btnUpdateBankAddress_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "PIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "State";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Address (2) :";
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(116, 250);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(147, 22);
            this.txtPIN.TabIndex = 6;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(116, 201);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(330, 22);
            this.txtState.TabIndex = 5;
            // 
            // txtAddress3
            // 
            this.txtAddress3.Location = new System.Drawing.Point(116, 154);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(672, 22);
            this.txtAddress3.TabIndex = 4;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(116, 97);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(672, 22);
            this.txtAddress2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address (2) :";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(116, 36);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(672, 22);
            this.txtAddress1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address (1) :";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.Location = new System.Drawing.Point(3, 338);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(95, 29);
            this.lblBankName.TabIndex = 46;
            this.lblBankName.Text = "label6";
            this.lblBankName.Visible = false;
            // 
            // panelReference
            // 
            this.panelReference.Controls.Add(this.btnReference);
            this.panelReference.Controls.Add(this.label8);
            this.panelReference.Controls.Add(this.txtSerialNumber);
            this.panelReference.Controls.Add(this.txtYearReference);
            this.panelReference.Controls.Add(this.label9);
            this.panelReference.Controls.Add(this.txtReference);
            this.panelReference.Controls.Add(this.label10);
            this.panelReference.Location = new System.Drawing.Point(829, 382);
            this.panelReference.Name = "panelReference";
            this.panelReference.Size = new System.Drawing.Size(594, 223);
            this.panelReference.TabIndex = 47;
            this.panelReference.Visible = false;
            // 
            // btnReference
            // 
            this.btnReference.Location = new System.Drawing.Point(3, 182);
            this.btnReference.Name = "btnReference";
            this.btnReference.Size = new System.Drawing.Size(252, 38);
            this.btnReference.TabIndex = 10;
            this.btnReference.Text = "Update Reference Details";
            this.btnReference.UseVisualStyleBackColor = true;
            this.btnReference.Click += new System.EventHandler(this.btnReference_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Serial Number";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(116, 154);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(383, 22);
            this.txtSerialNumber.TabIndex = 4;
            // 
            // txtYearReference
            // 
            this.txtYearReference.Location = new System.Drawing.Point(116, 97);
            this.txtYearReference.Name = "txtYearReference";
            this.txtYearReference.Size = new System.Drawing.Size(383, 22);
            this.txtYearReference.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Year Reference";
            // 
            // txtReference
            // 
            this.txtReference.Location = new System.Drawing.Point(116, 36);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(379, 22);
            this.txtReference.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Reference ";
            // 
            // panelPayMode
            // 
            this.panelPayMode.Controls.Add(this.btnPayMode);
            this.panelPayMode.Controls.Add(this.rdAPI);
            this.panelPayMode.Controls.Add(this.rdRTGS);
            this.panelPayMode.Controls.Add(this.rdCheque);
            this.panelPayMode.Location = new System.Drawing.Point(829, 608);
            this.panelPayMode.Name = "panelPayMode";
            this.panelPayMode.Size = new System.Drawing.Size(594, 64);
            this.panelPayMode.TabIndex = 48;
            // 
            // btnPayMode
            // 
            this.btnPayMode.Location = new System.Drawing.Point(448, 20);
            this.btnPayMode.Name = "btnPayMode";
            this.btnPayMode.Size = new System.Drawing.Size(143, 41);
            this.btnPayMode.TabIndex = 11;
            this.btnPayMode.Text = "Update Pay Mode";
            this.btnPayMode.UseVisualStyleBackColor = true;
            this.btnPayMode.Click += new System.EventHandler(this.btnPayMode_Click);
            // 
            // rdAPI
            // 
            this.rdAPI.AutoSize = true;
            this.rdAPI.Location = new System.Drawing.Point(290, 22);
            this.rdAPI.Name = "rdAPI";
            this.rdAPI.Size = new System.Drawing.Size(50, 21);
            this.rdAPI.TabIndex = 2;
            this.rdAPI.TabStop = true;
            this.rdAPI.Text = "API";
            this.rdAPI.UseVisualStyleBackColor = true;
            // 
            // rdRTGS
            // 
            this.rdRTGS.AutoSize = true;
            this.rdRTGS.Location = new System.Drawing.Point(144, 22);
            this.rdRTGS.Name = "rdRTGS";
            this.rdRTGS.Size = new System.Drawing.Size(68, 21);
            this.rdRTGS.TabIndex = 1;
            this.rdRTGS.TabStop = true;
            this.rdRTGS.Text = "RTGS";
            this.rdRTGS.UseVisualStyleBackColor = true;
            // 
            // rdCheque
            // 
            this.rdCheque.AutoSize = true;
            this.rdCheque.Location = new System.Drawing.Point(13, 22);
            this.rdCheque.Name = "rdCheque";
            this.rdCheque.Size = new System.Drawing.Size(78, 21);
            this.rdCheque.TabIndex = 0;
            this.rdCheque.TabStop = true;
            this.rdCheque.Text = "Cheque";
            this.rdCheque.UseVisualStyleBackColor = true;
            // 
            // ggProjects
            // 
            this.ggProjects.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.ggProjects.BackColor = System.Drawing.SystemColors.Window;
            this.ggProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggProjects.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggProjects.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black;
            this.ggProjects.Location = new System.Drawing.Point(0, 0);
            this.ggProjects.Name = "ggProjects";
            this.ggProjects.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggProjects.Size = new System.Drawing.Size(1592, 261);
            this.ggProjects.TabIndex = 5;
            this.ggProjects.Text = "gridGroupingControl1";
            this.ggProjects.UseRightToLeftCompatibleTextBox = true;
            this.ggProjects.VersionInfo = "9.403.0.62";
            this.ggProjects.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.ggProjects_TableControlCellClick);
            // 
            // PaymentBatchBanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1607, 684);
            this.Controls.Add(this.panelPayMode);
            this.Controls.Add(this.panelReference);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.panelAddress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Name = "PaymentBatchBanks";
            this.Text = "Payment Batch - Banks";
            this.Load += new System.EventHandler(this.PaymentBatchProjects_Load);
            this.panel1.ResumeLayout(false);
            this.panelAddress.ResumeLayout(false);
            this.panelAddress.PerformLayout();
            this.panelReference.ResumeLayout(false);
            this.panelReference.PerformLayout();
            this.panelPayMode.ResumeLayout(false);
            this.panelPayMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAddress;
        private System.Windows.Forms.Button btnUpdateBankAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtAddress3;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Panel panelReference;
        private System.Windows.Forms.Button btnReference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtYearReference;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelPayMode;
        private System.Windows.Forms.Button btnPayMode;
        private System.Windows.Forms.RadioButton rdAPI;
        private System.Windows.Forms.RadioButton rdRTGS;
        private System.Windows.Forms.RadioButton rdCheque;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggProjects;
    }
}