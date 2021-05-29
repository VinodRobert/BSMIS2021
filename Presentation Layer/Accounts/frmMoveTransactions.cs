using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLHelper;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Drawing;

namespace BSMIS 
{
    public partial class frmMoveTransactions : Form
    {
        DataTable finalResult;

        public frmMoveTransactions()
        {
            InitializeComponent();
        }
        private void ResetAll()
        {
            btnShow.Visible = false;
            btnTransfer.Visible = false;
            txtTrangrp.Text = "";
            txtYesNo.Text = "";
            txtTrangrp.ReadOnly = false;
            finalResult = new DataTable();
            finalResult.Clear();
            txtTrangrp.Visible = true;
        }

        private void FormatGrid()
        {

            this.ggTransGroup.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggTransGroup.ShowGroupDropArea = false;
            this.ggTransGroup.TableOptions.AllowSortColumns = true;
            this.ggTransGroup.TopLevelGroupOptions.ShowCaption = true;
            this.ggTransGroup.TableOptions.RecordPreviewRowHeight = 55;
            this.ggTransGroup.TableOptions.ShowRowHeader = false;
            this.ggTransGroup.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggTransGroup.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggTransGroup.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggTransGroup.TableOptions.DefaultColumnWidth = 65;
            this.ggTransGroup.TableOptions.CaptionRowHeight = 22;
            this.ggTransGroup.InvalidateAllWhenListChanged = true;
            this.ggTransGroup.ForceDisposeOnResetDataSource = true;
            this.ggTransGroup.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggTransGroup.CacheRecordValues = false;
            this.ggTransGroup.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggTransGroup.Font = new Font("Calibri", 8.0f);
            this.ggTransGroup.TopLevelGroupOptions.ShowFilterBar = false;
        }


        private void frmMoveTransactions_Load(object sender, EventArgs e)
        {
            ResetAll();
            FormatGrid();
        }

        private void txtTrangrp_TextChanged(object sender, EventArgs e)
        {
            btnShow.Visible = true;
            
        }

        private void PoupulateGrid()
        {
            ggTransGroup.DataSource = finalResult;
            ggTransGroup.TableDescriptor.Columns[0].HeaderText = "TRANGRP";
            ggTransGroup.TableDescriptor.Columns[0].Width = 50;
            ggTransGroup.TableDescriptor.Columns[0].AllowFilter = true;

            ggTransGroup.TableDescriptor.Columns[1].HeaderText = "ORGID";
            ggTransGroup.TableDescriptor.Columns[1].Width =  50;
            ggTransGroup.TableDescriptor.Columns[1].AllowFilter = true;
            this.ggTransGroup.TableModel.Cols.FreezeRange(0, 1);

            ggTransGroup.TableDescriptor.Columns[2].HeaderText = "Year";
            ggTransGroup.TableDescriptor.Columns[2].Width = 30;
            ggTransGroup.TableDescriptor.Columns[2].AllowFilter = false;

            ggTransGroup.TableDescriptor.Columns[3].HeaderText = "Period";
            ggTransGroup.TableDescriptor.Columns[3].Width = 50;
            ggTransGroup.TableDescriptor.Columns[3].AllowFilter = false;

            ggTransGroup.TableDescriptor.Columns[4].HeaderText = "BATCHREF";
            ggTransGroup.TableDescriptor.Columns[4].Width = 75;
            ggTransGroup.TableDescriptor.Columns[4].AllowFilter = false;

            ggTransGroup.TableDescriptor.Columns[5].HeaderText = "TransRef";
            ggTransGroup.TableDescriptor.Columns[5].Width = 75;
            ggTransGroup.TableDescriptor.Columns[5].AllowGroupByColumn = false;



            ggTransGroup.TableDescriptor.Columns[6].HeaderText = "TransDate";
            ggTransGroup.TableDescriptor.Columns[6].Width = 75;
            ggTransGroup.TableDescriptor.Columns[6].Appearance.AnyCell.CellType = "Date";
            ggTransGroup.TableDescriptor.Columns[6].AllowGroupByColumn = false;

      


            ggTransGroup.TableDescriptor.Columns[7].HeaderText = "Ledger Code";
            ggTransGroup.TableDescriptor.Columns[7].Width = 70;
            ggTransGroup.TableDescriptor.Columns[7].AllowGroupByColumn = false;
            ggTransGroup.TableDescriptor.Columns[7].Appearance.AnyCell.Format = "F2";


       


            ggTransGroup.TableDescriptor.Columns[8].HeaderText = "Description";
            ggTransGroup.TableDescriptor.Columns[8].Width = 250;
            ggTransGroup.TableDescriptor.Columns[8].AllowGroupByColumn = false;


            ggTransGroup.TableDescriptor.Columns[9].HeaderText = "Currency";
            ggTransGroup.TableDescriptor.Columns[9].Width = 50;
            ggTransGroup.TableDescriptor.Columns[9].AllowGroupByColumn = false;


            ggTransGroup.TableDescriptor.Columns[10].HeaderText = "Debit";
            ggTransGroup.TableDescriptor.Columns[10].Width = 90;
            ggTransGroup.TableDescriptor.Columns[10].AllowGroupByColumn = false;
            ggTransGroup.TableDescriptor.Columns[10].Appearance.AnyCell.Format = "F2";

            ggTransGroup.TableDescriptor.Columns[11].HeaderText = "Credit";
            ggTransGroup.TableDescriptor.Columns[11].Width = 90;
            ggTransGroup.TableDescriptor.Columns[11].AllowGroupByColumn = false;
            ggTransGroup.TableDescriptor.Columns[11].Appearance.AnyCell.Format = "F2";

            lblConfirm.Visible = true;
            btnTransfer.Visible = true;
            ggTransGroup.Visible = true;
            txtYesNo.Visible = true;
            txtYesNo.Text = "No";
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            string trangrp = Convert.ToString(txtTrangrp.Text).Trim();
            txtTrangrp.ReadOnly = true;

            if (trangrp != "")
            {
                string _connectionString = SqlHelper.GetConnectionString();
                string _sql = "Select TRANGRP,ORGID,YEAR,PERIOD,PDATE,BATCHREF,TRANSREF,LEDGERCODE,DESCRIPTION,CURRENCY,DEBIT,CREDIT from Transactions Where Trangrp= " + Convert.ToString(trangrp);
                DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
                finalResult = ds.Tables[0];
                PoupulateGrid();

            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string confirm = Convert.ToString(txtYesNo.Text).Trim().ToUpper();
            string trangrp = Convert.ToString(txtTrangrp.Text).Trim();
            if (confirm == "YES")
            {
                string _connectionString = SqlHelper.GetConnectionString();
                string _newYear = Convert.ToString(txtNewYear.Text);
                string _newPeriod = Convert.ToString(txtNewPeriod.Text);
                
                DateTime _newDate = dtNewDate.Value;
                var _newDateOnly = _newDate.Date;
                string _newDateString = String.Format("{0:dd/MM/yyyy}", _newDate);
                string _sql = "UPDATE TRANSACTIONS SET YEAR=";
                _sql = _sql + _newYear +",PERIOD=";
                _sql = _sql + _newPeriod + ",PDATE= CONVERT(DATETIME,'";
                _sql = _sql + _newDateString + "',103)  WHERE TRANGRP= " + Convert.ToString(trangrp);
                int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
                MessageBox.Show("Success !");
                ggTransGroup.Visible = false;
                txtYesNo.Visible = false;
                btnTransfer.Visible = false;
                ResetAll();
            }
        }
    }
}
