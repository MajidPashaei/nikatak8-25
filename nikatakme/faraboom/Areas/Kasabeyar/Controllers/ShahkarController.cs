using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Tavanam;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Kasabeyar.Controllers
{
    [Area("Kasabeyar")]
    [Authorize]
    public class ShahkarController : BaseController
    {
        public ShahkarController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }

        public IActionResult Index()
        {
            Diposit();
            return View();
        }

        //----------------------------------------------------------------------------------///

        public IActionResult Step1()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> Step2(Vm_Tavanam vt)
        {
            if (HttpContext.Session.GetInt32("sum") >= 12000)
            {
                var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
                var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));

                client.DefaultRequestHeaders.Add("App-Key", "13075");
                client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
                client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
                
                // client.DefaultRequestHeaders.Add("App-Key", "13457");
                // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
                // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");

                client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
                client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
                client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
                client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
                client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
                var data = new
                {
                    national_code = vt.national_code,
                    mobile = vt.mobile
                };
                var response = await client.PostAsJsonAsync("tavanam/factors", data);
                if (response.IsSuccessStatusCode == true)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "اعتبارسنجی",
                        Bill_Id = vt.factor_id,
                        Pay_Id = vt.pay_id,
                        Amount = 12000,
                        Titel_Request = "دریافت فاکتور",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(12000, qfinal.Id);
                    var result = await response.Content.ReadAsStringAsync();
                    var myDesfactor = JsonConvert.DeserializeObject<Rootfactor>(result);
                    //--------------------------------------------------------------------------------------------------------------------------------------------------//
                    //--------------------------------------------------------------------------------------------------------------------------------------------------//
                    var baseAddress1 = new System.Uri("https://api.faraboom.co/v1/");
                    var client1 = new System.Net.Http.HttpClient { BaseAddress = baseAddress1 };
                    client1.DefaultRequestHeaders.AcceptLanguage.Clear();
                    client1.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));

                    client1.DefaultRequestHeaders.Add("App-Key", "13075");
                    client1.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
                    client1.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");

                    // client1.DefaultRequestHeaders.Add("App-Key", "13457");
                    // client1.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
                    // client1.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");

                    client1.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
                    client1.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
                    client1.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
                    client1.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
                    client1.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
                    Random rn = new Random();
                    string rand = rn.Next(1000000, 99999999).ToString();
                    var data1 = new
                    {
                        factor_id = myDesfactor.FactorId,
                        pay_id = rand
                    };
                    var response1 = await client1.PostAsJsonAsync("tavanam/otp", data1);
                    if (response1.IsSuccessStatusCode == true)
                    {
                        var result1 = await response1.Content.ReadAsStringAsync();
                        var myDessms = JsonConvert.DeserializeObject<Rootsms>(result1);
                        if (myDessms.Succeed == true)
                        {
                            ViewBag.result = " Ok . ";
                            ViewBag.res = await response1.Content.ReadAsStringAsync();
                            ViewBag.fid = myDesfactor.FactorId;                            
                        }
                        else
                        {
                            ViewBag.Msg = " خطا در انجام عملیات . ";
                        }
                    }
                    else
                    {
                        ViewBag.res = await response1.Content.ReadAsStringAsync();
                        ViewBag.Msg = " خطا در انجام عملیات . ";
                    }
                }
                else
                {
                    ViewBag.res = await response.Content.ReadAsStringAsync();
                    ViewBag.Msg = " خطا در انجام عملیات  . ";
                }
            }
            else
            {
                ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
            }
            Diposit();
            return View();
        }   
        public class Rootfactor
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; } 

            [JsonProperty("factor_id")]
            public string FactorId { get; set; }  

            [JsonProperty("amount")]
            public int Amount { get; set; }
        }      
        public class Rootsms
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }
    
            [JsonProperty("succeed")]
            public bool Succeed { get; set; }
        }

        public IActionResult Set(Vm_Tavanam vtf)
        {
            List<Vm_Tavanam> lvt = new List<Vm_Tavanam>();
            Vm_Tavanam vt = new Vm_Tavanam()
            {
                otp = vtf.otp ,
                factor_id = vtf.factor_id ,
            };
            lvt.Add(vt);
            ViewBag.res = lvt;
            Diposit();
            return View();
        }
        
        public IActionResult Set()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> ShowReport( string fi , string ot )
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));

            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            
            // client.DefaultRequestHeaders.Add("App-Key", "13457");
            // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");

            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                factor_id = fi ,
                otp = ot ,
            };
            var response = await client.PostAsJsonAsync("tavanam/reports", data);
            if (response.IsSuccessStatusCode == true)
            {
                var result = await response.Content.ReadAsStringAsync();
                ViewBag.res = await response.Content.ReadAsStringAsync();
                var myDesreport = JsonConvert.DeserializeObject<Rootreport>(result); 
                ViewBag.result = myDesreport;
            }
            else
            {
                ViewBag.res = await response.Content.ReadAsStringAsync();
                ViewBag.Msg = " خطا در انجام عملیات  . ";
            }
            Diposit();
            return View();
        }

        public class Rootreport
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }

            [JsonProperty("reason_codes")]
            public string ReasonCodes { get; set; }

            [JsonProperty("rate")]
            public string Rate { get; set; }

            [JsonProperty("rank")]
            public string Rank { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }
        


        // -----------------------------------------------------------------------------------------------------------------------//
        public IActionResult AdvancedReport()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> ShowAdvancedReport( string fi , string ot )
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));

            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            
            // client.DefaultRequestHeaders.Add("App-Key", "13457");
            // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");

            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                factor_id = fi ,
                otp = ot ,
            };
            var response = await client.PostAsJsonAsync("tavanam/reports/advanced", data);
            var result =  await response.Content.ReadAsStringAsync();
            ViewBag.result =result;
            var myDeserializedClass = JsonConvert.DeserializeObject<Root2>(result); 
            Diposit();
            return View();
        }
        
        public class Root2
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }
    
            [JsonProperty("reason_codes")]
            public string ReasonCodes { get; set; }
    
            [JsonProperty("rate")]
            public string Rate { get; set; }
    
            [JsonProperty("rank")]
            public string Rank { get; set; }
    
            [JsonProperty("description")]
            public string Description { get; set; }
    
            [JsonProperty("report_file")]
            public List<int> ReportFile { get; set; }
    
            [JsonProperty("report_data")]
            public string ReportData { get; set; }
        }

    }
}