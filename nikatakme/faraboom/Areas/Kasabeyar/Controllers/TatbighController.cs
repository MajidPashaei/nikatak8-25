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

namespace Kasabeyar.Controllers
{
    [Area("Kasabeyar")]
    [Authorize]
    public class TatbighController : BaseController
    {
        public TatbighController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index()
        {
            Diposit();
            return View();
        }
    
        ///تطبیق کدملی و شماره تلفن همراه
        public IActionResult Tatbig()
        {
            Diposit();
            return View();
        }
        public async Task<IActionResult> ShowTatbig(Vm_Omomi vo)
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