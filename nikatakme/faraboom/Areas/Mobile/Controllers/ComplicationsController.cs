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
namespace Mobile.Controllers
{
    [Area("Mobile")]
    [Authorize]
    public class ComplicationsController : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public ComplicationsController(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;

        }


        public IActionResult index()
        {
            return View();
        }
        //بدهی کلی عوارض آزادراه
        public IActionResult Totaldebt()
        {
            return View();
        }
        //جزئیات بدهی عوارض آزادراه
        public IActionResult Detail()
        {
            return View();
        }
        //پرداخت گروهی عوارض آزادراه
        public IActionResult Grouppayment()
        {
            return View();
        }
        //پرداخت عوارض آزادراه
        public IActionResult Payment()
        {
            return View();
        }
        //استعلام پرداخت عوارض آزادراه
        public IActionResult Inquiry()
        {
            return View();
        }


    }
}