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
    public partial class frmAssetLocation : Form
    {
        string _ExcelFileName;

        Entities _ent = new Entities();
        Assets _as = new Assets();

        

        
        DataSet _dsFinalResult;
        

        

        string _Header1;
        string _Header2;
        string _Header3;

        public frmAssetLocation()
        {
            InitializeComponent();
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
                ggDetail.TableDescriptor.Columns[0].HeaderText = "Asset ID";
                ggDetail.TableDescriptor.Columns[0].Width = 80;
                ggDetail.TableDescriptor.Columns[0].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[0].AllowFilter = false;

                ggDetail.TableDescriptor.Columns[1].HeaderText = "Asset Number";
                ggDetail.TableDescriptor.Columns[1].Width = 120;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "Asset Name";
                ggDetail.TableDescriptor.Columns[2].Width = 200;
                ggDetail.TableDescriptor.Columns[2].AllowFilter = true;
                ggDetail.TableDescriptor.Columns[2].AllowGroupByColumn = false;
                


                ggDetail.TableDescriptor.Columns[3].HeaderText = "Asset Category";
                ggDetail.TableDescriptor.Columns[3].Width = 175;
                ggDetail.TableDescriptor.Columns[2].AllowGroupByColumn = true;

                ggDetail.TableDescriptor.Columns[4].HeaderText = "Asset Location";
                ggDetail.TableDescriptor.Columns[4].Width = 150;
                ggDetail.TableDescriptor.Columns[4].AllowFilter = true;
                ggDetail.TableDescriptor.Columns[4].AllowGroupByColumn = true;

             
           
             
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

                           
                          
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="AssetLocation";
                         
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
       
        private void GenerateResult(string _assetCategory,string _projectLocation)
        {
            _dsFinalResult = _as.GetAssetsWithLocation(_assetCategory,_projectLocation);
            _Header1 = "Capacite Infra Projects - Asset Master";
            _Header2 = _projectLocation;
          

            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 
            ReformatResultSet();
            LoadDetail(_dsFinalResult.Tables[0]);
            ggDetail.Visible = true;
            btnExport.Visible = true; 

        }
       
        private void ReformatResultSet()
        {
            _dsFinalResult.Tables[0].TableName = "Asset Master";
      

            _dsFinalResult.Tables[0].Columns[0].Caption = "Asset ID";
            _dsFinalResult.Tables[0].Columns[1].Caption = "Asset Number";
            _dsFinalResult.Tables[0].Columns[2].Caption = "Asset Name";
            _dsFinalResult.Tables[0].Columns[3].Caption = "Asset Category";
            _dsFinalResult.Tables[0].Columns[4].Caption = "Asset Location";
           
        }
       private void frmAssetMaster_Load(object sender, EventArgs e)
       {
           LoadCombo();
       }

       private void LoadCombo()
       {
           DataSet _dsLocation = new DataSet();
           _dsLocation = _as.GetProjectLocations();
           UtilityFunctions.LoadWindowsCombo(cmbAssetLocation, _dsLocation.Tables[0], "BORGNAME", "PROJECTCODE", 1);
           cmbAssetLocation.SelectedIndex = 0;

           DataSet _dsCategory = new DataSet();
           _dsCategory = _as.FetchAssetCategories();
           UtilityFunctions.LoadWindowsCombo(cmbAssetCategory, _dsCategory.Tables[0], "AssetCategory", "AssetOppLedgerCode", 1);
           cmbAssetLocation.SelectedIndex = 0;
       }


       private void btnShow_Click(object sender, EventArgs e)
       {
           string _projectLocation = Convert.ToString(cmbAssetLocation.SelectedIndex);
           string _assetCategory = Convert.ToString(cmbAssetCategory.SelectedIndex);
         
           _assetCategory = Convert.ToString(cmbAssetCategory.SelectedValue);
           _projectLocation = Convert.ToString(cmbAssetLocation.SelectedValue);
           GenerateResult(_assetCategory,_projectLocation);
       }

       

        

         

       

    }   
  }

