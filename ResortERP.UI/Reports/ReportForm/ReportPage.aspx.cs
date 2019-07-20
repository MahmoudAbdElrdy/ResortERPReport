using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using ResortERP.Core;
using ResortERP.Core.VM;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Web.Configuration;


namespace ResortERP.Report.ReportForm
{
    public partial class ReportPage : System.Web.UI.Page
    {
      
        private string UrlAPI = WebConfigurationManager.AppSettings["baseUrl"];
 
        protected void Page_Load(object sender, EventArgs e)
        {

           string ReportName = Request["ReportName"];
            if (!IsPostBack && ReportName!= null)
            {
                var method = this.GetType().GetMethod(ReportName);
                method.Invoke(this, null);
              
            }


        }
        private void BindReport(string reportName,  dynamic DataSet)
        {

            reportViewer1.LocalReport.ReportPath = Server.MapPath("../ReportDesigne/" + reportName + ".rdlc");// reportPath + ReportName + ".rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
             
           ReportDataSource source = new ReportDataSource(reportName, DataSet);

          reportViewer1.LocalReport.DataSources.Add(source);
          reportViewer1.DataBind();          
        }

        public List<AccountStatementVM> Get_PRC_RPT_LEDGER_Gold()
        {
            List<AccountStatementVM> accountStatements = new List<AccountStatementVM>();
            string stStartDate = Request["startDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();
            string CompanyName = Request["CompanyName"].ToString();

            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;

                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/get_PRC_RPT_LEDGER_Gold/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));


                        BindReport("AccountStatementGold", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", stCompanyBranch));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", stACCOUNTS_Param));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", CompanyName));
                        

                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }
      
        public List<AccountStatementGoldMonthlyVM> getAccountStatementGoldMonthlyReport()
        {
            List<AccountStatementGoldMonthlyVM> accountStatements = new List<AccountStatementGoldMonthlyVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";

            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/getAccountStatementGoldMonthlyReport/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldMonthlyVM>>(ResultResponse.Result));

                        ReportParameter rp1 = new ReportParameter("Parameter1", stCompanyBranch);
                        ReportParameter rp2 = new ReportParameter("Parameter2", stACCOUNTS_Param);

                        ReportParameter rp3 = new ReportParameter("Parameter3", stStartDate);
                        ReportParameter rp4 = new ReportParameter("Parameter4", stEndDate);
                        BindReport("BrokenGoldBoxMotionMonthly", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arEndDate));
                        
                        var date = DateTime.Now.ToString("dd/MMM/yyyy", new CultureInfo("ar"));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }
        
        public List<AccountStatementVM> getAccountStatementDailyReport()
        {
            List<AccountStatementVM> accountStatements = new List<AccountStatementVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;
            string ReportType = Request["ReportType"].ToString();

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.reportType = ReportType;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/getAccountStatementDailyReport/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementVM>>(ResultResponse.Result));
                     
                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);

                            }
                        }
                     

                        if (ReportType == "0")
                        {
                            BindReport("RiyalFundMotionAll", DataSet);
                        }
                        else if (ReportType == "1")
                        {
                            BindReport("RiyalFundMotionDaily", DataSet);
                        }
                        else if (ReportType == "2")
                        {
                            BindReport("RiyalFundMotionPeriod", DataSet);
                        }
                        else if (ReportType == "3")
                        {
                            BindReport("RiyalFundMotionDailyPeriod", DataSet);
                        }
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", stCompanyBranch));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", accnumber));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", CompanyName));

                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<List<AccountStatementVM>> getAccountStatementReport()
        {
            List<List<AccountStatementVM>> accountStatements = new List<List<AccountStatementVM>>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();
            
            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;
            string ReportType = Request["ReportType"].ToString();

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.reportType = ReportType;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/get_PRC_RPT_LEDGER_All/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<List<AccountStatementVM>>>(ResultResponse.Result));

                        foreach (var item in DataSet[0])
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);

                            }
                        }


                        if (ReportType == "0")
                        {
                            BindReport("AccountStatementAll", DataSet[0]);
                        }
                        else if (ReportType == "1")
                        {
                            BindReport("AccountStatementPeriod", DataSet[0]);
                        }

                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", stCompanyBranch));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", accnumber));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter6", AccountName));
                        

                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }
        public List<AccountStatementGoldVM> getAccountStatementGoldClientReport()
        {
            List<AccountStatementGoldVM> accountStatements = new List<AccountStatementGoldVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/get_PRC_RPT_LEDGER_Total/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);

                            }
                        }


                     

                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", stCompanyBranch));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", accnumber));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", CompanyName));

                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }
     public List<Entry_ReportVM> getMovementEntryTypeReport()
        {
            List<Entry_ReportVM> accountStatements = new List<Entry_ReportVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
             string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                 
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                 
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/getMovementEntryTypeReport/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<Entry_ReportVM>>(ResultResponse.Result));

                        //foreach (var item in DataSet)
                        //{
                        //    if (item.Date != null)
                        //    {
                        //        string s2 = item.Date;
                        //        item.Date = DateTime.ParseExact(s2, "dd/M/yyyy",
                        //            null);

                        //    }
                        //}

                        BindReport("MovementEntryType", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", CompanyName));



                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }



        public List<AccountStatementGoldVM> getGoldMovementDailyTypeReport()
        {
            List<AccountStatementGoldVM> accountStatements = new List<AccountStatementGoldVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetMovementDaily_Gold/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }

                        BindReport("GoldMovementDaily", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", AccountName));




                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }



        public List<AccountStatementGoldVM> getGoldBusyMovementPeriodTypeReport()
        {
            List<AccountStatementGoldVM> accountStatements = new List<AccountStatementGoldVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                  
                  DateTime d = DateTime.ParseExact(stStartDate, "yyyyMMdd",
                                 CultureInfo.InvariantCulture);
                    d = d.AddDays(-1);
                    string datebefore = d.ToString("dd/MM/yyyy");
                     client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetMovementPeriodBusy_Gold/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }


                        string DEBITGold24 = DataSet[0].DEBIT_Gold24.ToString();
                     
                        string CREDITGold24 = DataSet[0].CREDIT_Gold24.ToString();
                        string DEBITGold22 = DataSet[0].DEBIT_Gold22.ToString();
                        string CREDITGold22 = DataSet[0].CREDIT_Gold22.ToString();
                        string DEBITGold21 = DataSet[0].DEBIT_Gold21.ToString();
                        string CREDITGold21 = DataSet[0].CREDIT_Gold21.ToString();
                        string DEBITGold18 = DataSet[0].DEBIT_Gold18.ToString();
                        string CREDITGold18 = DataSet[0].CREDIT_Gold18.ToString();
                        DataSet.RemoveAt(0);
                        BindReport("GoldBusyMovementPeriod", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", AccountName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", datebefore));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter6", DEBITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter7", CREDITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter8", DEBITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter9", CREDITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter10", DEBITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter11", CREDITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter12", DEBITGold18));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter13", CREDITGold18));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }



        public List<AccountStatementGoldVM> getGoldBusyTotalDailyReport()
        {
            List<AccountStatementGoldVM> accountStatements = new List<AccountStatementGoldVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    DateTime d = DateTime.ParseExact(stStartDate, "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                    d = d.AddDays(-1);
                    string datebefore = d.ToString("dd/MM/yyyy");
                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetGoldBusyTotalDaily/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {

                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }


                        string DEBITGold24 = DataSet[0].DEBIT_Gold24.ToString();

                        string CREDITGold24 = DataSet[0].CREDIT_Gold24.ToString();
                        string DEBITGold22 = DataSet[0].DEBIT_Gold22.ToString();
                        string CREDITGold22 = DataSet[0].CREDIT_Gold22.ToString();
                        string DEBITGold21 = DataSet[0].DEBIT_Gold21.ToString();
                        string CREDITGold21 = DataSet[0].CREDIT_Gold21.ToString();
                        string DEBITGold18 = DataSet[0].DEBIT_Gold18.ToString();
                        string CREDITGold18 = DataSet[0].CREDIT_Gold18.ToString();
                        DataSet.RemoveAt(0);
                        BindReport("GoldBusyTotalDaily", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", AccountName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", datebefore));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter6", DEBITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter7", CREDITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter8", DEBITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter9", CREDITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter10", DEBITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter11", CREDITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter12", DEBITGold18));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter13", CREDITGold18));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<AccountStatementGoldVM> getGoldBusyTotalMonthlyReport()
        {
            List<AccountStatementGoldVM> accountStatements = new List<AccountStatementGoldVM>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string AccountName = Request["AccountName"].ToString();

            string stACCOUNTS_Param = Request["Accounts"].ToString();
            string accnumber = stACCOUNTS_Param;

            stACCOUNTS_Param = "<DS><ACCOUNTS><ACC_ID>" + stACCOUNTS_Param + "</ACC_ID></ACCOUNTS></DS>";
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.Accounts = stACCOUNTS_Param;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    DateTime d = DateTime.ParseExact(stStartDate, "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                    d = d.AddDays(-1);
                    string datebefore = d.ToString("dd/MM/yyyy");
                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetGoldBusyTotalMonthly/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<AccountStatementGoldVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {

                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }


                        string DEBITGold24 = DataSet[0].DEBIT_Gold24.ToString();

                        string CREDITGold24 = DataSet[0].CREDIT_Gold24.ToString();
                        string DEBITGold22 = DataSet[0].DEBIT_Gold22.ToString();
                        string CREDITGold22 = DataSet[0].CREDIT_Gold22.ToString();
                        string DEBITGold21 = DataSet[0].DEBIT_Gold21.ToString();
                        string CREDITGold21 = DataSet[0].CREDIT_Gold21.ToString();
                        string DEBITGold18 = DataSet[0].DEBIT_Gold18.ToString();
                        string CREDITGold18 = DataSet[0].CREDIT_Gold18.ToString();
                        DataSet.RemoveAt(0);
                        BindReport("GoldBusyTotalMonthly", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter4", arEndDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", AccountName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter5", datebefore));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter6", DEBITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter7", CREDITGold24));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter8", DEBITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter9", CREDITGold22));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter10", DEBITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter11", CREDITGold21));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter12", DEBITGold18));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter13", CREDITGold18));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<EntryDetails_ReportVM> GetEntriesDetailsDaily()
        {
            List<EntryDetails_ReportVM> accountStatements = new List<EntryDetails_ReportVM>();
            
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                 
                    Model.EndDate = stEndDate;
                  
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetEntries_DETAILS_Daily/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<EntryDetails_ReportVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }

                        BindReport("EntriesDetailsDaily", DataSet);
                      
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arEndDate));




                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<PurchasesDetails>  PurchasesDetailsItemsReport()
        {
            List<PurchasesDetails> accountStatements = new List<PurchasesDetails>();
            string stStartDate = Request["startDate"].ToString();
            
            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    DateTime d = DateTime.ParseExact(stStartDate, "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                    d = d.AddDays(-1);
                    string datebefore = d.ToString("dd/MM/yyyy");
                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/PurchasesDetailsItems/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<PurchasesDetails>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {

                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }


                        string DEBITGold24 = DataSet[0].DEBIT_Gold24.ToString();

                        string CREDITGold24 = DataSet[0].CREDIT_Gold24.ToString();
                        string DEBITGold22 = DataSet[0].DEBIT_Gold22.ToString();
                        string CREDITGold22 = DataSet[0].CREDIT_Gold22.ToString();
                        string DEBITGold21 = DataSet[0].DEBIT_Gold21.ToString();
                        string CREDITGold21 = DataSet[0].CREDIT_Gold21.ToString();
                        string DEBITGold18 = DataSet[0].DEBIT_Gold18.ToString();
                        string CREDITGold18 = DataSet[0].CREDIT_Gold18.ToString();
                        DataSet.RemoveAt(0);
                        BindReport("PurchasesDetailsItems", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arEndDate));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<EntryDetails_ReportVM> GetEntriesDetailsMonthly()
        {
            List<EntryDetails_ReportVM> accountStatements = new List<EntryDetails_ReportVM>();

            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
           
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetEntries_DETAILS_Monthly/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<EntryDetails_ReportVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }

                        BindReport("EntriesDetailsMonthly", DataSet);

                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arEndDate));



                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }
        public List<EntryDetails_ReportVM> GetEntriesDetailsTotalMonthly()
        {
            List<EntryDetails_ReportVM> accountStatements = new List<EntryDetails_ReportVM>();

            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();

            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/GetEntries_Total_Monthly/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<EntryDetails_ReportVM>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {
                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }

                        BindReport("EntriesDetailsDaily", DataSet);

                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", CompanyName));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter3", arEndDate));



                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

        public List<PurchasesDetails> PurchasesDetailsDailyReport()
        {
            List<PurchasesDetails> accountStatements = new List<PurchasesDetails>();
            string stStartDate = Request["startDate"].ToString();

            string arStartDate = Request["arStartDate"].ToString();
            string arEndDate = Request["arEndDate"].ToString();

            string stEndDate = Request["EndDate"].ToString();

            string stCompanyBranch = Request["companyBranches"].ToString();
            string CompanyName = Request["CompanyName"].ToString();
            try
            {

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(UrlAPI);

                    dynamic Model = new ExpandoObject();
                    Model.companyBranches = stCompanyBranch;
                    Model.StartDate = stStartDate;
                    Model.EndDate = stEndDate;
                    Model.CostCenterId = null;
                    var jsonString = JsonConvert.SerializeObject(Model);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    DateTime d = DateTime.ParseExact(stStartDate, "yyyyMMdd",
                                   CultureInfo.InvariantCulture);
                    d = d.AddDays(-1);
                    string datebefore = d.ToString("dd/MM/yyyy");
                    client.DefaultRequestHeaders.Clear();

                    var response = client.PostAsync("billMaster/PurchasesDetailsDaily/", content);
                    response.Wait();

                    dynamic ResultResponse = response.Result.Content.ReadAsStringAsync();

                    {

                        var DataSet = (JsonConvert.DeserializeObject<List<PurchasesDetails>>(ResultResponse.Result));

                        foreach (var item in DataSet)
                        {
                            if (item.DATE != null)
                            {

                                string s2 = item.DATE.ToString("dd-MM-yyyy");
                                item.DATE = DateTime.ParseExact(s2, "dd-MM-yyyy",
                                    CultureInfo.InvariantCulture);
                            }
                        }


                        string DEBITGold24 = DataSet[0].DEBIT_Gold24.ToString();

                        string CREDITGold24 = DataSet[0].CREDIT_Gold24.ToString();
                        string DEBITGold22 = DataSet[0].DEBIT_Gold22.ToString();
                        string CREDITGold22 = DataSet[0].CREDIT_Gold22.ToString();
                        string DEBITGold21 = DataSet[0].DEBIT_Gold21.ToString();
                        string CREDITGold21 = DataSet[0].CREDIT_Gold21.ToString();
                        string DEBITGold18 = DataSet[0].DEBIT_Gold18.ToString();
                        string CREDITGold18 = DataSet[0].CREDIT_Gold18.ToString();
                        DataSet.RemoveAt(0);
                        BindReport("PurchasesDetailsItems", DataSet);
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter1", arStartDate));
                        this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Parameter2", arEndDate));
                    }

                }
                return accountStatements;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }

        }

    }
}