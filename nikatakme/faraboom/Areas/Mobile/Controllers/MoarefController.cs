using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using Admin.Models;

namespace Mobile.Controllers {
    [Area ("Mobile")]
    [Authorize]
    public class MoarefController : BaseController
    { 

  public MoarefController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
      {
          
      }
        public IActionResult Index()
        {
            return View();
        }
    }
}