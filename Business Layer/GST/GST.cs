
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
    public class GST
    {


        #region Functions
        public DataSet GetAllCILGSTIN(DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetCILGSTIN" ,   arParms);
            return ds;
        }

        public DataSet GSTPurchase(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Borgs, DataTable _CILGSTIN, DataTable _DocType, DataTable _GSTType )
        {
            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@BORGS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _Borgs;
            arParms[4] = new SqlParameter("@CILGSTIN", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListCILGSTIN";
            arParms[4].Value = _CILGSTIN;
            arParms[5] = new SqlParameter("@DOCType", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListDocType";
            arParms[5].Value = _DocType;
            arParms[6] = new SqlParameter("@GSTType", SqlDbType.Structured);
            arParms[6].TypeName = "dbo.LisGSTType";
            arParms[6].Value = _GSTType;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGSTPurchase", arParms);
            return ds;
        }

        public DataSet GSSuppliers(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Borgs, string _ledgerCode) 
        {
            SqlParameter[] arParms = new SqlParameter[5];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@BORGS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _Borgs;
            arParms[4] = new SqlParameter("@LEDGERCODE", SqlDbType.Text);
            arParms[4].Value = _ledgerCode;
            

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGSTSupplier", arParms);
            return ds;
        }


        public DataSet GSTSales(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Borgs, DataTable _CILGSTIN, DataTable _DocType, DataTable _GSTType)
        {
            SqlParameter[] arParms = new SqlParameter[7];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@BORGS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _Borgs;
            arParms[4] = new SqlParameter("@CILGSTIN", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListCILGSTIN";
            arParms[4].Value = _CILGSTIN;
            arParms[5] = new SqlParameter("@DOCType", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListDocType";
            arParms[5].Value = _DocType;
            arParms[6] = new SqlParameter("@GSTType", SqlDbType.Structured);
            arParms[6].TypeName = "dbo.LisGSTType";
            arParms[6].Value = _GSTType;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGSTSales", arParms);
            return ds;
        }
        public DataSet ExtractBatch(Int64 _tranGrp)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT ORGID,YEAR,PERIOD,PDATE,BATCHREF,TRANSREF,TRANSTYPE,ALLOCATION,LEDGERCODE,CONTRACT,ACTIVITY,DESCRIPTION,CURRENCY,DEBIT,CREDIT,CREDNO,STORE,STOCKNO,QUANTITY,UNIT,RATE,REQNO,ORDERNO,TRANSID,USERID,TRANGRP FROM TRANSACTIONS  WHERE TRANGRP=" + Convert.ToString(_tranGrp) + "ORDER BY TRANSID ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
            
        }
         
     

      #endregion

    }
}