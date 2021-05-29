
#region Using
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Windows;
#endregion

namespace BSMIS
{
    public class Entities
    {

        #region Functions
      

        public DataSet GetPaymentBatchRolesLevelZero()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT * FROM PB.PAYBATCHROLES WHERE ROLEID NOT IN (SELECT STARTROLEID FROM PB.PAYBATCHWORKFLOW) ORDER BY ROLENAME ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetPaymentBatchRolesLevelOne(int levelZeroRoleID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT * FROM PB.PAYBATCHROLES WHERE ROLEID NOT IN (SELECT ENDROLEID FROM PB.PAYBATCHWORKFLOW WHERE STARTROLEID= ";
            _sql = _sql + Convert.ToString(levelZeroRoleID) + " ) AND ROLEID <> " +Convert.ToString(levelZeroRoleID) + " ORDER BY ROLENAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public int UpdatePaymentBatchWorkFlow(int levelZeroRole, int levelOneRole)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "INSERT INTO PB.PAYBATCHWORKFLOW VALUES(" + Convert.ToString(levelZeroRole) + "," + Convert.ToString(levelOneRole)  + ")";
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }
        public DataSet GetPaymentBatchWorkFlow()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT * FROM PB.PBORGLEVELAPPROVALS ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int UpdatePaymentBatchUsers(string bsLoginID,string bsLoginName,string bsLoginPassword,string pbRoleName)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "INSERT INTO PB.PAYMENTBATCHUSERS VALUES('" + Convert.ToString(bsLoginID).TrimEnd() + "','" + Convert.ToString(bsLoginName) + "','" + Convert.ToString(bsLoginPassword).TrimEnd() + "',"+   Convert.ToString(pbRoleName)+")";
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }

        public DataSet GetPaymentBatchUsers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT PBU.BSLOGINID,PBU.BSUSERNAME,PBR.LEVELNAME FROM PB.PAYMENTBATCHUSERS PBU INNER JOIN PB.APPROVALLEVELS PBR ON PBR.APPROVERLEVELID = PBU.APPROVERLEVELID ORDER BY[BSUSERNAME] ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetBorgid(string borgName)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT BORGID FROM BORGS WHERE BORGNAME='" + Convert.ToString(borgName).Trim() + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
     

        public int ResetMapping(string loginID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "DELETE FROM  PB.PAYMENTBATCHUSERORGROLEMAPPING WHERE BSLOGINID='" + Convert.ToString(loginID).Trim() + "'";
            int k = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return k;
        }


        public int UpdatePBUserProjectMapping(string loginID,int  borgID, string  processID,int  userApproverLevelID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Select isnull( count(*),0) Counts from PB.PAYMENTBATCHUSERORGROLEMAPPING where bsloginid='" + Convert.ToString(loginID) + "' and bsorgid='" + Convert.ToString(borgID) + "'";
            _sql = _sql + " and bsprocess='" + Convert.ToString(processID) + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            int counter = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
            if (counter>=1)
                return 0;
            _sql = "insert into PB.PAYMENTBATCHUSERORGROLEMAPPING(bsloginid,bsorgid,bsprocess,APPROVERLEVELID) values(";
            _sql = _sql + "'" + Convert.ToString(loginID) + "'," + Convert.ToString(borgID) + ",'" + Convert.ToString(processID) + "'," + Convert.ToString(userApproverLevelID) + ")";
            int k = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return k;
        }


        public DataSet GetPaymentBatchUserRole(string bsLoginID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT L.LEVELNAME,L.APPROVERLEVELID FROM PB.APPROVALLEVELS L WHERE APPROVERLEVELID = (SELECT APPROVERLEVELID FROM PB.PAYMENTBATCHUSERS WHERE BSLOGINID = '" + Convert.ToString(bsLoginID).Trim() + "');";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

         

        public DataSet GetProjectAssignment(string bsLoginID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "  SELECT O.BSORGNAME, CASE WHEN PBU.BSPROCESS = 'C' THEN 'Creditors'   WHEN PBU.BSPROCESS = 'S' THEN 'SubContractors'  END AS BSPROCESS, L.LEVELNAME ";
            _sql = _sql + "  FROM PB.PAYMENTBATCHUSERORGROLEMAPPING PBU INNER JOIN PB.PAYMENTBATCHORGS O ON PBU.BSORGID = O.BSORGID  INNER JOIN PB.APPROVALLEVELS L ON PBU.APPROVERLEVELID = L.APPROVERLEVELID ";
            _sql = _sql + "  WHERE PBU.BSLOGINID = '" + Convert.ToString(bsLoginID).Trim() + "';";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetPaymentBatchUserPassword(string bsLoginID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT PASSWORD FROM USERS WHERE LOGINID='" + Convert.ToString(bsLoginID).TrimEnd() + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public  DataSet GetRemainingBSUsers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LOGINID,USERNAME FROM USERS WHERE LOCKED=0 AND LOGINID NOT IN (SELECT BSLOGINID FROM PB.PAYMENTBATCHUSERS) ORDER BY USERNAME";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int ValidatePaymentBatchRole(string newPayBatchRole)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT ISNULL(COUNT(*),0) FROM PB.PAYBATCHROLES WHERE ROLENAME='"+Convert.ToString(newPayBatchRole)+"'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            int counter = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
            if (counter == 0)
                return 0;
            else
                return 1;
        }


        public int EnablePaymentBatch(int borgID,string projectName)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "INSERT INTO PB.PAYMENTBATCHORGS VALUES(" + Convert.ToString(borgID) + ",'" + Convert.ToString(projectName) + "')";
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            _sql = "INSERT INTO BATCHREMIT(BATCHNO,BATORGID,BATPROCESS,BATDESC,BATSTATUS,BATDATEOPEN,BATUPDATE,BATPERIOD,BATYEAR,BATOWNER,BATCURRENCY,BATBANK)";
            _sql = _sql + "  VALUES(999, " + Convert.ToString(borgID) + ", 'C', 'System Generated', -1, GETDATE(), NULL, 0, 2020, 'admin', 'ALL', 0)";
            _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            _sql = "INSERT INTO BATCHREMIT(BATCHNO,BATORGID,BATPROCESS,BATDESC,BATSTATUS,BATDATEOPEN,BATUPDATE,BATPERIOD,BATYEAR,BATOWNER,BATCURRENCY,BATBANK)";
            _sql = _sql + "  VALUES(999, " + Convert.ToString(borgID) + ", 'S', 'System Generated', -1, GETDATE(), NULL, 0, 2020, 'admin', 'ALL', 0)";
            _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }

        public int UpdatePaymentBatchRoles(string paymentBatchRole)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "INSERT INTO PB.PAYBATCHROLES VALUES( '" + Convert.ToString(paymentBatchRole) + "')";
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }


        public DataSet GetProjectsEnrolledForPaymentBatch()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT * FROM PB.PAYMENTBATCHORGS ORDER BY BSORGID ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetBanksForEnrolledProjects()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet _ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "PB.spGetPaymentBanks");
            return _ds;
        }

        public DataSet GetSingleBankEntry(int bankID)
        {
            string _sql = "SELECT * FROM PB.PAYMENTBANKS WHERE BANKID="+Convert.ToString(bankID);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int UpdateBankAddress(int bankIndex, string txtAddress1,string  txtAddress2, string txtAddress3,string  txtPIN, string txtState)
        {
            string sql = "Update PB.PAYMENTBANKS SET ADDRESS1='" + Convert.ToString(txtAddress1).Trim() + "',ADDRESS2='" + Convert.ToString(txtAddress2).Trim() + "',ADDRESS3='" + Convert.ToString(txtAddress3).Trim() + "'";
            sql = sql + " ,STATE='" + Convert.ToString(txtState).Trim() + "',PIN='" + Convert.ToString(txtPIN).Trim() + "'  WHERE BANKID=" + Convert.ToString(bankIndex);
                
            string _connectionString = SqlHelper.GetConnectionString();
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
            return 1;
        }

        public int UpdatePaymentMode(int bankIndex, int mode)
        {
            string sql;
            if (mode==1)
                sql = "Update PB.PAYMENTBANKS SET CHEQUE=1 ,RTGS=0,API=0 WHERE BANKID=" + Convert.ToString(bankIndex);
            else
                if (mode==2)
                  sql = "Update PB.PAYMENTBANKS SET CHEQUE=0 ,RTGS=1,API=0 WHERE BANKID=" + Convert.ToString(bankIndex);
                else
                  sql = "Update PB.PAYMENTBANKS SET CHEQUE=0 ,RTGS=0,API=1 WHERE BANKID=" + Convert.ToString(bankIndex);
            
            string _connectionString = SqlHelper.GetConnectionString();
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
            return 1;
        }


        public int UpdateReference(int bankIndex, string txtAddress1, string txtAddress2, string txtAddress3)
        {
            string sql = "Update PB.PAYMENTBANKS SET REFERENCE='" + Convert.ToString(txtAddress1).Trim() + "',YEARREFERENCE='" + Convert.ToString(txtAddress2).Trim() + "',SERIALNUMBER='" + Convert.ToString(txtAddress3).Trim() + "'";
            sql = sql +   "   WHERE BANKID=" + Convert.ToString(bankIndex);

            string _connectionString = SqlHelper.GetConnectionString();
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, sql);
            return 1;
        }


        public DataSet GetPaymentBatchRoles()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT * FROM PB.APPROVALLEVELS ORDER BY LEVELCODE ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetProjectsNotEnrolledForPaymentBatch()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT BORGID,BORGNAME FROM BORGS  WHERE BORGID NOT IN (SELECT BSORGID FROM PB.PAYMENTBATCHORGS ) AND PARENTBORG  IN(23, 24, 25, 26)   ORDER BY BORGNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public DataSet Login(string _userID, string _pwd)
        {
            DataSet _ds; 
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[2];
          
            arParms[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
            arParms[0].Value = _userID;
            arParms[1] = new SqlParameter("@PWD", SqlDbType.VarChar);
            arParms[1].Value = _pwd;
            _ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spLogin",arParms);
            return _ds;
        }

        public DataSet GetFinancialYearFromDate(String _givenDate)
        {
            QueryString _qr = new QueryString();
            _qr.FieldList = " * ";
            _qr.Criteria = "1=1";
            _qr.OrderBy = "";
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@GIVENDATE", SqlDbType.VarChar);
            arParms[0].Value = _givenDate;
            SqlParameter[] parameters = SqlHelper.BindParameters(_qr, "BI.spGetFinYearFromDate", _connectionString);
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetFinYearFromDate", arParms);
            return ds;
        }

        public DataSet GetFinancialYears()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DISTINCT [YEAR] FINYEAR  FROM PERIODSETUP WHERE YEAR>2014 AND ORGID=2 ORDER BY YEAR DESC ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDepreciationFinancialYears()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT CURRENTYEAR,PERIOD,PERIODDESC  FROM BORGS INNER JOIN PERIODMASTER ON PERIODMASTER.PERIODID=BORGS.PERIOD WHERE BORGID=2  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetAllCostLedgers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LEDGERALLOC,LEDGERCODE,LEDGERNAME FROM LEDGERCODES WHERE LEDGERALLOC IN ('Contracts','Overheads') AND LEDGERSUMMARY=0 ORDER BY LEDGERALLOC,LEDGERCODE ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetBorgs(int _zoneID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@ZONE", SqlDbType.Int);
            arParms[0].Value = _zoneID;
            // Execute the stored procedure
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetBorgs", arParms);
            return ds;
        }
        public DataSet GetPeriods()
        {
            
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "select PERIODID,PERIODDESC from periodmaster order by PeriodID";
          
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text , _sql);
            return ds;
        }

        public DataSet GetCreditors()
        {
            string _connectionString = SqlHelper.GetConnectionString();
         
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetCreditors");
            return ds;
        }

        public DataSet GetGroupLedgerHead()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT GROUPLEDGERCODE,GROUPLEDGERNAME FROM BI.GROUPLEDGERHEAD    ORDER BY GROUPLEDGERNAME ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetGroupLedgerHeadWithSubLedgers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT GROUPLEDGERCODE ,GROUPLEDGERNAME FROM BI.GROUPLEDGERHEAD WHERE SUBLEDGERAPPLICABLE=1 ORDER BY GROUPLEDGERNAME ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetGroupDetail(int _groupHeadID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "select LedgerCode,LedgerName,GroupLedgerDetailCode from BI.groupLedgerDetail where  GroupLedgerCode='" + Convert.ToString(_groupHeadID) + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetGroupHead(int _groupHeadID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "select * from BI.GROUPLEDGERHEAD where GroupLedgerCode='" + Convert.ToString(_groupHeadID) + "'";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetFreeGroupDetail()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LEDGERALLOC,LEDGERCODE,LEDGERNAME FROM LEDGERCODES WHERE LEDGERALLOC IN ('Contracts','Overheads') AND LEDGERSUMMARY=0 ";
            _sql = _sql + " AND LEDGERCODE NOT IN (SELECT LEDGERCODE FROM BI.GROUPLEDGERDETAIL ) ORDER BY LEDGERALLOC,LEDGERCODE ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public int DeleteGroupDetail(int _groupLedgerDetailCode)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Delete from BI.GROUPLEDGERDETAIL where GROUPLEDGERDETAILCODE= " + Convert.ToString(_groupLedgerDetailCode)  ;
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }

        public int DeleteGroupHead(int _groupHeaderCode)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Delete from BI.GroupLedgerDetail where GroupLedgerCode=" + Convert.ToString(_groupHeaderCode);
            _sql = _sql + ";Delete from BI.GROUPLEDGERHEAD where GROUPLEDGERCODE= " + Convert.ToString(_groupHeaderCode);
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        }

        public bool UpdateGroupDetail(int _groupLedgerCode, string _ledgercode, string _ledgerName)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql;
            _sql = "INSERT INTO [BI].[GROUPLEDGERDETAIL] ([GROUPLEDGERCODE],[LEDGERCODE],[LEDGERNAME]) VALUES ";
            _sql = _sql + "(" + Convert.ToString(_groupLedgerCode) + ",'" + _ledgercode + "','" + _ledgerName + "')";

   
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
       
            return true;
        }

        public bool UpdateGroupHeader(string _groupLedgerName, int _subLedgerApplicable )
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "INSERT INTO [BI].[GROUPLEDGERHEAD]  VALUES  ('"+_groupLedgerName+ "'," + Convert.ToString(_subLedgerApplicable) + ") ";

            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
             
            return true;
        }


        public DataSet GetActiveFinYear()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGetActiveFinYear]");
            return ds;
        }

        

        public DataSet GetZones()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetZones");
            return ds;
        }

        public DataSet GetCreditorAge(int _agedTo, string _dtAgeAsOn, int _periodAgeOn, int _finYear, int _agingON, string _cmbCreditor, int _cmbZone, int _cmbOrg)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@AGEDTO", SqlDbType.Int);
            arParms[0].Value = _agedTo;
            arParms[1] = new SqlParameter("@AGEDTODATE", SqlDbType.Text);
            arParms[1].Value = _dtAgeAsOn;
            arParms[2] = new SqlParameter("@AGEDTOPERIOD", SqlDbType.Int);
            arParms[2].Value = _periodAgeOn;
            arParms[3] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[3].Value = _finYear;
            arParms[4] = new SqlParameter("@AGEOF", SqlDbType.Int);
            arParms[4].Value = _agingON;
            arParms[5] = new SqlParameter("@CREDITOR", SqlDbType.VarChar);
            arParms[5].Value = _cmbCreditor;
            arParms[6] = new SqlParameter("@ZONE", SqlDbType.Int);
            arParms[6].Value = _cmbZone;
            arParms[7] = new SqlParameter("@ORGID", SqlDbType.Int);
            arParms[7].Value = _cmbOrg;
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[CREDITORAGING]", arParms);
            return ds;
        }


        public DataSet GetLedgerAmount(System.Data.DataTable _OrgIDS, int _groupHeaderID, int _cyfp, int _cytp, int _pyfp, int _pftp, int _finYear)
        {
            SqlParameter[] arParms = new SqlParameter[7];
 
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            arParms[1] = new SqlParameter("@GROUPHEADERID", SqlDbType.Int);
            arParms[1].Value = _groupHeaderID;
            arParms[2] = new SqlParameter("@CYFP", SqlDbType.Int);
            arParms[2].Value = _cyfp;
            arParms[3] = new SqlParameter("@CYTP", SqlDbType.Int);
            arParms[3].Value = _cytp;
            arParms[4] = new SqlParameter("@PYFP", SqlDbType.Int);
            arParms[4].Value = _pyfp;
            arParms[5] = new SqlParameter("@PYTP", SqlDbType.VarChar);
            arParms[5].Value = _pftp;
            arParms[6] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[6].Value =_finYear ;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[LEDGERAMOUNT]", arParms);
            return ds;

        }
        public DataSet GetLedgerAmountWithSubLedgers(System.Data.DataTable _OrgIDS, int _groupLedgerCode, int _finYear, int _cyfp, int _cytp)
        {
            SqlParameter[] arParms = new SqlParameter[7];
 
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            arParms[1] = new SqlParameter("@GROUPLEDGERCODE", SqlDbType.Int);
            arParms[1].Value = _groupLedgerCode;
            arParms[2] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[2].Value =_finYear ;
            arParms[3] = new SqlParameter("@CYFP", SqlDbType.Int);
            arParms[3].Value = _cyfp;
            arParms[4] = new SqlParameter("@CYTP", SqlDbType.Int);
            arParms[4].Value = _cytp;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[LEDGERAMOUNTWITHSUBLEDGER]", arParms);
            return ds;

        }
         

        public void ExportToExcel(DataSet _ds )
        {
         try
            {
             ////   Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
             //   Workbook xlWorkbook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
 
                
             //   DataTableCollection collection = _ds.Tables;
             //   int i;
             //   i = 3;
             //   //for (i = collection.Count; i > 0; i--)
             //   //{
             //       Sheets xlSheets = null;
             //       Worksheet xlWorksheet = null;
             //       //Create Excel Sheets
             //       xlSheets = ExcelApp.Sheets;
             //       xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1],
             //                      Type.Missing, Type.Missing, Type.Missing);
 
             //       System.Data.DataTable table = collection[i - 1];
             //       xlWorksheet.Name = table.TableName;
                    
             //       xlWorksheet.Cells[1, 1] = "Your title here";

             //       for (int j = 1; j < table.Columns.Count + 1; j++)
             //       {
             //           ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;
             //       }
 
             //       // Storing Each row and column value to excel sheet
             //       for (int k = 0; k < table.Rows.Count; k++)
             //       {
             //           for (int l = 0; l < table.Columns.Count; l++)
             //           {
             //               ExcelApp.Cells[k + 2, l + 1] =
             //               table.Rows[k].ItemArray[l].ToString();
             //           }
             //       }
             //       ExcelApp.Columns.AutoFit();
             //   //}
             //   ((Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
             //   ExcelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        }


        
        #endregion

    }
 
 