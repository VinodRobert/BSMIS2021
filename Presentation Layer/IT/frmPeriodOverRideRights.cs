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
    public partial class frmPeriodOverRideRights : Form
    {
        IT _it = new IT();
        int _howMany;

        DataTable _dtUsers; 

        public frmPeriodOverRideRights()
        {
            InitializeComponent();
        }

        private void frmPeriodOverRideRights_Load(object sender, EventArgs e)
        {
            ResetAll();
            PopulateUsers();
           

        }

        private void PopulateUsers()
        {
            DataSet _ds = _it.GetPeriodOverRiderUserList();
            if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            {
                gridPeriodOverRide.Visible = true; 
                _dtUsers = _ds.Tables[0];
                _howMany = 0;
                _howMany = Convert.ToInt16(_ds.Tables[0].Rows.Count);
                 
                gridPeriodOverRide.DataSource = _dtUsers;

                if (_howMany > 0)
                {
                    OpenForRevoking();
                }
            }
            else
            {
                gridPeriodOverRide.Visible = false;
                lblNIL.Visible = true; 
            }
        }


        private void ResetAll()
        {
            lblListofUsers.Visible = false;
            cmbUsers.Visible = false;
            btnRevokeNow.Visible = false;
            lblNIL.Visible = false; 
        }

        private void OpenForRevoking()
        {
            UtilityFunctions.LoadWindowsCombo(cmbUsers, _dtUsers, "USERNAME", "USERID", 0);
            lblListofUsers.Visible = true;
            cmbUsers.Visible = true;
            btnRevokeNow.Visible = true;
            lblNIL.Visible = false; 

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRevokeNow_Click(object sender, EventArgs e)
        {
            string _who;
            _who = Convert.ToString(cmbUsers.SelectedValue).Trim();
            int i = _it.RevokePeriodOverRidePrevelege(_who);
            MessageBox.Show("Success", "Success", MessageBoxButtons.OK);
            ResetAll();
            PopulateUsers();
        }
    }
}
