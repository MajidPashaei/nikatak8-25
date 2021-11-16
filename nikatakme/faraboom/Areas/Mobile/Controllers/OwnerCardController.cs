using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mobile.Controllers {
    [Area ("Mobile")]
    public class OwnerCardController : Controller {
        public async Task<IActionResult> Index () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "Your Device Id");
            client.DefaultRequestHeaders.Add ("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add ("Token-Id", "EJbzhUr1mul3SzEhaLHcm7SvQzZY69CLO8I6TYm6rbQEWEhbNLoXF84lp7QfuQ8qPgiVybQ9OnMSJurlO465Hsks");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                pan = "5029381014694871",
                // destination_pan = "",
                // track2 = "",
                pin = "76375",
                pin_type = "CARD",
                cvv2 = "496",
                exp_date = "0107",
                // loan_number = "",
                // amount = 0
            };
            var response = await client.PostAsJsonAsync ("cards/holder", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
    }
}