
#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
#endregion

namespace BSMIS 
{
    class Stores
    {
        public DataSet ReceiptIssue(int _fromPeriod, int _toPeriod, int _finYear,   DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@STARTPERIOD", SqlDbType.Int);
            arParms[0].Value = _fromPeriod;
            arParms[1] = new SqlParameter("@ENDPERIOD", SqlDbType.Int);
            arParms[1].Value = _toPeriod;
            arParms[2] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[2].Value = _finYear;
            arParms[3] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[RECEIPTS_AND_ISSUES_GLOBAL]", arParms);
            return ds;
        }


        public DataSet UnReconDelivery(DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[CONSOLIDATEUNRECONDELIVERIES]", arParms);
            return ds;
        }

        public DataSet FetchAllStores()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DISTINCT INV.BORGID,B.BORGNAME,INV.STKSTORE FROM INVENTORY INV   INNER  JOIN BORGS B ON INV.BORGID=B.BORGID  WHERE LEFT(STKSTORE,3)='MS-' ORDER BY INV.BORGID   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetInventory()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT STKCODE,STKDESC FROM INVENTORY WHERE  STKSTORE='VMAINSTORE' ORDER BY STKDESC   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetNegativeDelivery(int _choice)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@CHOICE", SqlDbType.Int);
            arParms[0].Value = _choice;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetNegativeDelivery", arParms);
       
            return ds;
        }

        public DataSet DropNegativeDelivery(int _dlvrID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@DLVRID", SqlDbType.Int);
            arParms[0].Value = _dlvrID;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spDropNegativeDelivery", arParms);
            return ds;
        }

        public DataSet GetPositiveDelivery(Int64 _ordID,int _ordItemLineNo)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@ORDID", SqlDbType.BigInt);
            arParms[0].Value = _ordID;
            arParms[1] = new SqlParameter("@ORDITEMLINENO", SqlDbType.Int);
            arParms[1].Value = _ordItemLineNo;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetPositiveDelivery", arParms);

            return ds;
        }

        public DataSet GetFullInventory()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spFullInventoryList");
            return ds;
        }
        public DataSet StockMovement(DataTable _Inventory, int _borgID)
        {
            SqlParameter[] arParms = new SqlParameter[2];
           
            arParms[0] = new SqlParameter("@LISTINVENTORY", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.LISTSTOCKITEMS";
            arParms[0].Value = _Inventory;
            arParms[1] = new SqlParameter("@BORGID", SqlDbType.Int);
            arParms[1].Value = _borgID;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spStockMovement]", arParms);
            return ds;
        }

        public DataSet FetchNegativeDeliviers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spFetchNegativeDeliveries");
            return ds;
        }
       

        public DataSet FetchPositiveDeliveries(int _borgID, int _ordID, int _itemLineNumber )
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@BORGID", SqlDbType.Int);
            arParms[0].Value = _borgID;
            arParms[1] = new SqlParameter("@ORDID", SqlDbType.Int);
            arParms[1].Value = _ordID;
            arParms[2] = new SqlParameter("@ITEMLINENO", SqlDbType.Int);
            arParms[2].Value = _itemLineNumber;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spFetchPositiveDeliveries]", arParms);
            return ds;
        }



        public DataSet StockAge(string _fromDateString, DataTable _Inventory, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@CUTOFFDATE", SqlDbType.Text);
            arParms[0].Value = _fromDateString;
            arParms[1] = new SqlParameter("@LISTINVENTORY", SqlDbType.Structured);
            arParms[1].TypeName = "dbo.ListStockItems";
            arParms[1].Value = _Inventory;
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spStockAging]", arParms);
            return ds;
        }

        public DataSet StockAgeXFR(string _fromDateString, DataTable _Inventory, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@CUTOFFDATE", SqlDbType.Text);
            arParms[0].Value = _fromDateString;
            arParms[1] = new SqlParameter("@LISTINVENTORY", SqlDbType.Structured);
            arParms[1].TypeName = "dbo.ListStockItems";
            arParms[1].Value = _Inventory;
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spStockAgingXFR]", arParms);
            return ds;
        }

        public DataSet StockOfADay(string _fromDateString, DataTable _Inventory, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@CUTOFFDATE", SqlDbType.Text);
            arParms[0].Value = _fromDateString;
            arParms[1] = new SqlParameter("@LISTINVENTORY", SqlDbType.Structured);
            arParms[1].TypeName = "dbo.ListStockItems";
            arParms[1].Value = _Inventory;
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spStockOfADay]", arParms);
            return ds;
        }
    }
}
