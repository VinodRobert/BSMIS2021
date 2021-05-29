namespace BSMIS 
{
    partial class frmBatch
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
            this.gridBatch = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBatch
            // 
            this.gridBatch.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridBatch.BackColor = System.Drawing.SystemColors.Window;
            this.gridBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBatch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBatch.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridBatch.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridBatch.Location = new System.Drawing.Point(0, 0);
            this.gridBatch.Name = "gridBatch";
            this.gridBatch.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridBatch.Size = new System.Drawing.Size(955, 347);
            this.gridBatch.TabIndex = 3;
            this.gridBatch.Text = "gridGroupingControl1";
            this.gridBatch.UseRightToLeftCompatibleTextBox = true;
            this.gridBatch.VersionInfo = "9.403.0.62";
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 347);
            this.Controls.Add(this.gridBatch);
            this.Name = "frmBatch";
            this.Text = "Batch Details";
            ((System.ComponentModel.ISupportInitialize)(this.gridBatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridBatch;
    }
}