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
using ViewModels.AdminViewModel.Experts;
using DataLayer.AdminEntities.Experts;
using System.IO;

namespace faraboom.Areas.Adminsite.Controllers
{
   
    public class  ExpertsController: BaseController
    {
           public ExpertsController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
             if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
           
            return View();
        }

         public IActionResult List()
        {
             if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
             ViewBag.list=db.Tbl_Experts.ToList();
            return View();
        }
         

         public IActionResult del(int id)
         {
             var qdel=db.Tbl_Experts.Where(add=>add.Id==id).SingleOrDefault();
             db.Tbl_Experts.Remove(qdel);
             db.SaveChanges();
             err="حذف رکورد مورد نظر با موفقیت انجام شد";
             return RedirectToAction("list");
         }

        public async Task<IActionResult> add(Vm_Experts ex)
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
           Tb_Experts tb=new Tb_Experts()
           {
              
               NameEx=ex.NameEx,
               ImageEx=NewFileName,
               TelEx=ex.TelEx,
               OfficeTelEx=ex.OfficeTelEx,
               LocationEx=ex.LocationEx,
               AboutEx=ex.AboutEx,
               address=ex.address,
               Language=ex.Language
           };
           db.Tbl_Experts.Add(tb);
           db.SaveChanges();
           err="اطلاعات با موفقیت ثبت شد";
           return RedirectToAction("index");
           
        }
    }
}