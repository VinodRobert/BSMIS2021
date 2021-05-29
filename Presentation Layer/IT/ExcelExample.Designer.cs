namespace BSMIS 
{
    partial class ExcelExample
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
            this._c1xl = new C1.C1Excel.C1XLBook();
            this.SuspendLayout();
            // 
            // _c1xl
            // 
            this._c1xl.CompatibilityMode = C1.C1Excel.CompatibilityMode.NoLimits;
            // 
            // ExcelExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 471);
            this.Name = "ExcelExample";
            this.Text = "ExcelExample";
            this.Load += new System.EventHandler(this.ExcelExample_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private C1.C1Excel.C1XLBook _c1xl;
    }
}