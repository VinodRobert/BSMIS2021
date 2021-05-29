using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    public partial class frmBudgetVsActual : Form
    {
        CreditorAge _cg = new CreditorAge();
        DataSet _dsFinYear;
        DataSet _dsProjects;
        DataSet _dsFinalResult;
        string _ExcelFileName;
        string _Header1;
        string _Header2;
        string _Header3; 


        public frmBudgetVsActual()
        {
            InitializeComponent();
        }

        private void frmBudgetVsActual_Load(object sender, EventArgs e)
        {
            LoadCombos();
            SetGrid();
        }

        private void LoadCombos()
        {
            _dsFinYear = _cg.GetBudgetYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _dsFinYear.Tables[0], "FINYEAR", "FINYEAR", 0);

            _dsProjects = _cg.GetProjectsHavingBudget();
            UtilityFunctions.LoadWindowsCombo(cmbProjects, _dsProjects.Tables[0], "BORGNAME", "BORGID", 0);

        }

        private void SetGrid()
        {
            ggBudget.Visible = false;
        

            this.ggBudget.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggBudget.ShowGroupDropArea = true;
            this.ggBudget.TableOptions.AllowSortColumns = true;
            this.ggBudget.TopLevelGroupOptions.ShowCaption = true;
            this.ggBudget.TableOptions.RecordPreviewRowHeight = 55;
            this.ggBudget.TableOptions.ShowRowHeader = false;
            this.ggBudget.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggBudget.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggBudget.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggBudget.TableOptions.DefaultColumnWidth = 65;
            this.ggBudget.TableOptions.CaptionRowHeight = 22;
            this.ggBudget.InvalidateAllWhenListChanged = true;
            this.ggBudget.ForceDisposeOnResetDataSource = true;
            this.ggBudget.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggBudget.CacheRecordValues = false;
            this.ggBudget.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggBudget.Font = new Font("Calibri", 8.0f);
            this.ggBudget.TopLevelGroupOptions.ShowFilterBar = true;  
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int _borgID;
            int _finYear;
            _Header1 = "Capacite Infra Projects - Budget Vs Actaul Report";
            _Header2 = "Project : " + Convert.ToString(cmbProjects.SelectedValue).Trim();
            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 

            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _borgID = Convert.ToInt16(cmbProjects.SelectedValue);

            _dsFinalResult = _cg.FetchBudgetVsActual(_finYear, _borgID);
            LoadDetail(_dsFinalResult);
        }



        private void WriteToExcel()
        {
            DataSet _dsEx = new DataSet();
            _dsEx = _dsFinalResult;

          
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
                     
                                ws.Column(9).Width = 13;
                                 



                                ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                              

                            }



                            Byte[] bin = xp.GetAsByteArray();
                            string _directoryName = @"C:\MIS\ExcelFiles\";
                            string _fileName = "";
                           
                            _fileName = "BudgetVsActual";
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


      
        private void LoadDetail(DataSet _ds)
        {
            DataTable _dt;
            _dt = _ds.Tables[0];
            ggBudget.DataSource = _dsFinalResult.Tables[0];
          
       
            ggBudget.Refresh();

            ggBudget.TableDescriptor.Columns[0].HeaderText = "Ledger Code";
            ggBudget.TableDescriptor.Columns[0].Width = 90;

            ggBudget.TableDescriptor.Columns[1].HeaderText = "Ledger Name";
            ggBudget.TableDescriptor.Columns[1].Width = 200;
            this.ggBudget.TableModel.Cols.FreezeRange(0, 1);

            ggBudget.TableDescriptor.Columns[2].HeaderText = "April(Budget)";
            ggBudget.TableDescriptor.Columns[2].Width = 100;
            ggBudget.TableDescriptor.Columns[2].AllowFilter = false;
            ggBudget.TableDescriptor.Columns[2].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[3].HeaderText = "April(Actual)";
            ggBudget.TableDescriptor.Columns[3].Width = 100;
            ggBudget.TableDescriptor.Columns[3].AllowFilter = false;
            ggBudget.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[3].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;

            ggBudget.TableDescriptor.Columns[4].HeaderText = "May(Budget)";
            ggBudget.TableDescriptor.Columns[4].Width = 100;
            ggBudget.TableDescriptor.Columns[4].AllowFilter = true;
            ggBudget.TableDescriptor.Columns[3].Appearance.AnyCell.Format = "F2";


            ggBudget.TableDescriptor.Columns[5].HeaderText = "May(Actual)";
            ggBudget.TableDescriptor.Columns[5].Width = 100;
            ggBudget.TableDescriptor.Columns[5].AllowFilter = true;
            ggBudget.TableDescriptor.Columns[5].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[5].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;

            ggBudget.TableDescriptor.Columns[6].HeaderText = "June(Budget)";
            ggBudget.TableDescriptor.Columns[6].Width = 100;
            ggBudget.TableDescriptor.Columns[6].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[7].HeaderText = "June(Actual)";
            ggBudget.TableDescriptor.Columns[7].Width = 100;
            ggBudget.TableDescriptor.Columns[7].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[7].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[8].HeaderText = "July(Budget)";
            ggBudget.TableDescriptor.Columns[8].Width = 100;
            ggBudget.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[8].AllowGroupByColumn = false;

            ggBudget.TableDescriptor.Columns[9].HeaderText = "July(Actual)";
            ggBudget.TableDescriptor.Columns[9].Width = 100;
            ggBudget.TableDescriptor.Columns[9].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[9].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[10].HeaderText = "August(Budget)";
            ggBudget.TableDescriptor.Columns[10].Width = 100;
            ggBudget.TableDescriptor.Columns[10].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";


            ggBudget.TableDescriptor.Columns[11].HeaderText = "August(Actual)";
            ggBudget.TableDescriptor.Columns[11].Width =100;
            ggBudget.TableDescriptor.Columns[11].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[11].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;

            ggBudget.TableDescriptor.Columns[12].HeaderText = "September(Buget)";
            ggBudget.TableDescriptor.Columns[12].Width = 100;
            ggBudget.TableDescriptor.Columns[12].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[12].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[13].HeaderText = "September(Actual)";
            ggBudget.TableDescriptor.Columns[13].Width = 100;
            ggBudget.TableDescriptor.Columns[13].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[13].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[13].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[14].HeaderText = "October(Budget)";
            ggBudget.TableDescriptor.Columns[14].Width = 100;
            ggBudget.TableDescriptor.Columns[14].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[14].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[15].HeaderText = "October(Actual)";
            ggBudget.TableDescriptor.Columns[15].Width = 100;
            ggBudget.TableDescriptor.Columns[15].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[15].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[15].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[16].HeaderText = "November(Budget)";
            ggBudget.TableDescriptor.Columns[16].Width =100;
            ggBudget.TableDescriptor.Columns[16].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[17].HeaderText = "November(Actual)";
            ggBudget.TableDescriptor.Columns[17].Width = 100;
            ggBudget.TableDescriptor.Columns[17].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[17].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[17].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[18].HeaderText = "December(Budget)";
            ggBudget.TableDescriptor.Columns[18].Width = 100;
            ggBudget.TableDescriptor.Columns[18].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[18].Appearance.AnyCell.Format = "F2";

            ggBudget.TableDescriptor.Columns[19].HeaderText = "December(Actual)";
            ggBudget.TableDescriptor.Columns[19].Width = 100;
            ggBudget.TableDescriptor.Columns[19].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[19].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[19].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;


            ggBudget.TableDescriptor.Columns[20].HeaderText = "January(Budget)";
            ggBudget.TableDescriptor.Columns[20].Width = 100;
            ggBudget.TableDescriptor.Columns[20].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[20].Appearance.AnyCell.Format = "F2";
          


            ggBudget.TableDescriptor.Columns[21].HeaderText = "January(ACtual)";
            ggBudget.TableDescriptor.Columns[21].Width = 100;
            ggBudget.TableDescriptor.Columns[21].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[21].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[21].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;
            
            ggBudget.TableDescriptor.Columns[22].HeaderText = "February(Budget)";
            ggBudget.TableDescriptor.Columns[22].Width = 100;
            ggBudget.TableDescriptor.Columns[22].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[22].Appearance.AnyCell.Format = "F2";
           

            ggBudget.TableDescriptor.Columns[23].HeaderText = "February(Actual)";
            ggBudget.TableDescriptor.Columns[23].Width = 100;
            ggBudget.TableDescriptor.Columns[23].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[23].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[23].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;
            
            ggBudget.TableDescriptor.Columns[24].HeaderText = "March(Budget)";
            ggBudget.TableDescriptor.Columns[24].Width = 100;
            ggBudget.TableDescriptor.Columns[24].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[24].Appearance.AnyCell.Format = "F2";
      
            ggBudget.TableDescriptor.Columns[25].HeaderText = "March(Actual)";
            ggBudget.TableDescriptor.Columns[25].Width = 100;
            ggBudget.TableDescriptor.Columns[25].AllowGroupByColumn = false;
            ggBudget.TableDescriptor.Columns[25].Appearance.AnyCell.Format = "F2";
            ggBudget.TableDescriptor.Columns[25].Appearance.AnyRecordFieldCell.BackColor = Color.LightSkyBlue;

            ggBudget.Visible = true;

        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            WriteToExcel();
            OpenExcel();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
