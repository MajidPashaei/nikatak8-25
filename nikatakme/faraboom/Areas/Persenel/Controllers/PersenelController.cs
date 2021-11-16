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
namespace Admin.Controllers
{
    [Area("Persenel")]
    [Authorize]
    public class PersenelController : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public PersenelController(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;

        }

        public IActionResult Index()
        {
            return View();
        }




        






        public IActionResult Exit()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "home");
        }

        public IActionResult form(int? id)
        {
             menu.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin" && a.ResiverMess==User.Identity.GetId ()).Count();
            if (id == 1)
            {
                ViewBag.msg = "اطلاعات با موفقیت بروزرسانی شد";
            }

            var quser = db.Tbl_infoPersenels.Where(a => a.UserNameId == (User.Identity.GetId())).SingleOrDefault();
            Vm_infoPersenel VmInfo = new Vm_infoPersenel()
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

    }
}