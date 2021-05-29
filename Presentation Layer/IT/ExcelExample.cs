using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using C1.C1Excel;
namespace BSMIS 
{
    public partial class ExcelExample : Form
    {
        //Excel styles
        XLStyle _styTitle;
        XLStyle _styHeader;
        XLStyle _styMoney;
        XLStyle _styOrder;
        DataSet _ds;
        IT _it = new IT();
        private Hashtable tempFiles = null;
        protected static string TEMP_DIR = System.Environment.GetEnvironmentVariable("tmp");
        public ExcelExample()
        {
            InitializeComponent();
        }
        public string GetUniqueTempFileName(string ext)
        {
            string appName = AppDomain.CurrentDomain.FriendlyName;
            string guid = System.Guid.NewGuid().ToString();
            return String.Format("{0}\\{1}_{2}{3}", TEMP_DIR, appName, guid, ext);
        }
        public string GetTempFileName(string ext)
        {
            if (tempFiles == null)
                tempFiles = new Hashtable();

            if (!tempFiles.Contains(ext))
            {
                string tempFile = GetUniqueTempFileName(ext);
                tempFiles.Add(ext, tempFile);
            }

            return tempFiles[ext].ToString();
        }

        private void CreateSheet(DataSet _ds)
        {
         

            DataTable _dt = _ds.Tables[0];
      

            string sheetName = "LoginUsers";
            XLSheet sheet = _c1xl.Sheets.Add(sheetName);
            sheet.Rows[0].Style = _styTitle;

            // set column widths (in twips)
            sheet.Columns[0].Width = 300;
            sheet.Columns[1].Width = 2200;
            sheet.Columns[2].Width = 1000;
            sheet.Columns[3].Width = 1600;
            sheet.Columns[4].Width = 1000;
            sheet.Columns[5].Width = 1000;
            sheet.Columns[6].Width = 1000;

            //add column headers
            int row = 2;
            sheet.Rows[row].Style = _styHeader;
            sheet[row, 1].Value = "Module";
            sheet[row, 2].Value = "LoginID";
            sheet[row, 3].Value = "UserName";
            sheet[row, 4].Value = "CATEGORY";
            sheet[row, 5].Value = "BORGNAME";



            foreach (DataRow product in _dt.Rows)
            {
                //move on to next row
                row++;

                //add row with some data
                sheet[row, 1].Value = product["Module"];
                sheet[row, 2].Value = product["LoginID"];
                sheet[row, 3].Value = product["UserName"];
                sheet[row, 4].Value = product["CATEGORY"];
                sheet[row, 5].Value = product["BORGNAME"];

            } 
           
        }

        private string CreateExcelFile()
        {
            //clear Excel book, remove the single blank sheet
            _c1xl.Clear();
            _c1xl.Sheets.Clear();
            _c1xl.DefaultFont = new Font("Tahoma", 8);

            //create Excel styles
            _styTitle = new XLStyle(_c1xl);
            _styHeader = new XLStyle(_c1xl);
            _styMoney = new XLStyle(_c1xl);
            _styOrder = new XLStyle(_c1xl);

            //set up styles
            _styTitle.Font = new Font(_c1xl.DefaultFont.Name, 15, FontStyle.Bold);
            _styTitle.ForeColor = Color.Blue;
            _styHeader.Font = new Font(_c1xl.DefaultFont, FontStyle.Bold);
            _styHeader.ForeColor = Color.White;
            _styHeader.BackColor = Color.DarkGray;
            _styMoney.Format = XLStyle.FormatDotNetToXL("c");
            _styOrder.Font = _styHeader.Font;
            _styOrder.ForeColor = Color.Red;

            //create report with one sheet per category
            _ds = _it.GetLoginUsers();
            CreateSheet(_ds);

            _c1xl.Sheets[0].Locked = true;
            

            //save xls file

            string filename = GetTempFileName(".xls");
            _c1xl.Save(filename);

            return filename;

        }

        private void ExcelExample_Load(object sender, EventArgs e)
        {
            string filename = CreateExcelFile();

            Process.Start(filename);
             
        }
    }
}
