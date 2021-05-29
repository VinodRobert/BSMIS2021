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
    public partial class frmStoresMaster : Form
    {

        Stores _st = new Stores();

        DataSet _dsFinalResult;
        DataTable _dt;

        public frmStoresMaster()
        {
            InitializeComponent();
        }

        private void frmCreditorAge_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "Stores Master";
            ResetAll();
            _dsFinalResult = new DataSet();
            _dt = new DataTable();
            _dsFinalResult = _st.FetchAllStores();
            _dt = _dsFinalResult.Tables[0];
            LoadDetail(_dt);
        }


        public void ResetAll()
        {
            this.gridRegister.ActivateCurrentCellBehavior = GridCellActivateAction.None;
            this.gridRegister.ShowGroupDropArea = false;
            this.gridRegister.TableOptions.AllowSortColumns = false;
            this.gridRegister.TopLevelGroupOptions.ShowCaption = true;
            this.gridRegister.TableOptions.RecordPreviewRowHeight = 55;
            this.gridRegister.TableOptions.ShowRowHeader = false;
            this.gridRegister.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridRegister.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridRegister.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridRegister.TableOptions.DefaultColumnWidth = 65;
            this.gridRegister.TableOptions.CaptionRowHeight = 22;
            this.gridRegister.InvalidateAllWhenListChanged = true;
            this.gridRegister.ForceDisposeOnResetDataSource = true;
            this.gridRegister.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridRegister.CacheRecordValues = false;
            this.gridRegister.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridRegister.Font = new Font("Calibri", 8.0f);
            this.gridRegister.TopLevelGroupOptions.ShowFilterBar = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void LoadDetail(DataTable _dt)
        {
            gridRegister.DataSource = _dt;

            gridRegister.TableDescriptor.Columns[0].HeaderText = "Org ID";
            gridRegister.TableDescriptor.Columns[0].Width = 50;
            gridRegister.TableDescriptor.Columns[0].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[0].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[1].HeaderText = "Project Name";
            gridRegister.TableDescriptor.Columns[1].Width = 325;
            gridRegister.TableDescriptor.Columns[1].AllowFilter = false;
            gridRegister.TableDescriptor.Columns[1].AllowGroupByColumn = true;

            gridRegister.TableDescriptor.Columns[2].HeaderText = "Store Name";
            gridRegister.TableDescriptor.Columns[2].Width = 225;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;
            gridRegister.TableDescriptor.Columns[2].AllowFilter = true;

        }

    }

}
