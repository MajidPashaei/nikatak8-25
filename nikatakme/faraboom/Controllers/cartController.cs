using System;
namespace faraboom.Controllers {
    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.AdminEntities.Order;
    using DataLayer.AdminEntities.Product;
    using DataLayer.Context;
    using Extensions;
    using faraboom.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.AdminViewModel.Order;
    public class cartController : BaseController {

        public cartController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) {

        }
        public IActionResult Index () {
             setdata();

            return View ();
        }

        public int addcart (int id, int count) {
            var qproduct = db.Tbl_Product.Where (a => a.Id == id).SingleOrDefault ();
            var qorder = db.Tbl_Order.Where (a => a.Id_user == Convert.ToInt32 (User.Identity.GetId ()) && a.State == "record").SingleOrDefault ();
            if (qorder != null) {
                var qfact = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id && a.Product_Id == id).SingleOrDefault ();
                if (qfact == null) {
                    Tb_Factor fact = new Tb_Factor () {
                    Id_Order = qorder.Id,
                    Product_Id = id,
                    product_Name = qproduct.TitleProductPro,
                    Product_Count = count,
                    product_Price = Convert.ToInt32 (qproduct.PricePro),
                    Total_sum = count * Convert.ToInt32 (qproduct.PricePro)

                    };
                    db.Tbl_Factors.Add (fact);
                    db.SaveChanges ();

                } else {
                    var qproduct1 = db.Tbl_Product.Where (a => a.Id == id).SingleOrDefault ();
                    qfact.Product_Count = qfact.Product_Count + count;
                    qfact.product_Price = Convert.ToInt32 (qproduct.PricePro);
                    qfact.Total_sum = (qfact.Product_Count + count) * Convert.ToInt32 (qproduct.PricePro);
                    db.Tbl_Factors.Update (qfact);
                    db.SaveChanges ();
                }

            } else {
                Tb_Order ord = new Tb_Order () {
                    Id_user = Int32.Parse (User.Identity.GetId ()),
                    Date_Order = DateTime.UtcNow,
                    Pay = "0",
                    State = "record"

                };
                db.Tbl_Order.Add (ord);
                db.SaveChanges ();
                addcart (id, count);

            }
            var qf = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id).ToList ();
            if (qorder != null) {
                int sum = 0;
                if (qf.Count () != 0) {
                    foreach (var item in qf) {
                        sum = sum + item.Product_Count;
                    }
                    menu.order_count = sum;
                } else {
                    menu.order_count = 0;
                }

            }
            return menu.order_count;
        }
        public IActionResult Order () {
            if (eror != null) {
                ViewBag.er = eror;
                eror = null;
            }

            var qorder = db.Tbl_Order.Where (a => a.Id_user == Convert.ToInt32 (User.Identity.GetId ()) && a.State == "record").SingleOrDefault ();
            ViewBag.listp = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id).ToList ();
            int sum = 0;
            foreach (var item in ViewBag.listp) {
                sum = sum + item.Total_sum;
            }
            ViewBag.sum = sum;
            return View ();
        }

        public IActionResult del (int id) {
            //TODO: Implement Realistic Implementation
            var qd = db.Tbl_Factors.Where (a => a.Id == id).SingleOrDefault ();
            db.Tbl_Factors.Remove (qd);
            db.SaveChanges ();
            var qorder = db.Tbl_Order.Where (a => a.Id_user == Convert.ToInt32 (User.Identity.GetId ()) && a.State == "record").SingleOrDefault ();
            if (qorder != null) {
                var qf = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id).ToList ();
                if (qorder != null) {
                    int sum = 0;
                    if (qf.Count () != 0) {
                        foreach (var item in qf) {
                            sum = sum + item.Product_Count;
                        }
                        menu.order_count = sum;
                    } else {
                        menu.order_count = 0;
                    }

                }

            }

            eror = "حذف با موفقیت انجام شد";
            return RedirectToAction ("order");
        }

        public IActionResult list () {
            //TODO: Implement Realistic Implementation
            List<Vm_Order> or = new List<Vm_Order> ();
            var qorder = db.Tbl_Order.Where (a => a.Id_user == Convert.ToInt32 (User.Identity.GetId ()) && a.State == "save").OrderByDescending (a => a.Id).ToList ();
            if (qorder != null) {
                foreach (var item in qorder) {
                    var qf = db.Tbl_Factors.Where (a => a.Id_Order == item.Id).ToList ();

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
                    };
                    or.Add (q);

                }
                ViewBag.listp = or.OrderByDescending (a => a.Id).ToList ();

            }
            return View ();
        }

        public IActionResult saveorder () {
            //TODO: Implement Realistic Implementation
            var qorder = db.Tbl_Order.Where (a => a.Id_user == Convert.ToInt32 (User.Identity.GetId ()) && a.State == "record").SingleOrDefault ();
            ViewBag.listp = db.Tbl_Factors.Where (a => a.Id_Order == qorder.Id).ToList ();
            int sum = 0;
            foreach (var item in ViewBag.listp) {
                sum = sum + item.Total_sum;
            }
           int sumshop = sum;

            qorder.State = "save";
            qorder.Date_Order = DateTime.UtcNow;
           
            db.Tbl_Order.Update (qorder);
            db.SaveChanges ();
            menu.order_count = 0;

            return RedirectToAction ("list");

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

        public IActionResult rezerv(int id)
        {
            menu.idrezerv=id;
          //TODO: Implement Realistic Implementation
          return RedirectToAction("index","login");
        }




           
   

    }
}