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
using System.Text;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.Request;
using faraboom.Models;

namespace Kasabeyar.Controllers
{   
    [Area("Kasabeyar")]
    [Authorize]
    public class HoviyatController : BaseController
    {
        public HoviyatController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {

        }
        ///   برای دریافت شماره موبایل
        public IActionResult Index()
        {
            Diposit();
            return View();
        }
        /// ارسال sms برای دریافت کد اولیه
        public IActionResult SendSms(vm_Sms Sms)
        {
            ///check mojodi
            if (check(2000))
            {
                RedirectToAction("index","Wallet");
            }
            var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/authorize?client_id=nikatak5250&response_type=code&redirect_uri=https://nikatak.ir/verify&scope=facility:sms-nid-verification:get&mobile="+Sms.Phone+"&auth_type=SMS");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
            request.AddHeader("Cookie", "boomrangid=s%3AEJpaFQ86elckKKhVVHSNxNLmSSuel_sP.DX754OiDsPERcSReMKEaEZE8Eo9d9MLWWPFqon%2B4YSc");
            IRestResponse response = client.Execute(request);
            var value = JsonConvert.DeserializeObject<RootSendSms>(response.Content);
            var TId=value.ResultSendSms.TrackId;
            HttpContext.Session.SetString("TrackId",TId);
            HttpContext.Session.SetString("Phone",Sms.Phone);
            HttpContext.Session.SetString("NationalCode",Sms.NationalCode);
            HttpContext.Session.SetString("FullName",Sms.FullName);
            HttpContext.Session.SetString("Name",Sms.Name);
            HttpContext.Session.SetString("Family",Sms.Family);
            HttpContext.Session.SetString("FatherName",Sms.FatherName);
            HttpContext.Session.SetString("Gender",Sms.Gender);
            HttpContext.Session.SetString("BirthFate",Sms.BirthDate);
            Diposit();
            return View();
        }
        // برای دیسریالایز کد دریافتی
        public class ResultSendSms
        {
            [JsonProperty("smsSent")]
            public bool SmsSent { get; set; }

            [JsonProperty("trackId")]
            public string TrackId { get; set; }
        }
        public class RootSendSms
        {
            [JsonProperty("result")]
            public ResultSendSms ResultSendSms { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
        /// ارسال  برای دریافت کد دوم
        public IActionResult CodeTwo(vm_Sms Sms)
        {
            try
            {
                var P=HttpContext.Session.GetString("Phone");
                var T=HttpContext.Session.GetString("TrackId");
                var N=HttpContext.Session.GetString("NationalCode");
                var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/verify/sms");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", "boomrangid=s%3AEJpaFQ86elckKKhVVHSNxNLmSSuel_sP.DX754OiDsPERcSReMKEaEZE8Eo9d9MLWWPFqon%2B4YSc");
                var body =
                "{" +
                "\"mobile\":\""+P+"\","
                + "\"otp\":\"" + Sms.CodeOne + "\","
                 + "\"nid\":\"" +N+ "\","
                  + "\"trackId\":\""+T+"\""
                + "}";
                request.AddParameter("application/json", body,  ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var value1 = JsonConvert.DeserializeObject<Rootcodetwo>(response.Content);
                HttpContext.Session.SetString("CodeTwo",value1.Resultcodetwo.Code);
                return RedirectToAction("TakeToken");
            }
            catch (System.Exception ex)
            {
                var msg="عدم تطابق کد ارسالی";
                HttpContext.Session.SetString("message" , msg);
                return RedirectToAction("Index");
            }
            
        }
        // کلاس های دیسریالایز کد دوم
        public class Resultcodetwo
        {
            [JsonProperty("code")]
            public string Code { get; set; }
        }

        public class Rootcodetwo
        {
            [JsonProperty("result")]
            public Resultcodetwo Resultcodetwo { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
        /// ارسال  برای دریافت توکن 
        public IActionResult TakeToken()
        {
            Diposit();
            var c2=HttpContext.Session.GetString("CodeTwo");
            var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
            request.AddHeader("Cookie", "boomrangid=s%3AEJpaFQ86elckKKhVVHSNxNLmSSuel_sP.DX754OiDsPERcSReMKEaEZE8Eo9d9MLWWPFqon%2B4YSc");
            var body ="{" +
                "\"grant_type\":\"authorization_code\","
                + "\"code\":\"" + c2 + "\","
                 + "\"auth_type\":\"SMS\","
                  + "\"redirect_uri\":\"https://nikatak.ir/verify\""
                + "}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var value2 = JsonConvert.DeserializeObject<RootTakeToken>(response.Content);
            var sd=value2.ResultTakeToken.Value;
            HttpContext.Session.SetString("Token",sd);
            return RedirectToAction("Result");
        }
        // دیسزیالایز برای دریاقت توکن
        public class ResultTakeToken
        {
            [JsonProperty("clientId")]
            public string ClientId { get; set; }
    
            [JsonProperty("scopes")]
            public List<string> Scopes { get; set; }
    
            [JsonProperty("lifeTime")]
            public string LifeTime { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("creationDate")]
            public string CreationDate { get; set; }
    
            [JsonProperty("userId")]
            public string UserId { get; set; }
    
            [JsonProperty("auth_type")]
            public string AuthType { get; set; }
    
            [JsonProperty("refreshToken")]
            public string RefreshToken { get; set; }
    
            [JsonProperty("bank")]
            public string Bank { get; set; }
    
            [JsonProperty("value")]
            public string Value { get; set; }
        }
    
        public class RootTakeToken
        {
            [JsonProperty("result")]
            public ResultTakeToken ResultTakeToken { get; set; }
    
            [JsonProperty("status")]
            public string Status { get; set; }
        }
        /// ارسال  برای دریافت اطلاعات
        public IActionResult Result()
        {
            var VarNid=HttpContext.Session.GetString("NationalCode");
            var Tkn=HttpContext.Session.GetString("Token");
            var FullName=HttpContext.Session.GetString("FullName");
            var Name=HttpContext.Session.GetString("Name");
            var Family=HttpContext.Session.GetString("Family");
            var FatherName=HttpContext.Session.GetString("FatherName");
            var Gender=HttpContext.Session.GetString("Gender");
            var BirthDate=HttpContext.Session.GetString("BirthFate");
            // convert to encode

            UTF8Encoding enc = new UTF8Encoding();
            //   send to parametr value
            try
            {
                var client = new RestClient("https://apibeta.finnotech.ir/facility/v2/clients/nikatak5250/users/"+VarNid+"/sms/nidVerification?birthDate="+BirthDate+"&gender="+Gender+"&fullName="+FullName+"&firstName="+Name+"&lastName="+Family+"&fatherName="+FatherName+"");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+Tkn );
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Cookie", "boomrangid=s%3AhBz2nAEDNI4pVXLRXFyp-oERSyR8Vknc.fTe6631CEnU1NpschCYbIcJZ3ZTbz7fKCn3vT763qG8");
                IRestResponse response = client.Execute(request);
                var value3 = JsonConvert.DeserializeObject<RootResult>(response.Content);
                if (value3.ResultResult.FatherName == null)
                {
                    ViewBag.msg="عدم تطابق کد ملی و تاریخ تولد(چنین شخصی موجودیت نمی باشد)";
                }
                else
                {
                    ViewBag.FatherName=value3.ResultResult.FatherName;
                    ViewBag.FirstName=value3.ResultResult.FirstName;
                    ViewBag.FullName=value3.ResultResult.FullName;
                    ViewBag.Gender=value3.ResultResult.Gender;
                    ViewBag.LastName=value3.ResultResult.LastName;
                    ViewBag.BirthDate=value3.ResultResult.BirthDate;
                    ViewBag.NationalCode=value3.ResultResult.NationalCode;
                    ViewBag.FirstNameSimilarity=value3.ResultResult.FirstNameSimilarity;
                    ViewBag.LastNameSimilarity=value3.ResultResult.LastNameSimilarity;
                    ViewBag.FatherNameSimilarity=value3.ResultResult.FatherNameSimilarity;
                    ViewBag.FullNameSimilarity=value3.ResultResult.FullNameSimilarity;
                    ViewBag.GenderSimilarity=value3.ResultResult.GenderSimilarity;
                    ViewBag.DeathStatus=value3.ResultResult.DeathStatus;
                    ViewBag.msgfull="نمایش میزان تطابق احراز هویت انجام شده ";
                }
                ///karmozd
                Tbl_Request tb = new Tbl_Request
                {
                    UserName = User.Identity.GetId(),
                    Type_Request = "احراز هویت",
                    Amount = 2000,
                    Titel_Request = "احراز هویت",
                    Date_Request = DateTime.UtcNow,
                    Bill_Id = VarNid,
                    Pay_Id ="احراز هویت",
                };
                db.Tbl_Requests.Add(tb);
                db.SaveChanges();
                var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                proccess(2000, qfinal.Id);
            }
            catch (System.Exception ex)
            {
                ViewBag.msg="پاسخی دریافت نشد.";
            }

            Diposit();
            return View();
        }
        // دیسزیالایز برای دریاقت result
        public class ResultResult
        {
            [JsonProperty("nationalCode")]
            public string NationalCode { get; set; }

            [JsonProperty("birthDate")]
            public string BirthDate { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("firstNameSimilarity")]
            public double FirstNameSimilarity { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("lastNameSimilarity")]
            public double LastNameSimilarity { get; set; }

            [JsonProperty("fullName")]
            public string FullName { get; set; }

            [JsonProperty("fullNameSimilarity")]
            public double FullNameSimilarity { get; set; }

            [JsonProperty("fatherName")]
            public string FatherName { get; set; }

            [JsonProperty("fatherNameSimilarity")]
            public double FatherNameSimilarity { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("genderSimilarity")]
            public double GenderSimilarity { get; set; }

            [JsonProperty("deathStatus")]
            public string DeathStatus { get; set; }
        }

        public class RootResult
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultResult ResultResult { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
                
    }
}