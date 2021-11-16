using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Request;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using ViewModels.AdminViewModel.Sepordeh;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SepordehController : BaseController
    {
        public SepordehController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index()
        {
            Diposit();
            return View();
        }
        //--------------------------------------Token
        public string Token()
        {
            var client = new RestClient("https://oauth.sandbox.faraboom.co/oauth/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept-Language", "fa");
            request.AddHeader("App-Key", "13075");
            request.AddHeader("Device-Id", "185.159.152.2");
            request.AddHeader("Bank-Id", "BEGNIR ");
            request.AddHeader("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            request.AddHeader("CLIENT-DEVICE-ID", "127.0.0.1");
            request.AddHeader("CLIENT-IP-ADDRESS", "127.0.0.1");
            request.AddHeader("CLIENT-USER-AGENT", "127.0.0.1");
            request.AddHeader("CLIENT-USER-ID", "09121234567");
            request.AddHeader("CLIENT-PLATFORM-TYPE", "WEB");
            request.AddHeader("Authorization", "Basic MTM0NTc6RDVWTFF5VjB6Mlc4WkM1UkpEUzZTN24zRXREdFp1aTg4WExja0xWZmR3WQ==");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", "ali.rafiee");
            request.AddParameter("password", "123456789");
            request.AddParameter("grant_type", "password");
            var response = client.Execute(request);
            var token = response.Content.Split(", ");
            var token1 = token[0].Split(":");
            var token2 = token1[1].Split(",");
            string token3 = token2[0].Replace("/", "").Replace("\"", "");
            Diposit();
            return token3;
        }
        ///دریافت اطلاعات نام مشتری
        public async Task<IActionResult> Showrinfo()
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Access Token");
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var response = await client.GetAsync("accounts?has_address=******&length=******&offset=******");
            var result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }
        public IActionResult Rinfo()
        {
            Diposit();
            return View();
        }
        //دریافت توکن
        // public string token()
        // {
        //     var client = new RestClient("https://oauth.sandbox.faraboom.co/oauth/token");
        //     client.Timeout = -1;
        //     var request = new RestRequest(Method.POST);
        //     request.AddHeader("Accept-Language", "fa");
        //     request.AddHeader("App-Key", "13075");
        //     request.AddHeader("Device-Id", "185.159.152.2");
        //     request.AddHeader("Bank-Id", "BEGNIR ");
        //     request.AddHeader("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
        //     request.AddHeader("CLIENT-DEVICE-ID", "127.0.0.1");
        //     request.AddHeader("CLIENT-IP-ADDRESS", "127.0.0.1");
        //     request.AddHeader("CLIENT-USER-AGENT", "127.0.0.1");
        //     request.AddHeader("CLIENT-USER-ID", "09121234567");
        //     request.AddHeader("CLIENT-PLATFORM-TYPE", "WEB");
        //     request.AddHeader("Authorization", "Basic MTM0NTc6RDVWTFF5VjB6Mlc4WkM1UkpEUzZTN24zRXREdFp1aTg4WExja0xWZmR3WQ==");
        //     request.AlwaysMultipartFormData = true;
        //     request.AddParameter("username", "ali.rafiee");
        //     request.AddParameter("password", "123456789");
        //     request.AddParameter("grant_type", "password");
        //     var response = client.Execute(request);
        //     var token = response.Content.Split(", ");
        //     var token1 = token[0].Split(":");
        //     var token2 = token1[1].Split(",");
        //     string token3 = token2[0].Replace("/", "").Replace("\"", "");
        //     return token3;
        // }
        ///دریافت لیست سپرده ها
        public IActionResult Rlist()
        {
            Diposit();
            return View();
        }
        ///دریافت جزییات سپرده
        public IActionResult Rdetails()
        {
            Diposit();
            return View();
        }
        ///دریافت صورت حساب
        public IActionResult RBills()
        {
            Diposit();
            return View();
        }
        ///دریافت نام صاحب سپرده

        public IActionResult Rname()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowRname()
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token());
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var response = await client.GetAsync("deposits/0203343021002/holder");
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 200)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "خدمات بانکی",
                        Bill_Id = "",
                        Pay_Id = "",
                        Amount = 200,
                        Titel_Request = "دریافت اطلاعات  نام مشتری",
                        Date_Request = DateTime.UtcNow,
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
        ///نرخ سود سپرده
        public IActionResult Rate()
        {
            Diposit();
            return View();
        }
        ///تبدیل شماره سپرده به شبا
        public IActionResult Convert()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowConvert(Vm_Sepordeh vs)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var response = await client.GetAsync("deposits/" + vs.deposit_number + "/iban");
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 600)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "خدمات بانکی",
                        Bill_Id = "",
                        Pay_Id = "",
                        Amount = 600,
                        Titel_Request = "تبدیل شماره سپرده به شبا",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(600, qfinal.Id);
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
        ///تبدیل شماره شبا به سپرده 
        public IActionResult ReConvert()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowReConvert(Vm_Sepordeh vs)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var response = await client.GetAsync("ibans/" + vs.Shaba);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 600)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "خدمات بانکی",
                        Bill_Id = "",
                        Pay_Id = "",
                        Amount = 600,
                        Titel_Request = "تبدیل شماره شبا به سپرده",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(600, qfinal.Id);
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
        ///افتتاح سپرده
        public IActionResult Openaccount()
        {
            Diposit();
            return View();
        }

        ///انطباق کد ملی و حساب,شبا

        public IActionResult NationalCode()
        {
            Diposit();
            return View();
        }

        ///نمایش انطباق کد ملی وحساب,شبا
        public async Task<IActionResult> ShowNationalCode(Vm_Sepordeh vg)
        {
            var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                national_code = vg.national_code,
                account = vg.account
            };
            var response = await client.PostAsJsonAsync("deposits/account/national-code", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 600)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "خدمات بانکی",
                        Bill_Id = "",
                        Pay_Id = "",
                        Amount = 600,
                        Titel_Request = "انطباق کد ملی و حساب/شبا",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(600, qfinal.Id);
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
        ///مسدودی سپرده وکالتی
        public IActionResult Blocked()
        {

            Diposit();
            return View();
        }

        ///رفع مسدودی سپرده وکالتی

        public IActionResult EBlocked()
        {

            Diposit();
            return View();
        }

        ///انتقال مبلغ مسدودی وکالتی

        public IActionResult TransferB()
        {

            Diposit();
            return View();
        }

        ///سرویس افزایش مبلغ مسدودی وکالتی

        public IActionResult Afzayesh()
        {

            Diposit();
            return View();
        }

        ///سرویس گزارش مسدودی های وکالتی
        public IActionResult Gozaresh()
        {

            Diposit();
            return View();
        }

        /// ثبت قرارداد مشتری وکالتی

        public IActionResult Sabtgarardad()
        {

            Diposit();
            return View();
        }

        ///انتساب مشتری به کسب و کار
        public IActionResult Emoshtari()
        {

            Diposit();
            return View();
        }

        ///انتساب سپرده وکالتی

        public IActionResult Esepordeh()
        {

            Diposit();
            return View();
        }

        ///گزارش سپرده های در اختیار وکالتی

        public IActionResult Gsepordeh()
        {

            Diposit();
            return View();
        }

        ///فعال سازی سپرده وکالتی در اختیار
        public IActionResult Activation()
        {

            Diposit();
            return View();
        }
        ///انتقال وجه وکالتی

        public IActionResult Evekalati()
        {

            Diposit();
            return View();
        }

        /// فهرست انواع سپرده های قابل افتتاح

        public IActionResult Contents()
        {

            Diposit();
            return View();
        }

        ///انتقال وجه تجمیعی

        public IActionResult Tajmie()
        {

            Diposit();
            return View();
        }

        ///خلاصه صورتحساب روزانه سپرده

        public IActionResult Summary()
        {

            Diposit();
            return View();
        }

        public async Task<IActionResult> ShowSummary(Vm_ShowSummary vg)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token());
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                deposit_number = 0203343021002,
                order = "DESC",
                from_date = "",
                to_date = ""
            };
            var response = await client.PostAsJsonAsync("deposits{deposit-number}/statements/summery", data);
            if (response.IsSuccessStatusCode == true)
            {
                Tbl_Request tb = new Tbl_Request
                {
                    UserName = User.Identity.GetId(),
                    Type_Request = "خدمات بانکی",
                    Bill_Id = "",
                    Pay_Id = "",
                    Amount = 1500,
                    Titel_Request = "خلاصه صورتحساب روزانه سپرده",
                    Date_Request = DateTime.UtcNow,
                };
                db.Tbl_Requests.Add(tb);
                db.SaveChanges();
                var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                proccess(1500, qfinal.Id);
            }
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }
        ///دریافت صورتحساب های پرونده اعتباری
        public IActionResult Parvandeh()
        {
            Diposit();
            return View();
        }
        /// فهرست پرونده های اعتباری
        public IActionResult Etebari()
        {

            Diposit();
            return View();
        }
        public IActionResult PardakhtEtebari()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowPardakhtEtebari(Vm_Sepordeh vs)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Access Token");
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                customer_number = vs.customer_number,
                dossier_number = vs.dossier_number,
                amount = vs.amount,
                deposit_number = vs.deposit_number,
                full_settlement = false,
                paid_from_automatic_deposit = false
            };
            var response = await client.PostAsJsonAsync("credits/payments", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            Diposit();
            return View();
        }
    }
}