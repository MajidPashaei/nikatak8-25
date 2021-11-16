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
    public class ChekController : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public ChekController(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;

        }


        public IActionResult index()
        {
            return View();
        }
        //لیست دسته چک های سپرده
        public IActionResult Chekofdeposit()
        {
            return View();
        }
        //لیست چکهای دسته چک
        public IActionResult Listofchek()
        {
            return View();
        }
        //لیست چک های واگذار شده
        public IActionResult Assignmentofchek()
        {
            return View();
        }
        //مسدود کردن برگه چک
        public IActionResult Blockchek()
        {
            return View();
        }
        //ثبت درخواست دسته چک
        public IActionResult Recordofchek()
        {
            return View();
        }


    }
}