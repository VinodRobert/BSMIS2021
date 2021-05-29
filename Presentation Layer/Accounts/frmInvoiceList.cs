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
    public partial class frmInvoiceList : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
     
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
        DataSet dsLedgerCompleteList;
        DataTable dtLedgerCompleteList;

         
        string _selectedZones;
        string _selectedProjects;


        DataSet dsMasterItems = null;
        DataTable dtMasterItems;

        string _Header1;
        string _Header2;
        string _Header3;

        public frmInvoiceList()
        {
            InitializeComponent();
        }

        private void frmCreditorAge_Load(object sender, EventArgs e)
        {
            
            lblHeader.Text = "Invoice Listings";
            ActivateCurrentFinYear();
            ResetAll();
            LoadCombos();
          
            LoadListZone();
            LoadListProject();
        }

        public void ActivateCurrentFinYear()
        {
            
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
            cmbFinYear.ReadOnly = false;
        }

        public void ResetAll()
        {
            _tableCreditors.Columns.Add("CredNumber", typeof(string));
            _tableProjects.Columns.Add("BORGID", typeof(int));

           

          
            btnReset.Visible = false;
            btnExport.Visible = false;


            this.gridRegister.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridRegister.ShowGroupDropArea = true;
            this.gridRegister.TableOptions.AllowSortColumns = true;
            this.gridRegister.TopLevelGroupOptions.ShowCaption = true;
            this.gridRegister.TableOptions.RecordPreviewRowHeight = 55;
            this.gridRegister.TableOptions.ShowRowHeader = false;
            this.gridRegister.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridRegister.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridRegister.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridRegister.TableOptions.DefaultColumnWidth = 65;
            this.gridRegister.TableOptions.CaptionRowHeight = 22;
            this.gridRegister.InvalidateAllWhenListChanged = true;
            this.gridRegister.ForceDisposeOnResetDataSource = true;
            this.gridRegister.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridRegister.CacheRecordValues = false;
            this.gridRegister.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridRegister.Font = new Font("Calibri", 8.0f);
            this.gridRegister.TopLevelGroupOptions.ShowFilterBar = true;   

         
        }
        
        private void LoadCombos()
        {
            _ds = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;

            DataSet _dsPeriodFrom;
            DataSet _dsPeriodTo;
            DataSet _dsMasters;

            _dsPeriodFrom = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbPeriodsFrom, _dsPeriodFrom.Tables[0], "PERIODDESC", "PERIODID", 0);
            _dsPeriodTo = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbPeriodsTo, _dsPeriodTo.Tables[0], "PERIODDESC", "PERIODID", 0);
            _dsMasters = _cg.GetMasterItems();
            UtilityFunctions.LoadWindowsCombo(cmbMasters, _dsMasters.Tables[0], "CONTROLNAME", "CONTROLID", 0);
        }

      

     
        public DataSet GetFinancialYears()
        {
            string _query = "Select DISTINCT  [Year] FINYEAR, [Year] FINYEARID FROM TRANSACTIONS WHERE YEAR>=2015 ORDER BY YEAR";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.TableDirect, _query);
            return ds;
        }

        public void  GetAllLedgerCodeLedgerName()
        {
       //     string _query = "SELECT LEDGERCODE,UPPER(LEDGERNAME) LEDGERNAME FROM LEDGERCODES WHERE LEDGERSUMMARY=0 AND LEDGERALLOC IN ('Contracts') AND LEDGERSTATUS=0 AND LEDGERNAME<>'' ORDER BY LEDGERNAME  ";
            string _connectionString = SqlHelper.GetConnectionString();

            dsLedgerCompleteList = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BS.spFetchLedgersForOppositeLegs");
            dtLedgerCompleteList = dsLedgerCompleteList.Tables[0];

          //  UtilityFunctions.LoadWindowsCombo(cmbVendorCode, dtLedgerCompleteList, "LEDGERNAME", "LEDGERCODE", 0);
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

  

   

        private void ResetAllBorgsChecked()
        {
            for (int i = 0; i < listProject.Items.Count; i++)
            {
                listProject.SetItemChecked(i, true);
            }
            chkUnChkCreditor.Checked = true;
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

      

   
   

     
          
        private void btnReset_Click(object sender, EventArgs e)
        {
            _resultSupplierWise.Rows.Clear();
            _resultProjectWise.Rows.Clear();
            _resultDetailed.Rows.Clear();
            DisableButtons(0);
         
        }

        private void WriteToExcel()
        {
          DataSet _dsEx = new DataSet();
          _dsEx = _dsFinalResult;
          
          int _tableCount = 0;
          int _recordCount = 0;
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
                        
                            dt.TableName = " Ledger Report - Opposite Legs ";
                            _tableCount = _tableCount + 1; 
                            ExcelWorksheet ws = xp.Workbook.Worksheets.Add(dt.TableName);
                            _recordCount = Convert.ToInt16(dt.Rows.Count);
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
                            ws.Cells[7, 1, 7, 6].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            ws.Column(5).Style.Numberformat.Format = "dd/MM/yyyy";
                            ws.Column(5).Width = 13;
                            ws.Column(7).Style.Numberformat.Format = "dd/MM/yyyy";
                            ws.Column(7).Width = 13;


                            ws.Cells[7, 8, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        
                            ws.Cells[7, 8, rowend, colend].AutoFitColumns(20);
                          


                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            
                        
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="DebtorRegister";
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
            MessageBox.Show("Unnder Development - Please Hold On");
            return;
        //    GenerateResult();
        }


        private void GenerateResult()
        {

            

            //DisableButtons(1);
            //DoPreparatoryWorks();
           
            
            //int _finYear;
            //int _fromPeriod;
            //int _toPeriod;
            //int _partyType;
            //string _partyCode;
            //DataTable _dt;

            //_finYear = Convert.ToInt16(cmbFinYear.SelectedValue.ToString());
            //_fromPeriod = Convert.ToInt16(cmbPeriodsFrom.SelectedValue.ToString());
            //_toPeriod = Convert.ToInt16(cmbPeriodsTo.SelectedValue.ToString());
            //_partyCode = Convert.ToString(cmbVendorCode.SelectedValue).ToString();
            //_partyType = Convert.ToInt16(cmbMasters.SelectedValue);
            //_dsFinalResult = new DataSet();
            //_dt = new DataTable();
            //_dsFinalResult = _cg.LedgerWithOppositeLegsAllMasters(_finYear, _fromPeriod, _toPeriod, _tableProjects, _partyCode,_partyType);
            //_dt = _dsFinalResult.Tables[0];
            
            
            //_Header1 = "Capacite Infra Projects - Debtor Register";
            //_Header2 = "Financial Year " + _finYear.ToString() + " From  Period : " + Convert.ToString(cmbPeriodsFrom.Text) + " To Period : " + Convert.ToString(cmbPeriodsTo.Text);
            //DateTime time = DateTime.Now;
            //string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            //_Header3 = "Report Generated On " + Convert.ToString(time.ToString(format));

        


            //DisableButtons(2);
           
            //LoadDetail(_dt);
          
        }

 
 
   
 
 
   
 
  
   
  
 


        private void LoadDetail(DataTable _dt)
        {
            gridRegister.DataSource = _dt;


            gridRegister.TableDescriptor.Columns[0].HeaderText = "GROUP ID";
            gridRegister.TableDescriptor.Columns[0].Width = 80;
            gridRegister.TableDescriptor.Columns[0].AllowFilter = true;

         

            gridRegister.TableDescriptor.Columns[1].HeaderText = "Category";
            gridRegister.TableDescriptor.Columns[1].Width = 100;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = true;


            gridRegister.TableDescriptor.Columns[2].HeaderText = "Project";
            gridRegister.TableDescriptor.Columns[2].Width = 200;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;

            gridRegister.TableDescriptor.Columns[3].HeaderText = "Year";
            gridRegister.TableDescriptor.Columns[3].Width = 80;

            gridRegister.TableDescriptor.Columns[4].HeaderText = "Month";
            gridRegister.TableDescriptor.Columns[4].Width = 60;
            gridRegister.TableDescriptor.Columns[4].AllowFilter = true;

            gridRegister.TableDescriptor.Columns[5].HeaderText = "TransDate";
            gridRegister.TableDescriptor.Columns[5].Width = 65;
            gridRegister.TableDescriptor.Columns[5].Appearance.AnyCell.CellType = "Date";
            gridRegister.TableDescriptor.Columns[5].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[6].HeaderText = "BatchRef";
            gridRegister.TableDescriptor.Columns[6].Width = 50;
            gridRegister.TableDescriptor.Columns[6].AllowGroupByColumn = false;


            gridRegister.TableDescriptor.Columns[7].HeaderText = "TransRef";
            gridRegister.TableDescriptor.Columns[7].Width = 75;
            gridRegister.TableDescriptor.Columns[7].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[8].HeaderText = "Trans Type";
            gridRegister.TableDescriptor.Columns[8].Width = 75;
            gridRegister.TableDescriptor.Columns[8].AllowGroupByColumn = false;


            gridRegister.TableDescriptor.Columns[9].HeaderText = "Party Code";
            gridRegister.TableDescriptor.Columns[9].Width = 75;
            gridRegister.TableDescriptor.Columns[9].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[10].HeaderText = "Party";
            gridRegister.TableDescriptor.Columns[10].Width =125;
            gridRegister.TableDescriptor.Columns[10].AllowGroupByColumn = false;

            

            

           



            

        }

        private void DisableButtons(int i)
        {
            switch (i)
            {
                case 1: 
                    btnGenerate.Visible = false;
                    btnClose.Visible = true;
                    btnExport.Visible = false;
                
                    break;
                case 2: 
                 
                    btnExport.Visible = true;
                    btnReset.Visible = true;
                    break;
                case 0: 
                    btnReset.Visible = false;
                    ResetAllBorgsChecked();
             
                    btnExport.Visible = false;
                    btnGenerate.Visible = true;
                    break;
               default:
                    break;

            }
           
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            //string filter = Convert.ToString(txtFilterString.Text).Trim();
            //if (filter == "")
            //    filter = "1=1";
            //else
            //{
            //    filter = " PARTYNAME like '" + filter + "%'";
            //}
            //    dsMasterItems.Tables[0].DefaultView.RowFilter = filter;
            //    dtMasterItems = (dsMasterItems.Tables[0].DefaultView).ToTable();

            //UtilityFunctions.LoadWindowsCombo(cmbVendorCode, dtMasterItems, "PARTYNAME", "PARTYCODE", 0);

        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            //int masterID = Convert.ToInt16(cmbMasters.SelectedValue);
            //dsMasterItems =null;
            //dtMasterItems =null;
            //if (masterID == 10)
            //    dsMasterItems = _cg.GetCreditorsNameOnly();
            //if (masterID == 13)
            //    dsMasterItems = _cg.GetSubbieeNameOnly();
            //if (masterID == 11)
            //    dsMasterItems = _cg.GetDebtorsNameOnly();
            //dtMasterItems = dsMasterItems.Tables[0];
            //UtilityFunctions.LoadWindowsCombo(cmbVendorCode, dtMasterItems, "PARTYNAME", "PARTYCODE", 0);
        }
    }   
  }

