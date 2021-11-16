using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using DataLayer.Context;
using ViewModels.AdminViewModel.Teaser;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Controllers
{
       public class TeaserController : BaseController
    {
       ////////////////////////////////////////////////////type db
           public TeaserController(ContextHampadco _db,  IWebHostEnvironment env):base(_db, env)
        {
            
        }
        //////////////////////////////////////////////////////////
        public IActionResult Index()
        {
            setdata();
           ///////////////////////////////////////////////////////////////////////////////teaser
           ViewBag.Teaser=db.Tbl_Teaser.Where(a=>a.Language==ln).OrderByDescending(a=>a.Id).ToList();
           return View();
        }
        
         public IActionResult details(int id)
        {
          
           ///////////////////////////////////////////////////////////////////////////////teaser
           var Teaser=db.Tbl_Teaser.Where(a=>a.Id==id).SingleOrDefault();
           

           return View(Teaser);
        }
        

    }
}
