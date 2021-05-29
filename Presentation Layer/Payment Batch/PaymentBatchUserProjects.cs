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


namespace BSMIS 
{
    public partial class PaymentBatchUserProjects : Form
    {
        Entities ent = new Entities();
        int chkState;
        int userApproverLevelID;

        public PaymentBatchUserProjects()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            ggBSUserMapping.Visible = false;
            this.ggBSUserMapping.ShowGroupDropArea = true;
            this.ggBSUserMapping.TableOptions.AllowSortColumns = true;
            this.ggBSUserMapping.TopLevelGroupOptions.ShowCaption = true;
            this.ggBSUserMapping.TableOptions.RecordPreviewRowHeight = 55;
            this.ggBSUserMapping.TableOptions.ShowRowHeader = false;
            this.ggBSUserMapping.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggBSUserMapping.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggBSUserMapping.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggBSUserMapping.TableOptions.DefaultColumnWidth = 65;
            this.ggBSUserMapping.TableOptions.CaptionRowHeight = 22;
            this.ggBSUserMapping.InvalidateAllWhenListChanged = true;
            this.ggBSUserMapping.ForceDisposeOnResetDataSource = true;
            this.ggBSUserMapping.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggBSUserMapping.CacheRecordValues = false;
            this.ggBSUserMapping.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggBSUserMapping.Font = new Font("Arial", 9.0f);
            this.ggBSUserMapping.TopLevelGroupOptions.ShowFilterBar = true;

            btnAdd.Enabled = false;
            btnReset.Enabled = false;
            btnClose.Enabled = true;
            btnClose.Visible = true;
            chkState = 0;
        }

        private void ReFormatGrid()
        {
            ggBSUserMapping.TableDescriptor.Columns[0].HeaderText = "Project";
            ggBSUserMapping.TableDescriptor.Columns[0].Width = 300;
            ggBSUserMapping.TableDescriptor.Columns[0].AllowGroupByColumn = true;

            ggBSUserMapping.TableDescriptor.Columns[1].HeaderText = "Process";
            ggBSUserMapping.TableDescriptor.Columns[1].Width = 125;
            ggBSUserMapping.TableDescriptor.Columns[1].AllowGroupByColumn = true;


            ggBSUserMapping.TableDescriptor.Columns[2].HeaderText = "Approval Level";
            ggBSUserMapping.TableDescriptor.Columns[2].Width = 300;
            ggBSUserMapping.TableDescriptor.Columns[2].AllowGroupByColumn = true;

            ggBSUserMapping.Visible = true;
            ggBSUserMapping.Enabled = true;

        }
         
        private void LoadExistingPayBatchUsers()
        {
            DataSet ds = ent.GetPaymentBatchUsers();
            UtilityFunctions.LoadWindowsCombo(cmbBSUsers, ds.Tables[0], "BSUSERNAME", "BSLOGINID", 0);
             
        }

        private void LoadRemainingBSUsers()
        {
            DataSet ds = ent.GetRemainingBSUsers();
            cmbBSUsers.DataSource = ds.Tables[0];
            
        }

        private void LoadPayBatchRole()
        {
            DataSet ds = ent.GetPaymentBatchRoles();
            //cmbPBRole.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggBSUserMapping.Visible = true;
        }


        private void PaymentBatchUsers_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadExistingPayBatchUsers();
           
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            string borgName;
            string processName;
            

            int borgID;
            string processID;

            string loginID = Convert.ToString(cmbBSUsers.SelectedValue);

            for (i = 0; i <= (chkListProjects.Items.Count - 1); i++)
            {
                borgName = Convert.ToString(chkListProjects.Items[i]).Trim();
                if (chkListProjects.GetItemChecked(i))
                {
                    for (j=0;j<=(chkListProcess.Items.Count-1);j++)
                    {
                        if (chkListProcess.GetItemChecked(j))
                        {
                            processName = Convert.ToString(chkListProcess.Items[j]);
                            if (processName == "Creditors")
                                processID = "C";
                            else
                                processID = "S";
                            DataSet ds = ent.GetBorgid(borgName);
                            borgID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                            int k = ent.UpdatePBUserProjectMapping(loginID, borgID, processID, userApproverLevelID);
                        }

                    }
                }
            }

            PopulateGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateGrid()
        {
            string loginID = Convert.ToString(cmbBSUsers.SelectedValue);
            DataSet dsExisting = ent.GetProjectAssignment(loginID);
            ggBSUserMapping.DataSource = dsExisting.Tables[0];
            ReFormatGrid();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            chkListProjects.Items.Clear();
            chkListProcess.Items.Clear();
            PopulateGrid();
            string loginID = Convert.ToString(cmbBSUsers.SelectedValue);
            DataSet ds = ent.GetPaymentBatchUserRole(loginID);
            string userRole = Convert.ToString(ds.Tables[0].Rows[0][0]);
            userApproverLevelID = Convert.ToInt16(ds.Tables[0].Rows[0][1]);
            lblUserRole.Text = Convert.ToString(userRole);
            DataSet dsProjects = ent.GetProjectsEnrolledForPaymentBatch();
            DataTable dt = dsProjects.Tables[0];
            chkListProcess.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chkListProjects.Items.Add(dt.Rows[i]["BSORGNAME"].ToString(),CheckState.Checked);
            }
            chkListProcess.Items.Clear();
            chkListProcess.Items.Add("Sub-Contractors", CheckState.Checked);
            chkListProcess.Items.Add("Creditors", CheckState.Checked);

            btnFetch.Enabled = false;
            btnAdd.Enabled = true;
            btnReset.Enabled = true;
            btnReset.Visible = true;
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            if (chkState==0)
            {
                chkState = 1;
                for (int i = 0; i < chkListProjects.Items.Count; i++)
                {
                    chkListProjects.SetItemChecked(i, true);
                }

            }
            else
            {
                chkState = 0;
                for (int i = 0; i < chkListProjects.Items.Count; i++)
                {
                    chkListProjects.SetItemChecked(i, false);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string loginID = Convert.ToString(cmbBSUsers.SelectedValue);
            DialogResult result2 = MessageBox.Show("Do You Want To Reset Mapping ?", "Reset Mapping",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result2 == DialogResult.Yes)
            {
                int i = ent.ResetMapping(loginID);
            }
            MessageBox.Show("Success!!");
            PopulateGrid();
            btnReset.Enabled = false;
            btnFetch.Enabled = true;
        }

        private void cmbBSUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            btnFetch.Enabled = true;
            btnFetch.Visible = true;
        }
    }
}
