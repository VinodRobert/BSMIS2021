
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
    public class Assets
    {

        private string   _assetCategory;
        private string   _assetNumber;
        private string   _assetName;
        private decimal  _assetPurchaseValue;
        private decimal  _assetSalvageValue;
        private int      _assetLife;
        private int      _lifeDepreciated;
        private decimal  _accumulatedDepreciation;
        private DateTime _assetPutToUse;
        private string   _assetLocation;
        private string   _gRN;
        private Int64    _assetOrderID;
        private string   _assetInvoiceNo;
        private Int64 _assetID;
        private decimal _dutyBenefit;
        private decimal _feRevaluation;
        private string _poNumber;
        private DateTime _poDate;
        private string _supplierCode;
        private string _supplierName;
        private DateTime _invoiceDate;
        private decimal _invoiceAmount;
        private int _orderType;
        private decimal _taxAmount;

        public  Int64 AssetID
        {
            get { return _assetID; }
            set { _assetID = value; }
        }

        public string   AssetCategory
        {
            get { return _assetCategory; }
            set { _assetCategory = value; }
        }

        public string AssetNumber
        {
            get { return _assetNumber; }
            set { _assetNumber = value; }
        }
      

        public string  AssetName
        {
            get { return _assetName; }
            set { _assetName = value; }
        }

        public decimal AssetPurchaseValue
        {
            get { return _assetPurchaseValue; }
            set { _assetPurchaseValue = value; }
        }

        public decimal AssetSalvageValue
        {
            get { return _assetSalvageValue; }
            set { _assetSalvageValue = value; }
        }

        
        public int AssetLife
        {
            get { return _assetLife; }
            set { _assetLife = value; }
        }

        public int LifeDepreciated
        {
            get { return _lifeDepreciated; }
            set { _lifeDepreciated = value; }
        }

 
        public decimal AccumulatedDepreciation
        {
            get { return _accumulatedDepreciation; }
            set { _accumulatedDepreciation = value; }
        }

        public DateTime AssetPutToUse
        {
            get { return _assetPutToUse; }
            set { _assetPutToUse = value; }
        }

        public string AssetLocation
        {
            get { return _assetLocation; }
            set { _assetLocation = value; }
        }

        public string GRN
        {
            get { return _gRN; }
            set { _gRN = value; }
        }

        public Int64 AssetOrderID
        {
            get { return _assetOrderID; }
            set { _assetOrderID = value; }
        }


        public string AssetInvoiceNo
        {
            get { return _assetInvoiceNo; }
            set { _assetInvoiceNo = value; }
        }

        public decimal DutyBenefit
        {
            get { return _dutyBenefit; }
            set { _dutyBenefit = value; }
        }

        public decimal FERevaluation
        {
            get { return _feRevaluation; }
            set { _feRevaluation = value; }
        }

  

        public string PONumber
        {
            get { return _poNumber; }
            set { _poNumber = value; }
        }

        public DateTime PODate
        {
            get { return _poDate; }
            set { _poDate = value; }
        }

        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }
        public Decimal InvoiceAmount
        {
            get { return _invoiceAmount; }
            set { _invoiceAmount = value; }

        }

        public  DateTime InvoiceDate
        {
           get { return _invoiceDate; }
           set { _invoiceDate = value ; }

        }

        public int OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        public Decimal TaxAmount
        {
            get { return _taxAmount ; }
            set { _taxAmount = value; }
        }


        #region Functions


     

        public int MonthlyDepreciation(int currentYear,int currentPeriod,int categoryID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@CURRENTYEAR", SqlDbType.Int);
            arParms[0].Value = currentYear;
            arParms[1] = new SqlParameter("@CURRENTMONTH", SqlDbType.Int);
            arParms[1].Value = currentPeriod;
            arParms[2] = new SqlParameter("@ID", SqlDbType.Int);
            arParms[2].Value = categoryID;
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BI].[MONTHLYDEPRECIATION]", arParms);
            return i;

        }


        public int DepreciationYearEnd(int currentFinYear)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParms[0].Value = currentFinYear;
            int i = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BI].[spAssetYearEnd]", arParms);
            return i;

        }
        public int CheckYearEndDoneForGivenYear(int newFinYear)
        {
            string _sql = "SELECT ISNULL(COUNT(*),0) FROM BI.ASSETPOSTS WHERE PERIOD=0 AND YEAR="+Convert.ToString(newFinYear);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            int lineCount = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
            if (lineCount > 0)
                return 1;
            else
                return 0;
            
        }

        public DataSet FindNextYearEndDue()
        {
            string _sql = "SELECT MIN(DEPYEAR)DEPYEAR  FROM BI.ASSETDEPHISTORY WHERE HISTORYID>(SELECT HISTORYID  FROM BI.ASSETDEPHISTORY WHERE ACTIVEMONTH = 1) AND DEPMONTH = 0 ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
       

        public DataSet FindNextDepreciationPeriod()
        {
            string _sql = "SELECT TOP 1 * FROM BI.ASSETDEPHISTORY WHERE DEPMONTH<>0 AND  HISTORYID>(SELECT HISTORYID FROM BI.ASSETDEPHISTORY WHERE ACTIVEMONTH=1) ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FindUptoWhatPeriodDepreciationDone()
        {
            string _sql = "SELECT DEPYEAR,DEPMONTHNAME FROM BI.ASSETDEPHISTORY WHERE ACTIVEMONTH=1 ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public int CheckDuplicate()
        {
            string _sql = "SELECT * FROM ASSETS WHERE ASSETNUMBER = '" + Convert.ToString(this.AssetNumber) + "'";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            if ( ds.Tables[0].Rows.Count>=1 )
                return 1;
            else
                return 0;
           
        }

        public DataSet FetchAssetCategories()
        {
            string _sql = "select * from bi.assetcategories order by assetcategory";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        } 
         
        public DataSet FetchAssetsHavingCategory(string _assetCategory)
        {
            string _sql = "SELECT (ASSETNUMBER +' - '+ ASSETNAME) AS  ASSETNAME,ASSETID FROM ASSETS WHERE ASSETOPPCODE='" + Convert.ToString(_assetCategory) + "' ORDER BY ASSETNUMBER ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchAssetsHavingCategoryUnSold(string _assetCategory)
        {
            string _sql = "SELECT (ASSETNUMBER +' - '+ ASSETNAME) AS  ASSETNAME,ASSETID FROM ASSETS WHERE ASSETOPPCODE='" + Convert.ToString(_assetCategory) + "' AND ASSETSALE=0.0 ORDER BY ASSETNUMBER ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

       
        public DataSet FetchLocationDetails()
        {
            string _sql = "SELECT LEFT(BORGNAME,5) LOCATION, BORGNAME FROM BORGS WHERE LEFT(BORGNAME,1)='9' ORDER BY LOCATION";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchReconDetails(int _assetID)
        {
            string _sql = "SELECT * FROM DEBTRECONS WHERE RECONID = " + Convert.ToString(_assetID);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchAssetsDetails(int _assetID)
        {
            string _sql = "SELECT * FROM ASSETS WHERE ASSETID = " + Convert.ToString(_assetID);
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
        public DataSet FetchAll()
        {
            string _sql = "SELECT * FROM ASSETS WHERE ASSETNUMBER = '" + Convert.ToString(this.AssetNumber) + "'";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return  ds;
        }

        public DataSet FetchAllWithMinimunInformation()
        {
            string _sql = "SELECT ASSETID,ASSETNUMBER,ASSETNAME,ASSETCATEGORY,ASSETLOCATION FROM ASSETS ORDER BY ASSETCATEGORY,ASSETNUMBER ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchAllOpenInvoices()
        {
            string _sql = "select reconid,b.borgname,d.Orgid,d.supname,d.postref,d.totdue,d.postdate from debtrecons d inner join borgs b on d.orgid = b.borgid ";
            _sql = _sql + "  where year(d.postdate) in (2016,2017) and posted=1 order by borgname,supname ";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetAssetsWithLocation(string _assetCategory,string _assetLocation)
        {
            string _sql;
            _sql = ""; 
            if (_assetCategory == "0")
                _assetCategory = "ALL";

            if (_assetLocation == "0")
                _assetLocation = "ALL";


            

           

            if ((_assetLocation == "ALL") && (_assetCategory == "ALL"))
                _sql = "SELECT ASSETID,ASSETNUMBER,ASSETNAME,ASSETCATEGORY,ASSETLOCATION  FROM ASSETS ORDER BY ASSETCATEGORY,ASSETLOCATION,ASSETNUMBER";

            if ( (_assetCategory == "ALL") && (_assetLocation != "ALL") )
            {
                _sql = "SELECT ASSETID,ASSETNUMBER,ASSETNAME,ASSETCATEGORY,ASSETLOCATION  FROM ASSETS WHERE ASSETLOCATION = '" + Convert.ToString(_assetLocation) + "' ";
                _sql = _sql + "   ORDER BY ASSETCATEGORY,ASSETLOCATION,ASSETNUMBER";
            }

            if ((_assetLocation == "ALL") && (_assetCategory != "ALL"))
            {
                _sql = "SELECT ASSETID,ASSETNUMBER,ASSETNAME,ASSETCATEGORY,ASSETLOCATION  FROM ASSETS WHERE ";
                _sql = _sql + "   ASSETOPPCODE = '" + Convert.ToString(_assetCategory) + "' ORDER BY ASSETCATEGORY,ASSETLOCATION,ASSETNUMBER";
            }

            if ((_assetLocation != "ALL") && (_assetCategory != "ALL"))
            {
                _sql = "SELECT ASSETID,ASSETNUMBER,ASSETNAME,ASSETCATEGORY,ASSETLOCATION  FROM ASSETS WHERE ASSETLOCATION = '" + Convert.ToString(_assetLocation) + "' ";
                _sql = _sql + " AND ASSETOPPCODE = '" + Convert.ToString(_assetCategory) + "' ORDER BY ASSETCATEGORY,ASSETLOCATION,ASSETNUMBER";
            }
             
            
             
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetActiveFinancialYear()
        {
            string _sql = "SELECT MAX(YEAR) AS FINYEAR FROM BI.ASSETPOSTS";
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchAttributes(Int64 _assetID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ASSETID", SqlDbType.Int);
            arParms[0].Value = _assetID; 
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spFetchAttributes]", arParms); 
            return ds;
        }

        public DataSet DetachPO(Int64 _assetID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ASSETID", SqlDbType.Int);
            arParms[0].Value = _assetID; 
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spDetachAttributes]", arParms); 
            return ds;
        }

        
        public DataSet FetchPO(string _PONumber)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ORDERNUMBER", SqlDbType.Text);
            arParms[0].Value = _PONumber;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spFetchPODetails", arParms);
            return ds;
          
        }

        public DataSet FetchWO(string _PONumber)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ORDERNUMBER", SqlDbType.Text);
            arParms[0].Value = _PONumber;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spFetchWODetails", arParms);
            return ds;

        }
        public DataSet FetchInvoice(string _GRN,string _OrderNumber)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@GRN", SqlDbType.Text);
            arParms[0].Value = _GRN;
            arParms[1] = new SqlParameter("@ORDERNUMBER", SqlDbType.Text);
            arParms[1].Value = _OrderNumber;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "BI.spFetchInvoiceDetails", arParms);
            return ds;

        }

        public DataSet FetchAssetNumbersForEdit()
        {
            string _sql = "SELECT ASSETNUMBER  FROM ASSETS WHERE ASSETTAXYEARS<>99 ORDER BY ASSETID DESC  ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet  FetchAssetNumbers()
        {
            string _sql = "SELECT ASSETNUMBER  FROM ASSETS ORDER BY ASSETID DESC  ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchAssetIDS()
        {
            string _sql = "SELECT ASSETID,ASSETNUMBER  FROM ASSETS ORDER BY ASSETNUMBER    ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet FetchOpenDebtReconIDS()
        {
            string _sql = "SELECT RECONID AS RECONID,RECONID AS RECONNUMBER from debtrecons where year(postdate) in (2016,2017) and posted=1  order by reconid desc    ";
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int  UpdateLocation(int _assetID,string _assetLocation) 
        {
            string _sql = "UPDATE ASSETS SET AssetLocation = '" + Convert.ToString(_assetLocation) + "'  WHERE ASSETID = " + Convert.ToString(_assetID);  
            string _connectionString = SqlHelper.GetConnectionString();

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return 1;
        }

        public DataSet GetAssets(int _choice)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@CHOICE", SqlDbType.Int);
            arParms[0].Value = _choice;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGenerateAssetMaster]", arParms);
            return ds;
        }

        public DataSet GetCurrentPeriod()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = " SELECT PERIOD FROM BORGS WHERE BORGID=2";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public DataSet GetProjectLocations()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT LEFT(BORGNAME,5) PROJECTCODE,BORGNAME FROM BORGS WHERE LEFT(BORGNAME,1)='9' ORDER BY LEFT(BORGNAME,5)";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }


        public DataSet FetchManualDepreciation()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT DP.YEAR,PR.PERIODDESC,ASS.ASSETNUMBER,ASS.ASSETNAME,DP.DEBIT AS AMOUNT FROM BI.ASSETPOSTS DP INNER JOIN PERIODMASTER PR ON DP.PERIOD=PR.PERIODID ";
            _sql = _sql + " INNER JOIN ASSETS AS  ASS ON DP.ASSETID=ASS.ASSETID WHERE DP.DEPTYPE='MANUAL'  ORDER BY ASS.ASSETID   ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }

        public int update()
        {
            string _connectionString = SqlHelper.GetConnectionString();
           
            SqlParameter[] parameters = SqlHelper.BindParameters(this, "[BI].[spUpdateAssets]", _connectionString);
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BI].[spUpdateAssets]", parameters);
            return _success;
        }

        public DataSet FetchDepreciationDetails(int _finYear,int _toPeriod,int _reportType)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@TOPERIOD", SqlDbType.Int);
            arParms[1].Value = _toPeriod;
            arParms[2] = new SqlParameter("@REPORTYPE", SqlDbType.Int);
            arParms[2].Value = _reportType;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGenerateAssetDepReport]", arParms);
            return ds;
        }

        public DataSet PostDepreciation(int _finYear,int _period,string _oppLedgerCode)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
            arParms[1].Value = _period;
            arParms[2] = new SqlParameter("@OPPLEDGERCODE", SqlDbType.Text);
            arParms[2].Value = _oppLedgerCode;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spPostDepreciation]", arParms);
            return ds;
        }

        public DataSet PostManualDepreciation(int _finYear, int _period, int _assetID, decimal _amount )
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[4];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
            arParms[1].Value = _period;
            arParms[2] = new SqlParameter("@ASSETID", SqlDbType.Int);
            arParms[2].Value = _assetID;
            arParms[3] = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            arParms[3].Value = _amount;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spPOSTMANUALDEPRECIATION]", arParms);
            return ds;
        }

        public DataSet AssetSale(int _finYear, int _period, int _assetID)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
            arParms[1].Value = _period;
            arParms[2] = new SqlParameter("@ASSETID", SqlDbType.Int);
            arParms[2].Value = _assetID;
          
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spAssetSale]", arParms);
            return ds;
        }

        public DataSet GetInvoiceDetailsWithTax(Int32 _tranGRP)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@TRANGRP", SqlDbType.Int);
            arParms[0].Value = _tranGRP;
           
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGetInvoiceDetails]", arParms);
            return ds;
        }

        public DataSet GenerateSummaryReport(int _finYear,int _toPeriod)
        {
            string _connectionString = SqlHelper.GetConnectionString();
            SqlParameter[] arParms = new SqlParameter[3];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
            arParms[1].Value = _toPeriod;
            arParms[2] = new SqlParameter("@REPORTTYPE", SqlDbType.Int);
            arParms[2].Value = 2;
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGenerateAssetSummary]", arParms);
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

        public DataSet GetPeriodsToLastDepreciated(int _finYear)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
            arParms[0].Value = _finYear;
            string _connectionString = SqlHelper.GetConnectionString();
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spGetPeriodToLastDepreciated]", arParms);
            return ds;
        }
        #endregion

    }
}