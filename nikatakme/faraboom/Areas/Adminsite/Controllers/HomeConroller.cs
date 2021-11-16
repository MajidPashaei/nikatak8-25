using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Areas.Adminsite.Controllers
{
   
    public class HomeController : BaseController
    {
        
        
        public HomeController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
              var user = db.Tbl_User.Where(a => a.UserNameUs=="admin").SingleOrDefault();
              if (user != null)
              {
                   menu.img=user.ProfileImageUs;
              }
             
              menu.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess!="admin").Count();
              menu.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
          
            return View();
        }
        public IActionResult exit()
        {
          
           
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index","home",new { area = "" });
        }

        public IActionResult RayChat()
        {
          return View();
        }

    }
}