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
    public partial class frmIPLA : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        int _maxColumns;
        int _maxRows;

        string _CurrentMonthName;
        DataSet _dsFinalResult;
        string _ExcelFileName;
        string _Header1;
        string _Header2;
        string _Header3;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        public frmIPLA()
        {
            InitializeComponent();
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
            DataSet _ds4;
            _ds1 = _cg.GetActiveFinancialYears(_CurrentFinYear);
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;
            _ds2 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);
            _ds3 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _ds3.Tables[0], "PERIODDESC", "PERIODID", 0);
            _ds4 = _cg.GetFullProjects();
            UtilityFunctions.LoadWindowsCombo(cmbBorgs, _ds4.Tables[0], "BORGNAME", "BORGID", 0);
        }

        public void ResetAll()
        {
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
            this.ggDetail.Font = new Font("Calibri", 8.0f);
            btnReset.Visible = false;
            btnExport.Visible = false;




        }

        private void frmIPLA_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Inter Project Loan Account Summary";
            ActivateCurrentFinYear();
            LoadCombos();
            ResetAll();
        }

        private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "IPLA(Summary)";
        }

        private void LoadDetail(DataTable _dt)
        {
            ggDetail.DataSource = _dt;
            ggDetail.Visible = true;
        }


        public void GenerateResult()
        {
             int _borgID;
            int _finYear;
            int _fromPeriod;
            int _endPeriod;
            _borgID = Convert.ToInt16(cmbBorgs.SelectedValue);
            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _endPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
           _dsFinalResult = _cg.IPLA(_finYear,_fromPeriod,_endPeriod,_borgID);
           _maxColumns = _dsFinalResult.Tables[0].Columns.Count - 1;
           _maxRows = _dsFinalResult.Tables[0].Rows.Count - 1;
           _Header1 = "Capacite Infra Projects - IPLA Summary";
           _Header2 = "Ranage :  For Period - " + Convert.ToString(cmbFromPeriod.Text) + " To Period - " + Convert.ToString(cmbToPeriod.Text) + "          Fin Year : " + Convert.ToString(_CurrentFinYear);
           DateTime time = DateTime.Now;
           string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
           _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format));

           ReformatResultSet();

           LoadDetail(_dsFinalResult.Tables[0]);
             
      
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
           GenerateResult();
           btnExport.Visible = true;
           btnGenerate.Visible = false;
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

                                ws.Cells[_totaRow - 1, 2].Value = "Total ... ";


                                ws.Cells[_totaRow - 1, 2, _totaRow - 1, colend].Style.Font.Bold = true;
                                ws.Cells[_totaRow - 1, 2, _totaRow - 1, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow - 1, 2, _totaRow - 1, colend].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

                                ws.Cells[8, colend - 1, _totaRow - 1, colend - 1].Style.Font.Bold = true;
                                ws.Cells[8, colend - 1, _totaRow - 1, colend - 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[8, colend - 1, _totaRow - 1, colend - 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);
                            }



                            Byte[] bin = xp.GetAsByteArray();
                            string _directoryName = @"C:\MIS\ExcelFiles\";

                            string _fileName = "";
                           
                            _fileName = "IPLA";
                           

                            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                            _fileName = _fileName + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
                            _ExcelFileName = _directoryName + _fileName;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            WriteToExcel();
            OpenExcel();
        }

         
    }
}
