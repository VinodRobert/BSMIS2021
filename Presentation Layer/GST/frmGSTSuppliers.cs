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
    public partial class frmGSTSuppliers : Form
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

        public frmGSTSuppliers()
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
                            
                            dt.TableName = " GST Supplier Summary  ";
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
                        string _fileName="PurchaseRegister";
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
    
       
 

        private void GenerateResult()
        {
            DisableButtons(1);
            int _fromPeriod;
            int _toPeriod;
            string  _ledgerCode; 
            int _finYear;
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _ledgerCode = Convert.ToString(cmbGSTTypes.SelectedValue);
            _dsFinalResult = _gst.GSSuppliers(_finYear, _fromPeriod, _toPeriod, _tableProjects, _ledgerCode );
     
               

            DataTable _dt;
            _dt = _dsFinalResult.Tables[0];



            _Header1 = "Capacite Infra Projects - GST Purchase Register ";
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
            gridRegister.TableDescriptor.Columns[1].Width =  65;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[2].HeaderText = "Borg Name";
            gridRegister.TableDescriptor.Columns[2].Width = 190;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[2].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[3].HeaderText = "CIL GSTIN";
            gridRegister.TableDescriptor.Columns[3].Width = 100;
            gridRegister.TableDescriptor.Columns[3].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[3].AllowGroupByColumn = true;


            gridRegister.TableDescriptor.Columns[4].HeaderText = "SuppCode";
            gridRegister.TableDescriptor.Columns[4].Width = 80;
            gridRegister.TableDescriptor.Columns[4].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[4].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[5].HeaderText = "Supplier";
            gridRegister.TableDescriptor.Columns[5].Width = 155;
            gridRegister.TableDescriptor.Columns[5].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[5].AllowGroupByColumn = true;


            gridRegister.TableDescriptor.Columns[6].HeaderText = "Supp GSTIN";
            gridRegister.TableDescriptor.Columns[6].Width = 80;
            gridRegister.TableDescriptor.Columns[6].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[6].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[7].HeaderText = "Supplier City";
            gridRegister.TableDescriptor.Columns[7].Width = 80;
            gridRegister.TableDescriptor.Columns[7].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[7].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[8].HeaderText = "Debit";
            gridRegister.TableDescriptor.Columns[8].Width = 100;
            gridRegister.TableDescriptor.Columns[8].AllowGroupByColumn = true;
            gridRegister.TableDescriptor.Columns[8].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";


            gridRegister.TableDescriptor.Columns[9].HeaderText = "Credit";
            gridRegister.TableDescriptor.Columns[9].Width = 100;
            gridRegister.TableDescriptor.Columns[9].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[9].AllowGroupByColumn = true;
            gridRegister.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";
       
            gridRegister.TableDescriptor.Columns[10].HeaderText = "Ledger";
            gridRegister.TableDescriptor.Columns[10].Width = 50;
            gridRegister.TableDescriptor.Columns[10].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[11].HeaderText = "Ledger Name ";
            gridRegister.TableDescriptor.Columns[11].Width = 150;
            gridRegister.TableDescriptor.Columns[11].AllowFilter = true;
         
           
          


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
            }
        }

        private void frmGSTPurchase_Load(object sender, EventArgs e)
        {
            _tableProjects.Columns.Add("BORGID", typeof(int));
            _tableBorgs.Columns.Add("BORGID", typeof(int));
            

            ActivateCurrentFinYear();
            LoadCombos();
            LoadListZone();
            LoadListProject();
          
            SetupGrid();
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
            DataSet _ds4;
            _ds1 = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;


            _ds2 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);

            _ds3 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _ds3.Tables[0], "PERIODDESC", "PERIODID", 0);

            _ds4 = _cg.GetGSTLedgers();
            UtilityFunctions.LoadWindowsCombo(cmbGSTTypes, _ds4.Tables[0], "NAME", "LEDGERCODE", 0);

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
            

        }

     

        

      
    

    }   
  }

