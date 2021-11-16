using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using ViewModels.AdminViewModel.inforep;

namespace faraboom.Controllers
{
       public class AgancyController : BaseController
    {
       ////////////////////////////////////////////////////type db
        public AgancyController(ContextHampadco _db, IWebHostEnvironment env):base(_db,env)
        {
            
        }
         
        //////////////////////////////////////////////////////////
        public IActionResult Index()
        {
            setdata();
           //////////////////////////////////////////////////////////////////////////////////expert list
           ViewBag.list = db.Tbl_Inforeps.OrderByDescending(a=>a.Id).ToList ();
        //    ViewBag.agancy=db.Tbl_Agencie.Where(a=>a.Language==ln).OrderByDescending(a=>a.Id).ToList();
           return View();
        }
        
         public IActionResult details(int id)
        {

            ViewBag.det = db.Tbl_Inforeps.Where(a=>a.Id==id).ToList();
           
           //////////////////////////////////////////////////////////////////////////////////expert list
        //    var agancy=db.Tbl_Agencie.Where(a =>a.Id==id && a.Language==ln).SingleOrDefault();
        //    if (agancy == null)
        //    {
        //        return RedirectToAction("index","home");
        //    }
           return View();
        }

           public IActionResult filter(Vm_inforep B)
        {
           ViewBag.A=db.Tbl_Inforeps.Where(a=>a.City==B.City).ToList();
           
           return View();
        }


        
     
        

    }
}
