using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using  faraboom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using DataLayer.AdminEntities.Teaser;
using ViewModels.AdminViewModel.Teaser;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace faraboom.Areas.Adminsite.Controllers {
   
    public class TeaserController : BaseController {
           public TeaserController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
             if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            //////////////////////////////////////////////////selector
            var qlist=db.Tbl_Product.ToList();
            ViewBag.list=new SelectList(qlist,"Id","TitleProductPro");
            ///////////////////////////////////////////////////////////list
            return View();
        }
          public IActionResult list()
        {
              if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
             
             ////////////////////////////////list
            
             
             ViewBag.list=db.Tbl_Teaser.OrderByDescending(a=>a.Id).ToList();
            return View();
        }


       public async Task<IActionResult> add(Vm_Teaser ex)
        {
            ///////////////upload file
                string FileExtension1 = Path.GetExtension(ex.img.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await ex.img.CopyToAsync(stream);



                }
                //////////////////////////end upload file 
           Tb_Teaser tb=new Tb_Teaser()
           {
              
               TitleTeaser=ex.TitleTeaser,
               LinkVideoTeaser=NewFileName,
               Language=ex.Language
           };
           db.Tbl_Teaser.Add(tb);
           db.SaveChanges();
           err="اطلاعات با موفقیت ثبت شد";
           return RedirectToAction("index");
           
        }


       public IActionResult del(int id)
         {
             var qdel=db.Tbl_Teaser.Where(add=>add.Id==id).SingleOrDefault();
             db.Tbl_Teaser.Remove(qdel);
             db.SaveChanges();
             err="حذف رکورد مورد نظر با موفقیت انجام شد";
             return RedirectToAction("list");
         }

    }
}