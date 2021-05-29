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
    public partial class frmOrgPeriodPermanentLock : Form
    {
        IT _it = new IT();
        CreditorAge _cg = new CreditorAge();
        DataSet _ds;
        int _CurrentFinYear;

        public frmOrgPeriodPermanentLock()
        {
            InitializeComponent();
        }

        private void ResetGrid()
        {
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

        private void LoadDetails(int _finYear)
        {
            DataSet _ds = new DataSet();
            _ds = _it.ProjectPeriodPermanentLockStatus(_finYear);
            this.gridRegister.DataSource = _ds.Tables[0];
            this.gridRegister.Refresh();
        }

        private void LoadCombo()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);

            _ds = _cg.GetFinancialYears();
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;
        }
        private void frmOrgPeriodPermanentLock_Load(object sender, EventArgs e)
        {
            ResetGrid();
            LoadCombo();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int _finYear;
            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue.ToString());
            LoadDetails(_finYear);
        }
    }
}
