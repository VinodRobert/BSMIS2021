using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSMIS  
{
    public partial class frmVariationOrders : Form
    {
        IT it = new IT();


        public frmVariationOrders()
        {
            InitializeComponent();
        }

        private void frmVariationOrders_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            lblLineNumber.Visible = false;
            txtLineNumber.Visible = false;
            btnUpdate.Visible = false;

            lblSubbie.Visible = false;
            lblSubbieName.Visible = false;

            lblVariationOrder.Visible = false;
            txtVO.Visible = false;

            btnVO.Visible = false;
            gridRegister.Visible = false;

            txtPO.Text = "";
        }

        private void btnWO_Click(object sender, EventArgs e)
        {
            if (txtPO.Text == "")
            {
                MessageBox.Show("Please Enter Valid WO #");
                return;
            }

            DataSet ds = it.GetWODetails(txtPO.Text.Trim());
            if (ds.Tables[0].Rows.Count==0)
            {
                MessageBox.Show("Invalid WO");
                return;
            }
            lblSubbie.Text = Convert.ToString(ds.Tables[0].Rows[0]["SUPPNAME"]);
            lblSubbie.Visible = true;
            lblSubbieName.Visible = true;
            lblVariationOrder.Visible = true;
            txtVO.Visible = true;
            btnVO.Visible = true;
        }
    }
}
