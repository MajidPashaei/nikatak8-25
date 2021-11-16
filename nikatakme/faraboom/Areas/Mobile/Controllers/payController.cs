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
using DataLayer.AdminEntities.wallet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Mobile.Controllers
{
    [Area("Mobile")]

    public class payController : BaseController
    {
        public payController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {

        }
        public IActionResult Index(int id)
        {
            Tbl_pay A = new Tbl_pay()
            {
                UserName = User.Identity.GetId(),
                Pay = id,
                DateTime = DateTime.UtcNow
            };
            db.Tbl_pays.Add(A);
            db.SaveChanges();
            Diposit();
            return RedirectToAction("Request");
        }
        //////////////////////////////////////////////////////////////////فرایند خرید
        public async Task<IActionResult> Request()
        {
            // var quser = db.Tbl_User.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            var quser = db.Tbl_Users.Where(a => a.Phone == User.Identity.GetId()).SingleOrDefault();
            var nf = quser.Name + " " + quser.Family ;
            var qpay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
            sumshop = qpay.Pay;
            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.Phone,
                CallbackUrl = "https://nikatak.ir/mobile/pay/validate",
                // CallbackUrl = "https://localhost:5001/mobile/pay/validate",
                Description = nf ,
                Email = quser.Gmail ,
                Amount = qpay.Pay,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
                // MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            },ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
            // return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
        }

        ///--------------------------------------------------------اعتبار سنجی
        public async Task<IActionResult> Validate(string authority, string status)
        {
            string pays = status;
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = sumshop,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35",
                // MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.zarinpal);

            if (pays == "OK")
            {
                var q = db.Tbl_pays.Where(a=> a.UserName==User.Identity.GetId()).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                q.status = true;
                db.Tbl_pays.Update(q);
                db.SaveChanges();
                msg = "succses";
                if (HttpContext.Session.GetString("payred") == "1")
                {
                    HttpContext.Session.SetString("pay", Diposit().ToString());
                    return RedirectToAction("index" , "Wallet");
                }
                return RedirectToAction("succses" , "Wallet" );
            }
            else
            {
                var q = db.Tbl_pays.Where(a=> a.UserName==User.Identity.GetId()).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                q.status = false;
                db.Tbl_pays.Remove(q);
                db.SaveChanges();
                msg = "error";
                return RedirectToAction("error", "Wallet" );
            }
        }
        public IActionResult pay()
        {
            if (msg != null)
            {
                ViewBag.msg = msg;
                msg = null;
            }
            HttpContext.Session.SetString("pay", Diposit().ToString());
            Diposit();
            return View();
        }
        public int Diposit()
        {
            var user = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).ToList();
            int pay = 0;
            int harvest = 0;
            foreach (var item in user)
            {
                if (item.Pay != 0 && item.status == true)
                {
                    pay = pay + item.Pay;
                }
                if (item.Harvest != 0)
                {
                    harvest = harvest + item.Harvest;
                }
            }
            int total = pay - harvest;
            return total;
        }
    }
}