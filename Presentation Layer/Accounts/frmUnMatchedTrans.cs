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
    public partial class frmUnMatchedTrans : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
        int _finYear;
        int _toPeriod;
        int _resetButtonClicked;
        int _selectionID;
                
        string _ExcelFileName;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataSet _dsFromYear;
        DataSet _dsToPeriod;
      
      
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();


      
        DataTable _tableProjects = new DataTable();
        DataSet _dsFinalResult;
        
        string _selectedZones;
        string _selectedProjects;

        int _runCounterDetail;
    


        string _Header1="";
        string _Header2="";
        string _Header3="";

        public frmUnMatchedTrans()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            _tableProjects.Columns.Add("BORGID", typeof(int));
            _resetButtonClicked = 0; 

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
            this.ggDetail.Font = new Font("Calibri",9.0f);
            this.ggDetail.TopLevelGroupOptions.ShowFilterBar = true;   

            btnReset.Visible = false;
            btnExport.Visible = false;

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

       

        private void ResetAllBorgsChecked()
        {
            for (int i = 0; i < listProject.Items.Count; i++)
            {
                listProject.SetItemChecked(i, true);
            }
         
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



        private void LoadCombos()
        {
            _dsFromYear = _cg.GetFinancialYearsForLedgerReports();
            UtilityFunctions.LoadWindowsCombo(cmbFromYear, _dsFromYear.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFromYear.SelectedValue = _CurrentFinYear;
            cmbFromYear.ReadOnly = false;
            _dsToPeriod = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _dsToPeriod.Tables[0], "PERIODDESC", "PERIODID", 0);
            cmbSelection.Text = "Please Select";
        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
        }


        private void frmUnMatchedTrans_Load(object sender, EventArgs e)
        {
            ActivateCurrentFinYear();
            ResetAll();
            LoadCombos();
            LoadListZone();
            LoadListProject();
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

    
            
        private void LoadDetail(DataTable _dt)
        {

            ggDetail.DataSource = _dt;

            _runCounterDetail = _runCounterDetail + 1;

            ggDetail.TableDescriptor.Columns[0].HeaderText = "TRANGRP";
            ggDetail.TableDescriptor.Columns[0].Width = 80;
            ggDetail.TableDescriptor.Columns[0].AllowFilter = false;


            ggDetail.TableDescriptor.Columns[1].HeaderText = "TRANSID";
            ggDetail.TableDescriptor.Columns[1].Width = 80;
            ggDetail.TableDescriptor.Columns[1].AllowFilter = true;

            ggDetail.TableDescriptor.Columns[2].HeaderText = "ORGID";
            ggDetail.TableDescriptor.Columns[2].Width = 80;

            ggDetail.TableDescriptor.Columns[3].HeaderText = "Project";
            ggDetail.TableDescriptor.Columns[3].Width = 200;

            ggDetail.TableDescriptor.Columns[4].HeaderText = "PartyCode";
            ggDetail.TableDescriptor.Columns[4].Width = 100;

            ggDetail.TableDescriptor.Columns[5].HeaderText = "Party";
            ggDetail.TableDescriptor.Columns[5].Width = 500;


            ggDetail.TableDescriptor.Columns[6].HeaderText = "Year";
            ggDetail.TableDescriptor.Columns[6].Width = 80;


            ggDetail.TableDescriptor.Columns[7].HeaderText = "Period";
            ggDetail.TableDescriptor.Columns[7].Width = 80;



            ggDetail.TableDescriptor.Columns[8].HeaderText = "TransDate";
            ggDetail.TableDescriptor.Columns[8].Width = 90;
            ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.CellType = "Date";


            ggDetail.TableDescriptor.Columns[9].HeaderText = "BatchRef";
            ggDetail.TableDescriptor.Columns[9].Width = 80;


            ggDetail.TableDescriptor.Columns[10].HeaderText = "TransRef";
            ggDetail.TableDescriptor.Columns[10].Width = 80;


            ggDetail.TableDescriptor.Columns[11].HeaderText = "TransType";
            ggDetail.TableDescriptor.Columns[11].Width = 80;

            ggDetail.TableDescriptor.Columns[12].HeaderText = "LedgerCode";
            ggDetail.TableDescriptor.Columns[12].Width = 80;


            ggDetail.TableDescriptor.Columns[13].HeaderText = "Description";
            ggDetail.TableDescriptor.Columns[13].Width = 255;


            ggDetail.TableDescriptor.Columns[14].HeaderText = "Debit";
            ggDetail.TableDescriptor.Columns[14].Width = 80;

            ggDetail.TableDescriptor.Columns[15].HeaderText = "Credit";
            ggDetail.TableDescriptor.Columns[15].Width = 80;
            ggDetail.TableDescriptor.Columns[15].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[16].HeaderText = "Credit";
            ggDetail.TableDescriptor.Columns[16].Width =0;
            ggDetail.TableDescriptor.Columns[16].Appearance.AnyCell.Format = "F2";

            ggDetail.TableDescriptor.Columns[17].HeaderText = "Credit";
            ggDetail.TableDescriptor.Columns[17].Width = 0;

          


        }

     

    
        private void btnReset_Click(object sender, EventArgs e)
        {
            frmReportPreviewLedgers _frmReportPreviewLedgers = new frmReportPreviewLedgers(_dsFinalResult);
            _frmReportPreviewLedgers.Show();
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

                            switch (_tableCount)
                            {
                                case 1:
                                    ws.Cells[7, colstart, 7, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    ws.Column(3).Style.Numberformat.Format = "dd/MM/yyyy";
                                    ws.Column(3).Width = 13;
                                    break;

                                case 2:
                                    ws.Cells[7, colstart, 7, 6 ].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                                case 3:
                                    ws.Cells[7, colstart, 7, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                            }
                            
                          


                           
                            
                        }
                        

                        
                        Byte[] bin = xp.GetAsByteArray();
                        string _directoryName =@"C:\MIS\ExcelFiles\";
                        string _fileName="UnMatched";
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
       
            _finYear = Convert.ToInt16(cmbFromYear.SelectedValue.ToString());
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue.ToString());

            string _masterName;
            _masterName = Convert.ToString(cmbSelection.Text);
            if (_masterName == "Suppliers")
                _selectionID = 1;
            else
                _selectionID = 2;

            _dsFinalResult = new DataSet();
            _dsFinalResult = _cg.FetchUnMatchedTransactions(_tableProjects, _finYear,  _toPeriod, _selectionID);
            LoadDetail(_dsFinalResult.Tables[0]);


            ggDetail.Visible = true;
            ggDetail.Refresh();

            
            
            DateTime time = DateTime.Now;
            string format = "dddd, MMMM dd, yyyy h:mm:ss tt";
            _Header3 = "Report Generated On " + Convert.ToString(time.ToString(format)); 

        //    ReformatResultSet();
            DisableButtons(2);
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

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            btnExport.Visible = false;
            ggDetail.Visible = false;
            btnGenerate.Visible = true;
            _resetButtonClicked = 1; 
        }

       

     

      


        private void cmbSelection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            string _masterName;
            _masterName = Convert.ToString(cmbSelection.Text);
            if (_masterName == "Supplliers")
                _selectionID = 1;
            else
                _selectionID = 2;
        }


      

     
       

    }   
  }

