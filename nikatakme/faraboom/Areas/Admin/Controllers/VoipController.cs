using System.Net.Cache;
using System.Runtime.CompilerServices;
using System;
using System.Linq;
using System.Threading.Tasks;
using Admin.Controllers;
using DataLayer.Context;
using DataLayer.AdminEntities.Voip;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using faraboom.Models;
using ViewModels.AdminViewModel.Voip;
using Microsoft.AspNetCore.Http;
using System.IO;
using DataLayer.AdminEntities.wallet;
using DataLayer.AdminEntities.Request;
using System.Collections.Generic;
using Extensions;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;


namespace faraboom.Areas.Admin.Controllers
{
    public class VoipController : BaseController
    {
        public static string  msg  ;
        public VoipController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
    
        public IActionResult Index()
        {
            Diposit();

            var gold = db.Tbl_VoipNumbers.Where( a => a.Rezerve == "0" && a.UserId == null && a.UserName == null && a.Type == "طلایی" ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            ViewBag.gold = gold ;

            var silver = db.Tbl_VoipNumbers.Where( a => a.Rezerve == "0" && a.UserId == null && a.UserName == null && a.Type == "نقره ای" ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            ViewBag.silver = silver ;

            var bronze = db.Tbl_VoipNumbers.Where( a => a.Rezerve == "0" && a.UserId == null && a.UserName == null && a.Type == "برنزی" ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            ViewBag.bronze = bronze ;

            var normal = db.Tbl_VoipNumbers.Where( a => a.Rezerve == "0" && a.UserId == null && a.UserName == null && a.Type == "معمولی" ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            ViewBag.normal = normal ;

            return View();
        }
        //--------------------------------------------------------------------------------------------------------//
        //--------------------------------------------------------------------------------------------------------//

        public IActionResult AddNumCode()
        {
            Diposit();
            return View();
        }

        public async Task<IActionResult> CheckShahkar( Vm_VoipUser vvu)
        {
            var qusercheck = db.Tbl_VoipUsers.Where( a => a.CM_Code == vvu.CM_Code ).SingleOrDefault();
            if ( qusercheck == null )
            {
                var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
                // var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
                var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
                client.DefaultRequestHeaders.AcceptLanguage.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
                // client.DefaultRequestHeaders.Add("App-Key", "13457");
                // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
                // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
                client.DefaultRequestHeaders.Add("App-Key", "13075");
                client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
                client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
                client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
                client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
                client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
                client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09120000000");
                client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");
                var data = new
                {
                    national_code = vvu.CM_Code,
                    mobile = vvu.Mobile,
                };
                var response = await client.PostAsJsonAsync("mobile/national-code", data);
                if (response.IsSuccessStatusCode == true)
                {
                    if (HttpContext.Session.GetInt32("sum") >= 550)
                    {
                        Tbl_Request tb = new Tbl_Request
                        {
                            UserName = User.Identity.GetId(),
                            Type_Request = "سامانه شاهکار",
                            Bill_Id = vvu.CM_Code,
                            Pay_Id = vvu.Mobile,
                            Amount = 550,
                            Titel_Request = "تطبیق کدملی و شماره تلفن همراه",
                            Date_Request = DateTime.UtcNow,
                        };
                        db.Tbl_Requests.Add(tb);
                        db.SaveChanges();
                        var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                        proccess(550, qfinal.Id);
                        var result = await response.Content.ReadAsStringAsync();
                        var desclass = JsonConvert.DeserializeObject<RootShahkar>(result);
                        if (desclass.Match == true)
                        {
                            ViewBag.resultok = " شماره تلفن با کد ملی مطابقت دارد . ";
                        }
                        else
                        {
                            ViewBag.resulter = " شماره تلفن با کد ملی مطابقت ندارد . ";
                        }
                    }
                    else
                    {
                        ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                    }
                }
                else
                {
                    ViewBag.result = await response.Content.ReadAsStringAsync();
                }
            }
            else
            {
                ViewBag.msguser = vvu.CM_Code ;
            }
            Diposit();
            ViewBag.CM_Code = vvu.CM_Code ;
            ViewBag.Mobile = vvu.Mobile ;
            return View();
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class RootShahkar
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }

            [JsonProperty("match")]
            public bool Match { get; set; }
        }

        public async Task<IActionResult> CheckAddress( Vm_VoipUser vvu )
        {
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            // var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            // client.DefaultRequestHeaders.Add("App-Key", "13457");
            // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09125000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                zip_code = vvu.Post ,
            };
            var response = await client.PostAsJsonAsync("gis/zipcodes/addresses", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 5000)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "مکان محور",
                        Bill_Id = vvu.Post,
                        Pay_Id = vvu.Post,
                        Amount = 2500,
                        Titel_Request = "دریافت آدرس",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(2500, qfinal.Id);
                    var result = await response.Content.ReadAsStringAsync();
                    var desclass = JsonConvert.DeserializeObject<RootAddress>(result);
                    ViewBag.resultok = desclass.Address ;
                    ViewBag.Address = desclass.Address ;
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            Diposit();
            ViewBag.CM_Code = vvu.CM_Code ;
            ViewBag.Mobile = vvu.Mobile ;
            ViewBag.Post = vvu.Post ;
            return View();
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class RootAddress
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }
    
            [JsonProperty("address")]
            public string Address { get; set; }
        }

        //------------------------------------------------------------------------------------------------------------//
        public async Task<IActionResult> AddClient( Vm_VoipUser vvu )
        {
            Diposit();
            if ( msg != null )
            {
                ViewBag.msg = msg ;
                msg = null ;
            }
            var baseAddress = new System.Uri("https://api.faraboom.co/v1/");
            // var baseAddress = new System.Uri("https://api.sandbox.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear();
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            // client.DefaultRequestHeaders.Add("App-Key", "13457");
            // client.DefaultRequestHeaders.Add("Device-Id", "192.168.1.1");
            // client.DefaultRequestHeaders.Add("Token-Id", "XBUFGGeJ1t8IBlPxhd6nQRm0dBQo9CJiUX1UrSvRp73c7KEIj5PTY670yhV0NzVMVoN84ecHMzU3A40ktm8jrE");
            client.DefaultRequestHeaders.Add("App-Key", "13075");
            client.DefaultRequestHeaders.Add("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add("CLIENT-USER-ID", "09125000000");
            client.DefaultRequestHeaders.Add("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new
            {
                zip_code =  vvu.Post
            };
            var response = await client.PostAsJsonAsync("gis/zipcodes/coordinates", data);
            if (response.IsSuccessStatusCode == true)
            {
                if (HttpContext.Session.GetInt32("sum") >= 2500)
                {
                    Tbl_Request tb = new Tbl_Request
                    {
                        UserName = User.Identity.GetId(),
                        Type_Request = "مکان محور",
                        Bill_Id = vvu.Post,
                        Pay_Id = vvu.Post,
                        Amount = 2500,
                        Titel_Request = "دریافت مشخصات جغرافیایی آدرس",
                        Date_Request = DateTime.UtcNow,
                    };
                    db.Tbl_Requests.Add(tb);
                    db.SaveChanges();
                    var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                    proccess(2500, qfinal.Id);
                    var result = await response.Content.ReadAsStringAsync();
                    var desclass = JsonConvert.DeserializeObject<RootG>(result); 
                    ViewBag.result = desclass ;
                    ViewBag.lat = desclass.Latitude ;
                    ViewBag.lng = desclass.Longitude ;
                }
                else
                {
                    ViewBag.Msg = " موجودی کیف پول شما کافی نمیباشد .";
                }
            }
            else
            {
                ViewBag.result = await response.Content.ReadAsStringAsync();
            }
            ViewBag.CM_Code = vvu.CM_Code ;
            ViewBag.Mobile = vvu.Mobile ;
            ViewBag.Post = vvu.Post ;
            ViewBag.Address = vvu.Address ;
            return View();
        }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class RootG
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }

            [JsonProperty("latitude")]
            public string Latitude { get; set; }

            [JsonProperty("longitude")]
            public string Longitude { get; set; }
        }

        public async Task<IActionResult> AddUser( Vm_VoipUser vv )
        {
            Diposit();
            Tbl_VoipUser tv = new Tbl_VoipUser(); 
            tv.UserName = User.Identity.GetId() ;
            tv.NameFamily = vv.NameFamily ;
            tv.CM_Code = vv.CM_Code ;
            tv.Mobile = vv.Mobile ;
            tv.Phone = vv.Phone ;
            tv.Post = vv.Post ;
            tv.Email = vv.Email ;
            tv.Address = vv.Address ;
            tv.Lng = vv.Lng ;
            tv.Lat = vv.Lat ;
            if (vv.CAImg != null)
            {
                string FileExtension1 = Path.GetExtension(vv.CAImg.FileName);
                string NewFileName1 =String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path1 = $"{_env.WebRootPath}\\FileUpload\\{NewFileName1}";
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    await vv.CAImg.CopyToAsync(stream);
                }
                tv.CM_Img = NewFileName1;
            };
            if (vv.CAImg2 != null)
            {
                string FileExtension2 = Path.GetExtension(vv.CAImg2.FileName);
                string NewFileName2 =String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                var path2 = $"{_env.WebRootPath}\\FileUpload\\{NewFileName2}";
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    await vv.CAImg2.CopyToAsync(stream);
                }
                tv.CM_Img2 = NewFileName2;
            };
            db.Tbl_VoipUsers.Add(tv);
            db.SaveChanges();
            msg = "Ok" ;
            return RedirectToAction("AddClient");
        }

        //-----------------------------------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------------//
        public IActionResult Sabt()
        {
            Diposit();
            var quser = db.Tbl_VoipUsers.Where( a => a.UserName == User.Identity.GetId() ).ToList();
            ViewBag.user = quser ;
            return View();
        }

        public IActionResult SabtNumber( int id )
        {
            Diposit();
            var quser = db.Tbl_VoipUsers.Where( a => a.Id == id ).SingleOrDefault();
            ViewBag.user = quser.Id ;
            return View();
        }

        public IActionResult CheckNum( Vm_VoipNumber vv )
        {
            Diposit();
            int price = 0;
            switch ( vv.Type )
            {
                case "طلایی":
                    price = 4000000;
                    break;
                case "نقره ای":
                    price = 2000000;
                    break;
                case "برنزی":
                    price = 400000;
                    break;
                case "معمولی":
                    price = 99000;
                    break;
            };
            if ( vv.SelectVoip == "پیشنهادی" )
            {
                var qnum = db.Tbl_VoipNumbers.Where( a => a.Ostan == vv.Ostan && a.Type == vv.Type && a.Rezerve == "0" ).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
                ViewBag.p = qnum ;
            }
            if ( vv.SelectVoip == "انتخابی" )
            {
                ViewBag.e = "OK";
                string codeostan = "null";
                switch ( vv.Ostan )
                {
                    case "تهران":
                        codeostan = "21";
                        break;
                    case "کردستان":
                        codeostan = "87";
                        break;
                    case "آذربایجان غربی":
                        codeostan = "44";
                        break;
                    case "آذربایجان شرقی":
                        codeostan = "41";
                        break;
                };
                ViewBag.codeostan = codeostan;
            };
            ViewBag.price = price;
            ViewBag.type = vv.Type;
            ViewBag.userid = vv.UserId;
            ViewBag.ostan = vv.Ostan;
            return View();
        }

        public IActionResult CheckNumSelect( Vm_VoipNumber vp )
        {
            Diposit();
            var qcodenum = vp.CodeOstan + vp.Number ;
            var qtn = db.Tbl_VoipNumbers.Where( a => a.Number == qcodenum && a.Ostan == vp.Ostan).SingleOrDefault();
            if ( qtn != null  )
            {
                if ( qtn.Rezerve == "0" )
                {
                    ViewBag.ok = "ok";
                    ViewBag.price = qtn.Price;
                    ViewBag.type = qtn.Type;
                    ViewBag.num = qcodenum;
                    ViewBag.userid = vp.UserId;
                    ViewBag.numid = qtn.Id;
                    return View();
                }
                else
                {
                    ViewBag.msgr = qcodenum ;
                    return View();
                } 
            }
            else
            {
                ViewBag.msgn = qcodenum ;
                return View();
            }
        }

        public IActionResult PishFactor( int numid , int userid )
        {
            ViewBag.numid = numid;
            ViewBag.userid = userid;
            var quser = db.Tbl_VoipUsers.Where(a => a.Id == userid).SingleOrDefault();
            var qnum = db.Tbl_VoipNumbers.Where(a => a.Id == numid).SingleOrDefault();
            var qorder = db.Tbl_VoipOrders.OrderByDescending( a => a.Id).FirstOrDefault();
            List<Vm_Factor> lvf = new List<Vm_Factor>();
            Vm_Factor vvm = new Vm_Factor()
            {
                Id_Tel = qnum.Id ,
                Number_Tel = qnum.Number ,
                Title_Tel = "خرید تلفن اینترنتی" + " - " + qnum.Ostan,
                Type_Tel = qnum.Type + " - " + qnum.Number ,
                Ostan_Tel = qnum.Ostan,
                Amount_Tel = qnum.Price.Rial(),
                Amount_ArAf_Tel =  (qnum.Price*9/100).Rial() ,
                Total_Amount_Tel = (qnum.Price + qnum.Price*9/100).Rial() ,
                Date_Tel = DateTime.Now.ToPersianDateString(),
                NameFamily = quser.NameFamily ,
                Address = quser.Address ,
                Mobile = quser.Phone ,
                Phone = quser.Mobile ,
                Post  = quser.Post ,
                CodeMeli = quser.CM_Code ,
                ta2 = ( qnum.Price + (qnum.Price*9/100) + 350000 ).Rial() ,
                ta1 = ( qnum.Price + 350000 ).Rial() ,
                Amount_Set = (350000).Rial() ,
                UserName = User.Identity.GetId() ,
            };
            if ( qorder != null )
            {
                vvm.Order_Id = (qorder.Id+1);
            }
            lvf.Add(vvm);
            ViewBag.result = lvf ;
            return View();
        }
        
        public IActionResult AddNum( Vm_VoipNumber vvn )
        {
            Diposit();
            var quser = db.Tbl_VoipUsers.Where(a => a.Id == vvn.UserId).SingleOrDefault();
            var qvoip = db.Tbl_VoipNumbers.Where(a => a.Id == vvn.NumId).SingleOrDefault();
            var qga = qvoip.Price + (qvoip.Price * 9 / 100) ;
            var qp = qga + 350000 ;
            int mypay = 0 ;
            switch ( qvoip.Type )
            {
                case "طلایی":
                    mypay = qvoip.Price * 40 / 100;
                    break;
                case "نقره ای":
                    mypay = qvoip.Price * 30 / 100;
                    break;
                case "برنزی":
                    mypay = qvoip.Price * 20 / 100;
                    break;
                case "معمولی":
                    mypay = qvoip.Price * 10 / 100;
                    break;
            };
            if (HttpContext.Session.GetInt32("sum") >= qp)
            {
                Tbl_VoipOrder tvo = new Tbl_VoipOrder()
                {
                    UserName = User.Identity.GetId(),
                    Id_User = vvn.UserId,
                    Id_Number = vvn.NumId,
                };
                db.Tbl_VoipOrders.Add(tvo);
                qvoip.DateRezerve = DateTime.Now;
                qvoip.Rezerve = "1";
                qvoip.UserName = User.Identity.GetId();
                qvoip.UserId = vvn.UserId.ToString();
                db.Tbl_VoipNumbers.Update(qvoip);
                Tbl_Request tb = new Tbl_Request()
                {
                    UserName = User.Identity.GetId(),
                    Type_Request = "خرید تلفن اینترنتی",
                    Amount = qga,
                    Titel_Request = qvoip.Type,
                    Date_Request = DateTime.UtcNow,
                    Bill_Id = quser.NameFamily ,
                    Pay_Id =qvoip.Ostan + " - " +  qvoip.Number ,
                };
                db.Tbl_Requests.Add(tb);
                db.SaveChanges();
                var qfinal = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                Tbl_pay A = new Tbl_pay()
                {
                    UserName = User.Identity.GetId(),
                    Harvest =  qga,
                    DateTime = DateTime.UtcNow,
                    status = true,
                    RequestId = qfinal.Id,
                };
                db.Tbl_pays.Add(A);
                Tbl_Mypay B = new Tbl_Mypay()
                {
                    UserName = User.Identity.GetId(),
                    Pay = mypay ,
                    DateTime = DateTime.UtcNow,
                    status = true,
                    RequestId = qfinal.Id ,
                };
                db.Tbl_Mypays.Add(B);
                Tbl_Request tb2 = new Tbl_Request()
                {
                    UserName = User.Identity.GetId(),
                    Type_Request = "کانفیگ",
                    Amount = 350000,
                    Titel_Request = "نصب و راه اندازی",
                    Date_Request = DateTime.UtcNow,
                    Bill_Id = quser.NameFamily ,
                    Pay_Id = qvoip.Number ,
                };
                db.Tbl_Requests.Add(tb2);
                db.SaveChanges();
                var qfinal2 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                Tbl_pay A2 = new Tbl_pay()
                {
                    UserName = User.Identity.GetId(),
                    Harvest =  qfinal2.Amount,
                    DateTime = DateTime.UtcNow,
                    status = true,
                    RequestId = qfinal2.Id,
                };
                db.Tbl_pays.Add(A2);
                db.SaveChanges();
                ViewBag.ok = " ثبت و خرید با موفقیت انجام شد . ";
                return RedirectToAction("Factor");
            }
            else
            {
                ViewBag.error = " موجودی کیف پول شما کافی نمیباشد .";
                return View();
            }
        }
        
        public IActionResult Factor()
        {
            Diposit();
            var qtel = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId() ).OrderByDescending( a => a.Id ).Skip(1).Take(1).SingleOrDefault();
            var qset = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId() ).OrderByDescending( a => a.Id ).Take(1).SingleOrDefault();
            int ta = qset.Amount + qtel.Amount;
            List<Vm_Factor> lvf = new List<Vm_Factor>();
            Vm_Factor vf = new Vm_Factor()
            {
                Title_Tel = qtel.Type_Request + " - " + qtel.Titel_Request ,
                Type_Tel =  qtel.Pay_Id ,
                Amount_Tel = qtel.Amount.Rial() ,
                Date_Tel = qtel.Date_Request.ToPersianDateString() ,
                Title_Set = qset.Titel_Request ,
                Type_Set = qset.Type_Request ,
                Amount_Set = qset.Amount.Rial() , 
                Date_Set = qset.Date_Request.ToPersianDateString() ,
                Amount_Total = ta.Rial() ,
                NameFamily = qset.Bill_Id ,
            };
            lvf.Add(vf);
            ViewBag.result = lvf;
            return View();
        }

        public IActionResult Report()
        {
            Diposit();
            var qorder = db.Tbl_VoipOrders.Where( a => a.UserName == User.Identity.GetId() ).ToList();
            List<Vm_Factor> lvv = new List<Vm_Factor>();
            foreach (var item in qorder)
            {
                var quser = db.Tbl_VoipUsers.Where( a => a.Id == item.Id_User ).SingleOrDefault();
                var qnum = db.Tbl_VoipNumbers.Where( a => a.Id == item.Id_Number ).SingleOrDefault();
                Vm_Factor vv = new Vm_Factor()
                {
                    Id = item.Id ,
                    NameFamily = quser.NameFamily ,
                    Mobile = quser.Mobile ,
                    Address = quser.Address ,
                    //----------------------------------------//
                    Number_Tel = qnum.Number ,
                    Ostan_Tel = qnum.Ostan ,
                    Type_Tel = qnum.Type ,
                    Date_Tel = qnum.DateRezerve.ToPersianDateString() ,
                };
                lvv.Add(vv);
            };
            ViewBag.result = lvv;
            return View();
        }

        public IActionResult SelectCD()
        {
            return View();
        }

        public IActionResult AddCD()
        {
            return View();
        }
        
    }
}