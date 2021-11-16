using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Admin.Controllers {
    [Area ("Admin")]
    [Authorize]
    public class EnteghalController : Controller {
        public IActionResult Index () {
            return View ();
        }
        public IActionResult Azmon () {
            return View ();
        }
        public IActionResult Card () {
            return View ();
        }
        public IActionResult B_Paya () {
            return View ();
        }
        public IActionResult B_Satena () {
            return View ();
        }
        public IActionResult Dakheli () {
            return View ();
        }

    }
}