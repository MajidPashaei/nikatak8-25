using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.Avarez;
//using Admin.Models;

namespace Admin.Controllers
{
    [Area("Admin")]
    public class AvarezController : Controller
    {
        public AvarezController()
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Way()
        {
            return View();
        }
        public async Task<IActionResult> ShowWay(Vm_info A)
        {
            var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13457");
            client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            string pelak = A.License1 + A.License2 + A.License3;
            var data = new
            {
                license = pelak,
                token = "dGVzdGFwaTp0ZXN0 "
            };
            var response = await client.PostAsJsonAsync("vas/toll/freeway/debts/total", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            return View();
        }
        public IActionResult detailsWay()
        {
            return View();
        }
        public async Task<IActionResult> ShowdetailsWay(Vm_info B)
        {
            var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13457");
            client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            string pelak = B.License1 + B.License2 + B.License3;
            var data = new
            {
                license = pelak,
                token = "dGVzdGFwaTp0ZXN0"
            };
            var response = await client.PostAsJsonAsync("vas/toll/freeway/debts/detail", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            return View();
        }
        public IActionResult Pardakht()
        {
            return View();
        }
        public async Task<IActionResult> ShowPardakht(Vm_Avarez va)
        {
            var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            client.DefaultRequestHeaders.Add("App-Key", "13457");
            client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
            var data = new
            {
                bill_id = va.bill_id ,
                amount = va.amount ,
                reference =  va.reference ,
                token = va.Token ,
            };
            var response = await client.PostAsJsonAsync("vas/toll/freeway/payments", data);
            ViewBag.result = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}