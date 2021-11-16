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
namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FolderworkController : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public FolderworkController(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;

        }


        public IActionResult index()
        {
            return View();
        }
        //نتقال وجه عادی کارتابلی
        public IActionResult Normaltransfer()
        {
            return View();
        }
        //انتقال وجه پایا کارتابلی
        public IActionResult Payatransfer()
        {
            return View();
        }
        //انتقال وجه ساتنا کارتابلی
        public IActionResult Satnatransfer()
        {
            return View();
        }
        //گزارش تاییدکنندگان بالقوه کارتابل
        public IActionResult Confirmationreport()
        {
            return View();
        }
        //افزودن تایید کننده/اجرا کننده به کارتابل
        public IActionResult Add()
        {
            return View();
        }
        //گزارش کارتابل کاربر
        public IActionResult Userreport()
        {
            return View();
        }
        //جزئیات کارتابل
        public IActionResult Detail()
        {
            return View();
        }
        //تایید/رد کارتابل توسط امضا دار
        public IActionResult Confirmrejection()
        {
            return View();
        }
        //اجرای کارتابل
        public IActionResult Run()
        {
            return View();
        }
        //حذف تایید کننده / اجرا کننده از کارتابل
        public IActionResult Delete()
        {
            return View();
        }
        //انتقال وجه پایا گروهی کارتابلی
        public IActionResult Payagrouptransfer()
        {
            return View();
        }
        //انتقال وجه داخلی گروهی کارتابلی
        public IActionResult Groupinternaltransfer()
        {
            return View();
        }
        //لغو کارتابل
        public IActionResult Cancel()
        {
            return View();
        }
        //ویرایش اطلاعات کارتابل
        public IActionResult Edit()
        {
            return View();
        }
    }
}