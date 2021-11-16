using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Category;
using DataLayer.AdminEntities.Product;
using DataLayer.Context;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Product;

namespace faraboom.Areas.Adminsite.Controllers {
  
    public class ProductController : BaseController {
        public ProductController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index () {
            //////////////////////////////////////////////////////////////////////////////////list

            return View ();
        }
        // public IActionResult addproduct () {

        //     //////////////////////////////////////////////////////////////////////////////////list
        //     var qlist = db.tbl_category.Where (a => a.FatherIdCat == -1).ToList ();
        //     var listtb = new List<Tb_Category> ();

        //     if (qlist != null) {
        //         foreach (var item in qlist) {
        //             var qselect = db.tbl_category.Where (a => a.FatherIdCat == item.Id).ToList ();
        //             if (qselect.Count () != 0) {
        //                 foreach (var item1 in qselect) {
        //                 var b = new Tb_Category () {
        //                 Id = item1.Id,
        //                 NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
        //                 FatherIdCat = item1.FatherIdCat
        //                     };
        //                     listtb.Add (b);
        //                 }

        //             } else {
        //                 listtb.Add (item);
        //             }

        //         }
        //         ViewBag.list = new SelectList (listtb, "Id", "NameCat");
        //     } else {
        //         ViewBag.list = null;
        //     }

        //     //////////////////////////////////////////////////////////////////////////////////list
        //     if (err != null) {
        //         ViewBag.er = err;
        //         err = null;
        //     }
        //     return View ();
        // }

        // public IActionResult list () {
        //     if (err != null) {
        //         ViewBag.er = err;
        //         err = null;
        //     }

        //     var list = db.Tbl_Product.OrderByDescending (a => a.Id).ToList ();
        //     if (list.Count != 0 )
        //     {              
            
        //     List<Vm_Product> p = new List<Vm_Product> ();
        //     foreach (var item in list) {
        //         var qcat = db.tbl_category.Where (a => a.Id == Convert.ToInt32 (item.CategoryIdPro)).SingleOrDefault ();
        //         Vm_Product product = new Vm_Product () {
        //             Id = item.Id,
        //             TitleProductPro = item.TitleProductPro,
        //             catname = qcat.NameCat,
        //             ImageMainPro = item.ImageMainPro,
        //             PricePro = item.PricePro,
        //             Language = item.Language,
        //             OfferPro = item.OfferPro,

        //         };
        //         p.Add (product);

        //     }
        //     ViewBag.listp = p.OrderByDescending (a => a.Id).ToList ();
        //           }
        //     return View ();
        // }

        public async Task<IActionResult> add (Vm_Product pro) {
            ////////////////////////////////////////////////////////////////////////////start upload main imge
            if (pro.mainimg != null) {
                foreach (var item in pro.upload_imgs) {
                    ///////////////upload file
                    string FileExtension1 = Path.GetExtension (pro.mainimg.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                    var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path, FileMode.Create)) {

                        await pro.mainimg.CopyToAsync (stream);

                    }
                    //////////////////////////end upload file 
                }

            }

            //////////////////////////////////////////////////////////////////////////////////////end upload multi image

            Tb_Product p = new Tb_Product () {
                TitleProductPro = pro.TitleProductPro,
                CategoryIdPro = pro.CategoryIdPro,
                PricePro = pro.PricePro,
                OfferPro = pro.OfferPro,
                SizePro = pro.SizePro,
                ColorPro = pro.ColorPro,
                BrandPro = pro.BrandPro,
                TypeCarPro = pro.TypeCarPro,
                MaterialPro = pro.MaterialPro,
                TotalPro = pro.TotalPro,
                DescreptionPro = pro.DescreptionPro,
                Language = pro.Language,
                ImageMainPro = NewFileName
            };

            db.Tbl_Product.Add (p);
            db.SaveChanges ();
            var q = db.Tbl_Product.OrderByDescending (a => a.Id).Take (1).SingleOrDefault ();
            ////////////////////////////////////////////////////////upload multi image
            if (pro.upload_imgs != null) {
                foreach (var item in pro.upload_imgs) {
                    ///////////////upload file
                    string FileExtension1 = Path.GetExtension (item.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                    var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path, FileMode.Create)) {

                        await item.CopyToAsync (stream);

                    }
                    Tb_GalleryProduct g = new Tb_GalleryProduct () {
                        Language = pro.Language,
                        ImagePath = NewFileName,
                        IdProduct = q.Id
                    };
                    db.tb_GalleryProducts.Add (g);
                    db.SaveChanges ();

                    //////////////////////////end upload file 
                }

            }
            err = "اطلاعات با موفقیت ثبت شد";
            //////////////////////////////////////////////////////////////////////////////////////end upload multi image
            return RedirectToAction ("addproduct");
        }

        // public IActionResult del (int id) {
        //     var q = db.Tbl_Product.Where (a => a.Id == id).SingleOrDefault ();
        //     db.Tbl_Product.Remove (q);
        //     db.SaveChanges ();
        //     err = "اطلاعات با موفقیت حذف شد";
        //     return RedirectToAction ("list");
        // }

        // public IActionResult update (int id) {

        //        //////////////////////////////////////////////////////////////////////////////////list
        //     var qlist = db.tbl_category.Where (a => a.FatherIdCat == -1).ToList ();
        //     var listtb = new List<Tb_Category> ();

        //     if (qlist != null) {
        //         foreach (var item in qlist) {
        //             var qselect = db.tbl_category.Where (a => a.FatherIdCat == item.Id).ToList ();
        //             if (qselect.Count () != 0) {
        //                 foreach (var item1 in qselect) {
        //                 var b = new Tb_Category () {
        //                 Id = item1.Id,
        //                 NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
        //                 FatherIdCat = item1.FatherIdCat
        //                     };
        //                     listtb.Add (b);
        //                 }

        //             } else {
        //                 listtb.Add (item);
        //             }

        //         }
        //         ViewBag.list = new SelectList (listtb, "Id", "NameCat");
        //     } else {
        //         ViewBag.list = null;
        //     }

        //     //////////////////////////////////////////////////////////////////////////////////list
        //     var qproduct = db.Tbl_Product.Where (a => a.Id == id).SingleOrDefault ();
        //     var qgallery = db.tb_GalleryProducts.Where (a => a.IdProduct == id).ToList ();
        //     List<string> h=new List<string>();
        //     foreach (var item in qgallery)
        //     {

        //         h.Add(item.ImagePath);
        //     }
        //     Vm_Product qp = new Vm_Product () {
        //         Id = qproduct.Id,
        //         TitleProductPro = qproduct.TitleProductPro,
        //         ImageMainPro = qproduct.ImageMainPro,
        //         CategoryIdPro = qproduct.CategoryIdPro,
        //         PricePro = qproduct.PricePro,
        //         OfferPro = qproduct.OfferPro,
        //         SizePro = qproduct.SizePro,
        //         ColorPro = qproduct.ColorPro,
        //         BrandPro = qproduct.BrandPro,
        //         MaterialPro = qproduct.MaterialPro,
        //         TotalPro = qproduct.TotalPro,
        //         DescreptionPro = qproduct.DescreptionPro,
        //         Language = qproduct.Language,

        //     };
        //    ViewBag.img=h;
        //     return View (qp);
        // }



    //    public async Task<IActionResult> updatepro(Vm_Product pro)
    //    {
    //        var qlist=db.Tbl_Product.Where(a=>a.Id==pro.Id).SingleOrDefault();
    //        if (pro.upload_imgs != null)
    //        {
    //            var qgallery=db.tb_GalleryProducts.Where(a=>a.IdProduct==pro.Id).ToList();
    //            foreach (var item in qgallery)
    //            {
    //                db.tb_GalleryProducts.Remove(item);
    //                db.SaveChanges();

    //            }

    //            ////////////////////////////////////////////////////////upload multi image
            
    //             foreach (var item in pro.upload_imgs) {
    //                 ///////////////upload file
    //                 string FileExtension1 = Path.GetExtension (item.FileName);
    //                 NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
    //                 var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
    //                 using (var stream = new FileStream (path, FileMode.Create)) {

    //                     await item.CopyToAsync (stream);

    //                 }
    //                 Tb_GalleryProduct g = new Tb_GalleryProduct () {
    //                     Language = pro.Language,
    //                     ImagePath = NewFileName,
    //                     IdProduct = pro.Id
    //                 };
    //                 db.tb_GalleryProducts.Add (g);
    //                 db.SaveChanges ();

    //                 //////////////////////////end upload file 
    //             }

          
           
    //        }
           
    //            ////////////////////////////////////////////////////////////////////////////start upload main imge
    //         if (pro.mainimg != null)
    //         {
              
    //                 ///////////////upload file
    //                 string FileExtension1 = Path.GetExtension (pro.mainimg.FileName);
    //                 NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
    //                 var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
    //                 using (var stream = new FileStream (path, FileMode.Create)) {

    //                     await pro.mainimg.CopyToAsync (stream);

    //                 }
    //                 //////////////////////////end upload file 
    //             qlist.Id = pro.Id;
    //             qlist.TitleProductPro = pro.TitleProductPro;
    //             qlist.ImageMainPro = NewFileName;
    //             qlist.CategoryIdPro = pro.CategoryIdPro;
    //             qlist.PricePro = pro.PricePro;
    //             qlist.OfferPro = pro.OfferPro;
    //             qlist.SizePro = pro.SizePro;
    //             qlist.ColorPro = pro.ColorPro;
    //             qlist.BrandPro = pro.BrandPro;
    //             qlist.TypeCarPro = pro.TypeCarPro;
    //             qlist.MaterialPro = pro.MaterialPro;
    //             qlist.TotalPro = pro.TotalPro;
    //             qlist.DescreptionPro = pro.DescreptionPro;
    //             qlist.Language = pro.Language;

    //             db.Tbl_Product.Update(qlist);
    //             db.SaveChanges();
    //             err="اطلاعات با موفقیت به روز رسانی شد.";
    //             return RedirectToAction("list");
    //         }
    //         else
    //         {
    //             qlist.Id = pro.Id;
    //             qlist.TitleProductPro = pro.TitleProductPro;
    //             qlist.CategoryIdPro = pro.CategoryIdPro;
    //             qlist.PricePro = pro.PricePro;
    //             qlist.OfferPro = pro.OfferPro;
    //             qlist.SizePro = pro.SizePro;
    //             qlist.ColorPro = pro.ColorPro;
    //             qlist.BrandPro = pro.BrandPro;
    //             qlist.TypeCarPro = pro.TypeCarPro;
    //             qlist.MaterialPro = pro.MaterialPro;
    //             qlist.TotalPro = pro.TotalPro;
    //             qlist.DescreptionPro = pro.DescreptionPro;
    //             qlist.Language = pro.Language;

    //             db.Tbl_Product.Update(qlist);
    //             db.SaveChanges();
    //             err="اطلاعات با موفقیت به روز رسانی شد.";
    //             return RedirectToAction("list");
    //         }

           
    //    }


    }
}