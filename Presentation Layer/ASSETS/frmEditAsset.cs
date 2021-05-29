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
    public partial class frmEditAsset : Form
    {
        Assets _as = new Assets();
        DataSet _ds;
        DataSet _dsAsset = new DataSet();
        DataSet _dsAttribs = new DataSet();
        DataTable _dt = new DataTable();
        DataTable _GRNTable = new DataTable();
        public frmEditAsset()
        {
            InitializeComponent();
        }

         

        private void LoadGrid()
        {
           

            _dsAsset = _as.GetAssets(0);
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
            gridAsset.TableDescriptor.Columns[5].Width = 68;
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
            this.dtInvoiceDate.ReadOnly = true;
            this.dtPODate.ReadOnly = true;
            txtSuppCode.ReadOnly = true;
            txtSupplier.ReadOnly = true;
            lblOrderID.Visible = false;
          
        }
        private void LoadLocations()
        {
            _ds = new DataSet();
            _ds = _as.GetProjectLocations();
            UtilityFunctions.LoadWindowsCombo(cmbLocation, _ds.Tables[0], "BORGNAME", "PROJECTCODE", 0);
        }

        private void LoadAssets()
        {
            DataSet _dsAssetNumber = new DataSet();
            _dsAssetNumber = _as.FetchAssetNumbersForEdit();
            UtilityFunctions.LoadWindowsCombo(cmbAssetNumber, _dsAssetNumber.Tables[0], "ASSETNUMBER", "ASSETNUMBER", 0);
        }

        

        private void frmNewAsset_Load(object sender, EventArgs e)
        {
            Setups();
            LoadLocations();
            

            LoadAssets();
            LoadGrid();
            cmbCategory.SelectedIndex = 0;
        }

        private int ValidateEntry()
        {
            if (Convert.ToInt32(txtAssetLife.Text) <= 0 ) 
               return 0;
            if (Convert.ToString(txtAssetName.Text)=="" )
               return 0;
            
            if (Convert.ToDecimal(txtPurchaseValue.DecimalValue) <= 0) 
               return 0;
            if (Convert.ToDecimal(txtSalvageValue.DecimalValue) <= 0)
                return 0;
            if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) >= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                return 0;
            if (Convert.ToDecimal(txtSalvageValue.DecimalValue) >= Convert.ToDecimal(txtPurchaseValue.DecimalValue))
                return 0;
            if (Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue) >= Convert.ToDecimal(txtSalvageValue.DecimalValue))
                return 0;
            if (Convert.ToInt16(txtLifeDepreciated.Text) >= Convert.ToInt16(txtAssetLife.Text))
                return 0;
            if (Convert.ToString(txtInvoice.Text.Trim()) == "")
                return 0;
            if (Convert.ToString(txtPO.Text.Trim()) == "")
                return 0;
            if (Convert.ToString(txtInvoice.Text.Trim()) == "")
                return 0;
            return 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ValidateEntry() == 1)
            {
                Assets _newAsset = new Assets();
                
                _newAsset.AccumulatedDepreciation = Convert.ToDecimal(txtAccumulatedDepreciation.DecimalValue);
                _newAsset.LifeDepreciated = Convert.ToInt16(txtLifeDepreciated.Text);
                _newAsset.AssetCategory = Convert.ToString(cmbCategory.Text);
                _newAsset.AssetLife = Convert.ToInt16(txtAssetLife.Text);
                _newAsset.AssetLocation = Convert.ToString(cmbLocation.SelectedValue);
                _newAsset.AssetName = Convert.ToString(txtAssetName.Text);
                _newAsset.AssetNumber = Convert.ToString(txtAssetNumber.Text);
                _newAsset.AssetPurchaseValue = Convert.ToDecimal(txtPurchaseValue.DecimalValue);
                _newAsset.AssetPutToUse = Convert.ToDateTime(dtPutToUse.Value);
                _newAsset.AssetSalvageValue = Convert.ToDecimal(txtSalvageValue.DecimalValue);
                _newAsset.AssetOrderID = Convert.ToInt64(lblOrderID.Text);
                _newAsset.GRN = Convert.ToString(cmbGRN.Text);
                _newAsset.AssetInvoiceNo = Convert.ToString(txtInvoice.Text);
                _newAsset.AssetID = Convert.ToInt64(txtAssetID.Text);
                _newAsset.DutyBenefit = Convert.ToDecimal(txtDutyBenefit.DecimalValue);
                _newAsset.FERevaluation = Convert.ToDecimal(txtFERevaluation.DecimalValue);
                _newAsset.PONumber = Convert.ToString(txtPO.Text.Trim());
                _newAsset.PODate = Convert.ToDateTime(dtPODate.Value.Date.ToString("dd/MM/yyyy"));
                _newAsset.SupplierCode = Convert.ToString(txtSuppCode.Text.Trim());
                _newAsset.SupplierName = Convert.ToString(txtSupplier.Text.Trim());
                _newAsset.InvoiceAmount = Convert.ToDecimal(txtInvoiceAmount.DecimalValue);
                _newAsset.InvoiceDate = Convert.ToDateTime(dtInvoiceDate.Value.Date.ToString("dd/MM/yyyy"));
                _newAsset.update();
                MessageBox.Show("Success ..........");
                LoadGrid();
               
            }
            else
            {
                MessageBox.Show("Check Your Entries");
            }
        }

      

     

        private void PopulateVariables(DataSet _ds)
        {
            string _assetCategory = Convert.ToString(_ds.Tables[0].Rows[0]["AssetCategory"]).Trim();
            string _assetLocation;
            _assetLocation = Convert.ToString(_ds.Tables[0].Rows[0]["AssetLocation"]).Trim();
            txtAssetName.Text = Convert.ToString(_ds.Tables[0].Rows[0]["AssetName"]);
            txtAccumulatedDepreciation.Text = Convert.ToString(_ds.Tables[0].Rows[0]["AssetAccumDep"]);
            txtAssetLife.Text = Convert.ToString(_ds.Tables[0].Rows[0]["AssetPeriod"]);
            txtLifeDepreciated.Text = Convert.ToString(_ds.Tables[0].Rows[0]["AssetDepProg"]);
            txtPurchaseValue.DecimalValue = Convert.ToDecimal(_ds.Tables[0].Rows[0]["AssetPPrice"]);
            txtSalvageValue.DecimalValue = Convert.ToDecimal(_ds.Tables[0].Rows[0]["AssetSalvage"]);
            txtAssetID.Text  = Convert.ToString(_ds.Tables[0].Rows[0]["AssetID"]);
       
            dtPutToUse.Value = Convert.ToDateTime(_ds.Tables[0].Rows[0]["AssetPDate"]);
            cmbLocation.SelectedValue  = Convert.ToString(_assetLocation);

            if (_assetCategory == "Plant and Machinery")
                cmbCategory.SelectedIndex = 5; 
            else 
               if (_assetCategory == "Computers and Printers")
                   cmbCategory.SelectedIndex = 0; 
               else 
                  if (_assetCategory == "Form Work Equipment")
                     cmbCategory.SelectedIndex = 1; 
                  else 
                     if (_assetCategory == "Furniture and Fixtures")
                        cmbCategory.SelectedIndex = 2; 
                     else 
                        if (_assetCategory == "Office Equipments")
                           cmbCategory.SelectedIndex = 3;
                        else 
                           if (_assetCategory == "Office Premises")
                               cmbCategory.SelectedIndex = 4;
                           else 
                              if (_assetCategory == "Softwares")
                                  cmbCategory.SelectedIndex = 6;
                              else 
                                 if (_assetCategory == "Vehicles")
                                     cmbCategory.SelectedIndex = 6;
            btnSave.Visible = true;

        }     

        private void EnableControls()
        {
            txtAssetName.Enabled = true;
            cmbCategory.Enabled = true;
            txtAccumulatedDepreciation.Enabled = true;
            txtAssetLife.Enabled = true;
            txtLifeDepreciated.Enabled = true;
            txtPurchaseValue.Enabled = true;
            txtSalvageValue.Enabled = true; 
            txtSupplier.Text = "";
            //txtGRN.Text = "";
            dtPutToUse.Enabled = true;
            cmbLocation.Enabled = true;
        }

        private void GetPurchaseDetail()
        {
           
            if (txtPO.Text.Trim() != "")
            {
                DataSet _dsPO = _as.FetchPO(txtPO.Text.Trim());
                if (_dsPO.Tables.Count >= 1)
                {
                    if ((_dsPO.Tables[0].Rows.Count == 0) || (_dsPO.Tables[1].Rows.Count == 0))
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
                        cmbGRN.Enabled = true;
                        UtilityFunctions.LoadWindowsCombo(cmbGRN, _GRNTable, "GRNNO", "GRNNO", 0);
                        lblOrderID.Text = Convert.ToString(_dsPO.Tables[0].Rows[0]["OrdID"]);
                        UtilityFunctions.LoadWindowsCombo(cmbGRN, _dsPO.Tables[1], "GRNNO", "GRNNO", 0);
                        lblOrderID.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["ORDID"]);
                    }
                }

            }
            else
            {
                MessageBox.Show("Invalid PO Number");
            }
        }

     


        private void btnFetch_Click(object sender, EventArgs e)
        {
            GetPurchaseDetail();
        }

        private void btnGetIt_Click(object sender, EventArgs e)
        {
            txtAssetNumber.Text = Convert.ToString(cmbAssetNumber.SelectedValue);
            _as = new Assets();
            _as.AssetNumber = Convert.ToString(txtAssetNumber.Text);
            _ds = _as.FetchAll();

            PopulateVariables(_ds);


            _dsAttribs = _as.FetchAttributes(Convert.ToInt64(txtAssetID.Text));
            if (_dsAttribs.Tables[0].Rows.Count > 0)
            {
                txtPO.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["ORDERNUMBER"]);
                txtInvoice.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["INVOICENUMBER"]);
                txtDutyBenefit.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["DUTYBENEFITS"]);
                txtFERevaluation.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["FEREVALUATION"]);
                dtPODate.Value = Convert.ToDateTime(_dsAttribs.Tables[0].Rows[0]["PODate"]);
                txtSuppCode.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["SupplierCode"]);
                txtSupplier.Text = Convert.ToString(_dsAttribs.Tables[0].Rows[0]["SupplierName"]);
                dtInvoiceDate.Value = Convert.ToDateTime(_dsAttribs.Tables[0].Rows[0]["InvoiceDate"]);
                txtInvoiceAmount.DecimalValue = Convert.ToDecimal(_dsAttribs.Tables[0].Rows[0]["InvoiceAmount"]);
               
                txtTaxAmount.DecimalValue = 0; 
            }
            //  GetPurchaseDetail();
            //EnableControls();
        }

        private void linkDetachPO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataSet _detach = _as.DetachPO(Convert.ToInt64(txtAssetID.Text));
            txtPO.Text = "";
            cmbGRN.Enabled = false;
            txtInvoice.Text = "";
            txtSuppCode.Text = "";
            txtSupplier.Text = "";
            dtPODate.Value = DateTime.Now;
            txtInvoiceAmount.DecimalValue = 0;
            dtInvoiceDate.Value = DateTime.Now;
            txtTaxAmount.DecimalValue = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGRN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow[] foundRows;
            string _currentSelection = Convert.ToString(cmbGRN.Text).Trim();
            string _searchString = "GRNNO='" + _currentSelection + "'";
            foundRows = _GRNTable.Select(_searchString);
            txtInvoice.Text = Convert.ToString(foundRows[0][1]);
            dtInvoiceDate.Value = Convert.ToDateTime(foundRows[0][2]);
        }

        
    }
}
