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
    public partial class frmIPLA : Form
    {
        int _CurrentFinYear;
        int _CurrentMonth;
        string _CurrentMonthName;
        DataSet _dsFinalResult;
        string _ExcelFileName;

        Entities _ent = new Entities();

        CreditorAge _cg = new CreditorAge();
        DataSet _ds;

        public frmIPLA()
        {
            InitializeComponent();
        }

        public void ActivateCurrentFinYear()
        {
            _ds = _cg.GetActiveFinYear();
            _CurrentFinYear = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            _CurrentMonth = Convert.ToInt16(_ds.Tables[0].Rows[0][1]);
            _CurrentMonthName = Convert.ToString(_ds.Tables[0].Rows[0][1]);
        }

        private void LoadCombos()
        {
            DataSet _ds1;
            DataSet _ds2;
            DataSet _ds3;
            DataSet _ds4;
            _ds1 = _cg.GetActiveFinancialYears(_CurrentFinYear);
            UtilityFunctions.LoadWindowsCombo(cmbFinYear, _ds1.Tables[0], "FINYEAR", "FINYEAR", 0);
            cmbFinYear.SelectedValue = _CurrentFinYear;
            _ds2 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbFromPeriod, _ds2.Tables[0], "PERIODDESC", "PERIODID", 0);
            _ds3 = _cg.GetPeriods();
            UtilityFunctions.LoadWindowsCombo(cmbToPeriod, _ds3.Tables[0], "PERIODDESC", "PERIODID", 0);
            _ds4 = _cg.GetFullProjects();
            UtilityFunctions.LoadWindowsCombo(cmbBorgs, _ds4.Tables[0], "BORGNAME", "BORGID", 0);
        }

        public void ResetAll()
        {
            ggDetail.Visible = false;
            this.ggDetail.ActivateCurrentCellBehavior = GridCellActivateAction.None;
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
            this.ggDetail.Font = new Font("Calibri", 8.0f);
            btnReset.Visible = false;
            btnExport.Visible = false;




        }

        private void frmIPLA_Load(object sender, EventArgs e)
        {

            lblHeader.Text = "Inter Project Loan Account Summary";

            ActivateCurrentFinYear();
            LoadCombos();
           

            ResetAll();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int _borgID;
            int _finYear;
            int _fromPeriod;
            int _endPeriod;
            _borgID = Convert.ToInt16(cmbBorgs.SelectedValue);
            _finYear = Convert.ToInt16(cmbFinYear.SelectedValue);
            _fromPeriod = Convert.ToInt16(cmbFromPeriod.SelectedValue);
            _endPeriod = Convert.ToInt16(cmbToPeriod.SelectedValue);
           _dsFinalResult = _cg.IPLA(_finYear,_fromPeriod,_endPeriod,_borgID);

        }
    }
}
