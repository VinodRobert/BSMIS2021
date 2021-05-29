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
    public partial class frmAssetSale : Form
    {
        DataSet _ds = new DataSet();
        Assets _as = new Assets();
        CreditorAge _ca = new CreditorAge();

        public frmAssetSale()
        {
            InitializeComponent();
        }
        private void LoadAssetCategories()
        {
            cmbAssets.Enabled = false;
            _ds = _as.FetchAssetCategories();
            UtilityFunctions.LoadWindowsCombo(cmbAssetCategory, _ds.Tables[0], "AssetCategory", "AssetOppLedgerCode", 0);
        }
        private void frmManualDepreciation_Load(object sender, EventArgs e)
        {
            LoadAssetCategories();
            Reset();
            LoadFinYear();
            LoadPeriods();
        }

        private void Reset()
        {
            cmbPeriods.Enabled = true;
            cmbAssets.Enabled = false;
            txtFinYear.Enabled = false;
            btnSave.Enabled = false;
             
        }

        private void Set()
        {
            cmbPeriods.Enabled = true;
            cmbAssets.Enabled = true;
          
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
            DataSet _dsPeriod = _as.GetCurrentPeriod();
            int _currnetPeriod = Convert.ToInt16(_dsPeriod.Tables[0].Rows[0]["PERIOD"]);
            cmbPeriods.SelectedValue = _currnetPeriod;
            //cmbPeriods.ReadOnly = true; 
        }

       

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string _assetCategory = Convert.ToString(cmbAssetCategory.SelectedValue);
            DataSet _dsAssets = new DataSet();
            _dsAssets = _as.FetchAssetsHavingCategoryUnSold(_assetCategory);
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
            int _assetID;

            btnLoad.Enabled = false; 

            DialogResult result = MessageBox.Show("Are You Sure ?",
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
            _assetID = Convert.ToInt16(cmbAssets.SelectedValue);

            DataSet _dsFinalResult = _as.AssetSale(_finYear, _period, _assetID);

            MessageBox.Show(_dsFinalResult.Tables[0].Rows[0]["Result"].ToString());

            Reset();
            btnLoad.Enabled = true;

        }


    }
}
 