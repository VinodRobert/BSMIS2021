namespace BSMIS 
{
    partial class frmLoginUser
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.gridLoginUsers = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoginUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.ForeColor = System.Drawing.Color.Red;
            this.autoLabel1.Location = new System.Drawing.Point(371, 9);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(193, 23);
            this.autoLabel1.TabIndex = 1;
            this.autoLabel1.Text = "Buildsmart Users";
            // 
            // gridLoginUsers
            // 
            this.gridLoginUsers.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridLoginUsers.BackColor = System.Drawing.SystemColors.Window;
            this.gridLoginUsers.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridLoginUsers.Location = new System.Drawing.Point(13, 42);
            this.gridLoginUsers.Name = "gridLoginUsers";
            this.gridLoginUsers.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridLoginUsers.Size = new System.Drawing.Size(944, 462);
            this.gridLoginUsers.TabIndex = 2;
            this.gridLoginUsers.Text = "gridGroupingControl1";
            this.gridLoginUsers.UseRightToLeftCompatibleTextBox = true;
            this.gridLoginUsers.VersionInfo = "9.403.0.62";
            // 
            // frmLoginUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 516);
            this.Controls.Add(this.gridLoginUsers);
            this.Controls.Add(this.autoLabel1);
            this.Name = "frmLoginUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buildsmart Users";
            this.Load += new System.EventHandler(this.frmLoginUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoginUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridLoginUsers;
    }
}