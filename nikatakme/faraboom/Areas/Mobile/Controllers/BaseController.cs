using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using ViewModels;
using DataLayer.Context;
using DataLayer.AdminEntities;
using ZarinPal.Class;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.wallet;
using RestSharp;

namespace Mobile.Controllers
{
    [Area("Mobile")]
    public class BaseController : Controller
    {
        public static string mobile;
        public static string msg;
        public readonly Payment _payment;
        public readonly Authority _authority;
        public readonly Transactions _transactions;
        public readonly ContextHampadco db;
        public static int sumshop;
        public readonly IWebHostEnvironment _env;
        public BaseController(ContextHampadco _db, IWebHostEnvironment env)
        {
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            db = _db;
            _env = env;
        }
        public void Diposit()
        {
            int pay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId() && a.status == true).Sum(a => a.Pay);
            int harvest = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Harvest);
            HttpContext.Session.SetInt32("sum", (pay - harvest));



            int mypay = db.Tbl_Mypays.Where(a => a.UserName == User.Identity.GetId() && a.status == true).Sum(a => a.Pay);
            int myharvest = db.Tbl_Mypays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Harvest);
            HttpContext.Session.SetInt32("mysum", (mypay - myharvest));


            // اعتبار معرف
            var MyInvite=0;
            HttpContext.Session.SetInt32("MyInvite",MyInvite);

                        
            var user = db.Tbl_Users.Where(a => a.Phone == User.Identity.GetId()).SingleOrDefault();
            HttpContext.Session.SetString( "name" , ( user.Name + " " + user.Family ));
            HttpContext.Session.SetString( "photo" , user.Image );


        }
        public void proccess(int amount, int IdRequest)
        {
            Diposit();
            Tbl_pay A = new Tbl_pay()
            {
                UserName = User.Identity.GetId(),
                Harvest = amount,
                DateTime = DateTime.UtcNow,
                status = true,
                RequestId = IdRequest
            };
            db.Tbl_pays.Add(A);
            db.SaveChanges();
            Tbl_Mypay B = new Tbl_Mypay()
            {
                UserName = User.Identity.GetId(),
                Pay = (amount/2) * 60 / 100,
                DateTime = DateTime.UtcNow,
                status = true,
                RequestId = IdRequest
            };
            db.Tbl_Mypays.Add(B);
            db.SaveChanges();
        }
        //-------------دریافت توکن
        public string token()
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
            request.AddParameter("username", "ali.rafiee");
            request.AddParameter("password", "123456789");
            request.AddParameter("grant_type", "password");
            var response = client.Execute(request);
            var token = response.Content.Split(", ");
            var token1 = token[0].Split(":");
            var token2 = token1[1].Split(",");
            string token3 = token2[0].Replace("/", "").Replace("\"", "");
            return token3;
        }

        public bool check(int amount)
        {
          if (HttpContext.Session.GetInt32("sum") < (amount))
           {
               return true;
           }
           else
            {
                return false;
            }
        }
         
        ///process charge
        public void proccesscharge(int amount,int Orgprice, int IdRequest)
        {
            Diposit();
            Tbl_pay A = new Tbl_pay()
            {
                UserName = User.Identity.GetId(),
                Harvest = amount,
                DateTime = DateTime.UtcNow,
                status = true,
                RequestId = IdRequest
            };
            db.Tbl_pays.Add(A);
            db.SaveChanges();
            Tbl_Mypay B = new Tbl_Mypay()
            {
                UserName = User.Identity.GetId(),
                Pay =Convert.ToInt32(Math.Round((Orgprice*0.03)*0.6)),
                DateTime = DateTime.UtcNow,
                status = true,
                RequestId = IdRequest
            };
            db.Tbl_Mypays.Add(B);
            db.SaveChanges();
        }
    }
}