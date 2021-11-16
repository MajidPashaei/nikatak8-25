using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Hesab;
using RestSharp;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using DataLayer.AdminEntities.Hesab;

namespace Mobile.Controllers
{
    [Area("Mobile")]
    [Authorize]
    public class HesabController : BaseController
    {
        public static string msg ;

        public HesabController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {

        }
        public IActionResult Index()
        {
            if (msg != null)
            {
                ViewBag.msg = msg ;
                msg = null ;
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Index2(Vm_Hesab vh)
        {
            Tbl_Hesab th = new Tbl_Hesab
            {
                UserName = User.Identity.GetId(),
                Bank = vh.Bank,
                Hesab = vh.Hesab,
                Shaba = vh.Shaba,
                Shobe = vh.Shobe,
            };
            db.Tbl_Hesabs.Add(th);
            db.SaveChanges();
            msg = " اطلاعات حساب بانکی شما ثبت و در انتظار تایید میباشد .  ";
            return RedirectToAction("Index");
        }
    }
}