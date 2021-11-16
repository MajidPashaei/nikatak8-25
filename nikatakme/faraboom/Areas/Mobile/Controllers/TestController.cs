using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mobile.Controllers {
    [Area("Mobile")]

    public class TestController : Controller {

        public async Task<IActionResult> Index ()
         {

           var b= Encoding.UTF8.GetString(Encoding.Default.GetBytes("رحیم قاسمی"));

            return View ();
         }

        public async Task<IActionResult> Client ()
        {

            return View ();
        }

        public void GetData () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", "Your Access Token");
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "Your Device Id");
            client.DefaultRequestHeaders.Add ("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add ("Token-Id", "xukHh7W5wozX0mRmvIldAO0Paz7xViCYt6SPxj3boVrAIlEDXX4Dfz3JVEl3j0Lzl2suE8fmoL1tuEXP1x4HpV1Q");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");
        }

    }
}