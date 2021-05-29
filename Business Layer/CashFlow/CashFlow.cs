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
    class CashFlow
    {
        public DataSet ExtractBatch(Int64 _tranGrp)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT ORGID,YEAR,PERIOD,PDATE,BATCHREF,TRANSREF,TRANSTYPE,ALLOCATION,LEDGERCODE,CONTRACT,ACTIVITY,DESCRIPTION,CURRENCY,DEBIT,CREDIT,CREDNO,STORE,STOCKNO,QUANTITY,UNIT,RATE,REQNO,ORDERNO,TRANSID,USERID,TRANGRP FROM TRANSACTIONS  WHERE TRANGRP=" + Convert.ToString(_tranGrp) + "ORDER BY TRANSID ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;

        }

      

        public DataSet GenerateCashFlow(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Borgs )
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@BORGS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _Borgs;
             


            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spCashFlow]", arParms);
            return ds;
        }

    }

}
