namespace BSMIS
{
    partial class CashFlowHeaders
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
            this.ggCashFlowHeaders = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ggCashFlowHeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Red;
            this.lblHeader.Location = new System.Drawing.Point(288, 9);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(235, 25);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Cash Flow Headers";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ggCashFlowHeaders);
            this.panel1.Location = new System.Drawing.Point(13, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 419);
            this.panel1.TabIndex = 2;
            // 
            // ggCashFlowHeaders
            // 
            this.ggCashFlowHeaders.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ggCashFlowHeaders.BackColor = System.Drawing.SystemColors.Window;
            this.ggCashFlowHeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ggCashFlowHeaders.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ggCashFlowHeaders.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.ggCashFlowHeaders.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.ggCashFlowHeaders.Location = new System.Drawing.Point(0, 0);
            this.ggCashFlowHeaders.Name = "ggCashFlowHeaders";
            this.ggCashFlowHeaders.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.ggCashFlowHeaders.Size = new System.Drawing.Size(805, 419);
            this.ggCashFlowHeaders.TabIndex = 1;
            this.ggCashFlowHeaders.Text = "gridGroupingControl1";
            this.ggCashFlowHeaders.UseRightToLeftCompatibleTextBox = true;
            this.ggCashFlowHeaders.VersionInfo = "9.403.0.62";
            // 
            // CashFlowHeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHeader);
            this.Name = "CashFlowHeaders";
            this.Text = "CashFlowHeaders";
            this.Load += new System.EventHandler(this.CashFlowHeaders_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ggCashFlowHeaders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel lblHeader;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl ggCashFlowHeaders;
    }
}