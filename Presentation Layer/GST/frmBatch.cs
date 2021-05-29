using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSMIS 
{
    public partial class frmBatch : Form
    {
        GST _gst = new GST();
        public frmBatch(Int64 _trangrp)
        {
            InitializeComponent();
            SetupGrid();
            PopulateGrid(_trangrp);
        }

        public void SetupGrid()
        {
             
            this.gridBatch.ShowGroupDropArea = true;
            this.gridBatch.TableOptions.AllowSortColumns = true;
            this.gridBatch.TopLevelGroupOptions.ShowCaption = true;
            this.gridBatch.TableOptions.RecordPreviewRowHeight = 55;
            this.gridBatch.TableOptions.ShowRowHeader = false;
            this.gridBatch.TableOptions.SelectionBackColor = Color.FromArgb(255, 128, 128);
            this.gridBatch.TableOptions.SelectionTextColor = Color.Maroon;
            this.gridBatch.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended;
            this.gridBatch.TableOptions.DefaultColumnWidth = 65;
            this.gridBatch.TableOptions.CaptionRowHeight = 22;
            this.gridBatch.InvalidateAllWhenListChanged = true;
            this.gridBatch.ForceDisposeOnResetDataSource = true;
            this.gridBatch.AllowResetTableDescriptorWhenDataSourceSetNull = true;
            this.gridBatch.CacheRecordValues = false;
            this.gridBatch.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme;
            this.gridBatch.Font = new Font("Ariel", 7.0f);
            this.gridBatch.TopLevelGroupOptions.ShowFilterBar = true;  
        }

        public void PopulateGrid(Int64 _transGroupID)
        {
            DataSet _ds = new DataSet();
            _ds = _gst.ExtractBatch(_transGroupID);
            gridBatch.DataSource = _ds;
        }
    }
}
