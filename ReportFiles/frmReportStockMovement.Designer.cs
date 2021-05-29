namespace BSMIS 
{
    partial class frmReportStockMovement
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
            this.cvLedgers = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Ledgers1 = new ReportFiles.Ledgers();
            this.SuspendLayout();
            // 
            // cvLedgers
            // 
            this.cvLedgers.ActiveViewIndex = 0;
            this.cvLedgers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cvLedgers.Cursor = System.Windows.Forms.Cursors.Default;
            this.cvLedgers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvLedgers.Location = new System.Drawing.Point(0, 0);
            this.cvLedgers.Name = "cvLedgers";
            this.cvLedgers.ReportSource = this.Ledgers1;
            this.cvLedgers.Size = new System.Drawing.Size(839, 262);
            this.cvLedgers.TabIndex = 0;
            // 
            // frmReportPreviewLedgers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 262);
            this.Controls.Add(this.cvLedgers);
            this.Name = "frmReportPreviewLedgers";
            this.Text = "frmReportPreviewLedgers";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cvLedgers;
        private ReportFiles.Ledgers  Ledgers1;
    }
}