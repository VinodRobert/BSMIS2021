using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
 
 
namespace BSMIS 
{
    public partial class frmDefineRevenueExpenseHeads : Form
    {
        DataSet _ds;
        Budget _bu = new Budget();
        DataSet _dsGroupHeaders;

        int _subLedgerApplicable;
        int _currentlyHowMany;

        public frmDefineRevenueExpenseHeads()
        {
            InitializeComponent();
            LoadGrid();
        }
        
      

        private void LoadGrid()
        {
            DataSet _dsGroupHeaders = _bu.FetchGroupHeads();
            flexRevenueExpense.DataSource = _dsGroupHeaders.Tables[0];
            flexRevenueExpense.Cols[0].Caption = "Category";
            flexRevenueExpense.Cols[1].Caption = "Order";
            flexRevenueExpense.Cols[2].Caption = "Name";
            flexRevenueExpense.AllowFiltering = true;
            flexRevenueExpense.Cols[0].Width = 120;
            flexRevenueExpense.Cols[1].Width = 50;
            flexRevenueExpense.Cols[2].Width = 250;
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (btnAddUpdate.Text == "New")
            {
                txtHead.Text = "";
                cmbCategory.SelectedIndex = 0;
                txtPosition.IntegerValue = 1000;
                btnAddUpdate.Text = "Update";
            }
            else
            {
                if (btnAddUpdate.Text == "Update")
                {
                    int i = _bu.InsertHeads(txtHead.Text.ToString(), cmbCategory.SelectedValue.ToString(), txtPosition.Text.ToString());
                }
            }
        }
       
	}
}
