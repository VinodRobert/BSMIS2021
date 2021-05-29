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
    public partial class frmGSTSales : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
     
        string _ExcelFileName;

        Entities _ent = new Entities();
        GST _gst = new GST();

        Stores _st = new Stores();
        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataSet _dsFinalResult;

        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();
        DataTable _tableProjects = new DataTable();
        DataTable _tableBorgs = new DataTable();
        DataTable _tableCILGSTN = new DataTable();
        DataTable _tableDocmentType = new DataTable();
        DataTable _tableGSTType = new DataTable();

        string _selectedZones;
        string _selectedProjects;


        string _Header1;
        string _Header2;
        string _Header3;

        public frmGSTSales()
        {
            InitializeComponent();
        }

      

        

        public void ResetAll()
        {
           
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
            this.gridRegister.TableOptions.AllowSelection = GridSelectionFlags.Row;

         
        }

             
        private void btnReset_Click(object sender, EventArgs e)
        {
         
            DisableButtons(0);
            RefreshScreen();
         
        }

        private void WriteToExcel()
        {
          DataSet _dsEx = new DataSet();
          _dsEx = _dsFinalResult;
          
          int _tableCount = 0;
          Int64 _recordCount = 0;
          Int64 _totaRow = 0; 
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
                            
                            dt.TableName = " GST Purchase Register  ";
                            _tableCount = _tableCount + 1; 
                            ExcelWorksheet ws = xp.Workbook.Worksheets.Add(dt.TableName);
                            _recordCount = Convert.ToInt64(dt.Rows.Count);
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
                            ws.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
                            ws.Column(4).Width = 13;
                            //ws.Column(7).Style.Numberformat.Format = "dd/MM/yyyy";
                            //ws.Column(7).Width = 13;


                            ws.Cells[7, 8, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                        
                            ws.Cells[7, 8, rowend, colend].AutoFitColumns(20);
                          


                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            
                        
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="GSTSalesReport";
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
            GenerateOrgTable();
            GenerateCILGSTN();
            GenerateDocumentType();
            GenerateGSTType();
            GenerateResult();
        }

        private void GenerateOrgTable()
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
    
        private void GenerateCILGSTN()
        {
            int i;
            _tableCILGSTN.Rows.Clear();
            for (i = 0; i <= (checkedListBoxCILGSTIN.Items.Count - 1); i++)
            {
                if (checkedListBoxCILGSTIN.GetItemChecked(i))
                {
                   _tableCILGSTN.Rows.Add(Convert.ToString(checkedListBoxCILGSTIN.Items[i]));
                }
            }
        }
        
        private void GenerateDocumentType() 
        {
            int i;
            _tableDocmentType.Rows.Clear();
            for (i = 0; i <= (checkedListBoxDocType.Items.Count - 1); i++)
            {
                if (checkedListBoxDocType.GetItemChecked(i))
                {
                    _tableDocmentType.Rows.Add(Convert.ToString(checkedListBoxDocType.Items[i]));
                }
            }
        }

        private void GenerateGSTType()
        {
            int i;
            _tableGSTType.Rows.Clear();
            for (i = 0; i <= (checkedListBoxGSTType.Items.Count - 1); i++)
            {
                if (checkedListBoxGSTType.GetItemChecked(i))
                {
                    _tableGSTType.Rows.Add(Convert.ToString(checkedListBoxGSTType.Items[i]));
                }
            }
        }

        private void GenerateResult()
        {
            DisableButtons(1);
            int _fromPeriod;
            int _toPeriod;
            int _finYear;
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _dsFinalResult = _gst.GSTSales(_finYear,_fromPeriod, _toPeriod,  _tableProjects, _tableCILGSTN, _tableDocmentType, _tableGSTType);
     
               

            DataTable _dt;
            _dt = _dsFinalResult.Tables[0];



            _Header1 = "Capacite Infra Projects - GST Sales Report ";
            _Header2 = "From  Period : " + Convert.ToString(_fromPeriod) + " To Period : " + Convert.ToString(_toPeriod);
            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format));

        


            DisableButtons(2);
           
            LoadDetail(_dt);
          
        }

        private void LoadDetail(DataTable _dt)
        {
            gridRegister.DataSource = _dt;

            gridRegister.TableDescriptor.Columns[0].HeaderText = "FinYear";
            gridRegister.TableDescriptor.Columns[0].Width = 50;
            gridRegister.TableDescriptor.Columns[0].AllowFilter = false;

            gridRegister.TableDescriptor.Columns[1].HeaderText = "Period";
            gridRegister.TableDescriptor.Columns[1].Width =  55;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[2].HeaderText = "Borg Name";
            gridRegister.TableDescriptor.Columns[2].Width = 190;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[2].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[3].HeaderText = "CIL GSTIN";
            gridRegister.TableDescriptor.Columns[3].Width = 100;
            gridRegister.TableDescriptor.Columns[3].AllowGroupByColumn = true;
            gridRegister.TableDescriptor.Columns[3].AllowFilter = true;

            gridRegister.TableDescriptor.Columns[4].HeaderText = "DocType";
            gridRegister.TableDescriptor.Columns[4].Width = 100;
            gridRegister.TableDescriptor.Columns[4].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[4].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[5].HeaderText = "GSTType";
            gridRegister.TableDescriptor.Columns[5].Width = 55;
            gridRegister.TableDescriptor.Columns[5].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[5].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[6].HeaderText = "BatchRef";
            gridRegister.TableDescriptor.Columns[6].Width = 100;
            gridRegister.TableDescriptor.Columns[6].AllowFilter = false;
      
            gridRegister.TableDescriptor.Columns[7].HeaderText = "Invoice#";
            gridRegister.TableDescriptor.Columns[7].Width = 100;
            gridRegister.TableDescriptor.Columns[7].AllowFilter = false;
      

            gridRegister.TableDescriptor.Columns[8].HeaderText = "Invoice Dt";
            gridRegister.TableDescriptor.Columns[8].Width = 65;
            gridRegister.TableDescriptor.Columns[8].Appearance.AnyCell.CellType = "Date";
            gridRegister.TableDescriptor.Columns[8].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[9].HeaderText = "Trans Dt";
            gridRegister.TableDescriptor.Columns[9].Width = 65;
            gridRegister.TableDescriptor.Columns[9].Appearance.AnyCell.CellType = "Date";
            gridRegister.TableDescriptor.Columns[9].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[10].HeaderText = "SuppCode";
            gridRegister.TableDescriptor.Columns[10].Width = 80;
            gridRegister.TableDescriptor.Columns[10].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[10].AllowGroupByColumn = false;
            
            gridRegister.TableDescriptor.Columns[11].HeaderText = "Supplier";
            gridRegister.TableDescriptor.Columns[11].Width = 155;
            gridRegister.TableDescriptor.Columns[11].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[11].AllowGroupByColumn = true;
            

            gridRegister.TableDescriptor.Columns[12].HeaderText = "Supp GSTIN";
            gridRegister.TableDescriptor.Columns[12].Width = 80;
            gridRegister.TableDescriptor.Columns[11].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[12].AllowGroupByColumn = false;
            
            gridRegister.TableDescriptor.Columns[13].HeaderText = "Supplier City";
            gridRegister.TableDescriptor.Columns[13].Width = 80;
            gridRegister.TableDescriptor.Columns[13].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[13].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[14].HeaderText = "Ledger";
            gridRegister.TableDescriptor.Columns[14].Width = 50;
            gridRegister.TableDescriptor.Columns[14].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[15].HeaderText = "Ledger Name ";
            gridRegister.TableDescriptor.Columns[15].Width = 150;
            gridRegister.TableDescriptor.Columns[15].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[15].AllowGroupByColumn = true;
           

            gridRegister.TableDescriptor.Columns[16].HeaderText = "Item";
            gridRegister.TableDescriptor.Columns[16].Width = 250;
            gridRegister.TableDescriptor.Columns[16].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[17].HeaderText = "Qty";
            gridRegister.TableDescriptor.Columns[17].Width = 90;
            gridRegister.TableDescriptor.Columns[17].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[18].HeaderText = "UOM";
            gridRegister.TableDescriptor.Columns[18].Width = 50;
            gridRegister.TableDescriptor.Columns[18].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[19].HeaderText = "Rate ";
            gridRegister.TableDescriptor.Columns[19].Width = 100;
            gridRegister.TableDescriptor.Columns[19].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[19].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[20].HeaderText = "Amount";
            gridRegister.TableDescriptor.Columns[20].Width = 150;
            gridRegister.TableDescriptor.Columns[20].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[20].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[20].Appearance.AnyCell.Format = "F2";


            gridRegister.TableDescriptor.Columns[21].HeaderText = "CGST %";
            gridRegister.TableDescriptor.Columns[21].Width = 50;
            gridRegister.TableDescriptor.Columns[21].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[21].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[22].HeaderText = "SGST %";
            gridRegister.TableDescriptor.Columns[22].Width = 50;
            gridRegister.TableDescriptor.Columns[22].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[22].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[23].HeaderText = "IGST %";
            gridRegister.TableDescriptor.Columns[23].Width = 55;
            gridRegister.TableDescriptor.Columns[23].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[23].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[24].HeaderText = "CSGT";
            gridRegister.TableDescriptor.Columns[24].Width = 100;
            gridRegister.TableDescriptor.Columns[24].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[24].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[25].HeaderText = "SGST";
            gridRegister.TableDescriptor.Columns[25].Width = 100;
            gridRegister.TableDescriptor.Columns[25].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[25].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[26].HeaderText = "IGST";
            gridRegister.TableDescriptor.Columns[26].Width = 100;
            gridRegister.TableDescriptor.Columns[26].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[26].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[27].HeaderText = "CSGT(RCM) Input";
            gridRegister.TableDescriptor.Columns[27].Width = 100;
            gridRegister.TableDescriptor.Columns[27].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[27].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[28].HeaderText = "SGST(RCM) Input";
            gridRegister.TableDescriptor.Columns[28].Width = 100;
            gridRegister.TableDescriptor.Columns[28].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[28].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[29].HeaderText = "IGST(RCM) Input";
            gridRegister.TableDescriptor.Columns[29].Width = 100;
            gridRegister.TableDescriptor.Columns[29].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[29].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[30].HeaderText = "CGST(RCM) Output";
            gridRegister.TableDescriptor.Columns[30].Width = 100;
            gridRegister.TableDescriptor.Columns[30].AllowFilter = false;


            gridRegister.TableDescriptor.Columns[31].HeaderText = "SGST(RCM) Output";
            gridRegister.TableDescriptor.Columns[31].Width = 100;
            gridRegister.TableDescriptor.Columns[31].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[32].HeaderText = "IGST(RCM) Output";
            gridRegister.TableDescriptor.Columns[32].Width = 100;
            gridRegister.TableDescriptor.Columns[32].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[33].HeaderText = "GST Expense";
            gridRegister.TableDescriptor.Columns[33].Width = 100;
            gridRegister.TableDescriptor.Columns[33].AllowGroupByColumn = false;


            gridRegister.TableDescriptor.Columns[34].HeaderText = "TransGroupo";
            gridRegister.TableDescriptor.Columns[34].Width = 100;
            gridRegister.TableDescriptor.Columns[34].AllowGroupByColumn = false;
            

            GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "CGST", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "SGST", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd2 = new GridSummaryColumnDescriptor("Sum2", SummaryType.DoubleAggregate, "IGST", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd3 = new GridSummaryColumnDescriptor("Sum3", SummaryType.DoubleAggregate, "CGSTRCM_I", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd4 = new GridSummaryColumnDescriptor("Sum4", SummaryType.DoubleAggregate, "SGSTRCM_I", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd5 = new GridSummaryColumnDescriptor("Sum5", SummaryType.DoubleAggregate, "IGSTRCM_I", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd6 = new GridSummaryColumnDescriptor("Sum6", SummaryType.DoubleAggregate, "CGSTRCM_O", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd7 = new GridSummaryColumnDescriptor("Sum7", SummaryType.DoubleAggregate, "SGSTRCM_O", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd8 = new GridSummaryColumnDescriptor("Sum8", SummaryType.DoubleAggregate, "IGSTRCM_O", "{Sum:#.00}");
            GridSummaryColumnDescriptor scd9 = new GridSummaryColumnDescriptor("Sum9", SummaryType.DoubleAggregate, "GGSTEXPENSE", "{Sum:#.00}");

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

            //this.gridRegister.TableDescriptor.SummaryRows.Add(srd);


            gridRegister.Visible = true;
            

        }

        private void SetupGrid()
        {
            gridRegister.Visible = false;
            

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


        private void DisableButtons(int i)
        {
            if (i == 1)
            {
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = false;
            }
            else
            {
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = true;
                btnReset.Visible = true;
            }
        }

        private void frmGSTPurchase_Load(object sender, EventArgs e)
        {
            _tableProjects.Columns.Add("BORGID", typeof(int));
            _tableBorgs.Columns.Add("BORGID", typeof(int));
            _tableCILGSTN.Columns.Add("CILCGSTN", typeof(string));
            _tableDocmentType.Columns.Add("DOCType", typeof(string));
            _tableGSTType.Columns.Add("GSTType", typeof(string));

            RefreshScreen();
        }

        private void RefreshScreen()
        {
            gridRegister.Visible = false;
            btnReset.Visible = false;
            ActivateCurrentFinYear();
            LoadCombos();
            LoadListZone();
            LoadListProject();
            MakeAllChecked();
            SetupGrid();
            btnGenerate.Visible = true;
        }
        private void MakeAllChecked()
        {
            int i;
            for (i = 0; i <= (checkedListBoxDocType.Items.Count - 1); i++)
            {
                checkedListBoxDocType.SetItemChecked(i, true);
            }
            for (i = 0; i <= (checkedListBoxGSTType.Items.Count - 1); i++)
            {
                checkedListBoxGSTType.SetItemChecked(i, true);
            }
        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
          

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

        private void LoadCombos()
        {
            DataSet _ds1;
            DataSet _ds2;
            DataSet _ds3;

            _ds1 = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;


            _ds2 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);

            _ds3 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _ds3.Tables[0], "PERIODDESC", "PERIODID", 0);

            

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
         //   LoadProjectsBasedOnZoneSelection();
        }

        private void LoadListProjectZoneWise()
        {
            listProject.Items.Clear();
            checkedListBoxCILGSTIN.Items.Clear();
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
            LoadCILGSTIN(_ds.Tables[1]);
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
            LoadCILGSTIN(_ds.Tables[1]);
        
        }

        private void LoadCILGSTIN(DataTable _dtGSTIN )
        {
         
            string _selectedGSTIN; 
            checkedListBoxCILGSTIN.Sorted = true;
            checkedListBoxCILGSTIN.Items.Clear();
            for (int i = 0; i <= _dtGSTIN.Rows.Count - 1; i++)
            {
                _selectedGSTIN = Convert.ToString(_dtGSTIN.Rows[i][0]);
                checkedListBoxCILGSTIN.Items.Add(_selectedGSTIN);
            }

            for (int i = 0; i < checkedListBoxCILGSTIN.Items.Count; i++)
                checkedListBoxCILGSTIN.SetItemChecked(i, true);

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

            LoadGSTINBasedOnProjectSelection();
        }

        private void listProject_MouseUp(object sender, MouseEventArgs e)
        {
            LoadGSTINBasedOnProjectSelection();
        }

        private void LoadGSTINBasedOnProjectSelection()
        {
            int i;
            string _searchString;
            _tableBorgs.Rows.Clear();
            DataSet _dsGSTIN;
            for (i = 0; i <= (listProject.Items.Count - 1); i++)
            {
                if (listProject.GetItemChecked(i))
                {
                    _searchString = "BORGNAME LIKE '" + listProject.Items[i].ToString().Trim() + "%'";
                    DataRow[] result = _dtProject.Select(_searchString);
                    if (result.Length > 0)
                    {
                        _tableBorgs.Rows.Add(Convert.ToString(result[0][0]));
                    }
                }
            }
            _dsGSTIN =  _gst.GetAllCILGSTIN(_tableBorgs);
            LoadCILGSTIN(_dsGSTIN.Tables[0]);

        }

        private void gridRegister_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            int  row = Convert.ToInt32((e.Inner.RowIndex) );
            int  col = Convert.ToInt32(e.Inner.ColIndex);
            if ((row >= 5) && (col >= 1))
            {
                string cellValue = "";
                Int64 _tranGrp;
                var s = this.gridRegister.Table.SelectedRecords;
                GridRangeInfoList s1 = this.gridRegister.TableModel.Selections.GetSelectedRows(true, true);
                foreach (GridRangeInfo info in s1)
                {

                    Element el = this.gridRegister.TableModel.GetDisplayElementAt(info.Top);

                    cellValue = el.GetRecord().GetValue("TRANGRP").ToString();

                }
                _tranGrp = Convert.ToInt64(cellValue);
                frmBatch _frmBatch = new frmBatch(_tranGrp);
                _frmBatch.StartPosition = FormStartPosition.CenterParent;
                _frmBatch.ShowDialog(this);
            }
        }

        private void chkDocType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDocType.Checked)
            {
                for (int i = 0; i < checkedListBoxDocType.Items.Count; i++)
                {
                    checkedListBoxDocType.SetItemChecked(i, true);
                }

            }
            else
            {
                for (int i = 0; i < checkedListBoxDocType.Items.Count; i++)
                {
                    checkedListBoxDocType.SetItemChecked(i, false);
                }

            }
        }

        private void listZone_Click(object sender, EventArgs e)
        {

        }

        private void listZone_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            LoadProjectsBasedOnZoneSelection();
        }

        

      
    

    }   
  }

