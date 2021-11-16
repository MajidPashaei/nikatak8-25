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
using ViewModels.AdminViewModel.Voip;

namespace Adminsite.Controllers
{
    public class VoipController : BaseController
    {
        public VoipController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sabt()
        {
            var qnum = db.Tbl_VoipNumbers.ToList();
            ViewBag.num = qnum;
            return View();
        }

        public IActionResult Rezerve()
        {
            var qusernum = db.Tbl_VoipNumbers.Where( a => a.UserName != null && a.UserId != null ).ToList();
            List<Vm_VoipNumber> lvv = new List<Vm_VoipNumber>();
            foreach (var item in qusernum)
            {
                var quser = db.Tbl_VoipUsers.Where( a => a.Id.ToString() == item.UserId ).SingleOrDefault();
                Vm_VoipNumber vv = new Vm_VoipNumber()
                {
                    Name = quser.NameFamily ,
                    Number = item.Number ,
                    Ostan = item.Ostan ,
                    Type = item.Type ,
                    Price = item.Price ,
                    UserName = item.UserName ,
                    Date = item.DateRezerve.ToPersianDateString() ,
                };
                lvv.Add(vv);
            };
            ViewBag.user = lvv;
            return View();
        }

    }
}