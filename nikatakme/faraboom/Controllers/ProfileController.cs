using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using DataLayer.Context;
using ViewModels.AdminViewModel.User;
using DataLayer.AdminEntities.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.User;

namespace faraboom.Controllers
{
     [Authorize]
       public class ProfileController : BaseController
    {
        ////////////////////////////////////////////////////type db
         public ProfileController(ContextHampadco _db, IWebHostEnvironment env):base(_db,env)
        {
            
        }
        //////////////////////////////////////////////////////////


        public IActionResult Index()
        {
            if (menu.idrezerv != 0)
            {
                int id=menu.idrezerv;
                menu.idrezerv=0;
                return RedirectToAction("details","product",new{ id =id});
                
            }
             setdata();
            /////////////////////////////////////////////////////////////////////////////////////////////////////eror message
            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }
             var quser=db.Tbl_User.Where(a=>a.Id== Convert.ToInt32(User.Identity.GetId())).SingleOrDefault();
             Vm_User us =new Vm_User()
             {
                 UserNameUs=quser.UserNameUs,
                 PhoneUs=quser.PhoneUs,
                 ProfileImageUs=quser.ProfileImageUs,
                 PasswordUs=quser.PasswordUs,
                 AddressUs=quser.AddressUs,
             };
            return View(us);
        }
        



        public async Task<IActionResult> add(Vm_User us)
        {
            if (us.UserNameUs=="admin")
            {
                eror="نام غیر قابل قبول است";
               return RedirectToAction("index");
            }


             
            if (us.img != null)
            {
                ///////////////upload file
                string FileExtension1 = Path.GetExtension(us.img.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await us.img.CopyToAsync(stream);



                }
                //////////////////////////end upload file 
               var quser=db.Tbl_User.Where(a=>a.Id== Convert.ToInt32(User.Identity.GetId())).SingleOrDefault();
               quser.UserNameUs=us.UserNameUs;
               quser.PasswordUs=us.PasswordUs;
               quser.AddressUs=us.AddressUs;
               quser.ProfileImageUs=NewFileName;
               quser.Language="fa";
               db.Tbl_User.Update(quser);
               db.SaveChanges();
               eror="اطلاعات با موفقیت بروز رسانی شد.";
               return RedirectToAction("index");
            }else
            {
                 var quser=db.Tbl_User.Where(a=>a.Id== Convert.ToInt32(User.Identity.GetId())).SingleOrDefault();
               quser.UserNameUs=us.UserNameUs;
               quser.PasswordUs=us.PasswordUs;
                 quser.Language="fa";
               quser.AddressUs=us.AddressUs;
               db.Tbl_User.Update(quser);
               db.SaveChanges();
               eror="اطلاعات با موفقیت بروز رسانی شد.";
               return RedirectToAction("index");
            }
        }
       
    }
}
