namespace BSMIS 
{
    partial class frmVariationOrders
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
            this.lblVariationOrder = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.txtVO = new System.Windows.Forms.TextBox();
            this.btnWO = new System.Windows.Forms.Button();
            this.btnVO = new System.Windows.Forms.Button();
            this.lblSubbieName = new System.Windows.Forms.Label();
            this.lblSubbie = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridRegister = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lblLineNumber = new System.Windows.Forms.Label();
            this.txtLineNumber = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(155, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variation Order - Update Qty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter WO in Full ";
            // 
            // lblVariationOrder
            // 
            this.lblVariationOrder.AutoSize = true;
            this.lblVariationOrder.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVariationOrder.Location = new System.Drawing.Point(9, 128);
            this.lblVariationOrder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVariationOrder.Name = "lblVariationOrder";
            this.lblVariationOrder.Size = new System.Drawing.Size(179, 17);
            this.lblVariationOrder.TabIndex = 2;
            this.lblVariationOrder.Text = "Variation Order in Full";
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.Location = new System.Drawing.Point(192, 67);
            this.txtPO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(243, 23);
            this.txtPO.TabIndex = 3;
            // 
            // txtVO
            // 
            this.txtVO.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVO.Location = new System.Drawing.Point(192, 128);
            this.txtVO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVO.Name = "txtVO";
            this.txtVO.Size = new System.Drawing.Size(244, 23);
            this.txtVO.TabIndex = 4;
            // 
            // btnWO
            // 
            this.btnWO.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWO.Location = new System.Drawing.Point(453, 59);
            this.btnWO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnWO.Name = "btnWO";
            this.btnWO.Size = new System.Drawing.Size(88, 33);
            this.btnWO.TabIndex = 5;
            this.btnWO.Text = "Search";
            this.btnWO.UseVisualStyleBackColor = true;
            this.btnWO.Click += new System.EventHandler(this.btnWO_Click);
            // 
            // btnVO
            // 
            this.btnVO.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVO.Location = new System.Drawing.Point(453, 122);
            this.btnVO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVO.Name = "btnVO";
            this.btnVO.Size = new System.Drawing.Size(88, 28);
            this.btnVO.TabIndex = 6;
            this.btnVO.Text = "Fetch";
            this.btnVO.UseVisualStyleBackColor = true;
            // 
            // lblSubbieName
            // 
            this.lblSubbieName.AutoSize = true;
            this.lblSubbieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubbieName.ForeColor = System.Drawing.Color.Blue;
            this.lblSubbieName.Location = new System.Drawing.Point(9, 98);
            this.lblSubbieName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubbieName.Name = "lblSubbieName";
            this.lblSubbieName.Size = new System.Drawing.Size(117, 17);
            this.lblSubbieName.TabIndex = 7;
            this.lblSubbieName.Text = "Sub Contractor";
            // 
            // lblSubbie
            // 
            this.lblSubbie.AutoSize = true;
            this.lblSubbie.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubbie.Location = new System.Drawing.Point(189, 98);
            this.lblSubbie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubbie.Name = "lblSubbie";
            this.lblSubbie.Size = new System.Drawing.Size(15, 17);
            this.lblSubbie.TabIndex = 8;
            this.lblSubbie.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridRegister);
            this.panel1.Location = new System.Drawing.Point(12, 167);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 203);
            this.panel1.TabIndex = 9;
            // 
            // gridRegister
            // 
            this.gridRegister.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.gridRegister.BackColor = System.Drawing.SystemColors.Window;
            this.gridRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRegister.Location = new System.Drawing.Point(0, 0);
            this.gridRegister.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridRegister.Name = "gridRegister";
            this.gridRegister.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridRegister.Size = new System.Drawing.Size(496, 203);
            this.gridRegister.TabIndex = 2;
            this.gridRegister.Text = "gridGroupingControl1";
            this.gridRegister.UseRightToLeftCompatibleTextBox = true;
            this.gridRegister.VersionInfo = "9.403.0.62";
            this.gridRegister.WantTabKey = false;
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.AutoSize = true;
            this.lblLineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineNumber.Location = new System.Drawing.Point(9, 398);
            this.lblLineNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(114, 17);
            this.lblLineNumber.TabIndex = 10;
            this.lblLineNumber.Text = "Line Number ?";
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Location = new System.Drawing.Point(120, 396);
            this.txtLineNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(84, 20);
            this.txtLineNumber.TabIndex = 11;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(446, 393);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 24);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // frmVariationOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 422);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtLineNumber);
            this.Controls.Add(this.lblLineNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSubbie);
            this.Controls.Add(this.lblSubbieName);
            this.Controls.Add(this.btnVO);
            this.Controls.Add(this.btnWO);
            this.Controls.Add(this.txtVO);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.lblVariationOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmVariationOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variation Order";
            this.Load += new System.EventHandler(this.frmVariationOrders_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegister)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVariationOrder;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.TextBox txtVO;
        private System.Windows.Forms.Button btnWO;
        private System.Windows.Forms.Button btnVO;
        private System.Windows.Forms.Label lblSubbieName;
        private System.Windows.Forms.Label lblSubbie;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridRegister;
        private System.Windows.Forms.Label lblLineNumber;
        private System.Windows.Forms.TextBox txtLineNumber;
        private System.Windows.Forms.Button btnUpdate;
    }
}