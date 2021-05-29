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
    public partial class PaymentBatchRoles : Form
    {
        Entities ent = new Entities();

        public PaymentBatchRoles()
        {
            InitializeComponent();
        }

        public void ResetAll()
        {
            ggProjects.Visible = false;
            this.ggProjects.ShowGroupDropArea = false;
            this.ggProjects.TableOptions.AllowSortColumns = true;
            this.ggProjects.TopLevelGroupOptions.ShowCaption = true;
            this.ggProjects.TableOptions.RecordPreviewRowHeight = 55;
            this.ggProjects.TableOptions.ShowRowHeader = false;
            this.ggProjects.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggProjects.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggProjects.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggProjects.TableOptions.DefaultColumnWidth = 65;
            this.ggProjects.TableOptions.CaptionRowHeight = 22;
            this.ggProjects.InvalidateAllWhenListChanged = true;
            this.ggProjects.ForceDisposeOnResetDataSource = true;
            this.ggProjects.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggProjects.CacheRecordValues = false;
            this.ggProjects.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggProjects.Font = new Font("Arial", 9.0f);
            this.ggProjects.TopLevelGroupOptions.ShowFilterBar = true;
        }

        private void ReFormatGrid()
        {
            ggProjects.TableDescriptor.Columns[0].HeaderText = "Role ID";
            ggProjects.TableDescriptor.Columns[0].Width = 0;

            ggProjects.TableDescriptor.Columns[1].HeaderText = "Role Name";
            ggProjects.TableDescriptor.Columns[1].Width = 0;

            ggProjects.TableDescriptor.Columns[2].HeaderText = "Role ID";
            ggProjects.TableDescriptor.Columns[2].Width = 100;

            ggProjects.TableDescriptor.Columns[3].HeaderText = "Role Name";
            ggProjects.TableDescriptor.Columns[3].Width = 300;

        }
         
        private void LoadExistingPayBatchRoles()
        {
            DataSet ds = ent.GetPaymentBatchRoles();
            ggProjects.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggProjects.Visible = true;
        }
        private void PaymentBatchProjects_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadExistingPayBatchRoles();
         
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string newPayBatchRole;
            newPayBatchRole = Convert.ToString(txtRoleName.Text.Trim());
            if (newPayBatchRole == "")
                return;

            int j = ent.ValidatePaymentBatchRole(newPayBatchRole);
            if (j == 0)
            {
                int i = ent.UpdatePaymentBatchRoles(newPayBatchRole);
                MessageBox.Show("Success!!!!");
                LoadExistingPayBatchRoles();

                txtRoleName.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid/Duplicate  Entry");
            }
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
