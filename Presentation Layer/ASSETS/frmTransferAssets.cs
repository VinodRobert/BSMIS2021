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
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Drawing;
 
using OfficeOpenXml;
using System.IO;
using System.Globalization;
 

 
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel; 

namespace BSMIS 
{
    public partial class frmTransferAssets : Form
    {
        

        Entities _ent = new Entities();
        Assets _as = new Assets();

      
        int _currentAssetID;
        string _currentNewLocation; 
        
        DataSet _dsFinalResult = new DataSet();
        

        

   

        public frmTransferAssets()
        {
            InitializeComponent();
        }
       public void ResetAll()
        {
        
            ggDetail.Visible = false;
            

            this.ggDetail.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.ggDetail.ShowGroupDropArea = true;
            this.ggDetail.TableOptions.AllowSortColumns = true;
            this.ggDetail.TopLevelGroupOptions.ShowCaption = true;
            this.ggDetail.TableOptions.RecordPreviewRowHeight = 55;
            this.ggDetail.TableOptions.ShowRowHeader = false;
            this.ggDetail.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.ggDetail.TableOptions.SelectionTextColor = Color.Maroon;
            this.ggDetail.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.ggDetail.TableOptions.DefaultColumnWidth = 65;
            this.ggDetail.TableOptions.CaptionRowHeight = 22;
            this.ggDetail.InvalidateAllWhenListChanged = true;
            this.ggDetail.ForceDisposeOnResetDataSource = true;
            this.ggDetail.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.ggDetail.CacheRecordValues = false;
            this.ggDetail.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.ggDetail.Font = new Font("Calibri",8.0f);
            this.ggDetail.TopLevelGroupOptions.ShowFilterBar = true;   
           
          
        }
       private void LoadDetail(DataTable _dt)
        {
        
                ggDetail.DataSource = _dt;
                ggDetail.ShowGroupDropArea = true; 
                ggDetail.TableDescriptor.Columns[0].HeaderText = "Asset ID";
                ggDetail.TableDescriptor.Columns[0].Width =0;
                ggDetail.TableDescriptor.Columns[0].AllowGroupByColumn = false;
                ggDetail.TableDescriptor.Columns[0].AllowFilter = false;

                ggDetail.TableDescriptor.Columns[1].HeaderText = "Asset Number";
                ggDetail.TableDescriptor.Columns[1].Width = 100;

                ggDetail.TableDescriptor.Columns[2].HeaderText = "Asset Name";
                ggDetail.TableDescriptor.Columns[2].Width = 200;
                ggDetail.TableDescriptor.Columns[2].AllowFilter = true;
                ggDetail.TableDescriptor.Columns[2].AllowGroupByColumn = false;
                

                ggDetail.TableDescriptor.Columns[3].HeaderText = "Asset Category";
                ggDetail.TableDescriptor.Columns[3].Width = 150;
                ggDetail.TableDescriptor.Columns[2].AllowGroupByColumn = true;

                ggDetail.TableDescriptor.Columns[4].HeaderText = "Asset Location";
                ggDetail.TableDescriptor.Columns[4].Width = 100;
                ggDetail.TableDescriptor.Columns[4].AllowFilter = true;
                ggDetail.TableDescriptor.Columns[4].AllowGroupByColumn = true;

             
           
             
        }
  
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
       
       
       private void frmAssetMaster_Load(object sender, EventArgs e)
       {
           PopulateGrid();
           LoadCombos();
           btnConfirm.Visible = false;
           btnGet.Visible = true; 
       }

       private void LoadCombos()
       {
           DataSet _dsAssetNumbers = new DataSet();
           _dsAssetNumbers = _as.FetchAssetIDS();
           UtilityFunctions.LoadWindowsCombo(cmbAssetNumber, _dsAssetNumbers.Tables[0], "ASSETNUMBER", "ASSETID", 0);

           DataSet _dsLocation = _as.FetchLocationDetails();
           UtilityFunctions.LoadWindowsCombo(cmbNewLocation, _dsLocation.Tables[0], "BORGNAME", "LOCATION", 0);

       }
       private void PopulateGrid()
       {

           _dsFinalResult = _as.FetchAllWithMinimunInformation();
           _dsFinalResult.Tables[0].TableName = "Asset Master";
           _dsFinalResult.Tables[0].Columns[0].Caption = "Asset ID";
           _dsFinalResult.Tables[0].Columns[1].Caption = "Asset Number";
           _dsFinalResult.Tables[0].Columns[2].Caption = "Asset Name";
           _dsFinalResult.Tables[0].Columns[3].Caption = "Asset Category";
           _dsFinalResult.Tables[0].Columns[4].Caption = "Asset Location";
           LoadDetail(_dsFinalResult.Tables[0]);

       }

       private void btnGet_Click(object sender, EventArgs e)
       {
           int _assetID = Convert.ToInt16(cmbAssetNumber.SelectedValue);
           DataSet _dsAssetMaster = _as.FetchAssetsDetails(_assetID);
           _currentAssetID = _assetID;
           lblAssetLocation.Text = Convert.ToString(_dsAssetMaster.Tables[0].Rows[0]["AssetLocation"]);
           lblAssetName.Text = Convert.ToString(_dsAssetMaster.Tables[0].Rows[0]["AssetName"]);
           btnGet.Visible = false;
           btnConfirm.Visible = true; 
       }

       private void btnConfirm_Click(object sender, EventArgs e)
       {
           lblNewLocation.Text = Convert.ToString(cmbNewLocation.SelectedValue);
           _currentNewLocation = Convert.ToString(lblNewLocation.Text).Trim();
           btnConfirm.Visible = false;
           btnUpdate.Visible = true;
           
       }

       private void btnClear_Click(object sender, EventArgs e)
       {
           btnUpdate.Visible = false;
           btnConfirm.Visible = false;
           btnGet.Visible = true;
           lblNewLocation.Text = "";
           lblAssetName.Text = "";
           lblAssetLocation.Text = "";
           cmbNewLocation.SelectedIndex = 0;
           cmbAssetNumber.SelectedIndex = 0;

       }

       private void Clear()
       {
           btnUpdate.Visible = false;
           btnConfirm.Visible = false;
           btnGet.Visible = true;
           lblNewLocation.Text = "";
           lblAssetName.Text = "";
           lblAssetLocation.Text = "";
           cmbNewLocation.SelectedIndex = 0;
           cmbAssetNumber.SelectedIndex = 0;
       }

       private void btnUpdate_Click(object sender, EventArgs e)
       {
           int _result = _as.UpdateLocation(_currentAssetID,_currentNewLocation);
           PopulateGrid();
           MessageBox.Show("Success","Result",MessageBoxButtons.OK,MessageBoxIcon.Information);
           Clear();
       }

       

       

       

        

         

       

    }   
  }

