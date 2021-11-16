using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers {
    [Area ("Admin")]
    public class ReserveToken : Controller {
        public async Task<IActionResult> Index () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "Your Device Id");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "nikatak",
                password = "Nn@123456",
            };
            var response = await client.PostAsJsonAsync ("auth/market/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
    }
}