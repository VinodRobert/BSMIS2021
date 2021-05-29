using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using Microsoft.Win32;
using SQLHelper;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BSMIS
{
    class UtilityFunctions 
    {
        static string _labourForced;

        public static string LabourForced
        {
            get { return UtilityFunctions._labourForced; }
            set { UtilityFunctions._labourForced = value; }
        }


        public static string GetPhotoFilePath()
        {
            string _photoFileLocation = "";
            string _xmlFile = AppDomain.CurrentDomain.BaseDirectory + @"\PhotoFileLocation.xml";


            XmlReader _xmlReader = XmlReader.Create(_xmlFile);
            _xmlReader.MoveToContent();
            while (_xmlReader.Read())
            {
                if (_xmlReader.NodeType == XmlNodeType.Element)
                    _photoFileLocation  = _xmlReader.ReadElementString();
            }
            _xmlReader.Close();
            return _photoFileLocation;
        }

        public static void ImportData(object inputObject, DataSet ds)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                System.Type inputType = inputObject.GetType();


                DataRow _dr = ds.Tables[0].Rows[0];

                foreach (DataColumn _dc in _dr.Table.Columns)
                {
                    if (inputType.GetProperty(_dc.ColumnName) != null)
                    {

                        PropertyInfo property = inputType.GetProperty(_dc.ColumnName);

                        if (_dr[_dc.ColumnName] != DBNull.Value)
                        {
                            property.SetValue(inputObject, _dr[_dc.ColumnName], null);
                        }
                    }
                }

            }
        }


        public static void ImportData(object inputObject, DataRow dr)
        {
            System.Type inputType = inputObject.GetType();

            foreach (DataColumn _dc in dr.Table.Columns)
            {
                if (inputType.GetProperty(_dc.ColumnName) != null)
                {
                    PropertyInfo property = inputType.GetProperty(_dc.ColumnName);
                    if (dr[_dc.ColumnName] != DBNull.Value)
                    {
                        property.SetValue(inputObject, dr[_dc.ColumnName], null);
                    }
                }
            }

        }



        public static void Success()
        {
            MessageBox.Show("Successfully Saved/Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static void SuccessWithErrors()
        {
            MessageBox.Show("Successfully Saved/Updated With ERRORS", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        

        public static void ExportData(object inputObject, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                System.Type inputType = inputObject.GetType();

                DataRow _dr = ds.Tables[0].Rows[0];

                foreach (DataColumn _dc in _dr.Table.Columns)
                {
                    if (inputType.GetProperty(_dc.ColumnName) != null)
                    {
                        PropertyInfo property = inputType.GetProperty(_dc.ColumnName);
                        if (_dr[_dc.ColumnName] != DBNull.Value)
                        {
                            property.SetValue(inputObject, _dr[_dc.ColumnName], null);
                        }
                    }
                }

            }
        }


        public static void ExportData(object inputObject, DataRow dr)
        {
            System.Type inputType = inputObject.GetType();

            foreach (DataColumn _dc in dr.Table.Columns)
            {
                if (inputType.GetProperty(_dc.ColumnName) != null)
                {
                    PropertyInfo property = inputType.GetProperty(_dc.ColumnName);
                    if (dr[_dc.ColumnName] != DBNull.Value)
                    {
                        property.SetValue(inputObject, dr[_dc.ColumnName], null);
                    }
                }
            }

        }

        public static void LoadWindowsCombo(Syncfusion.Windows.Forms.Tools.ComboBoxAdv ctl, DataTable dt, string itemDisplay, string itemValue, int i)
        {

            if (i == 1)
            {
                DataRow dr = dt.NewRow();
                dr[itemDisplay] = "--ALL--";
                dr[itemValue] = 0;
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            }
            if (i == 2)
            {
                DataRow dr = dt.NewRow();
                dr[itemDisplay] = "--New--";
                dr[itemValue] = 0;
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();
            }
            ctl.DataSource = dt;
            ctl.DisplayMember = itemDisplay;
            ctl.ValueMember = itemValue;
            //ctl.SelectedIndex = 2;


           


        }

        public class PivotTable : DataTable
        {
            /// <summary>
            /// Builds a new PivotTable based on a given DataTable, a pivot column,
            /// and the column that contains the values to be summarized.
            /// </summary>
            /// <param name="dt">DataTable with the original data.</param>
            /// <param name="pivotField">Name of the column that contains the pivot values (e.g. year, quarter).</param>
            /// <param name="valueField">Name of the column that contains the values to summarize (e.g. sales).</param>
            /// <param name="sum">Set to true to sum values, false to count.</param>
            public PivotTable(DataTable dt, string pivotField, string valueField, bool sum)
            {
                // sort source table by pivot values
                // so pivot columns will be added in order
                DataView dv = new DataView(dt);
                dv.Sort = pivotField;

                // create list of key columns
                // used as keys when adding rows to the pivot table
                ArrayList keyColumns = new ArrayList();
                foreach (DataColumn col in dt.Columns)
                {
                    string colName = col.ColumnName;
                    if (colName != pivotField && colName != valueField)
                    {
                        DataColumn key = Columns.Add(colName, col.DataType);
                        keyColumns.Add(key);
                    }
                }

                // add keys to pivot table (to enable lookup)
                UniqueConstraint unique = new UniqueConstraint(
                    (DataColumn[])keyColumns.ToArray(typeof(DataColumn)), true);
                Constraints.Add(unique);

                // dimension look up array
                object[] keys = new object[keyColumns.Count];

                // use int or decimal to count or sum values
                Type type = (sum) ? typeof(decimal) : typeof(int);

                // add values to pivot table
                Hashtable pivotNames = new Hashtable();
                foreach (DataRowView drv in dv)
                {
                    // get pivot value
                    string pivotValue = drv[pivotField].ToString();

                    // get pivot column name (from hash if we can, to save time)
                    string pivotName = pivotNames[pivotValue] as string;
                    if (pivotName == null)
                    {
                        // build pivot column name
                        pivotName = Regex.Replace(pivotField, "[aeiou]", string.Empty);
                        if (pivotName.Length > 5) pivotName = pivotName.Substring(0, 5);
                        pivotName += pivotValue;
                        pivotName = Regex.Replace(pivotName, "[^A-Za-z0-9_]", string.Empty);

                        // save it for next time
                        pivotNames[pivotValue] = pivotName;
                    }

                    // add pivot column if necessary
                    if (!Columns.Contains(pivotName))
                        Columns.Add(pivotName, type);

                    // lookup existing row based on key columns
                    for (int i = 0; i < keys.Length; i++)
                    {
                        string name = ((DataColumn)keyColumns[i]).ColumnName;
                        keys[i] = drv[name];
                    }
                    DataRow drp = Rows.Find(keys);

                    // add new row if necessary
                    if (drp == null)
                    {
                        drp = NewRow();
                        foreach (DataColumn col in keyColumns)
                        {
                            string name = col.ColumnName;
                            drp[name] = drv[name];
                        }
                        Rows.Add(drp);
                    }

                    // get current aggregate value
                    decimal oldVal = (drp[pivotName] != DBNull.Value)
                        ? (decimal)Convert.ChangeType(drp[pivotName], typeof(decimal))
                        : (decimal)0;

                    // calculate aggregate (sum or count)
                    if (sum)
                    {
                        decimal newVal = (drv[valueField] != DBNull.Value)
                            ? (decimal)Convert.ChangeType(drv[valueField], typeof(decimal))
                            : (decimal)0;
                        drp[pivotName] = oldVal + newVal;
                    }
                    else
                    {
                        if (drv[valueField] != DBNull.Value)
                            drp[pivotName] = (int)oldVal + 1;
                    }
                }
            }
        }
    }
}
