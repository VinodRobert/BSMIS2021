namespace BSMIS 
{
    partial class frmCreditors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreditors));
            this.tbGrid0 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.tbGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrid0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbGrid0
            // 
            this.tbGrid0.GroupByCaption = "Drag a column header here to group by that column";
            this.tbGrid0.Images.Add(((System.Drawing.Image)(resources.GetObject("tbGrid0.Images"))));
            this.tbGrid0.Location = new System.Drawing.Point(77, 24);
            this.tbGrid0.Name = "tbGrid0";
            this.tbGrid0.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tbGrid0.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tbGrid0.PreviewInfo.ZoomFactor = 75D;
            this.tbGrid0.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.tbGrid0.Size = new System.Drawing.Size(439, 150);
            this.tbGrid0.TabIndex = 0;
            this.tbGrid0.Text = "c1TrueDBGrid1";
            this.tbGrid0.PropBag = resources.GetString("tbGrid0.PropBag");
            // 
            // tbGrid1
            // 
            this.tbGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.tbGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("tbGrid1.Images"))));
            this.tbGrid1.Location = new System.Drawing.Point(111, 93);
            this.tbGrid1.Name = "tbGrid1";
            this.tbGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.tbGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.tbGrid1.PreviewInfo.ZoomFactor = 75D;
            this.tbGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid2.PrintInfo.PageSettings")));
            this.tbGrid1.Size = new System.Drawing.Size(666, 150);
            this.tbGrid1.TabIndex = 1;
            this.tbGrid1.Text = "c1TrueDBGrid2";
            this.tbGrid1.PropBag = resources.GetString("tbGrid1.PropBag");
            // 
            // frmCreditors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 489);
            this.Controls.Add(this.tbGrid1);
            this.Controls.Add(this.tbGrid0);
            this.Name = "frmCreditors";
            this.Text = "frmCreditors";
            this.Load += new System.EventHandler(this.frmCreditors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbGrid0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tbGrid0;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid tbGrid1;

    }
}