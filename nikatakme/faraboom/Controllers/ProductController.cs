using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Extensions;
using faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Comment;
using ViewModels.AdminViewModel.Product;

namespace faraboom.Controllers {
    public class ProductController : BaseController {
        ////////////////////////////////////////////////////type db
       public ProductController(ContextHampadco _db, IWebHostEnvironment env):base(_db,env)
        {
            
        }

        //////////////////////////////////////////////////////////
        public IActionResult Index (int id) {
             setdata();
            ////////////////////////////////////////////////////////////////////////////////////////////////address
            var product = db.Tbl_Product.Where (a => a.Language == ln && a.CategoryIdPro == id.ToString ()).OrderByDescending (a => a.Id).ToList ();
            if (product != null) {
                ViewBag.product = product;

            } else {
                ViewBag.product = null;
            }
            return View ();
        }

        public IActionResult details (int id) {
             /////////////////////////////////////////////////////////////////////////////////////////comment
            var qcomit=db.Tbl_Comments.Where(a=>a.product_id==id && a.State==true).ToList();
            
            List<Vm_Comment> com=new  List<Vm_Comment>();
            foreach (var item in qcomit)
            {
                var name=db.Tbl_User.Where(a=>a.Id==Convert.ToInt32(item.User_Id) ).SingleOrDefault();
                Vm_Comment comm=new Vm_Comment()
            {
                username=name.UserNameUs,
                dateshamsi=item.DateComment.ToPersianDateString(),
                Comment=item.Comment,
                image=name.ProfileImageUs

            };
            com.Add(comm);
            }
            ViewBag.comments=com.OrderByDescending(a=>a.Id).ToList();
            /////////////////////////////////////////////////////////////////////////////////////////////////////// 

            //////////////////////////////////////////////////////////////////////////////////list
            var qproduct = db.Tbl_Product.Where (a => a.Id == id).SingleOrDefault ();
            if (qproduct != null) {
                var qgallery = db.tb_GalleryProducts.Where (a => a.IdProduct == id).ToList ();
                ViewBag.baner = qgallery.OrderByDescending (a => a.Id).ToList ();
                List<string> h = new List<string> ();
                foreach (var item in qgallery) {

                    h.Add (item.ImagePath);
                }
                Vm_Product qp = new Vm_Product () {
                    Id = qproduct.Id,
                    TitleProductPro = qproduct.TitleProductPro,
                    ImageMainPro = qproduct.ImageMainPro,
                    CategoryIdPro = qproduct.CategoryIdPro,
                    PricePro = qproduct.PricePro,
                    OfferPro = qproduct.OfferPro,
                    SizePro = qproduct.SizePro,
                    ColorPro = qproduct.ColorPro,
                    BrandPro = qproduct.BrandPro,
                    TypeCarPro = qproduct.TypeCarPro,
                    MaterialPro = qproduct.MaterialPro,
                    TotalPro = qproduct.TotalPro,
                    DescreptionPro = qproduct.DescreptionPro,
                    Language = qproduct.Language,

                };
                ViewBag.img = h;
                return View (qp);
            } else {

                return RedirectToAction ("index", "home");
            }

        }

    }
}