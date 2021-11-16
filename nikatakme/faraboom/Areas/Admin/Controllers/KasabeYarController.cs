using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Admin.Controllers;
using DataLayer.AdminEntities.KasabeYar;
using DataLayer.Context;
using faraboom.Models;
using ViewModels.AdminViewModel.KasabeYar;

namespace faraboom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class KasabeYarController : BaseController
    {
        public KasabeYarController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sabt()
        {
            return View();
        }

        public async Task<ActionResult> Add( Vm_KasabeYarUser vky )
        {
            Tbl_KasabeYarUser tky = new Tbl_KasabeYarUser();
            tky.Name = vky.Name ;
            tky.Family = vky.Family ;
            tky.CodeMeli = vky.CodeMeli ;
            tky.UserName = vky.UserName ;
            tky.UserAdmin = User.Identity.GetId() ;
            tky.Password = vky.Password ;
            tky.Phone = vky.Phone ;
            tky.Email = vky.Email ;
            tky.CodePosti = vky.CodePosti;
            tky.Address = vky.Address ;
            tky.state = true ;
            if (vky.img != null)
            {
                string FileExtension = Path.GetExtension(vky.img.FileName);
                string NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await vky.img.CopyToAsync(stream);
                }
                tky.Image = NewFileName;
            }
            db.Tbl_KasabeYarUsers.Add(tky);
            db.SaveChanges();

            ViewBag.msg = " ثبت با موفقیت انجام شد . ";

            return View();
        }
        public IActionResult Report()
        {
            var quser = db.Tbl_KasabeYarUsers.Where(a => a.UserAdmin == User.Identity.GetId()).OrderByDescending(a => a.Id);
            ViewBag.quser = quser;
            return View();
        }

        public IActionResult Detail( int id )
        {
            var quser = db.Tbl_KasabeYarUsers.SingleOrDefault( a => a.Id == id ); 
            if ( quser.state == true )
            {
                quser.state = false ;
            }
            else
            {
                quser.state = true ;
            }
            db.Tbl_KasabeYarUsers.Update(quser);
            db.SaveChanges();
            return RedirectToAction("Report");
        }

    }
}