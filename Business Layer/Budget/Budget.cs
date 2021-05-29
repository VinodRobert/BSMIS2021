
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
    public class Budget
    {

        private int _orgID;
        private string _ledgerCode;
        private int _year;
        private int  _month;
        private decimal _bugetApril;
        private decimal _bugetMay;
        private decimal _bugetJune;
        private decimal _bugetJuly;
        private decimal _bugetAugust;
        private decimal _bugetSeptember;
        private decimal _bugetOctober;
        private decimal _bugetNovember;
        private decimal _bugetDecember;
        private decimal _bugetJanuary;
        private decimal _bugetFebruary;
        private decimal _bugetMarch;
        
        public  int OrgID
        {
            get { return _orgID; }
            set { _orgID = value; }
        }

        public string LedgerCode
        {
            get { return _ledgerCode; }
            set { _ledgerCode = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
      

        public int  Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public decimal BudgetApril
        {
            get { return _bugetApril; }
            set { _bugetApril = value; }
        }

        public decimal BudgetMay
        {
            get { return _bugetMay; }
            set { _bugetMay = value; }
        }


        public decimal BudgetJune
        {
            get { return _bugetJune; }
            set { _bugetJune = value; }
        }

        public decimal BugetJuly
        {
            get { return _bugetJuly; }
            set { _bugetJuly = value; }
        }


        public decimal BugetAugust
        {
            get { return _bugetAugust; }
            set { _bugetAugust = value; }
        }

        public decimal BugetSeptember
        {
            get { return _bugetSeptember; }
            set { _bugetSeptember = value; }
        }

        public decimal BugetOctober
        {
            get { return _bugetOctober; }
            set { _bugetOctober = value; }
        }

        public decimal BudgetNovember
        {
            get { return _bugetNovember; }
            set { _bugetNovember = value; }
        }

        public decimal BugetDecember
        {
            get { return _bugetDecember; }
            set { _bugetDecember = value; }
        }


        public decimal BudgetJanuary
        {
            get { return _bugetJanuary; }
            set { _bugetJanuary = value; }
        }

        public decimal BugetFebruary
        {
            get { return _bugetFebruary; }
            set { _bugetFebruary = value; }
        }

        public decimal BugetMarch
        {
            get { return _bugetMarch; }
            set { _bugetMarch = value; }
        }

  
        #region Functions


        public DataSet  FetchGroupHeads()
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "SELECT CATEGORY,POSITION,HEADNAME  FROM BI.REVEXPHEADS ORDER BY POSITION  ";
            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.Text, _sql);
            return ds;
        }
       
        public int InsertHeads(string _headName, string _category, string  _position )
        {
            string _connectionString = SqlHelper.GetConnectionString();
            string _sql = "Insert into BI.REVEXPHEADS values ("+_headName.ToString()+","+_category.ToString()+","+ _position.ToString() +" ) ";
            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.Text, _sql);
            return _success;
        } 
      
        public int updateBudget( int _orgID, string _ledgerCode,int _year, decimal _budgetApril,
                                decimal _budgetMay,decimal _budgetJune,decimal _budgetJuly, decimal budgetAugust, 
                                decimal _budgetSeptember, decimal _budgetOctober, decimal _budgetNovember, decimal _budgetDecember, 
                                decimal _budgetJanuary, decimal _budgetFebruary, decimal _budgetMarch)
        {
            string _connectionString = SqlHelper.GetConnectionString();
          
            SqlParameter[] arParms = new SqlParameter[15];
            arParms[0] = new SqlParameter("@ORGID", SqlDbType.Int);
            arParms[0].Value = _orgID;
            arParms[1] = new SqlParameter("@LEDGECODE", SqlDbType.Text);
            arParms[1].Value = _ledgerCode;
            arParms[2] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParms[2].Value = _year;
            arParms[3] = new SqlParameter("@BUDGETAPRIL", SqlDbType.Decimal);
            arParms[3].Value = _budgetApril;
            arParms[4] = new SqlParameter("@BUDGETMAY", SqlDbType.Decimal);
            arParms[4].Value = _budgetMay;
            arParms[5] = new SqlParameter("@BUDGETJUNE", SqlDbType.Decimal);
            arParms[5].Value = _budgetJune;
            arParms[6] = new SqlParameter("@BUDGETJULY", SqlDbType.Decimal);
            arParms[6].Value = _budgetJuly;
            arParms[7] = new SqlParameter("@BUDGETAUGUST", SqlDbType.Decimal);
            arParms[7].Value = budgetAugust;
            arParms[8] = new SqlParameter("@BUDGETSEPTEMBER", SqlDbType.Decimal);
            arParms[8].Value = _budgetSeptember;
            arParms[9] = new SqlParameter("@BUDGETOCTOBER", SqlDbType.Decimal);
            arParms[9].Value = _budgetOctober;
            arParms[10] = new SqlParameter("@BUDGETNOVEMBER", SqlDbType.Decimal);
            arParms[10].Value = _budgetNovember;
            arParms[11] = new SqlParameter("@BUDGETDECEMBER", SqlDbType.Decimal);
            arParms[11].Value = _budgetDecember;
            arParms[12] = new SqlParameter("@BUDGETJANUARY", SqlDbType.Decimal);
            arParms[12].Value = _budgetJanuary;
            arParms[13] = new SqlParameter("@BUDGETFEBRUARY", SqlDbType.Decimal);
            arParms[13].Value = _budgetFebruary;
            arParms[14] = new SqlParameter("@BUDGETMARCH", SqlDbType.Decimal);
            arParms[14].Value = _budgetMarch;

            int _success = SqlHelper.ExecuteNonQuery(_connectionString, CommandType.StoredProcedure, "[BI].[spUpdateBudget]", arParms);
            return _success;
        }

     
        //public DataSet PostManualDepreciation(int _finYear, int _period, int _assetID, decimal _amount )
        //{
        //    string _connectionString = SqlHelper.GetConnectionString();
        //    SqlParameter[] arParms = new SqlParameter[4];
        //    arParms[0] = new SqlParameter("@FINYEAR", SqlDbType.Int);
        //    arParms[0].Value = _finYear;
        //    arParms[1] = new SqlParameter("@PERIOD", SqlDbType.Int);
        //    arParms[1].Value = _period;
        //    arParms[2] = new SqlParameter("@ASSETID", SqlDbType.Int);
        //    arParms[2].Value = _assetID;
        //    arParms[3] = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
        //    arParms[3].Value = _amount;
        //    DataSet ds = SqlHelper.ExecuteDataset(_connectionString, CommandType.StoredProcedure, "[BI].[spPOSTMANUALDEPRECIATION]", arParms);
        //    return ds;
        //}

     
      
         #endregion

    }
}