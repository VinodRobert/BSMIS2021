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
    public partial class frmReportPreviewLedgers : Form
    {
        public frmReportPreviewLedgers(DataSet _dsResult)
        {
            InitializeComponent();
            ReportFiles.Ledgers  _ledgerReport = new ReportFiles.Ledgers();
            _ledgerReport.SetDataSource(_dsResult.Tables[0]);
            _ledgerReport.Refresh();
            cvLedgers.ReportSource = _ledgerReport;
            cvLedgers.RefreshReport();
        }
    }
}
