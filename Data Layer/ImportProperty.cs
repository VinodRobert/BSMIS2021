using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;


namespace BSMIS
{
    public class ImportingProperty
    {
        /// <summary>
   
        /// </summary>
        /// <param name="inputObject"></param>
        /// <param name="ds"></param>
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
                            if (property.GetType() == typeof(int))
                            {
                                property.SetValue(inputObject, (_dr[_dc.ColumnName]==DBNull.Value?0:_dr[_dc.ColumnName]), null);
                            }
                            else
                            {
                                property.SetValue(inputObject, _dr[_dc.ColumnName], null);
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
      
        /// </summary>
        /// <param name="inputObject"></param>
        /// <param name="dr"></param>
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
                        if (property.GetType() == typeof(int))
                        {
                            property.SetValue(inputObject, (dr[_dc.ColumnName] == DBNull.Value ? 0 : dr[_dc.ColumnName]), null);
                        }
                        else
                        {
                            property.SetValue(inputObject, dr[_dc.ColumnName], null);
                        }
                    }
                }
            }

        }
        
    }
}
