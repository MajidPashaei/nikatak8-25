using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Extensions;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Order;

namespace faraboom.Areas.Adminsite.Controllers {
    [Area ("Admin")]
    public class OrderController : BaseController {
        public OrderController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) { }
        public IActionResult Index () {
            if (eror != null)
            {
                ViewBag.er=eror;
                eror=null;
            }





            List<Vm_Order> or = new List<Vm_Order> ();
            var qorder = db.Tbl_Order.Where (a => a.State == "save").OrderByDescending (a => a.Id).ToList ();
            if (qorder != null) {
                foreach (var item in qorder) {
                    var qf = db.Tbl_Factors.Where (a => a.Id_Order == item.Id).ToList ();
                     var user=db.Tbl_User.Where(a=>a.Id==item.Id_user).SingleOrDefault();
                    int sum = 0;
                    if (qf.Count () != 0) {
                        foreach (var item1 in qf) {
                            sum = sum + item1.Total_sum;
                        }
                    }

                    Vm_Order q = new Vm_Order () {
                        Id = item.Id,
                        datesave = item.Date_Order.ToPersianDateString (),
                        Total = sum,
                        Pay = item.Pay,
                        UserName=user.UserNameUs,
                        phone=user.PhoneUs
                    };
                    or.Add (q);

                }
                ViewBag.listp = or.OrderByDescending (a => a.Id).ToList ();

            }
            return View();
        }
        public IActionResult ongoing () {
            return View ();
        }
        public IActionResult sender () {
            
            List<Vm_Order> or = new List<Vm_Order> ();
            var qorder = db.Tbl_Order.Where (a => a.State == "send").OrderByDescending (a => a.Id).ToList ();
            if (qorder != null) {
                foreach (var item in qorder) {
                    var qf = db.Tbl_Factors.Where (a => a.Id_Order == item.Id).ToList ();
                     var user=db.Tbl_User.Where(a=>a.Id==item.Id_user).SingleOrDefault();
                    int sum = 0;
                    if (qf.Count () != 0) {
                        foreach (var item1 in qf) {
                            sum = sum + item1.Total_sum;
                        }
                    }

                    Vm_Order q = new Vm_Order () {
                        Id = item.Id,
                        datesave = item.Date_Order.ToPersianDateString (),
                        Total = sum,
                        Pay = item.Pay,
                        UserName=user.UserNameUs,
                        phone=user.PhoneUs
                    };
                    or.Add (q);

                }
                ViewBag.listp = or.OrderByDescending (a => a.Id).ToList ();

            }
            return View();
        }

          public IActionResult show(int id)
        {
         
            var qorder = db.Tbl_Order.Where (a => a.Id==id).SingleOrDefault ();
            ViewBag.listp = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id).ToList ();
            int sum = 0;
            foreach (var item in ViewBag.listp) {
                sum = sum + item.Total_sum;
            }
            ViewBag.sum = sum;
            return View ();
        }

        public IActionResult del(int id)
        {
          //TODO: Implement Realistic Implementationvar
          var qorder = db.Tbl_Order.Where (a => a.Id==id).SingleOrDefault ();
          db.Tbl_Order.Remove(qorder);
          db.SaveChanges();
          eror="سفارش با موفقیت حذف شد";

          return RedirectToAction("index");
        }

         public IActionResult send(int id)
        {
          //TODO: Implement Realistic Implementationvar
          var qorder = db.Tbl_Order.Where (a => a.Id==id).SingleOrDefault ();
          qorder.State="send";
          db.Tbl_Order.Update(qorder);
          db.SaveChanges();
          eror="سفارش با موفقیت ارسال شد";

          return RedirectToAction("index");
        }

    }
}