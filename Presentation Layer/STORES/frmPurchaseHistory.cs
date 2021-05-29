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
    public partial class frmPurchaseHistory : Form
    {
      
  
        int _countSelectedProjects = 0;
       
     
        string _ExcelFileName;

        Entities _ent = new Entities();

        Stores _st = new Stores();
        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataSet _dsFinalResult;
        DataTable _dtInventory = new DataTable();
        DataTable _dtStockCodeTable = new DataTable();
       
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();
        DataTable _tableInventory = new DataTable();
        DataTable _tableProjects = new DataTable();

        int _OrgnizationIDSelected; 
        string _selectedInventory;
        string _selectedZones;
        string _selectedProjects;

        string _Header1;
        string _Header2;
        string _Header3;

        public frmPurchaseHistory()
        {
            InitializeComponent();
        }

       

        private void LoadListInventory()
        {
            string _stockCode;
            _dtStockCodeTable.Columns.Add("StockCode", typeof(string));
            
            _ds = _st.GetFullInventory();

            _dtInventory = _ds.Tables[0];

            listInventory.Sorted = true;

            for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
            {
                _selectedInventory = Convert.ToString(_ds.Tables[0].Rows[i][1]);
                _stockCode = Convert.ToString(_ds.Tables[0].Rows[i][0]);

                _dtStockCodeTable.Rows.Add(_stockCode);
                listInventory.Items.Add(_selectedInventory);
            }

            for (int i = 0; i < listInventory.Items.Count; i++)
                listInventory.SetItemChecked(i, false);

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
                listZone.SetItemChecked(i, false);


            chkUnchkZone.Checked = false;

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
                listProject.SetItemChecked(i, false);

            chkUnChkProject.Checked = false;
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
                listProject.SetItemChecked(i, false);

            chkUnChkProject.Checked = false;
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

        private void ResetAllCreditorsChecked()
        {
            for (int i = 0; i < listInventory.Items.Count; i++)
            {
                listInventory.SetItemChecked(i, true);
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
                for (int i = 0; i < listInventory.Items.Count; i++)
                {
                    listInventory.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listInventory.Items.Count; i++)
                {
                    listInventory.SetItemChecked(i, false);
                }
            }
        }


        public void ResetAll()
        {
           
            btnReset.Visible = false;
            btnExport.Visible = false;


            _tableInventory.Columns.Add("STKCODE", typeof(String)); 
            _tableProjects.Columns.Add("BORGID", typeof(int));

            txtSearchCreditor.ForeColor = Color.Red;

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

                            if (_tableCount == 1)
                            {
                                ws.Column(7).Style.Numberformat.Format = "dd/MM/yyyy";
                                ws.Column(7).Width = 13;
                            }
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
            GenerateResult();
        }


        private void GenerateResult()
        {
            DisableButtons(1);
            DoPreparatoryWorks();

            if (_countSelectedProjects > 1)
            {
                MessageBox.Show("You Can Select Only ONE Project For This Report",    "Warning !",    MessageBoxButtons.OK,     MessageBoxIcon.Exclamation,  MessageBoxDefaultButton.Button1);
                btnGenerate.Visible = true; 
                return;
            }

            if (_countSelectedProjects == 0 )
            {
                MessageBox.Show("Select One Project ", "Warning !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                btnGenerate.Visible = true;
                return;
            }

            DataTable _dt;

            _dsFinalResult = new DataSet();
            _dt = new DataTable();
            _dsFinalResult = _st.StockMovement(_tableInventory, _OrgnizationIDSelected);
            _dsFinalResult.Tables[0].TableName = "Detail";
         //   _dsFinalResult.Tables[1].TableName = "Summary";

            _dt = _dsFinalResult.Tables[0];



            _Header1 = "Capacite Infra Projects - Stock Movement Report ";
            _Header2 = "Live Stock Position ";
            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format));

        


            DisableButtons(2);
           
            LoadDetail(_dt);
          
        }
          private void DoPreparatoryWorks()
        {
            GeneateInventoryTable();
            GeneateOrgTable();
        }

        private void txtSearchCreditor_TextChanged(object sender, EventArgs e)
        {

            int i;
            i = listInventory.FindString(txtSearchCreditor.Text);
            if (i >= 0)
                listInventory.SelectedItem = listInventory.Items[i];
        }

        private void GeneateInventoryTable()
        {
            int i;
          
            string _selectedStockCode;
            _tableInventory.Rows.Clear();
            for (i = 0; i <= (listInventory.Items.Count - 1); i++)
            {
                if (listInventory.GetItemChecked(i))
                {
                  
                    _selectedStockCode = Convert.ToString(_dtStockCodeTable.Rows[i][0]);
                    _tableInventory.Rows.Add(_selectedStockCode);
                   
                }
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
                        _OrgnizationIDSelected = Convert.ToInt16(result[0][0]);
                        _countSelectedProjects = _countSelectedProjects + 1;
                    }
                }
            }
        }
 
						 
                           
							 



        private void LoadDetail(DataTable _dt)
        {
            gridRegister.DataSource = _dt;
             
            
            gridRegister.TableDescriptor.Columns[0].HeaderText = "Store";
            gridRegister.TableDescriptor.Columns[0].Width = 100;
            gridRegister.TableDescriptor.Columns[0].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[0].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[1].HeaderText = "Stock Code";
            gridRegister.TableDescriptor.Columns[1].Width = 60;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[1].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[2].HeaderText = "Stock Name";
            gridRegister.TableDescriptor.Columns[2].Width = 150;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[2].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[3].HeaderText = "Unit";
            gridRegister.TableDescriptor.Columns[3].Width = 40;
            gridRegister.TableDescriptor.Columns[3].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[3].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[4].HeaderText = "Live";
            gridRegister.TableDescriptor.Columns[4].Width = 80;
            gridRegister.TableDescriptor.Columns[4].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[4].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[5].HeaderText = "Rate";
            gridRegister.TableDescriptor.Columns[5].Width = 50;
            gridRegister.TableDescriptor.Columns[5].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[5].AllowFilter = false;

            gridRegister.TableDescriptor.Columns[6].HeaderText = "Stock Value";
            gridRegister.TableDescriptor.Columns[6].Width = 80;
            gridRegister.TableDescriptor.Columns[6].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";
            gridRegister.TableDescriptor.Columns[6].AllowFilter = false;

       
            gridRegister.TableDescriptor.Columns[7].HeaderText = "Receipts";
            gridRegister.TableDescriptor.Columns[7].Width = 80;
            gridRegister.TableDescriptor.Columns[7].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[8].HeaderText = "Rec.Value";
            gridRegister.TableDescriptor.Columns[8].Width = 80;
            gridRegister.TableDescriptor.Columns[8].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[9].HeaderText = "Issue";
            gridRegister.TableDescriptor.Columns[9].Width = 80;
            gridRegister.TableDescriptor.Columns[9].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[9].Appearance.AnyCell.Format = "F2";
          
            gridRegister.TableDescriptor.Columns[10].HeaderText = "Iss.Value";
            gridRegister.TableDescriptor.Columns[10].Width = 80;
            gridRegister.TableDescriptor.Columns[10].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";


            gridRegister.TableDescriptor.Columns[11].HeaderText = "TransferIn";
            gridRegister.TableDescriptor.Columns[11].Width = 80;
            gridRegister.TableDescriptor.Columns[11].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";
          
            gridRegister.TableDescriptor.Columns[12].HeaderText = "TrIn Value";
            gridRegister.TableDescriptor.Columns[12].Width = 80;
            gridRegister.TableDescriptor.Columns[12].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[12].Appearance.AnyCell.Format = "F2";


            gridRegister.TableDescriptor.Columns[13].HeaderText = "TransferOut";
            gridRegister.TableDescriptor.Columns[13].Width = 80;
            gridRegister.TableDescriptor.Columns[13].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[13].Appearance.AnyCell.Format = "F2";
          
            gridRegister.TableDescriptor.Columns[14].HeaderText = "TrOutValue";
            gridRegister.TableDescriptor.Columns[14].Width = 80;
            gridRegister.TableDescriptor.Columns[14].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[14].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[15].HeaderText = "DeliveryPending";
            gridRegister.TableDescriptor.Columns[15].Width = 80;
            gridRegister.TableDescriptor.Columns[15].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[15].Appearance.AnyCell.Format = "F2";
          
            gridRegister.TableDescriptor.Columns[16].HeaderText = "DelPendValue";
            gridRegister.TableDescriptor.Columns[16].Width = 80;
            gridRegister.TableDescriptor.Columns[16].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[17].HeaderText = "OpenPR";
            gridRegister.TableDescriptor.Columns[17].Width = 80;
            gridRegister.TableDescriptor.Columns[17].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[17].Appearance.AnyCell.Format = "F2";
          
            gridRegister.TableDescriptor.Columns[18].HeaderText = "OpenPRValue";
            gridRegister.TableDescriptor.Columns[18].Width = 80;
            gridRegister.TableDescriptor.Columns[18].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[18].Appearance.AnyCell.Format = "F2";
            gridRegister.Visible = true; 

        }

        private void DisableButtons(int i)
        {
            if (i == 1)
              {
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = false;
                
              }
             if (i==2) 
               {
                btnGenerate.Visible = false;
                btnClose.Visible = true;
                btnExport.Visible = true;
                btnReset.Visible = true;
               }

             if (i == 0)
              {
                  btnGenerate.Visible = true;
                  btnClose.Visible = true;
                  btnExport.Visible = false;
                  btnReset.Visible = false;
                  gridRegister.Visible = false;
                  _countSelectedProjects = 0;
              }

          
           
        }

        private void frmStockAging_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Stock Movement";
            ResetAll();
            LoadListInventory();
            LoadListZone();
            LoadListProject();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportStockMovement _frmReportStockMovement = new frmReportStockMovement(_dsFinalResult);
            _frmReportStockMovement.Show();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            //int i;

            //int _firstHit = 0; 
            //for (i = 0; i <= (listInventory.Items.Count - 1); i++)
            //{
            //    if ( (listInventory.GetItemChecked(i)) && _firstHit=1
            //    {

            //        _selectedStockCode = Convert.ToString(_dtStockCodeTable.Rows[i][0]);
            //        _tableInventory.Rows.Add(_selectedStockCode);

            //    }
            //}
        }
}

        

     

    

    }   
  

