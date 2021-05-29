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
    public partial class frmDepSummaryReport : Form
    {
        string _ExcelFileName;

        Entities _ent = new Entities();
        Assets _as = new Assets();

        
        
        DataSet _dsFinalResult;
        

        

        string _Header1;
        string _Header2;
        string _Header3;

        public frmDepSummaryReport()
        {
            InitializeComponent();
        }

       public DataSet GetFinancialYears()
        {


            string _query = "SELECT DISTINCT DEPYEAR AS FINYEAR, DEPYEAR AS FINYEARID  FROM BI.ASSETDEPHISTORY WHERE HISTORYID <= (SELECT HISTORYID FROM BI.ASSETDEPHISTORY WHERE  ACTIVEMONTH=1) ORDER BY DEPYEAR";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _query);
            return ds;
           

        }

       public void ResetAll()
        {
        
            ggDetail.Visible = false;
            

            this.ggDetail.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggDetail.ShowGroupDropArea = false;
            this.ggDetail.TableOptions.AllowSortColumns = false;
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
           
            btnExport.Visible = false;
        }
       private void LoadDetail(DataTable _dt)
        {
        
                ggDetail.DataSource = _dt;
                ggDetail.ShowGroupDropArea = false; 
                ggDetail.TableDescriptor.Columns[0].HeaderText = "Ledger";
                ggDetail.TableDescriptor.Columns[0].Width = 60;
             
                ggDetail.TableDescriptor.Columns[1].HeaderText = "Ledger Name";
                ggDetail.TableDescriptor.Columns[1].Width = 175;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "Opening   (GB)";
                ggDetail.TableDescriptor.Columns[2].Width = 120;
                ggDetail.TableDescriptor.Columns[2].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[3].HeaderText = "Additions (GB)";
                ggDetail.TableDescriptor.Columns[3].Width = 100;
                ggDetail.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[4].HeaderText = "Deletions (GB)";
                ggDetail.TableDescriptor.Columns[4].Width = 100;
                ggDetail.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[5].HeaderText = "Closing   (GB)";
                ggDetail.TableDescriptor.Columns[5].Width = 120;
                ggDetail.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[6].HeaderText = "Opening   (Dep)";
                ggDetail.TableDescriptor.Columns[6].Width = 120;
                ggDetail.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[7].HeaderText = "Additons  (Dep)";
                ggDetail.TableDescriptor.Columns[7].Width = 100;
                ggDetail.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[8].HeaderText = "Deletions (Dep)";
                ggDetail.TableDescriptor.Columns[8].Width = 100;
                ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[9].HeaderText = "Closing   (Dep)";
                ggDetail.TableDescriptor.Columns[9].Width = 120;
                ggDetail.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[10].HeaderText = "Net Value"; 
                ggDetail.TableDescriptor.Columns[10].Width = 120;
                ggDetail.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[11].Width = 0;
                ggDetail.TableDescriptor.Columns[12].Width = 0;
             
        }
       private void WriteToExcel()
        {
          btnExport.Enabled = false;
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
                            dt.Columns.RemoveAt(11);
                            dt.Columns.RemoveAt(11);
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
                            ws.Cells[7, colstart, 7, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                           

                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                          
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="";
                        _fileName = "FASummary";
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
       

       private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Asset Depreciation Report (Summary )";
      
            string _PrevYear ;
            string _CurrYear;
            int _thisYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _CurrYear = " - " + Convert.ToString(_thisYear);
            _PrevYear = " - " + Convert.ToString(_thisYear -1 );   

            _dsFinalResult.Tables[0].Columns[0].Caption = "Ledger Code";
            _dsFinalResult.Tables[0].Columns[1].Caption = "Ledger Name";
            _dsFinalResult.Tables[0].Columns[2].Caption = "Opening   (GB)";
            _dsFinalResult.Tables[0].Columns[3].Caption = "Additions (GB)";
            _dsFinalResult.Tables[0].Columns[4].Caption = "Deletions (GB)";
            _dsFinalResult.Tables[0].Columns[5].Caption = "Closing   (GB)";
            _dsFinalResult.Tables[0].Columns[6].Caption = "Opening   (Dep)";
            _dsFinalResult.Tables[0].Columns[7].Caption = "Additons  (Dep)";
            _dsFinalResult.Tables[0].Columns[8].Caption = "Deletions (Dep)";
            _dsFinalResult.Tables[0].Columns[9].Caption = "Closing   (Dep)";
            _dsFinalResult.Tables[0].Columns[10].Caption = "Net Value"; 
            _dsFinalResult.Tables[0].Columns[11].Caption = "From Period";
            _dsFinalResult.Tables[0].Columns[12].Caption = "To Period";
            

        }

       private void LoadFinYears()
       {
           DataSet _dsFinYear = new DataSet();
           _dsFinYear = GetFinancialYears();
           UtilityFunctions.LoadWindowsCombo(cmbFinYear, _dsFinYear.Tables[0], "FINYEAR", "FINYEARID", 0);

       }
       private void frmAssetMaster_Load(object sender, EventArgs e)
       {
           btnGenerate.Enabled = false;
           cmbPeriod.Enabled = false;
           btnExport.Enabled = false;
           LoadFinYears();
         
          
       }

       private void LoadPeriods()
       {
           DataSet _dsPeriods = new DataSet();
           int _finYear = Convert.ToInt16(cmbFinYear.Text);
           _dsPeriods = _as.GetPeriodsToLastDepreciated(_finYear);
           UtilityFunctions.LoadWindowsCombo(cmbPeriod, _dsPeriods.Tables[0], "PERIODDESC", "PERIODID", 0);

       }
       private void btnGenerate_Click(object sender, EventArgs e)
       {
           DataSet _finalResult = new DataSet();
           int _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
           int _toPeriod = Convert.ToInt16(cmbPeriod.SelectedValue);
           string _toPerioName = Convert.ToString(cmbPeriod.SelectedText);
           _dsFinalResult =  _as.FetchDepreciationDetails(_finYear, _toPeriod,2);
           _Header1 = "Capacite Infra Projects - Asset Depreciation Report (Summary)";
           _Header2 = "Financial Year: " + Convert.ToString(_finYear) + "   To Period : " + Convert.ToString(_toPerioName);
           DateTime time = DateTime.Now;
           string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
           _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format));
           btnExport.Enabled = true;
           ReformatResultSet();
           LoadDetail(_dsFinalResult.Tables[0]); 
       }

       private void btnShowPeriod_Click(object sender, EventArgs e)
       {
           LoadPeriods();
           btnShowPeriod.Enabled = false;
           btnGenerate.Enabled = true;
           cmbPeriod.Enabled = true;
       }

       private void btnReset_Click(object sender, EventArgs e)
       {
           btnExport.Enabled = false;
           btnShowPeriod.Enabled = true;
           cmbPeriod.Enabled = false;

           
       }

       

        

         

       

    }   
  }

