using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Areas.Adminsite.Controllers
{
    
    public class  SourcehelpController: BaseController
    {
          public SourcehelpController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult UploadImageSingle()
        {
            return View();
        }
        public IActionResult UploadImageMulti()
        {
            return View();
        }
        public IActionResult list()
        {
            return View();
        }
        public IActionResult DropdownSearch()
        {
            return View();
        }



    }
}