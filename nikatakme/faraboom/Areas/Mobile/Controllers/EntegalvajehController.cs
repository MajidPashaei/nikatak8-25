using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Admin;
namespace Mobile.Controllers {
    [Area ("Mobile")]
    [Authorize]
    public class EntegalvajehController : Controller {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public EntegalvajehController (ContextHampadco _db, IHostingEnvironment env) {
            db = _db;
            _env = env;

        }

        public IActionResult Index () {
            return View ();
        }
        //دریافت مشخصات صاحب کارت
          public IActionResult Cardholderprofile () {
            return View ();
        }
        //انتقال وجه کارتی
          public IActionResult Moneytransfer () {
            return View ();
        }
        //فهرست کارت ها
          public IActionResult  Listofcards () {
            return View ();
        }
        //لیست تراکنش های کارت
          public IActionResult  Listoftransactions () {
            return View ();
        }
        //دریافت شماره شبا و مشخصات صاحب کارت
          public IActionResult Shabanumber () {
            return View ();
        }
        //دریافت صورتحساب کارت
          public IActionResult Bills () {
            return View ();
        }
        //خیریه

          public IActionResult Charity () {
            return View ();
        }
        //انتقال وجه مستمر بین بانکی پایا

          public IActionResult Continuousinterbank () {
            return View ();
        }
        //انتقال وجه بین بانکی پایا
          public IActionResult Paya () {
            return View ();
            
        }

      
        //انتقال وجه دسته ای بین بانکی پایا
          public IActionResult Category () {
            return View ();
            
        }

        
        //گزارش لیست انتقال وجه های بین بانکی پایا
          public IActionResult listPaya () {
            return View ();
        }
        //لغو انتقال وجه پایا
          public IActionResult Canceltransfer () {
            return View ();
        }
        //انتقال وجه بین بانکی ساتنا
             public IActionResult Satna () {
            return View ();
        }
        //گزارش انتقال وجه ساتنا
             public IActionResult SatnaReport () {
            return View ();
        }
        //انتقال وجه داخلی
              public IActionResult Internaltransfer () {
            return View ();
        }
        //انتقال وجه مستمر

              public IActionResult Continuoustransmission () {
            return View ();
        }
        //سرویس لیست انتقال وجه‌های مستمر
              public IActionResult Transferlist () {
            return View ();
        }
        //گزارش انتقال وجه های مستمر
              public IActionResult Continuousreporting () {
            return View ();
        }
        //لغو انتقال وجه مستمر

              public IActionResult Cancelmoneytransfer () {
            return View ();
        }
        //انتقال وجه دسته ای

              public IActionResult Batchmoneytransfer () {
            return View ();
        }
        //
        
    

     
        public IActionResult Exit () {

            HttpContext.SignOutAsync (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction ("index", "home");
        }

     

    

    }
}