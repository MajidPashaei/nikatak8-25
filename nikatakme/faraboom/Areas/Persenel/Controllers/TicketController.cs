using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Persenel.Controllers {
    [Area ("Persenel")]

    public class TicketController : Controller {


        public IActionResult Inputs () {

            return View ();
        }

        public IActionResult send () {

            return View ();
        }
    }
}