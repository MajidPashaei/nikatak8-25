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
using ViewModels.AdminViewModel.Wallet;
using Extensions;
using faraboom.Areas.Adminsite.Controllers;
using ViewModels.AdminViewModel.Request;
using ViewModels.AdminViewModel.Wallet;
using DataLayer.AdminEntities.wallet;

namespace Adminsite.Controllers
{
    public class WalletController : BaseController
    {
        public static string msg ;
        public WalletController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index()
        {
            List<Vm_Pay> A = new List<Vm_Pay>();
            var a = db.Tbl_pays.Where(a => a.status == true).OrderByDescending(a => a.Id).ToList();
            foreach (var item in a)
            {
                Vm_Pay B = new Vm_Pay()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Pay = item.Pay,
                    Harvest = item.Harvest,
                    DateTime = item.DateTime.ToPersianDateString(),
                    status = item.status,
                    RequestId = item.RequestId,
                };
                A.Add(B);
            }
            ViewBag.list2 = A.OrderByDescending(a => a.Id);
            return View();
        }

        public IActionResult Wallet()
        {
            if ( msg != null)
            {
                ViewBag.msg = msg ;
                msg = null ;
            };
            return View();
        }

        public IActionResult AddWallet( Vm_Pay vp )
        {
            Tbl_pay tp = new Tbl_pay()
            {
                UserName = vp.UserName ,
                Pay = vp.Pay ,
                Harvest = 0 ,
                DateTime = DateTime.Now ,
                status = true ,
                RequestId = 0 ,
            };
            db.Tbl_pays.Add(tp);
            db.SaveChanges();
            msg = " پرداخت با موفقیت انجام شد . " ;
            return RedirectToAction("Wallet");
        }

        public IActionResult HesabMan()
        {
            if ( msg != null)
            {
                ViewBag.msg = msg ;
                msg = null ;
            };
            return View();
        }

        public IActionResult AddHesabMan( Vm_Mypay vmp )
        {
            Tbl_Mypay tmp = new Tbl_Mypay()
            {
                UserName = vmp.UserName ,
                Pay = vmp.Pay ,
                Harvest = 0 ,
                DateTime = DateTime.Now ,
                status = true ,
                RequestId = 0 ,
            };
            db.Tbl_Mypays.Add(tmp);
            db.SaveChanges();
            msg = " پرداخت با موفقیت انجام شد . " ;
            return RedirectToAction("HesabMan");
        }
        
    }
}