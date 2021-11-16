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
namespace faraboom.Controllers
{

    public class paylevelController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public static string msg;
        private readonly ContextHampadco db;
        public static int sumshop;

        public paylevelController(ContextHampadco _db)
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
            sumshop = 25000000;

            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.PhoneUs,
                CallbackUrl = "https://nikatak.ir/pay/validate",
                Description = quser.NameFamily,
                Email = quser.EmailUS,
                Amount = 25000000,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
            }, ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }

        public async Task<IActionResult> Request2()
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















    }
}