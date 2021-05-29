using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSMIS
{
    public partial class frmMasterCategoryList : Form
    {
        Masters ma = new Masters();
        DataTable attributeList;
        string[] CATEGORY;
        string[] PARTYCODE;

        public frmMasterCategoryList()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\Budget\Excel\";
            openFileDialog1.Title = "Browse Excel Files Files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "xlsx";
            openFileDialog1.Filter = "Excel files (*.xls)|*.xlsx";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = openFileDialog1.FileName;
                lblFileName.Visible = true;
            }
            if (lblFileName.Text != "")
            {
                btnRead.Enabled = true;
            }
            btnRead.Enabled = true;

        }

        private void ResetAll()
        {
            btnBrowse.Enabled = true;
            btnRead.Enabled = false;
            btnUpload.Enabled = false;
            btnValidate.Enabled = false;

        }
        private void frmMasterCategoryList_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        public DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            int _errorExcelFormat;
            _errorExcelFormat = 0;
            DataTable tbl = new DataTable();
            tbl = null;
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                if (ws.Name.ToUpper() != "CATEGORY")
                {
                    MessageBox.Show("Worksheet Name Not Proper - Must be CATEGORY", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    _errorExcelFormat = 1;
                }

                if (_errorExcelFormat == 0)
                {
                    tbl = new DataTable();
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }

                    if (tbl.Columns[0].Caption.ToUpper() != "PARTY CODE")
                    {
                        MessageBox.Show("Column Name 1 Not Proper - Must Be PARTYCODE", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        _errorExcelFormat = 1;
                    }

                    if (tbl.Columns[1].Caption.ToUpper() != "PARTY NAME")
                    {
                        MessageBox.Show("Column Name 1 Not Proper - Must Be PARTYNAME", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        _errorExcelFormat = 1;
                    }


                    if (tbl.Columns[2].Caption.ToUpper() != "CATEGORY")
                    {
                        MessageBox.Show("Column Name 2 Not Proper - Must Be CATEGORY", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        _errorExcelFormat = 1;
                    }

                    if (_errorExcelFormat == 1)
                    {
                        tbl = null;
                    }
                    else
                    {
                        var startRow = hasHeader ? 2 : 1;
                        for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                        {
                            var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                            DataRow row = tbl.Rows.Add();
                            foreach (var cell in wsRow)
                            {
                                row[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                    }
                }

                // Removal of Unwanted Colums 
                if (_errorExcelFormat == 0)
                {
                    int _howmanyColumns = Convert.ToInt16(tbl.Columns.Count);
                    int _allowedColumns = 3;
                    int _columnsToRemove = _howmanyColumns - _allowedColumns;
                    for (int i = 1; i <= _columnsToRemove; i++)
                        tbl.Columns.RemoveAt(_allowedColumns);
                }

                return tbl;
            }
        }

        DataTable RemoveEmptyRowsFromDataTable(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][1] == DBNull.Value)
                    dt.Rows[i].Delete();
            }
            dt.AcceptChanges();
            return dt;
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            string _fileName = lblFileName.Text.Trim();
            FileInfo newFile = new FileInfo(_fileName);
            ExcelPackage pck;
            try
            {
                pck = new ExcelPackage(newFile);
            }
            catch
            {
                MessageBox.Show("Unable to Read File", "Excel File Open", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return; ;
            }

            ExcelWorksheet firstWorksheet = pck.Workbook.Worksheets[1];
            if (firstWorksheet.Name.ToUpper() != "CATEGORY")
            {
                MessageBox.Show("First WorkSheet Not Proper-Must Be CATEGORY ", "Excel File Read", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            var validation = firstWorksheet.DataValidations.AddIntegerValidation("A1:A2");

            try
            {
                attributeList = new DataTable();
                attributeList = GetDataTableFromExcel(_fileName, true);
                if (attributeList != null)
                {
                    RemoveEmptyRowsFromDataTable(attributeList);
                    btnRead.Enabled = false;
                    btnValidate.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Check you Excel File. Contains Refernces,Formuala,Special Characters etc ", "Excel File Read", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        public void LoadMasterCategory()
        {
            int masterCategoryCode;
            if (cmbMaterType.SelectedIndex == 1)
                masterCategoryCode = 1;
            else
                masterCategoryCode = 2;

            DataTable dtCategory = ma.GetMasterCategory(masterCategoryCode).Tables[0];
            int columnIndex = 1;
            CATEGORY = new string[dtCategory.Rows.Count];
            for (int i = 0; i < dtCategory.Rows.Count; i++)
            {
                CATEGORY[i] = dtCategory.Rows[i][columnIndex].ToString();
            }
        }

        public void LoadPartyCodes()
        {
            DataTable dtParty;
            if (cmbMaterType.SelectedIndex == 0)
                dtParty = ma.GetPartyCodes(1).Tables[0];
            else
                dtParty = ma.GetPartyCodes(2).Tables[0];
            int columnIndex = 0;
            PARTYCODE = new string[dtParty.Rows.Count];
            for (int i = 0; i < dtParty.Rows.Count; i++)
            {
                PARTYCODE[i] = dtParty.Rows[i][columnIndex].ToString();
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            int _validData = ValidateImportedData(attributeList);
            if (_validData == 1)
            {
                btnBrowse.Enabled = false;
                lblValidated.Enabled = true;
                lblValidated.Visible = true;
                btnValidate.Enabled = false;

            }
        }

        public int SearchCategory(String _searchCategory)
        {
            foreach (string x in CATEGORY)
            {
                if (string.Equals(x, _searchCategory))
                {
                    return 0;
                }
            }
            return 1;
        }

        public int SearchParty(String _searchPartyCode)
        {
            foreach (string x in PARTYCODE)
            {
                if (string.Equals(x, _searchPartyCode))
                {
                    return 0;
                }
            }
            return 1;
        }

        public int ValidateImportedData(DataTable _dt)
        {
            string partyCode;
            string categoryCode;
            int _totalErrorCount = 0;
            int _errorInData = 0;
            string _loadingErrorMessage;
            int _maxRowCount = _dt.Rows.Count;
            int _maxColCount = _dt.Columns.Count;

            DataRow row;
            _loadingErrorMessage = "Data Error-Check Row ";


            _errorInData = 1;
            for (int r = 0; r <= _maxRowCount - 1; r++)
            {
                row = _dt.Rows[r];


                if (String.IsNullOrEmpty(row[0] as String))
                {
                    _loadingErrorMessage = "Data Error-Check Row " + Convert.ToString(r + 1) + "  PartyCode  Cannot Be Null or Empty ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;

                }


                partyCode = Convert.ToString(row[0]);
                categoryCode = Convert.ToString(row[1]);

                int _validToolCode = SearchCategory(categoryCode);
                if (_validToolCode == 1)
                {
                    _loadingErrorMessage = _loadingErrorMessage + "  Invalid Category Code  ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;

                }


                int _validPartyCodes = SearchParty(partyCode);
                if (_validPartyCodes == 1)
                {
                    _loadingErrorMessage = _loadingErrorMessage + "  Invalid Party Code  ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;

                }
            }

            if (_totalErrorCount > 5)
            {
                MessageBox.Show("Total Error Count > 5. Fix and Read Once Again. Exiting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnValidate.Enabled = false;
                btnBrowse.Enabled = false;
                return _errorInData;
            }


            return _errorInData;
        }



        private void btnGetIt_Click(object sender, EventArgs e)
        {

            if (btnGetIt.Text == "Please Select")
                return;
            LoadMasterCategory();
            LoadPartyCodes();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string attribute;
            string partyCode;
            int success;
            for ( int i=0;i<=attributeList.Rows.Count-1;i++)
            {
                attribute = Convert.ToString(attributeList.Rows[i][0]);
                partyCode = Convert.ToString(attributeList.Rows[i][1]);

                success = ma.UpdateMasterCategory(partyCode, attribute);
            }
        }
    }

}