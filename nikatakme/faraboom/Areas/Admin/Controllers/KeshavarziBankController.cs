using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Admin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using Admin.Models;
using Newtonsoft;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using Microsoft.AspNetCore.HttpOverrides;

namespace Admin.Controllers
{   
    [Area("Admin")]
    [Authorize]
    public class KeshavarziBankController : BaseController
    {
        public KeshavarziBankController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {

        }

        // گرفتن Ip کاربر
        public string g()
        {
            var x= Request.HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");
            var z= Request.HttpContext.GetServerVariable("REMOTE_ADDR");
            var y =  Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var t = Request.HttpContext.Request.HttpContext.Connection.RemoteIpAddress ;
            var ss=System.Net.IPAddress.IPv6Loopback;
            var b1=y[y.Length-4];
            var b2=y[y.Length-3];
            var b3=y[y.Length-2];
            var b4=y[y.Length-1];
            var gh=b1.ToString()+"."+b2.ToString()+"."+b3.ToString()+"."+b4.ToString();
            return gh;
        }

        
        
        
        // قسمت فراخوانی مشترک کلیه API ها
        public RestRequest API()
        {
            
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Request-ID", "-38577028");
            request.AddHeader("X-API-Key", "rl5OzOSQsbKB9+FeM0f3Ljw3JZe5KoIGtoRYDelnKRI=");
            request.AddHeader("TPP-IP-Address", "185.132.80.141");
            request.AddHeader("PSU-IP-Address","185.132.80.141");
            request.AddHeader("PSU-Date", "2021-11-15T21:1:29.215+0330");
            request.AddHeader("Client-ID", "F640A01E-8E52-4D45-877A-4234083D079A");
            request.AddHeader("Client-Secret", "MM56Y4V036q6617ICuDls34rGi8TdXHcB73T4BxAS1");
            return request;
        }
        // IR0696000000010324200001
        ///   برای   انتخاب سرویس مد نظر
        public IActionResult Index()
        {
            var Ip=g();
            var client = new RestClient("https://oapi.bki.ir:443/v1/ibans/IR0696000000010324200001/inquiry?lang=fa");
            client.Timeout = -1;
            var request=API();
            IRestResponse response = client.Execute(request);
            return View();
        }
    }
}