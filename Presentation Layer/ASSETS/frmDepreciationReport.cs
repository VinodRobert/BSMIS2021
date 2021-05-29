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
    public partial class frmDepreciationReport : Form
    {
        string _ExcelFileName;

        Entities _ent = new Entities();
        Assets _as = new Assets();

        
        
        DataSet _dsFinalResult;
        

        

        string _Header1;
        string _Header2;
        string _Header3;

        public frmDepreciationReport()
        {
            InitializeComponent();
        }

       public DataSet GetFinancialYears()
        {
            string _query = "Select DISTINCT  [Year] FINYEAR, [Year] FINYEARID FROM TRANSACTIONS WHERE YEAR>=2017 ORDER BY YEAR";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _query);
            return ds;
        }

       public void ResetAll()
        {
        
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
           
            btnExport.Visible = false;
        }
       private void LoadDetail(DataTable _dt)
        {
        
                ggDetail.DataSource = _dt;
                ggDetail.ShowGroupDropArea = true; 
                ggDetail.TableDescriptor.Columns[0].HeaderText = "Category";
                ggDetail.TableDescriptor.Columns[0].Width = 150;
                ggDetail.TableDescriptor.Columns[0].AllowGroupByColumn = true;
                ggDetail.TableDescriptor.Columns[0].AllowFilter = true;

                ggDetail.TableDescriptor.Columns[1].HeaderText = "Asset Number";
                ggDetail.TableDescriptor.Columns[1].Width = 95;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "Asset Name";
                ggDetail.TableDescriptor.Columns[2].Width = 250;
                ggDetail.TableDescriptor.Columns[2].AllowFilter = true;
                ggDetail.TableDescriptor.Columns[2].AllowGroupByColumn = true;
               
                ggDetail.TableDescriptor.Columns[3].HeaderText = "Put To Use";
                ggDetail.TableDescriptor.Columns[3].Width = 79;
                ggDetail.TableDescriptor.Columns[3].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[3].Appearance.AnyCell.CellType = "Date";

                ggDetail.TableDescriptor.Columns[4].HeaderText = "AssetValue";
                ggDetail.TableDescriptor.Columns[4].Width = 150;
                ggDetail.TableDescriptor.Columns[4].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[4].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[5].HeaderText = "Additions";
                ggDetail.TableDescriptor.Columns[5].Width = 150;
                ggDetail.TableDescriptor.Columns[5].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[6].HeaderText = "Deletions";
                ggDetail.TableDescriptor.Columns[6].Width = 150;
                ggDetail.TableDescriptor.Columns[6].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[7].HeaderText = "Salvage Value";
                ggDetail.TableDescriptor.Columns[7].Width = 150;
                ggDetail.TableDescriptor.Columns[7].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[8].HeaderText = "Life(Months)";
                ggDetail.TableDescriptor.Columns[8].Width = 100;
                ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F0";
                ggDetail.TableDescriptor.Columns[8].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[9].HeaderText = "# Depreciated";
                ggDetail.TableDescriptor.Columns[9].Width = 100;
                ggDetail.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F0";
                ggDetail.TableDescriptor.Columns[9].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[10].HeaderText = "Accum. Depre";
                ggDetail.TableDescriptor.Columns[10].Width = 150;
                ggDetail.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";
                ggDetail.TableDescriptor.Columns[10].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[23].HeaderText = "Remaining Life(Months)";
                ggDetail.TableDescriptor.Columns[23].Width = 150;
                ggDetail.TableDescriptor.Columns[23].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[23].Appearance.AnyCell.Format = "F0";

                ggDetail.TableDescriptor.Columns[24].HeaderText = "Additions Dep";
                ggDetail.TableDescriptor.Columns[24].Width = 150;
                ggDetail.TableDescriptor.Columns[24].Appearance.AnyCell.Format = "F2";
                ggDetail.TableDescriptor.Columns[24].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[25].HeaderText = "Deletions Dep";
                ggDetail.TableDescriptor.Columns[25].Width = 150;
                ggDetail.TableDescriptor.Columns[25].Appearance.AnyCell.Format = "F2";
                ggDetail.TableDescriptor.Columns[25].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[26].HeaderText = "Book Value";
                ggDetail.TableDescriptor.Columns[26].Width = 150;
                ggDetail.TableDescriptor.Columns[26].Appearance.AnyCell.Format = "F2";
                ggDetail.TableDescriptor.Columns[26].AllowGroupByColumn = false;

                ggDetail.TableDescriptor.Columns[27].HeaderText = "Location";
                ggDetail.TableDescriptor.Columns[27].Width = 135;


                this.ggDetail.TableModel.Cols.FreezeRange(0,2);

                GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "ASSETVALUE", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "ADDITIONS", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd2 = new GridSummaryColumnDescriptor("Sum2", SummaryType.DoubleAggregate, "DELETIONS", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd3 = new GridSummaryColumnDescriptor("Sum3", SummaryType.DoubleAggregate, "SALVAGE", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd4 = new GridSummaryColumnDescriptor("Sum4", SummaryType.DoubleAggregate, "ACCUMDEP", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd5 = new GridSummaryColumnDescriptor("Sum5", SummaryType.DoubleAggregate, "DEPADDITIONS", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd6 = new GridSummaryColumnDescriptor("Sum6", SummaryType.DoubleAggregate, "DEPDELETES", "{Sum:#.00}");
                GridSummaryColumnDescriptor scd7 = new GridSummaryColumnDescriptor("Sum7", SummaryType.DoubleAggregate, "BOOKVALUE", "{Sum:#.00}");








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
               






                GridSummaryRowDescriptor srd = new GridSummaryRowDescriptor("Sum", "Total", new GridSummaryColumnDescriptor[] { scd0, scd1, scd2,scd3,scd4,scd5,scd6,scd7 });
                srd.Appearance.AnyCell.Format = "F2";
                srd.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

                this.ggDetail.TableDescriptor.SummaryRows.Add(srd);
             
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
                            ws.Cells[7, colstart, 7, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            ws.Column(5).Style.Numberformat.Format = "dd/MM/yyyy";


                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            if (_tableCount == 1)
                            {
                                ws.Cells[_totaRow, 4].Value = "Total ... ";
                                ws.Cells[_totaRow, 6].Formula = "+SUM(F8:F" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 7].Formula = "+SUM(G8:G" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 8].Formula = "+SUM(H8:H" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 9].Formula = "+SUM(I8:I" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 12].Formula = "+SUM(L8:L" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 26].Formula = "+SUM(Z8:Z" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 27].Formula = "+SUM(AA8:AA" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 28].Formula = "+SUM(AB8:AB" + (_recordCount + 7) + ")";

                                //ws.Cells[_totaRow, 15].Formula = "+SUM(O8:O" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 16].Formula = "+SUM(P8:P" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 17].Formula = "+SUM(Q8:Q" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 18].Formula = "+SUM(R8:R" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 19].Formula = "+SUM(S8:S" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 20].Formula = "+SUM(T8:T" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 21].Formula = "+SUM(U8:U" + (_recordCount + 7) + ")";
                                //ws.Cells[_totaRow, 22].Formula = "+SUM(V8:V" + (_recordCount + 7) + ")";
                             
                                //ws.Cells[_totaRow, 24].Formula = "+SUM(X8:X" + (_recordCount + 7) + ")";





                                ws.Cells[_totaRow, 10, _totaRow, 10].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                ws.Cells[_totaRow, 12, _totaRow, 24].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            
                                ws.Cells[_totaRow, 2, _totaRow, 28].Style.Font.Bold = true;
                                ws.Cells[_totaRow, 2, _totaRow, 28].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow, 2, _totaRow, 28].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

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
       

       private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Asset Depreciation Report";
      
            string _PrevYear ;
            string _CurrYear;
            int _thisYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _CurrYear = " - " + Convert.ToString(_thisYear);
            _PrevYear = " - " + Convert.ToString(_thisYear -1 );   

            _dsFinalResult.Tables[0].Columns[0].Caption = "Category";
            _dsFinalResult.Tables[0].Columns[1].Caption = "Asset Number";
            _dsFinalResult.Tables[0].Columns[2].Caption = "Asset Name";
            _dsFinalResult.Tables[0].Columns[3].Caption = "Put To Use";
            _dsFinalResult.Tables[0].Columns[4].Caption = "AssetValue";
            _dsFinalResult.Tables[0].Columns[5].Caption = "Additions";
            _dsFinalResult.Tables[0].Columns[6].Caption = "Deletions";
            _dsFinalResult.Tables[0].Columns[7].Caption = "Salvage Value";
            _dsFinalResult.Tables[0].Columns[8].Caption = "Life(Months)";
            _dsFinalResult.Tables[0].Columns[9].Caption = "# Depreciated";
            _dsFinalResult.Tables[0].Columns[10].Caption = "Accum. Depre";
            _dsFinalResult.Tables[0].Columns[11].Caption = "April" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[12].Caption = "May" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[13].Caption = "June" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[14].Caption = "July" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[15].Caption = "August" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[16].Caption = "September" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[17].Caption = "October" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[18].Caption = "November" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[19].Caption = "December" + _PrevYear;
            _dsFinalResult.Tables[0].Columns[20].Caption = "January" + _CurrYear;
            _dsFinalResult.Tables[0].Columns[21].Caption = "February" + _CurrYear;
            _dsFinalResult.Tables[0].Columns[22].Caption = "March" + _CurrYear;
            _dsFinalResult.Tables[0].Columns[23].Caption = "Remaining Life";
            _dsFinalResult.Tables[0].Columns[24].Caption = "Additions Dep";
            _dsFinalResult.Tables[0].Columns[25].Caption = "Deletions Dep";
            _dsFinalResult.Tables[0].Columns[26].Caption = "Book Value";
            _dsFinalResult.Tables[0].Columns[27].Caption = "Location";


        }

       private void LoadPeriods()
       {
           DataSet _dsPeriods = new DataSet();
           int _finYear = Convert.ToInt16(cmbFinYear.Text);
           _dsPeriods = _as.GetPeriodsToLastDepreciated(_finYear);
           UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _dsPeriods.Tables[0], "PERIODDESC", "PERIODID", 0);

       }

       private void LoadFinYears()
       {
           DataSet _dsFinYear = new DataSet();
           _dsFinYear = GetFinancialYears();
           UtilityFunctions.LoadWindowsCombo(cmbFinYear, _dsFinYear.Tables[0], "FINYEAR", "FINYEARID", 0);

       }
       private void frmAssetMaster_Load(object sender, EventArgs e)
       {
           LoadFinYears();
           LoadPeriods();
       }

       private void btnGenerate_Click(object sender, EventArgs e)
       {
           DataSet _finalResult = new DataSet();
           int _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
           int _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
           _dsFinalResult = _as.FetchDepreciationDetails(_finYear,_toPeriod,1);
           _Header1 = "Capacite Infra Projects - Asset Master";
           _Header2 = " ";
           DateTime time = DateTime.Now;
           string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
           _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 
           ReformatResultSet();
           LoadDetail(_dsFinalResult.Tables[0]); 
       }

       

        

         

       

    }   
  }

