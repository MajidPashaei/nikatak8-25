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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
namespace faraboom.Controllers
{
   
       public class AmozeshController : BaseController
    {
       ////////////////////////////////////////////////////type db
           public AmozeshController(ContextHampadco _db,  IWebHostEnvironment env):base(_db, env)
        {
            
        }
        //////////////////////////////////////////////////////////
        public IActionResult Index()
        {
           
           ///////////////////////////////////////////////////////////////////////////////teaser
           
           return View();
        }

         public IActionResult Category(string type)
        {
           
           ///////////////////////////////////////////////////////////////////////////////teaser
           ViewBag.Amozesh=db.Tbl_Teaser.Where(a=>a.Language==type).ToList();
           return View();

        }
        
         public IActionResult details(int id )
        {
          
           ///////////////////////////////////////////////////////////////////////////////teaser
           var Amozesh=db.Tbl_Teaser.Where(a=>a.Id==id).SingleOrDefault();
           

           return View(Amozesh);
        }
        

    }
}
