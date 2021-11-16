using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using ViewModels.AdminViewModel.Logo;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.Logo;
using DataLayer.Context;
using Microsoft.AspNetCore.Http;

namespace faraboom.Areas.Adminsite.Controllers
{
   
    public class LogoController : BaseController
    {
        public LogoController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////index logo
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            var list = db.Tbl_Logo.ToList();
            if (list != null)
            {
                ViewBag.list = list;
            }
            return View();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////add logo
        [HttpPost]
        public async Task<IActionResult> add(Vm_Logo vmlogo)
        {
            if (db.Tbl_Logo.Any(a => a.Language == vmlogo.Language))
            {

                err = "قبلا برای این زبان ثبت شده لطفا آن را حذف دوباره امتحان کنید.";
            }
            else
            {

                ///////////////upload file
                string FileExtension1 = Path.GetExtension(vmlogo.ImageLogo.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await vmlogo.ImageLogo.CopyToAsync(stream);



                }
                //////////////////////////end upload file 
                  ///////////////upload file
                string FileExtension2 = Path.GetExtension(vmlogo.fav.FileName);
                NewFileName1 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName1}";
                using (var stream = new FileStream(path1, FileMode.Create))
                {

                    await vmlogo.fav.CopyToAsync(stream);



                }
                //////////////////////////end upload file 



                var logo = new Tb_Logo()
                {
                    TitleLogo = vmlogo.TitleLogo,
                    ImageLogo = NewFileName,
                    Language = vmlogo.Language,
                    FavIcon=NewFileName1


                };
                db.Tbl_Logo.Add(logo);
                db.SaveChanges();
                err = "اطلاعات با موفقیت ثبت شد";
                

            }


            return RedirectToAction("index");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////delete logo
        public IActionResult del(int id)
        {
            var selectdel = db.Tbl_Logo.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_Logo.Remove(selectdel);
            db.SaveChanges();
            err = "حذف با موفقیت انجام شد";
            return RedirectToAction("index");
        }











    }
}