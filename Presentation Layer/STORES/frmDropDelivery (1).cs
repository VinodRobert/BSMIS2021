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
    public partial class frmDropDelivery : Form
    {
        Stores _st = new Stores();
        DataTable _match = new DataTable();
        Int64 _sourceDeliveryID; 

        public frmDropDelivery()
        {
            InitializeComponent();
        }

        private void frmDropDelivery_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadNegativeDelivery();

            _match.Columns.Add("DLVRID", typeof(Int64));
            _match.Columns.Add("DLVQQTY", typeof(Decimal));
        }

        private void ResetAll()
        {
            this.gridNegative.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridNegative.ShowGroupDropArea = false;
            this.gridNegative.TableOptions.AllowSortColumns = false;
            this.gridNegative.TopLevelGroupOptions.ShowCaption = true;
            this.gridNegative.TableOptions.RecordPreviewRowHeight = 55;
            this.gridNegative.TableOptions.ShowRowHeader = false;
            this.gridNegative.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridNegative.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridNegative.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridNegative.TableOptions.DefaultColumnWidth = 65;
            this.gridNegative.TableOptions.CaptionRowHeight = 22;
            this.gridNegative.InvalidateAllWhenListChanged = true;
            this.gridNegative.ForceDisposeOnResetDataSource = true;
            this.gridNegative.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridNegative.CacheRecordValues = false;
            this.gridNegative.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridNegative.Font = new Font("Calibri", 10.0f);
            this.gridNegative.TopLevelGroupOptions.ShowFilterBar = true;


           
        }
        private void LoadNegativeDelivery()
        {
            DataSet _ds = _st.GetNegativeDelivery(1);
            LoadNegative(_ds.Tables[0]);
            
        }

        private void  LoadPositiveDelivery(Int64 _ordID, int _itemLineNo)
        {
            DataSet _ds = _st.GetPositiveDelivery(_ordID,_itemLineNo);
            LoadPositive(_ds.Tables[0]);
        }
        

        private void LoadNegative(DataTable _dt)
        {
            gridNegative.DataSource = _dt;

            gridNegative.TableDescriptor.Columns[0].HeaderText = "Project";
            gridNegative.TableDescriptor.Columns[0].Width = 200;
            gridNegative.TableDescriptor.Columns[0].AllowFilter = true;
            gridNegative.TableDescriptor.Columns[0].AllowGroupByColumn = true;

            gridNegative.TableDescriptor.Columns[1].HeaderText = "Fin Year";
            gridNegative.TableDescriptor.Columns[1].Width = 60;
            gridNegative.TableDescriptor.Columns[1].AllowFilter = true;
            gridNegative.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            gridNegative.TableDescriptor.Columns[2].HeaderText = "Order Number";
            gridNegative.TableDescriptor.Columns[2].Width = 150;
            gridNegative.TableDescriptor.Columns[2].AllowFilter = false;

            gridNegative.TableDescriptor.Columns[3].HeaderText = "Item Name";
            gridNegative.TableDescriptor.Columns[3].Width = 200;
            gridNegative.TableDescriptor.Columns[3].AllowGroupByColumn = true;

            gridNegative.TableDescriptor.Columns[4].HeaderText = "Delivery ID";
            gridNegative.TableDescriptor.Columns[4].Width = 80;
            gridNegative.TableDescriptor.Columns[4].AllowGroupByColumn = false;
            gridNegative.TableDescriptor.Columns[4].AllowFilter = false;

            gridNegative.TableDescriptor.Columns[5].HeaderText = "Delivery No";
            gridNegative.TableDescriptor.Columns[5].Width = 150;
            gridNegative.TableDescriptor.Columns[5].AllowGroupByColumn = false;
            gridNegative.TableDescriptor.Columns[5].AllowFilter = false;

            gridNegative.TableDescriptor.Columns[6].HeaderText = "GRN";
            gridNegative.TableDescriptor.Columns[6].Width = 100;
            gridNegative.TableDescriptor.Columns[6].AllowFilter = false;
            gridNegative.TableDescriptor.Columns[6].AllowGroupByColumn = false;

            gridNegative.TableDescriptor.Columns[7].HeaderText = "Delivery Qty";
            gridNegative.TableDescriptor.Columns[7].Width = 80;
            gridNegative.TableDescriptor.Columns[7].AllowFilter = false;
            gridNegative.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F4";

           
            gridNegative.TableDescriptor.Columns[8].HeaderText = "TBORGID";
            gridNegative.TableDescriptor.Columns[8].Width =0;
          
            gridNegative.TableDescriptor.Columns[9].HeaderText = "ORDITEMLINENO";
            gridNegative.TableDescriptor.Columns[9].Width = 0;

          

           
          
        }

        private void LoadPositive(DataTable _dt)
        {
            gridPositive.DataSource = _dt;

            gridPositive.TableDescriptor.Columns[0].HeaderText = "Project";
            gridPositive.TableDescriptor.Columns[0].Width = 200;
            gridPositive.TableDescriptor.Columns[0].AllowFilter = true;
            gridPositive.TableDescriptor.Columns[0].AllowGroupByColumn = true;

            gridPositive.TableDescriptor.Columns[1].HeaderText = "Fin Year";
            gridPositive.TableDescriptor.Columns[1].Width = 60;
            gridPositive.TableDescriptor.Columns[1].AllowFilter = true;
            gridPositive.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            gridPositive.TableDescriptor.Columns[2].HeaderText = "Order Number";
            gridPositive.TableDescriptor.Columns[2].Width = 150;
            gridPositive.TableDescriptor.Columns[2].AllowFilter = false;

            gridPositive.TableDescriptor.Columns[3].HeaderText = "Item Name";
            gridPositive.TableDescriptor.Columns[3].Width = 180;
            gridPositive.TableDescriptor.Columns[3].AllowGroupByColumn = true;

            gridPositive.TableDescriptor.Columns[4].HeaderText = "Delivery ID";
            gridPositive.TableDescriptor.Columns[4].Width = 80;
            gridPositive.TableDescriptor.Columns[4].AllowGroupByColumn = false;
            gridPositive.TableDescriptor.Columns[4].AllowFilter = false;

            gridPositive.TableDescriptor.Columns[5].HeaderText = "Delivery No";
            gridPositive.TableDescriptor.Columns[5].Width = 100;
            gridPositive.TableDescriptor.Columns[5].AllowGroupByColumn = false;
            gridPositive.TableDescriptor.Columns[5].AllowFilter = false;

            gridPositive.TableDescriptor.Columns[6].HeaderText = "GRN";
            gridPositive.TableDescriptor.Columns[6].Width = 90;
            gridPositive.TableDescriptor.Columns[6].AllowFilter = false;
            gridPositive.TableDescriptor.Columns[6].AllowGroupByColumn = false;

            gridPositive.TableDescriptor.Columns[7].HeaderText = "Delivery Qty";
            gridPositive.TableDescriptor.Columns[7].Width = 80;
            gridPositive.TableDescriptor.Columns[7].AllowFilter = false;
            gridPositive.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F4";


            gridPositive.TableDescriptor.Columns[8].HeaderText = "Recon Status";
            gridPositive.TableDescriptor.Columns[8].Width = 100;

          

      

      



        }

        private void gridNegative_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            string row = Convert.ToString(e.Inner.RowIndex);
            string ordIDValue = "";
            string itemNumberValue = "";
            string deliveryID ="";
            string deliveryQty = "";

            Int64 _ordID;
            int _itemLineNo;
            Int64 _deliveryID;
            Decimal _deliveryQty;
            
            var s = this.gridNegative.Table.SelectedRecords;
            GridRangeInfoList s1 = this.gridNegative.TableModel.Selections.GetSelectedRows(true, true);
            foreach (GridRangeInfo info in s1)
            {

                Element el = this.gridNegative.TableModel.GetDisplayElementAt(info.Top);
                deliveryID = el.GetRecord().GetValue("DLVRID").ToString();
               
                ordIDValue = el.GetRecord().GetValue("ORDID").ToString();
                itemNumberValue = el.GetRecord().GetValue("ORDITEMLINENO").ToString();
                deliveryQty = el.GetRecord().GetValue("DLVRQTY").ToString();

            }
            _ordID = Convert.ToInt64(ordIDValue);
            _itemLineNo = Convert.ToInt16(itemNumberValue);
            _deliveryID = Convert.ToInt64(deliveryID);
            _sourceDeliveryID = Convert.ToInt64(deliveryID);
            lblNDID.Text = deliveryID.ToString();
            lblNDQ.Text = deliveryQty.ToString();
            _match.Clear();
            lblPositiveMatch.Text = "";
            LoadPositiveDelivery(_ordID,_itemLineNo);
           
        }

        private void gridPositive_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
        {
            string row = Convert.ToString(e.Inner.RowIndex);
            string deliveryID = "";
            string deliveryQty = "";
            decimal _totalPositive;
         
            Int64 _deliveryID;
            Decimal _deliveryQty;

            var s = this.gridPositive.Table.SelectedRecords;
            GridRangeInfoList s1 = this.gridPositive.TableModel.Selections.GetSelectedRows(true, true);
            foreach (GridRangeInfo info in s1)
            {

                Element el = this.gridPositive.TableModel.GetDisplayElementAt(info.Top);
                deliveryID = el.GetRecord().GetValue("DLVRID").ToString();
                deliveryQty = el.GetRecord().GetValue("DLVRQTY").ToString();

            }
            
            _deliveryID = Convert.ToInt64(deliveryID);
            _deliveryQty = Convert.ToDecimal(deliveryQty);

            _match.Rows.Add(_deliveryID,_deliveryQty);
            gridMatch.DataSource = _match;

            _totalPositive = 0;

            foreach (DataRow dr in _match.Rows)
            {
                _totalPositive = _totalPositive + Convert.ToDecimal(dr["DLVQQTY"].ToString());
            }
            lblPositiveMatch.Text = Convert.ToString(_totalPositive);

            if ((Convert.ToDecimal(lblNDQ.Text))+ (Convert.ToDecimal(lblPositiveMatch.Text)) == 0 )
                btnDrop.Visible = true;
            else
                btnDrop.Visible = false;

        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            _match.Rows.Add(_sourceDeliveryID, 0);
            DataSet _ds;
            foreach (DataRow row in _match.Rows)
            {
                int _dlvrID = Convert.ToInt32(row["DLVRID"]);
                _ds = _st.DropNegativeDelivery(_dlvrID);
            }
            MessageBox.Show("Successfully Dropped .",    "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

    }
}
