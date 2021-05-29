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

using Syncfusion.Grouping;
 
using Syncfusion.Windows.Forms.Grid;
 
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Drawing;

using OfficeOpenXml;
using System.IO;
using System.Globalization;


namespace BSMIS 
{
    public partial class PaymentBatchBanks : Form
    {
        Entities ent = new Entities();
        int bankIndex;

        public PaymentBatchBanks()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            ggProjects.Visible = false;
            this.ggProjects.ShowGroupDropArea = true;
            this.ggProjects.TableOptions.AllowSortColumns = true;
            this.ggProjects.TopLevelGroupOptions.ShowCaption = true;
            this.ggProjects.TableOptions.RecordPreviewRowHeight = 55;
            this.ggProjects.TableOptions.ShowRowHeader = false;
            this.ggProjects.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggProjects.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggProjects.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggProjects.TableOptions.DefaultColumnWidth = 65;
            this.ggProjects.TableOptions.CaptionRowHeight = 22;
            this.ggProjects.InvalidateAllWhenListChanged = true;
            this.ggProjects.ForceDisposeOnResetDataSource = true;
            this.ggProjects.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggProjects.CacheRecordValues = false;
            this.ggProjects.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggProjects.Font = new Font("Arial", 9.0f);
            this.ggProjects.TopLevelGroupOptions.ShowFilterBar = false;
            this.ggProjects.TableModel.Cols.FrozenCount = 5;
            panelAddress.Visible = false;
            panelPayMode.Visible = false;
            panelReference.Visible = false;
        }

        private void ReFormatGrid()
        {
            ggProjects.TableDescriptor.Columns[0].HeaderText = "BankID";
            ggProjects.TableDescriptor.Columns[0].Width = 0;

            ggProjects.TableDescriptor.Columns[1].HeaderText = "Project Name";
            ggProjects.TableDescriptor.Columns[1].Width =200;
            ggProjects.TableDescriptor.Columns[1].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[1].AllowFilter = true;


            ggProjects.TableDescriptor.Columns[2].HeaderText = "Org ID";
            ggProjects.TableDescriptor.Columns[2].Width = 00;


            ggProjects.TableDescriptor.Columns[3].HeaderText = "Bank Name";
            ggProjects.TableDescriptor.Columns[3].Width = 200;
            ggProjects.TableDescriptor.Columns[3].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[4].AllowFilter = true;


            ggProjects.TableDescriptor.Columns[4].HeaderText = "Bank Account";
            ggProjects.TableDescriptor.Columns[4].Width = 200;


            ggProjects.TableDescriptor.Columns[5].HeaderText = "Address";
            ggProjects.TableDescriptor.Columns[5].Width = 100;

            ggProjects.TableDescriptor.Columns[6].HeaderText = "Address";
            ggProjects.TableDescriptor.Columns[6].Width = 100;


            ggProjects.TableDescriptor.Columns[7].HeaderText = "Address";
            ggProjects.TableDescriptor.Columns[7].Width = 100;


            ggProjects.TableDescriptor.Columns[8].HeaderText = "State";
            ggProjects.TableDescriptor.Columns[8].Width = 100;


            ggProjects.TableDescriptor.Columns[9].HeaderText = "PIN";
            ggProjects.TableDescriptor.Columns[9].Width = 100;

            ggProjects.TableDescriptor.Columns[10].HeaderText = "Ledger Code";
            ggProjects.TableDescriptor.Columns[10].Width = 100;


            ggProjects.TableDescriptor.Columns[11].HeaderText = "Ledger Name";
            ggProjects.TableDescriptor.Columns[11].Width = 250;

         

            ggProjects.TableDescriptor.Columns[12].HeaderText = "Reference";
            ggProjects.TableDescriptor.Columns[12].Width = 100;
            ggProjects.TableDescriptor.Columns[12].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[12].AllowFilter = true;

            ggProjects.TableDescriptor.Columns[13].HeaderText = "Year(Reference)";
            ggProjects.TableDescriptor.Columns[13].Width = 100;

            ggProjects.TableDescriptor.Columns[14].HeaderText = "SerialNumber";
            ggProjects.TableDescriptor.Columns[14].Width = 100;


            ggProjects.TableDescriptor.Columns[15].HeaderText = "Cheque";
            ggProjects.TableDescriptor.Columns[15].Width = 80;
            ggProjects.TableDescriptor.Columns[15].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[15].AllowFilter = true;

            ggProjects.TableDescriptor.Columns[16].HeaderText = "RTGS";
            ggProjects.TableDescriptor.Columns[16].Width = 50;
            ggProjects.TableDescriptor.Columns[16].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[16].AllowFilter = true;

            ggProjects.TableDescriptor.Columns[17].HeaderText = "API";
            ggProjects.TableDescriptor.Columns[17].Width = 50;
            ggProjects.TableDescriptor.Columns[17].AllowGroupByColumn = true;
            ggProjects.TableDescriptor.Columns[17].AllowFilter = true;

        }

        private void LoadEnrolledBanksInProjects()
        {
            DataSet ds = ent.GetBanksForEnrolledProjects();
            ggProjects.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggProjects.Visible = true;
        }
        private void PaymentBatchProjects_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadEnrolledBanksInProjects();
            
        }
      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void populateBankDetails(int bankID)
        {
            bankIndex = bankID;
            string txtRTGS;
            string txtCHEQUE;
            string txtAPI;

            DataSet ds = new DataSet();
            ds = ent.GetSingleBankEntry(bankID);
            DataRow dr;
            dr = ds.Tables[0].Rows[0];

            txtAddress1.Text = dr["Address1"].ToString();
            txtAddress2.Text = dr["Address2"].ToString();
            txtAddress3.Text = dr["Address3"].ToString();
            txtState.Text = dr["State"].ToString();
            txtPIN.Text = dr["PIN"].ToString();

            txtReference.Text = dr["REFERENCE"].ToString();
            txtYearReference.Text = dr["YEARREFERENCE"].ToString();
            txtSerialNumber.Text = dr["SERIALNUMBER"].ToString();

            txtRTGS = dr["RTGS"].ToString();
            txtCHEQUE = dr["CHEQUE"].ToString();
            txtAPI = dr["API"].ToString();
             

            rdAPI.Checked = false;
            rdCheque.Checked = false;
            rdRTGS.Checked = false;

            if (txtRTGS == "True")
                rdRTGS.Checked = true;
            else
                rdRTGS.Checked = false;

            if (txtCHEQUE == "True")
                rdCheque.Checked = true;
            else
                rdCheque.Checked = false;

            if (txtAPI == "True")
                rdAPI.Checked = true;
            else
                rdAPI.Checked = false;

            panelAddress.Visible = true;
            panelPayMode.Visible = true;
            panelReference.Visible = true;

        }
        private void ggProjects_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            string row = Convert.ToString(e.Inner.RowIndex);
            string cellValue = "";
            int bankID;
            var s = this.ggProjects.Table.SelectedRecords;
            GridRangeInfoList s1 = this.ggProjects.TableModel.Selections.GetSelectedRows(true, true);
            foreach (GridRangeInfo info in s1)
            {

                Element el = this.ggProjects.TableModel.GetDisplayElementAt(info.Top);

                cellValue = el.GetRecord().GetValue("BANKID").ToString();

            }
            bankID = Convert.ToInt16(cellValue);

            populateBankDetails(bankID);
            
        }

        private void btnUpdateBankAddress_Click(object sender, EventArgs e)
        {
            int i = ent.UpdateBankAddress(bankIndex, txtAddress1.Text, txtAddress2.Text, txtAddress3.Text, txtPIN.Text, txtState.Text);
            MessageBox.Show("Sucess!!");
            LoadEnrolledBanksInProjects();
            txtAddress3.Text = "";
            txtAddress2.Text = "";
            txtAddress1.Text = "";
            txtState.Text = "";
            txtPIN.Text = "";

        }

 

        private void btnPayMode_Click(object sender, EventArgs e)
        {
            if ( (rdAPI.Checked) == true )
            {
                int i = ent.UpdatePaymentMode(bankIndex, 3);
                MessageBox.Show("Sucess!!");
            }

            if ((rdCheque.Checked) == true)
            {
                int i = ent.UpdatePaymentMode(bankIndex, 1);
                MessageBox.Show("Sucess!!");
            }

            if ((rdRTGS.Checked) == true)
            {
                int i = ent.UpdatePaymentMode(bankIndex, 2);
                MessageBox.Show("Sucess!!");
            }

            LoadEnrolledBanksInProjects();
        }

        private void btnReference_Click(object sender, EventArgs e)
        {
            int i = ent.UpdateReference(bankIndex, txtReference.Text, txtYearReference.Text, txtSerialNumber.Text);
            txtSerialNumber.Text = "";
            txtReference.Text = "";
            txtYearReference.Text = "";
            MessageBox.Show("Success");
            LoadEnrolledBanksInProjects();
        }
    }
}
