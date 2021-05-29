using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLHelper;
using System.Data.SqlClient;


namespace BSMIS
{
   
    public partial class frmPasswords : Form
    {
        private static readonly Timer Timer = new Timer();

        public frmPasswords()
        {
            InitializeComponent();
        }

        private void frmPasswords_Load(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            lblUserName.Text = "User Name";
            lblPassword.Text = "Password";
            txtBSLoginID.Visible = false;
            btnShow.Visible = false;
         
    }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            String today =Convert.ToString(now.ToString("MMddyyyy"));
            int mm = Convert.ToInt16(today.Substring(0, 2));
            int dd = Convert.ToInt16(today.Substring(2, 2));
            int key = dd + mm;
            int keypressed = Convert.ToInt16(txtPassword.Text.ToString());
            if (key==keypressed)
            {
                txtBSLoginID.Visible = true;
                btnShow.Visible = true;
                lblPassword.Visible = true;
                lblUserName.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid Key !!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string loginID = Convert.ToString(txtBSLoginID.Text.Trim());
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT USERID,USERNAME,PASSWORD FROM USERS  WHERE LOGINID='" + Convert.ToString(loginID)+"'";
            DataSet users = new DataSet();

            users = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            int cnt = Convert.ToInt32(users.Tables[0].Rows.Count);
            if (cnt == 0)
            {
                lblUserName.Text = "Invalid BS User";
                lblPassword.Text = "XXXXX";
            }
            else
            {
                lblUserName.Text = Convert.ToString(users.Tables[0].Rows[0][1]);
                lblPassword.Text = Convert.ToString(users.Tables[0].Rows[0][2]);
                Timer.Tick += TimerEventProcessor;
                Timer.Interval = 3000;
                Timer.Start();
            }
           
        }

        private  void TimerEventProcessor(object myObject, EventArgs myEventArgs)
        {
            Timer.Stop();
            lblPassword.Text = "";
            
        }
    }
}
