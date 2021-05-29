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
    public partial class PaymentBatchUsers : Form
    {
        Entities ent = new Entities();

        public PaymentBatchUsers()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            ggBSUsers.Visible = false;
            this.ggBSUsers.ShowGroupDropArea = false;
            this.ggBSUsers.TableOptions.AllowSortColumns = true;
            this.ggBSUsers.TopLevelGroupOptions.ShowCaption = true;
            this.ggBSUsers.TableOptions.RecordPreviewRowHeight = 55;
            this.ggBSUsers.TableOptions.ShowRowHeader = false;
            this.ggBSUsers.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggBSUsers.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggBSUsers.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggBSUsers.TableOptions.DefaultColumnWidth = 65;
            this.ggBSUsers.TableOptions.CaptionRowHeight = 22;
            this.ggBSUsers.InvalidateAllWhenListChanged = true;
            this.ggBSUsers.ForceDisposeOnResetDataSource = true;
            this.ggBSUsers.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggBSUsers.CacheRecordValues = false;
            this.ggBSUsers.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggBSUsers.Font = new Font("Arial", 9.0f);
            this.ggBSUsers.TopLevelGroupOptions.ShowFilterBar = true;
        }

        private void ReFormatGrid()
        {
            ggBSUsers.TableDescriptor.Columns[0].HeaderText = "BS LoginID";
            ggBSUsers.TableDescriptor.Columns[0].Width = 100;

            ggBSUsers.TableDescriptor.Columns[1].HeaderText = "BS Login Name";
            ggBSUsers.TableDescriptor.Columns[1].Width = 325;

            ggBSUsers.TableDescriptor.Columns[2].HeaderText = "Pay Batch Role";
            ggBSUsers.TableDescriptor.Columns[2].Width = 300;
        }
         
        private void LoadExistingPayBatchUsers()
        {
            DataSet ds = ent.GetPaymentBatchUsers();
            ggBSUsers.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggBSUsers.Visible = true;
        }

        private void LoadRemainingBSUsers()
        {
            DataSet ds = ent.GetRemainingBSUsers();
            cmbBSUsers.DataSource = ds.Tables[0];
            
        }

        private void LoadPayBatchRole()
        {
            DataSet ds = ent.GetPaymentBatchRoles();
            cmbPBRole.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggBSUsers.Visible = true;
        }


        private void PaymentBatchUsers_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadExistingPayBatchUsers();
            LoadRemainingBSUsers();
            LoadPayBatchRole();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newPayBatchUser;
            string newPayBatchRole;
            string newPayBatchLoginID;
            newPayBatchLoginID = Convert.ToString(cmbBSUsers.SelectedValue).TrimEnd();
            newPayBatchUser = Convert.ToString(cmbBSUsers.Text).TrimEnd();
            newPayBatchRole = Convert.ToString(cmbPBRole.SelectedValue);
          
            DataSet  ds = ent.GetPaymentBatchUserPassword(newPayBatchLoginID);
            string newPayBatchUserPassword = Convert.ToString(ds.Tables[0].Rows[0][0]).TrimEnd();
            int i = ent.UpdatePaymentBatchUsers(newPayBatchLoginID, newPayBatchUser, newPayBatchUserPassword,newPayBatchRole);
            MessageBox.Show("Success!!!!");
            LoadExistingPayBatchUsers();
            LoadRemainingBSUsers();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
