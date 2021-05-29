namespace BSMIS 
{
    partial class frmDefineRevenueExpenseHeads
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefineRevenueExpenseHeads));
            this.label1 = new System.Windows.Forms.Label();
            this.flexRevenueExpense = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.lblCostLedger = new System.Windows.Forms.Label();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.cmbCategory = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtPosition = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flexRevenueExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Revenue / Expense Heads - Definition";
            // 
            // flexRevenueExpense
            // 
            this.flexRevenueExpense.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.flexRevenueExpense.AllowEditing = false;
            this.flexRevenueExpense.ColumnInfo = "10,1,0,0,0,100,Columns:0{AllowSorting:False;AllowDragging:False;AllowResizing:Fal" +
    "se;AllowEditing:False;}\t";
            this.flexRevenueExpense.Location = new System.Drawing.Point(12, 144);
            this.flexRevenueExpense.Name = "flexRevenueExpense";
            this.flexRevenueExpense.Rows.DefaultSize = 20;
            this.flexRevenueExpense.Size = new System.Drawing.Size(425, 348);
            this.flexRevenueExpense.StyleInfo = resources.GetString("flexRevenueExpense.StyleInfo");
            this.flexRevenueExpense.TabIndex = 15;
            this.flexRevenueExpense.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue;
            // 
            // lblCostLedger
            // 
            this.lblCostLedger.AutoSize = true;
            this.lblCostLedger.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostLedger.ForeColor = System.Drawing.Color.Blue;
            this.lblCostLedger.Location = new System.Drawing.Point(13, 39);
            this.lblCostLedger.Name = "lblCostLedger";
            this.lblCostLedger.Size = new System.Drawing.Size(45, 14);
            this.lblCostLedger.TabIndex = 16;
            this.lblCostLedger.Text = "Name";
            // 
            // txtHead
            // 
            this.txtHead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHead.Location = new System.Drawing.Point(136, 38);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(301, 21);
            this.txtHead.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(388, 63);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 25);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Location = new System.Drawing.Point(332, 63);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(57, 25);
            this.btnAddUpdate.TabIndex = 26;
            this.btnAddUpdate.Text = "New";
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cmbCategory.Items.AddRange(new object[] {
            "Expense",
            "Revenue"});
            this.cmbCategory.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbCategory, "Expense"));
            this.cmbCategory.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cmbCategory, "Revenue"));
            this.cmbCategory.Location = new System.Drawing.Point(136, 65);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(118, 21);
            this.cmbCategory.Sorted = true;
            this.cmbCategory.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cmbCategory.TabIndex = 24;
            this.cmbCategory.Text = " ";
            // 
            // txtPosition
            // 
            this.txtPosition.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtPosition.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPosition.IntegerValue = ((long)(1));
            this.txtPosition.Location = new System.Drawing.Point(136, 102);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.NullString = "";
            this.txtPosition.Size = new System.Drawing.Size(100, 21);
            this.txtPosition.TabIndex = 27;
            this.txtPosition.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(13, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Order";
            // 
            // frmDefineRevenueExpenseHeads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 504);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.btnAddUpdate);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtHead);
            this.Controls.Add(this.lblCostLedger);
            this.Controls.Add(this.flexRevenueExpense);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDefineRevenueExpenseHeads";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            ((System.ComponentModel.ISupportInitialize)(this.flexRevenueExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid flexRevenueExpense;
        private System.Windows.Forms.Label lblCostLedger;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddUpdate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbCategory;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}