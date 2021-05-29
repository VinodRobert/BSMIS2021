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
   
    public partial class frmBookKeeping : Form
    {
        IT it = new IT();

        public frmBookKeeping()
        {
            InitializeComponent();
        }

        private void frmPasswords_Load(object sender, EventArgs e)
        {
            txtPassword.Text = "";
          
         
    }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            btnPassword.Enabled = false;
            lblShow.Visible = true;
            int i = it.DoBookKeeping();
            MessageBox.Show("Success !!!");
            this.Close();
            return;
        }
    }
}
