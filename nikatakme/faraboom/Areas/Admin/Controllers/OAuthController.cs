using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Admin.Controllers
{
    [Area("Admin")]
    public class OAuthController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new RestClient("https://oauth.sandbox.faraboom.co/oauth/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept-Language", "fa");
            request.AddHeader("App-Key", "13075");
            request.AddHeader("Device-Id", "185.159.152.2");
            request.AddHeader("Bank-Id", "BEGNIR ");
            request.AddHeader("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            request.AddHeader("CLIENT-DEVICE-ID", "127.0.0.1");
            request.AddHeader("CLIENT-IP-ADDRESS", "127.0.0.1");
            request.AddHeader("CLIENT-USER-AGENT", "127.0.0.1");
            request.AddHeader("CLIENT-USER-ID", "09121234567");
            request.AddHeader("CLIENT-PLATFORM-TYPE", "WEB");
            request.AddHeader("Authorization", "Basic MTM0NTc6RDVWTFF5VjB6Mlc4WkM1UkpEUzZTN24zRXREdFp1aTg4WExja0xWZmR3WQ==");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", "ghasabkola");
            request.AddParameter("password", "717517351");
            request.AddParameter("grant_type", "password");
            ViewBag.response = client.Execute(request);

            return View();
        }

        public async Task<IActionResult> Check(string code, string state)
        {
            return View();
        }
    }
}