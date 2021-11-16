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
    public class TashilatController : Controller {

        public IActionResult Index () {
            return View ();
        }
        public IActionResult Getfacilitydetails () {
            return View ();
        }
         public IActionResult Gettheownerofthefacility () {
            return View ();
        }
         public IActionResult Listoffacilities () {
            return View ();
        }
         public IActionResult Paymentoffacilitiesbydeposit () {
            return View ();
        }
         public IActionResult Paymentoffacilitiesbycard () {
            return View ();
        }

    }
}