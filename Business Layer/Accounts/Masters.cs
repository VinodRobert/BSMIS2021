using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;

namespace BSMIS 
{
    class Masters
    {
        public DataSet GetMasterCategory(int masterCategory)
        {
            string _sql = "SELECT * from BI.MASTERCATEGORY where partytype="+ Convert.ToString(masterCategory) + " ORDER BY MASTERCATEGORYNAME ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetPartyCodes(int i)
        {
            string _connectionString = SqlHelper.GetConnectionString();
          
            string sql;
            if (i==1)
            {
                sql = "SELECT CREDNUMBER PARTYCODE FROM CREDITORS WHERE CREDNUMBER<>'' ORDER BY CREDNUMBER ";
            }
            else
            {
                sql = "SELECT SUBNUMBER PARTYCODE FROM SUBCONTRACTORS WHERE SUBNUMBER<>'' ORDER BY SUBNUMBER ";
            }

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql);
            return ds;
        }

        public int InsertNewCategoryName(string newCategoryName,int masterCategory)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string sql = "Select ISNULL(Count(*),0) FROM BI.MASTERCATEGORY WHERE MASTERCATEGORYNAME='" + Convert.ToString(newCategoryName).Trim() + "' AND PARTYTYPE=" + Convert.ToString(masterCategory);
            var counts = SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, sql);
            if (Convert.ToInt32(counts)==1)
               return 1;
            else
            {
                sql = "Select MAX(MasterCategoryCode) FROM BI.MASTERCATEGORY";
                var nextCode = SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, sql);
                var nextCategoryCode = Convert.ToInt32(nextCode) + 10;
                sql = "INSERT INTO BI.MASTERCATEGORY SELECT " + Convert.ToString(nextCategoryCode) + ",'" + Convert.ToString(newCategoryName.Trim()) + "'," + Convert.ToString(masterCategory);
                int j = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
                return 0;
            }
        }


        public int UpdateMasterCategory(string partyCode, string categoryName)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string sql = "Select ISNULL(Count(*),0) FROM BI.MASTERCATEGORYLIST WHERE PARTYCODE='" + Convert.ToString(partyCode).Trim() + "'";
            var counts = SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, sql);
            if (Convert.ToInt32(counts) == 1)
                return 1;
            else
            {
                //sql = "Select MAX(MasterCategoryCode) FROM BI.MASTERCATEGORY";
                //var nextCode = SqlHelper.ExecuteScalar(_connectionString, CommandType.Text, sql);
                //var nextCategoryCode = Convert.ToInt32(nextCode) + 10;
                //sql = "INSERT INTO BI.MASTERCATEGORY SELECT " + Convert.ToString(nextCategoryCode) + ",'" + Convert.ToString(newCategoryName.Trim()) + "'," + Convert.ToString(masterCategory);
                //int j = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
                 return 0;
            }
        }

    }
}
