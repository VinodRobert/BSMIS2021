namespace BSMIS 
{
    partial class frmDropDelivery
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
            Syncfusion.Windows.Forms.Grid.GridStyleInfo gridStyleInfo1 = new Syncfusion.Windows.Forms.Grid.GridStyleInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridNegative = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridPositive = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNDID = new System.Windows.Forms.Label();
            this.lblNDQ = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gridMatch = new Syncfusion.Windows.Forms.Grid.GridDataBoundGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPositiveMatch = new System.Windows.Forms.Label();
            this.btnDrop = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNegative)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPositive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(437, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drop Negative Delivery ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridNegative);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 214);
            this.panel1.TabIndex = 1;
            // 
            // gridNegative
            // 
            this.gridNegative.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridNegative.BackColor = System.Drawing.SystemColors.Window;
            this.gridNegative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridNegative.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridNegative.Location = new System.Drawing.Point(0, 0);
            this.gridNegative.Name = "gridNegative";
            this.gridNegative.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridNegative.Size = new System.Drawing.Size(1079, 214);
            this.gridNegative.TabIndex = 0;
            this.gridNegative.Text = "gridGroupingControl1";
            this.gridNegative.UseRightToLeftCompatibleTextBox = true;
            this.gridNegative.VersionInfo = "9.403.0.62";
            this.gridNegative.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridNegative_TableControlCellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Negative Delivery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(12, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Matching Positive Delivery";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridPositive);
            this.panel2.Location = new System.Drawing.Point(15, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 200);
            this.panel2.TabIndex = 4;
            // 
            // gridPositive
            // 
            this.gridPositive.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridPositive.BackColor = System.Drawing.SystemColors.Window;
            this.gridPositive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPositive.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridPositive.Location = new System.Drawing.Point(0, 0);
            this.gridPositive.Name = "gridPositive";
            this.gridPositive.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridPositive.Size = new System.Drawing.Size(1076, 200);
            this.gridPositive.TabIndex = 0;
            this.gridPositive.Text = "gridGroupingControl1";
            this.gridPositive.UseRightToLeftCompatibleTextBox = true;
            this.gridPositive.VersionInfo = "9.403.0.62";
            this.gridPositive.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.gridPositive_TableControlCellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Negative Delivery ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(15, 559);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Negative Delivery Qty:";
            // 
            // lblNDID
            // 
            this.lblNDID.AutoSize = true;
            this.lblNDID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNDID.Location = new System.Drawing.Point(249, 518);
            this.lblNDID.Name = "lblNDID";
            this.lblNDID.Size = new System.Drawing.Size(13, 16);
            this.lblNDID.TabIndex = 7;
            this.lblNDID.Text = ".";
            // 
            // lblNDQ
            // 
            this.lblNDQ.AutoSize = true;
            this.lblNDQ.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNDQ.Location = new System.Drawing.Point(249, 559);
            this.lblNDQ.Name = "lblNDQ";
            this.lblNDQ.Size = new System.Drawing.Size(13, 16);
            this.lblNDQ.TabIndex = 8;
            this.lblNDQ.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(470, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Positive Matching:";
            // 
            // gridMatch
            // 
            this.gridMatch.AllowDragSelectedCols = true;
            this.gridMatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridMatch.EnableAddNew = false;
            this.gridMatch.EnableRemove = false;
            this.gridMatch.Font = new System.Drawing.Font("Verdana", 9F);
            this.gridMatch.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridMatch.Location = new System.Drawing.Point(603, 519);
            this.gridMatch.Name = "gridMatch";
            this.gridMatch.OptimizeInsertRemoveCells = true;
            this.gridMatch.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridMatch.Size = new System.Drawing.Size(302, 110);
            this.gridMatch.SmartSizeBox = false;
            this.gridMatch.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick;
            this.gridMatch.TabIndex = 11;
            gridStyleInfo1.Font.Bold = false;
            gridStyleInfo1.Font.Facename = "Verdana";
            gridStyleInfo1.Font.Italic = false;
            gridStyleInfo1.Font.Size = 9F;
            gridStyleInfo1.Font.Strikeout = false;
            gridStyleInfo1.Font.Underline = false;
            this.gridMatch.TableStyle = gridStyleInfo1;
            this.gridMatch.Text = "gridDataBoundGrid1";
            this.gridMatch.UseListChangedEvent = true;
            this.gridMatch.UseRightToLeftCompatibleTextBox = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(15, 599);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total Positive Matching Qty:";
            // 
            // lblPositiveMatch
            // 
            this.lblPositiveMatch.AutoSize = true;
            this.lblPositiveMatch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositiveMatch.Location = new System.Drawing.Point(249, 596);
            this.lblPositiveMatch.Name = "lblPositiveMatch";
            this.lblPositiveMatch.Size = new System.Drawing.Size(13, 16);
            this.lblPositiveMatch.TabIndex = 13;
            this.lblPositiveMatch.Text = ".";
            // 
            // btnDrop
            // 
            this.btnDrop.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.ForeColor = System.Drawing.Color.Red;
            this.btnDrop.Location = new System.Drawing.Point(952, 559);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(121, 37);
            this.btnDrop.TabIndex = 14;
            this.btnDrop.Text = "Drop";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Visible = false;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(360, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(430, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "( Do it Carefully ! Irrecoverable . Do When Less Network Traffic) ";
            // 
            // frmDropDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 641);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.lblPositiveMatch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridMatch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNDQ);
            this.Controls.Add(this.lblNDID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmDropDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drop Negative Delivery";
            this.Load += new System.EventHandler(this.frmDropDelivery_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridNegative)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPositive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridNegative;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridPositive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNDID;
        private System.Windows.Forms.Label lblNDQ;
        private System.Windows.Forms.Label label6;
        private Syncfusion.Windows.Forms.Grid.GridDataBoundGrid gridMatch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPositiveMatch;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Label label8;
    }
}