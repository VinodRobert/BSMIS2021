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
 

 
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel; 

namespace BSMIS 
{
    public partial class frmPostDepreciation : Form
    {
        DataSet _ds;
        Assets _as = new Assets();
        Entities _en = new Entities();
        int CurrentFinYear;
        int CurrentPeriod;
        string CurrentLedgercode;

       public frmPostDepreciation()
        {
            InitializeComponent();
        }

       private void frmPostDepreciation_Load(object sender, EventArgs e)
       {
           LoadAssetCategory();
           LoadYearMonth();
       }

       private void LoadAssetCategory()
       {
           _ds = new DataSet();
           _ds = _as.FetchAssetCategories();
           UtilityFunctions.LoadWindowsCombo(cmbAssetCategory, _ds.Tables[0], "AssetCategory", "AssetOppLedgerCode", 0);
           CurrentLedgercode = Convert.ToString(_ds.Tables[0].Rows[0]["AssetOppLedgerCode"]);
       }

       private void LoadYearMonth()
       {
           DataSet _dsYP = new DataSet();
           _dsYP = _en.GetDepreciationFinancialYears();
           CurrentFinYear = Convert.ToInt16(_dsYP.Tables[0].Rows[0]["CURRENTYEAR"]);
           txtFinYear.Text = Convert.ToString(CurrentFinYear);
           CurrentPeriod = Convert.ToInt16(_dsYP.Tables[0].Rows[0]["PERIOD"]);
           txtMonth.Text = Convert.ToString(_dsYP.Tables[0].Rows[0]["PERIODDESC"]);
       }


       private void btnPOSTIT_Click(object sender, EventArgs e)
       {
           string _oppLedgerCode = Convert.ToString(cmbAssetCategory.SelectedValue);
           txtAlert.Visible = true; 
           DialogResult result = MessageBox.Show("Are You Sure About Fin Year and Current Month ?",
                                                  "Depreciation Posting ?",
                                                   MessageBoxButtons.YesNoCancel,
                                                   MessageBoxIcon.Question,
                                                   MessageBoxDefaultButton.Button2);
           if (result == DialogResult.Cancel)
               this.Close();
           if (result == DialogResult.No)
               return;
           btnPOSTIT.Enabled = false;
           cmbAssetCategory.Enabled = false;
           StartPostingDepreciation(CurrentFinYear, CurrentPeriod, CurrentLedgercode);

       }

       private void StartPostingDepreciation(int _currentFinYear, int _currentPeriod, string _currentLedgercode)
       {
        
          
           DataSet _dsResult = _as.PostDepreciation(_currentFinYear, _currentPeriod, _currentLedgercode);

           MessageBox.Show(_dsResult.Tables[0].Rows[0]["Result"].ToString());

           btnPOSTIT.Enabled = true;
           cmbAssetCategory.Enabled = true;
           txtAlert.Visible = false; 
       }

       private void cmbAssetCategory_SelectionChangeCommitted(object sender, EventArgs e)
       {
           CurrentLedgercode = Convert.ToString(cmbAssetCategory.SelectedValue); 
       }
       

        

         

       

    }   
  }

