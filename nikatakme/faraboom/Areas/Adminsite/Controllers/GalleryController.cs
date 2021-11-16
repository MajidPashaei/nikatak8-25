using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using DataLayer.AdminEntities.Gallery;
using ViewModels.AdminViewModel.Gallery;
using System.IO;

namespace faraboom.Areas.Adminsite.Controllers
{
    
    
    public class  GalleryController: BaseController
    {
       public GalleryController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            return View();
        }
         public IActionResult List()
        {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list=db.Tbl_Gallery.OrderByDescending(a=>a.Id).ToList();
            return View();
        }

        public async Task<IActionResult> add(Vm_Gallery gallery)
        {

            ///////////////upload file
                    string FileExtension1 = Path.GetExtension (gallery.img.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                    var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path, FileMode.Create)) {

                        await gallery.img.CopyToAsync (stream);

                    }
                    //////////////////////////end upload file  
          Tb_Gallery g=new Tb_Gallery()
          {
              Language=gallery.Language,
              TitleGal=gallery.TitleGal,
              pathImage=NewFileName,


          };
          db.Tbl_Gallery.Add(g);
          db.SaveChanges();
          var finallist=db.Tbl_Gallery.OrderByDescending(a=>a.Id).Take(1).SingleOrDefault();
          if (gallery.upload_imgs != null) {
                foreach (var item in gallery.upload_imgs) {
                    ///////////////upload file
                    string FileExtension = Path.GetExtension (item.FileName);
                    NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension);
                    var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                    using (var stream = new FileStream (path1, FileMode.Create)) {

                        await item.CopyToAsync (stream);

                    }
                    //////////////////////////end upload file 
                    Tb_ImageGallery imageGallery=new Tb_ImageGallery()
                    {
                        IdGallery=finallist.Id,
                        ImagePath=NewFileName,
                        Language=finallist.Language
                    }
                    ;
                    db.tb_ImageGalleries.Add(imageGallery);
                    db.SaveChanges();
                }
                err="اطلاعات با موفقیت ثبت شد";
              

            }

            return RedirectToAction("index");
        }


        public IActionResult del(int id)
        {
            var qselect=db.Tbl_Gallery.Where(a=>a.Id==id).SingleOrDefault();
            db.Tbl_Gallery.Remove(qselect);
            db.SaveChanges();
            var qgallery=db.tb_ImageGalleries.Where(a =>a.IdGallery==id).ToList();
            foreach (var item in qgallery)
            {
                db.tb_ImageGalleries.Remove(item);
                   db.SaveChanges();
            }
            err="رکورد با موفقیت حذف شد";
            return RedirectToAction("list");


        }

    }
}