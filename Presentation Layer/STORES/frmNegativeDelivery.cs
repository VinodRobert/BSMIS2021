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


namespace BSMIS
{
    public partial class frmNegativeDelivery : Form
    {
        Stores _st = new Stores();
        DataSet _ds = new DataSet();
        public frmNegativeDelivery()
        {
            InitializeComponent();
        }

        private void frmNegativeDelivery_Load(object sender, EventArgs e)
        {
            LoadNegativeDeliveries();
            SetGrid();
        }

        private void LoadNegativeDeliveries()
        {
            _ds = new DataSet();
            _ds = _st.FetchNegativeDeliviers();
            LoadDetail(_ds.Tables[0]);
        }

        private void LoadDetail(DataTable _dt)
        {
            gridRegister.DataSource = _dt;

            gridRegister.TableDescriptor.Columns[0].HeaderText = "Project";
            gridRegister.TableDescriptor.Columns[0].Width = 200;
            gridRegister.TableDescriptor.Columns[0].AllowFilter = true;

            gridRegister.TableDescriptor.Columns[1].HeaderText = "Order #";
            gridRegister.TableDescriptor.Columns[1].Width = 150;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[1].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[2].HeaderText = "Item";
            gridRegister.TableDescriptor.Columns[2].Width = 250;
            gridRegister.TableDescriptor.Columns[2].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[3].HeaderText = "Year";
            gridRegister.TableDescriptor.Columns[3].Width = 80;
            gridRegister.TableDescriptor.Columns[3].AllowFilter = true;


            gridRegister.TableDescriptor.Columns[4].HeaderText = "Period";
            gridRegister.TableDescriptor.Columns[4].Width = 50;
            gridRegister.TableDescriptor.Columns[4].AllowFilter = true;

            gridRegister.TableDescriptor.Columns[5].HeaderText = "GRN No";
            gridRegister.TableDescriptor.Columns[5].Width = 100;


            gridRegister.TableDescriptor.Columns[6].HeaderText = "Delivery#";
            gridRegister.TableDescriptor.Columns[6].Width = 250;
            gridRegister.TableDescriptor.Columns[6].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[7].HeaderText = "Allocation";
            gridRegister.TableDescriptor.Columns[7].Width = 80;
            gridRegister.TableDescriptor.Columns[7].AllowGroupByColumn = false;

            gridRegister.TableDescriptor.Columns[8].HeaderText = "Delivery Qty";
            gridRegister.TableDescriptor.Columns[8].Width = 100;
            gridRegister.TableDescriptor.Columns[8].AllowGroupByColumn = false;
            gridRegister.TableDescriptor.Columns[8].Appearance.AnyCell.Format = "F2";

            gridRegister.TableDescriptor.Columns[9].HeaderText = "TBORGID";
            gridRegister.TableDescriptor.Columns[9].Width = 0;
            gridRegister.TableDescriptor.Columns[9].AllowGroupByColumn = false;
       

            gridRegister.TableDescriptor.Columns[10].HeaderText = "ORDID";
            gridRegister.TableDescriptor.Columns[10].Width = 0;
            gridRegister.TableDescriptor.Columns[10].AllowGroupByColumn = false;
 

            gridRegister.TableDescriptor.Columns[11].HeaderText = "ORDITEMLINENO";
            gridRegister.TableDescriptor.Columns[11].Width = 0;

            gridRegister.TableDescriptor.Columns[12].HeaderText = "DLVRID";
            gridRegister.TableDescriptor.Columns[12].Width = 0;
        }


        private void SetGrid()
        {
            this.gridRegister.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridRegister.ShowGroupDropArea = false;
            this.gridRegister.TableOptions.AllowSortColumns = false;
            this.gridRegister.TopLevelGroupOptions.ShowCaption = false;
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
            this.gridRegister.TopLevelGroupOptions.ShowFilterBar = false;

            this.ggPositive.ActivateCurrentCellBehavior = GridCellActivateAction.None;
          
            this.ggPositive.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggPositive.Font = new Font("Calibri", 8.0f);
           
        }

        private void gridRegister_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            string row = Convert.ToString(e.Inner.RowIndex);
     
            string borgValue = "";
            string ordValue = "";
            string lineNumber = "";
            string dlvrID = "";
            string dlvrQty = "";
            Int32 _ordID;
            Int32 _borgID;
            Int32 _ItemLineNumber;
            Int32 _dlvrID;
            decimal _dlvrQty;
      
            var s = this.gridRegister.Table.SelectedRecords;
            GridRangeInfoList s1 = this.gridRegister.TableModel.Selections.GetSelectedRows(true, true);
            foreach (GridRangeInfo info in s1)
            {

                Element el = this.gridRegister.TableModel.GetDisplayElementAt(info.Top);

                borgValue = el.GetRecord().GetValue("TBORGID").ToString();
                ordValue = el.GetRecord().GetValue("ORDID").ToString();
                lineNumber = el.GetRecord().GetValue("ORDITEMLINENO").ToString();
                dlvrID = el.GetRecord().GetValue("DLVRID").ToString();
                dlvrQty = el.GetRecord().GetValue("DLVRQTY").ToString();
            }
            _borgID = Convert.ToInt32(borgValue);
            _ordID = Convert.ToInt32(ordValue);
            _ItemLineNumber = Convert.ToInt32(lineNumber);
            _dlvrID = Convert.ToInt32(dlvrID);
            _dlvrQty = Convert.ToDecimal(dlvrQty);
            lblNegDID.Text = _dlvrID.ToString();
            label5.Text = _dlvrQty.ToString();
            LoadPositiveDeliveries(_borgID, _ordID, _ItemLineNumber); 
        }

        private void LoadPositiveDeliveries(int _borgID, int _ordID, int _ItemLineNumber)
        {
            DataSet _result = new DataSet();
            _result = _st.FetchPositiveDeliveries(_borgID, _ordID, _ItemLineNumber);
            ShowPositiveDeliveries(_result.Tables[0]);
           
        }

      
        private void ShowPositiveDeliveries(DataTable _dt)
        {
            ggPositive.DataSource = _dt;

            ggPositive.TableDescriptor.Columns[0].HeaderText = "Delivery #";
            ggPositive.TableDescriptor.Columns[0].Width = 200;
            ggPositive.TableDescriptor.Columns[0].AllowFilter = true;

            ggPositive.TableDescriptor.Columns[1].HeaderText = "GRN";
            ggPositive.TableDescriptor.Columns[1].Width = 150;
            ggPositive.TableDescriptor.Columns[1].AllowFilter = true;
            ggPositive.TableDescriptor.Columns[1].AllowGroupByColumn = false;

            ggPositive.TableDescriptor.Columns[2].HeaderText = "Delivery Qty";
            ggPositive.TableDescriptor.Columns[2].Width = 150;
            ggPositive.TableDescriptor.Columns[2].AllowGroupByColumn = false;

            ggPositive.TableDescriptor.Columns[3].HeaderText = "Reconcile";
            ggPositive.TableDescriptor.Columns[3].Width = 80;
            ggPositive.TableDescriptor.Columns[3].AllowFilter = true;
             
         
            ggPositive.TableDescriptor.Columns[4].HeaderText = "DLVRID";
            ggPositive.TableDescriptor.Columns[4].Width = 0;
            ggPositive.TableDescriptor.Columns[4].AllowFilter = true;

        }
    }
}
