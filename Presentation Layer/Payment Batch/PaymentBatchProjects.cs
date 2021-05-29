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
    public partial class PaymentBatchProjects : Form
    {
        Entities ent = new Entities();

        public PaymentBatchProjects()
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
            this.ggProjects.TopLevelGroupOptions.ShowFilterBar = false;
        }

        private void ReFormatGrid()
        {
            ggProjects.TableDescriptor.Columns[0].HeaderText = "Org ID";
            ggProjects.TableDescriptor.Columns[0].Width = 100;
         

            ggProjects.TableDescriptor.Columns[1].HeaderText = "Organization Name";
            ggProjects.TableDescriptor.Columns[1].Width = 350;

           
        }
        private void LoadRemainingProjects()
        {
            DataSet dsProjects = ent.GetProjectsNotEnrolledForPaymentBatch();
            cmbProjects.DataSource = dsProjects.Tables[0];
            
        }
        private void LoadEnrolledProjects()
        {
            DataSet ds = ent.GetProjectsEnrolledForPaymentBatch();
            ggProjects.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggProjects.Visible = true;
        }
        private void PaymentBatchProjects_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadRemainingProjects();
            LoadEnrolledProjects();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int newProjectID;
            string newProjectName;
            newProjectID =Convert.ToInt16(cmbProjects.SelectedValue);
            newProjectName = Convert.ToString(cmbProjects.Text);
            int i = ent.EnablePaymentBatch(newProjectID,newProjectName);
            MessageBox.Show("Success!!!!");
            LoadRemainingProjects();
            LoadEnrolledProjects();
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
