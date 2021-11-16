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
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Blog;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Originality;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.inforep;
using Microsoft.AspNetCore.Http;
using ViewModels.AdminViewModel.Gabz;
using DataLayer.AdminEntities.Request;
using DataLayer.AdminEntities.PayBills;
using DataLayer.AdminEntities.wallet;
using Extensions;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PayGabzController : BaseController
    {
        public PayGabzController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {
        }

        
    //     ///select bank
        public IActionResult Index()
        {
            return View();
        }
        //create Access
        public IActionResult Access()
        {

            var bankid="062";
            var client = new RestSharp.RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/authorize?client_id=nikatak5250&response_type=code&redirect_uri=https://nikatak.ir/verify&scope=oak:bill-account:execute&limit=10000000&count=1000&bank="+bankid+"");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
            request.AddHeader("Cookie", "boomrangid=s%3ATk2WBPGh3sUlrg5j3Xn-v6bVuWCcEuHw.PEXico%2FkAuoadncP%2B%2F%2FfsUelQWQlAFXiXR7S7Ycq5Yo; connect.sid=s%3Ad44HHRz3Hhn1b8mbpCg2kG5Ve_aVyWYh.T6vqOfZ6oBjRIM%2BWQ6%2FGLSoUWxfm0DUl9bvOW7LGvu8");
            IRestResponse response = client.Execute(request);




            return Redirect(response.ResponseUri.ToString());



        }


    //     //create token
        public IActionResult Urlback(string code)
        {
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
            + "\"bank\":\"062\","
            + "\"redirect_uri\":\"https://nikatak.ir/verify\""
            + "}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var value1 = JsonConvert.DeserializeObject<Root>(response.Content);
            var token=db.Tbl_TokenPayGabzValues.SingleOrDefault();
            token.Token=value1.Result.Value;
            token.Refresh=value1.Result.RefreshToken;
            token.LifeTime=DateTime.Today.AddDays(9);
            db.Tbl_TokenPayGabzValues.Update(token);
            db.SaveChanges();
            ViewBag.token="توکن با موفقیت اپدیت شد";
            return View();
        }


        public IActionResult Test()
        {
            
            return View();
        }
        public IActionResult result(Vm_Gabz Gabz)
        { 
            
            var GabzTitel = "null" ;
            switch (Gabz.Titel)
            {
                case "Water":
                    GabzTitel = "آب";
                    break;

                case "Electricity":
                    GabzTitel = "برق";
                    break;

                case "Gas":
                    GabzTitel = "گاز";
                    break;

                case "Mobile":
                    GabzTitel = "تلفن همراه";
                    break;

                case "MobileNow":
                    GabzTitel = "تلفن همراه";
                    break;

                case "Tel":
                    GabzTitel = "تلفن ثابت";
                    break;

                case "TelNow":
                    GabzTitel = "تلفن ثابت";
                    break;
            }
            //check mojodi
                if (HttpContext.Session.GetInt32("sum") >= (1000 + Gabz.amount/10))
                {
                    //sent to bank
                    var checkany=db.Tbl_PayBills.Any(a=>a.BillId== Gabz.bill_id && a.PayId == Gabz.pay_id);
                    if (checkany)
                    {
                        ViewBag.Msg = "این قبض قبلا پرداخت شده است .";
                        Diposit();
                        return View();
                    }
                        string StrTrackId = Guid.NewGuid().ToString("N").Substring(0, 15);
                        
                        var token=db.Tbl_TokenPayGabzValues.SingleOrDefault().Token;
                        
                        var client = new RestClient("https://apibeta.finnotech.ir/oak/v2/clients/nikatak5250/billPayment?trackId="+StrTrackId+"");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "Bearer"+" "+token);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Cookie", "boomrangid=s%3A5aSDTwS0_f55lXJQ5Ug6amY_5nDNKsa2.2dVBXBwPu7VuYJDvH39jpKZSx%2FRjg%2Fk4gPQtzbOuOOo");
                        var body =
                        "{" +
                        "\"payId\":\"" + Gabz.pay_id + "\","
                        + "\"billId\":\"" + Gabz.bill_id + "\""
                        + "}";
                        request.AddParameter("application/json", body,  ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        var value2 = JsonConvert.DeserializeObject<Root1>(response.Content);

                     //check response is true
                        if (value2.Status=="DONE")
                        {
                            //add karmozde
                                    Tbl_Request tb = new Tbl_Request
                                    {
                                        UserName = User.Identity.GetId(),
                                        Type_Request = "پرداخت قبض",
                                        Bill_Id = Gabz.bill_id,
                                        Pay_Id = Gabz.pay_id,
                                        Amount = 1000,
                                        Titel_Request =GabzTitel,
                                        Date_Request = DateTime.UtcNow,
                                    };
                                    db.Tbl_Requests.Add(tb);
                                    db.SaveChanges();
                                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                    proccess(1000, qfinal.Id);
                                 /// pay Fish
                                    Tbl_Request tb1 = new Tbl_Request
                                    {
                                        UserName = User.Identity.GetId(),
                                        Type_Request = "پرداخت قبض",
                                        Bill_Id = Gabz.bill_id,
                                        Pay_Id = Gabz.pay_id,
                                        Amount = Gabz.amount/10,
                                        Titel_Request = GabzTitel,
                                        Date_Request = DateTime.UtcNow,
                                    };
                                    db.Tbl_Requests.Add(tb1);
                                    db.SaveChanges();
                                    var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                    //proccess(Gabz.amount/10, qfinal1.Id);
                                    //proccess chanche
                                    Diposit();
                                    Tbl_pay A = new Tbl_pay()
                                    {
                                        UserName = User.Identity.GetId(),
                                        Harvest = Gabz.amount/10,
                                        DateTime = DateTime.UtcNow,
                                        status = true,
                                        RequestId = qfinal1.Id
                                    };
                                    db.Tbl_pays.Add(A);
                                    db.SaveChanges();

                            //add to tbl_pay_gabz
                                    Tb_PayBill Pays = new Tb_PayBill
                                            {
                                                Type= GabzTitel +" "+ value2.Result1.BillType ,
                                                BillId=Gabz.bill_id,
                                                PayId=Gabz.pay_id,
                                                User=User.Identity.GetId(),
                                                Amount=value2.Result1.ActualAmount.ToString(),
                                                Date=value2.Result1.TransactionDate,
                                                Time=value2.Result1.TransactionTime,
                                                ShenaseMarja=value2.Result1.RRN,
                                                PeygiriId=value2.Result1.TraceNumber,
                                            };
                                            db.Tbl_PayBills.Add(Pays);
                                            db.SaveChanges();
                            // view result
                                    ViewBag.TransactionDate=value2.Result1.TransactionDate;
                                    ViewBag.TransactionTime=value2.Result1.TransactionTime;
                                    ViewBag.TraceNumber=value2.Result1.TraceNumber;
                                    ViewBag.Message=value2.Result1.Message;
                                    ViewBag.ActualAmount=value2.Result1.ActualAmount;
                                    ViewBag.BillType=value2.Result1.BillType;
                                    ViewBag.RRN=value2.Result1.RRN;
                                    ViewBag.Pay=Gabz.pay_id;
                                    ViewBag.Bill=Gabz.bill_id;

                            /// 
                        }
                        else
                        {
                             ViewBag.Msg = " پاسخی از بانک دریافت نشد.";
                        }
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
                Diposit();
                return View();
        }
        
        // public IActionResult result(Vm_Gabz Gabz)
        // {
        //     //check mojodi
        //         if (HttpContext.Session.GetInt32("sum") >= (1000 + Gabz.amount/10))
        //         {
        //             //sent to bank
        //                 // uuid
        //             var checkany=db.Tbl_PayBills.Any(a=>a.BillId== Gabz.bill_id && a.PayId == Gabz.pay_id);
        //             if (checkany)
        //             {
        //                 ViewBag.Msg = "این قبض قبلا پرداخت شده است .";
        //                 Diposit();
        //                 return View();
        //             }
        //                 string StrTrackId = Guid.NewGuid().ToString("N").Substring(0, 15);
        //                 //
        //                 var token=db.Tbl_TokenPayGabzValues.SingleOrDefault().Token;
                        
        //                 var client = new RestClient("https://apibeta.finnotech.ir/oak/v2/clients/nikatak5250/billPayment?trackId="+StrTrackId+"");
        //                 client.Timeout = -1;
        //                 var request = new RestRequest(Method.POST);
        //                 request.AddHeader("Authorization", "Bearer"+" "+token);
        //                 request.AddHeader("Content-Type", "application/json");
        //                 request.AddHeader("Cookie", "boomrangid=s%3A5aSDTwS0_f55lXJQ5Ug6amY_5nDNKsa2.2dVBXBwPu7VuYJDvH39jpKZSx%2FRjg%2Fk4gPQtzbOuOOo");
        //                 var body =
        //                 "{" +
        //                 "\"payId\":\"" + Gabz.pay_id + "\","
        //                 + "\"billId\":\"" + Gabz.bill_id + "\""
        //                 + "}";
        //                 request.AddParameter("application/json", body,  ParameterType.RequestBody);
        //                 IRestResponse response = client.Execute(request);
        //                 var value2 = JsonConvert.DeserializeObject<Root1>(response.Content);

        //             ///
                   
        //              //check response is true
        //                 if (value2.Status=="DONE")
        //                 {
        //                     //add karmozde
        //                             Tbl_Request tb = new Tbl_Request
        //                             {
        //                                 UserName = User.Identity.GetId(),
        //                                 Type_Request = "پرداخت قبض",
        //                                 Bill_Id = Gabz.bill_id,
        //                                 Pay_Id = Gabz.pay_id,
        //                                 Amount = 1000,
        //                                 Titel_Request =Gabz.Titel,
        //                                 Date_Request = DateTime.UtcNow,
        //                             };
        //                             db.Tbl_Requests.Add(tb);
        //                             db.SaveChanges();
        //                             var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
        //                             proccess(1000, qfinal.Id);
        //                          /// pay Fish
        //                             Tbl_Request tb1 = new Tbl_Request
        //                             {
        //                                 UserName = User.Identity.GetId(),
        //                                 Type_Request = "پرداخت قبض",
        //                                 Bill_Id = Gabz.bill_id,
        //                                 Pay_Id = Gabz.pay_id,
        //                                 Amount = Gabz.amount/10,
        //                                 Titel_Request = Gabz.Titel,
        //                                 Date_Request = DateTime.UtcNow,
        //                             };
        //                             db.Tbl_Requests.Add(tb1);
        //                             db.SaveChanges();
        //                             var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
        //                             //proccess(Gabz.amount/10, qfinal1.Id);
        //                             //proccess chanche
        //                             Diposit();
        //                             Tbl_pay A = new Tbl_pay()
        //                             {
        //                                 UserName = User.Identity.GetId(),
        //                                 Harvest = Gabz.amount/10,
        //                                 DateTime = DateTime.UtcNow,
        //                                 status = true,
        //                                 RequestId = qfinal1.Id
        //                             };
        //                             db.Tbl_pays.Add(A);
        //                             db.SaveChanges();

        //                     //add to tbl_pay_gabz
        //                             Tb_PayBill Pays = new Tb_PayBill
        //                                     {
        //                                         Type= Gabz.Titel +" "+ value2.Result1.BillType ,
        //                                         BillId=Gabz.bill_id,
        //                                         PayId=Gabz.pay_id,
        //                                         User=User.Identity.GetId(),
        //                                         Amount=value2.Result1.ActualAmount.ToString(),
        //                                         Date=value2.Result1.TransactionDate,
        //                                         Time=value2.Result1.TransactionTime,
        //                                         ShenaseMarja=value2.Result1.RRN,
        //                                         PeygiriId=value2.Result1.TraceNumber,
        //                                     };
        //                                     db.Tbl_PayBills.Add(Pays);
        //                                     db.SaveChanges();
        //                     // view result
        //                             ViewBag.TransactionDate=value2.Result1.TransactionDate;
        //                             ViewBag.TransactionTime=value2.Result1.TransactionTime;
        //                             ViewBag.TraceNumber=value2.Result1.TraceNumber;
        //                             ViewBag.Message=value2.Result1.Message;
        //                             ViewBag.ActualAmount=value2.Result1.ActualAmount;
        //                             ViewBag.BillType=value2.Result1.BillType;
        //                             ViewBag.RRN=value2.Result1.RRN;
        //                             ViewBag.Pay=Gabz.pay_id;
        //                             ViewBag.Bill=Gabz.bill_id;

        //                     /// 
        //                 }
        //                 else
        //                 {
        //                      ViewBag.Msg = " پاسخی از بانک دریافت نشد.";
        //                 }
                    
        //             /// end pay fish
        //         }
        //         else
        //         {
        //             ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
        //         }
        //         Diposit();
        //         return View();
        // }

        //create token value

        //pay jarime taki
        public IActionResult payjarime(string billid,string payid,string amount)
        {
                    //check mojodi
                if (HttpContext.Session.GetInt32("sum") >= (1000 + Convert.ToInt32(amount)/10))
                {
                    //sent to bank
                        // uuid
                    var checkany=db.Tbl_PayBills.Any(a=>a.BillId== billid && a.PayId == payid);
                    if (checkany)
                    {
                        ViewBag.Msg = "این قبض قبلا پرداخت شده است .";
                        Diposit();
                        return View();
                    }
                        string StrTrackId = Guid.NewGuid().ToString("N").Substring(0, 15);
                        //
                        var token=db.Tbl_TokenPayGabzValues.SingleOrDefault().Token;
                        
                        var client = new RestClient("https://apibeta.finnotech.ir/oak/v2/clients/nikatak5250/billPayment?trackId="+StrTrackId+"");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorization", "Bearer"+" "+token);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Cookie", "boomrangid=s%3A5aSDTwS0_f55lXJQ5Ug6amY_5nDNKsa2.2dVBXBwPu7VuYJDvH39jpKZSx%2FRjg%2Fk4gPQtzbOuOOo");
                        var body =
                        "{" +
                        "\"payId\":\"" + payid + "\","
                        + "\"billId\":\"" + billid + "\""
                        + "}";
                        request.AddParameter("application/json", body,  ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        var value2 = JsonConvert.DeserializeObject<Root1>(response.Content);

                    ///
                   
                     //check response is true
                        if (value2.Status=="DONE")
                        {
                            //add karmozde
                                    Tbl_Request tb = new Tbl_Request
                                    {
                                        UserName = User.Identity.GetId(),
                                        Type_Request = "پرداخت قبض",
                                        Bill_Id = billid,
                                        Pay_Id = payid,
                                        Amount = 1000,
                                        Titel_Request ="پرداخت خلافی",
                                        Date_Request = DateTime.UtcNow,
                                    };
                                    db.Tbl_Requests.Add(tb);
                                    db.SaveChanges();
                                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                    proccess(1000, qfinal.Id);
                                 /// pay Fish
                                    Tbl_Request tb1 = new Tbl_Request
                                    {
                                        UserName = User.Identity.GetId(),
                                        Type_Request = "پرداخت قبض",
                                        Bill_Id = billid,
                                        Pay_Id = payid,
                                        Amount = Convert.ToInt32(amount)/10,
                                        Titel_Request = "پرداخت جریمه",
                                        Date_Request = DateTime.UtcNow,
                                    };
                                    db.Tbl_Requests.Add(tb1);
                                    db.SaveChanges();
                                    var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                    //proccess(Gabz.amount/10, qfinal1.Id);
                                    //proccess chanche
                                    Diposit();
                                    Tbl_pay A = new Tbl_pay()
                                    {
                                        UserName = User.Identity.GetId(),
                                        Harvest = Convert.ToInt32(amount)/10,
                                        DateTime = DateTime.UtcNow,
                                        status = true,
                                        RequestId = qfinal1.Id
                                    };
                                    db.Tbl_pays.Add(A);
                                    db.SaveChanges();

                            //add to tbl_pay_gabz
                                    Tb_PayBill Pays = new Tb_PayBill
                                            {
                                                Type= "پرداخت جریمه" +" "+ value2.Result1.BillType ,
                                                BillId=billid,
                                                PayId=payid,
                                                User=User.Identity.GetId(),
                                                Amount=value2.Result1.ActualAmount.ToString(),
                                                Date=value2.Result1.TransactionDate,
                                                Time=value2.Result1.TransactionTime,
                                                ShenaseMarja=value2.Result1.RRN,
                                                PeygiriId=value2.Result1.TraceNumber,
                                            };
                                            db.Tbl_PayBills.Add(Pays);
                                            db.SaveChanges();
                            // view result
                                    ViewBag.TransactionDate=value2.Result1.TransactionDate;
                                    ViewBag.TransactionTime=value2.Result1.TransactionTime;
                                    ViewBag.TraceNumber=value2.Result1.TraceNumber;
                                    ViewBag.Message=value2.Result1.Message;
                                    ViewBag.ActualAmount=value2.Result1.ActualAmount;
                                    ViewBag.BillType=value2.Result1.BillType;
                                    ViewBag.RRN=value2.Result1.RRN;
                                    ViewBag.Pay=payid;
                                    ViewBag.Bill=billid;

                            /// 
                        }
                        else
                        {
                             ViewBag.Msg = " پاسخی از بانک دریافت نشد.";
                        }
                    
                    /// end pay fish
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
                Diposit();
                return View();
        }
        









        /// 
        
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
        // Result paygabz
        public class Result1
        {
            [JsonProperty("transactionDate")]
            public string TransactionDate { get; set; }

            [JsonProperty("transactionTime")]
            public string TransactionTime { get; set; }

            [JsonProperty("traceNumber")]
            public string TraceNumber { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("actualAmount")]
            public int ActualAmount { get; set; }

            [JsonProperty("billType")]
            public string BillType { get; set; }

            [JsonProperty("RRN")]
            public string RRN { get; set; }
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
        public string Set_Token()
        {
            var client = new RestClient("https://appservices.ir:8072/api/User/Authorization");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
            " + "\n" +
            @"  ""username"": ""TestUser"",
            " + "\n" +
            @"  ""password"": ""12345""
            " + "\n" +
            @"}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var settoken_des = JsonConvert.DeserializeObject<Root_Token>(response.Content); 

            Console.WriteLine(response.Content);
            return settoken_des.value.Response ;
        } 
        public class Value
        {            
            public string Response  { get; set; }
        }
        public class Error
        {
        }
        public class Root_Token
        {
            public DateTime timeStamp { get; set; }
            public int responseCode { get; set; }
            public string message { get; set; }
            public Value value { get; set; }
            public Error error { get; set; }
        }

        //-------------------------------------- PayGabz/Gabz_Pay

        public IActionResult Gabz_Pay()
        {
            return View();
        }
        
        public IActionResult Pardakht_Gabz(Vm_Gabz vg)
        {
            if ( db.Tbl_PayBills.Any( a => a.BillId == vg.bill_id && a.PayId == vg.pay_id ) )
            {
                ViewBag.Msg = " این قبض قبلا پرداخت شده است . ";
            }
            else
            {
                if(HttpContext.Session.GetInt32("sum") >= (1000 + vg.amount/10))
                {
                    try
                    {
                        string bill_id = "";
                        string pay_id = "";

                        if (vg.bill_id.Length == 13)
                        {
                            bill_id = vg.bill_id;
                        }
                        else
                        {
                            var num = 13 - (vg.bill_id.Length);
                            bill_id = vg.bill_id;
                            for (int i = 1; i <= num; i++)
                            {
                                bill_id = "0" + bill_id;
                            }

                        }

                        if (vg.pay_id.Length == 13)
                        {
                            pay_id = vg.pay_id;
                        }
                        else
                        {
                            var num = 13 - (vg.pay_id.Length);
                            pay_id = vg.pay_id;
                            for (int i = 1; i <= num; i++)
                            {
                                pay_id = "0" + pay_id;
                            }
                        }

                        var GabzTitel = "null" ;
                        switch (vg.Titel)
                        {
                            case "Water":
                                GabzTitel = "آب";
                                break;

                            case "Electricity":
                                GabzTitel = "برق";
                                break;

                            case "Gas":
                                GabzTitel = "گاز";
                                break;

                            case "Mobile":
                                GabzTitel = "تلفن همراه";
                                break;

                            case "MobileNow":
                                GabzTitel = "تلفن همراه";
                                break;

                            case "Tel":
                                GabzTitel = "تلفن ثابت";
                                break;

                            case "TelNow":
                                GabzTitel = "تلفن ثابت";
                                break;
                        }

                        var token = Set_Token();
                        var client = new RestClient("https://appservices.ir:8072/api/payment/Add");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Authorizationbearer", token);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Authorization", "Bearer " + token);
                        var body = "{" +
                                    "\"payId\":\"" + pay_id + "\","
                                    + "\"billId\":\"" + bill_id + "\""
                                    + "}";
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        var testgabz_des = JsonConvert.DeserializeObject<Root_Gabz>(response.Content);
                        ViewBag.result = testgabz_des;

                        if (testgabz_des.ResponseCode == 200)
                        {

                            Tbl_Request tb = new Tbl_Request
                            {
                                UserName = User.Identity.GetId(),
                                Type_Request = "پرداخت قبض",
                                Bill_Id = vg.bill_id,
                                Pay_Id = vg.pay_id,
                                Amount = 1000,
                                Titel_Request = GabzTitel,
                                Date_Request = DateTime.UtcNow,
                            };
                            db.Tbl_Requests.Add(tb);
                            db.SaveChanges();
                            var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                            proccess(1000, qfinal.Id);

                            Tbl_Request tb1 = new Tbl_Request
                            {
                                UserName = User.Identity.GetId(),
                                Type_Request = "پرداخت قبض",
                                Bill_Id = vg.bill_id,
                                Pay_Id = vg.pay_id,
                                Amount = vg.amount / 10,
                                Titel_Request = GabzTitel,
                                Date_Request = DateTime.UtcNow,
                            };
                            db.Tbl_Requests.Add(tb1);
                            db.SaveChanges();
                            var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();

                            Diposit();
                            Tbl_pay A = new Tbl_pay()
                            {
                                UserName = User.Identity.GetId(),
                                Harvest = vg.amount / 10,
                                DateTime = DateTime.UtcNow,
                                status = true,
                                RequestId = qfinal1.Id
                            };
                            db.Tbl_pays.Add(A);
                            db.SaveChanges();

                            string guid = Guid.NewGuid().ToString("N");

                            Tb_PayBill Pays = new Tb_PayBill
                            {
                                Type = GabzTitel,
                                BillId = vg.bill_id,
                                PayId = vg.pay_id,
                                User = User.Identity.GetId(),
                                Amount = vg.amount.ToString(),
                                Date = DateTime.UtcNow.ToString(),
                                Time = DateTime.UtcNow.ToString(),
                                ShenaseMarja = guid,
                                PeygiriId = guid,
                            };
                            db.Tbl_PayBills.Add(Pays);
                            db.SaveChanges();

                            ViewBag.Msgs = " پرداخت با موفقیت انجام شد ." ;

                            ViewBag.TransactionDate = DateTime.UtcNow.ToPersianDateString();
                            ViewBag.TraceNumber = guid;
                            ViewBag.ActualAmount = vg.amount;
                            ViewBag.BillType = GabzTitel;
                            ViewBag.Bill = vg.bill_id;
                            ViewBag.Pay = vg.pay_id;


                        }
                        else
                        {
                            if (testgabz_des.Message != null)
                            {
                                ViewBag.Msg = " خطا در  پرداخت .";
                                ViewBag.Msgn = testgabz_des.Message;
                            }
                            else
                            {
                                ViewBag.Msg = " پاسخی از بانک دریافت نشد.";
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        ViewBag.Msg = " خطا در  پرداخت .";
                        ViewBag.er = ex ;
                    }

                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }

            return View();
        } 
        public class Value1
        {
        }

        public class Error1
        {
        }

        public class Root_Gabz
        {
            [JsonProperty("timeStamp")]
            public DateTime TimeStamp { get; set; }

            [JsonProperty("responseCode")]
            public int ResponseCode { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("value")]
            public Value1 Value { get; set; }

            [JsonProperty("error")]
            public Error1 Error { get; set; }
        }

        


        

    }
}
