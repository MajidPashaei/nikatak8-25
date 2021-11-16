using System.Data;
using System.Data.Common;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataLayer.Context;
using Dto.Payment;
using faraboom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ZarinPal.Class;
using ViewModels.AdminViewModel.Job;
using DataLayer.AdminEntities.Job;
using Kavenegar;

namespace faraboom.Controllers
{
    public class PayController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public static string msg;
        private readonly ContextHampadco db;
        public static int sumshop;

        public PayController(ContextHampadco _db)
        {
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
            db = _db;
        }

        public IActionResult Index()
        {

            if (msg != null)
            {
                ViewBag.msg = msg;
                msg = null;
            }

            return View();
        }
        //////////////////////////////////////////////////////////////////فرایند خرید

        public async Task<IActionResult> Request()
        {

            var quser = db.Tbl_User.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            sumshop = 50000000;

            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.PhoneUs,
                CallbackUrl = "https://nikatak.ir/pay/validate",
                Description = quser.NameFamily,
                Email = quser.EmailUS,
                Amount = 50000000,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
            }, ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }

        public async Task<IActionResult> Request2()
        {

            var quser = db.Tbl_User.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            sumshop = 75000000;
            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.PhoneUs,
                CallbackUrl = "https://nikatak.ir/pay/validate",
                Description = quser.NameFamily,
                Email = quser.EmailUS,
                Amount = 75000000,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
            }, ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }


        public async Task<IActionResult> Request3()
        {

            var quser = db.Tbl_UserPersenel.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            sumshop = 30000;

            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.PhoneUs,
                CallbackUrl = "https://nikatak.ir/pay/validate3",
                Description = quser.NameFamily,
                Email = quser.EmailUS,
                Amount = 30000,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
            }, ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }
        ///////////////////////////////////////////////////اعتبار سنجی

        public async Task<IActionResult> Validate(string authority, string status)
        {

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = sumshop,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35",
                Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100)
            {
                var quser = db.Tbl_infoPersenels.Where(a => a.UserNameId == (User.Identity.GetId())).SingleOrDefault();
                quser.Locationaddress = "ok";
                db.Tbl_infoPersenels.Update(quser);
                db.SaveChanges();


                return RedirectToAction("verifi", "home", new { area = "Admin", id = 1 });
            }
            else

            {


                return RedirectToAction("verifi", "home", new { area = "Admin", id = 0 });

            }

        }




        public async Task<IActionResult> validate3(string authority, string status)
        {

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = sumshop,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35",
                Authority = authority
            }, Payment.Mode.sandbox);

            if (verification.Status == 100)
            {
                var quser = db.Tbl_infoPersenels.Where(a => a.UserNameId == (User.Identity.GetId())).SingleOrDefault();
                quser.Locationaddress = "ok";
                db.Tbl_infoPersenels.Update(quser);
                db.SaveChanges();


                return RedirectToAction("form", "Persenel", new { area = "Persenel", id = 1 });
            }
            else

            {


                return RedirectToAction("form", "Persenel", new { area = "Persenel", id = 0 });

            }

        }

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

        public IActionResult IndexJob()
        {
            return View();
        }
        
        public async Task<IActionResult> RequestJob( Vm_JobPay vjp )
        {

            Tbl_JobPay tjp = new Tbl_JobPay()
            {
                Name = vjp.Name , 
                Family = vjp.Family ,
                CodeMeli = vjp.CodeMeli ,
                Mobile = vjp.Mobile ,
                Email = vjp.Email ,
                DateTime = DateTime.Now,
            };
            db.Tbl_JobPays.Add(tjp);
            db.SaveChanges();

            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = vjp.Mobile ,
                // CallbackUrl = "https://localhost:5001/Pay/ValidateJob",
                CallbackUrl = "https://nikatak.ir/Pay/ValidateJob",
                Description = (" خرید کارت اعتباری " + "  " + vjp.Name + "  " +  vjp.Family) ,
                Email = vjp.Email ,
                Amount = 100000,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35" ,
                // MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" ,
            // },ZarinPal.Class.Payment.Mode.sandbox);
            // return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            },ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }

        public async Task<IActionResult> ValidateJob(string authority, string status)
        {

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = 100000 ,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35" ,
                // MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" ,
                Authority = authority
            // }, Payment.Mode.sandbox);
            }, Payment.Mode.zarinpal);

            if (status == "OK")
            {
                string RandomNum;
                do
                {
                    Random rand = new Random();
                    RandomNum = rand.Next(100000, 999999).ToString();
                } while (db.Tbl_JobPays.Any(a => a.Rand == RandomNum));
                
                var qjpay = db.Tbl_JobPays.OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                qjpay.Rand = RandomNum;
                qjpay.statuspay = true;
                db.Tbl_JobPays.Update(qjpay);
                db.SaveChanges();

                ViewBag.ok = " پرداخت با موفقیت انجام شد  ." ;
                ViewBag.RandomNum = RandomNum;
                var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                api.VerifyLookup(qjpay.Mobile, RandomNum, "nikatakjob");
            }
            else
            {
                ViewBag.er = " خطا در پرداخت  ." ;
            }
            return View();

        }

        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------//

    }
}