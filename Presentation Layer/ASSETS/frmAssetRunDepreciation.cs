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
    public partial class frmAssetRunDepreciation : Form
    {
        Assets Ass = new Assets();
        int nextYear;
        int nextPeriod; 

        public frmAssetRunDepreciation()
        {
            InitializeComponent();
        }

        

        private void DisplayYearDetails()
        {
            DataSet ds = Ass.FindUptoWhatPeriodDepreciationDone();
            string lastDepeciation = Convert.ToString(ds.Tables[0].Rows[0][0]) + " - " + Convert.ToString(ds.Tables[0].Rows[0][1]);
            lblLastDepreciation.Text = lastDepeciation;

            DataSet ds1 = Ass.FindNextDepreciationPeriod();
            string nextYearEndDue = Convert.ToString(ds1.Tables[0].Rows[0][1]) + " - " + Convert.ToString(ds1.Tables[0].Rows[0][3]); ;
            lblNextYearEnd.Text = nextYearEndDue;

            nextYear = Convert.ToInt16(ds1.Tables[0].Rows[0][1]);
            nextPeriod = Convert.ToInt16(ds1.Tables[0].Rows[0][2]);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirm.Text != "Yes")
                return;
            string category = Convert.ToString(cmbCategory.Text).Trim();
            int ID;
            ID = 0;

            if (category == "Office Premises")
                ID = 1;
            if (category == "Softwares")
                ID = 2;
            if (category == "Vehicles")
                ID = 3;
            if (category == "Office Equipment")
                ID = 4;
            if (category == "Computer and Printers")
                ID = 5;
            if (category == "Form Work")
                ID = 6;
            if (category == "Furniture and Fixtures")
                ID = 7;
            if (category == "Plant and Machinery")
                ID = 8;


            int i = Ass.MonthlyDepreciation(nextYear,nextPeriod, ID);
            MessageBox.Show("Success !!!!! ");
        }

        private void frmAssetRunDepreciation_Load(object sender, EventArgs e)
        {
            DisplayYearDetails();
        }
    }
}
