using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.User;
using DataLayer.AdminEntities.mobiledb;
using Kavenegar;
using System.Security.Claims;

namespace Mobile.Controllers
{
    [Area("Mobile")]
    public class HomeController : BaseController
    {
        public static string NewFileName , msg , mobile ;
        // private readonly ContextHampadco db;
        // private readonly IWebHostEnvironment _env;

        // public HomeController(ContextHampadco _db, IWebHostEnvironment env)
        // {
        //     db = _db;
        //     _env = env;

        // }
        public HomeController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult levelform()
        {
            return View();
        }

        public IActionResult levelform2()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }
        public IActionResult Exit()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index");
        }

        public IActionResult form(int? id)
        {

            menu.resiver = db.Tbl_Message.Where(a => a.StateMess == false && a.SenderMess == "admin" && a.ResiverMess == User.Identity.GetId()).Count();
            if (id == 1)
            {
                ViewBag.msg = "اطلاعات با موفقیت بروزرسانی شد";
            }

            var quser = db.Tbl_infos.Where(a => a.UserNameId == (User.Identity.GetId())).SingleOrDefault();
            Vm_info VmInfo = new Vm_info()
            {
                Nameper = quser.Nameper,
                Familyper = quser.Familyper,
                Fathernameper = quser.Fathernameper,
                Nameen = quser.Nameen,
                Familyen = quser.Familyen,
                Fathernameen = quser.Fathernameen,
                Place = quser.Place,
                Serial = quser.Serial,
                Religion = quser.Religion,
                Email = quser.Email,
                Yers = quser.Yers,
                Mont = quser.Mont,
                Day = quser.Day,
                Gender = quser.Gender,
                maritalstatus = quser.maritalstatus,
                Bankname = quser.Bankname,
                Bankcode = quser.Bankcode,
                Branchname = quser.Branchname,
                Accounttype = quser.Accounttype,
                cardnumber = quser.cardnumber,
                Shabanumber = quser.Shabanumber,
                accountnumber = quser.accountnumber,
                AccountName = quser.AccountName,
                PostalcodeBank = quser.PostalcodeBank,
                Address = quser.Address,
                Phone = quser.Phone,
                PhoneHome = quser.PhoneHome,
                PhonelocationN = quser.PhonelocationN,
                PhoneNikatak = quser.PhoneNikatak,
                State = quser.State,
                City = quser.City,
                Postalcode = quser.Postalcode,
                homeaddress = quser.homeaddress,
                Locationaddress = quser.Locationaddress,
                DiplomDate = quser.DiplomDate,
                DiplomLocation = quser.DiplomLocation,
                KardaniDate = quser.KardaniDate,
                KardaniLocation = quser.KardaniLocation,
                KarshenasiDate = quser.KarshenasiDate,
                KarshenasiLocation = quser.KarshenasiLocation,
                ArshadDate = quser.ArshadDate,
                ArshadLocation = quser.ArshadLocation,
                DoktoraDate = quser.DoktoraDate,
                DoktoraLocation = quser.DoktoraLocation,
                photos = quser.photos,
                Nationalcard = quser.Nationalcard,
                Nationalcardback = quser.Nationalcardback,
                Certificate = quser.Certificate,
                Shaba = quser.Shaba,
                Degreeeducation = quser.Degreeeducation,
                PostalcodeDoc = quser.PostalcodeDoc,
                Document = quser.Document,
                Badbackground = quser.Badbackground,
                Receipt = quser.Receipt,
                Companyname = quser.Companyname,
                start = quser.start,
                End = quser.End,
                Typeactivity = quser.Typeactivity,
                NationalCode = quser.NationalCode,
            };

            return View(VmInfo);
        }

        public IActionResult verifi(int id)
        {

            if (id == 1)
            {
                ViewBag.msg = "پرداخت باموفقیت انجام شد";
            }
            else
            {
                ViewBag.msg = " پرداخت ناموفق بود ";

            }
            return View();

        }
        public IActionResult map()
        {
            
            return View();
        }
        public IActionResult logincode()
        {
            return View();
        }

        public IActionResult sendtoken(Vm_User us)
        {
            Random rnd = new Random();
            string number = rnd.Next(1000, 9999).ToString();
            mobile=us.Phone;
            var qcheck = db.Tbl_Users.Where(a => a.Phone == us.Phone).SingleOrDefault();
            if (qcheck == null)
            {
                Tbl_User user = new Tbl_User()
                {
                    Phone = us.Phone,
                    Token = number,
                };
                db.Tbl_Users.Add(user);
                db.SaveChanges();
                var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                api.VerifyLookup(us.Phone, number, "nikatakAllowed");

                return RedirectToAction("signup");
            }
            else
            {
                qcheck.Token=number;
                db.Tbl_Users.Update(qcheck);
                db.SaveChanges();
                var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                api.VerifyLookup(us.Phone, number, "nikatakAllowed");

                return RedirectToAction("signup");
            }
        }

        public IActionResult signup()
        {
            if (msg != null)
                {
                    ViewBag.msg = msg;
                    msg = null;
                }
            return View();
        }

        public IActionResult signup2()
        {
            if (msg != null)
                {
                    ViewBag.msg = msg;
                    msg = null;
                }
            return View();
        }
        
        public IActionResult checkcode(Vm_User us)
        {
            ViewBag.Mobile=mobile;
            var q=db.Tbl_Users.Where(a => a.Phone == mobile).SingleOrDefault();
            if (q.Token==us.Token)
            {
                if (q.Name != null)
                {
                    var claims = new List<Claim> (
                        
                    )
                    {
                      new Claim (ClaimTypes.NameIdentifier,q.Phone),
                      new Claim (ClaimTypes.Name,q.Name)
                    };

                    var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal (identity);
                    var properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddYears(1),
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync (principal, properties);
                    return RedirectToAction("index","Menu", new { area = "mobile" });
                }
                else
                {
                    ViewBag.Mobile=mobile;
                    var tu=db.Tbl_Users.Where(a => a.Phone == mobile).SingleOrDefault();
                    if (tu.Token==us.Token)
                    {
                        var claims = new List<Claim> ()
                        {
                          new Claim (ClaimTypes.NameIdentifier,q.Phone),
                          new Claim (ClaimTypes.Name,"")
                        };
                        var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal (identity);
                        var properties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddYears(1),
                            IsPersistent = true
                        };
                        HttpContext.SignInAsync (principal, properties);
                        return RedirectToAction("SetProfile","Menu", new { area = "mobile" });
                    }
                }
            }
            else
            {
                msg = " کد ورودی اشتباه است ";
                return RedirectToAction("signup");
            }

            return View();
        }

        public IActionResult setting()
        { 
            Diposit();
            return View();
        }
        
        public IActionResult lang()
        { 
            Diposit();
            return View();
        }

        public IActionResult suopport()
        { 
            Diposit();
            return View();
        }

        public IActionResult Page()
        { 
            Diposit();
            return View();
        }
    }
}