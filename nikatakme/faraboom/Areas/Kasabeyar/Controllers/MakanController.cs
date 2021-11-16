using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using ViewModels.AdminViewModel.Makanmehvar;

namespace Kasabeyar.Controllers
{   
    [Area("Kasabeyar")]
    [Authorize]

    public class MakanController : BaseController
    {
        public MakanController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index()
        {
            Diposit();
            return View();
        }
        ///   دریافت آدرس براساس کدپستی
        public IActionResult Address()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowAddress(Vm_Makanmehvar vm)
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
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09125000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                zip_code = vm.zip_code,
            };
            var response = await client.PostAsJsonAsync("gis/zipcodes/addresses", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 2500)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "مکان محور",
                        Bill_Id = vm.zip_code,
                        Pay_Id = vm.zip_code,
                        Amount = 2500,
                        Titel_Request = "دریافت آدرس",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(2500, qfinal.Id);
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
        ///    دریافت جزییات آدرس براساس کدپستی
        public IActionResult Details()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowDetails(Vm_Makanmehvar vm)
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
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09125000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                zip_code = vm.zip_code
            };
            var response = await client.PostAsJsonAsync("gis/zipcodes/addresses/details", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 2500)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "مکان محور",
                        Bill_Id = vm.zip_code,
                        Pay_Id = vm.zip_code,
                        Amount = 2500,
                        Titel_Request = "دریافت جرئیات آدرس",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(2500, qfinal.Id);
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
        ///     دریافت مشخصات جغرافیایی براساس کدپستی
        public IActionResult Geography()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowGeography(Vm_Makanmehvar vm)
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
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09125000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                zip_code = vm.zip_code
            };
            var response = await client.PostAsJsonAsync("gis/zipcodes/coordinates", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 2500)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "مکان محور",
                        Bill_Id = vm.zip_code,
                        Pay_Id = vm.zip_code,
                        Amount = 2500,
                        Titel_Request = "دریافت مشخصات جغرافیایی آدرس",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(2500, qfinal.Id);
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