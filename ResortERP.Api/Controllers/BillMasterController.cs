using ResortERP.Core.VM;
using ResortERP.Repository;
using ResortERP.Service;
using ResortERP.Service.IServices;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ResortERP.Api.Controllers
{
    [Logger]
    public class BillMasterController : ApiController
    {
        IBillMasterService billMasterService;
        IUserLogFileService userLogFileService;
        public BillMasterController(IBillMasterService billMasterService, IUserLogFileService userLogFileService)
        {
            this.billMasterService = billMasterService;
            this.userLogFileService = userLogFileService;
        }

        [Route("billMaster/add")]
        [HttpPost]
        public async Task<IHttpActionResult> add([FromBody]BILL_MASTERVM entity)
        {
            var result=await billMasterService.InsertAsync(entity);
            await LogData("_"+entity.BILL_SETTING_ID+ "_" + result, result.ToString(), entity.BILL_NUMBER.ToString());
            //if (result != 0)
            //{
            //    return Ok(true);
            //}
            return Ok(result);
        }
        [Route("billMaster/update")]
        [HttpPost]
        public async Task<IHttpActionResult> update([FromBody]BILL_MASTERVM entity)
        {
            var result = await billMasterService.UpdateAsync(entity);
            await LogData("_" + entity.BILL_SETTING_ID + "_" + entity.BILL_ID, entity.BILL_ID.ToString(), entity.BILL_NUMBER.ToString(),entity.EditReason);
            return Ok(result);
        }
        [Route("billMaster/delete")]
        [HttpPost]
        public async Task<IHttpActionResult> delete([FromBody]BILL_MASTERVM entity)
        {
           var result= await billMasterService.DeleteAsync(entity);
           await LogData("_" + entity.BILL_SETTING_ID + "_" + entity.BILL_ID, entity.BILL_ID.ToString(), entity.BILL_NUMBER.ToString());
            return Ok(result);
        }
        [Route("billMaster/get")]
        [HttpGet]
        public async Task<IHttpActionResult> get(int branchId, int billType, int pageNum, int pageSize)
        {
            return Ok(await billMasterService.GetAllAsync(branchId, billType, pageNum, pageSize));
        }


        [Route("billMaster/getBillByBillNumber")]
        [HttpGet]
        public async Task<IHttpActionResult> getBillByBillNumber(int billNo, int billType)
        {
            return Ok(await billMasterService.getBillByBillNumber(billNo, billType));
        }



        [Route("billMaster/count")]
        [HttpGet]
        public async Task<IHttpActionResult> count(int billType)
        {
            return Ok(await billMasterService.CountAsync(billType));
        }

        [Route("billMaster/GetLastBillNumber")]
        [HttpGet]
        public async Task<long> GetLastBillNumber(int branchId, int settingID)
        {
            return await billMasterService.GetLastBillNumber(branchId, settingID);
        }



        [Route("billMaster/getByID")]
        [HttpGet]
        public async Task<IHttpActionResult> getByID(int billID)
        {
            return Ok(await billMasterService.GetByBillID(billID));
        }


        [Route("billMaster/updateEntryID")]
        [HttpPost]
        public async Task<IHttpActionResult> updateEntryID(BillEntryObj obj)
        {
            var result = await billMasterService.UpdateBillEntryByID(obj.BillMaster, obj.EntryID);
            //await LogData(null,obj.BillMaster.BILL_ID.ToString(), obj.BillMaster.BILL_NUMBER);
            return Ok(result);
        }


        [Route("billMaster/checkBillByBillNumber")]
        [HttpGet]
        public async Task<IHttpActionResult> CheckBillByBillNumber(int billNo, int billType)
        {
            return Ok(await billMasterService.CheckBillByBillNumber(billNo, billType));
        }



        [Route("billMaster/getPaginationByType")]
        [HttpGet]
        public int getPaginationByType(int billSettingID)
        {
            return billMasterService.getPaginationByType(billSettingID);
        }


        [Route("billMaster/GetAllBillsBySettingID")]
        [HttpGet]
        public List<BILL_MASTERVM> GetAllBillsBySettingID(int settingID)
        {
            return billMasterService.GetAllBillsBySettingID(settingID);
        }

        [Route("billMaster/getBillsForSearch")]
        [HttpPost]
        public List<BILL_MASTERVM> GetBillsForSearch(BillSearch BillSearchObj)
        {
            return billMasterService.GetBillsForSearch(BillSearchObj);
        }

        [Route("billMaster/getAccountStatement")]
        [HttpGet]
        public List<AccountStatementVM> GetAccountStatement(int AccID)
        {
            return billMasterService.GetAccountStatement(AccID);
        }

        [Route("billMaster/get_PRC_RPT_LEDGER")]
        [HttpGet]
        public List<AccountStatementVM> GetAccountStatement2(string companyBranches, string Accounts, string StartDate, string EndDate)
        {
            return billMasterService.Get_PRC_RPT_LEDGER(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/getAccountStatementDailyReport")]
        [HttpPost]
        public List<AccountStatementVM> getAccountStatementDailyReport(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            string reportType = ((dynamic)Model).reportType;
            return billMasterService.getAccountStatementDailyReport(companyBranches, Accounts, StartDate, EndDate,reportType);
        }

        [Route("billMaster/get_PRC_RPT_LEDGER_Gold")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetAccountStatement_Gold( ExpandoObject Model)
        {
            // Model = new ExpandoObject();
           
            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.Get_PRC_RPT_LEDGER_Gold(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/getAccountStatementGoldDailyReport")]
        [HttpGet]
        public List<AccountStatementGoldVM> getAccountStatementGoldDailyReport(string companyBranches, string Accounts, string Date)
        {
            return billMasterService.getAccountStatementGoldDailyReport(companyBranches, Accounts, Date);
        }

        [Route("billMaster/getAccountStatementGoldMonthlyReport")]
        [HttpPost]
        public List<AccountStatementGoldMonthlyVM> getAccountStatementGoldMonthlyReport(ExpandoObject Model)
        {


            string companyBranches = ((dynamic)Model).companyBranches; 
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            return billMasterService.getAccountStatementGoldMonthlyReport(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/getAccountStatementMonthlyReport")]
        [HttpGet]
        public List<AccountStatementMonthlyVM> getAccountStatementMonthlyReport(string companyBranches, string Accounts, string StartDate, string EndDate)
        {
            return billMasterService.getAccountStatementMonthlyReport(companyBranches, Accounts, StartDate, EndDate);
        }
        /**********New Report ***************************/
        [Route("billMaster/getMovementEntryTypeReport")]
        [HttpPost]
        public List<Entry_ReportVM> getMovementEntryTypeReport(ExpandoObject Model)
        {


            string companyBranches = ((dynamic)Model).companyBranches;
         
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            return billMasterService.getMovementEntryTypeReport(companyBranches,StartDate, EndDate);
        }


        /***************************************/

        [Route("billMaster/getExpensesTaxReport")]
        [HttpGet]
        public List<AccountStatementVM> getExpensesTaxReport(string companyBranches, string Accounts, string StartDate, string EndDate)
        {
            return billMasterService.getExpensesTaxReport(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/getExpensesTaxDailyReport")]
        [HttpGet]
        public List<AccountStatementVM> getExpensesTaxDailyReport(string companyBranches, string Accounts, string Date)
        {
            return billMasterService.getExpensesTaxDailyReport(companyBranches, Accounts, Date);
        }

        [Route("billMaster/getExpensesTaxMonthlyReport")]
        [HttpGet]
        public List<AccountStatementMonthlyVM> getExpensesTaxMonthlyReport(string companyBranches, string Accounts, string StartDate, string EndDate)
        {
            return billMasterService.getExpensesTaxMonthlyReport(companyBranches, Accounts, StartDate, EndDate);
        }

        /***************************************/

        [Route("billMaster/Get_PRC_RPT_TrialBalance")]
        [HttpGet]
        public List<TrialBalance> Get_PRC_RPT_TrialBalance(string companyBranches, string StartDate, string EndDate, string Type)
        {
            return billMasterService.Get_PRC_RPT_TRIALBALANCE(companyBranches, StartDate, EndDate, Type);
        }

        [Route("billMaster/get_PRC_RPT_LEDGER_All")]
        [HttpPost]
        public List<List<AccountStatementVM>> GetAccountStatementAll(ExpandoObject Model)
        {
            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            string CostCenterId = ((dynamic)Model).CostCenterId;
            return billMasterService.Get_PRC_RPT_LEDGER(companyBranches, Accounts, CostCenterId, StartDate, EndDate);
        }
        [Route("billMaster/get_PRC_RPT_LEDGER_Total")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetAccountStatementGoldsAndClients(ExpandoObject Model)
        {
            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            string CostCenterId = ((dynamic)Model).CostCenterId;
            return billMasterService.Get_PRC_RPT_LEDGER_Gold_Total(companyBranches, Accounts, StartDate, EndDate);
        }


        [Route("billMaster/get_Rpt_ENTRY_Gold_Daily")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetStatementsGoldDaily(ExpandoObject Model)
        {
            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            string CostCenterId = ((dynamic)Model).CostCenterId;
            return billMasterService.get_Rpt_ENTRY_Gold_Daily(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/get_PRC_RPT_LEDGER_All_Gold")]
        [HttpGet]
        public List<List<AccountStatementGoldVM>> GetAccountStatementGoldAll(string companyBranches, string Accounts, string CostCenterId, string Source, string StartDate, string EndDate)
        {
            return billMasterService.Get_PRC_RPT_LEDGER_Gold(companyBranches, Accounts, CostCenterId, Source, StartDate, EndDate);
        }

        [Route("billMaster/Get_PRC_RPT_TrialBalance_Gold")]
        [HttpGet]
        public List<TrialBalanceGoldVM> Get_PRC_RPT_TrialBalanceGold(string companyBranches ,string StartDate, string EndDate, string Type)
        {
            return billMasterService.Get_PRC_RPT_TRIALBALANCE_Gold(companyBranches, StartDate, EndDate, Type);
        }

        [Route("billMaster/getAccountDetectingReportData")]
        [HttpGet]
        public List<DetectionReportTotalVM> getAccountDetectingReportData(string companyBranches, string StartDate, string EndDate)
        {
            return billMasterService.getAccountDetectingReportData(companyBranches, StartDate, EndDate);
        }

        [Route("billMaster/getAccountDetectingReportDataChart")]
        [HttpGet]
        public List<DetectionReportTotalVM> getAccountDetectingReportDataChart(string companyBranches, string StartDate, string EndDate)
        {
            return billMasterService.getAccountDetectingReportDataChart(companyBranches, StartDate, EndDate);
        }

        [Route("billMaster/getSalesTaxReportData")]
        [HttpGet]
        public List<SalesTaxViewVM> getSalesTaxReportData(string companyBranches, string StartDate, string EndDate)
        {
            return billMasterService.getSalesTaxReportData(companyBranches, StartDate, EndDate);
        }

        [Route("billMaster/getPurchasingTaxReportData")]
        [HttpGet]
        public List<PurchasingTaxViewVM> getPurchasingTaxReportData(string companyBranches, string StartDate, string EndDate)
        {
            return billMasterService.getPurchasingTaxReportData(companyBranches, StartDate, EndDate);
        }

       

        [Route("billMaster/GetInvoiceMotionReportSearch")]
        [HttpPost]
        public List<InvoiceMotionViewVM> GetInvoiceMotionReportSearch([FromBody]InvoiceMotionSearchModel searchObject)
        {
            return billMasterService.GetInvoiceMotionReportSearch(searchObject);
        }

        [Route("billMaster/getNotPotedBills")]
        [HttpPost]
        public List<BILL_MASTERVM> getNotPotedBills([FromBody]BillPostingSearchVM searchObject)
        {
            return billMasterService.getNotPotedBills(searchObject);
        }

        [Route("billMaster/SetBillsPosted")]
        [HttpPost]
        public bool SetBillsPosted([FromBody]List<int> BillIds)
        {
            return billMasterService.SetBillsPosted(BillIds);
        }

      
        public async Task<bool> LogData(string code = null,string id=null,string notes=null,string editR=null)
        {
            Logger logger = new Logger();
            await userLogFileService.Insert(logger.LogDataMethod(code,id,notes, editR));
            return true;
        }

        [Route("billMaster/GetMovementDaily_Gold")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetMovementDailyGold(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.Get_MovementDaily_Gold(companyBranches, Accounts, StartDate);
        }
        [Route("billMaster/GetMovementPeriodBusy_Gold")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetMovementPeriodBusyGold(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.Get_MovementPeriodBusy_Gold(companyBranches, Accounts, StartDate, EndDate);
        }
       
        [Route("billMaster/GetGoldBusyTotalDaily")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetGoldBusyTotal_Daily(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.GetGoldBusyTotal_Daily(companyBranches, Accounts, StartDate, EndDate);
        }


        [Route("billMaster/GetGoldBusyTotalMonthly")]
        [HttpPost]
        public List<AccountStatementGoldVM> GetGoldBusyTotal_Monthly(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string Accounts = ((dynamic)Model).Accounts;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.GetGoldBusyTotal_Monthly(companyBranches, Accounts, StartDate, EndDate);
        }

        [Route("billMaster/GetEntries_DETAILS_Daily")]
        [HttpPost]
        public List<EntryDetails_ReportVM> GetEntries_DETAILS_Daily(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
          
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.GetEntries_DETAILS_Daily(companyBranches, EndDate);
        }

        /*********************** Purchases Reports **********************/

        [Route("billMaster/PurchasesDetailsItems")]
        [HttpPost]
        public List<PurchasesDetails> Purchase_DetailsItems(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.Purchase_DetailsItems(companyBranches, StartDate, EndDate);
        }


        [Route("billMaster/PurchasesDetailsDaily")]
        [HttpPost]
        public List<PurchasesDetails> Purchase_DetailsDaily(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.Purchase_DetailsDaily(companyBranches, StartDate, EndDate);
        }
        /*************Entries Reports*********************/

        [Route("billMaster/GetEntries_DETAILS_Monthly")]
        [HttpPost]
        public List<EntryDetails_ReportVM> GetEntries_DETAILS_Monthly(ExpandoObject Model)
        {
            // Model = new ExpandoObject();

            string companyBranches = ((dynamic)Model).companyBranches;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.GetEntries_DETAILS_Monthly(companyBranches, StartDate, EndDate);
        }
        [Route("billMaster/GetEntries_Total_Monthly")]
        [HttpPost]
        public List<EntryDetails_ReportVM> GetEntries_Total_Monthly(ExpandoObject Model)
        {
            string companyBranches = ((dynamic)Model).companyBranches;
            string StartDate = ((dynamic)Model).StartDate;
            string EndDate = ((dynamic)Model).EndDate;
            // bool val = ((dynamic)Model).companyBranches;
            return billMasterService.GetEntries_DETAILS_Total_Monthly(companyBranches, StartDate, EndDate);
        }

    }



    public class BillEntryObj
    {
        public BILL_MASTERVM BillMaster { get; set; }
        public long EntryID { get; set; }

    }


}