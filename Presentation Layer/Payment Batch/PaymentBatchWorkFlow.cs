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
    public partial class PaymentBatchWorkFlow : Form
    {
        Entities ent = new Entities();

        public PaymentBatchWorkFlow()
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
            ggProjects.TableDescriptor.Columns[0].Width = 0;
            ggProjects.TableDescriptor.Columns[0].Width = 0;

            ggProjects.TableDescriptor.Columns[1].HeaderText = "Payment Mode";
            ggProjects.TableDescriptor.Columns[1].Width = 125;

            ggProjects.TableDescriptor.Columns[2].HeaderText = "Level ID";
            ggProjects.TableDescriptor.Columns[2].Width = 100;

            ggProjects.TableDescriptor.Columns[3].HeaderText = "Level ";
            ggProjects.TableDescriptor.Columns[3].Width = 200;

            ggProjects.TableDescriptor.Columns[4].HeaderText = "Final(1=True)";
            ggProjects.TableDescriptor.Columns[4].Width = 100;

        }

        private void LoadExistingPayBatchWorkFlow()
        {
            DataSet ds = ent.GetPaymentBatchWorkFlow();
            ggProjects.DataSource = ds.Tables[0];
            ReFormatGrid();
            ggProjects.Visible = true;
        }

        

       

         

        private void PaymentBatchUsers_Load(object sender, EventArgs e)
        {
            ResetAll();
            LoadExistingPayBatchWorkFlow();
        
         


        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         

         
    }
}
