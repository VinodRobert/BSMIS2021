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
  
    public partial class frmMain : Form
    {
           

        public frmMain()
        {
            InitializeComponent();
        }

  
        private void creditorAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubbieAge _frmCredAge = new frmSubbieAge();
            GlobalVariables.AgeOf = 1;
            _frmCredAge.Show();
        }

        private void buildsmartUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginUser _frmLoginUsers = new frmLoginUser();
            _frmLoginUsers.Show();
        }

     

        private void frmMain_Load(object sender, EventArgs e)
        {
            tooltipStrip.Text = "Ready";
            statusStrip.Refresh();
            
            switch (GlobalVariables._UserRole)
            {
                case "ACCOUNTS HEAD":
                    ToolStripMenuStores.Enabled = true;
                    //eAndYToolStripMenuItem.Enabled = false; 
                    break;
                default: 
                    break;
            }
            ToolStripMenuIT.Enabled = false;

           

            if ( (GlobalVariables._UserID == "CIPL4214") || (GlobalVariables._UserID == "Vinod") ||
                 (GlobalVariables._UserID == "CIPL814")  )
            {
                ToolStripAssetsMenuItem.Enabled = true;
           
                ToolStripEAndYMenuItem.Enabled = false;
                ToolStripMenuIT.Enabled = false;
                ToolStripMenuStores.Enabled = false;
                ToolStripMenuAccounts.Enabled = false;

            }
            else
            {
                ToolStripAssetsMenuItem.Enabled = false;
                ToolStripMenuIT.Enabled = false;
                ToolStripEAndYMenuItem.Enabled = true;
             
                ToolStripMenuStores.Enabled = true;
                ToolStripMenuAccounts.Enabled = true;
            }

            if ( (GlobalVariables._UserID == "Admin") || (GlobalVariables._UserID == "Vinod") )
            {
                ToolStripMenuIT.Enabled = true;
                paymentBatchingToolStripMenuItem.Enabled = true;
            }
            else
            {
                ToolStripMenuIT.Enabled = false;
                paymentBatchingToolStripMenuItem.Enabled = false;
            }
            if ( (GlobalVariables._UserID == "CIPL814") || (GlobalVariables._UserID == "Vinod") )
            {
                utilityToolStripMenuItem.Enabled = true;
            }
            else
            {
                utilityToolStripMenuItem.Enabled = false;
            }

            if ( (GlobalVariables._UserID == "CIPL1113") || (GlobalVariables._UserID == "Vinod") )
            {
                eAndYReportsToolStripMenuItem.Enabled = true;
            }
            else
            {
                eAndYReportsToolStripMenuItem.Enabled = false;
            } 
        }

     

        private void subContractorAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubbieAge _frmCredAge = new frmSubbieAge();
            GlobalVariables.AgeOf = 2;
            _frmCredAge.Show();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void debtorAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubbieAge _frmDebtorAge = new frmSubbieAge();
            GlobalVariables.AgeOf = 3;
            _frmDebtorAge.Show();
        }

       

        private void purchaseRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseRegister _frmPurchaseRegister = new frmPurchaseRegister();
            _frmPurchaseRegister.Show();
        }

        private void purchaseOrderRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPORegister _frmPurchaseRegister = new frmPORegister();
            _frmPurchaseRegister.Show();
        }

        private void subContractorRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubContractorRegister _frmSubContractorRegister = new frmSubContractorRegister();
            _frmSubContractorRegister.Show();
        }

        private void salesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDebtorRegister _frmDebtorRegister = new frmDebtorRegister();
            _frmDebtorRegister.Show();
        }

        private void transactionDumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDumps _frmDumps = new frmDumps();
            _frmDumps.Show();
        }

        private void orgCrossTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrgXTab _frmOrgXTab = new frmOrgXTab();
            _frmOrgXTab.Show();
        }

        private void requisitionRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPRRegister _frmPurchaseRegister = new frmPRRegister();
            _frmPurchaseRegister.Show();
        }

        private void lockUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLockUsers _frmLockUsers = new frmLockUsers();
            _frmLockUsers.Show();
        }

        private void assetMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetMaster _frmAssetMaster = new frmAssetMaster();
            _frmAssetMaster.Show();
        }

        private void newAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewAsset _frmNewAsset = new frmNewAsset();
            _frmNewAsset.Show();
        }

        private void editAssetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAsset _frmEditAsset = new frmEditAsset();
            _frmEditAsset.Show();
        }

        private void depreciationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepreciationReport _frmDepReport = new frmDepreciationReport();
            _frmDepReport.Show();
        }

        private void postDepreciationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPostDepreciation _frmPostDepreciation = new frmPostDepreciation();
            _frmPostDepreciation.Show();
        }

        private void manualDepreciationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualDepreciation _frmManualDepreciation = new frmManualDepreciation();
            _frmManualDepreciation.Show();
        }

        private void locationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetLocation _frmAssetLocation = new frmAssetLocation();
            _frmAssetLocation.Show();
        }

        private void assetSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetSale _frmAssetSale = new frmAssetSale();
            _frmAssetSale.Show();
        }

        private void summaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepSummaryReport _frmDepSummaryReport = new frmDepSummaryReport();
            _frmDepSummaryReport.Show();
        }

        private void assetTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferAssets _frmTransferAssets = new frmTransferAssets();
            _frmTransferAssets.Show();
        }

        private void openDebtorReconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpenDebtRecons _frmOpenDebtRecons = new frmOpenDebtRecons();
            _frmOpenDebtRecons.Show();
        }

        private void receiptIssueRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceiptIssue _frmReceiptIssue = new frmReceiptIssue();
            _frmReceiptIssue.Show();
        }

        private void assetLocationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetLocation _frmAssetLocation = new frmAssetLocation();
            _frmAssetLocation.Show();
        }

        private void stockAgingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockAging _frmStockAging = new frmStockAging();
            _frmStockAging.Show();
        }

        private void purchaseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseHistory _frmPurchaseHistory = new frmPurchaseHistory();
            _frmPurchaseHistory.Show();
        }

        private void uploadBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmUploadBudget _frmUploadBudget = new frmUploadBudget();
            //_frmUploadBudget.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGSTPurchase _frmGSTPurchase = new frmGSTPurchase();
            _frmGSTPurchase.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGSTSales _frmGSTSales = new frmGSTSales();
            _frmGSTSales.Show();
        }

        private void mastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMastersLedger _frmMastersLedger = new frmMastersLedger();
            _frmMastersLedger.Show();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void gRNRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGRNRegister _frmGRNRegister = new frmGRNRegister();
            _frmGRNRegister.Show();
        }

        private void aToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Form1 _frm1 = new Form1();
            //_frm1.Show();
        }

        private void ledgersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmOtherLedger _frmOtherLedger = new frmOtherLedger();
            _frmOtherLedger.Show();
        }

        
        //private void negativeDeliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmNegativeDelivery _frmNegativeDelivery = new frmNegativeDelivery();
        //    _frmNegativeDelivery.Show();
        //}

      

        

        private void unReconDeliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnReconcileDelivery _frmUnReconcileDelivery = new frmUnReconcileDelivery();
            _frmUnReconcileDelivery.Show();
        }

        private void stockOfADayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockOfADay _frmStockOfDay = new frmStockOfADay();
            _frmStockOfDay.Show();
        }

        private void globalPeriodManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGlobalPeriodMangement _frmGlobalPeriodManagement = new frmGlobalPeriodMangement();
            _frmGlobalPeriodManagement.Show();
        }

        private void dropNegativeDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDropDelivery _frmDropDelivery = new frmDropDelivery();
            _frmDropDelivery.Show();
        }

        private void storesMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStoresMaster _frmStoresMaster = new frmStoresMaster();
            _frmStoresMaster.Show();
        }

       

        private void assetLocationReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAssetLocation _frmAssetLocation = new frmAssetLocation();
            _frmAssetLocation.Show();
        }

        private void wHTReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWHT _frmWHT = new frmWHT();
            _frmWHT.Show();
        }

        private void supplierSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGSTSuppliers _frmGSTSuppliers = new frmGSTSuppliers();
            _frmGSTSuppliers.Show();
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashFlow _frmCashFlow = new frmCashFlow();
            _frmCashFlow.Show();
        }

        private void wHTReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmWHT _frmWHT = new frmWHT();
            _frmWHT.Show();
        }

        private void projectPeriodPermanentLockUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrgPeriodPermanentLock _frmOrgPeriodPermanentLock = new frmOrgPeriodPermanentLock();
            _frmOrgPeriodPermanentLock.Show();

        }

        private void managePeriodPermanentLockUnlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePermanentPeriodLock _frmManagePermanentPeriodLock = new frmManagePermanentPeriodLock();
            _frmManagePermanentPeriodLock.Show();
        }

        private void periodOverRideRightUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeriodOverRideRights _frmPeriodOverRideRights = new frmPeriodOverRideRights();
            _frmPeriodOverRideRights.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmStockAgingXFR _frmStockAgingXFR = new frmStockAgingXFR();
            _frmStockAgingXFR.Show();
        }

        private void iPLASummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIPLA _frmIPLA = new frmIPLA();
            _frmIPLA.Show();
        }

        private void transGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMoveTransactions _frmMoveTransactiosn = new frmMoveTransactions();
            _frmMoveTransactiosn.Show();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detachUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetachUsers _frmDetachUsers = new frmDetachUsers();
            _frmDetachUsers.Show();
        }

        private void ledgerReportOppLegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOppositeLeg _frmOppositeLeg = new frmOppositeLeg();
            _frmOppositeLeg.Show();
        }

        private void unMatchedTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnMatchedTrans _frmUnMatchedTrans = new frmUnMatchedTrans();
            _frmUnMatchedTrans.Show();
        }

        private void attachProjectsForPBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchProjects _paymentBatchProjects = new PaymentBatchProjects();
            _paymentBatchProjects.Show();
        }

        private void pBRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchRoles _paymentBatchRoles = new PaymentBatchRoles();
            _paymentBatchRoles.Show();
        }

        private void pBUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchUsers _payBatchUsers = new PaymentBatchUsers();
            _payBatchUsers.Show();
        }

        private void pBApprovalHierachyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchWorkFlow _paymentBacthWorkFlow = new PaymentBatchWorkFlow();
            _paymentBacthWorkFlow.Show();
        }

        private void yearEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetYearEnd _frmAssetYearEnd = new frmAssetYearEnd();
            _frmAssetYearEnd.Show();
        }

        private void monthlyDepreciationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAssetRunDepreciation _frmRunDepreciation = new frmAssetRunDepreciation();
            _frmRunDepreciation.Show();

        }

        private void attachProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchProjects _paymentBatchProjects = new PaymentBatchProjects();
            _paymentBatchProjects.Show();
        }

        private void uploadMatchedTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUploadForTransactionMatching _upload = new frmUploadForTransactionMatching();
            _upload.Show();
        }

        private void attachUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchUsers _paymentBatchUsers = new PaymentBatchUsers();
            _paymentBatchUsers.Show();
        }

        private void attachUsersToProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchUserProjects _paymentBatchUserProjects = new PaymentBatchUserProjects();
            _paymentBatchUserProjects.Show();
        }

        private void updateSubConTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUploadForSubConMatching _uploadSubbie = new frmUploadForSubConMatching();
            _uploadSubbie.Show();
        }

        private void masterDumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterDump frmMasterDump = new frmMasterDump();
            frmMasterDump.Show();
        }

        private void gSTOutstandingUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUploadGSTOutstanding gstOutstanding = new frmUploadGSTOutstanding();
            gstOutstanding.Show();
        }

        private void bookingDateTransDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPDATEDump pdateDump = new frmPDATEDump();
            pdateDump.Show();
        }

        private void userDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPasswords frmPassword = new frmPasswords();
            frmPassword.Show();
        }

        private void masterDumpsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMasterDump frmMasterDump = new frmMasterDump();
            frmMasterDump.Show();
        }

        private void bookKeepingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookKeeping bookKeeping = new frmBookKeeping();
            bookKeeping.Show();

        }

        private void pBAttachUserToProjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchUserProjects pbup = new PaymentBatchUserProjects();
            pbup.Show();
        }

        private void banksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentBatchBanks BanksBatch = new PaymentBatchBanks();
            BanksBatch.Show();
        }

        private void defineCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterCategory masterCategory = new frmMasterCategory();
            masterCategory.Show();
        }

        private void masterCategoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterCategoryList masterCategoryList = new frmMasterCategoryList();
            masterCategoryList.Show();
        }

        private void oppositeLegMastersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOppositeLegMasters oppLegMaster = new frmOppositeLegMasters();
            oppLegMaster.Show();
        }

        private void invoiceListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceList invoiceList = new frmInvoiceList();
            invoiceList.Show();
        }

        private void workInProgressStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWIPStores wipStore = new frmWIPStores();
            wipStore.Show();
        }

        private void variationOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVariationOrders vo = new frmVariationOrders();
            vo.Show();
        }
    } 
}
