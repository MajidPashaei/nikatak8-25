using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Agency;
using DataLayer.AdminEntities.inforep;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Agency;
using ViewModels.AdminViewModel.inforep;

namespace faraboom.Areas.Adminsite.Controllers {
    public class AgencyController : BaseController {
            
        public AgencyController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) { }
        public IActionResult Index () {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            return View ();
        }
        public IActionResult List () {
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list = db.Tbl_Inforeps.ToList ();
            return View ();
        }

        public IActionResult del (int id) {
            var qdel = db.Tbl_Inforeps.Where (add => add.Id == id).SingleOrDefault ();
            db.Tbl_Inforeps.Remove (qdel);
            db.SaveChanges ();
            err = "حذف رکورد مورد نظر با موفقیت انجام شد";
            return RedirectToAction ("list");
        }

        public async Task<IActionResult> add (Vm_inforep ex) {
            ///////////////upload file
            string FileExtension1 = Path.GetExtension (ex.poto.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) {

                await ex.poto.CopyToAsync (stream);

            }
            //////////////////////////end upload file 
            Tbl_inforep tb = new Tbl_inforep () {

                photos = NewFileName,
                State = ex.State,
                City = ex.City,
                part = ex.part,
                cod = ex.cod,
                Clerk = ex.Clerk,
                Phone = ex.Phone,
                PhoneHome = ex.PhoneHome,
                Address = ex.Address,
                Postalcode=ex.Postalcode,
                Locationaddress=ex.Locationaddress,
                Description=ex.Description,
                codshow=ex.codshow,
                Clerkshow=ex.Clerkshow,
                Phoneshow=ex.Phoneshow,
                PhoneHomeshow=ex.PhoneHomeshow,
                Addressshow=ex.Addressshow,
                Postalcodeshow=ex.Postalcodeshow,
                photosshow=ex.photosshow,




            };
            db.Tbl_Inforeps.Add (tb);
            db.SaveChanges ();
            err = "اطلاعات با موفقیت ثبت شد";
            return RedirectToAction ("index");

        }

            [HttpGet]
          public IActionResult edit (int id) {
          var B=db.Tbl_Inforeps.Where(a=>a.Id==id).SingleOrDefault();
           Vm_inforep A=new Vm_inforep()
           {

                photos = B.photos,
                State = B.State,
                City = B.City,
                part = B.part,
                cod = B.cod,
                Clerk = B.Clerk,
                Phone = B.Phone,
                PhoneHome = B.PhoneHome,
                Address = B.Address,
                Postalcode=B.Postalcode,
                Locationaddress=B.Locationaddress,
                Description=B.Description,
                codshow=B.codshow,
                Clerkshow=B.Clerkshow,
                Phoneshow=B.Phoneshow,
                PhoneHomeshow=B.PhoneHomeshow,
                Addressshow=B.Addressshow,
                Postalcodeshow=B.Postalcodeshow,
                photosshow=B.photosshow,
           };
             
            return View (A);
        }


    [HttpPost]
          public async Task< IActionResult> edit (Vm_inforep B) {
          var A=db.Tbl_Inforeps.Where(a=>a.Id==B.Id).SingleOrDefault();
          if (B.poto!=null)
          {
                    string FileExtension1 = Path.GetExtension (B.poto.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) {

                await B.poto.CopyToAsync (stream);

            }
             A.photos = NewFileName;
          }
        

            
              A.State = B.State;
              A.City = B.City;
              A.part = B.part;
               A.cod = B.cod;
             A.Clerk = B.Clerk;
             A.Phone = B.Phone;
             A.PhoneHome = B.PhoneHome;
             A.Address = B.Address;
             A.Postalcode=B.Postalcode;
            A.Locationaddress=B.Locationaddress;
            A.Description=B.Description;
            A.codshow=B.codshow;
            A.Clerkshow=B.Clerkshow;
            A.Phoneshow=B.Phoneshow;
            A.PhoneHomeshow=B.PhoneHomeshow;
            A.Addressshow=B.Addressshow;
             A.Postalcodeshow=B.Postalcodeshow;
             A.photosshow=B.photosshow;
          
             db.Tbl_Inforeps.Update(A);
             db.SaveChanges();
            return RedirectToAction("List");
        }




    }
}