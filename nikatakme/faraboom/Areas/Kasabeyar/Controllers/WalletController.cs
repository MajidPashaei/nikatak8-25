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
using ViewModels.AdminViewModel.Request;
using ViewModels.AdminViewModel.Wallet;
using DataLayer.AdminEntities.wallet;

namespace Kasabeyar.Controllers
{
    [Area("Kasabeyar")]
    [Authorize]

    public class WalletController : BaseController
    {
        public WalletController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {
        }
        public IActionResult Index()
        {
            List<Vm_Pay> A = new List<Vm_Pay>();
            var a = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId() && a.status == true && a.RequestId==0 ).OrderByDescending(a => a.Id).ToList();
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
            Diposit();
            return View();
        }
        public IActionResult Tarakonesh()
        {
           var t= db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(b => b.Id).ToList();
            List<Vm_Request>  requests=new List<Vm_Request>();
            foreach (var item in t)
            {
                Vm_Request request=new Vm_Request()
                {
                    Id=item.Id,
                    Id_User = item.UserName ,
                    Type_Request = item.Type_Request,
                    Bill_Id=item.Bill_Id,
                    Pay_Id=item.Pay_Id,
                    Amount = item.Amount,
                    Titel_Request = item.Titel_Request,
                    Date1 = item.Date_Request.ToPersianDateString()
                };
                requests.Add(request);
            }
            ViewBag.Tarakonesh=requests.OrderByDescending(a=>a.Id).ToList();
            var A = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).ToList();
            int P = 0;
            foreach (var item in A)
            {
                if (item.Amount != 0)
                {
                    P = item.Amount + P;
                }
            }
            ViewBag.Sum = P ;
            Diposit();
            return View();
        }
           public IActionResult Tarakoneshs()
        {
           List<Vm_Pay> A = new List<Vm_Pay>();
            var a = db.Tbl_Mypays.Where(a => a.UserName == User.Identity.GetId() && a.status == true).OrderByDescending(a => a.Id).ToList();
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

            // //////////////////////////////////////////////////////////////////// sum pays

            int P = 0;
            foreach (var item in a)
            {
                
                    P = item.Pay + P;
            }
            ViewBag.Sum = P ;



            Diposit();



            return View();
        }
        public IActionResult Detail(int id)
        {
            ViewBag.id = db.Tbl_Requests.Where(a => a.Id == id).ToList();
            Diposit();
            return View();
        }
    }
}