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
    public partial class frmDumps : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
 
        string _ExcelFileName;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

       
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();

        DataTable _dtLedgers = new DataTable();
        DataTable _tableLedgers = new DataTable();
        DataTable _tableProjects = new DataTable();

        DataTable _resultDetailed = new DataTable();
        DataTable _resultProjectWise = new DataTable();
        DataTable _resultSupplierWise = new DataTable();

        DataSet _dsFinalResult;

        DataTable dtLedgerByMoreSelection = new DataTable();
        
        string _selectedLedgers;
        string _selectedZones;
        string _selectedProjects;

        DateTime _dtMinDate;
        DateTime _dtMaxDate; 

 
        
      


        string _Header1;
        string _Header2;
        string _Header3;

        public frmDumps()
        {
            InitializeComponent();
        }

        private void frmCreditorAge_Load(object sender, EventArgs e)
        {

            lblHeader.Text = "Transaction/Ledger Dumps";

            ActivateCurrentFinYear();
            LoadCombos();
            GetDateLimits();
            Reset_Dates();
            LoadRadioButtons();
            ResetAll();

            LoadListLedgerIDs();
            LoadListZone();
            LoadListProject();

        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
        }

        private void LoadRadioButtons()
        {
            rdDateRange.Checked = false;
            rdPeriod.Checked = true;
            rdLedger.Checked = true;
            rdTransaction.Checked = false; 
        }

        private void LoadCombos()
        {
            DataSet _ds1;
            DataSet _ds2;
           
            DataSet _ds4; 

            _ds1 = _cg.GetActiveFinancialYears(_CurrentFinYear);
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;


            _ds2 = _cg.GetFullPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);

            _ds4 = _cg.GetFullPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod,_ds4.Tables[0], "PERIODDESC", "PERIODID", 0);

        }

        public void GetDateLimits()
        {
            _ds = _cg.GetDateLimits(_CurrentFinYear);
            _dtMinDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["STARTDATE"]);
            _dtMaxDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["ENDDATE"]);
           
        }

        private void cmbFinYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public void Reset_Dates()
        {
            dtFromDate.MinDate = _dtMinDate;
            dtFromDate.MaxDate = _dtMaxDate;
            dtFromDate.Value = _dtMinDate;


            dtToDate.MinDate = _dtMinDate;
            dtToDate.MaxDate = _dtMaxDate;
            dtToDate.Value = _dtMaxDate;
          
         
        }

        public void ResetAll()
        {

            DataColumn dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.String");
            dc1.ColumnName = "Ledgercode";
            dc1.MaxLength = 15;
            DataColumn dc2 = new DataColumn();
            dc2.DataType = System.Type.GetType("System.String");
            dc2.ColumnName = "LedgerName";
            dc1.MaxLength = 150;
            dtLedgerByMoreSelection.Columns.Add(dc1);
            dtLedgerByMoreSelection.Columns.Add(dc2);

            panelMoreSelectionCriteria.Visible = false;
            Reset_Dates();

            lblDate.Visible = false;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;

            cmbToPeriod.Visible = false; 
            _tableLedgers.Columns.Add("LedgerID", typeof(int));
            _tableProjects.Columns.Add("BORGID", typeof(int));

            

            txtSearchCreditor.ForeColor = Color.Red;

            ggDetail.Visible = false;
           

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

            this.gridLedgerSelection.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridLedgerSelection.ShowGroupDropArea = false;
            this.gridLedgerSelection.TableOptions.AllowSortColumns = true;
            this.gridLedgerSelection.TopLevelGroupOptions.ShowCaption = true;
            this.gridLedgerSelection.TableOptions.RecordPreviewRowHeight = 55;
            this.gridLedgerSelection.TableOptions.ShowRowHeader = false;
            this.gridLedgerSelection.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridLedgerSelection.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridLedgerSelection.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridLedgerSelection.TableOptions.DefaultColumnWidth = 65;
            this.gridLedgerSelection.TableOptions.CaptionRowHeight = 22;
            this.gridLedgerSelection.InvalidateAllWhenListChanged = true;
            this.gridLedgerSelection.ForceDisposeOnResetDataSource = true;
            this.gridLedgerSelection.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridLedgerSelection.CacheRecordValues = false;
            this.gridLedgerSelection.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridLedgerSelection.Font = new Font("Calibri", 8.0f);
            this.gridLedgerSelection.TopLevelGroupOptions.ShowFilterBar = false;
         
            btnReset.Visible = false;
            btnExport.Visible = false;

           

          
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

        private void LoadListLedgerIDs()
        {
            SqlParameter[] arParms = new SqlParameter[1];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = Convert.ToInt16(_CurrentFinYear);
            // Execute the stored procedure
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet _ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetLedgerIDs", arParms);
            DataSet _ds0 = _ds.Copy();
            DataSet _ds1 = _ds.Copy();
            UtilityFunctions.LoadWindowsCombo(cmbFromLedgerCode, _ds0.Tables[0], "LEDGERNAME", "LEDGERCODE", 1);
            UtilityFunctions.LoadWindowsCombo(cmbToLedgerCode, _ds1.Tables[0], "LEDGERNAME", "LEDGERCODE", 1);

        
            _dtLedgers = _ds.Tables[0];

            listLedgers.Sorted = true;

            for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
            {
                _selectedLedgers = Convert.ToString(_ds.Tables[0].Rows[i][1]);
                listLedgers.Items.Add(_selectedLedgers);
            }

            for (int i = 0; i < listLedgers.Items.Count; i++)
                listLedgers.SetItemChecked(i, true);

            chkUnChkCreditor.Checked = true;
        }

   

        private void ResetAllCreditorsChecked()
        {
            for (int i = 0; i < listLedgers.Items.Count; i++)
            {
                listLedgers.SetItemChecked(i, true);
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
                for (int i = 0; i < listLedgers.Items.Count; i++)
                {
                    listLedgers.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listLedgers.Items.Count; i++)
                {
                    listLedgers.SetItemChecked(i, false);
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


        private void DoPreparatoryWorks()
        {
            if (rdTransaction.Checked == true)
            {
                ReplicateLedgerTable();
            }
            else
            {
                GeneateLedgerTable();
            }

            AppendFromMoreSelection();

            GeneateOrgTable();

        }

        private void ReplicateLedgerTable()
        {
            int i;
            _tableLedgers.Rows.Clear();
            for (i = 0; i <= (listLedgers.Items.Count - 1); i++)
            {
               
                _tableLedgers.Rows.Add(Convert.ToString(_dtLedgers.Rows[i][2]));
            }
        }

        private void GeneateLedgerTable()
        {
            int i;
            string _searchString;
            _tableLedgers.Rows.Clear();
            for (i = 0; i <= (listLedgers.Items.Count - 1); i++)
            {
                if (listLedgers.GetItemChecked(i))
                {
                    _searchString = "LedgerName LIKE '" + listLedgers.Items[i].ToString().Trim() + "%'";
                    DataRow[] result = _dtLedgers.Select(_searchString);
                    if (result.Length > 0)
                    {
                        _tableLedgers.Rows.Add(Convert.ToString(result[0][2]));
                    }
                }
            }
        }

        private void AppendFromMoreSelection()
        {
            int ledgerID;
            for (int i = 0; i <= dtLedgerByMoreSelection.Rows.Count - 1; i++)
            {
                ledgerID =Convert.ToInt16( dtLedgerByMoreSelection.Rows[i][0] );
                _tableLedgers.Rows.Add(ledgerID);
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

     
   
     

        private void txtSearchCreditor_TextChanged(object sender, EventArgs e)
        {

            int i;
            i = listLedgers.FindString(txtSearchCreditor.Text);
            if (i >= 0)
                listLedgers.SelectedItem = listLedgers.Items[i];
        }
          
        private void btnReset_Click(object sender, EventArgs e)
        {
            _resultSupplierWise.Rows.Clear();
            _resultProjectWise.Rows.Clear();
            _resultDetailed.Rows.Clear();
            DisableButtons(2);
       
        }

    

       private void WriteToExcel()
        {
          DataSet _dsEx = new DataSet();
          _dsEx = _dsFinalResult;
    
          int _tableCount = 0;
          Int32 _recordCount = 0;
          Int32 _totaRow = 0; 
      
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

                            Int32 rowstart = 2;
                            int colstart = 2;
                            Int32 rowend = rowstart;
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
                            ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true; 
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightSteelBlue);

                            ws.Cells[7, colstart, 7, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            ws.Column(7).Style.Numberformat.Format = "dd/MM/yyyy";
                            ws.Column(7).Width = 13;
                            ws.Column(16).Width = 100;

                            ws.Column(18).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            ws.Column(19).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            ws.Cells[_totaRow, 16].Value = "Total ... ";
                            ws.Cells[_totaRow, 18].Formula = "+SUM(R8:R" + (_recordCount + 7) + ")";
                            ws.Cells[_totaRow, 19].Formula = "+SUM(R8:R" + (_recordCount + 7) + ")";
                            ws.Cells[_totaRow, 18, _totaRow, 19].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                       
                            ws.Cells[_totaRow, 2, _totaRow, 21].Style.Font.Bold = true;
                            ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="";
                        if (rdTransaction.Checked == true)
                            _fileName = "TransactionDump";
                        else
                            _fileName = "LedgerDump";

                 
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

            int _year;
            int _rangeID;
            int _fromPeriod;
            int _toPeriod;
            string _startDate;
            string _endDate;

            _year = _CurrentFinYear;
            if (rdDateRange.Checked == true)
            {
                _rangeID = 2;
                _startDate = Convert.ToString(dtFromDate.Value);
                _endDate = Convert.ToString(dtToDate.Value);
                _fromPeriod = 0;
                _toPeriod = 0; 
            }
            else
            {
                _rangeID = 1;
                _startDate = Convert.ToString(DateTime.Now);
                _endDate = Convert.ToString(DateTime.Now);
                _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
                _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue); 
            }

            _dsFinalResult = new DataSet();

            _dsFinalResult = _cg.LedgerDump(_year, _rangeID, _fromPeriod, _toPeriod, _startDate, _endDate, _tableLedgers, _tableProjects);
            _Header1 = "Capacite Infra Projects - Ledger Dump";

            if (_rangeID == 1)
            {
                _Header2 = "Ranage :  For Period - "+  Convert.ToString(cmbFromPeriod.Text) +"          Fin Year : " + Convert.ToString(_CurrentFinYear);
            }
            else
            {
                _Header2 = "Based on Transaction Date - Fromn Date : " + Convert.ToString(dtFromDate.Value) + "  To Date : " + Convert.ToString(dtToDate.Value) + "           Fin Year : " + Convert.ToString(_CurrentFinYear);
            }

            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 

            ReformatResultSet();
         
            LoadDetail(_dsFinalResult.Tables[0]);
             
      
            
        }

        private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Dump";


            _dsFinalResult.Tables[0].Columns[0].Caption = "OrgID";
            _dsFinalResult.Tables[0].Columns[1].Caption = "Org Name";
            _dsFinalResult.Tables[0].Columns[2].Caption = "Year";
            _dsFinalResult.Tables[0].Columns[3].Caption = "Period";
            _dsFinalResult.Tables[0].Columns[4].Caption = "Month";
            _dsFinalResult.Tables[0].Columns[5].Caption = "TransDate";
            _dsFinalResult.Tables[0].Columns[6].Caption = "BatchRef";
            _dsFinalResult.Tables[0].Columns[7].Caption = "TransRef";
            _dsFinalResult.Tables[0].Columns[8].Caption = "TransType";
            _dsFinalResult.Tables[0].Columns[9].Caption = "LedgerCode";
            _dsFinalResult.Tables[0].Columns[10].Caption = "LedgerName";
            _dsFinalResult.Tables[0].Columns[11].Caption = "Allocation";
            _dsFinalResult.Tables[0].Columns[12].Caption = "Contract";
            _dsFinalResult.Tables[0].Columns[13].Caption = "Activity Name";
            _dsFinalResult.Tables[0].Columns[14].Caption = "Description";
            _dsFinalResult.Tables[0].Columns[15].Caption = "Currency";
            _dsFinalResult.Tables[0].Columns[16].Caption = "Debit";
            _dsFinalResult.Tables[0].Columns[17].Caption = "Credit";
            _dsFinalResult.Tables[0].Columns[18].Caption = "Party Code";
            _dsFinalResult.Tables[0].Columns[19].Caption = "Party";
            _dsFinalResult.Tables[0].Columns[20].Caption = "Store";
            _dsFinalResult.Tables[0].Columns[21].Caption = "PlantNo";
            _dsFinalResult.Tables[0].Columns[22].Caption = "Plant";
            _dsFinalResult.Tables[0].Columns[23].Caption = "StockNo";
            _dsFinalResult.Tables[0].Columns[24].Caption = "Stock Name";
            _dsFinalResult.Tables[0].Columns[25].Caption = "Quantity";
            _dsFinalResult.Tables[0].Columns[26].Caption = "Unit";
            _dsFinalResult.Tables[0].Columns[27].Caption = "Rate";
            _dsFinalResult.Tables[0].Columns[28].Caption = "Order Number";
            _dsFinalResult.Tables[0].Columns[29].Caption = "Home Currency";
            _dsFinalResult.Tables[0].Columns[30].Caption = "Convertion";
            _dsFinalResult.Tables[0].Columns[31].Caption = "TransGRP";
            _dsFinalResult.Tables[0].Columns[32].Caption = "TransID";
            _dsFinalResult.Tables[0].Columns[33].Caption = "GRN";








        }

        private void LoadLedgerSelection(DataTable _dt)
        {
            gridLedgerSelection.DataSource = _dt;
            gridLedgerSelection.Visible = true;
            gridLedgerSelection.TableDescriptor.Columns[0].HeaderText = "Ledger Code";
            gridLedgerSelection.TableDescriptor.Columns[0].Width = 0;
            gridLedgerSelection.TableDescriptor.Columns[0].AllowFilter = true;

            gridLedgerSelection.TableDescriptor.Columns[1].HeaderText = "Ledger Name";
            gridLedgerSelection.TableDescriptor.Columns[1].Width = 350;
            gridLedgerSelection.TableDescriptor.Columns[1].AllowFilter = true;
        }


        private void LoadDetail(DataTable _dt)
        {

            ggDetail.DataSource = _dt;
            ggDetail.Visible = true;
            ggDetail.TableDescriptor.Columns[0].HeaderText = "Org ID";
            ggDetail.TableDescriptor.Columns[0].Width = 50;
            ggDetail.TableDescriptor.Columns[0].AllowFilter = true;

            ggDetail.TableDescriptor.Columns[1].HeaderText = "Project";
            ggDetail.TableDescriptor.Columns[1].Width = 150;
            ggDetail.TableDescriptor.Columns[1].AllowFilter = true;
            this.ggDetail.TableModel.Cols.FreezeRange(0, 1);

            ggDetail.TableDescriptor.Columns[2].HeaderText = "Year";
            ggDetail.TableDescriptor.Columns[2].Width = 30;
            ggDetail.TableDescriptor.Columns[2].AllowFilter = false;

            ggDetail.TableDescriptor.Columns[3].HeaderText = "Period";
            ggDetail.TableDescriptor.Columns[3].Width = 50;
            ggDetail.TableDescriptor.Columns[3].AllowFilter = false;

            ggDetail.TableDescriptor.Columns[4].HeaderText = "Month";
            ggDetail.TableDescriptor.Columns[4].Width = 60;
            ggDetail.TableDescriptor.Columns[4].AllowFilter = false;
         
            ggDetail.TableDescriptor.Columns[5].HeaderText = "TransDate";
            ggDetail.TableDescriptor.Columns[5].Width = 75;
            ggDetail.TableDescriptor.Columns[5].Appearance.AnyCell.CellType = "Date";
            ggDetail.TableDescriptor.Columns[5].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[6].HeaderText = "BatchRef";
            ggDetail.TableDescriptor.Columns[6].Width = 75;
            ggDetail.TableDescriptor.Columns[6].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[7].HeaderText = "TransRef";
            ggDetail.TableDescriptor.Columns[7].Width = 75;
            ggDetail.TableDescriptor.Columns[7].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[8].HeaderText = "TransType";
            ggDetail.TableDescriptor.Columns[8].Width = 65;
            ggDetail.TableDescriptor.Columns[8].AllowGroupByColumn = true;

          

            ggDetail.TableDescriptor.Columns[9].HeaderText = "Ledger Code";
            ggDetail.TableDescriptor.Columns[9].Width = 70;
            ggDetail.TableDescriptor.Columns[9].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";


            ggDetail.TableDescriptor.Columns[10].HeaderText = "Ledger Name";
            ggDetail.TableDescriptor.Columns[10].Width =180;
            ggDetail.TableDescriptor.Columns[10].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[11].HeaderText = "Allocation";
            ggDetail.TableDescriptor.Columns[11].Width = 80;
            ggDetail.TableDescriptor.Columns[11].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[12].HeaderText = "Contract";
            ggDetail.TableDescriptor.Columns[12].Width = 90;
            ggDetail.TableDescriptor.Columns[12].AllowGroupByColumn = false;
 

            ggDetail.TableDescriptor.Columns[13].HeaderText = "Activity";
            ggDetail.TableDescriptor.Columns[13].Width = 90;
            ggDetail.TableDescriptor.Columns[13].AllowGroupByColumn = false;
       

            ggDetail.TableDescriptor.Columns[14].HeaderText = "Description";
            ggDetail.TableDescriptor.Columns[14].Width = 300;
            ggDetail.TableDescriptor.Columns[14].AllowGroupByColumn = false;
 

            ggDetail.TableDescriptor.Columns[15].HeaderText = "Currency";
            ggDetail.TableDescriptor.Columns[15].Width = 50;
            ggDetail.TableDescriptor.Columns[15].AllowGroupByColumn = false;
 

            ggDetail.TableDescriptor.Columns[16].HeaderText = "Debit";
            ggDetail.TableDescriptor.Columns[16].Width = 90;
            ggDetail.TableDescriptor.Columns[16].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[17].HeaderText = "Credit";
            ggDetail.TableDescriptor.Columns[17].Width = 90;
            ggDetail.TableDescriptor.Columns[17].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[17].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[18].HeaderText = "Vendor ";
            ggDetail.TableDescriptor.Columns[18].Width = 70;
            ggDetail.TableDescriptor.Columns[18].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[18].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[19].HeaderText = "Vendor Name";
            ggDetail.TableDescriptor.Columns[19].Width = 200;
            ggDetail.TableDescriptor.Columns[19].AllowGroupByColumn = false;
      

            ggDetail.TableDescriptor.Columns[20].HeaderText = "Store";
            ggDetail.TableDescriptor.Columns[20].Width = 70;
            ggDetail.TableDescriptor.Columns[20].AllowGroupByColumn = false;


            ggDetail.TableDescriptor.Columns[21].HeaderText = "PlantCode";
            ggDetail.TableDescriptor.Columns[21].Width = 70;
            ggDetail.TableDescriptor.Columns[21].AllowGroupByColumn = false;
         

            ggDetail.TableDescriptor.Columns[22].HeaderText = "Plant";
            ggDetail.TableDescriptor.Columns[22].Width = 70;
            ggDetail.TableDescriptor.Columns[22].AllowGroupByColumn = false;


            ggDetail.TableDescriptor.Columns[23].HeaderText = "StockCode ";
            ggDetail.TableDescriptor.Columns[23].Width = 70;
            ggDetail.TableDescriptor.Columns[23].AllowGroupByColumn = false;
 

            ggDetail.TableDescriptor.Columns[24].HeaderText = "Stock Name";
            ggDetail.TableDescriptor.Columns[24].Width = 200;
            ggDetail.TableDescriptor.Columns[24].AllowGroupByColumn = false;
            

            ggDetail.TableDescriptor.Columns[25].HeaderText = "Qty";
            ggDetail.TableDescriptor.Columns[25].Width = 80;
            ggDetail.TableDescriptor.Columns[25].AllowGroupByColumn = false;


            ggDetail.TableDescriptor.Columns[26].HeaderText = "Unit";
            ggDetail.TableDescriptor.Columns[26].Width = 70;
            ggDetail.TableDescriptor.Columns[26].AllowGroupByColumn = false;
          //  ggDetail.TableDescriptor.Columns[17].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[27].HeaderText = "Rate ";
            ggDetail.TableDescriptor.Columns[27].Width = 80;
            ggDetail.TableDescriptor.Columns[27].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[27].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[28].HeaderText = "Order #";
            ggDetail.TableDescriptor.Columns[28].Width = 200;
            ggDetail.TableDescriptor.Columns[28].AllowGroupByColumn = false;
    

            ggDetail.TableDescriptor.Columns[29].HeaderText = "Home Currency";
            ggDetail.TableDescriptor.Columns[29].Width = 100;
            ggDetail.TableDescriptor.Columns[29].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[29].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[30].HeaderText = "Conv.Rate ";
            ggDetail.TableDescriptor.Columns[30].Width = 80;
            ggDetail.TableDescriptor.Columns[30].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[30].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[31].HeaderText = "TransGRP";
            ggDetail.TableDescriptor.Columns[31].Width = 50;
            ggDetail.TableDescriptor.Columns[31].AllowGroupByColumn = true;

            ggDetail.TableDescriptor.Columns[32].HeaderText = "TransID";
            ggDetail.TableDescriptor.Columns[32].Width = 50;
            ggDetail.TableDescriptor.Columns[32].AllowGroupByColumn = true;


            ggDetail.TableDescriptor.Columns[33].HeaderText = "GRN";
            ggDetail.TableDescriptor.Columns[33].Width = 50;
            ggDetail.TableDescriptor.Columns[33].AllowGroupByColumn = false;

        }

        private void DisableButtons(int i)
        {
            if (i == 1)
            {
                pbar.Minimum = 1;
                pbar.Maximum = 100;
                pbar.Value = 2;
                pbar.Visible = true; 
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = true;
                btnReset.Visible = true;
            }

           if (i == 0)
            {
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = true;
                pbar.Visible = false; 
            }

           if (i == 2)
           {
               btnGenerate.Visible = true;
               ggDetail.Visible = false;
               btnClose.Visible = true;
               btnExport.Visible = false;
               btnReset.Visible = false;
           }
        }

        private void cmbFinYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _CurrentFinYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            GetDateLimits();
            Reset_Dates();
        }

        private void rdDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDateRange.Checked == true)
            {
                lblDate.Visible = true;
                dtFromDate.Visible = true;
                dtToDate.Visible = true;
            }
            else
            {
                lblDate.Visible = false;
                dtFromDate.Visible = false;
                dtToDate.Visible = false;
            }
        }

        private void rdPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPeriod.Checked == true)
            {
                lblPeriodFrom.Visible = true;
                cmbFromPeriod.Visible = true;
          
            }
            else
            {
                lblPeriodFrom.Visible = false;
                cmbFromPeriod.Visible = false;

             
                cmbToPeriod.Visible = true;

            }
        }

        private void rdTransaction_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTransaction.Checked == true)
            {
                lblSearch.Enabled = false;
                chkUnChkCreditor.Enabled = false;
                txtSearchCreditor.Enabled = false;
                listLedgers.Enabled = false;
            }
            else
            {
                lblSearch.Enabled = true;
                chkUnChkCreditor.Enabled = true;
                txtSearchCreditor.Enabled = true;
                listLedgers.Enabled = true;
            }
        }

        private void rdLedger_CheckedChanged(object sender, EventArgs e)
        {
            if (rdLedger.Checked == true)
            {
                lblSearch.Enabled = true;
                chkUnChkCreditor.Enabled = true;
                txtSearchCreditor.Enabled = true;
                listLedgers.Enabled = true;
                lblPeriodFrom.Text = "Select Period";
                cmbToPeriod.Enabled = true;
                cmbToPeriod.Visible = true; 
            }
            else
            {
                lblSearch.Enabled = false;
                chkUnChkCreditor.Enabled = false;
                txtSearchCreditor.Enabled = false;
                listLedgers.Enabled = false;
                lblPeriodFrom.Text = "For Period";
                cmbToPeriod.Enabled = false; 
            }
        }



        private void chkMoreSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMoreSelection.Checked == true)
            {
                panelMoreSelectionCriteria.Visible = true;
                txtLedgerCodesCommaSeperated.Text = "";
                dtLedgerByMoreSelection.Clear();
            }
            else
            {
                panelMoreSelectionCriteria.Visible = false;
            }
        }

        

        private void btnCloseMore_Click(object sender, EventArgs e)
        {
            panelMoreSelectionCriteria.Visible = false;
            chkMoreSelection.Checked = false;
        }

        private void btnAddRange_Click(object sender, EventArgs e)
        {
            string startLedgercode = Convert.ToString(cmbFromLedgerCode.SelectedValue);
            string endLedgercode = Convert.ToString(cmbToLedgerCode.SelectedValue);
            string sql = "Select LedgerID,LedgerName from LedgerCodes where ledgersummary=0 and  Ledgercode between '" + Convert.ToString(startLedgercode) + "' AND '" + Convert.ToString(endLedgercode) + "'";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql);
         

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRow dr = dtLedgerByMoreSelection.NewRow();

                dr[0] = Convert.ToString(ds.Tables[0].Rows[i][0]);
                dr[1] = Convert.ToString(ds.Tables[0].Rows[i][1]);
                dtLedgerByMoreSelection.Rows.Add(dr);
            }


            LoadLedgerSelection(dtLedgerByMoreSelection);
            
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            string ledgerCodeList = txtLedgerCodesCommaSeperated.Text.Trim();
            string _connectionString = SqlHelper.GetConnectionString();
            string[] ledgerCodeListArray = new string[100];
            string ledgercode;
            if (ledgerCodeList.Length !=0 )
            {
                 ledgerCodeListArray = ledgerCodeList.Split(',');

            }

            for (int i=0; i <= ledgerCodeListArray.Length-1; i++)
            {
                ledgercode = Convert.ToString(ledgerCodeListArray[i]);
                string sql = "Select LedgerID,LedgerName from LedgerCodes where LedgerSummary =0 AND  Ledgercode= '" + Convert.ToString(ledgercode) + "'";
                DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dtLedgerByMoreSelection.NewRow();

                    dr[0] = Convert.ToString(ds.Tables[0].Rows[0][0]);
                    dr[1] = Convert.ToString(ds.Tables[0].Rows[0][1]);
                    dtLedgerByMoreSelection.Rows.Add(dr);
                }
            }
            LoadLedgerSelection(dtLedgerByMoreSelection);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLedgerCodesCommaSeperated.Text = "";
            dtLedgerByMoreSelection.Clear();
            gridLedgerSelection.DataSource = null;
            gridLedgerSelection.Refresh();
        }

        


       


}

       
 
  }

