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
    public partial class frmWHT : Form
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
 

        
        string _selectedZones;
        string _selectedProjects;

        DateTime _dtMinDate;
        DateTime _dtMaxDate; 

       


        string _Header1;
        string _Header2;
        string _Header3;

        public frmWHT()
        {
            InitializeComponent();
        }

        private void frmCreditorAge_Load(object sender, EventArgs e)
        {

            lblHeader.Text = "WHT Report";

            ActivateCurrentFinYear();
            LoadCombos();
            GetDateLimits();
          
          
            ResetAll();

           
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

       

        private void LoadCombos()
        {
            DataSet _ds1;
            DataSet _ds2;
            DataSet _ds3;

            _ds1 = _cg.GetActiveFinancialYears(_CurrentFinYear);
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;

      
            _ds2 = _cg.GetFullPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);

            _ds3 = _cg.GetFullPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _ds3.Tables[0], "PERIODDESC", "PERIODID", 0);

            

        }

        public void GetDateLimits()
        {
            _ds = _cg.GetDateLimits(_CurrentFinYear);
            _dtMinDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["STARTDATE"]);
            _dtMaxDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["ENDDATE"]);
           
        }

       

        public void ResetAll()
        {
          
            _tableProjects.Columns.Add("BORGID", typeof(int));
 

            ggDetail.Visible = false;
           

            this.ggDetail.ActivateCurrentCellBehavior = GridCellActivateAction.None;
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
            //this.ggDetail.TopLevelGroupOptions.ShowFilterBar = true;   

         
         
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
            if (sCount == 5)
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
            ggDetail.Visible = false;
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

                         

                            ws.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                       

                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";

                        string _fileName="";
                        
                        _fileName = "WHT";
                         

                 
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
          
            int _fromPeriod;
            int _toPeriod;
            int _maxColumns;
            int _maxRows;

           
            _year = _CurrentFinYear;
           
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
            
            _dsFinalResult = new DataSet();

            _dsFinalResult = _cg.WHT(_year, 1 , _fromPeriod, _toPeriod, _tableProjects);

            _maxColumns = _dsFinalResult.Tables[0].Columns.Count - 1;
            _maxRows = _dsFinalResult.Tables[0].Rows.Count - 1;

            //_dsFinalResult.Tables[0].Columns[_maxColumns].Caption = "Total";
            //_dsFinalResult.Tables[0].Rows[_maxRows][0] = "Total";
            _dsFinalResult.AcceptChanges();


            _Header1 = "Capacite Infra Projects - Cross Tab";

            
            _Header1 = _Header1 + " WHT ";
             



            
            _Header2 = "Ranage :  For Period - "+  Convert.ToString(cmbFromPeriod.Text) +" To Period - "+  Convert.ToString(cmbToPeriod.Text)+"          Fin Year : " + Convert.ToString(_CurrentFinYear);
            

            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 

            ReformatResultSet();
         
            LoadDetail(_dsFinalResult.Tables[0]);
             
      
          //  DisableButtons(2);
        }

        private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Cross Tab";
         

        }

        private void DisableButtons(int i)
        {
            if (i == 1)
            {
               
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = true;
                btnReset.Visible = true; 
            }
            else
            {
                btnGenerate.Visible = true;
                btnExport.Visible = false;
                 
            }

        }


         

       
        private void cmbFinYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _CurrentFinYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            GetDateLimits();
           
        }

        private void LoadDetail(DataTable _dt)
        {
            ggDetail.DataSource = _dt;

            ggDetail.TableDescriptor.Columns[0].HeaderText = "BORGID";
            ggDetail.TableDescriptor.Columns[0].Width = 60;
            ggDetail.TableDescriptor.Columns[0].AllowFilter = true;
            ggDetail.TableDescriptor.Columns[0].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[1].HeaderText = "Project";
            ggDetail.TableDescriptor.Columns[1].Width = 150;
            ggDetail.TableDescriptor.Columns[1].AllowFilter = false;
            ggDetail.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            ggDetail.TableDescriptor.Columns[2].HeaderText = "PERIOD";
            ggDetail.TableDescriptor.Columns[2].Width = 60;
            ggDetail.TableDescriptor.Columns[2].AllowFilter = true;
        

            ggDetail.TableDescriptor.Columns[3].HeaderText = "WHT Section";
            ggDetail.TableDescriptor.Columns[3].Width = 70;
            ggDetail.TableDescriptor.Columns[3].AllowGroupByColumn = true;
            ggDetail.TableDescriptor.Columns[3].AllowFilter = true;

            ggDetail.TableDescriptor.Columns[4].HeaderText = "Tax Name";
            ggDetail.TableDescriptor.Columns[4].Width = 150;
            ggDetail.TableDescriptor.Columns[4].AllowGroupByColumn = false;


            ggDetail.TableDescriptor.Columns[5].HeaderText = "WHT Rate";
            ggDetail.TableDescriptor.Columns[5].Width = 80;
            ggDetail.TableDescriptor.Columns[5].AllowFilter = true;
            ggDetail.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[6].HeaderText = "Trans Type";
            ggDetail.TableDescriptor.Columns[6].Width = 70;

            ggDetail.TableDescriptor.Columns[7].HeaderText = "TransDate";
            ggDetail.TableDescriptor.Columns[7].Width = 65;
            ggDetail.TableDescriptor.Columns[7].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[7].Appearance.AnyCell.CellType = "Date";

            ggDetail.TableDescriptor.Columns[8].HeaderText = "Narration";
            ggDetail.TableDescriptor.Columns[8].Width = 250;
            ggDetail.TableDescriptor.Columns[8].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[9].HeaderText = "Order #";
            ggDetail.TableDescriptor.Columns[9].Width =  80;
            ggDetail.TableDescriptor.Columns[9].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[10].HeaderText = "Invoice #";
            ggDetail.TableDescriptor.Columns[10].Width =  90;
            ggDetail.TableDescriptor.Columns[10].AllowGroupByColumn = false;
           


            ggDetail.TableDescriptor.Columns[11].HeaderText = "Supplier Code";
            ggDetail.TableDescriptor.Columns[11].Width =  80;
            ggDetail.TableDescriptor.Columns[11].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[11].AllowFilter = true;

            ggDetail.TableDescriptor.Columns[12].HeaderText = "Supplier  ";
            ggDetail.TableDescriptor.Columns[12].Width = 150;
            ggDetail.TableDescriptor.Columns[12].AllowGroupByColumn = false;
           

            ggDetail.TableDescriptor.Columns[13].HeaderText = "PAN";
            ggDetail.TableDescriptor.Columns[13].Width = 85;
            ggDetail.TableDescriptor.Columns[13].AllowGroupByColumn = false;

            ggDetail.TableDescriptor.Columns[14].HeaderText = "Invoice Amount";
            ggDetail.TableDescriptor.Columns[14].Width = 100;
            ggDetail.TableDescriptor.Columns[14].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[14].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[15].HeaderText = "WHT Debit";
            ggDetail.TableDescriptor.Columns[15].Width = 100;
            ggDetail.TableDescriptor.Columns[15].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[15].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[16].HeaderText = "WHT Credit";
            ggDetail.TableDescriptor.Columns[16].Width = 100;
            ggDetail.TableDescriptor.Columns[16].AllowGroupByColumn = false;
            ggDetail.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

          

            ggDetail.Visible = true; 
        }


        

    
           
      

       

       


}

       
 
  }

