using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Request;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using ViewModels.AdminViewModel.Gabz;
using faraboom.Models;
using Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mobile.Controllers
{
    [Area("Mobile")]
    [Authorize]
    public class GabzController : BaseController
    {
        public GabzController(ContextHampadco _db, IWebHostEnvironment env) :
            base(_db, env)
        {
        }

        //--------------------------------------Token
        public string Token()
        {
            var client =
                new RestClient("https://oauth.faraboom.co/oauth/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept-Language", "fa");
            request.AddHeader("app-key", "13075");
            request.AddHeader("Device-Id", "185.159.152.2");
            request.AddHeader("Bank-Id", "BEGNIR");
            request
                .AddHeader("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            request.AddHeader("CLIENT-DEVICE-ID", "127.0.0.1");
            request.AddHeader("CLIENT-IP-ADDRESS", "127.0.0.1");
            request.AddHeader("CLIENT-USER-AGENT", "127.0.0.1");
            request.AddHeader("CLIENT-USER-ID", "09121234567");
            request.AddHeader("CLIENT-PLATFORM-TYPE", "WEB");
            request
                .AddHeader("Authorization",
                "Basic MTMwNzU6UW5TM040aHpHSkVEa0l6Z1Z3dnpxY1NSWlBTNGpvVmtCNFBZbk9POTg=");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", "nik6562100");
            request.AddParameter("password", "10464418");
            request.AddParameter("grant_type", "password");
            var response = client.Execute(request);
            var token = response.Content.Split(", ");
            var token1 = token[0].Split(":");
            var token2 = token1[1].Split(",");
            string token3 = token2[0].Replace("/", "").Replace("\"", "");
            Diposit();
            return token3;
        }

        //..................................... Pardakht1
        // public async Task<IActionResult> Pardakht(Vm_Gabz vg)
        // {
        //     var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
        //     var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
        //     client.DefaultRequestHeaders.AcceptLanguage.Clear();
        //     client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
        //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token());
        //     client.DefaultRequestHeaders.Add("App-Key", "13075");
        //     client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
        //     client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
        //     client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
        //     client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
        //     client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
        //     var data = new
        //     {
        //         deposit_number = "102-850-6562100-1",
        //         bill_id = vg.bill_id2 ,
        //         pay_id = vg.pay_id2 ,
        //     };
        //     var response = await client.PostAsJsonAsync("bills/" + vg.bill_id2 + "/payments/" + vg.pay_id2 + "/deposit", data);
        //     if (response.IsSuccessStatusCode == true)
        //     {
        //         Tbl_Request tb = new Tbl_Request
        //         {
        //             UserName = User.Identity.GetId(),
        //             Type_Request = "پرداخت",
        //             Bill_Id = vg.bill_id,
        //             Pay_Id = vg.pay_id,
        //             Amount = 75,
        //             Titel_Request = vg.Titel,
        //            Date_Request = DateTime.UtcNow,
        //         };
        //         db.Tbl_Requests.Add(tb);
        //         db.SaveChanges();
        //         var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
        //         proccess(75, qfinal.Id);
        //     }
        //     ViewBag.Code = response;
        //     ViewBag.result = await response.Content.ReadAsStringAsync();
        //     Diposit();
        //     return View();
        // }

        public async Task<IActionResult> Pardakht(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token());
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    deposit_number = "102-850-6562100-1",
                    bill_id = vg.bill_id2,
                    pay_id = vg.pay_id2
                };
            var response =
                await client
                    .PostAsJsonAsync("bills/" +
                    vg.bill_id2 +
                    "/payments/" +
                    vg.pay_id2 +
                    "/deposit",
                    data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= (75 + vg.amount))
                {
                    Tbl_Request tb =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "پرداخت",
                            Bill_Id = vg.bill_id,
                            Pay_Id = vg.pay_id,
                            Amount = 75,
                            Titel_Request = vg.Titel,
                            Date_Request = DateTime.UtcNow
                        };
                    db.Tbl_Requests.Add (tb);
                    db.SaveChanges();
                    var qfinal =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(75, qfinal.Id);

                    /// pay Fish
                    Tbl_Request tb1 =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = " پرداخت قبض " + " " + vg.Titel,
                            Bill_Id = vg.bill_id2,
                            Pay_Id = vg.pay_id2,
                            Amount = vg.amount,
                            Titel_Request = vg.Titel,
                            Date_Request = DateTime.UtcNow
                        };
                    db.Tbl_Requests.Add (tb1);
                    db.SaveChanges();
                    var qfinal1 =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(vg.amount, qfinal1.Id);
                    ViewBag.Code = response;
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                    /// end pay fish
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.Code = response;
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult PardakhtError()
        {
            Diposit();
            return View();
        }

        public IActionResult PardakhtTe(Vm_Gabz vg)
        {
            Tbl_Request tb =
                new Tbl_Request {
                    UserName = User.Identity.GetId(),
                    Type_Request = "پرداخت",
                    Bill_Id = vg.bill_id,
                    Pay_Id = vg.pay_id,
                    Amount = 75,
                    Titel_Request = vg.Titel,
                    Date_Request = DateTime.UtcNow
                };
            db.Tbl_Requests.Add (tb);
            db.SaveChanges();
            var qfinal =
                db
                    .Tbl_Requests
                    .Where(a => a.UserName == User.Identity.GetId())
                    .OrderByDescending(a => a.Id)
                    .Take(1)
                    .SingleOrDefault();
            proccess(75, qfinal.Id);

            /// pay Fish
            Tbl_Request tb1 =
                new Tbl_Request {
                    UserName = User.Identity.GetId(),
                    Type_Request = " پرداخت قبض " + " " + vg.Titel,
                    Bill_Id = vg.bill_id2,
                    Pay_Id = vg.pay_id2,
                    Amount = vg.amount,
                    Titel_Request = vg.Titel,
                    Date_Request = DateTime.UtcNow
                };
            db.Tbl_Requests.Add (tb1);
            db.SaveChanges();
            var qfinal1 =
                db
                    .Tbl_Requests
                    .Where(a => a.UserName == User.Identity.GetId())
                    .OrderByDescending(a => a.Id)
                    .Take(1)
                    .SingleOrDefault();
            proccess(vg.amount, qfinal1.Id);
            Diposit();
            Random rand = new Random();
            int ran = rand.Next(100000000, 999999999);
            ViewBag.ra = ran;
            return View();
        }

        public async Task<IActionResult>
        Pardakht1(string bill_id2, string pay_id2, string amount)
        {
            var amount1 = Convert.ToInt32(amount);
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token());
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    deposit_number = "102-850-6562100-1",
                    bill_id = bill_id2,
                    pay_id = pay_id2
                };
            var response =
                await client
                    .PostAsJsonAsync("bills/" +
                    bill_id2 +
                    "/payments/" +
                    pay_id2 +
                    "/deposit",
                    data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= (75 + amount1))
                {
                    Tbl_Request tb =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "پرداخت",
                            Bill_Id = bill_id2,
                            Pay_Id = pay_id2,
                            Amount = 75,
                            Titel_Request = "خلافی",
                            Date_Request = DateTime.UtcNow
                        };
                    db.Tbl_Requests.Add (tb);
                    db.SaveChanges();
                    var qfinal =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(75, qfinal.Id);

                    /// pay Fish
                    Tbl_Request tb1 =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "خلافی",
                            Bill_Id = bill_id2,
                            Pay_Id = pay_id2,
                            Amount = amount1,
                            Titel_Request = "خلافی",
                            Date_Request = DateTime.UtcNow
                        };
                    db.Tbl_Requests.Add (tb1);
                    db.SaveChanges();
                    var qfinal1 =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(amount1, qfinal1.Id);
                    ViewBag.Code = response;
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                    /// end pay fish
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.Code = response;
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        //......................................gabz
        public IActionResult PayBillsByCard()
        {
            Diposit();
            return View();
        }

        public IActionResult InvoiceBill()
        {
            Diposit();
            return View();
        }

        public IActionResult PayBillByDeposit()
        {
            Diposit();
            return View();
        }

        // public async Task<IActionResult> ShowPayBillByDeposit(Vm_Gabz vg)
        // {
        //     var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
        //     var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
        //     client.DefaultRequestHeaders.AcceptLanguage.Clear();
        //     client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
        //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", vg.Token);
        //     client.DefaultRequestHeaders.Add("App-Key", "13075");
        //     client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
        //     client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
        //     client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
        //     client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
        //     client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
        //     var data = new
        //     {
        //         deposit_number = "102-850-6562100-1",
        //         bill_id = vg.bill_id2,
        //         pay_id = vg.pay_id2,
        //     };
        //     var response = await client.PostAsJsonAsync("bills/" + vg.bill_id2 + "/payments/" + vg.pay_id2 + "/deposit", data);
        //     if (response.IsSuccessStatusCode == true)
        //     {
        //         if (HttpContext.Session.GetInt32("sum") >= 75)
        //         {
        //             Tbl_Request tb = new Tbl_Request
        //             {
        //                 UserName = User.Identity.GetId(),
        //                 Type_Request = "پرداخت",
        //                 Bill_Id = vg.bill_id2,
        //                 Pay_Id = vg.pay_id2,
        //                 Amount = 75,
        //                 Titel_Request = vg.Titel,
        //                 Date_Request = DateTime.UtcNow,
        //             };
        //             db.Tbl_Requests.Add(tb);
        //             db.SaveChanges();
        //             var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
        //             proccess(75, qfinal.Id);
        //             ViewBag.Code = response;
        //             ViewBag.result = await response.Content.ReadAsStringAsync();
        //         }
        //         else
        //         {
        //             ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
        //         }
        //     }
        //     else
        //     {
        //         ViewBag.result = await response.Content.ReadAsStringAsync();
        //     }
        //     Diposit();
        //     return View();
        // }
        public async Task<IActionResult> ShowPayBillByDeposit(Vm_Gabz vg)
        {
            var baseAddress =
                new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Token());
            client.DefaultRequestHeaders.Add("App-Key", "13457");
            client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            client.DefaultRequestHeaders.Add("Bank-Id", "BOOMIR");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    deposit_number = "0203305445009",
                    bill_id = vg.bill_id2,
                    pay_id = vg.pay_id2
                };
            var response =
                await client
                    .PostAsJsonAsync("bills/" +
                    vg.bill_id2 +
                    "/payments/" +
                    vg.pay_id2 +
                    "/deposit",
                    data);
            if (response.IsSuccessStatusCode == true)
            {
                Tbl_Request tb =
                    new Tbl_Request {
                        UserName = User.Identity.GetId(),
                        Type_Request = "پرداخت",
                        Bill_Id = vg.bill_id2,
                        Pay_Id = vg.pay_id2,
                        Amount = 75,
                        Titel_Request = vg.Titel,
                        Date_Request = DateTime.UtcNow
                    };
                db.Tbl_Requests.Add (tb);
                db.SaveChanges();
                var qfinal =
                    db
                        .Tbl_Requests
                        .Where(a => a.UserName == User.Identity.GetId())
                        .OrderByDescending(a => a.Id)
                        .Take(1)
                        .SingleOrDefault();
                proccess(75, qfinal.Id);
                ViewBag.Code = response;
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult BatchPaymentOfBills()
        {
            Diposit();
            return View();
        }

        public IActionResult Batchpaymentwithdeposit()
        {
            Diposit();
            return View();
        }

        public IActionResult Receivebillreports()
        {
            Diposit();
            return View();
        }

        public IActionResult Payspecialbills()
        {
            Diposit();
            return View();
        }

        //..................................sharg
        public IActionResult Directchargerequest()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> ShwoDirectchargerequest(Vm_Gabz vg)
        {
            Diposit();

            // var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            // var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            // client.DefaultRequestHeaders.AcceptLanguage.Clear();
            // client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            // client.DefaultRequestHeaders.Add("App-Key", "13075");
            // client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            // client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
            // client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            // client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            // client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            // client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            // client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            // client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            // var data = new
            // {
            //     mobile_number = vg.mobile_number,
            //     amount = vg.amount,
            //     pan ="",
            //     pin ="",
            //     pin_type = "CARD",
            //     cvv2 ="",
            //     exp_date = "",
            //     track2 = ""
            // };
            // var response = await client.PostAsJsonAsync("charge/topup", data);
            // ViewBag.result = await response.Content.ReadAsStringAsync();
            return View();
        }

        public IActionResult BuyAChargIngPin()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> ShowBuyAChargIngPin(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    pan = vg.pan,
                    track2 = "",
                    pin = vg.pin,
                    pin_type = "CARD",
                    cvv2 = vg.cvv2,
                    exp_date = vg.exp_date,
                    payment_service_id = vg.payment_service_id,
                    amount = vg.amount,
                    merchant_id = ""
                };
            var response = await client.PostAsJsonAsync("charge/pin", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            return View();
        }

        //............................estelam gabz
        public IActionResult Waterbilldebtinquiry()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showwaterbillinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new { bill_id = vg.Water, identifier = "" };
            var response = await client.PostAsJsonAsync("vas/abfa/bills", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Bill_Id = vg.Water,
                            Pay_Id = vg.pay_id,
                            Amount = 200,
                            Titel_Request = "آب",
                            Date_Request = DateTime.UtcNow
                        };
                    db.Tbl_Requests.Add (tb);
                    db.SaveChanges();
                    var qfinal =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(200, qfinal.Id);
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult Waterbillsdebtinquiry()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showwatersbillinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    data = new [] { new { bill_id = "" }, new { bill_id = "" } }
                };
            var response =
                await client.PostAsJsonAsync("vas/abfa/bills/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Inquiryofelectricitybilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showelectricitybillinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new { bill_id = vg.Electricity };
            var response =
                await client.PostAsJsonAsync("vas/tavanir/bills", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 200,
                            Titel_Request = "برق",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id = vg.Electricity,
                            Pay_Id = vg.pay_id
                        };
                    db.Tbl_Requests.Add (tb);
                    db.SaveChanges();
                    var qfinal =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(200, qfinal.Id);
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult Inquiryofelectricitybillsdebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showelectricitybillisnquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    data = new [] { new { bill_id = "" }, new { bill_id = "" } }
                };

            var response =
                await client.PostAsJsonAsync("vas/tavanir/bills/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Inquiryofgasbilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showgasbillinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new { customer_id = vg.Gaz };
            var response = await client.PostAsJsonAsync("vas/gas/bills", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb =
                        new Tbl_Request {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 200,
                            Titel_Request = "گاز",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id = vg.Gaz,
                            Pay_Id = vg.pay_id
                        };
                    db.Tbl_Requests.Add (tb);
                    db.SaveChanges();
                    var qfinal =
                        db
                            .Tbl_Requests
                            .Where(a => a.UserName == User.Identity.GetId())
                            .OrderByDescending(a => a.Id)
                            .Take(1)
                            .SingleOrDefault();
                    proccess(200, qfinal.Id);
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult Inquiryofgasbillsdebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showgasbillsinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    data =
                        new []
                        { new { customer_id = "" }, new { customer_id = "" } }
                };
            var response =
                await client.PostAsJsonAsync("vas/gas/bills/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Inquiryoftelephonebilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showphonebilldebtinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                phone = vg.Phone,
                midterm = false
            };
            var response = await client.PostAsJsonAsync("vas/phone/bills", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "استعلام",
                        Amount = 200,
                        Titel_Request = "تلفن ثابت",
                        Date_Request = DateTime.UtcNow,
                        Bill_Id = vg.Phone,
                        Pay_Id = vg.pay_id,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(200, qfinal.Id);
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult Inquiryoftelephonesbilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showphonebillsdebtinquiry()
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    data = new [] { new { phone = "" }, new { phone = "" } }
                };
            var response =
                await client.PostAsJsonAsync("vas/phone/bills/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Inquiryofmobilephonebilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showmobileinvoicedebtinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                mobile = vg.Mobile,
                midterm = false
            };
            var response = await client.PostAsJsonAsync("vas/mobile/bills", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "استعلام",
                        Amount = 200,
                        Titel_Request = "تلفن همراه",
                        Date_Request = DateTime.UtcNow,
                        Bill_Id = vg.Mobile,
                        Pay_Id = vg.pay_id,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(200, qfinal.Id);
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            return View();
        }

        public IActionResult Inquiryofmobilephonesbilldebt()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Showmobilesinvoicedebtinquiry(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data =
                new {
                    data = new [] { new { mobile = "" }, new { mobile = "" } }
                };
            var response =
                await client.PostAsJsonAsync("vas/mobile/bills/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Violationofcarsandmotorcycles()
        {
            Diposit();
            return View();
        }

        // public async Task<IActionResult> Showcarandmotorcycleinfringementdebtinquiries(Vm_Gabz vg)
        // {
        //     var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
        //     var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
        //     client.DefaultRequestHeaders.AcceptLanguage.Clear();
        //     client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
        //     client.DefaultRequestHeaders.Add("App-Key", "13075");
        //     client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
        //     client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
        //     client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
        //     client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
        //     client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
        //     var data = new
        //     {
        //         barcode = vg.Violation
        //     };
        //     var response = await client.PostAsJsonAsync("vas/rahvar/fines", data);
        //     if (response.IsSuccessStatusCode == true)
        //     {
        //         if (HttpContext.Session.GetInt32("sum") >= 600)
        //         {
        //             Tbl_Request tb = new Tbl_Request
        //             {
        //                 UserName = User.Identity.GetId(),
        //                 Type_Request = "استعلام",
        //                 Amount = 600,
        //                 Titel_Request = "خلافی خودرو و موتور",
        //                 Date_Request = DateTime.UtcNow,
        //                 Bill_Id = vg.Violation,
        //                 Pay_Id = vg.pay_id,
        //             };
        //             db.Tbl_Requests.Add(tb);
        //             db.SaveChanges();
        //             var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
        //             proccess(600, qfinal.Id);
        //             ViewBag.result = await response.Content.ReadAsStringAsync();
        //         }
        //         else
        //         {
        //             ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
        //         }
        //     }
        //     else
        //     {
        //         ViewBag.result = await response.Content.ReadAsStringAsync();
        //     }
        //     Diposit();
        //     return View();
        // }
        public async Task<IActionResult>
        Showcarandmotorcycleinfringementdebtinquiries(Vm_Gabz vg)
        {
            var baseAddress =
                new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13457");
            client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new { barcode = vg.Violation };
            var response =
                await client.PostAsJsonAsync("vas/rahvar/fines", data);
            if (response.IsSuccessStatusCode == true)
            {
                Tbl_Request tb =
                    new Tbl_Request {
                        UserName = User.Identity.GetId(),
                        Type_Request = "استعلام",
                        Amount = 600,
                        Titel_Request = "خلافی خودرو و موتور",
                        Date_Request = DateTime.UtcNow,
                        Bill_Id = vg.Violation,
                        Pay_Id = vg.pay_id
                    };
                db.Tbl_Requests.Add (tb);
                db.SaveChanges();
                var qfinal =
                    db
                        .Tbl_Requests
                        .Where(a => a.UserName == User.Identity.GetId())
                        .OrderByDescending(a => a.Id)
                        .Take(1)
                        .SingleOrDefault();
                proccess(600, qfinal.Id);
            }
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        public IActionResult Violationsofcarsandmotorcycles()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult>
        Showcarsandmotorcyclesinfringementdebtinquiries(Vm_Gabz vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client =
                new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client
                .DefaultRequestHeaders
                .AcceptLanguage
                .Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client
                .DefaultRequestHeaders
                .Add("Token-Id",
                "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new { data = new [] { new { barcode = "" } } };

            var response =
                await client.PostAsJsonAsync("vas/rahvar/fines/batch", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }

        //.....................................shahrdari
        public IActionResult Trafficplanentrylist()
        {
            Diposit();
            return View();
        }

        public IActionResult Paymentoftrafficplantolls()
        {
            Diposit();
            return View();
        }

        public IActionResult Inquiryforpaymentoftrafficplantolls()
        {
            Diposit();
            return View();
        }

        public IActionResult Toilets()
        {
            Diposit();
            return View();
        }

        public new IActionResult List()
        {
            ViewBag.List =
                db
                    .Tbl_PayBills
                    .Where(a => a.User == User.Identity.GetId())
                    .ToList();
            return View();
        }

        ///            فینوتک استعلام قبض ساده
        public IActionResult EstelamGabz (Vm_Gabz vg)
        {
            if( HttpContext.Session.GetInt32("sum") >= 200 )
            {
                var token = db.Tbl_TokenValues.SingleOrDefault().Token;
                var client =
                    new RestClient("https://apibeta.finnotech.ir/billing/v2/clients/nikatak5250/billingInquiry?type=" +
                        vg.type +
                        "&parameter=" +
                        vg.parameter +
                        "");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer" + " " + token);
                request
                    .AddHeader("Cookie",
                    "boomrangid=s%3AIOfSJfSbIxcw14Jd40NLBjAq7TGq4Ihw.aMuKwHA0nMwsWPRRdGK2B%2Fp94krLpfwdtSYPDsYg3Os");
                IRestResponse response = client.Execute(request);
                var EstelamGabz =
                    JsonConvert
                        .DeserializeObject<RootEstelamGabz>(response.Content);
                if (EstelamGabz.Status == "DONE")
                {
                    var result = EstelamGabz.ResultEstelamGabz;
                    ViewBag.Amount = result.Amount;
                    ViewBag.BillId = result.BillId;
                    ViewBag.PayId = result.PayId;
                    ViewBag.Date = result.Date;
                    ViewBag.Title = vg.type;
                }
                return View();
            }
            else
            {
                ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                return View();
            }
        }

        //-----------------کلاس دیسریالایز استعلام قبض فینوتک ساده

        public class ResultEstelamGabz
        {
            [JsonProperty("Amount")]
            public string Amount { get; set; }

            [JsonProperty("BillId")]
            public string BillId { get; set; }

            [JsonProperty("PayId")]
            public string PayId { get; set; }

            [JsonProperty("Date")]
            public string Date { get; set; }
        }

        public class RootEstelamGabz
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultEstelamGabz ResultEstelamGabz { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
    }
}
