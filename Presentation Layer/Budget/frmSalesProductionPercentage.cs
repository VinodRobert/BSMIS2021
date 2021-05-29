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
    public partial class frmSalesProductionPercentage : Form
    {
        DataSet _dsFinYear;
        DataSet _dsProjects;
        DataSet _ds2;

        CreditorAge _cg = new CreditorAge();
        int _orgID;
        int _finyear;
        int _month;
        public frmSalesProductionPercentage()
        {
            InitializeComponent();
        }

        private void frmSalesProductionPercentage_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void LoadCombos()
        {
            _dsFinYear = _cg.GetBudgetYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _dsFinYear.Tables[0], "FINYEAR", "FINYEAR", 0);

            _dsProjects = _cg.GetProjectsHavingBudget();
            UtilityFunctions.LoadWindowsCombo(cmbProjects, _dsProjects.Tables[0], "BORGNAME", "BORGID", 0);

            _ds2 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);

            ShowProductions();

        }

        private void ShowProductions()
        {
        
            _orgID = Convert.ToInt16(cmbProjects.SelectedValue);
            _finyear = Convert.ToInt16(cmbFinYear.SelectedValue);

            DataSet _dsPercentage = _cg.GetSalesPercentage(_finyear,_orgID  );
            gridViewPercentage.DataSource = _dsPercentage.Tables[0];

            DataSet _dsLedgers = _cg.FetchLedgersHavingImpact();
            gridViewLedgers.DataSource = _dsLedgers.Tables[0];

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int _success;
            decimal _salesPercentage ;
           
            _month = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _salesPercentage = Convert.ToDecimal(salesPercentage.PercentValue);
            _success = _cg.UpdateSalesPercentage(_finyear,_month, _orgID, _salesPercentage);
            ShowProductions();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void cmbProjects_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowProductions();
        }

         
    }
}
