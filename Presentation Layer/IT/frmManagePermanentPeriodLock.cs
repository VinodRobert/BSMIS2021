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
    public partial class frmManagePermanentPeriodLock : Form
    {
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataSet _dsFromYear;
     
        DataSet _dsFromPeriod;

        IT _it = new IT();


        int _CurrentFinYear;
        int _CurrentMonth;
        int _fromYear;
        int _toPeriod;

        string _CurrentMonthName;


        DataTable _tableProjects = new DataTable();

         
        string _selectedProjects;

        public frmManagePermanentPeriodLock()
        {
            InitializeComponent();
        }

        private void frmGlobalPeriodMangement_Load(object sender, EventArgs e)
        {
            ActivateCurrentFinYear();
            ResetAll();
         
            
            LoadCombos();
        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
            _tableProjects.Columns.Add("BORGID", typeof(int));
        }

        public void ResetAll()
        {
            
        }

       

        private void LoadListProject(int _finYear,int _period, int _action )
        {
            _ds = _it.ExractPeriodStatus(_finYear, _period, _action);
            _dtProject = _ds.Tables[0];
            listProject.Sorted = true;
            listProject.Items.Clear();
            for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
            {
                _selectedProjects = Convert.ToString(_ds.Tables[0].Rows[i][1]);
                listProject.Items.Add(_selectedProjects);
            }

            for (int i = 0; i < listProject.Items.Count; i++)
                listProject.SetItemChecked(i, true);

            chkUnChkProject.Checked = true;
        }

        public DataSet GetBorgs(int _zoneID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@ZONE", SqlDbType.Int);
            arParms[0].Value = _zoneID;
            // Execute the stored procedure
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetBorgs", arParms);
            return ds;
        }



        private void ResetAllBorgsChecked()
        {
            for (int i = 0; i < listProject.Items.Count; i++)
            {
                listProject.SetItemChecked(i, true);
            }

        }

       






      

       
        private void chkUnChkProject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnChkProject.Checked)
            {
                for (int i = 0; i < listProject.Items.Count; i++)
                {
                    listProject.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listProject.Items.Count; i++)
                {
                    listProject.SetItemChecked(i, false);
                }
            }
        }



        private void LoadCombos()
        {
            _dsFromYear = _cg.GetFinancialYearsForLedgerReports();
            UtilityFunctions.LoadWindowsCombo(cmbFromYear, _dsFromYear.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFromYear.SelectedValue = _CurrentFinYear;

       

            _dsFromPeriod = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _dsFromPeriod.Tables[0], "PERIODDESC", "PERIODID", 0);

            cmbAction.SelectedValue = "Lock";
            cmbAction.SelectedText="Lock";
            cmbAction.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoPreparatoryWorks();
            int _action; 
            _fromYear = Convert.ToInt16(cmbFromYear.SelectedValue.ToString());
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue.ToString());
            if (Convert.ToString(cmbAction.Text) == "Lock")
                _action = 1;
            else
                _action = 0;

            int _result = _it.SetPeriodGlobally(_fromYear, _toPeriod, _tableProjects, _action); 
           if ( _result>1 )
            {
                MessageBox.Show("Sucess .", "Result ");
                this.Close();
                return; 
                
            }
           
        }

        private void DoPreparatoryWorks()
        {
            GeneateOrgTable();
        }

        private void GeneateOrgTable()
        {
            int i;
            string _searchString;
            _tableProjects.Rows.Clear();
            for (i = 0; i <= (listProject.Items.Count - 1); i++)
            {
                if (listProject.GetItemChecked(i))
                {
                    _searchString = "BORGNAME LIKE '" + listProject.Items[i].ToString().Trim() + "%'";
                    DataRow[] result = _dtProject.Select(_searchString);
                    if (result.Length > 0)
                    {
                        _tableProjects.Rows.Add(Convert.ToString(result[0][0]));
                    }
                }
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            int _action ;
            int _finYear = Convert.ToInt16(cmbFromYear.SelectedValue);
            int _period = Convert.ToInt16(cmbToPeriod.SelectedValue);
            if (Convert.ToString(cmbAction.Text) == "Lock")
                _action = 0;
            else
                _action = 1;

            LoadListProject(_finYear,_period,_action );

        }

         







    }
}
