using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers {
    [Area ("Admin")]

    public class MoneyTransferController : Controller {
        public IActionResult Card () {

            return View ();
        }

        public IActionResult Paya () {

            return View ();
        }

        public IActionResult Satna () {

            return View ();
        }

        public IActionResult Internal () {

            return View ();
        }
    }
}