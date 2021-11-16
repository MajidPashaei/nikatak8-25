using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Blog;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Originality;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.inforep;
using Microsoft.AspNetCore.Http;

namespace faraboom.Controllers {
    public class HomeController : BaseController {
        ////////////////////////////////////////////////////type db
        public HomeController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) {

        }

        //////////////////////////////////////////////////////////
        public IActionResult Index () {

            setdata ();
            ////////////////////////////////////////////////////////////////////////////////////////////////address
            var address = db.Tbl_Adress.Where (a => a.Language == ln).ToList ();
            if (address != null) {
                ViewBag.address = address;

            } else {
                ViewBag.address = null;
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////blog

            var blog = db.Tbl_Blog.Where (a => a.Language == ln).OrderByDescending (a => a.Id).Take (8).ToList ();
            if (blog != null) {
                ViewBag.blog = blog;
            }

            ///خدمات ما 
            var qcat = db.tbl_category.Where (a => a.NameCat == "خدمات ما")?.SingleOrDefault ();
            if (qcat != null) {
                var qbl = db.Tbl_Blog.Where (a => a.Language == ln).OrderByDescending (a => a.Id).ToList ();
                List<Tb_Blog> lb = new List<Tb_Blog> ();
                foreach (var item in qbl) {
                    if (item.IdCtegoryBlo == qcat.Id) {
                        lb.Add (item);
                    }
                }

                if (lb != null) {
                    ViewBag.khadamat = lb;
                }
            }
            ///خدمات ما 
            var qqcat = db.tbl_category.Where (a => a.NameCat == "سازمانها و مراکز طرف قرارداد")?.SingleOrDefault ();
            if (qcat != null) {
                var qbl = db.Tbl_Blog.Where (a => a.Language == ln).OrderByDescending (a => a.Id).ToList ();
                List<Tb_Blog> lb = new List<Tb_Blog> ();
                foreach (var item in qbl) {
                    if (item.IdCtegoryBlo == qqcat.Id) {
                        lb.Add (item);
                    }
                }

                if (lb != null) {
                    ViewBag.sazeman = lb;
                }
            }

            //////////////////////////////////////////////////////////////////slider
            var qslider = db.Tbl_Slider.Where (a => a.Language == ln).OrderByDescending (a => a.Id).ToList ();
            if (qslider != null) {
                ViewBag.slider = qslider;
            }
            //////////////////////////////////////////////////////////////////baner
            var qbaner = db.Tbl_Baner.Where (a => a.Language == ln).OrderByDescending (a => a.Id).ToList ();
            if (qbaner != null) {
                ViewBag.baner = qbaner;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////first_page
            var qfirst = db.tbl_category.Where (a => a.FatherIdCat == -3).ToList ();

            List<Tb_Blog> blg = new List<Tb_Blog> ();
            foreach (var item in qfirst) {
                var first = db.Tbl_Blog.Where (a => a.IdCtegoryBlo == item.Id && a.Language == ln).SingleOrDefault ();
                if (first != null) {
                    blg.Add (first);
                }

            }

            if (blg != null) {
                ViewBag.first = blg.OrderByDescending (a => a.Id).Take (2).ToList ();
            }

            ///////////////////////////////////////////////////////////////////////////////teaser
            ViewBag.Teaser = db.Tbl_Teaser.Where (a => a.Language == ln).OrderByDescending (a => a.Id).Take (3).ToList ();

            ViewBag.Amozesh = db.Tbl_Teaser.Where (a => a.Language == ln).OrderByDescending (a => a.Id).Take (3).ToList ();
            ////////////////////////////////////////////////////////////////////////////////product list
            ViewBag.product = db.Tbl_Product.Where (a => a.Language == ln).OrderByDescending (a => a.Id).Take (6).ToList ();
            //////////////////////////////////////////////////////////////////////////////////expert list
            ViewBag.expert = db.Tbl_Experts.Where (a => a.Language == ln).OrderByDescending (a => a.Id).ToList ();

         

            return View ();
        }

        public IActionResult exit () {
            HttpContext.SignOutAsync (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction ("index", "home");
        }

        public IActionResult orgincheck (string id) {
            setdata ();
            var orgin = db.Tbl_Originality.Where (a => a.HologramCodeOri == id).ToList ();
            if (orgin.Count () != 0) {
                ///////////////////////////////////////////////////////////list

                List<Vm_Originality> originality = new List<Vm_Originality> ();
                foreach (var item in orgin) {
                    var product = db.Tbl_Product.Where (a => a.Id == item.IdProductOri).SingleOrDefault ();
                    Vm_Originality origin = new Vm_Originality () {
                        Id = item.Id,
                        nameproduct = product.TitleProductPro,
                        HologramCodeOri = item.HologramCodeOri,
                        NumberProductOri = item.NumberProductOri,
                        Language = item.Language,
                        DateCreateOri = item.DateCreateOri,
                        img = product.ImageMainPro,
                        IdProductOri = product.Id
                    };
                    originality.Add (origin);

                }

                ViewBag.listp = originality.OrderByDescending (a => a.Id).ToList ();
                //////////////////////////////////////////////////////////
            } else {
                error = "چنین کد هولوگرامی در شرکت سون استار ثبت نشده است";
                return RedirectToAction ("orgin");
            }
            return View ();
        }

        [Authorize]
        public IActionResult orgin () {
            if (error != null) {
                ViewBag.e = error;
                error = null;
            }
            return View ();
        }

        public IActionResult khadamat () {
            var qcat = db.tbl_category.Where (a => a.NameCat == "خدمات ما")?.SingleOrDefault ();
            return RedirectToAction ("index", "blog", new { id = qcat.Id });
        }
        public IActionResult Faq () {
           return View();
        }

        public IActionResult info () {
            var qcat = db.tbl_category.Where (a => a.NameCat == "اطلاعیه های جدید")?.SingleOrDefault ();
            return RedirectToAction ("index", "blog", new { id = qcat.Id });
        }
        public IActionResult MapLogin () {

          

            return View ();
        }
        public IActionResult AboutUs () {
            var qcat = db.tbl_category.Where (a => a.NameCat == "درباره ما")?.SingleOrDefault ();
            var p = db.Tbl_Blog.Where (a => a.Language == ln && a.IdCtegoryBlo == qcat.Id).OrderByDescending (a => a.Id).FirstOrDefault ();
            return RedirectToAction ("details", "blog", new { id = p.Id });

            return View ();
        }
        
         public IActionResult job () {
          
             return View ();
         }
         public IActionResult gallery () {
          
             return View ();
         }
         public IActionResult moarefi () {
          
             return View ();
         }

          public IActionResult Amozesh () {
          
             return View ();
         }
        
        
         public IActionResult mozaeieh ()
          {
            var qcat = db.tbl_category.Where (a => a.NameCat == "مزایده و مناقصه")?.SingleOrDefault ();
            var p = db.Tbl_Blog.Where (a => a.IdCtegoryBlo == qcat.Id).OrderByDescending (a => a.Id).FirstOrDefault ();
            return RedirectToAction ("details", "blog", new { id = p.Id });

            return View ();
         }

         ///verify
         [Route("verify")]
        public IActionResult verify(string code)
        {
            var session=HttpContext.Session.GetString("Ret");
            if (session == null)
            {
               ViewBag.code=code;
               return View(); 
            }
            HttpContext.Session.SetString("CR",code);
            var ControlerName = HttpContext.Session.GetString("Ret");
            return RedirectToAction("Urlback",ControlerName, new {Area = "Admin"} );
        }
    }
}