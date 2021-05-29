
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
    public class CreditorAge
    {


        #region Functions
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
        public DataSet GetMasterItems()
        {
            string sql = "select CONTROLID,CONTROLNAME from controlcodes where controlid in (10,11,13) ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql);
            return ds;
        }
        public DataSet GetFinancialYears()
        {
            string _sql = "SELECT DISTINCT [YEAR] FINYEAR FROM TRANSACTIONS WHERE YEAR>=2014 ORDER BY YEAR ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetFinancialYearsForLedgerReports()
        {
            string _sql = "SELECT DISTINCT [YEAR] FINYEAR FROM TRANSACTIONS WHERE YEAR>=2015 ORDER BY YEAR ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetBudgetYears()
        {
            string _sql = "SELECT DISTINCT FINYEAR  FROM BI.YEARLYBUDGETS ORDER BY FINYEAR  ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }



        public DataSet GetActiveFinancialYears(int _currentFinYear)
        {
            string _sql = "SELECT DISTINCT [YEAR] FINYEAR FROM TRANSACTIONS WHERE YEAR>=2016 AND YEAR<= 2023  ORDER BY YEAR ";
            string _connectionString = SqlHelper.GetConnectionString();

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

        public DataSet GetBorgs(string _ZoneNames)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ZoneNames", SqlDbType.Text);
            arParms[0].Value = _ZoneNames;
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetBorgsSelected", arParms);
            return ds;
        }
          
        public DataSet GetGSTLedgers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT NAME,LEDGERCODE  FROM VATGROUPS WHERE NAME LIKE '%GST%' ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;  
            
        }

        public DataSet GetPeriods()
        {
            QueryString _qr = new QueryString();
            _qr.FieldList = " * ";
            _qr.Criteria = "1=1";
            _qr.OrderBy = "PeriodID";
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] parameters = SqlHelper.BindParameters(_qr, "[BI].[spGetPeriod] ", _connectionString);
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGetPeriod]", parameters);
            return ds;
        }

        public DataSet GetFullPeriods()
        {
            QueryString _qr = new QueryString();
            _qr.FieldList = " * ";
            _qr.Criteria = "1=1";
            _qr.OrderBy = null;
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] parameters = SqlHelper.BindParameters(_qr, "[BI].[spGetFullPeriod] ", _connectionString);
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGetFullPeriod]", parameters);
            return ds;
        }

        public DataSet GetCreditors()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT CREDNUMBER,( CREDNUMBER+'-'+ CREDNAME ) CREDNAME FROM CREDITORS   ORDER BY CREDNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public DataSet GetSubContractors()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT SUBNUMBER CREDNUMBER,( SUBNUMBER+'-'+ SUBNAME ) CREDNAME FROM SUBCONTRACTORS   ORDER BY CREDNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtors()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER,(DEBTNUMBER+'-'+ DEBTNAME) DEBTNAME  FROM DEBTORS    ORDER BY DEBTNAME   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetCreditorsCommon()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT CREDNUMBER PARTYCODE,(LTRIM(RTRIM(CREDNAME)) +' ('+ CREDNUMBER +') ' ) PARTYNAME FROM CREDITORS   ORDER BY PARTYNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public DataSet GetSubContractorsCommon()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT SUBNUMBER PARTYCODE,(LTRIM(RTRIM(SUBNAME)) +' ('+ SUBNUMBER +')' ) PARTYNAME FROM SUBCONTRACTORS   ORDER BY PARTYNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtorsCommon()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER PARTYCODE,(LTRIM(RTRIM(DEBTNAME)) +' ('+ DEBTNUMBER +')' ) PARTYNAME  FROM DEBTORS    ORDER BY PARTYNAME   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public DataSet GetCreditorsNameOnly()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT CREDNUMBER PARTYCODE ,UPPER(LTRIM(RTRIM(CREDNAME))) PARTYNAME FROM CREDITORS WHERE CREDNAME<>''  ORDER BY CREDNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetSubbieeNameOnly()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT SUBNUMBER PARTYCODE ,UPPER(LTRIM(RTRIM(SUBNAME))) PARTYNAME FROM SUBCONTRACTORS WHERE SUBNAME<> '' ORDER BY SUBNAME ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtorsNameOnly()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER PARTYCODE ,UPPER(LTRIM(RTRIM(DEBTNAME))) PARTYNAME  FROM DEBTORS WHERE DEBTNAME<>''   ORDER BY DEBTNAME   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetSalesPercentage(int _finYear, int _borgID )
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT BP.PERIOD Period ,P.PERIODDESC Month ,BP.PRODPERCENTAGE Percentage FROM BI.SALESPERCENTAGE BP INNER JOIN PERIODMASTER P ON P.PERIODID = BP.PERIOD WHERE ";
            _sql = _sql + " BP.ORGID="+Convert.ToString(_borgID) + "  ORDER BY BP.PERIOD   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchLedgersHavingImpact()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LEDGERNAME FROM LEDGERCODES WHERE LEDGERCODE IN ( SELECT COLKEY FROM ATTRIBVALUE WHERE TABLENAME='LEDGERCODES' AND ATTRIBUTE= 'Sales % Effect in Budget' AND VALUE=1)";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
         
        public DataSet GetProjectsHavingBudget()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT  BORGID, BORGNAME FROM BORGS WHERE BORGID IN (SELECT DISTINCT ORGID FROM BI.YEARLYBUDGETS) ORDER BY BORGNAME   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetFullProjects()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT  BORGID, BORGNAME FROM BORGS WHERE PARENTBORG IN (24,25,26,27)  ORDER BY BORGNAME   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        //public DataSet GetDebtors()
        //{
        //    string _connectionString = SqlHelper.GetConnectionString();
        //    string _sql = "SELECT DEBTNUMBER,(DEBTNUMBER+'-'+ DEBTNAME) DEBTNAME  FROM DEBTORS    ORDER BY DEBTNAME   ";
        //    DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
        //    return ds;
        //}



        public DataSet FetchBudgetVsActual(int _finYear, int _borgID)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@ORGID", SqlDbType.Int);
            arParms[1].Value = _borgID;
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spUpdateActuals", arParms);
            return ds;
        }

        public int UpdateSalesPercentage(int _finYear,int _period, int _orgID, decimal _percentage )
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Update BI.SALESPERCENTAGE SET PRODPERCENTAGE=" + Convert.ToString(_percentage);
            _sql = _sql + " where Year = " + Convert.ToString(_finYear) + " and  ORGID= " + Convert.ToString(_orgID) + " and PERIOD = "+ Convert.ToString(_period ) ;
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
             
        }


       


        public DataSet GetCreditorsOrdered()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT  CREDNUMBER,( LTRIM(RTRIM(CREDNAME))+'('+ LTRIM(RTRIM(CREDNUMBER)) +')' ) CREDNAME FROM CREDITORS    ORDER BY CREDNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        
        public DataSet GetSubbieOrdered()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT SUBNUMBER   CREDNUMBER,( LTRIM(RTRIM(SUBNAME))+'('+ LTRIM(RTRIM(SUBNUMBER)) +')' ) CREDNAME FROM SUBCONTRACTORS   ORDER BY SUBNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtorsOrdered2()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER    CREDNUMBER,( LTRIM(RTRIM(DEBTNAME))+'('+ LTRIM(RTRIM(DEBTNUMBER)) +')' ) CREDNAME FROM DEBTORS   ORDER BY DEBTNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetDebtorsOrdered_Sale()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER CREDNUMBER,( LTRIM(RTRIM(DEBTNAME))+'('+ LTRIM(RTRIM(DEBTNUMBER)) +')' ) CREDNAME FROM DEBTORS WHERE DEBTCONTROL='2540000'  ORDER BY DEBTNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtorsOrdered_Staff()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER CREDNUMBER,( LTRIM(RTRIM(DEBTNAME))+'('+ LTRIM(RTRIM(DEBTNUMBER)) +')' ) CREDNAME FROM DEBTORS WHERE DEBTCONTROL='2540002'  ORDER BY DEBTNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDebtorsOrdered_Scrap()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DEBTNUMBER CREDNUMBER,( LTRIM(RTRIM(DEBTNAME))+'('+ LTRIM(RTRIM(DEBTNUMBER)) +')' ) CREDNAME FROM DEBTORS WHERE DEBTCONTROL='2540001'  ORDER BY DEBTNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet LoadOtherLedgers()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LEDGERCODE,UPPER(LEDGERNAME)+'('+LEDGERCODE+')' LEDGERNAME FROM LEDGERCODES WHERE LEDGERCODE NOT IN ('2540000','2540001','2540002','1315000','1320000') AND LEDGERNAME<>' ' ORDER BY LEDGERNAME  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet GetDebtorsOrdered()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetDebtors");
            return ds;
        }


        public DataSet GetCreditorsInYear(int fyear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spCREDITORSDONETRANS", arParms);
            return ds;
        }

        public DataSet GetSubbiesInYear(int fyear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spSubbiesDONETRANS", arParms);
            return ds;
        }

        public DataSet GetDebtorsInYear(int fyear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spDEBTORSDONETRANS", arParms);
            return ds;
        }

        public DataSet GetDebtorsInYear(int fyear, string debtorledgercode)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            arParms[1] = new SqlParameter("@LEDGERCODE", SqlDbType.VarChar);
            arParms[1].Value = debtorledgercode;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spDEBTORDONETRANS]", arParms);
            return ds;
        }


        public DataSet GetSubContractorsInYear(int fyear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spSUBBIEDONETRANS", arParms);
            return ds;
        }
        public DataSet GetActiveFinYear()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT B.CURRENTYEAR,B.CURRENTPERIOD,P.PERIODDESC  FROM BORGS B INNER JOIN PERIODMASTER P ON B.CURRENTPERIOD=P.PERIODID  WHERE BORGID=2";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetDateLimits(int fyear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = fyear;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spDateLimits", arParms);
            return ds;
        }

        public DataSet GetZones()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGetzones");
            return ds;
        }

        
        public DataSet MasterDump(int _masterType, int _fromYear, int _fromPeriod, int _toYear, int _toPeriod, DataTable _creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[7];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@MASTERTYPE", SqlDbType.Int);
            arParms[0].Value = _masterType;
            arParms[1] = new SqlParameter("@FROMYEAR", SqlDbType.Int);
            arParms[1].Value = _fromYear;
            arParms[2] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[2].Value = _fromPeriod;
            arParms[3] = new SqlParameter("@TOYEAR", SqlDbType.Int);
            arParms[3].Value = _toYear;
            arParms[4] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[4].Value = _toPeriod;
            arParms[5] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListCredNumbers";
            arParms[5].Value = _creditors;
            arParms[6] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[6].TypeName = "dbo.ListOrgIDS";
            arParms[6].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spOppositeLedgerRegisterMaster]", arParms);
            return ds;

        }


        public DataSet WHT(int _year, int _reportType, int _fromPeriod, int _toPeriod,  DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _year;
            arParms[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Int);
            arParms[1].Value = 1;
            arParms[2] = new SqlParameter("@STARTPERIOD", SqlDbType.Int);
            arParms[2].Value = _fromPeriod;
            arParms[3] = new SqlParameter("@ENDPERIOD", SqlDbType.Int);
            arParms[3].Value = _toPeriod;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spWHT", arParms);
            return ds;

        }

        public DataSet IPLA(int _year,  int _fromPeriod, int _toPeriod, int _borgID)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _year;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@BORGID", SqlDbType.Int);
            arParms[3].Value = _borgID;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BS].[spIPLA]", arParms);
            return ds;

        }



        public DataSet OrgXTAB(int _year, int _reportType, int _fromPeriod, int _toPeriod, DataTable _Ledgers, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _year;
            arParms[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Int);
            arParms[1].Value = _reportType;
            arParms[2] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[2].Value = _fromPeriod;
            arParms[3] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[3].Value = _toPeriod;
            
            arParms[4] = new SqlParameter("@LISTLEDGERIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListLedgerIDS";
            arParms[4].Value = _Ledgers;
            arParms[5] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListOrgIDS";
            arParms[5].Value = _OrgIDS;
            DataSet ds;
            string _connectionString = SqlHelper.GetConnectionString();
            if (_reportType < 3 )
                 ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spORGXTABS", arParms);
            else
                ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spORGXTABS_MASTERS", arParms);
            return ds;

        }
       
        public DataSet MasterDumpPDATE(string _startDate, string _endDate,DataTable _OrgIDS) 
        {
            SqlParameter[] arParms = new SqlParameter[3];
      
            arParms[0] = new SqlParameter("@STARTDATESTRING", SqlDbType.Text);
            arParms[0].Value = _startDate;
            arParms[1] = new SqlParameter("@ENDDATESTRING", SqlDbType.Text);
            arParms[1].Value = _endDate;
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spExtractLedgerDumpsPDATE]", arParms);
            return ds;

        }



        public DataSet  LedgerDump(int _year,int _rageID, int _fromPeriod, int _toPeriod,  string _startDate, string _endDate, DataTable _Ledgers, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[9];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParms[0].Value = _year;
            arParms[1] = new SqlParameter("@RANGEID", SqlDbType.Int);
            arParms[1].Value = _rageID;
            arParms[2] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[2].Value = _fromPeriod;
            arParms[3] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[3].Value = _toPeriod;

            arParms[4] = new SqlParameter("@STARTDATESTRING", SqlDbType.Text);
            arParms[4].Value = _startDate;
            arParms[5] = new SqlParameter("@ENDDATESTRING", SqlDbType.Text);
            arParms[5].Value = _endDate;
            arParms[6] = new SqlParameter("@LISTLEDGERIDS", SqlDbType.Structured);
            arParms[6].TypeName = "dbo.ListLedgerIDS";
            arParms[6].Value = _Ledgers;
            arParms[7] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[7].TypeName = "dbo.ListOrgIDS";
            arParms[7].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spExtractLedgerDumps]", arParms);
            return ds;

        }

        public DataSet GetCreditorAge(int _agedTo, int _periodAgeOn, int _finYear, int _agingON, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@AGEDTO", SqlDbType.Int);
            arParms[0].Value = _agedTo;
            arParms[1] = new SqlParameter("@AGEDTOPERIOD", SqlDbType.Int);
            arParms[1].Value = _periodAgeOn;
            arParms[2] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[2].Value = _finYear;
            arParms[3] = new SqlParameter("@AGEOF", SqlDbType.Int);
            arParms[3].Value = _agingON;
            arParms[4] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListCredNumbers";
            arParms[4].Value = _Creditors;
            arParms[5] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListOrgIDS";
            arParms[5].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[CREDITORAGING]", arParms);
            return ds;
        }


        public DataSet GetSubbieAge(int _agedTo, int _periodAgeOn, int _finYear, int _agingON, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@AGEDTO", SqlDbType.Int);
            arParms[0].Value = _agedTo;
            arParms[1] = new SqlParameter("@AGEDTOPERIOD", SqlDbType.Int);
            arParms[1].Value = _periodAgeOn;
            arParms[2] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[2].Value = _finYear;
            arParms[3] = new SqlParameter("@AGEOF", SqlDbType.Int);
            arParms[3].Value = _agingON;
            arParms[4] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListCredNumbers";
            arParms[4].Value = _Creditors;
            arParms[5] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[5].TypeName = "dbo.ListOrgIDS";
            arParms[5].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[SUBBIEAGING]", arParms);
            return ds;
        }

        public DataSet GetDebtorAge(string _ledgercode, int _periodAgeOn, int _finYear, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[8];
            // @ZONE is the Input Parameter

            arParms[0] = new SqlParameter("@LEDGERCODE", SqlDbType.VarChar);
            arParms[0].Value = _ledgercode;
            arParms[1] = new SqlParameter("@AGEDTOPERIOD", SqlDbType.Int);
            arParms[1].Value = _periodAgeOn;
            arParms[2] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[2].Value = _finYear;
            arParms[3] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListCredNumbers";
            arParms[3].Value = _Creditors;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[DEBTORAGING]", arParms);
            return ds;
        }

        public DataSet PuchaseRegister(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListCredNumbers";
            arParms[3].Value = _Creditors;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spPurchaseRegister", arParms);
            return ds;
        }

       


        public DataSet SubbieRegister(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListCredNumbers";
            arParms[3].Value = _Creditors;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spSubContractorRegister", arParms);
            return ds;
        }
        public DataSet LedgerWithOppositeLegs(int _finYear, int _fromPeriod, int _toPeriod, DataTable _OrgIDS, string _ledgerCode)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _OrgIDS;
            arParms[4] = new SqlParameter("@LEDGERCODE", SqlDbType.Text);
            arParms[4].Value = _ledgerCode;
           

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spOppositeLedgerRegister]", arParms);
            return ds;
        }



        public DataSet LedgerWithOppositeLegsAllMasters(int _finYear, int _fromPeriod, int _toPeriod, DataTable _OrgIDS,string _partyName, int _partyType)
        {
            SqlParameter[] arParms = new SqlParameter[6];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _OrgIDS;
            arParms[4] = new SqlParameter("@PARTYCODE", SqlDbType.Text);
            arParms[4].Value = _partyName;
            arParms[5] = new SqlParameter("@PARTYTYPE", SqlDbType.Int);
            arParms[5].Value = _partyType;


            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spOppositeLedgerRegisterAllMasters]", arParms);
            return ds;
        }
        public DataSet DebtorRegister(int _finYear, int _fromPeriod, int _toPeriod, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[1].Value = _fromPeriod;
            arParms[2] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[2].Value = _toPeriod;
            arParms[3] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListCredNumbers";
            arParms[3].Value = _Creditors;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spDebtorRegister", arParms);
            return ds;
        }
        public DataSet PORegister(string _fromDate, string _toDate, int _orderStatus, DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@STARTDATESTRING", SqlDbType.Text);
            arParms[0].Value = _fromDate;
            arParms[1] = new SqlParameter("@ENDDATESTRING", SqlDbType.Text);
            arParms[1].Value = _toDate;
            arParms[2] = new SqlParameter("@ORDSTATUSID", SqlDbType.Int);
            arParms[2].Value = _orderStatus;
            arParms[3] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListCredNumbers";
            arParms[3].Value = _Creditors;
            arParms[4] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[4].TypeName = "dbo.ListOrgIDS";
            arParms[4].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spPurchaseOrderRegister", arParms);
            return ds;
        }

        public DataSet WIPStoresConsolidated()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string sql = " SELECT I.STKSTORE StoreName, B.BORGNAME Project,I.BORGID OrgID,I.STKCODE StockCode,";
            sql = sql +  " I.STKDESC StockName,I.STKUNIT Unit,I.STKQUANTITY Quantity,";
            sql = sql +  " I.STKCOSTRATE Rate,(I.STKQUANTITY*I.STKCOSTRATE) Amount ";
            sql = sql + " FROM INVENTORY I INNER JOIN BORGS B ON I.BORGID = B.BORGID ";
            sql = sql + " WHERE LEFT(I.STKSTORE,3) = 'WS-' AND I.BORGID <> 65 ORDER BY BORGNAME,STKDESC";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, sql);
            return ds;
        }



        public DataSet GRNRegister(string _fromDate, string _toDate,   DataTable _Creditors, DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[5];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@STARTDATESTRING", SqlDbType.Text);
            arParms[0].Value = _fromDate;
            arParms[1] = new SqlParameter("@ENDDATESTRING", SqlDbType.Text);
            arParms[1].Value = _toDate;
            arParms[2] = new SqlParameter("@LISTCREDITORS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListCredNumbers";
            arParms[2].Value = _Creditors;
            arParms[3] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[3].TypeName = "dbo.ListOrgIDS";
            arParms[3].Value = _OrgIDS;

            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spGRNRegister", arParms);
            return ds;
        }

        public DataSet PRRegister(string _fromDate, string _toDate,  DataTable _OrgIDS)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            // @ZONE is the Input Parameter


            arParms[0] = new SqlParameter("@STARTDATESTRING", SqlDbType.Text);
            arParms[0].Value = _fromDate;
            arParms[1] = new SqlParameter("@ENDDATESTRING", SqlDbType.Text);
            arParms[1].Value = _toDate;
           
            arParms[2] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[2].TypeName = "dbo.ListOrgIDS";
            arParms[2].Value = _OrgIDS;


            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.[spRequisitionRegister]", arParms);
            return ds;
        }
  
        public DataSet FetchUnMatchedTransactions(DataTable _OrgIDS, int _finYear, int _toPeriod, int _selectionID)
        {
            SqlParameter[] arParms = new SqlParameter[4];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            arParms[1] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[1].Value = Convert.ToInt32(_finYear);
            arParms[2] = new SqlParameter("@PERIODTO", SqlDbType.Int);
            arParms[2].Value = Convert.ToInt32(_toPeriod);
            arParms[3] = new SqlParameter("@PARTYID", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt16(_selectionID);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BS].[UNMATCHEDTRANSACTIONS]", arParms);
            return ds;
        }


        public DataSet GetLedgerSummary(DataTable _OrgIDS,string _ledgerCode, string _partyCode, int _fromYear , int _fromPeriod, int _toYear , int _toPeriod )
        {
            SqlParameter[] arParms = new SqlParameter[7];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            arParms[1] = new SqlParameter("@LEDGERCODE", SqlDbType.VarChar);
            arParms[1].Value = Convert.ToString(_ledgerCode);
            arParms[2] = new SqlParameter("@PARTYCODE", SqlDbType.VarChar);
            arParms[2].Value = Convert.ToString(_partyCode);
            arParms[3] = new SqlParameter("@FROMYEAR", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt16(_fromYear);
            arParms[4] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[4].Value = Convert.ToInt16(_fromPeriod);
            arParms[5] = new SqlParameter("@TOYEAR", SqlDbType.Int);
            arParms[5].Value = Convert.ToInt16(_toYear);
            arParms[6] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[6].Value = Convert.ToInt16(_toPeriod);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spLEDGERSUMMARY_MASTERS]", arParms);
            return ds;
        }

        public DataSet GetOtherLedgerSummary(DataTable _OrgIDS, string _ledgerCode,  int _fromYear, int _fromPeriod, int _toYear, int _toPeriod)
        {
            SqlParameter[] arParms = new SqlParameter[6];
            // @ZONE is the Input Parameter
            arParms[0] = new SqlParameter("@LISTORGIDS", SqlDbType.Structured);
            arParms[0].TypeName = "dbo.ListOrgIDS";
            arParms[0].Value = _OrgIDS;
            arParms[1] = new SqlParameter("@LEDGERCODE", SqlDbType.VarChar);
            arParms[1].Value = Convert.ToString(_ledgerCode);
            arParms[2] = new SqlParameter("@FROMYEAR", SqlDbType.Int);
            arParms[2].Value = Convert.ToInt16(_fromYear);
            arParms[3] = new SqlParameter("@FROMPERIOD", SqlDbType.Int);
            arParms[3].Value = Convert.ToInt16(_fromPeriod);
            arParms[4] = new SqlParameter("@TOYEAR", SqlDbType.Int);
            arParms[4].Value = Convert.ToInt16(_toYear);
            arParms[5] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[5].Value = Convert.ToInt16(_toPeriod);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spLEDGERSUMMARY_OTHERS]", arParms);
            return ds;
        }


        #endregion

    }
}