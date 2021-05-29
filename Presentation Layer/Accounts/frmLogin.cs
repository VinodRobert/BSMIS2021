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


namespace BSMIS 
{
    public partial class frmLogin : Form
    {
        Entities _en = new Entities();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _userID;
            string _pwd;
            int _success;
            if (rdLAN.Checked == true)
                GlobalVariables._connectedBy = 0;
            else
                GlobalVariables._connectedBy = 1;


            DataSet _ds; 
            _userID = Convert.ToString(txtUserID.Text).Trim();
            _pwd = Convert.ToString(txtPWD.Text).Trim();
            _ds  = _en.Login(_userID, _pwd) ;
            _success = Convert.ToInt16(_ds.Tables[0].Rows[0][0]);
            if (_success != 1)
            {
                MessageBox.Show("Invalid User ID or Password ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                GlobalVariables._UserRole = Convert.ToString(_ds.Tables[0].Rows[0][1]).Trim();
                GlobalVariables._UserID = Convert.ToString(txtUserID.Text).Trim();
                
                this.Visible = false; 
                frmMain _main = new frmMain();
                
                _main.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
