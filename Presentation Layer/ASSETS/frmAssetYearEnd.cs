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
    public partial class frmAssetYearEnd : Form
    {
        Assets Ass = new Assets();
        public frmAssetYearEnd()
        {
            InitializeComponent();
        }

        private void Verify_Click(object sender, EventArgs e)
        {
            string code = Convert.ToString(txtCode.Text).Trim();
            if (code == "BSMISYEAREND2019")
            {
                MessageBox.Show("Continue ...");
                DisplayYearDetails();
            }
            else
            {
                MessageBox.Show("Invalid Verification Code -- Contact BS Admin ");
                return;
            }
        }

        private void DisplayYearDetails()
        {
            DataSet ds = Ass.FindUptoWhatPeriodDepreciationDone();
            string lastDepeciation = Convert.ToString(ds.Tables[0].Rows[0][0]) + " - " + Convert.ToString(ds.Tables[0].Rows[0][1]);
            lblLastDepreciation.Text = lastDepeciation;

            DataSet ds1 = Ass.FindNextYearEndDue();
            string nextYearEndDue = Convert.ToString(ds.Tables[0].Rows[0][0]);
            lblNextYearEnd.Text = nextYearEndDue;


         }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text != "Yes")
                return;
            int currentYear = Convert.ToInt32(lblNextYearEnd.Text);
            int i = Ass.DepreciationYearEnd(currentYear);
            MessageBox.Show("Success !!!!! ");
        }
    }
}
