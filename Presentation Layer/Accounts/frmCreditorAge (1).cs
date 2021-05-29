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
    public partial class frmSubbieAge : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
        int _reportChoice;
        string _ExcelFileName;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataTable _dtCreditors = new DataTable();
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();


        DataTable _tableCreditors = new DataTable();
        DataTable _tableProjects = new DataTable();

        DataTable _resultDetailed = new DataTable();
        DataTable _resultProjectWise = new DataTable();
        DataTable _resultSupplierWise = new DataTable();

        DataSet _dsFinalResult;
        DataSet _dsFinalResultFormatted; 

        string _selectedCreditors;
        string _selectedZones;
        string _selectedProjects;

        int _runCounterDetail;
        int _runCounterProject;
        int _runCounterConsolidated;


        string _Header1;
        string _Header2;
        string _Header3; 

        public frmSubbieAge()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            cmbDebtors.Visible = false;

            dtAgedTo.MinDate = Convert.ToDateTime("01-Apr-2016");
            dtAgedTo.MaxDate = DateTime.Now;

            _tableCreditors.Columns.Add("CredNumber", typeof(string));
            _tableProjects.Columns.Add("BORGID", typeof(int));

            txtSearchCreditor.ForeColor = Color.Red;

            ggDetail.Visible = false;
            ggConsolidated.Visible = false;
            ggProject.Visible = false;

            this.ggDetail.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggDetail.ShowGroupDropArea = true;
            this.ggDetail.TableOptions.AllowSortColumns = true;
            this.ggDetail.TopLevelGroupOptions.ShowCaption = true;
            this.ggDetail.TableOptions.RecordPreviewRowHeight = 55;
            this.ggDetail.TableOptions.ShowRowHeader = false;
            this.ggDetail.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggDetail.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggDetail.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggDetail.TableOptions.DefaultColumnWidth = 65;
            this.ggDetail.TableOptions.CaptionRowHeight = 22;
            this.ggDetail.InvalidateAllWhenListChanged = true;
            this.ggDetail.ForceDisposeOnResetDataSource = true;
            this.ggDetail.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggDetail.CacheRecordValues = false;
            this.ggDetail.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggDetail.Font = new Font("Calibri",8.0f);
            this.ggDetail.TopLevelGroupOptions.ShowFilterBar = true;   

            this.ggProject.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggProject.ShowGroupDropArea = true;
            this.ggProject.TableOptions.AllowSortColumns = true;
            this.ggProject.TopLevelGroupOptions.ShowCaption = true;
            this.ggProject.TableOptions.RecordPreviewRowHeight = 55;
            this.ggProject.TableOptions.ShowRowHeader = false;
            this.ggProject.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggProject.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggProject.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggProject.TableOptions.DefaultColumnWidth = 65;
            this.ggProject.TableOptions.CaptionRowHeight = 22;
            this.ggProject.InvalidateAllWhenListChanged = true;
            this.ggProject.ForceDisposeOnResetDataSource = true;
            this.ggProject.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggProject.CacheRecordValues = false;
            this.ggProject.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Silver;
            this.ggProject.Font = new Font("Calibri", 8.0f);
            this.ggProject.TopLevelGroupOptions.ShowFilterBar = true;   


            this.ggConsolidated.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggConsolidated.ShowGroupDropArea = true;
            this.ggConsolidated.TableOptions.AllowSortColumns = true;
            this.ggConsolidated.TopLevelGroupOptions.ShowCaption = true;
            this.ggConsolidated.TableOptions.RecordPreviewRowHeight = 55;
            this.ggConsolidated.TableOptions.ShowRowHeader = false;
            this.ggConsolidated.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggConsolidated.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggConsolidated.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggConsolidated.TableOptions.DefaultColumnWidth = 65;
            this.ggConsolidated.TableOptions.CaptionRowHeight = 22;
            this.ggConsolidated.InvalidateAllWhenListChanged = true;
            this.ggConsolidated.ForceDisposeOnResetDataSource = true;
            this.ggConsolidated.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggConsolidated.CacheRecordValues = false;
            this.ggConsolidated.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Silver;
            this.ggConsolidated.Font = new Font("Calibri", 8.0f);
            this.ggConsolidated.TopLevelGroupOptions.ShowFilterBar = true;   


            btnReset.Visible = false;
            btnExport.Visible = false;

            rdConsolidated.Checked = false;
            rdDetail.Checked = false;
            rdProject.Checked = false;
            gbView.Visible = false; 

            _runCounterDetail = 0;
            _runCounterConsolidated = 0;
            _runCounterProject = 0; 

        }

        public DataSet GetFinancialYears()
        {
            string _query = "Select DISTINCT  [Year] FINYEAR, [Year] FINYEARID FROM TRANSACTIONS WHERE YEAR>=2015 ORDER BY YEAR";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.TableDirect, _query);
            return ds;
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

        public DataSet GetPeriods()
        {
            QueryString _qr = new QueryString();
            _qr.FieldList = " * ";
            _qr.Criteria = "1=1";
            _qr.OrderBy = "PeriodID";
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] parameters = SqlHelper.BindParameters(_qr, "BS.spSelectPeriod", _connectionString);
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetPeriod", parameters);
            return ds;
        }

        private void LoadListCreditors()
        {
            switch (GlobalVariables.AgeOf)
            { 
                case 1:
                    _ds = _cg.GetCreditorsInYear(_CurrentFinYear);
                    break;
                case 2:
                    _ds = _cg.GetSubContractorsInYear(_CurrentFinYear);
                    break;
                case 3:
                    string  _debtorLedgercode = Convert.ToString(cmbDebtors.SelectedValue);
                    _ds = _cg.GetDebtorsInYear(_CurrentFinYear, _debtorLedgercode);
                    break;
            }
        
            _dtCreditors = _ds.Tables[0];

            listCreditors.Sorted = true;

            for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
            {
                _selectedCreditors = Convert.ToString(_ds.Tables[0].Rows[i][1]);
                listCreditors.Items.Add(_selectedCreditors);
            }

            for (int i = 0; i < listCreditors.Items.Count; i++)
                listCreditors.SetItemChecked(i, true);

            chkUnChkCreditor.Checked = true;
        }

        private void ResetAllCreditorsChecked()
        {
            for (int i = 0; i < listCreditors.Items.Count; i++)
            {
                listCreditors.SetItemChecked(i, true);
            }
            chkUnChkProject.Checked = true; 
        }

        private void ResetAllBorgsChecked()
        {
            for (int i = 0; i < listProject.Items.Count; i++)
            {
                listProject.SetItemChecked(i, true);
            }
            chkUnChkCreditor.Checked = true;
        }
        private void chkUnChkCreditor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnChkCreditor.Checked)
            {
                for (int i = 0; i < listCreditors.Items.Count; i++)
                {
                    listCreditors.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listCreditors.Items.Count; i++)
                {
                    listCreditors.SetItemChecked(i, false);
                }
            }
        }

        private void LoadListZone()
        {
            _ds = _cg.GetZones();
            _dtZone = _ds.Tables[0];

            listZone.Sorted = false;

            for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
            {
                _selectedZones = Convert.ToString(_ds.Tables[0].Rows[i][1]);
                listZone.Items.Add(_selectedZones);
            }

            for (int i = 0; i < listZone.Items.Count; i++)
                listZone.SetItemChecked(i, true);


            chkUnchkZone.Checked = true;

        }

        private void LoadProjectsBasedOnZoneSelection()
        {
            int sCount = listZone.CheckedItems.Count;
            if (sCount == 4)
            {
                LoadListProject();

            }
            else
            {
                LoadListProjectZoneWise();
                chkUnChkProject.Visible = true;
                listProject.Visible = true;
            }
        }
        private void listZone_MouseUp(object sender, MouseEventArgs e)
        {
            LoadProjectsBasedOnZoneSelection();
        }

        private void LoadListProjectZoneWise()
        {
            listProject.Items.Clear();
            listProject.Sorted = true;
            string _tickedZone = "";

            if (listZone.CheckedItems.Count != 0)
            {

                for (int x = 0; x <= listZone.CheckedItems.Count - 1; x++)
                {
                    _tickedZone = _tickedZone + listZone.CheckedItems[x].ToString() + ",";
                }

                int _len = _tickedZone.Length;
                _tickedZone = _tickedZone.Substring(0, _len - 1);
                LoadListProjectZones(_tickedZone);
            }
        }


        private void chkUnchkZone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnchkZone.Checked)
            {
                for (int i = 0; i < listZone.Items.Count; i++)
                {
                    listZone.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listZone.Items.Count; i++)
                {
                    listZone.SetItemChecked(i, false);
                }
            }
            LoadProjectsBasedOnZoneSelection();
        }


        private void LoadListProjectZones(string _SelectedZones)
        {
            _ds = _cg.GetBorgs(_SelectedZones);
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


        private void LoadListProject()
        {
            _ds = _cg.GetBorgs(0);
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
            _ds = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;

            cmbAgingOf.Items.Add("Transaction Date");
            cmbAgingOf.Items.Add("Invoice     Date");
            cmbAgingOf.SelectedIndex = 0;
            cmbAgingOf.ReadOnly = true; 

            cmbAgedTo.Items.Add("Live");
            cmbAgedTo.Items.Add("Period");
            cmbAgedTo.SelectedIndex = 0;

            //if (GlobalVariables.AgeOf != 1)
            //{
                cmbAgedTo.SelectedIndex = 1;
                cmbAgingOf.ReadOnly = true;
                cmbAgedTo.ReadOnly = true; 
            //}

            _ds = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbPeriods, _ds.Tables[0], "PERIODDESC", "PERIODID", 0);

            cmbDebtors.Visible = false;
            lblAgeOf.Text = "Age Of";
            if (GlobalVariables.AgeOf == 3)
            {
                DataSet _dsD = _cg.GetDebtors();
                UtilityFunctions.LoadWindowsCombo(cmbDebtors, _dsD.Tables[0], "LEDGERNAME", "LEDGERCODE", 0);
                cmbDebtors.Visible = true;
                cmbAgingOf.Visible = false;
                lblAgeOf.Text = "Debtor";
            }

        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
            cmbFinYear.ReadOnly = true;
            cmbAgingOf.ReadOnly = true;
            dtAgedTo.MinDate = Convert.ToDateTime("01-April-2015");

        }


        private void frmCreditorAge_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.AgeOf == 1)
                lblHeader.Text = "Creditor Aging Report";
            else if (GlobalVariables.AgeOf == 2)
                lblHeader.Text = "Sub Contractor Aging Report";
            else
                lblHeader.Text = "Debtor Aging Report";

            ActivateCurrentFinYear();
            ResetAll();
            LoadCombos();
            LoadListCreditors();
            LoadListZone();
            LoadListProject();

        }



        private void cmbAgingOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFinYear.ReadOnly = true;
            if (cmbAgedTo.Text == "Given Date")
            {
                dtAgedTo.Visible = true;
                cmbAgingOf.ReadOnly = false;
            }
            else
                dtAgedTo.Visible = false;

            if (cmbAgedTo.Text == "Period")
            {
                cmbPeriods.Visible = true;
                cmbFinYear.ReadOnly = false;
                cmbAgingOf.ReadOnly = false;
            }
            else
                cmbPeriods.Visible = false;

            if (cmbAgedTo.Text == "Live")
            {
                cmbFinYear.ReadOnly = true;
                dtAgedTo.Visible = false;
                cmbPeriods.Visible = false;
                cmbAgingOf.ReadOnly = true;
                cmbAgingOf.SelectedIndex = 0;
            }
        }

        private void dtAgedTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime _agingAsOn;
            _agingAsOn = dtAgedTo.Value.Date;
            _ds = _cg.GetFinancialYearFromDate(Convert.ToString(_agingAsOn));
            cmbFinYear.SelectedValue = _ds.Tables[0].Rows[0][0];
        }

        private void DoPreparatoryWorks()
        {

            GeneateCreditorTable();
            GeneateOrgTable();

        }

        private void GeneateCreditorTable()
        {
            int i;
            string _searchString;
            _tableCreditors.Rows.Clear();
            for (i = 0; i <= (listCreditors.Items.Count - 1); i++)
            {
                if (listCreditors.GetItemChecked(i))
                {
                    _searchString = "CREDNAME LIKE '" + listCreditors.Items[i].ToString().Trim() + "%'";
                    DataRow[] result = _dtCreditors.Select(_searchString);
                    if (result.Length > 0)
                    {
                        _tableCreditors.Rows.Add(Convert.ToString(result[0][0]));
                    }
                }
            }
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

     
        private void LoadDetail(DataTable _dt)
        {
        
            ggDetail.DataSource = _dt;
            if (_runCounterDetail == 0)
            {
                _runCounterDetail = _runCounterDetail + 1; 
                ggDetail.TableDescriptor.Columns[0].HeaderText = "ID";
                ggDetail.TableDescriptor.Columns[0].Width = 0;

                ggDetail.TableDescriptor.Columns[1].HeaderText = "SupplierID";
                ggDetail.TableDescriptor.Columns[1].Width = 0;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "Vendor";
                ggDetail.TableDescriptor.Columns[2].Width = 200;
                ggDetail.TableDescriptor.Columns[2].AllowFilter = true;

                ggDetail.TableDescriptor.Columns[3].HeaderText = "BORGID";
                ggDetail.TableDescriptor.Columns[3].Width = 0;

                ggDetail.TableDescriptor.Columns[4].HeaderText = "Project";
                ggDetail.TableDescriptor.Columns[4].Width = 200;
                ggDetail.TableDescriptor.Columns[4].AllowFilter = true;
                this.ggDetail.TableModel.Cols.FreezeRange(0, 4);

                ggDetail.TableDescriptor.Columns[5].HeaderText = "Type";
                ggDetail.TableDescriptor.Columns[5].Width = 30;
                ggDetail.TableDescriptor.Columns[5].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[6].HeaderText = "Invoice #";
                ggDetail.TableDescriptor.Columns[6].Width = 70;
                ggDetail.TableDescriptor.Columns[6].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[7].HeaderText = "Inv. Date";
                ggDetail.TableDescriptor.Columns[7].Width = 65;
                ggDetail.TableDescriptor.Columns[7].Appearance.AnyCell.CellType = "Date";
                ggDetail.TableDescriptor.Columns[7].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[8].HeaderText = "Invoice Amount";
                ggDetail.TableDescriptor.Columns[8].Width = 100;
                ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";
                ggDetail.TableDescriptor.Columns[8].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[9].HeaderText = "Age";
                ggDetail.TableDescriptor.Columns[9].Width = 40;
                ggDetail.TableDescriptor.Columns[9].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[10].HeaderText = "[ <= 30 ]";
                ggDetail.TableDescriptor.Columns[10].Width = 70;
                ggDetail.TableDescriptor.Columns[10].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[11].HeaderText = "[31 - 60]";
                ggDetail.TableDescriptor.Columns[11].Width = 70;
                ggDetail.TableDescriptor.Columns[11].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[12].HeaderText = "[61 - 90]";
                ggDetail.TableDescriptor.Columns[12].Width = 70;
                ggDetail.TableDescriptor.Columns[12].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[12].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[13].HeaderText = "[91 - 180]";
                ggDetail.TableDescriptor.Columns[13].Width = 70;
                ggDetail.TableDescriptor.Columns[13].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[13].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[14].HeaderText = "[181 - 365]";
                ggDetail.TableDescriptor.Columns[14].Width = 70;
                ggDetail.TableDescriptor.Columns[14].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[14].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[15].HeaderText = "[366 - 730]";
                ggDetail.TableDescriptor.Columns[15].Width = 70;
                ggDetail.TableDescriptor.Columns[15].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[15].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[16].HeaderText = "[731 - 1095]";
                ggDetail.TableDescriptor.Columns[16].Width = 70;
                ggDetail.TableDescriptor.Columns[16].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[17].HeaderText = "[ > 1095  ]";
                ggDetail.TableDescriptor.Columns[17].Width = 70;
                ggDetail.TableDescriptor.Columns[17].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[17].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[18].HeaderText = "Un Matched";
                ggDetail.TableDescriptor.Columns[18].Width = 70;
                ggDetail.TableDescriptor.Columns[18].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[18].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[19].HeaderText = "LineTotal";
                ggDetail.TableDescriptor.Columns[19].Width = 100;
                ggDetail.TableDescriptor.Columns[19].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[19].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[20].HeaderText = "Narration";
                ggDetail.TableDescriptor.Columns[20].Width = 100;
                ggDetail.TableDescriptor.Columns[20].AllowGroupByColumn = false;

                GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "BUCKET0", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "BUCKET1", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd2 = new GridSummaryColumnDescriptor("Sum2", SummaryType.DoubleAggregate, "BUCKET2", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd3 = new GridSummaryColumnDescriptor("Sum3", SummaryType.DoubleAggregate, "BUCKET3", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd4 = new GridSummaryColumnDescriptor("Sum4", SummaryType.DoubleAggregate, "BUCKET4", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd5 = new GridSummaryColumnDescriptor("Sum5", SummaryType.DoubleAggregate, "BUCKET5", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd6 = new GridSummaryColumnDescriptor("Sum6", SummaryType.DoubleAggregate, "BUCKET6", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd7 = new GridSummaryColumnDescriptor("Sum7", SummaryType.DoubleAggregate, "BUCKET7", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd8 = new GridSummaryColumnDescriptor("Sum8", SummaryType.DoubleAggregate, "UNMATCHED", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd9 = new GridSummaryColumnDescriptor("Sum9", SummaryType.DoubleAggregate, "LINETOTAL", "{Sum:#.00}");

                scd0.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd0.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd1.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd1.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd2.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd2.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd3.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd3.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd4.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd4.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd5.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd5.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd6.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd6.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd7.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd7.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd8.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd8.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd9.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd9.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                GridSummaryRowDescriptor srd = new GridSummaryRowDescriptor("Sum", "Total", new GridSummaryColumnDescriptor[] { scd0, scd1, scd2, scd3, scd4, scd5, scd6, scd7, scd8,scd9 });
                srd.Appearance.AnyCell.Format = "F2";
                srd.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

                this.ggDetail.TableDescriptor.SummaryRows.Add(srd);
                this.ggDetail.TableDescriptor.Columns[5].AllowGroupByColumn = false;

                this.ggDetail.TableDescriptor.Columns[2].AllowFilter = true;
                this.ggDetail.TableDescriptor.Columns[4].AllowFilter = true;

            }
        }

        private void LoadProject(DataTable _dt)
        {
           
            ggProject.DataSource = _dt;

            if (_runCounterProject == 0)
            {
                _runCounterProject = _runCounterProject + 1;
                ggProject.TableDescriptor.Columns[0].HeaderText = "ID";
                ggProject.TableDescriptor.Columns[0].Width = 0;

                ggProject.TableDescriptor.Columns[1].HeaderText = "SupplierID";
                ggProject.TableDescriptor.Columns[1].Width = 0;

                ggProject.TableDescriptor.Columns[2].HeaderText = "Vendor";
                ggProject.TableDescriptor.Columns[2].Width = 225;
                ggProject.TableDescriptor.Columns[2].AllowFilter = true;

                ggProject.TableDescriptor.Columns[3].HeaderText = "BORGID";
                ggProject.TableDescriptor.Columns[3].Width = 0;

                ggProject.TableDescriptor.Columns[4].HeaderText = "Project";
                ggProject.TableDescriptor.Columns[4].Width = 225;
                ggProject.TableDescriptor.Columns[4].AllowFilter = true;

                this.ggProject.TableModel.Cols.FreezeRange(0, 4);

                ggProject.TableDescriptor.Columns[5].HeaderText = "[ <= 30 ]";
                ggProject.TableDescriptor.Columns[5].Width = 75;
                ggProject.TableDescriptor.Columns[5].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";


                ggProject.TableDescriptor.Columns[6].HeaderText = "[31 - 60]";
                ggProject.TableDescriptor.Columns[6].Width = 75;
                ggProject.TableDescriptor.Columns[6].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";


                ggProject.TableDescriptor.Columns[7].HeaderText = "[61 - 90]";
                ggProject.TableDescriptor.Columns[7].Width = 75;
                ggProject.TableDescriptor.Columns[7].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[8].HeaderText = "[91 - 180]";
                ggProject.TableDescriptor.Columns[8].Width = 75;
                ggProject.TableDescriptor.Columns[8].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[9].HeaderText = "[181 - 365]";
                ggProject.TableDescriptor.Columns[9].Width = 75;
                ggProject.TableDescriptor.Columns[9].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[10].HeaderText = "[366 - 730]";
                ggProject.TableDescriptor.Columns[10].Width = 75;
                ggProject.TableDescriptor.Columns[10].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[11].HeaderText = "[731 - 1095]";
                ggProject.TableDescriptor.Columns[11].Width = 75;
                ggProject.TableDescriptor.Columns[11].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[12].HeaderText = "[ > 1095  ]";
                ggProject.TableDescriptor.Columns[12].Width = 75;
                ggProject.TableDescriptor.Columns[12].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[12].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[13].HeaderText = "Un Matched";
                ggProject.TableDescriptor.Columns[13].Width = 75;
                ggProject.TableDescriptor.Columns[13].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[13].Appearance.AnyCell.Format = "F2";

                ggProject.TableDescriptor.Columns[14].HeaderText = "Project Total";
                ggProject.TableDescriptor.Columns[14].Width = 100;
                ggProject.TableDescriptor.Columns[14].AllowGroupByColumn = false;
                ggProject.TableDescriptor.Columns[14].Appearance.AnyCell.Format = "F2";

                GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "BUCKET0", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "BUCKET1", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd2 = new GridSummaryColumnDescriptor("Sum2", SummaryType.DoubleAggregate, "BUCKET2", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd3 = new GridSummaryColumnDescriptor("Sum3", SummaryType.DoubleAggregate, "BUCKET3", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd4 = new GridSummaryColumnDescriptor("Sum4", SummaryType.DoubleAggregate, "BUCKET4", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd5 = new GridSummaryColumnDescriptor("Sum5", SummaryType.DoubleAggregate, "BUCKET5", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd6 = new GridSummaryColumnDescriptor("Sum6", SummaryType.DoubleAggregate, "BUCKET6", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd7 = new GridSummaryColumnDescriptor("Sum7", SummaryType.DoubleAggregate, "BUCKET7", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd8 = new GridSummaryColumnDescriptor("Sum8", SummaryType.DoubleAggregate, "UNMATCHED", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd9 = new GridSummaryColumnDescriptor("Sum9", SummaryType.DoubleAggregate, "ORGTOTAL", "{Sum:#.00}");

                scd0.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd0.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd1.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd1.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd2.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd2.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd3.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd3.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd4.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd4.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd5.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd5.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd6.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd6.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd7.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd7.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd8.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd8.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd9.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd9.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                GridSummaryRowDescriptor srd = new GridSummaryRowDescriptor("Sum", "Total", new GridSummaryColumnDescriptor[] { scd0, scd1, scd2, scd3, scd4, scd5, scd6, scd7, scd8, scd9 });
                srd.Appearance.AnyCell.Format = "F2";
                srd.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

                this.ggProject.TableDescriptor.SummaryRows.Add(srd);
                this.ggProject.TableDescriptor.Columns[5].AllowGroupByColumn = false;

                this.ggProject.TableDescriptor.Columns[2].AllowFilter = true;
                this.ggProject.TableDescriptor.Columns[4].AllowFilter = true;
            }



        }
 
        private void LoadConsolidated(DataTable _dt)
        {
            
            ggConsolidated.DataSource = _dt;

            if (_runCounterConsolidated == 0)
            {
                _runCounterConsolidated = _runCounterConsolidated + 1; 
                ggConsolidated.TableDescriptor.Columns[0].HeaderText = "ID";
                ggConsolidated.TableDescriptor.Columns[0].Width = 0;

                ggConsolidated.TableDescriptor.Columns[1].HeaderText = "SupplierID";
                ggConsolidated.TableDescriptor.Columns[1].Width = 0;

                ggConsolidated.TableDescriptor.Columns[2].HeaderText = "Vendor";
                ggConsolidated.TableDescriptor.Columns[2].Width = 225;
                ggConsolidated.TableDescriptor.Columns[2].AllowFilter = true;

                this.ggConsolidated.TableModel.Cols.FreezeRange(0, 2);

                ggConsolidated.TableDescriptor.Columns[3].HeaderText = "[ <= 30 ]";
                ggConsolidated.TableDescriptor.Columns[3].Width = 75;
                ggConsolidated.TableDescriptor.Columns[3].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "F2";


                ggConsolidated.TableDescriptor.Columns[4].HeaderText = "[31 - 60]";
                ggConsolidated.TableDescriptor.Columns[4].Width = 75;
                ggConsolidated.TableDescriptor.Columns[4].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "F2";


                ggConsolidated.TableDescriptor.Columns[5].HeaderText = "[61 - 90]";
                ggConsolidated.TableDescriptor.Columns[5].Width = 75;
                ggConsolidated.TableDescriptor.Columns[5].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[6].HeaderText = "[91 - 180]";
                ggConsolidated.TableDescriptor.Columns[6].Width = 75;
                ggConsolidated.TableDescriptor.Columns[6].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[7].HeaderText = "[181 - 365]";
                ggConsolidated.TableDescriptor.Columns[7].Width = 75;
                ggConsolidated.TableDescriptor.Columns[7].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[8].HeaderText = "[366 - 730]";
                ggConsolidated.TableDescriptor.Columns[8].Width = 75;
                ggConsolidated.TableDescriptor.Columns[8].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[9].HeaderText = "[731 - 1095]";
                ggConsolidated.TableDescriptor.Columns[9].Width = 75;
                ggConsolidated.TableDescriptor.Columns[9].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[10].HeaderText = "[ > 1095  ]";
                ggConsolidated.TableDescriptor.Columns[10].Width = 75;
                ggConsolidated.TableDescriptor.Columns[10].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[11].HeaderText = "Un Matched";
                ggConsolidated.TableDescriptor.Columns[11].Width = 75;
                ggConsolidated.TableDescriptor.Columns[11].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";

                ggConsolidated.TableDescriptor.Columns[12].HeaderText = "Vendor Total";
                ggConsolidated.TableDescriptor.Columns[12].Width = 100;
                ggConsolidated.TableDescriptor.Columns[12].AllowGroupByColumn = false;
                ggConsolidated.TableDescriptor.Columns[12].Appearance.AnyCell.Format = "F2";

                GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "BUCKET0", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "BUCKET1", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd2 = new GridSummaryColumnDescriptor("Sum2", SummaryType.DoubleAggregate, "BUCKET2", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd3 = new GridSummaryColumnDescriptor("Sum3", SummaryType.DoubleAggregate, "BUCKET3", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd4 = new GridSummaryColumnDescriptor("Sum4", SummaryType.DoubleAggregate, "BUCKET4", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd5 = new GridSummaryColumnDescriptor("Sum5", SummaryType.DoubleAggregate, "BUCKET5", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd6 = new GridSummaryColumnDescriptor("Sum6", SummaryType.DoubleAggregate, "BUCKET6", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd7 = new GridSummaryColumnDescriptor("Sum7", SummaryType.DoubleAggregate, "BUCKET7", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd8 = new GridSummaryColumnDescriptor("Sum8", SummaryType.DoubleAggregate, "UNMATCHED", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd9 = new GridSummaryColumnDescriptor("Sum9", SummaryType.DoubleAggregate, "SUPPTOTAL", "{Sum:#.00}");

                scd0.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd0.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd1.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd1.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd2.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd2.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd3.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd3.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd4.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd4.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd5.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd5.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd6.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd6.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd7.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd7.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd8.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd8.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                scd9.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                scd9.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                GridSummaryRowDescriptor srd = new GridSummaryRowDescriptor("Sum", "Total", new GridSummaryColumnDescriptor[] { scd0, scd1, scd2, scd3, scd4, scd5, scd6, scd7, scd8, scd9 });
                srd.Appearance.AnyCell.Format = "F2";
                srd.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

                this.ggConsolidated.TableDescriptor.SummaryRows.Add(srd);
                this.ggConsolidated.TableDescriptor.Columns[2].AllowFilter = true;

               

            }
        }

        private void txtSearchCreditor_TextChanged(object sender, EventArgs e)
        {

            int i;
            i = listCreditors.FindString(txtSearchCreditor.Text);
            if (i >= 0)
                listCreditors.SelectedItem = listCreditors.Items[i];
        }
          
        private void btnReset_Click(object sender, EventArgs e)
        {
            _resultSupplierWise.Rows.Clear();
            _resultProjectWise.Rows.Clear();
            _resultDetailed.Rows.Clear();
            DisableButtons(0);
            DisableGrid(0);
        }

    

       private void WriteToExcel()
        {
          DataSet _dsEx = new DataSet();
          _dsEx = _dsFinalResult;
    
          int _tableCount = 0;
          Int32 _recordCount = 0;
          int _totaRow = 0; 
          try
          {
            using (_dsEx)
            {
                if (_dsEx != null && _dsEx.Tables.Count > 0)
                {
                    using (ExcelPackage xp = new ExcelPackage())
                    {
                        foreach (DataTable dt in _dsEx.Tables)
                        {
                            _tableCount = _tableCount + 1; 
                            ExcelWorksheet ws = xp.Workbook.Worksheets.Add(dt.TableName);
                            _recordCount = Convert.ToInt32(dt.Rows.Count);
                            _totaRow = 8 + _recordCount; 
                            ws.Cells.Style.Font.Name = "Calibri";
                            ws.Cells.Style.Font.Size = 11;

                            int rowstart = 2;
                            int colstart = 2;
                            int rowend = rowstart;
                            int colend = colstart + dt.Columns.Count;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Size = 13;
                            ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Value = _Header1;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                            rowstart = 3;
                            rowend = 3; 
                            ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Size = 12;
                            ws.Cells[rowstart, colstart, rowend, colend].Value = _Header2;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                            rowstart = 4;
                            rowend = 4; 
                            ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Size = 11;
                            ws.Cells[rowstart, colstart, rowend, colend].Value = _Header3;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                            rowstart = 5;
                            rowend = 5; 
                            ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Size = 11;
                            ws.Cells[rowstart, colstart, rowend, colend].Value = dt.TableName;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                            rowstart += 2;
                            rowend = rowstart + dt.Rows.Count;
                            ws.Cells[rowstart, colstart].LoadFromDataTable(dt, true);
                            int i = 1;
                            foreach (DataColumn dc in dt.Columns)
                            {
                                i++;
                                if (dc.DataType == typeof(decimal))
                                    ws.Column(i).Style.Numberformat.Format = "#0.00";
                            }
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            rowstart = 7;
                            rowend = 7;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true; 
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);

                            switch (_tableCount)
                            {
                                case 1:
                                    ws.Cells[7, colstart, 7, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    ws.Column(9).Style.Numberformat.Format = "dd/MM/yyyy";
                                    ws.Column(9).Width = 13;
                                    break;

                                case 2:
                                    ws.Cells[7, colstart, 7, 6 ].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                                case 3:
                                    ws.Cells[7, colstart, 7, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                            }
                            
                          


                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            if (_tableCount == 1)
                            {
                                ws.Cells[_totaRow, 6].Value = "Total ... ";
                                ws.Cells[_totaRow, 10].Formula = "+SUM(J8:J" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 12].Formula = "+SUM(L8:L" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 13].Formula = "+SUM(M8:M" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 14].Formula = "+SUM(N8:N" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 15].Formula = "+SUM(O8:O" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 16].Formula = "+SUM(P8:P" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 17].Formula = "+SUM(Q8:Q" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 18].Formula = "+SUM(R8:R" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 19].Formula = "+SUM(S8:S" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 20].Formula = "+SUM(T8:T" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 21].Formula = "+SUM(U8:U" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 10, _totaRow, 10].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                ws.Cells[_totaRow, 12, _totaRow, 21].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Font.Bold = true;
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                            }
                            if (_tableCount == 2)
                            {
                                ws.Cells[_totaRow, 6].Value = "Total ... ";
                                ws.Cells[_totaRow, 7].Formula = "+SUM(G8:G" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 8].Formula = "+SUM(H8:H" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 9].Formula = "+SUM(I8:I" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 10].Formula = "+SUM(J8:J" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 11].Formula = "+SUM(K8:K" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 12].Formula = "+SUM(L8:L" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 13].Formula = "+SUM(M8:M" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 14].Formula = "+SUM(N8:N" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 15].Formula = "+SUM(O8:O" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 16].Formula = "+SUM(P8:P" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 2, _totaRow, 16].Style.Font.Bold = true;
                                ws.Cells[_totaRow, 2, _totaRow, 16].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow, 2, _totaRow, 16].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSeaGreen);
                            }
                            if (_tableCount == 3)
                            {
                                ws.Cells[_totaRow, 4].Value = "Total ... ";
                                ws.Cells[_totaRow, 5].Formula = "+SUM(E8:E" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 6].Formula = "+SUM(F8:F" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 7].Formula = "+SUM(G8:G" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 8].Formula = "+SUM(H8:H" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 9].Formula = "+SUM(I8:I" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 10].Formula = "+SUM(J8:J" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 11].Formula = "+SUM(K8:K" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 12].Formula = "+SUM(L8:L" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 13].Formula = "+SUM(M8:M" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 14].Formula = "+SUM(N8:N" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 2, _totaRow, 14].Style.Font.Bold = true;
                                ws.Cells[_totaRow, 2, _totaRow, 14].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow, 2, _totaRow, 14].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSalmon);
                            }

                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="";
                        switch (GlobalVariables.AgeOf) 
                        {
                            case 1:
                                _fileName = "CreditorAge";
                                break;
                            case 2:
                                _fileName = "SubContractorAge";
                                break;
                            case 3:
                                _fileName = "DebtorAge";
                                break;
                        }
                        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                        _fileName = _fileName + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
                        _ExcelFileName= _directoryName+ _fileName;
                        File.WriteAllBytes(_ExcelFileName, bin);
 
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    
       }
       private void btnExport_Click(object sender, EventArgs e)
        {
            WriteToExcel();
            OpenExcel();
        }

       private void OpenExcel()
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.Workbooks.Open(_ExcelFileName);

           
 

        }

       

       private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateResult();
        }


        private void GenerateResult()
        {
            DisableButtons(1);
            DoPreparatoryWorks();
            int _agedTo;
            int _periodAgeOn;
            int _finYear;
            int _agingOn;
            string  _debtorLedger;

            if (cmbAgedTo.Text == "LIVE")
                _agedTo = 1;
            else
                _agedTo = 2;

            if (cmbAgingOf.Text == "Transaction Date")
                _agingOn = 1;
            else
                _agingOn = 2;

            _debtorLedger =Convert.ToString(cmbDebtors.SelectedValue);

            if (cmbPeriods.Visible == false)
                _periodAgeOn = -1;
            else
                _periodAgeOn = Convert.ToInt16(cmbPeriods.SelectedValue.ToString());

            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue.ToString());

            _dsFinalResult = new DataSet();

            switch (GlobalVariables.AgeOf)
            {
                case 1:
                    _dsFinalResult = _cg.GetCreditorAge(_agedTo, _periodAgeOn, _finYear, _agingOn, _tableCreditors, _tableProjects);
                    _Header1 = "Capacite Infra Projects - Creditor Aging Report";
                    break;
                case 2:
                    _dsFinalResult = _cg.GetSubbieAge(2, _periodAgeOn, _finYear, 1, _tableCreditors, _tableProjects);
                    _Header1 = "Capacite Infra Projects - Sub Contractor Aging Report";
                    break;
                case 3:
                    _dsFinalResult = _cg.GetDebtorAge(_debtorLedger, _periodAgeOn, _finYear, _tableCreditors, _tableProjects);
                    _Header1 = "Capacite Infra Projects - Debtor (" + Convert.ToString(cmbDebtors.Text).Trim() + ")   Aging Report";
                    break;
            }

            if (_agingOn == 1)
            {
                _Header2 = "Based on Transaction Date                           To  Period : " + Convert.ToString(cmbPeriods.Text) +  "                              Fin Year : " + Convert.ToString(cmbFinYear.Text);
            }
            else
            {
                _Header2 = "Based on Invoice  Date                              To  Period : " + Convert.ToString(cmbPeriods.Text) +  "                              Fin Year : " + Convert.ToString(cmbFinYear.Text);
            }

            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 

            ReformatResultSet();

             
      
            DisableButtons(2);
        }

        private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Detail";
            _dsFinalResult.Tables[1].TableName = "ProjectWise";
            _dsFinalResult.Tables[2].TableName = "Consolidated";

            _dsFinalResult.Tables[0].Columns[0].Caption = "ID";
            _dsFinalResult.Tables[0].Columns[1].Caption = "Party Code";
            _dsFinalResult.Tables[0].Columns[2].Caption = "Vendor";
            _dsFinalResult.Tables[0].Columns[3].Caption = "BORGID";
            _dsFinalResult.Tables[0].Columns[4].Caption = "Project";
            _dsFinalResult.Tables[0].Columns[5].Caption = "Type";
            _dsFinalResult.Tables[0].Columns[6].Caption = "Invoice #";
            _dsFinalResult.Tables[0].Columns[7].Caption = "Inv. Date";
            _dsFinalResult.Tables[0].Columns[8].Caption = "Invoice Amount";
            _dsFinalResult.Tables[0].Columns[9].Caption = "Age";
            _dsFinalResult.Tables[0].Columns[10].Caption = "[ <= 30 ]";
            _dsFinalResult.Tables[0].Columns[11].Caption = "[31 - 60]";
            _dsFinalResult.Tables[0].Columns[12].Caption = "[61 - 90]";
            _dsFinalResult.Tables[0].Columns[13].Caption = "[91 - 180]";
            _dsFinalResult.Tables[0].Columns[14].Caption = "[181 - 365]";
            _dsFinalResult.Tables[0].Columns[15].Caption = "[366 - 730]";
            _dsFinalResult.Tables[0].Columns[16].Caption = "[731 - 1095]";
            _dsFinalResult.Tables[0].Columns[17].Caption = "[ > 1095  ]";
            _dsFinalResult.Tables[0].Columns[18].Caption = "Un Matched";
            _dsFinalResult.Tables[0].Columns[19].Caption = "LineTotal";
            _dsFinalResult.Tables[0].Columns[20].Caption = "Narration";

            _dsFinalResult.Tables[1].Columns[0].Caption = "No";
            _dsFinalResult.Tables[1].Columns[1].Caption = "SupplierID";
            _dsFinalResult.Tables[1].Columns[2].Caption = "Vendor";
            _dsFinalResult.Tables[1].Columns[3].Caption = "BORGID";
            _dsFinalResult.Tables[1].Columns[4].Caption = "Project";
            _dsFinalResult.Tables[1].Columns[5].Caption = "[ <= 30 ]";
            _dsFinalResult.Tables[1].Columns[6].Caption = "[31 - 60]";
            _dsFinalResult.Tables[1].Columns[7].Caption = "[61 - 90]";
            _dsFinalResult.Tables[1].Columns[8].Caption = "[91 - 180]";
            _dsFinalResult.Tables[1].Columns[9].Caption = "[181 - 365]";
            _dsFinalResult.Tables[1].Columns[10].Caption = "[366 - 730]";
            _dsFinalResult.Tables[1].Columns[11].Caption = "[731 - 1095]";
            _dsFinalResult.Tables[1].Columns[12].Caption = "[ > 1095  ]";
            _dsFinalResult.Tables[1].Columns[13].Caption = "Un Matched";
            _dsFinalResult.Tables[1].Columns[14].Caption = "Project Total";


            _dsFinalResult.Tables[2].Columns[0].Caption = "ID";
            _dsFinalResult.Tables[2].Columns[1].Caption = "Party Code";
            _dsFinalResult.Tables[2].Columns[2].Caption = "Name";
            _dsFinalResult.Tables[2].Columns[3].Caption = "[ <= 30 ]";
            _dsFinalResult.Tables[2].Columns[4].Caption = "[31 - 60]";
            _dsFinalResult.Tables[2].Columns[5].Caption = "[61 - 90]";
            _dsFinalResult.Tables[2].Columns[6].Caption = "[91 - 180]";
            _dsFinalResult.Tables[2].Columns[7].Caption = "[181 - 365]";
            _dsFinalResult.Tables[2].Columns[8].Caption = "[366 - 730]";
            _dsFinalResult.Tables[2].Columns[9].Caption = "[731 - 1095]";
            _dsFinalResult.Tables[2].Columns[10].Caption = "[ > 1095  ]";
            _dsFinalResult.Tables[2].Columns[11].Caption = "Un Matched";
            _dsFinalResult.Tables[2].Columns[12].Caption = "Party Total";







        }
        private void DisableButtons(int i)
        {
            switch (i)
            {
                case 1: 
                    btnGenerate.Visible = false;
                    btnClose.Visible = true;
                    btnExport.Visible = false;
                    gbView.Visible = false;
                    break;
                case 2: 
                    gbView.Visible = true;
                    btnExport.Visible = true;
                    btnReset.Visible = true;
                    break;
                case 0: 
                    btnReset.Visible = false;
                    ResetAllCreditorsChecked();
                    ResetAllBorgsChecked();
                    gbView.Visible = false;
                    btnExport.Visible = false;
                    btnGenerate.Visible = true;
                    break;
               default:
                    break;

            }
           
        }

        private void rdDetail_Click(object sender, EventArgs e)
        {
            _reportChoice = 1;
            LoadDetail(_dsFinalResult.Tables["Detail"]);
            DisableGrid(_reportChoice);
            ggDetail.Visible = true; 
        }

        private void rdProject_Click(object sender, EventArgs e)
        {
            _reportChoice = 2;
            LoadProject(_dsFinalResult.Tables["ProjectWise"]);
            DisableGrid(_reportChoice);
            ggProject.Visible = true; 
        }

        private void rdConsolidated_Click(object sender, EventArgs e)
        {
            _reportChoice = 3;
            LoadConsolidated(_dsFinalResult.Tables["Consolidated"]);
            DisableGrid(_reportChoice);
            ggConsolidated.Visible = true; 
        }

        private void DisableGrid(int i)
        {
            switch (i)
            {
                case 1:
                    ggDetail.Visible = true;
                    ggProject.Visible = false;
                    ggConsolidated.Visible = false;
                    break;
                case 2:
                    ggDetail.Visible = false;
                    ggProject.Visible = true;
                    ggConsolidated.Visible = false;
                    break;
                case 3:
                    ggDetail.Visible = false;
                    ggProject.Visible = false;
                    ggConsolidated.Visible = true;
                    break;
                case 0:
                    ggConsolidated.Visible = false;
                    ggProject.Visible = false;
                    ggDetail.Visible = false;
                    break;
            }
        }

        private void cmbDebtors_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listCreditors.Visible = false;
            string  _debtorLedgercode = Convert.ToString(cmbDebtors.SelectedValue);
            DataSet _dsDebtors = _cg.GetDebtorsInYear(_CurrentFinYear, _debtorLedgercode);
            _dtCreditors = _dsDebtors.Tables[0];
            listCreditors.Visible = false;
            listCreditors.Sorted = true;
            listCreditors.Items.Clear();
            for (int i = 0; i <= _dsDebtors.Tables[0].Rows.Count - 1; i++)
            {
                _selectedCreditors = Convert.ToString(_dsDebtors.Tables[0].Rows[i][1]);
                listCreditors.Items.Add(_selectedCreditors);
            }

            for (int i = 0; i < listCreditors.Items.Count; i++)
                listCreditors.SetItemChecked(i, true);
            listCreditors.Visible = true;
            chkUnChkCreditor.Checked = true;
        }

    }   
  }

