using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Globalization;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms;


using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Drawing;
using Syncfusion.GridHelperClasses;

using System.Data.SqlClient;
using OfficeOpenXml;
using SQLHelper;

namespace BSMIS 
{
    public partial class frmUploadGSTOutstanding : Form
    {
        DataTable _transactionLists;

        public frmUploadGSTOutstanding()
        {
            InitializeComponent();
        }


        private void btnOpen_Click(object sender, EventArgs e)
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
                btnRead.Visible = true;
            }
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
                if (ws.Name.ToUpper() != "GST")
                {
                    MessageBox.Show("Worksheet Name Not Proper - Must be GST", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    _errorExcelFormat = 1;
                    tbl = null;
                    return tbl;
                }

                if (_errorExcelFormat == 0)
                {
                    tbl = new DataTable();
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    }

                    if (tbl.Columns[0].Caption.ToUpper() != "SUBNUMBER")
                    {
                        MessageBox.Show("Column Name 1 Not Proper - Must Be SUBNUMBER", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        _errorExcelFormat = 1;
                    }


                    if (tbl.Columns[1].Caption.ToUpper() != "AMOUNT")
                    {
                        MessageBox.Show("Column Name 2 Not Proper - Must Be AMOUNT", "Excel File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        _errorExcelFormat = 1;
                    }

                 
                    if (_errorExcelFormat == 1)
                    {
                        tbl = null;
                        return tbl;
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

                int _howmanyColumns = Convert.ToInt16(tbl.Columns.Count);
                int _allowedColumns = 2;
                int _columnsToRemove = _howmanyColumns - _allowedColumns;
                for (int i = 1; i <= _columnsToRemove; i++)
                    tbl.Columns.RemoveAt(_allowedColumns);


                return tbl;
            }
        }

        DataTable RemoveEmptyRowsFromDataTable(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][0] == DBNull.Value)
                    dt.Rows[i].Delete();
            }
            dt.AcceptChanges();
            return dt;
        }

        private void FormatGrid()
        {
            gridTransID.Visible = false;
            this.gridTransID.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridTransID.ShowGroupDropArea = false;
            this.gridTransID.TableOptions.AllowSortColumns = true;
            this.gridTransID.TopLevelGroupOptions.ShowCaption = true;
            this.gridTransID.TableOptions.RecordPreviewRowHeight = 55;
            this.gridTransID.TableOptions.ShowRowHeader = true;
            this.gridTransID.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridTransID.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridTransID.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridTransID.TableOptions.DefaultColumnWidth = 165;
            this.gridTransID.TableOptions.CaptionRowHeight = 22;
            this.gridTransID.InvalidateAllWhenListChanged = true;
            this.gridTransID.ForceDisposeOnResetDataSource = true;
            this.gridTransID.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridTransID.CacheRecordValues = false;
            this.gridTransID.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridTransID.Font = new Font("Calibri", 8.0f);
            this.gridTransID.TopLevelGroupOptions.ShowFilterBar = false;
            this.gridTransID.TableModel.Cols.FrozenCount = 7;
            this.gridTransID.TableOptions.AllowSortColumns = false;

            this.gridTransID.TopLevelGroupOptions.ShowFilterBar = false;

            this.gridTransID.Appearance.AlternateRecordFieldCell.BackColor = Color.FromArgb(255, 243, 229);
            this.gridTransID.Appearance.AlternateRecordFieldCell.Font.Bold = false;
            this.gridTransID.Appearance.AlternateRecordFieldCell.TextColor = Color.Maroon;
            this.gridTransID.TableOptions.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;

           
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
            if (firstWorksheet.Name.ToUpper() != "GST")
            {
                MessageBox.Show("First WorkSheet Not Proper. The Label Must be GST ", "Excel File Read", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            var validation = firstWorksheet.DataValidations.AddIntegerValidation("A1:A2");


            _transactionLists = new DataTable();
            _transactionLists = GetDataTableFromExcel(_fileName, true);
            if (_transactionLists != null)
            {
                RemoveEmptyRowsFromDataTable(_transactionLists);
                gridTransID.DataSource = _transactionLists;
                FormatGrid();
                gridTransID.Visible = true;
                btnRead.Enabled = false;
                btnValidate.Enabled = true;
                btnValidate.Visible = true;
              
            }

        }

        public int ValidateImportedData(DataTable _dtSales)
        {
            int _totalErrorCount = 0;
            int _row;
            int _maxRowCount = _transactionLists.Rows.Count;
            int _maxColCount = _transactionLists.Columns.Count;

            DataRow _transIDROW;
            string _currentID;
            string _loadingErrorMessage;
            int _errorInData;
            _loadingErrorMessage = "Data Error-Check Row ";

            // For each row, print the values of each column.
            _errorInData = 1;
            for (_row = 0; _row <= _maxRowCount - 1; _row++)
            {
                _transIDROW = _transactionLists.Rows[_row];

                _loadingErrorMessage = "Data Error-Check Row " + Convert.ToString(_row + 2);
                if (String.IsNullOrEmpty(_transIDROW[0] as String))
                {
                    _loadingErrorMessage = _loadingErrorMessage + "  SUBNUMBER  Cannot Be Null or Empty ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;

                }
                if (String.IsNullOrEmpty(_transIDROW[1] as String))
                {
                    _loadingErrorMessage = _loadingErrorMessage + "  AMOUNT  Cannot Be Null or Empty ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;

                }

                _currentID = Convert.ToString(_transIDROW[1]);
                if (!IsDigitsOnly(_currentID))
                {
                    _loadingErrorMessage = _loadingErrorMessage + "  AMOUNT Must be  Numeric ";
                    MessageBox.Show(_loadingErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _totalErrorCount = _totalErrorCount + 1;
                    _errorInData = 0;
                }

                


            }

            return _errorInData;
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            int _validData = ValidateImportedData(_transactionLists);
            
            if (_validData == 1)
            {
                lblValidated.Text = "Validated !!";
                btnBrowse.Enabled = false;
                lblValidated.Enabled = true;
                lblValidated.Visible = true;
                btnValidate.Enabled = false;
                btnUpload.Enabled = true;
                btnUpload.Visible = true;
            }
        }

        public bool IsDigitsOnly(string str)
        {
            int count = str.Split('.').Length - 1;
            if (count > 1)
                return false;

            foreach (char c in str)
            {

                if ((c < '0' || c > '9') && (c != '.'))
                    return false;
            }

            return true;
        }
        private void frmUploadForTransactionMatching_Load(object sender, EventArgs e)
        {
            lblValidated.Visible = false;
            btnUpload.Visible = false;
            btnRead.Visible = false;
            btnValidate.Visible = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            EmptyMatchingTable();
            SaveToTables(_transactionLists);
            MessageBox.Show("Success!!!!  All Outstanding Uploaded ");
            this.Close();
        }

        private void EmptyMatchingTable()
        {
            string _sql;
            int result;
            string _connectionString = SqlHelper.GetConnectionString();
            _sql = "DELETE FROM PB.GSTOUTSTANDING;DBCC CHECKIDENT('[PB].[GSTOUTSTANDING]',RESEED,0)";
            result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
        }

        



        public void SaveToTables(DataTable transTable)
        {
            int _maxRowCount = transTable.Rows.Count;
            DataRow _tranIDRow;
            string credno;
            decimal amount;
            int counter;
            DataTable _gstTable = new DataTable("GST");
            _gstTable.Columns.Add(new DataColumn("COUNTER", typeof(int)));
            _gstTable.Columns.Add(new DataColumn("CREDNO", typeof(string)));
            _gstTable.Columns.Add(new DataColumn("AMOUNT", typeof(Decimal)));

            for (int i = 0; i <= _maxRowCount - 1; i++)
            {
                _tranIDRow = transTable.Rows[i];
                counter = i;
                credno = Convert.ToString(_tranIDRow[0]);
                amount = Convert.ToDecimal(_tranIDRow[1]);
                _gstTable.Rows.Add(counter,credno, amount);
            }
            string _connectionString = SqlHelper.GetConnectionString();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connectionString))
            {
                bulkCopy.BulkCopyTimeout = 600; // in seconds
                bulkCopy.DestinationTableName = "PB.GSTOUTSTANDING";
                bulkCopy.WriteToServer(_gstTable);
            }
        }


    }
}
