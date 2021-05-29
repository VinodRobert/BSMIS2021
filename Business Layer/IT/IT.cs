
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
    public class IT
    {
      

        #region Functions

        public DataSet GetWODetails(string ordNumber)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT  S.SUPPNAME FROM ORD O INNER JOIN SUPPLIERS S ON O.SUPPID=S.SUPPID WHERE O.ORDNUMBER='" + Convert.ToString(ordNumber).Trim() + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetLoginUsers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetLoginUsers");
            return ds;
        }

     

        public int DoBookKeeping()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BS].[spBookKeepingNightRevised]");
            return i;
        }

        public DataSet GetPrivelegeLoginUsers()
        {
            string _sql = "SELECT USERNAME FROM USERS WHERE LOCKED=0 AND POORDBY<>9  ORDER BY USERNAME";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet CheckCurrentlyLocked()
        {
            string _sql = "Select ISNULL(COUNT(*),0) COUNTERS FROM BI.LOGINSUSPENS  ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int LockAllUsers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Update Users Set Locked=1 ";
            SqlParameter[] arParms = new SqlParameter[1];
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return 1;
        }

        public int UnLockAllUsers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Update Users Set Locked=0 where POORDBY<>9 ";
            SqlParameter[] arParms = new SqlParameter[1];
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return 1;
        }

        public int UnLockUser(string _who)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Update Users Set Locked=0 where UserName='" + _who.Trim() + "'";
            SqlParameter[] arParms = new SqlParameter[1];
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return 1;
        }


        public int UnLockUser()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ACTION", SqlDbType.Int);
            arParms[0].Value = 0;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[LOCKUSERS]", arParms);
            return 1;
        }


        public DataSet ProjectPeriodPermanentLockStatus(int _finYear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spPeriodPermanentLockStatus",arParms);
            return ds;
        }

        public DataSet ExractPeriodStatus(int _finYear, int _period, int _action)
        {
            string _connectionString = SqlHelper.GetConnectionString();
          

            string _sql = "SELECT B.BORGID,B.BORGNAME FROM BORGS B WHERE BORGID IN (SELECT ORGID FROM PERIODSETUP WHERE YEAR=";
            _sql = _sql + Convert.ToString(_finYear) + " AND PERIOD= " + Convert.ToString(_period) + " AND STATUS= " + Convert.ToString(_action) + ") ";
            _sql = _sql + " AND BORGID NOT IN ( 22, 23, 24, 26, 27,59 ) AND LEFT(BORGNAME,1)='9'  ORDER BY BORGID ";
            DataSet _ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return _ds;
        }

        public DataSet GetPeriodOverRiderUserList()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT USERNAME, LOGINID , USERID   FROM USERS WHERE USERID IN (SELECT USERID FROM USERADMINPROCESSES WHERE PROCESS='Period Override' AND ALLOW=1) ORDER BY USERNAME ";
            DataSet _ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return _ds;
        }


        public int SetPeriodGlobally(int _finYear, int _period, DataTable _OrgIDS, int _status)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = Convert.ToInt16(_finYear);
            arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
            arParms[1].Value = Convert.ToInt16(_period);
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;
            arParms[3] = new SqlParameter("@STATUS", SqlDbType.Int);
            arParms[3].Value = _status; 

            string _connectionString = SqlHelper.GetConnectionString();
            int _result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BI].[spGlobalPeriodLockUnlock]", arParms);
            return _result;
        }

        public int RevokePeriodOverRidePrevelege(string _who)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "UPDATE USERADMINPROCESSES SET ALLOW=0  WHERE PROCESS='Period Override' AND ALLOW=1 AND USERID = " + Convert.ToString(_who); 
            int _result = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text ,_sql );
            return _result;
        }

        

        #endregion

    }
}