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
    public partial class frmLockUsers : Form
    {
        DataSet _ds;
        DataTable _dtActiveUsers;
       
        IT _it = new IT();

        public frmLockUsers()
        {
            InitializeComponent();

        }


      

       

       
        private void frmLockUsers_Load(object sender, EventArgs e)
        {
            
            LoadListBox();
            btnLockUsers.Enabled = false; 
        }

        
        private void LoadListBox()
        {
            _ds = new DataSet();
            _ds = _it.GetPrivelegeLoginUsers();
            _dtActiveUsers = new DataTable();

            _dtActiveUsers = _ds.Tables[0];

            dgUsers.DataSource = _dtActiveUsers;
            dgUsers.Columns[0].HeaderText = "Login User Name";
            dgUsers.Columns[0].Width = 250;
            dgUsers.Columns[0].DefaultCellStyle.Font =  new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
            dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsers.MultiSelect = true; 
            dgUsers.Refresh();

        }

        private void btnLockUsers_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure?","Lock Users",    MessageBoxButtons.YesNoCancel,    MessageBoxIcon.Question,  MessageBoxDefaultButton.Button2);
            string _who;
            if (result == DialogResult.Yes)
            {
                int l = _it.LockAllUsers();
                foreach (DataGridViewRow row in this.dgPrevileged.Rows)
                {
                    _who = row.Cells[0].Value.ToString();
                    _it.UnLockUser(_who);
                }
            }

            MessageBox.Show("All Users Locked . Please Restart the World Wide Web Service To Clear All LOGINS ");
            this.Close();
        }

       

      

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgUsers.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                    dgUsers.Rows.Remove(row);
                }
                this.dgPrevileged.Rows.Add(rowData);
            }
            btnLockUsers.Enabled = true; 
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure To UNLOCK Now  ?", "UnLock Users", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int l = _it.UnLockAllUsers();
                MessageBox.Show("Success. Better Restart World Wide Web Service ");
            }
         
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


       

    }     
   
}
