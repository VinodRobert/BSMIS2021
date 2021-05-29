using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SQLHelper;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Drawing;

using OfficeOpenXml;
using System.IO;
using System.Globalization;

namespace BSMIS 
{
    public partial class frmManualDepreciation : Form
    {
        DataSet _ds = new DataSet();
        Assets _as = new Assets();
        CreditorAge _ca = new CreditorAge();

        public frmManualDepreciation()
        {
            InitializeComponent();
        }
        private void LoadAssetCategories()
        {
            cmbAssets.Enabled = false;
            _ds = _as.FetchAssetCategories();
            UtilityFunctions.LoadWindowsCombo(cmbAssetCategory, _ds.Tables[0], "AssetCategory", "AssetOppLedgerCode", 0);
        }
        private void LoadAlreadyDone()
        {
            DataSet _dsResult = _as.FetchManualDepreciation();
            gridResult.DataSource = _dsResult.Tables[0];
            gridResult.Refresh();
        }
        private void frmManualDepreciation_Load(object sender, EventArgs e)
        {
            LoadAlreadyDone();
            LoadAssetCategories();
            Reset();
            LoadFinYear();
            LoadPeriods();
        }

        private void Reset()
        {
            cmbPeriods.Enabled = false;
            cmbAssets.Enabled = false;
            txtFinYear.Enabled = false;
            btnSave.Enabled = false;
            txtAmount.Enabled = false;
            txtAmount.DecimalValue = 0M;

            this.gridResult.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridResult.ShowGroupDropArea = false;
            this.gridResult.TableOptions.AllowSortColumns = true;
            this.gridResult.TopLevelGroupOptions.ShowCaption = true;
            this.gridResult.TableOptions.RecordPreviewRowHeight = 55;
            this.gridResult.TableOptions.ShowRowHeader = false;
            this.gridResult.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridResult.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridResult.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridResult.TableOptions.DefaultColumnWidth = 65;
            this.gridResult.TableOptions.CaptionRowHeight = 22;
            this.gridResult.InvalidateAllWhenListChanged = true;
            this.gridResult.ForceDisposeOnResetDataSource = true;
            this.gridResult.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridResult.CacheRecordValues = false;
            this.gridResult.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridResult.Font = new Font("Calibri", 8.0f);
            this.gridResult.TopLevelGroupOptions.ShowFilterBar = false;   
        }

        private void Set()
        {
            cmbPeriods.Enabled = true;
            cmbAssets.Enabled = true;
            txtAmount.Enabled = true;
            txtFinYear.Enabled = true;
            btnSave.Enabled = true;
            cmbAssets.ReadOnly = false; 
        }

        private void LoadFinYear()
        {
            DataSet _dsFinYear = _as.GetActiveFinancialYear();
            txtFinYear.Text = Convert.ToString(_dsFinYear.Tables[0].Rows[0]["FinYear"]);
        }

        private void LoadPeriods()
        {
            DataSet _dsFinYear = _ca.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbPeriods, _dsFinYear.Tables[0], "PERIODDESC", "PERIODID", 0);
            //DataSet _dsPeriod = _as.GetCurrentPeriod();
            //int _currnetPeriod = Convert.ToInt16(_dsPeriod.Tables[0].Rows[0]["PERIOD"]);
            //cmbPeriods.SelectedValue = _currnetPeriod;
            //cmbPeriods.ReadOnly = true; 
        }

       

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string _assetCategory = Convert.ToString(cmbAssetCategory.SelectedValue);
            DataSet _dsAssets = new DataSet();
            _dsAssets = _as.FetchAssetsHavingCategory(_assetCategory);
            UtilityFunctions.LoadWindowsCombo(cmbAssets, _dsAssets.Tables[0], "ASSETNAME", "ASSETID", 0);
            cmbAssets.Enabled = true;
            Set();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int _finYear;
            int _period;
            decimal _amount;
            int _assetID;

            btnLoad.Enabled = false; 

            DialogResult result = MessageBox.Show("Are You Sure  ?",
                                                   "Manual Depreciation Posting ?",
                                                    MessageBoxButtons.YesNoCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel)
                this.Close();
            if (result == DialogResult.No)
                return;

            _finYear = Convert.ToInt16(txtFinYear.Text);
            _period = Convert.ToInt16(cmbPeriods.SelectedValue);
            _amount = Convert.ToDecimal(txtAmount.DecimalValue);
            _assetID = Convert.ToInt16(cmbAssets.SelectedValue);

            DataSet _dsFinalResult = _as.PostManualDepreciation(_finYear, _period, _assetID, _amount);

            MessageBox.Show(_dsFinalResult.Tables[0].Rows[0]["Result"].ToString());

            Reset();
            btnLoad.Enabled = true;
            LoadAlreadyDone();

        }


    }
}
 