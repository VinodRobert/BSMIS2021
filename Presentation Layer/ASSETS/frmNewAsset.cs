using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSMIS 
{
    public partial class frmNewAsset : Form
    {
        Assets _as = new Assets();
        DataSet _ds;
        DataSet _dsAsset = new DataSet();
        DataTable _dt = new DataTable();
        DataTable _GRNTable = new DataTable();
        DataTable _InvoiceTable = new DataTable();

        int _orderType;
        public frmNewAsset()
        {
            InitializeComponent();
        }

         

        private void LoadGrid()
        {
           

            _dsAsset = _as.GetAssets(1);
            _dt = _dsAsset.Tables[0];
        

            gridAsset.DataSource = _dt;

            gridAsset.TableDescriptor.AllowEdit = false;
            gridAsset.TableDescriptor.AllowNew = false;
            gridAsset.TableDescriptor.AllowRemove = false;

            gridAsset.TableDescriptor.Columns[0].HeaderText = "ASSET CATEGORY";
            gridAsset.TableDescriptor.Columns[0].Width =200;

            gridAsset.TableDescriptor.Columns[1].HeaderText = "PROJECTID";
            gridAsset.TableDescriptor.Columns[1].Width = 0;

            gridAsset.TableDescriptor.Columns[2].HeaderText = "Location";
            gridAsset.TableDescriptor.Columns[2].Width = 200;
            gridAsset.TableDescriptor.Columns[2].AllowFilter = true;

            gridAsset.TableDescriptor.Columns[3].HeaderText = "ASSET NUMBER";
            gridAsset.TableDescriptor.Columns[3].Width = 100;

            gridAsset.TableDescriptor.Columns[4].HeaderText = "ASSET NAME";
            gridAsset.TableDescriptor.Columns[4].Width = 250;
            gridAsset.TableDescriptor.Columns[4].AllowFilter = true;


            gridAsset.TableDescriptor.Columns[5].HeaderText = "PUT TO USE";
            gridAsset.TableDescriptor.Columns[5].Width = 66;
            gridAsset.TableDescriptor.Columns[5].AllowGroupByColumn = false;
            gridAsset.TableDescriptor.Columns[5].Appearance.AnyCell.CellType = "Date";

            gridAsset.TableDescriptor.Columns[6].HeaderText = "Purchase Value";
            gridAsset.TableDescriptor.Columns[6].Width = 100;
            gridAsset.TableDescriptor.Columns[6].AllowGroupByColumn = false;

                   
            gridAsset.TableDescriptor.Columns[7].Width = 0;
            gridAsset.TableDescriptor.Columns[8].Width = 0;

            gridAsset.TableDescriptor.Columns[9].HeaderText = "Book Value";
            gridAsset.TableDescriptor.Columns[9].Width = 100;
            gridAsset.TableDescriptor.Columns[9].AllowGroupByColumn = false;

            gridAsset.TableDescriptor.Columns[10].Width = 0;

            gridAsset.TableDescriptor.Columns[11].HeaderText = "Remaining Life";
            gridAsset.TableDescriptor.Columns[11].Width = 90;
            gridAsset.TableDescriptor.Columns[11].AllowGroupByColumn = false;


            gridAsset.TableDescriptor.Columns[12].HeaderText = "ASSETID";
            gridAsset.TableDescriptor.Columns[12].Width = 100;

          
               
        }

        private void Setups()
        {

            this.gridAsset.ShowGroupDropArea = true;
            this.gridAsset.TableOptions.AllowSortColumns = true;
            this.gridAsset.TopLevelGroupOptions.ShowCaption = true;
            this.gridAsset.TableOptions.RecordPreviewRowHeight = 55;
            this.gridAsset.TableOptions.ShowRowHeader = false;
            this.gridAsset.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridAsset.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridAsset.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridAsset.TableOptions.DefaultColumnWidth = 65;
            this.gridAsset.TableOptions.CaptionRowHeight = 22;
            this.gridAsset.InvalidateAllWhenListChanged = true;
            this.gridAsset.ForceDisposeOnResetDataSource = true;
            this.gridAsset.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridAsset.CacheRecordValues = false;
            this.gridAsset.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridAsset.Font = new Font("Calibri", 8.0f);
            this.gridAsset.TopLevelGroupOptions.ShowFilterBar = true;
            dtPutToUse.Value = DateTime.Now;
            lblOrderID.Text = "0";
            cmbGRN.Enabled = false;
            this.dtInvoiceDate.ReadOnly = true;
            this.dtInvoiceDate.ReadOnly = true;
            dtInvoiceDate.CustomFormat = "dd-MM-yyyy";
            dtPODate.CustomFormat = "dd-MM-yyyy";
            cmbOrderType.SelectedIndex = 0;
        }
        private void LoadLocations()
        {
            _ds = new DataSet();
            _ds = _as.GetProjectLocations();
            UtilityFunctions.LoadWindowsCombo(cmbLocation, _ds.Tables[0], "BORGNAME", "PROJECTCODE", 0);
        }
        private void frmNewAsset_Load(object sender, EventArgs e)
        {
            Setups();
            LoadLocations();
            LoadGrid();
            cmbCategory.SelectedIndex = 0;
        }

        private int ValidateEntry()
        {
            if (Convert.ToInt16(txtAssetLife.Text) <= 0 ) 
               return 0;
            if (Convert.ToString(txtAssetName.Text)=="" )
               return 0;
            if (Convert.ToString(txtAssetNumber.Text)=="")
               return 0;
            if (Convert.ToDecimal(txtPurchaseValue.DecimalValue)  == 0) 
               return 0;
            if (Convert.ToInt16(txtLifeDepreciated.Text) >= Convert.ToInt16(txtAssetLife.Text))
                return 0;
            if (Convert.ToString(txtInvoice.Text.Trim()) == "")
                return 0;

            if (Convert.ToDecimal(txtPurchaseValue.DecimalValue) > 0)
            {
                if (Convert.ToDecimal(txtSalvageValue.DecimalValue) <= 0)
                    return 0;
                if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) >= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                    return 0;
                if (Convert.ToDecimal(txtSalvageValue.DecimalValue) >= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                    return 0;
                if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) >= Convert.ToDecimal(txtSalvageValue.DecimalValue))
                    return 0;
            }

            if (Convert.ToDecimal(txtPurchaseValue.DecimalValue) < 0)
            {
                if (Convert.ToDecimal(txtSalvageValue.DecimalValue) >= 0)
                    return 0;
                if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) <= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                    return 0;
                if (Convert.ToDecimal(txtSalvageValue.DecimalValue) <= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                    return 0;
                if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) <= Convert.ToDecimal(txtSalvageValue.DecimalValue))
                    return 0;
            }

            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ValidateEntry() == 1)
            {
                Assets _newAsset = new Assets();
                _newAsset.AssetID = 0;
                _newAsset.AccumulatedDepreciation = Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue);
                _newAsset.LifeDepreciated = Convert.ToInt16(txtLifeDepreciated.Text);
                _newAsset.AssetCategory = Convert.ToString(cmbCategory.Text);
                _newAsset.AssetLife = Convert.ToInt16(txtAssetLife.Text);
                _newAsset.AssetLocation = Convert.ToString(cmbLocation.SelectedValue);
                _newAsset.AssetName = Convert.ToString(txtAssetName.Text);
                _newAsset.AssetNumber = Convert.ToString(txtAssetNumber.Text);
                _newAsset.AssetPurchaseValue = Convert.ToDecimal(txtPurchaseValue.DecimalValue);
                _newAsset.AssetPutToUse = Convert.ToDateTime(dtPutToUse.Value.Date);
                _newAsset.AssetSalvageValue = Convert.ToDecimal(txtSalvageValue.DecimalValue);
                _newAsset.AssetOrderID = Convert.ToInt64(lblOrderID.Text);
                _newAsset.AssetInvoiceNo = Convert.ToString(txtInvoice.Text);
                _newAsset.GRN = Convert.ToString(cmbGRN.Text);
                _newAsset.DutyBenefit = Convert.ToDecimal(txtDutyBenefit.DecimalValue);
                _newAsset.FERevaluation = Convert.ToDecimal(txtFERevaluation.DecimalValue);
                _newAsset.PONumber = Convert.ToString(txtPO.Text.Trim());
                _newAsset.PODate = Convert.ToDateTime(dtPODate.Value.Date.ToString("dd/MM/yyyy"));
                _newAsset.SupplierCode = Convert.ToString(txtSuppCode.Text.Trim());
                _newAsset.SupplierName = Convert.ToString(txtSupplier.Text.Trim());
                _newAsset.InvoiceAmount = Convert.ToDecimal(txtInvoiceAmount.DecimalValue);
                _newAsset.InvoiceDate = Convert.ToDateTime(dtInvoiceDate.Value.Date.ToString("dd/MM/yyyy"));
                _newAsset.OrderType = Convert.ToInt16(cmbOrderType.SelectedIndex);
                _newAsset.TaxAmount = Convert.ToDecimal(txtTaxAmount.DecimalValue);
                

                if (_newAsset.CheckDuplicate() == 0)
                {
                    _newAsset.update();
                    MessageBox.Show("Success ..........");
                    LoadGrid();
                    ClearAll();
                }
                else
                    MessageBox.Show("Duplicate Asset Code ");
            }
            else
            {
                MessageBox.Show("Check Your Entries");
            }
        }

        private void gridAsset_SelectedRecordsChanged(object sender, Syncfusion.Grouping.SelectedRecordsChangedEventArgs e)
        {
            if (e.SelectedRecord != null)
            {
                Console.WriteLine(e.SelectedRecord.Record);
            }
            // To get the number of selected records
            Console.WriteLine(e.Table.SelectedRecords.Count);
        }

        
        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (_orderType == 0)
                FetchPurchaseOrder();
            else
                FetchWorkOrders();
        }

        private void FetchWorkOrders()
        {
            DataSet _dsWO = _as.FetchWO(txtPO.Text.Trim());
            if ((_dsWO.Tables[0].Rows.Count == 0) || (_dsWO.Tables.Count == 1))
            {
                MessageBox.Show(" Work Order Not Existing or Invoice Not Booked ");
            }
            else
            {
                dtPODate.Value = Convert.ToDateTime(_dsWO.Tables[0].Rows[0]["PODATE"]);
                txtSupplier.Text = Convert.ToString(_dsWO.Tables[0].Rows[0]["SUPPLIER"]);
                txtSuppCode.Text = Convert.ToString(_dsWO.Tables[0].Rows[0]["SUPPCODE"]);

                _InvoiceTable = _dsWO.Tables[1];
               lblOrderID.Text = Convert.ToString(_dsWO.Tables[0].Rows[0]["OrdID"]);
               txtInvoice.Text = Convert.ToString(_InvoiceTable.Rows[0]["INVOICENUMBER"]);
               dtInvoiceDate.Value = Convert.ToDateTime(_InvoiceTable.Rows[0]["INVOICEDATE"]);
               txtInvoiceAmount.DecimalValue = Convert.ToDecimal(_InvoiceTable.Rows[0]["INVOICEAMOUNT"]);
            }
        }


        private void FetchPurchaseOrder()
        {

            if (txtPO.Text.Trim() != "")
            {
                DataSet _dsPO = _as.FetchPO(txtPO.Text.Trim());
                if (  (_dsPO.Tables[0].Rows.Count == 0)  || (_dsPO.Tables[1].Rows.Count==0 ) )
                {
                    MessageBox.Show(" Purchase Order Not Exising Or No GRN for the Purchase Order !!! ");
                }
                else
                {
                    dtPODate.Value = Convert.ToDateTime(_dsPO.Tables[0].Rows[0]["PODATE"]);
                    txtSupplier.Text = Convert.ToString(_dsPO.Tables[0].Rows[0]["SUPPLIER"]);
                    txtSuppCode.Text = Convert.ToString(_dsPO.Tables[0].Rows[0]["SUPPCODE"]);
                    
                    _GRNTable = _dsPO.Tables[1];
                    cmbGRN.Enabled = true; 
                    UtilityFunctions.LoadWindowsCombo(cmbGRN, _GRNTable, "GRNNO", "GRNNO", 0);
                    lblOrderID.Text = Convert.ToString(_dsPO.Tables[0].Rows[0]["OrdID"]);
                  
                }

            }
            else
            {
                MessageBox.Show("Invalid PO Number");
            }
        }

       

        

        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearAll();
        }

        private void ClearAll()
        {
            txtAccumulatedDepreciation.DecimalValue = 0;
            txtAssetLife.DefaultValue = 0;
            txtAssetName.Text = "";
            txtAssetNumber.Text = "";
            txtDutyBenefit.DecimalValue = 0;
            txtFERevaluation.DecimalValue = 0;
            txtInvoice.Text = "";
            txtLifeDepreciated.DefaultValue = 0;
            txtPO.Text = "";
            txtPurchaseValue.DecimalValue = 0;
            txtSalvageValue.DecimalValue = 0;
            txtSuppCode.Text = "";
            txtSupplier.Text = "";
            lblOrderID.Text = "0";
            txtAssetLife.Text = "0";
            cmbGRN.Enabled = false;
            txtInvoiceAmount.DecimalValue = 0;
            txtTaxAmount.DecimalValue = 0;
            txtInvoice.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGRN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow[] foundRows;
            int _tranGRP; 
            string _currentSelection = Convert.ToString(cmbGRN.Text).Trim();
            string _searchString = "GRNNO='" + _currentSelection+"'";
            foundRows = _GRNTable.Select(_searchString);
            txtInvoice.Text = Convert.ToString(foundRows[0][1]);
            dtInvoiceDate.Value = Convert.ToDateTime(foundRows[0][2]);
            _tranGRP = Convert.ToInt32(foundRows[0][3]);
            GetAndDisplayInvoiceValueAndTax(_tranGRP);
        }

        private void GetAndDisplayInvoiceValueAndTax(Int32 _tranGRP)
        {
            DataSet _dsInvoiceDetails = new DataSet();
            _dsInvoiceDetails = _as.GetInvoiceDetailsWithTax(_tranGRP);
            txtInvoiceAmount.DecimalValue = Convert.ToDecimal(_dsInvoiceDetails.Tables[0].Rows[0]["INVOICEAMOUNT"]);
            txtTaxAmount.DecimalValue = Convert.ToDecimal(_dsInvoiceDetails.Tables[0].Rows[0]["TAXAMOUNT"]); 

        }

        private void cmbOrderType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _orderType = Convert.ToInt16(cmbOrderType.SelectedIndex);
            if (_orderType == 0 )
            {
                lblOrderType.Text = "Enter Purchase Order Number in FULL (CIPL/...) ";
            }
            else
            {
                lblOrderType.Text = "Enter Work Order Number in FULL ( CIPL/.. )  " ;
                cmbGRN.Enabled = false;
                txtDutyBenefit.Enabled = false;
                txtTaxAmount.Enabled = false;
                txtFERevaluation.Enabled = false;
            }
        }
      
        
        

        
    }
}
