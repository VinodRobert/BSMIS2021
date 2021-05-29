using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSMIS 
{
    public partial class frmCreditors : Form
    {
        DataSet _ds = new DataSet();
        IT  _it = new IT();
        public frmCreditors()
        {
            InitializeComponent();
        }

        private void frmCreditors_Load(object sender, EventArgs e)
        {
            _ds = _it.GetLedgers(); 
            tbGrid0.AllowAddNew = false;
            tbGrid0.AllowFilter = true;
            tbGrid0.AllowSort = true;

            _ds.Tables[0].TableName = "Ledgers";
            _ds.Tables[1].TableName = "Transactions";
            _ds.Relations.Add("LedgerTransactions", _ds.Tables["Ledgers"].Columns["LEDGERCODE"], _ds.Tables["Transactions"].Columns["LEDGERCODE"]);

            tbGrid0.DataSource = _ds;
             
            // DataMember of MasterTable
            tbGrid0.DataMember = "Ledgers";

            tbGrid0.Columns[1].Caption = "VINOD ROBERT";
            tbGrid0.Columns[1].FilterDropdown = true;
            tbGrid0.Visible = true;
            tbGrid0.ChildGrid = tbGrid1;
            tbGrid0.ChildGrid.DataSource = _ds;
            tbGrid0.ChildGrid.DataMember = "Ledgers.LedgerTransactions";
        
 
        }
    }
}
