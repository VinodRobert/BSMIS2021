﻿using System;
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
    public partial class frmOtherLedger : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
        int _fromYear;
        int _toYear;
        int _fromPeriod;
        int _toPeriod;
        int _resetButtonClicked; 
        
                
        string _ExcelFileName;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        DataSet _dsFromYear;
        DataSet _dsToYear;
        DataSet _dsFromPeriod;
        DataSet _dsToPeriod;
        DataSet _dsLedgers;
       

        DataTable _dtLedgers = new DataTable();
        DataTable _dtZone = new DataTable();
        DataTable _dtProject = new DataTable();


        DataTable _tableCreditors = new DataTable();
        DataTable _tableProjects = new DataTable();

        DataTable _resultDetailed = new DataTable();
        DataTable _resultProjectWise = new DataTable();
        DataTable _resultSupplierWise = new DataTable();

        DataSet _dsFinalResult;
        

      
        string _selectedZones;
        string _selectedProjects;

        
    


        string _Header1;
        string _Header2;
        string _Header3;

        public frmOtherLedger()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
           

            _tableCreditors.Columns.Add("CredNumber", typeof(string));
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
        }



        private void LoadCombos()
        {
            cmbParty.Visible = false;
            cmbParty.Sorted = false;

            _dsFromYear = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFromYear, _dsFromYear.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFromYear.SelectedValue = _CurrentFinYear;

            _dsToYear = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbToYear, _dsToYear.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbToYear.SelectedValue = _CurrentFinYear;

            _dsFromPeriod = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _dsFromPeriod.Tables[0], "PERIODDESC", "PERIODID", 0);

            _dsToPeriod = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _dsToPeriod.Tables[0], "PERIODDESC", "PERIODID", 0);

      
            _dsLedgers = _cg.LoadOtherLedgers();
            cmbParty.Items.Clear();
            UtilityFunctions.LoadWindowsCombo(cmbParty, _dsLedgers.Tables[0], "LEDGERNAME", "LEDGERCODE", 0);
            cmbParty.SelectedValue = 0;

            cmbParty.Visible = true;
          
      
        }
            

            
    

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
        }


        private void frmMastersLedger_Load(object sender, EventArgs e)
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
        
          

                ggDetail.TableDescriptor.Columns[0].HeaderText = "SlNo";
                ggDetail.TableDescriptor.Columns[0].Width = 50;
                ggDetail.TableDescriptor.Columns[0].AllowFilter = false;


                ggDetail.TableDescriptor.Columns[1].HeaderText = "Project";
                ggDetail.TableDescriptor.Columns[1].Width = 190;
                ggDetail.TableDescriptor.Columns[1].AllowFilter = true;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "TransDate";
                ggDetail.TableDescriptor.Columns[2].Appearance.AnyCell.CellType = "Date";
                ggDetail.TableDescriptor.Columns[2].Width = 70;

                ggDetail.TableDescriptor.Columns[3].HeaderText = "Narration";
                ggDetail.TableDescriptor.Columns[3].Width = 350;

                ggDetail.TableDescriptor.Columns[4].HeaderText = "TransType";
                ggDetail.TableDescriptor.Columns[4].Width = 70;

                ggDetail.TableDescriptor.Columns[5].HeaderText = "Invoice/Chq Number";
                ggDetail.TableDescriptor.Columns[5].Width = 150;

             
                ggDetail.TableDescriptor.Columns[6].HeaderText = "Debit";
                ggDetail.TableDescriptor.Columns[6].Width = 100;
                ggDetail.TableDescriptor.Columns[6].Appearance.AnyCell.Format = "F2";

                ggDetail.TableDescriptor.Columns[7].HeaderText = "Credit";
                ggDetail.TableDescriptor.Columns[7].Width = 100;
                ggDetail.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[8].HeaderText = "Closing Balance";
                ggDetail.TableDescriptor.Columns[8].Width = 100;
                ggDetail.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";


                ggDetail.TableDescriptor.Columns[9].HeaderText = "Sign";
                ggDetail.TableDescriptor.Columns[9].Width = 50;
               

                ggDetail.TableDescriptor.Columns[10].HeaderText = "Party Name";
                ggDetail.TableDescriptor.Columns[10].Width = 0;


                ggDetail.TableDescriptor.Columns[11].HeaderText = "Report Period";
                ggDetail.TableDescriptor.Columns[11].Width = 0;



                if (_resetButtonClicked == 0)
                {


                    GridSummaryColumnDescriptor scd0 = new GridSummaryColumnDescriptor("Sum0", SummaryType.DoubleAggregate, "DEBIT", "{Sum:#.00}");
                    GridSummaryColumnDescriptor scd1 = new GridSummaryColumnDescriptor("Sum1", SummaryType.DoubleAggregate, "CREDIT", "{Sum:#.00}");
                

                    scd0.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                    scd0.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                    scd1.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Right;
                    scd1.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(192, 255, 162));
                    GridSummaryRowDescriptor srd = new GridSummaryRowDescriptor("Sum", "Total", new GridSummaryColumnDescriptor[] { scd0, scd1 });
                    srd.Appearance.AnyCell.Format = "F2";
                    srd.Appearance.AnySummaryCell.Interior = new BrushInfo(Color.FromArgb(255, 231, 162));

                    this.ggDetail.TableDescriptor.SummaryRows.Add(srd);
                    this.ggDetail.TableDescriptor.Columns[5].AllowGroupByColumn = false;

                }

             
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
                                    ws.Column(9).Style.Numberformat.Format = "dd/MM/yyyy";
                                    ws.Column(9).Width = 13;
                                    break;

                                case 2:
                                    ws.Cells[7, colstart, 7, 6 ].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                                case 3:
                                    ws.Cells[7, colstart, 7, 3].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                    break;
                            }
                            
                          


                            ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                               ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            if (_tableCount == 1)
                            {
                                ws.Cells[_totaRow, 6].Value = "Total ... ";
                                ws.Cells[_totaRow, 10].Formula = "+SUM(J8:J" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 12].Formula = "+SUM(L8:L" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 13].Formula = "+SUM(M8:M" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 14].Formula = "+SUM(N8:N" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 15].Formula = "+SUM(O8:O" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 16].Formula = "+SUM(P8:P" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 17].Formula = "+SUM(Q8:Q" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 18].Formula = "+SUM(R8:R" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 19].Formula = "+SUM(S8:S" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 20].Formula = "+SUM(T8:T" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 21].Formula = "+SUM(U8:U" + (_recordCount + 7) + ")";
                                ws.Cells[_totaRow, 10, _totaRow, 10].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                ws.Cells[_totaRow, 12, _totaRow, 21].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                            
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Font.Bold = true;
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                ws.Cells[_totaRow, 2, _totaRow, 21].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink);

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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateResult();
        }

   

        private void GenerateResult()
        {
             DisableButtons(1);
             DoPreparatoryWorks();
       
            _fromYear = Convert.ToInt16(cmbFromYear.SelectedValue.ToString());
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue.ToString());
            _toYear = Convert.ToInt16(cmbToYear.SelectedValue.ToString());
            _toPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue.ToString());
          
            string  _ledgercode ;
            _ledgercode = Convert.ToString(cmbParty.SelectedValue.ToString());

            _dsFinalResult = new DataSet();
            _dsFinalResult = _cg.GetOtherLedgerSummary(_tableProjects, _ledgercode, _fromYear, _fromPeriod, _toYear, _toPeriod);
            LoadDetail(_dsFinalResult.Tables[0]);
        

            ggDetail.Visible = true;
            ggDetail.Refresh();

            //Form1 _fn = new Form1(_dsFinalResult);
            //_fn.Show();
            
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
            btnReset.Visible = false;
            ggDetail.Visible = false;
            btnGenerate.Visible = true;
            _resetButtonClicked = 1; 
        }

    

        


       


      

     
       

    }   
  }

