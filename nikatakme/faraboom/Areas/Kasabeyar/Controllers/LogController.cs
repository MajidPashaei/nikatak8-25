using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLayer.AdminEntities.User;
using DataLayer.Context;
using faraboom.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using ViewModels.AdminViewModel.User;
using DataLayer.AdminEntities.Admin;
using DataLayer.AdminEntities.KasabeYar;
using ViewModels.AdminViewModel.KasabeYar;

namespace Kasabeyar.Controllers
{
    [Area("Kasabeyar")]
    
    public class LogController : Controller
    {
        public static string eror, massage, NewFileName;
        private readonly ContextHampadco db;
        private readonly IWebHostEnvironment _env;

        public LogController(ContextHampadco _db, IWebHostEnvironment env)
        {
            db = _db;
            _env = env;
        }

        public IActionResult Login()
        {

            if (eror != null)
            {
                ViewBag.eror = eror;
                eror = null;
            }

            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }

            return View();
        }

        public IActionResult login_check( Vm_LogKasabeYar vl )
        {
            var user = db.Tbl_KasabeYarUsers.Where(a => a.UserName == vl.User && a.Password == vl.Pass && a.state == true).SingleOrDefault();
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim (ClaimTypes.NameIdentifier, user.UserName),
                    new Claim (ClaimTypes.Name, user.UserName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                HttpContext.SignInAsync(principal, properties);
                HttpContext.Session.SetString("name", (user.Name + " " + user.Family));
                
                
                int pay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Pay);
                int harvest = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Harvest);
                HttpContext.Session.SetInt32("sum", (pay - harvest));

                return RedirectToAction("index", "menu", new { area = "Kasabeyar" });
            }
            else if (db.Tbl_KasabeYarUsers.Any(a => a.state == false))
            {
                eror = "حساب کاربری شما غیرفعال است.";
                return RedirectToAction("Login");
            }
            else
            {
                eror = "نام کاربری یا رمز عبور شما نادرست است";
                return RedirectToAction("Login");
            }

        }

    }
}
