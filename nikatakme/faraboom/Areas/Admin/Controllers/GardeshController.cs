using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Admin.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GardeshController : BaseController
    {
        public GardeshController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {

        }

         ///select bank
        public IActionResult Index()
        {
            return View();
        }
        //create Access
        public IActionResult Access(string bankid)
        {
            ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }
            var client = new RestSharp.RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/authorize?client_id=nikatak5250&response_type=code&redirect_uri=https://nikatak.ir/verify&scope=oak:statement:get&bank=" + bankid + "");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
            request.AddHeader("Cookie", "boomrangid=s%3ATk2WBPGh3sUlrg5j3Xn-v6bVuWCcEuHw.PEXico%2FkAuoadncP%2B%2F%2FfsUelQWQlAFXiXR7S7Ycq5Yo; connect.sid=s%3Ad44HHRz3Hhn1b8mbpCg2kG5Ve_aVyWYh.T6vqOfZ6oBjRIM%2BWQ6%2FGLSoUWxfm0DUl9bvOW7LGvu8");
            IRestResponse response = client.Execute(request);


            var qwe="Gardesh";
            HttpContext.Session.SetString("IdBank", bankid);
            HttpContext.Session.SetString("Ret", qwe);
            




            return Redirect(response.ResponseUri.ToString());



        }
        
        //create token
        public IActionResult Urlback()
        {

            var code=HttpContext.Session.GetString("CR");
            string bankid = HttpContext.Session.GetString("IdBank");

            var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
            request.AddHeader("Cookie", "boomrangid=s%3Aa9wyuhzs0reZ3FhuFQdMNR-4iZWdspP7.bere%2BHtpg%2BqkQR0gA4g0%2FSIjox%2BLBihHeFjIkUPsHlo");
            var body =
            "{" +
            "\"grant_type\":\"authorization_code\","
            + "\"code\":\"" + code + "\","
             + "\"bank\":\"" + bankid + "\","
              + "\"redirect_uri\":\"https://nikatak.ir/verify\""
            + "}";


            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var value1 = JsonConvert.DeserializeObject<Root>(response.Content);
            HttpContext.Session.SetString("tokencode", value1.Result.Value);
            ViewBag.Hesabs = value1.Result.Deposits;

            return View();
        }
        public IActionResult result(vm_Gardesh Gardesh)
        {   try
                {
                    var token = HttpContext.Session.GetString("tokencode");
                    var client = new RestClient("https://apibeta.finnotech.ir/oak/v2/clients/nikatak5250/deposits/"+Gardesh.Deposit+"/statement?toDate="+Gardesh.To+"&fromDate="+Gardesh.From+"");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("Authorization", "Bearer"+" "+token);
                    request.AddHeader("Cookie", "boomrangid=s%3AUJCk7WO29No6Wvv0ZJ5A7LDv6whfjIWi.B4qNgSlMuXQlqzmeTg0lZ8oIWCunGG8YR8fa%2FKge%2Fw8");
                    var body = @"";
                    request.AddParameter("text/plain", body, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var value2 = JsonConvert.DeserializeObject<Root1>(response.Content);
                    ViewBag.result = value2.Result1.Transactions.ToList();
                    ///karmozd
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "استعلام",
                        Amount = 500,
                        Titel_Request = "استعلام گردش حساب",
                        Date_Request = DateTime.UtcNow,
                        Bill_Id =  Gardesh.Deposit,
                        Pay_Id ="استعلام گردش حساب",
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(500, qfinal.Id);
                    Diposit();
                }
                catch (System.Exception ex)
                {
                      ViewBag.result = null;
                      
                }
           
            return View();
        }
        
        //create token value
        public class Result
        {
            [JsonProperty("scopes")]
            public List<string> Scopes { get; set; }

            [JsonProperty("monthlyCallLimitation")]
            public int MonthlyCallLimitation { get; set; }

            [JsonProperty("maxAmountPerTransaction")]
            public int MaxAmountPerTransaction { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("creationDate")]
            public string CreationDate { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("bank")]
            public string Bank { get; set; }

            [JsonProperty("lifeTime")]
            public int LifeTime { get; set; }

            [JsonProperty("deposits")]
            public List<string> Deposits { get; set; }

            [JsonProperty("clientId")]
            public string ClientId { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }
        }

        public class Root
        {
            [JsonProperty("result")]
            public Result Result { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }


        
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
       // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class OperationCode
    {
        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("operationCode")]
        public OperationCode OperationCode { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("transactionAmountCredit")]
        public string TransactionAmountCredit { get; set; }

        [JsonProperty("transactionAmountDebit")]
        public string TransactionAmountDebit { get; set; }

        [JsonProperty("transactionDescription")]
        public string TransactionDescription { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("time")]
        public object Time { get; set; }

        [JsonProperty("branchNo")]
        public string BranchNo { get; set; }

        [JsonProperty("recordNumber")]
        public object RecordNumber { get; set; }

        [JsonProperty("userID")]
        public object UserID { get; set; }

        [JsonProperty("refCode")]
        public object RefCode { get; set; }
    }

    public class Result1
    {
        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("branchCode")]
        public object BranchCode { get; set; }

        [JsonProperty("branchName")]
        public object BranchName { get; set; }

        [JsonProperty("accountCurrentBalance")]
        public string AccountCurrentBalance { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("accountTypeCode")]
        public object AccountTypeCode { get; set; }

        [JsonProperty("subTypeCode")]
        public object SubTypeCode { get; set; }

        [JsonProperty("customerName")]
        public object CustomerName { get; set; }

        [JsonProperty("customerFamilyName")]
        public object CustomerFamilyName { get; set; }

        [JsonProperty("backupAccountNumber")]
        public object BackupAccountNumber { get; set; }

        [JsonProperty("accountCurrentBalanceSign")]
        public object AccountCurrentBalanceSign { get; set; }

        [JsonProperty("accountAvailableBalance")]
        public object AccountAvailableBalance { get; set; }

        [JsonProperty("accountAvailableBalanceSign")]
        public object AccountAvailableBalanceSign { get; set; }

        [JsonProperty("effectiveAccountBalance")]
        public object EffectiveAccountBalance { get; set; }

        [JsonProperty("effectiveAccountBalanceSign")]
        public object EffectiveAccountBalanceSign { get; set; }

        [JsonProperty("openDate")]
        public object OpenDate { get; set; }
    }

    public class Root1
    {
        [JsonProperty("trackId")]
        public string TrackId { get; set; }

        [JsonProperty("result")]
        public Result1 Result1 { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }








    }
}
