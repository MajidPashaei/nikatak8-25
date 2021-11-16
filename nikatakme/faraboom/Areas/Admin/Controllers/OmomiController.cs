using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Request;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Omomi;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OmomiController : BaseController
    {
        public OmomiController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        ///دریافت لیست شعب بانک
        public IActionResult Shobe()
        {
            return View();
        }
        public async Task<IActionResult> ShowShobe(Vm_Omomi vo)
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Bank-Id", "Bank Id");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var response = await client.GetAsync("banks/" + vo.shobe + "/branches?length=******&offset=******&search=******");
            ViewBag.result = await response.Content.ReadAsStringAsync();

            return View();
        }
        ///   استعلام تراکنش
        public IActionResult Tarakonesh()
        {
            return View();
        }
        public async Task<IActionResult> ShowTarakonesh(Vm_Omomi vo)
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
            var response = await client.GetAsync("inquiry/{trace-date}/{inquiry/2020-10-12/123456}");
            ViewBag.result = await response.Content.ReadAsStringAsync();

            return View();
        }
        ///   استعلام شماره شبا
        public IActionResult Shaba()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ShowShaba()
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
            var response = await client.GetAsync("ach/iban/IR310120010000005675042482/info");
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 300)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "خدمات بانکی",
                        Bill_Id = "",
                        Pay_Id = "",
                        Amount = 300,
                        Titel_Request = "استعلام شماره شبا",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(300, qfinal.Id);
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
        ///تطبیق کدملی و شماره تلفن همراه
        public IActionResult Tatbigh()
        {
            return View();
        }
        public async Task<IActionResult> ShowTatbigh(Vm_Omomi vo)
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
                national_code = vo.national_code,
                mobile = vo.mobile
            };
            var response = await client.PostAsJsonAsync("mobile/national-code", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 550)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "سامانه شاهکار",
                        Bill_Id = vo.national_code,
                        Pay_Id = vo.mobile,
                        Amount = 550,
                        Titel_Request = "تطبیق کدملی و شماره تلفن همراه",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(550, qfinal.Id);
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
    }
}