using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms;
 
using System.IO;

namespace BSMIS
{
    public partial class frmLoginUser : Form
    {
        DataSet _ds = new DataSet();
        IT _it = new IT();
     
        public frmLoginUser()
        {
            InitializeComponent();
        }

        private void frmLoginUser_Load(object sender, EventArgs e)
        {
            _ds = _it.GetLoginUsers();
           gridLoginUsers.DataSource = _ds.Tables[0];

           this.gridLoginUsers.TableOptions.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
           this.gridLoginUsers.TableOptions.GridLineBorder = new GridBorder(GridBorderStyle.Solid, Color.FromArgb(208, 215, 229), GridBorderWeight.Thin);
           this.gridLoginUsers.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
           this.gridLoginUsers.NestedTableGroupOptions.ShowAddNewRecordBeforeDetails = false;
           this.gridLoginUsers.TopLevelGroupOptions.ShowCaption = false;
           this.gridLoginUsers.Appearance.AnyCell.Font.Facename = "Verdana";
           this.gridLoginUsers.Appearance.AnyCell.TextColor = Color.MidnightBlue;

        
            gridLoginUsers.TopLevelGroupOptions.ShowFilterBar = true;
            gridLoginUsers.TableDescriptor.Appearance.FilterBarCell.BackColor = Color.AliceBlue;
            for (int i = 0; i < gridLoginUsers.TableDescriptor.Columns.Count; i++)
            {
                gridLoginUsers.TableDescriptor.Columns[i].AllowFilter = true;
            }
            gridLoginUsers.TableDescriptor.Columns[0].HeaderText = "Module";
            gridLoginUsers.TableDescriptor.Columns[0].Width = 100;
            gridLoginUsers.TableDescriptor.Columns[1].Width = 125;
            gridLoginUsers.TableDescriptor.Columns[2].Width = 200;
            gridLoginUsers.TableDescriptor.Columns[3].Width = 100;
            gridLoginUsers.TableDescriptor.Columns[4].Width = 400;


          

        }

        private void gridLoginUsers_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {

        }    
        
        	 
    
    }
}
