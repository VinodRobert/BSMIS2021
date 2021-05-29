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
    public partial class Form1 : Form
    {
        Entities _en = new Entities();
        DataSet _ds;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ggc1.Visible = false;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            _ds = _en.GetGroupLedgerHead();
            ggc1.DataSource = _ds.Tables[0];
            ggc1.Visible = true; 
        }

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

            return ws;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
          
        }
    }
}
