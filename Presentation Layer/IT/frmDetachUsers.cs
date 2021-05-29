using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLHelper;

namespace BSMIS 
{
    public partial class frmDetachUsers : Form
    {
        string _connectionString = SqlHelper.GetConnectionString();
        DataSet Users;
        DataSet AccountsOrgs;
        DataSet POSOrgs;
        int accAccess;
        int posAccess;
        string selectedProject;
        int userID;
        public frmDetachUsers()
        {
            InitializeComponent();
        }
        private void ResetAll()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            chkUnChkPOS.Visible = false;
            chkUnChkAcc.Visible = false;
            lblPOSAccess.Visible = false;
            lblAccountAccess.Visible = false;
            lblUserName.Visible = false;
        }
        private void frmDetachUsers_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadUsers();

        }

        private void LoadUsers()
        {
            string _sql = "SELECT USERID,USERNAME FROM USERS  order by UserName ";
            Users = new DataSet();
            Users = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            UtilityFunctions.LoadWindowsCombo(cmbLoginUsers, Users.Tables[0], "USERNAME", "USERID", 0);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "Show")
            {
                userID = Convert.ToInt32(cmbLoginUsers.SelectedValue);
                lblUserName.Text = Convert.ToString(cmbLoginUsers.Text);
                string sql1 = "SELECT UB.BORGID,B.BORGNAME FROM USERSINBORG UB INNER JOIN BORGS B ON UB.BORGID=B.BORGID WHERE UB.USERID = " + Convert.ToString(userID);
                string sql2 = "SELECT UP.BORGID,B.BORGNAME FROM USERSINBORGP UP INNER JOIN BORGS B ON UP.BORGID=B.BORGID WHERE UP.USERID = " + Convert.ToString(userID);
                AccountsOrgs = new DataSet();
                AccountsOrgs = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql1);
               
                accAccess = AccountsOrgs.Tables[0].Rows.Count;
                POSOrgs = new DataSet();
                POSOrgs = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql2);
                posAccess = POSOrgs.Tables[0].Rows.Count;
                lblAccountAccess.Text = Convert.ToString(accAccess) + " Entries in ACC ";
                lblPOSAccess.Text = Convert.ToString(posAccess) + " Entries in POS ";
                lblPOSAccess.Visible = true;
                lblAccountAccess.Visible = true;
                lblUserName.Visible = true;

                LoadListBoxes();
            }

            else if (btnShow.Text == "Commit")
            {
                foreach (object itemChecked in listACC.CheckedItems)
                {
                    selectedProject = "";
                    selectedProject = Convert.ToString(itemChecked.ToString());
                    DisableFromAcc(userID, selectedProject);
                     
                }

                foreach (object itemChecked in listPOS.CheckedItems)
                {
                    selectedProject = "";
                    selectedProject = Convert.ToString(itemChecked.ToString());
                    DisableFromPOS(userID, selectedProject);

                }
                MessageBox.Show("Success !!!");
                this.Close();

            }
        }

        private void DisableFromAcc(int UserID, string ProjectName)
        {
            string expression;
            int borgID;
            string sql;
            expression = "BORGNAME='" + Convert.ToString(ProjectName).Trim() + "'";
            DataRow[] foundRows =  AccountsOrgs.Tables[0].Select(expression);
            borgID = Convert.ToInt16(foundRows[0][0]);
            sql = "Delete From USERSINBORG Where UserID=" + Convert.ToString(userID) + " AND BORGID=" + Convert.ToString(borgID);
            int j = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
        }

        private void DisableFromPOS(int UserID, string ProjectName)
        {
            string expression;
            int borgID;
            string sql;
            expression = "BORGNAME='" + Convert.ToString(ProjectName).Trim() + "'";
            DataRow[] foundRows = POSOrgs.Tables[0].Select(expression);
            borgID = Convert.ToInt16(foundRows[0][0]);
            sql = "Delete From USERSINBORGP Where UserID=" + Convert.ToString(userID) + " AND BORGID=" + Convert.ToString(borgID);
            int j = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
        }

        private void LoadListBoxes()
        {
            listACC.Sorted = true;
            listACC.Items.Clear();
            listPOS.Sorted = true;
            listPOS.Items.Clear();
            string accOrg;
            string posOrg;
            for (int i = 0; i <= AccountsOrgs.Tables[0].Rows.Count - 1; i++)
            {
                accOrg = Convert.ToString(AccountsOrgs.Tables[0].Rows[i][1]);
                listACC.Items.Add(accOrg);

            }

            for (int i = 0; i <= POSOrgs.Tables[0].Rows.Count - 1; i++)
            {
                posOrg = Convert.ToString(POSOrgs.Tables[0].Rows[i][1]);
                listPOS.Items.Add(posOrg);

            }


            for (int i = 0; i < listACC.Items.Count; i++)
                listACC.SetItemChecked(i, false);

            for (int i = 0; i < listPOS.Items.Count; i++)
                listPOS.SetItemChecked(i, false);


            chkUnChkAcc.Checked = false;
            chkUnChkPOS.Checked = false;
            btnShow.Text = "Commit";
            if (accAccess > 0)
            {
                panel1.Visible = true;
                chkUnChkAcc.Visible = true;
                 
            }
            if (posAccess > 0)
            {
                panel2.Visible = true;
                chkUnChkPOS.Visible = true;
                 
            }

        }

        private void chkUnChkAcc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnChkAcc.Checked)
            {
                for (int i = 0; i < listACC.Items.Count; i++)
                {
                    listACC.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listACC.Items.Count; i++)
                {
                    listACC.SetItemChecked(i, false);
                }
            }
        }

        private void chkUnChkPOS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnChkPOS.Checked)
            {
                for (int i = 0; i < listPOS.Items.Count; i++)
                {
                    listPOS.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < listPOS.Items.Count; i++)
                {
                    listPOS.SetItemChecked(i, false);
                }
            }
        }
    }
}
