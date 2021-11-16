using System.Net.Http;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.mobiledb;
using DataLayer.AdminEntities.mobiledb;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using ViewModels.AdminViewModel.User;
using ViewModels.AdminViewModel.User;
using faraboom.Models;
using System.IO;


namespace Mobile.Controllers
{
    [Area("Mobile")]
    [Authorize]
    public class MenuController : BaseController
    {
        public static string

                NewFileName,
                msg,
                mobile;

        public MenuController(ContextHampadco _db, IWebHostEnvironment env) :
            base(_db, env)
        {
        }

        public IActionResult Index()
        {
            var token = db.Tbl_TokenValues.SingleOrDefault();
            if (token != null)
            {
                var Timer = DateTime.Today;
                if (token.LifeTime == Timer)
                {
                    var client =
                        new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request
                        .AddHeader("Authorization",
                        "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
                    request
                        .AddHeader("Cookie",
                        "boomrangid=s%3AU9An7QDHKh5XZfCqCT9EB2A4qV8CrlYH.vfyR%2FZUYgqXGY5lJVXTx09Fs2vamhGgaYW5MYHmaJqk");
                    var body =
                        "{" +
                        "\"grant_type\":\"refresh_token\"," +
                        "\"token_type\":\"CLIENT-CREDENTIAL\"," +
                        "\"refresh_token\":\"" +
                        token.Refresh +
                        "\"" +
                        "}";
                    request
                        .AddParameter("application/json",
                        body,
                        ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var value2 =
                        JsonConvert.DeserializeObject<Root>(response.Content);
                    var NewToken = value2.Result.Value;
                    var NewRefresh = value2.Result.RefreshToken;
                    var NewTime = token.LifeTime.AddDays(9);

                    token.Token = NewToken;
                    token.Refresh = NewRefresh;
                    token.LifeTime = NewTime;
                    db.Tbl_TokenValues.Update (token);
                    db.SaveChanges();
                }
            }

            ///         paygabz token
            var tokenpay = db.Tbl_TokenPayGabzValues.SingleOrDefault();
            if (tokenpay != null)
            {
                var Timer = DateTime.Today;
                if (tokenpay.LifeTime == Timer)
                {
                    var client =
                        new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    request
                        .AddHeader("Authorization",
                        "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
                    request
                        .AddHeader("Cookie",
                        "boomrangid=s%3AU9An7QDHKh5XZfCqCT9EB2A4qV8CrlYH.vfyR%2FZUYgqXGY5lJVXTx09Fs2vamhGgaYW5MYHmaJqk");
                    var body =
                        "{" +
                        "\"grant_type\":\"refresh_token\"," +
                        "\"bank\":\"062\"," +
                        "\"token_type\":\"CODE\"," +
                        "\"refresh_token\":\"" +
                        tokenpay.Refresh +
                        "\"" +
                        "}";
                    request
                        .AddParameter("application/json",
                        body,
                        ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    var value2 =
                        JsonConvert.DeserializeObject<Root>(response.Content);
                    var NewToken = value2.Result.Value;
                    var NewRefresh = value2.Result.RefreshToken;
                    var NewTime = token.LifeTime.AddDays(9);

                    tokenpay.Token = NewToken;
                    tokenpay.Refresh = NewRefresh;
                    tokenpay.LifeTime = NewTime;
                    db.Tbl_TokenPayGabzValues.Update (tokenpay);
                    db.SaveChanges();
                }
            }

            Diposit();
            return View();
        }

        //reslt
        public class Result
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("scopes")]
            public List<string> Scopes { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }

            [JsonProperty("creationDate")]
            public string CreationDate { get; set; }

            [JsonProperty("lifeTime")]
            public int LifeTime { get; set; }
        }

        public class Root
        {
            [JsonProperty("result")]
            public Result Result { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }

        public IActionResult Index2()
        {
            Diposit();
            return View();
        }

        public IActionResult SetProfile()
        {
            if (msg != null)
            {
                ViewBag.msg = msg;
                msg = null;
            }
            return View();
        }

        public async Task<IActionResult> AddProfile(Vm_User vu)
        {
            var tu = db.Tbl_Users.Where(a => a.Phone == User.Identity.GetId()).SingleOrDefault();
            if (tu.Name == null)
            {
                tu.Name = vu.Name;
                tu.Family = vu.Family;
                tu.CodeNational = vu.CodeNational;
                tu.CodeInvite = vu.CodeInvite;
                tu.Gmail = vu.Gmail;
                if (vu.img != null)
                {
                    string FileExtension1 = Path.GetExtension(vu.img.FileName);
                    NewFileName =String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                    var path = $"{_env.WebRootPath}\\FileUpload\\{NewFileName}";
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await vu.img.CopyToAsync(stream);
                    }
                    tu.Image = NewFileName;
                }
                db.Tbl_Users.Update (tu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                msg = " خطا در ثبت اطلاعات";
                return RedirectToAction("SetProfile");
            }
        }

        public async Task<IActionResult> profile (Vm_User vs)
        {
            var tu =
                db
                    .Tbl_Users
                    .Where(a => a.Phone == User.Identity.GetId())
                    .SingleOrDefault();
            List<Vm_User> lvu = new List<Vm_User>();
            Vm_User vu =
                new Vm_User()
                {
                    Name = tu.Name ,
                    Family = tu.Family ,
                    CodeNational = tu.CodeNational ,
                    CodeInvite = tu.CodeInvite ,
                    Gmail = tu.Gmail ,
                    Image = tu.Image ,
                };
                
                ViewBag.img = tu.Image ;
            lvu.Add(vu);
            ViewBag.pro = lvu;
            return View();
        }
        public async Task<IActionResult> EditProfile (Vm_User vs)
        {
            var tu =
                db
                    .Tbl_Users
                    .Where(a => a.Phone == User.Identity.GetId())
                    .SingleOrDefault();
            Vm_User vu =
                new Vm_User()
                {
                    Name = tu.Name ,
                    Family = tu.Family ,
                    CodeNational = tu.CodeNational ,
                    CodeInvite = tu.CodeInvite ,
                    Gmail = tu.Gmail ,
                    Image = tu.Image ,
                };
                
                ViewBag.img = tu.Image ;

            return View(vu);
        }
        
        public async Task<IActionResult> Edit_Profile(Vm_User vu)
        {
            var tu = db.Tbl_Users.Where(a => a.Phone == User.Identity.GetId()).SingleOrDefault();

            tu.Name = vu.Name;
            tu.Family = vu.Family;
            tu.CodeNational = vu.CodeNational;
            tu.CodeInvite = vu.CodeInvite;
            tu.Gmail = vu.Gmail;

            if (vu.img != null)
            {
                string FileExtension1 = Path.GetExtension(vu.img.FileName);
                NewFileName =String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\FileUpload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await vu.img.CopyToAsync(stream);
                }
                tu.Image = NewFileName;
            }

            db.Tbl_Users.Update(tu);
            db.SaveChanges();

            return RedirectToAction("profile");
        }
        

        public IActionResult exit()
        {
            HttpContext
                .SignOutAsync(CookieAuthenticationDefaults
                    .AuthenticationScheme);
            return RedirectToAction("logincode", "home");
        }

        public IActionResult add()
        {
            ViewBag.x = db.Tbl_Users.ToList();
            return View();
        }

        public IActionResult add2(Vm_User vm)
        {
            Tbl_User tx = new Tbl_User() { Name = vm.Name, Family = vm.Family };
            db.Tbl_Users.Add(tx);
            db.SaveChanges();
            return RedirectToAction("add");
        }

        public IActionResult davat()
        {
            var tu = db.Tbl_Users.Where(a => a.Phone == User.Identity.GetId()).SingleOrDefault();
            ViewBag.id = tu.Id ;
            // ViewBag.id
            return View();
        }
        
        public IActionResult points()
        {
            return View();
        }

        public IActionResult aboutus()
        {
            return View();
        }
        
        public IActionResult jashnvareh()
        {
            return View();
        }
        
        public IActionResult faq()
        {
            return View();
        }
        
    }
}
