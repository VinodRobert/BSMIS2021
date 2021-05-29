using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BSMIS 
{
    public partial class frmReportStockMovement : Form
    {
        public frmReportStockMovement(DataSet _dsResult)
        {
            InitializeComponent();
            ReportFiles.StockMovement _stockMovement = new ReportFiles.StockMovement();
            _stockMovement.SetDataSource(_dsResult.Tables[0]);
            _stockMovement.Refresh();
            cvLedgers.ReportSource = _stockMovement;
            cvLedgers.RefreshReport();
        }
    }
}
