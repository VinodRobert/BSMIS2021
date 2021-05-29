namespace BSMIS 
{
    partial class frmNewAsset
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtAssetNumber = new System.Windows.Forms.TextBox();
            this.txtAssetName = new System.Windows.Forms.TextBox();
            this.txtAssetLife = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.txtLifeDepreciated = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.btnFetch = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbLocation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPutToUse = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.txtPurchaseValue = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.txtSalvageValue = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.txtAccumulatedDepreciation = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.gridAsset = new Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAssetID = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtPODate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.txtSuppCode = new System.Windows.Forms.TextBox();
            this.dtInvoiceDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDutyBenefit = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFERevaluation = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.cmbGRN = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtInvoiceAmount = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.txtTaxAmount = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtAssetLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLifeDepreciated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPutToUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPutToUse.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalvageValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccumulatedDepreciation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPODate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPODate.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDutyBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFERevaluation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(518, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Asset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asset Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Asset Number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Asset Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(574, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Asset Purchase Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(582, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Asset Salvage Value";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(905, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Asset Life (Months)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(868, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 16);
            this.label10.TabIndex = 9;
            this.label10.Text = "Life Depreciated(Months)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(545, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Accumulated Depreciation";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Computers  and Printers            ",
            "Form Work Equipment                ",
            "Furniture and Fixtures             ",
            "Office Equipments                  ",
            "Office Premises                    ",
            "Plant  and Machinery                ",
            "Softwares                          ",
            "Vehicles                           "});
            this.cmbCategory.Location = new System.Drawing.Point(200, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(339, 22);
            this.cmbCategory.Sorted = true;
            this.cmbCategory.TabIndex = 5;
            // 
            // txtAssetNumber
            // 
            this.txtAssetNumber.Location = new System.Drawing.Point(200, 67);
            this.txtAssetNumber.Name = "txtAssetNumber";
            this.txtAssetNumber.Size = new System.Drawing.Size(240, 21);
            this.txtAssetNumber.TabIndex = 6;
            // 
            // txtAssetName
            // 
            this.txtAssetName.AllowDrop = true;
            this.txtAssetName.Location = new System.Drawing.Point(200, 94);
            this.txtAssetName.Multiline = true;
            this.txtAssetName.Name = "txtAssetName";
            this.txtAssetName.Size = new System.Drawing.Size(339, 31);
            this.txtAssetName.TabIndex = 7;
            // 
            // txtAssetLife
            // 
            this.txtAssetLife.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtAssetLife.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAssetLife.IntegerValue = ((long)(0));
            this.txtAssetLife.Location = new System.Drawing.Point(1058, 35);
            this.txtAssetLife.Name = "txtAssetLife";
            this.txtAssetLife.NullString = "";
            this.txtAssetLife.Size = new System.Drawing.Size(55, 21);
            this.txtAssetLife.TabIndex = 11;
            this.txtAssetLife.Text = "0";
            // 
            // txtLifeDepreciated
            // 
            this.txtLifeDepreciated.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtLifeDepreciated.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLifeDepreciated.IntegerValue = ((long)(0));
            this.txtLifeDepreciated.Location = new System.Drawing.Point(1058, 62);
            this.txtLifeDepreciated.Name = "txtLifeDepreciated";
            this.txtLifeDepreciated.NullString = "";
            this.txtLifeDepreciated.Size = new System.Drawing.Size(55, 21);
            this.txtLifeDepreciated.TabIndex = 12;
            this.txtLifeDepreciated.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(545, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "GRN";
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(12, 179);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(297, 21);
            this.txtPO.TabIndex = 14;
            // 
            // btnFetch
            // 
            this.btnFetch.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.WindowsXP;
            this.btnFetch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFetch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFetch.Location = new System.Drawing.Point(318, 179);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.PushButton = true;
            this.btnFetch.Size = new System.Drawing.Size(66, 25);
            this.btnFetch.TabIndex = 15;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyle = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // txtSupplier
            // 
            this.txtSupplier.Enabled = false;
            this.txtSupplier.ForeColor = System.Drawing.Color.Blue;
            this.txtSupplier.Location = new System.Drawing.Point(80, 250);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(369, 21);
            this.txtSupplier.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(661, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Location";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Blue;
            this.btnSave.Location = new System.Drawing.Point(990, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Blue;
            this.btnClear.Location = new System.Drawing.Point(1074, 228);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(1155, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(731, 126);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(358, 21);
            this.cmbLocation.TabIndex = 16;
            this.cmbLocation.Text = "comboBoxAdv1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(962, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Put To Use";
            // 
            // dtPutToUse
            // 
            this.dtPutToUse.BorderColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.dtPutToUse.Calendar.AllowMultipleSelection = false;
            this.dtPutToUse.Calendar.Culture = new System.Globalization.CultureInfo("en-IN");
            this.dtPutToUse.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.dtPutToUse.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPutToUse.Calendar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPutToUse.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPutToUse.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtPutToUse.Calendar.Name = "monthCalendar";
            this.dtPutToUse.Calendar.ScrollButtonSize = new System.Drawing.Size(20, 19);
            this.dtPutToUse.Calendar.SelectedDates = new System.DateTime[0];
            this.dtPutToUse.Calendar.Size = new System.Drawing.Size(146, 174);
            this.dtPutToUse.Calendar.SizeToFit = true;
            this.dtPutToUse.Calendar.TabIndex = 0;
            this.dtPutToUse.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtPutToUse.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtPutToUse.Calendar.NoneButton.Location = new System.Drawing.Point(62, 0);
            this.dtPutToUse.Calendar.NoneButton.Size = new System.Drawing.Size(84, 20);
            this.dtPutToUse.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            this.dtPutToUse.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtPutToUse.Calendar.TodayButton.Size = new System.Drawing.Size(62, 20);
            this.dtPutToUse.Calendar.TodayButton.Text = "Today";
            this.dtPutToUse.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPutToUse.DropDownImage = null;
            this.dtPutToUse.Location = new System.Drawing.Point(1058, 99);
            this.dtPutToUse.MinValue = new System.DateTime(((long)(0)));
            this.dtPutToUse.Name = "dtPutToUse";
            this.dtPutToUse.ShowCheckBox = false;
            this.dtPutToUse.Size = new System.Drawing.Size(184, 20);
            this.dtPutToUse.TabIndex = 13;
            this.dtPutToUse.Value = new System.DateTime(2017, 3, 7, 11, 42, 20, 466);
            // 
            // txtPurchaseValue
            // 
            this.txtPurchaseValue.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtPurchaseValue.CurrencySymbol = "Rs";
            this.txtPurchaseValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPurchaseValue.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtPurchaseValue.Location = new System.Drawing.Point(731, 35);
            this.txtPurchaseValue.Name = "txtPurchaseValue";
            this.txtPurchaseValue.NullString = "";
            this.txtPurchaseValue.Size = new System.Drawing.Size(133, 21);
            this.txtPurchaseValue.TabIndex = 8;
            this.txtPurchaseValue.Text = "Rs 0.00";
            // 
            // txtSalvageValue
            // 
            this.txtSalvageValue.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtSalvageValue.CurrencySymbol = "Rs";
            this.txtSalvageValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSalvageValue.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSalvageValue.Location = new System.Drawing.Point(731, 67);
            this.txtSalvageValue.Name = "txtSalvageValue";
            this.txtSalvageValue.NullString = "";
            this.txtSalvageValue.Size = new System.Drawing.Size(133, 21);
            this.txtSalvageValue.TabIndex = 9;
            this.txtSalvageValue.Text = "Rs 0.00";
            // 
            // txtAccumulatedDepreciation
            // 
            this.txtAccumulatedDepreciation.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtAccumulatedDepreciation.CurrencySymbol = "Rs";
            this.txtAccumulatedDepreciation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccumulatedDepreciation.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtAccumulatedDepreciation.Location = new System.Drawing.Point(731, 99);
            this.txtAccumulatedDepreciation.Name = "txtAccumulatedDepreciation";
            this.txtAccumulatedDepreciation.NullString = "";
            this.txtAccumulatedDepreciation.Size = new System.Drawing.Size(133, 21);
            this.txtAccumulatedDepreciation.TabIndex = 10;
            this.txtAccumulatedDepreciation.Text = "Rs 0.00";
            // 
            // gridAsset
            // 
            this.gridAsset.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridAsset.BackColor = System.Drawing.SystemColors.Window;
            this.gridAsset.GridLineColor = System.Drawing.SystemColors.GrayText;
            this.gridAsset.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue;
            this.gridAsset.Location = new System.Drawing.Point(12, 288);
            this.gridAsset.Name = "gridAsset";
            this.gridAsset.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.gridAsset.ShowGroupDropArea = true;
            this.gridAsset.ShowNavigationBar = true;
            this.gridAsset.Size = new System.Drawing.Size(1230, 274);
            this.gridAsset.TabIndex = 42;
            this.gridAsset.Text = "gridGroupingControl1";
            this.gridAsset.UseRightToLeftCompatibleTextBox = true;
            this.gridAsset.VersionInfo = "9.403.0.62";
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.Location = new System.Drawing.Point(12, 158);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(322, 16);
            this.lblOrderType.TabIndex = 43;
            this.lblOrderType.Text = "Enter Purchase Order Number in FULL (CIPL/...)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
            this.label12.TabIndex = 44;
            this.label12.Text = "Supplier";
            // 
            // lblAssetID
            // 
            this.lblAssetID.AutoSize = true;
            this.lblAssetID.Location = new System.Drawing.Point(1169, 134);
            this.lblAssetID.Name = "lblAssetID";
            this.lblAssetID.Size = new System.Drawing.Size(48, 13);
            this.lblAssetID.TabIndex = 45;
            this.lblAssetID.Text = "label13";
            this.lblAssetID.Visible = false;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Enabled = false;
            this.txtInvoice.ForeColor = System.Drawing.Color.Red;
            this.txtInvoice.Location = new System.Drawing.Point(661, 199);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.Size = new System.Drawing.Size(126, 21);
            this.txtInvoice.TabIndex = 47;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 217);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 16);
            this.label15.TabIndex = 48;
            this.label15.Text = "PO Date";
            // 
            // dtPODate
            // 
            this.dtPODate.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtPODate.BorderColor = System.Drawing.Color.Empty;
            this.dtPODate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtPODate.Calendar.AllowMultipleSelection = false;
            this.dtPODate.Calendar.Culture = new System.Globalization.CultureInfo("en-IN");
            this.dtPODate.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.dtPODate.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPODate.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPODate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtPODate.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtPODate.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtPODate.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtPODate.Calendar.HeaderHeight = 20;
            this.dtPODate.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtPODate.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtPODate.Calendar.HeadGradient = true;
            this.dtPODate.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtPODate.Calendar.Name = "monthCalendar";
            this.dtPODate.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.dtPODate.Calendar.SelectedDates = new System.DateTime[0];
            this.dtPODate.Calendar.Size = new System.Drawing.Size(146, 174);
            this.dtPODate.Calendar.SizeToFit = true;
            this.dtPODate.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtPODate.Calendar.TabIndex = 0;
            this.dtPODate.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtPODate.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtPODate.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtPODate.Calendar.NoneButton.Location = new System.Drawing.Point(62, 0);
            this.dtPODate.Calendar.NoneButton.Size = new System.Drawing.Size(84, 20);
            this.dtPODate.Calendar.NoneButton.Text = "None";
            this.dtPODate.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtPODate.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtPODate.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtPODate.Calendar.TodayButton.Size = new System.Drawing.Size(62, 20);
            this.dtPODate.Calendar.TodayButton.Text = "Today";
            this.dtPODate.Calendar.TodayButton.UseVisualStyle = true;
            this.dtPODate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPODate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtPODate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtPODate.DropDownImage = null;
            this.dtPODate.Enabled = false;
            this.dtPODate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dtPODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPODate.Location = new System.Drawing.Point(80, 217);
            this.dtPODate.MinValue = new System.DateTime(((long)(0)));
            this.dtPODate.Name = "dtPODate";
            this.dtPODate.ShowCheckBox = false;
            this.dtPODate.Size = new System.Drawing.Size(143, 20);
            this.dtPODate.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtPODate.TabIndex = 49;
            this.dtPODate.Value = new System.DateTime(2017, 3, 7, 11, 42, 20, 466);
            // 
            // txtSuppCode
            // 
            this.txtSuppCode.Enabled = false;
            this.txtSuppCode.ForeColor = System.Drawing.Color.Blue;
            this.txtSuppCode.Location = new System.Drawing.Point(455, 250);
            this.txtSuppCode.Name = "txtSuppCode";
            this.txtSuppCode.Size = new System.Drawing.Size(104, 21);
            this.txtSuppCode.TabIndex = 50;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.BorderColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.dtInvoiceDate.Calendar.AllowMultipleSelection = false;
            this.dtInvoiceDate.Calendar.Culture = new System.Globalization.CultureInfo("en-IN");
            this.dtInvoiceDate.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.dtInvoiceDate.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtInvoiceDate.Calendar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtInvoiceDate.Calendar.Name = "monthCalendar";
            this.dtInvoiceDate.Calendar.ScrollButtonSize = new System.Drawing.Size(20, 19);
            this.dtInvoiceDate.Calendar.SelectedDates = new System.DateTime[0];
            this.dtInvoiceDate.Calendar.Size = new System.Drawing.Size(138, 174);
            this.dtInvoiceDate.Calendar.SizeToFit = true;
            this.dtInvoiceDate.Calendar.TabIndex = 0;
            this.dtInvoiceDate.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtInvoiceDate.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtInvoiceDate.Calendar.NoneButton.Location = new System.Drawing.Point(54, 0);
            this.dtInvoiceDate.Calendar.NoneButton.Size = new System.Drawing.Size(84, 20);
            this.dtInvoiceDate.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            this.dtInvoiceDate.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtInvoiceDate.Calendar.TodayButton.Size = new System.Drawing.Size(54, 20);
            this.dtInvoiceDate.Calendar.TodayButton.Text = "Today";
            this.dtInvoiceDate.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInvoiceDate.DropDownImage = null;
            this.dtInvoiceDate.Enabled = false;
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceDate.Location = new System.Drawing.Point(793, 200);
            this.dtInvoiceDate.MinValue = new System.DateTime(((long)(0)));
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.ShowCheckBox = false;
            this.dtInvoiceDate.Size = new System.Drawing.Size(119, 20);
            this.dtInvoiceDate.TabIndex = 52;
            this.dtInvoiceDate.Value = new System.DateTime(2017, 3, 7, 11, 42, 20, 466);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(413, 184);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(67, 13);
            this.lblOrderID.TabIndex = 53;
            this.lblOrderID.Text = "lblOrderID";
            this.lblOrderID.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(697, 233);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 16);
            this.label16.TabIndex = 54;
            this.label16.Text = "Duty Benefit";
            // 
            // txtDutyBenefit
            // 
            this.txtDutyBenefit.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtDutyBenefit.CurrencySymbol = "Rs";
            this.txtDutyBenefit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDutyBenefit.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtDutyBenefit.Location = new System.Drawing.Point(793, 228);
            this.txtDutyBenefit.Name = "txtDutyBenefit";
            this.txtDutyBenefit.NullString = "";
            this.txtDutyBenefit.Size = new System.Drawing.Size(133, 21);
            this.txtDutyBenefit.TabIndex = 55;
            this.txtDutyBenefit.Text = "Rs 0.00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(656, 259);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 16);
            this.label18.TabIndex = 56;
            this.label18.Text = "FE Revaluation Adj";
            // 
            // txtFERevaluation
            // 
            this.txtFERevaluation.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtFERevaluation.CurrencySymbol = "Rs";
            this.txtFERevaluation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFERevaluation.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtFERevaluation.Location = new System.Drawing.Point(793, 259);
            this.txtFERevaluation.Name = "txtFERevaluation";
            this.txtFERevaluation.NullString = "";
            this.txtFERevaluation.Size = new System.Drawing.Size(133, 21);
            this.txtFERevaluation.TabIndex = 57;
            this.txtFERevaluation.Text = "Rs 0.00";
            // 
            // cmbGRN
            // 
            this.cmbGRN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGRN.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGRN.Location = new System.Drawing.Point(661, 154);
            this.cmbGRN.Name = "cmbGRN";
            this.cmbGRN.Size = new System.Drawing.Size(179, 22);
            this.cmbGRN.TabIndex = 58;
            this.cmbGRN.SelectionChangeCommitted += new System.EventHandler(this.cmbGRN_SelectionChangeCommitted);
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtInvoiceAmount.CurrencySymbol = "Rs";
            this.txtInvoiceAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInvoiceAmount.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtInvoiceAmount.ForeColor = System.Drawing.Color.Blue;
            this.txtInvoiceAmount.Location = new System.Drawing.Point(918, 200);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.NullString = "";
            this.txtInvoiceAmount.PositiveColor = System.Drawing.Color.Blue;
            this.txtInvoiceAmount.ReadOnly = true;
            this.txtInvoiceAmount.Size = new System.Drawing.Size(133, 21);
            this.txtInvoiceAmount.TabIndex = 59;
            this.txtInvoiceAmount.Text = "Rs 0.00";
            // 
            // txtTaxAmount
            // 
            this.txtTaxAmount.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtTaxAmount.CurrencySymbol = "Rs";
            this.txtTaxAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaxAmount.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTaxAmount.ForeColor = System.Drawing.Color.Magenta;
            this.txtTaxAmount.Location = new System.Drawing.Point(1057, 200);
            this.txtTaxAmount.Name = "txtTaxAmount";
            this.txtTaxAmount.NullString = "";
            this.txtTaxAmount.PositiveColor = System.Drawing.Color.Magenta;
            this.txtTaxAmount.Size = new System.Drawing.Size(133, 21);
            this.txtTaxAmount.TabIndex = 60;
            this.txtTaxAmount.Text = "Rs 0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(661, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 61;
            this.label13.Text = "Invoice #";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(790, 180);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 62;
            this.label19.Text = "Invoice Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(915, 180);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 13);
            this.label20.TabIndex = 63;
            this.label20.Text = "Invoice Amount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(1054, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 64;
            this.label21.Text = "Tax Amount";
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "Purchase Order",
            "Work Order"});
            this.cmbOrderType.Location = new System.Drawing.Point(12, 134);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(121, 22);
            this.cmbOrderType.TabIndex = 65;
            this.cmbOrderType.SelectionChangeCommitted += new System.EventHandler(this.cmbOrderType_SelectionChangeCommitted);
            // 
            // frmNewAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 563);
            this.Controls.Add(this.cmbOrderType);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTaxAmount);
            this.Controls.Add(this.txtInvoiceAmount);
            this.Controls.Add(this.cmbGRN);
            this.Controls.Add(this.txtFERevaluation);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDutyBenefit);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.txtSuppCode);
            this.Controls.Add(this.dtPODate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.lblAssetID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblOrderType);
            this.Controls.Add(this.gridAsset);
            this.Controls.Add(this.txtAccumulatedDepreciation);
            this.Controls.Add(this.txtSalvageValue);
            this.Controls.Add(this.txtPurchaseValue);
            this.Controls.Add(this.dtPutToUse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtLifeDepreciated);
            this.Controls.Add(this.txtAssetLife);
            this.Controls.Add(this.txtAssetName);
            this.Controls.Add(this.txtAssetNumber);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(30, 50);
            this.Name = "frmNewAsset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New Asset";
            this.Load += new System.EventHandler(this.frmNewAsset_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAssetLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLifeDepreciated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPutToUse.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPutToUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalvageValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccumulatedDepreciation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAsset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPODate.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPODate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDutyBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFERevaluation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGRN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtAssetNumber;
        private System.Windows.Forms.TextBox txtAssetName;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtAssetLife;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtLifeDepreciated;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPO;
        private Syncfusion.Windows.Forms.ButtonAdv btnFetch;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbLocation;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtPurchaseValue;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtSalvageValue;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtAccumulatedDepreciation;
        private Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl gridAsset;
        private System.Windows.Forms.Label lblOrderType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAssetID;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Label label15;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtPODate;
        private System.Windows.Forms.TextBox txtSuppCode;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtInvoiceDate;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv dtPutToUse;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label label16;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtDutyBenefit;
        private System.Windows.Forms.Label label18;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtFERevaluation;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbGRN;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtInvoiceAmount;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtTaxAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbOrderType;
    }
}