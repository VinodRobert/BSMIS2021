using Syncfusion.Windows.Forms.Grid;
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
    public partial class frmMasterCategory : Form
    {
        Masters ma = new Masters();
        int partyCategory;
        public frmMasterCategory()
        {
            InitializeComponent();
        }

        private void ResetAll()
        {
            txtCategoryName.Enabled = false;
            btnCancel.Text = "Cancel";
            btnNew.Text = "New";
            btnDelete.Text = "Delete";
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            cmbMaterType.SelectedIndex = 0;

            this.ggMasterCategory.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggMasterCategory.ShowGroupDropArea = false;
            this.ggMasterCategory.TableOptions.AllowSortColumns = true;
            this.ggMasterCategory.TopLevelGroupOptions.ShowCaption = true;
            this.ggMasterCategory.TableOptions.RecordPreviewRowHeight = 55;
            this.ggMasterCategory.TableOptions.ShowRowHeader = false;
            this.ggMasterCategory.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggMasterCategory.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggMasterCategory.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggMasterCategory.TableOptions.DefaultColumnWidth = 300;
            this.ggMasterCategory.TableOptions.CaptionRowHeight = 22;
            this.ggMasterCategory.InvalidateAllWhenListChanged = true;
            this.ggMasterCategory.ForceDisposeOnResetDataSource = true;
            this.ggMasterCategory.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggMasterCategory.CacheRecordValues = false;
            this.ggMasterCategory.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggMasterCategory.Font = new Font("Calibri", 8.0f);
            this.ggMasterCategory.TopLevelGroupOptions.ShowFilterBar = false;
        }
        private void frmMasterCategory_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ReformatGrid()
        {
            ggMasterCategory.TableDescriptor.Columns[0].HeaderText = "ID";
            ggMasterCategory.TableDescriptor.Columns[0].Width = 0;

            ggMasterCategory.TableDescriptor.Columns[1].HeaderText = "Category Name";
            ggMasterCategory.TableDescriptor.Columns[1].Width = 300;

            ggMasterCategory.TableDescriptor.Columns[2].HeaderText = "CategoryType";
            ggMasterCategory.TableDescriptor.Columns[2].Width = 0;

        }
        private void btnGetIt_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            int masterCategory = Convert.ToInt32(cmbMaterType.SelectedIndex);

            if (masterCategory == 1)
                partyCategory = 1;
            else
                partyCategory = 2;

            DataSet ds = ma.GetMasterCategory(partyCategory);
            ggMasterCategory.DataSource = null;
            ggMasterCategory.Refresh();
            ggMasterCategory.DataSource = ds.Tables[0];
            ReformatGrid();
            btnGetIt.Enabled = true;
            btnNew.Enabled = true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
           
            if (btnNew.Text=="New")
            {
                btnNew.Text = "Update";
                txtCategoryName.Enabled = true;
            }
            else
            {
                if (txtCategoryName.Text.Trim() == "")
                    return;
                else
                {
                    int j = ma.InsertNewCategoryName(txtCategoryName.Text.Trim().ToUpper(), partyCategory);
                    LoadCategory();
                    btnNew.Enabled = false;
                    txtCategoryName.Text = "";
                    btnNew.Enabled = true; ;
                    btnNew.Text = "New";
                    txtCategoryName.Enabled = false;
                    MessageBox.Show("Success !!!");
                }
            }
            
        }
    }
}
