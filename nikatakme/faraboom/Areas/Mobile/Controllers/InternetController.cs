using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Request;
using DataLayer.AdminEntities.wallet;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceReference1;
using ViewModels.AdminViewModel.Charge;
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
using ServiceReference;

namespace Mobile.Controllers
{
    [Area ("Mobile")]

    public class InternetController : BaseController
    {
        public InternetController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env){}
        public IActionResult SelectOperator()
        {
            return View();
        }
        ///     رایتل صفحه گرفتن پارامتر ها
        public IActionResult ParametrsRightel()
        {
            return View();
        }
        ///     ایرانسل صفحه گرفتن پارامتر ها
        public IActionResult ParametrsMTN()
        {
            return View();
        }
        ///     همراه اول صفحه گرفتن پارامتر ها
        public IActionResult ParametrsMCI()
        {
            return View();
        }
        ///     شاتل صفحه گرفتن پارامتر ها
        public IActionResult ParametrsShatel()
        {
            return View();
        }
        ///   رایتل صفحه جستوجو بسته ها   
        public IActionResult Rightel(Vm_Charge charge)
        {
            int Rn;
            var R=new Random();
            Rn=R.Next(100000, 999999);
            PackageInqClient client = new PackageInqClient();
            ///     ارسال پارمتر ها
            var result=client.RightelPackageInquiryAsync
            (new ServiceReference1.RequestModel
            {
                    ///// یوزر-
                    Username="nikatakuser",
                    ///// پس-
                    Password="n!K@T@k",
                    ///// تاریخ-
                    LocalDateTime=DateTime.Now,
                    ///// شماره تماس-
                    CellNumber=charge.CellNumber,
                    // ///منحصر بفرد
                    ReserveNumber=Rn,
                    //// نوع شارژ-
                    ChargeType=charge.ChargeType,
                }
            ).Result;
            if (result.Status==true)
            {
               ViewBag.package = JsonConvert.DeserializeObject<List<MyArray>>(result.ReturnMsg);
               HttpContext.Session.SetInt32("Rn",Rn);
               HttpContext.Session.SetString("CellNumber",charge.CellNumber);
               if (result.AdditionalData != null)
               {
                   HttpContext.Session.SetString("AdditionalData",result.AdditionalData);
               }
            }
            else
            {
                ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش کنید";
            }
            
            ///    بستن سرویس
            client.Close();
            return View();
        }
        ///   ایرانسل صفحه جستوجو بسته ها   
        public IActionResult MTN(Vm_Charge charge)
        {
            int Rn;
            var R=new Random();
            Rn=R.Next(100000, 999999);
            PackageInqClient client = new PackageInqClient();
            ///     ارسال پارمتر ها
            var result=client.MTNPackageInquiryAsync
            (new ServiceReference1.RequestModel
            {
                    ///// یوزر-
                    Username="nikatakuser",
                    ///// پس-
                    Password="n!K@T@k",
                    ///// تاریخ-
                    LocalDateTime=DateTime.Now,
                    ///// شماره تماس-
                    CellNumber=charge.CellNumber,
                    // ///منحصر بفرد
                    ReserveNumber=Rn,
                    //// نوع شارژ-
                    ChargeType=charge.ChargeType,
                }
            ).Result;
            if (result.Status==true)
            {
               ViewBag.package = JsonConvert.DeserializeObject<List<MyArray>>(result.ReturnMsg);
               HttpContext.Session.SetInt32("Rn",Rn);
               HttpContext.Session.SetString("CellNumber",charge.CellNumber);
               if (result.AdditionalData != "")
               {
                   HttpContext.Session.SetString("AdditionalData",result.AdditionalData);
               }
            }
            else
            {
                ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش کنید";
            }
            
            ///    بستن سرویس
            client.Close();
            return View();
        }
        ///   همراه اول صفحه جستوجو بسته ها   
        public IActionResult MCI(Vm_Charge charge)
        {
            int Rn;
            var R=new Random();
            Rn=R.Next(100000, 999999);
            PackageInqClient client = new PackageInqClient();
            ///     ارسال پارمتر ها
            var result=client.MCIPackageInquiryAsync
            (new ServiceReference1.RequestModel
            {
                    ///// یوزر-
                    Username="nikatakuser",
                    ///// پس-
                    Password="n!K@T@k",
                    ///// تاریخ-
                    LocalDateTime=DateTime.Now,
                    ///// شماره تماس-
                    CellNumber=charge.CellNumber,
                    // ///منحصر بفرد
                    ReserveNumber=Rn,
                    //// نوع شارژ-
                    ChargeType=charge.ChargeType,
                }
            ).Result;
            if (result.Status==true)
            {
               ViewBag.package = JsonConvert.DeserializeObject<List<MyArray>>(result.ReturnMsg);
               HttpContext.Session.SetInt32("Rn",Rn);
               HttpContext.Session.SetString("CellNumber",charge.CellNumber);
               if (result.AdditionalData != "")
               {
                   HttpContext.Session.SetString("AdditionalData",result.AdditionalData);
               }
            }
            else
            {
                ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش کنید";
            }
            
            ///    بستن سرویس
            client.Close();
            return View();
        }
        ///   شاتل صفحه جستوجو بسته ها   
        public IActionResult Shatel(Vm_Charge charge)
        {
            int Rn;
            var R=new Random();
            Rn=R.Next(100000, 999999);
            PackageInqClient client = new PackageInqClient();
            ///     ارسال پارمتر ها
            var result=client.ShatelPackageInquiryAsync
            (new ServiceReference1.RequestModel
            {
                    ///// یوزر-
                    Username="nikatakuser",
                    ///// پس-
                    Password="n!K@T@k",
                    ///// تاریخ-
                    LocalDateTime=DateTime.Now,
                    ///// شماره تماس-
                    CellNumber=charge.CellNumber,
                    // ///منحصر بفرد
                    ReserveNumber=Rn,
                    //// نوع شارژ-
                    ChargeType=charge.ChargeType,
                }
            ).Result;
            if (result.Status==true)
            {
               ViewBag.package = JsonConvert.DeserializeObject<List<MyArray>>(result.ReturnMsg);
               HttpContext.Session.SetInt32("Rn",Rn);
               HttpContext.Session.SetString("CellNumber",charge.CellNumber);
               if (result.AdditionalData != null)
               {
                   HttpContext.Session.SetString("AdditionalData",result.AdditionalData);
               }
            }
            else
            {
                ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش کنید";
            }
            
            ///    بستن سرویس
            client.Close();
            return View();
        }
        public IActionResult BuyRightel(int ChargeType, decimal AffAmount,string Title,decimal OrgAmount)
        {
            //check mojodi
            if (HttpContext.Session.GetInt32("sum") >= (Convert.ToInt32(AffAmount)/10))
            {
                try
                {
                    var ReserveNumber=Convert.ToInt64(HttpContext.Session.GetInt32("Rn"));
                    var CellNumber=HttpContext.Session.GetString("CellNumber");
                    var price=Convert.ToInt32(AffAmount)/10;
                    var Orgprice=Convert.ToInt32(OrgAmount)/10;

                    ChargeSrvClient client = new ChargeSrvClient();
                    var result=client.ReserveInternetPackageAsync
                        (new ServiceReference.RequestModel
                        {
                                ///// یوزر-
                                Username="nikatakuser",
                                ///// پس-
                                Password="n!K@T@k",
                                ///// تاریخ-
                                LocalDateTime=DateTime.Now,
                                ReserveNumber=ReserveNumber,
                                CellNumber=CellNumber,
                                DeviceType=05,
                                ChargeType=ChargeType,
                                AdditionalData=HttpContext.Session.GetString("AdditionalData"),
                                OperatorId=3,

                            }
                        ).Result;
                        if (result.Status==true)
                        {
                            ///    چک کردن پارامتر ها و اعمال شارژ
                            var SendRefrense=client.ApproveAsync
                            (new ServiceReference.RequestModel
                                {
                                    Username="nikatakuser",
                                    Password="n!K@T@k",
                                    LocalDateTime=DateTime.Now,
                                    ReserveNumber=result.ReserveNumber,
                                    ReferenceNumber=result.ReferenceNumber,
                                }
                            ).Result;
                            if (SendRefrense.Status==true)
                            {
                            /// pay Fish
                                Tbl_Request tb1 = new Tbl_Request
                                {
                                    UserName = User.Identity.GetId(),
                                    Type_Request = "خرید بسته اینترنتی رایتل"+" "+ Title,
                                    Bill_Id = Convert.ToString(result.ReserveNumber),
                                    Pay_Id = Convert.ToString(result.ReferenceNumber),
                                    Amount =price,
                                    Titel_Request =CellNumber,
                                    Date_Request = DateTime.UtcNow,
                                };
                                db.Tbl_Requests.Add(tb1);
                                db.SaveChanges();
                                var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                Diposit();
                                proccesscharge(price,Orgprice, qfinal1.Id);
                                ViewBag.mesage="خرید بسته اینترنتی با موفقیت انجام شد";
                                ViewBag.LocalDateTime=SendRefrense.LocalDateTime;
                                ViewBag.Operator=SendRefrense.Operator;
                                ViewBag.ReferenceNumber=SendRefrense.ReferenceNumber;
                                ViewBag.ReserveNumber=SendRefrense.ReserveNumber;
                                ViewBag.ReturnMsg=SendRefrense.ReturnMsg;
                                ViewBag.CellNumber=CellNumber;
                                ViewBag.TotalAmount=price;
                            }
                            else
                            {
                                ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا تلاش کنید";
                            }
                        }
                        else
                        {
                            ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا تلاش کنید";
                        }
                        ///    بستن سرویس
                        client.Close();
                }
                catch (System.Exception ex)
                {
                    ViewBag.mesagee = " خطا در پارامتر های ورودی .";
                }
            }
            else
            {
                ViewBag.mesagee = " موجودی کیف پول شما کافی نمیباشد .";
            }
            return View();
        }
        public IActionResult BuyMTN(int ChargeType, decimal AffAmount,string Title,decimal OrgAmount)
        {
            //check mojodi
            if (HttpContext.Session.GetInt32("sum") >= (Convert.ToInt32(AffAmount)/10))
            {
                try
                {
                    var ReserveNumber=Convert.ToInt64(HttpContext.Session.GetInt32("Rn"));
                    var CellNumber=HttpContext.Session.GetString("CellNumber");
                    var price=Convert.ToInt32(AffAmount)/10;
                    var Orgprice=Convert.ToInt32(OrgAmount)/10;

                    ChargeSrvClient client = new ChargeSrvClient();
                    var result=client.ReserveInternetPackageAsync
                        (new ServiceReference.RequestModel
                        {
                                ///// یوزر-
                                Username="nikatakuser",
                                ///// پس-
                                Password="n!K@T@k",
                                ///// تاریخ-
                                LocalDateTime=DateTime.Now,
                                ReserveNumber=ReserveNumber,
                                CellNumber=CellNumber,
                                DeviceType=05,
                                ChargeType=ChargeType,
                                AdditionalData=HttpContext.Session.GetString("AdditionalData"),
                                OperatorId=2,

                            }
                        ).Result;
                        if (result.Status==true)
                        {
                            ///    چک کردن پارامتر ها و اعمال شارژ
                            var SendRefrense=client.ApproveAsync
                            (new ServiceReference.RequestModel
                                {
                                    Username="nikatakuser",
                                    Password="n!K@T@k",
                                    LocalDateTime=DateTime.Now,
                                    ReserveNumber=result.ReserveNumber,
                                    ReferenceNumber=result.ReferenceNumber,
                                }
                            ).Result;
                            if (SendRefrense.Status==true)
                            {
                            /// pay Fish
                                Tbl_Request tb1 = new Tbl_Request
                                {
                                    UserName = User.Identity.GetId(),
                                    Type_Request = "خرید بسته اینترنتی ایرانسل"+" "+ Title,
                                    Bill_Id = Convert.ToString(result.ReserveNumber),
                                    Pay_Id = Convert.ToString(result.ReferenceNumber),
                                    Amount =price,
                                    Titel_Request =CellNumber,
                                    Date_Request = DateTime.UtcNow,
                                };
                                db.Tbl_Requests.Add(tb1);
                                db.SaveChanges();
                                var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                Diposit();
                                proccesscharge(price,Orgprice, qfinal1.Id);
                                ViewBag.mesage="خرید بسته اینترنتی با موفقیت انجام شد";
                                ViewBag.LocalDateTime=SendRefrense.LocalDateTime;
                                ViewBag.Operator=SendRefrense.Operator;
                                ViewBag.ReferenceNumber=SendRefrense.ReferenceNumber;
                                ViewBag.ReserveNumber=SendRefrense.ReserveNumber;
                                ViewBag.ReturnMsg=SendRefrense.ReturnMsg;
                                ViewBag.CellNumber=CellNumber;
                                ViewBag.TotalAmount=price;
                            }
                            else
                            {
                                ViewBag.mesagee="شارژ ناموفق مجددا امتحان کنید";
                            }
                        }
                        else
                        {
                            ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا تلاش کنید";
                        }
                        ///    بستن سرویس
                        client.Close();
                }
                catch (System.Exception ex)
                {
                    ViewBag.mesagee = " خطا در پارامتر های ورودی .";
                }
            }
            else
            {
                ViewBag.mesagee = " موجودی کیف پول شما کافی نمیباشد .";
            }
            return View();
        }
        public IActionResult BuyMCI(int ChargeType, decimal AffAmount,string Title,decimal OrgAmount)
        {
            //check mojodi
            if (HttpContext.Session.GetInt32("sum") >= (Convert.ToInt32(AffAmount)/10))
            {
                try
                {
                    var ReserveNumber=Convert.ToInt64(HttpContext.Session.GetInt32("Rn"));
                    var CellNumber=HttpContext.Session.GetString("CellNumber");
                    var price=Convert.ToInt32(AffAmount)/10;
                    var Orgprice=Convert.ToInt32(OrgAmount)/10;

                    ChargeSrvClient client = new ChargeSrvClient();
                    var result=client.ReserveInternetPackageAsync
                        (new ServiceReference.RequestModel
                        {
                                ///// یوزر-
                                Username="nikatakuser",
                                ///// پس-
                                Password="n!K@T@k",
                                ///// تاریخ-
                                LocalDateTime=DateTime.Now,
                                ReserveNumber=ReserveNumber,
                                CellNumber=CellNumber,
                                DeviceType=05,
                                ChargeType=ChargeType,
                                AdditionalData=HttpContext.Session.GetString("AdditionalData"),
                                OperatorId=1,

                            }
                        ).Result;
                        if (result.Status==true)
                        {
                            ///    چک کردن پارامتر ها و اعمال شارژ
                            var SendRefrense=client.ApproveAsync
                            (new ServiceReference.RequestModel
                                {
                                    Username="nikatakuser",
                                    Password="n!K@T@k",
                                    LocalDateTime=DateTime.Now,
                                    ReserveNumber=result.ReserveNumber,
                                    ReferenceNumber=result.ReferenceNumber,
                                }
                            ).Result;
                            if (SendRefrense.Status==true)
                            {
                                /// pay Fish
                                Tbl_Request tb1 = new Tbl_Request
                                {
                                    UserName = User.Identity.GetId(),
                                    Type_Request = "خرید بسته اینترنتی همراه اول"+" "+ Title,
                                    Bill_Id = Convert.ToString(result.ReserveNumber),
                                    Pay_Id = Convert.ToString(result.ReferenceNumber),
                                    Amount =price,
                                    Titel_Request =CellNumber,
                                    Date_Request = DateTime.UtcNow,
                                };
                                db.Tbl_Requests.Add(tb1);
                                db.SaveChanges();
                                var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                Diposit();
                                proccesscharge(price,Orgprice, qfinal1.Id);
                                ViewBag.mesage="خرید بسته اینترنتی با موفقیت انجام شد";
                                ViewBag.LocalDateTime=SendRefrense.LocalDateTime;
                                ViewBag.Operator=SendRefrense.Operator;
                                ViewBag.ReferenceNumber=SendRefrense.ReferenceNumber;
                                ViewBag.ReserveNumber=SendRefrense.ReserveNumber;
                                ViewBag.ReturnMsg=SendRefrense.ReturnMsg;
                                ViewBag.CellNumber=CellNumber;
                                ViewBag.TotalAmount=price;
                            }
                            else
                            {
                                ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا تلاش کنید";
                            }
                        }
                        else
                        {
                            ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا تلاش کنید";
                        }
                        ///    بستن سرویس
                        client.Close();
                }
                catch (System.Exception ex)
                {
                    ViewBag.mesagee = " خطا در پارامتر های ورودی .";
                }
            }
            else
            {
                ViewBag.mesagee = " موجودی کیف پول شما کافی نمیباشد .";
            }
            return View();
        }
        public IActionResult BuyShatel(int ChargeType, decimal AffAmount,string Title,decimal OrgAmount)
        {
            //check mojodi
            if (HttpContext.Session.GetInt32("sum") >= (Convert.ToInt32(AffAmount)/10))
            {
                try
                {
                    var ReserveNumber=Convert.ToInt64(HttpContext.Session.GetInt32("Rn"));
                    var CellNumber=HttpContext.Session.GetString("CellNumber");
                    var price=Convert.ToInt32(AffAmount)/10;
                    var Orgprice=Convert.ToInt32(OrgAmount)/10;

                    ChargeSrvClient client = new ChargeSrvClient();
                    var result=client.ReserveInternetPackageAsync
                        (new ServiceReference.RequestModel
                        {
                                ///// یوزر-
                                Username="nikatakuser",
                                ///// پس-
                                Password="n!K@T@k",
                                ///// تاریخ-
                                LocalDateTime=DateTime.Now,
                                ReserveNumber=ReserveNumber,
                                CellNumber=CellNumber,
                                DeviceType=05,
                                ChargeType=ChargeType,
                                AdditionalData=HttpContext.Session.GetString("AdditionalData"),
                                OperatorId=1,

                            }
                        ).Result;
                        if (result.Status==true)
                        {
                            ///    چک کردن پارامتر ها و اعمال شارژ
                            var SendRefrense=client.ApproveAsync
                            (new ServiceReference.RequestModel
                                {
                                    Username="nikatakuser",
                                    Password="n!K@T@k",
                                    LocalDateTime=DateTime.Now,
                                    ReserveNumber=result.ReserveNumber,
                                    ReferenceNumber=result.ReferenceNumber,
                                }
                            ).Result;
                            if (SendRefrense.Status==true)
                            {
                                /// pay Fish
                                Tbl_Request tb1 = new Tbl_Request
                                {
                                    UserName = User.Identity.GetId(),
                                    Type_Request = "خرید بسته اینترنتی شاتل"+" "+ Title,
                                    Bill_Id = Convert.ToString(result.ReserveNumber),
                                    Pay_Id = Convert.ToString(result.ReferenceNumber),
                                    Amount =price,
                                    Titel_Request =CellNumber,
                                    Date_Request = DateTime.UtcNow,
                                };
                                db.Tbl_Requests.Add(tb1);
                                db.SaveChanges();
                                var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                Diposit();
                                proccesscharge(price,Orgprice, qfinal1.Id);
                                ViewBag.mesage="خرید بسته اینترنتی با موفقیت انجام شد";
                                ViewBag.LocalDateTime=SendRefrense.LocalDateTime;
                                ViewBag.Operator=SendRefrense.Operator;
                                ViewBag.ReferenceNumber=SendRefrense.ReferenceNumber;
                                ViewBag.ReserveNumber=SendRefrense.ReserveNumber;
                                ViewBag.ReturnMsg=SendRefrense.ReturnMsg;
                                ViewBag.CellNumber=CellNumber;
                                ViewBag.TotalAmount=price;
                            }
                            else
                            {
                                ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا امتحان کنید";
                            }
                        }
                        else
                        {
                            ViewBag.mesagee="خرید بسته اینترنتی ناموفق ، مجددا امتحان کنید";
                        }
                        ///    بستن سرویس
                        client.Close();
                }
                catch (System.Exception ex)
                {
                    ViewBag.mesagee = " خطا در پارامتر های ورودی .";
                }
            }
            else
            {
                ViewBag.mesagee = " موجودی کیف پول شما کافی نمیباشد .";
            }
            return View();
        }


        public IActionResult index()
        {
            return View();
        }
        
        // دیسریالایز بسته های موجود اینترنتی
        public class MyArray
        {
            [JsonProperty("ch_type")]
            public string ChType { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("org_amount")]
            public string OrgAmount { get; set; }

            [JsonProperty("aff_amount")]
            public string AffAmount { get; set; }

            [JsonProperty("caption")]
            public string Caption { get; set; }

            [JsonProperty("trafic")]
            public string Trafic { get; set; }

            [JsonProperty("expiry")]
            public string Expiry { get; set; }
        }
    }
}