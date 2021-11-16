using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Admin.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using System;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Client_CredentialController  : BaseController
    {
        public Client_CredentialController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
      {
          
      }
        ///           انتخاب سرویس        ////////////////////////////////////////////////////
        public IActionResult Index()
        {
            return View();
        }
        ///          استعلام شماره کارت      ////////////////////////////////////////////
        public IActionResult InputCardNumber()
        {
            return View();
        }
        public IActionResult EstelamCartResult(vm_Gardesh Gardesh)
        {
           ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }


            try
            {
                var token=db.Tbl_TokenValues.SingleOrDefault().Token;
                var client = new RestClient("https://apibeta.finnotech.ir/mpg/v2/clients/nikatak5250/cards/" + Gardesh.Deposit + "");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+token);
                request.AddHeader("Cookie", "boomrangid=s%3A5UMXQjEUAWfS4xjbnVZ5L1RWyTHDFH0r.io8Qcr70CEa7%2FxvJWHKlogRpVsSwimeOVK1Mt0n9tu4");
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var EstelamCart = JsonConvert.DeserializeObject<RootEstelamCart>(response.Content);                         
                ViewBag.Description =EstelamCart.ResultEstelamCart.Description;
                ViewBag.DestCard =EstelamCart.ResultEstelamCart.DestCard;
                ViewBag.DoTime =EstelamCart.ResultEstelamCart.DoTime;
                ViewBag.Name =EstelamCart.ResultEstelamCart.Name;
                ///karmozd  
                if (EstelamCart.Status == "DONE")
                    {
                        Tbl_Request tb = new Tbl_Request
                        {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 500,
                            Titel_Request = "استعلام شماره کارت",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id =  Gardesh.Deposit,
                            Pay_Id = "استعلام شماره کارت",
                        };
                        db.Tbl_Requests.Add(tb);
                        db.SaveChanges();
                        var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                        proccess(500, qfinal.Id);
                    }
                Diposit();
            }
            catch (System.Exception ex)
            {
                ViewBag.Description ="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.DestCard ="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.DoTime ="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Name ="اطلاعاتی از سمت بانک دریافت نشد";
            }


            
            return View();
        }
        //                کلاس های دیسریالایز استعلام شماره کارت 
        public class ResultEstelamCart
        {
            [JsonProperty("destCard")]
            public string DestCard { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("result")]
            public string Result { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("doTime")]
            public string DoTime { get; set; }
        }

        public class RootEstelamCart
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultEstelamCart ResultEstelamCart { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
        ///////////////////////////////////////////////پایان استعلام شماره کارت//////////////////////////////////////////////////////////////
        ///                    تبدیل شماره کارت به شبا     ///////////////////////////////////////////////////
        public IActionResult CartToShaba()
        {
            return View();
        }
        public IActionResult CartToShabaResult (vm_Gardesh Gardesh)
        {
            ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }

            try
            {
                var token=db.Tbl_TokenValues.SingleOrDefault().Token;
                var client = new RestClient("https://apibeta.finnotech.ir/facility/v2/clients/nikatak5250/cardToIban?card=" + Gardesh.Deposit + "");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+token);
                request.AddHeader("Cookie", "boomrangid=s%3AM9Y3baYsL7KiuB9HZhS8AbrqpmHz7s9R.enqYkFKYMOf73ZKw4nSMS9xLbe1HINVRTwE2cVCeZIc");
                var body = @"";
                request.AddParameter("text/plain", body,  ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var CartShaba = JsonConvert.DeserializeObject<RootCartToShaba>(response.Content);
                var s=CartShaba.ResultCartToShaba;
                ViewBag.BankName=s.BankName;
                ViewBag.Card=s.Card;
                ViewBag.Deposit=s.Deposit;
                ViewBag.DepositDescription=s.DepositDescription;
                ViewBag.IBAN=s.IBAN;
                ViewBag.Name=s.DepositOwnersCartToShaba[0].FirstName;
                ViewBag.LastName=s.DepositOwnersCartToShaba[0].LastName;
                
                ///karmozd  
                if (CartShaba.Status == "DONE")
                    {
                        Tbl_Request tb = new Tbl_Request
                        {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 500,
                            Titel_Request = "تبدیل شماره کارت به شبا",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id =  Gardesh.Deposit,
                            Pay_Id = "تبدیل شماره کارت به شبا",
                        };
                        db.Tbl_Requests.Add(tb);
                        db.SaveChanges();
                        var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                        proccess(500, qfinal.Id);
                    }
                Diposit();
            }
            catch (System.Exception ex)
            {
                ViewBag.BankName="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Card="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Deposit="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.DepositDescription="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.IBAN="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Name="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.LastName="اطلاعاتی از سمت بانک دریافت نشد";
            }
            

            return View();
        }
        //                کلاس های دیسریالایز استعلام شماره کارت
        public class DepositOwnerCartToShaba
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }
        }

        public class ResultCartToShaba
        {
            [JsonProperty("IBAN")]
            public string IBAN { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("deposit")]
            public string Deposit { get; set; }

            [JsonProperty("card")]
            public string Card { get; set; }

            [JsonProperty("depositStatus")]
            public string DepositStatus { get; set; }

            [JsonProperty("depositDescription")]
            public string DepositDescription { get; set; }

            [JsonProperty("depositComment")]
            public string DepositComment { get; set; }

            [JsonProperty("depositOwners")]
            public List<DepositOwnerCartToShaba> DepositOwnersCartToShaba { get; set; }
        }

        public class RootCartToShaba
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultCartToShaba ResultCartToShaba { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
        ///////////////////////////////////////////////پایان تبدیل کارت به شبا //////////////////////////////////////////////////////////////
        ///                    استعلام شبا         ///////////////////////////////////////////////////
        public IActionResult EstelamShaba()
        {
            return View();
        }
        public IActionResult EstelamShabaResult (vm_Gardesh Gardesh)
        {
            ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }


            try
            {
                var token=db.Tbl_TokenValues.SingleOrDefault().Token;
                var client = new RestClient("https://apibeta.finnotech.ir/facility/v2/clients/nikatak5250/depositToIban?deposit="+Gardesh.Deposit+"&bankCode="+Gardesh.To+"");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+token);
                request.AddHeader("Cookie", "boomrangid=s%3AQb6IL1Thi0OgpfDht1c8_FUHstt3LHxu.ElfiIz7%2Bj2y6FVEjQyZxlVOHAT0C%2BKTaz5iN%2F122JnI");
                IRestResponse response = client.Execute(request);
                var CartShaba = JsonConvert.DeserializeObject<RootEstelamShaba>(response.Content);
                var s=CartShaba.ResultEstelamShaba;
                ViewBag.AccountStatus=s.AccountStatus;
                ViewBag.BankName=s.BankName;
                ViewBag.Deposit=s.Deposit;
                ViewBag.DepositOwners=s.DepositOwners;
                ViewBag.Iban=s.Iban;
                ///karmozd  
                if (CartShaba.Status == "DONE")
                    {
                        Tbl_Request tb = new Tbl_Request
                        {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 500,
                            Titel_Request = "تبدیل شماره شبا",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id =  Gardesh.Deposit,
                            Pay_Id = "تبدیل شماره شبا",
                        };
                        db.Tbl_Requests.Add(tb);
                        db.SaveChanges();
                        var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                        proccess(500, qfinal.Id);
                    }
                Diposit();
                
            }
            catch (System.Exception ex)
            {
                ViewBag.BankName="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Deposit="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.DepositOwners="اطلاعاتی از سمت بانک دریافت نشد";
                ViewBag.Iban="اطلاعاتی از سمت بانک دریافت نشد";
            }
            


            return View();
        }
         //                کلاس های دیسریالایز استعلام  شبا
                public class ResultEstelamShaba
                {
                    [JsonProperty("deposit")]
                    public string Deposit { get; set; }

                    [JsonProperty("accountStatus")]
                    public string AccountStatus { get; set; }

                    [JsonProperty("bankName")]
                    public string BankName { get; set; }

                    [JsonProperty("iban")]
                    public string Iban { get; set; }

                    [JsonProperty("depositOwners")]
                    public string DepositOwners { get; set; }
                }

                public class RootEstelamShaba
                {
                    [JsonProperty("trackId")]
                    public string TrackId { get; set; }

                    [JsonProperty("result")]
                    public ResultEstelamShaba ResultEstelamShaba { get; set; }

                    [JsonProperty("status")]
                    public string Status { get; set; }
                }
       
        ///////////////////////////////////////////////پایان تبدیل استعلام  شبا //////////////////////////////////////////////////////////////
        ///                    استعلام خلافی خودرو     ///////////////////////////////////////////////////
        public IActionResult EstelamCarBill()
        {
            return View();
        }
        public IActionResult EstelamCarBillResult (vm_Gardesh Gardesh)
        {
            ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }
            try
            {
                var token=db.Tbl_TokenValues.SingleOrDefault().Token;
                var client = new RestClient("https://apibeta.finnotech.ir/billing/v2/clients/nikatak5250/drivingOffense?parameter="+ Gardesh.To +"");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+token);
                request.AddHeader("Cookie", "boomrangid=s%3AM9Y3baYsL7KiuB9HZhS8AbrqpmHz7s9R.enqYkFKYMOf73ZKw4nSMS9xLbe1HINVRTwE2cVCeZIc");
                var body = @"";
                request.AddParameter("text/plain", body,  ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var Khelafi = JsonConvert.DeserializeObject<RootEstelamCarBill>(response.Content);
                var s=Khelafi.ResultEstelamCarBill;
                ViewBag.Pelak=s.PlateNumber;
                ViewBag.AmountPay=s.TotalAmount;
                var Result=s.BillsEstelamCarBill.ToList();
                ViewBag.Result=Result;
                ///karmozd
                        Tbl_Request tb = new Tbl_Request
                        {
                            UserName = User.Identity.GetId(),
                            Type_Request = "استعلام",
                            Amount = 500,
                            Titel_Request = "استعلام خلافی خودرو",
                            Date_Request = DateTime.UtcNow,
                            Bill_Id =  Gardesh.To,
                            Pay_Id = "استعلام خلافی خودرو",
                        };
                        db.Tbl_Requests.Add(tb);
                        db.SaveChanges();
                        var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                        proccess(500, qfinal.Id);
                Diposit();
            }
            catch (Exception ex)
            {
                ViewBag.Pelak="اطلاعاتی دریافت نشد";
                ViewBag.AmountPay="اطلاعاتی دریافت نشد";
                ViewBag.Msg="سرور با اختلال همراه هست";
            }
            return View();
        }
        //                کلاس های دیسریالایز استعلام خلافی خودرو
        public class BillEstelamCarBill
        {
            [JsonProperty("Amount")]
            public string Amount { get; set; }

            [JsonProperty("BillId")]
            public string BillId { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("Date")]
            public string Date { get; set; }

            [JsonProperty("DeliveryType")]
            public string DeliveryType { get; set; }

            [JsonProperty("Location")]
            public string Location { get; set; }

            [JsonProperty("PayId")]
            public string PayId { get; set; }

            [JsonProperty("Type")]
            public string Type { get; set; }
        }

        public class ResultEstelamCarBill
        {
            [JsonProperty("Bills")]
            public List<BillEstelamCarBill> BillsEstelamCarBill { get; set; }

            [JsonProperty("PlateNumber")]
            public string PlateNumber { get; set; }

            [JsonProperty("TotalAmount")]
            public string TotalAmount { get; set; }
        }

        public class RootEstelamCarBill
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultEstelamCarBill ResultEstelamCarBill { get; set; }
        }
        ///////////////////////////////////////////////پایان   استعلام خلافی خودرو   //////////////////////////////////////////////////////////////
        ///                    استعلام نمره منفی گواهینامه     ///////////////////////////////////////////////////
        public IActionResult EstelamNegativePoint()
        {
            return View();
        }
        public IActionResult EstelamNegativePointResult (vm_Gardesh Gardesh)
        {
            ///check mojodi
            if (check(500))
            {
                RedirectToAction("index","Wallet");
            }
            try
            {
                var token=db.Tbl_TokenValues.SingleOrDefault().Token;
                var client = new RestClient("https://apibeta.finnotech.ir/billing/v2/clients/nikatak5250/negativeScore?licenseNumber="+Gardesh.From+"");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer"+" "+token);
                request.AddHeader("Cookie", "boomrangid=s%3AM9Y3baYsL7KiuB9HZhS8AbrqpmHz7s9R.enqYkFKYMOf73ZKw4nSMS9xLbe1HINVRTwE2cVCeZIc");
                var body = @"";
                request.AddParameter("text/plain", body,  ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                var EstelamNegativePoint = JsonConvert.DeserializeObject<RootNegativePoint>(response.Content);
                ViewBag.LicenseNumber=EstelamNegativePoint.ResultNegativePoint.LicenseNumber;
                ViewBag.NegativeScore=EstelamNegativePoint.ResultNegativePoint.NegativeScore;
                ViewBag.OffenseCount=EstelamNegativePoint.ResultNegativePoint.OffenseCount;
                ///karmozd
                Tbl_Request tb = new Tbl_Request
                {
                    UserName = User.Identity.GetId(),
                    Type_Request = "استعلام",
                    Amount = 500,
                    Titel_Request = "استعلام نمره منفی گواهینامه",
                    Date_Request = DateTime.UtcNow,
                    Bill_Id =  Gardesh.From,
                    Pay_Id = "استعلام نمره منفی گواهینامه",
                };
                db.Tbl_Requests.Add(tb);
                db.SaveChanges();
                var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                proccess(500, qfinal.Id);
                Diposit();
            }
            catch (Exception ex)
            {
                ViewBag.LicenseNumber="اطلاعاتی دریافت نشد";
                ViewBag.NegativeScore="اطلاعاتی دریافت نشد";
                ViewBag.OffenseCount="اطلاعاتی دریافت نشد";
            }
            return View();
        }
        //   کلاس های دیسریالایز استعلام  نمره منفی گواهینامه 
        public class ResultNegativePoint
        {
            [JsonProperty("LicenseNumber")]
            public string LicenseNumber { get; set; }

            [JsonProperty("NegativeScore")]
            public string NegativeScore { get; set; }

            [JsonProperty("OffenseCount")]
            public string OffenseCount { get; set; }
        }
        public class RootNegativePoint
        {
            [JsonProperty("trackId")]
            public string TrackId { get; set; }

            [JsonProperty("result")]
            public ResultNegativePoint ResultNegativePoint { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }
        }
        ///////////////////////////////////////////////پایان   استعلام  نمره منفی گواهینامه   //////////////////////////////////////////////////////////////
    }
}
