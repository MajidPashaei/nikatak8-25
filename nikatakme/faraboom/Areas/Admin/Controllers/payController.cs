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

namespace Admin.Controllers
{
    [Area("Admin")]

       public class payController : BaseController
    {
      
      public payController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
      {
          
      }
        public IActionResult Index(int id)
        {
            if (msg != null)
            {
                ViewBag.msg = msg;
                msg = null;
            }
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
            var quser = db.Tbl_User.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            var qpay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
            sumshop = qpay.Pay;
            var result = await _payment.Request(new DtoRequest()
            {
                Mobile = quser.PhoneUs,
                CallbackUrl = "https://nikatak.ir/Admin/pay/validate",
                //CallbackUrl = "https://localhost:5001/Admin/pay/validate",
                Description = quser.NameFamily,
                Email = "tak1.ghasemi@gmail.com",
                Amount = qpay.Pay,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35"
                //MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
            }, ZarinPal.Class.Payment.Mode.zarinpal);
            return Redirect($"https://zarinpal.com/pg/StartPay/{result.Authority}");
        }
        ///////////////////////////////////////////////////اعتبار سنجی
        public async Task<IActionResult> Validate(string authority, string status)
        {
            string pays = status;
            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = sumshop,
                MerchantId = "ab99ecd5-bc8a-402f-8ead-b8dca3ed0e35",
                Authority = authority
            }, Payment.Mode.zarinpal);

            if (pays == "OK")
            {
                var q = db.Tbl_pays.Where(a=> a.UserName==User.Identity.GetId()).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                q.status = true;
                db.Tbl_pays.Update(q);
                db.SaveChanges();
                msg = "پرداخت با موفقیت انجام شد";
                if (HttpContext.Session.GetString("payred") == "1")
                {
                    HttpContext.Session.SetString("pay", Diposit().ToString());
                    return RedirectToAction("index", "Wallet");
                }
                return RedirectToAction("index", "Wallet");
            }
            else
            {
                var q = db.Tbl_pays.Where(a=> a.UserName==User.Identity.GetId()).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                q.status = false;
                db.Tbl_pays.Remove(q);
                db.SaveChanges();
                msg = "پرداخت نا موفق بوده است ";
                return RedirectToAction("index", "Wallet");
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

        // public IActionResult paytravel()
        // {
        //     var qtravel=db.tbl_Travels.Where(a => a.UserPhone == User.Identity.GetId() && a.TypePay == "پذیرش").SingleOrDefault();
        //    if (qtravel != null)
        //    {
        //         if ( Convert.ToInt32(HttpContext.Session.GetString ("pay"))  >= Convert.ToInt32(qtravel.Price)  )
        //     {
        //          Tbl_pay A=new Tbl_pay()
        //     {
        //        Phone=User.Identity.GetId(),
        //        Harvest=Convert.ToInt32(qtravel.Price),
        //        havesttime=DateTime.UtcNow,
        //        idtravel=qtravel.Id

        //     };
        //     db.tbl_Pays.Add(A);
        //      db.SaveChanges();

        //             var quser = db.tbl_Users.Where(a => a.phone == qtravel.UserPhone)?.SingleOrDefault();
        //       Tbl_paydriver B=new Tbl_paydriver()
        //     {
        //        Driverid=qtravel.DriverId.ToString(),
        //        Pay=Convert.ToInt32(qtravel.Price),
        //        Paytime=DateTime.UtcNow,
        //         Travelid = qtravel.Id.ToString(),
        //        NameFamily=quser.NameFamily



        //     };
        //     db.Tbl_paydriver.Add(B);
        //      db.SaveChanges();
        //        HttpContext.Session.SetString ("pay", Diposit().ToString());

        //      return RedirectToAction ("mapaccept","mapaccept");

        //       }
        //       else
        //       {
        //            HttpContext.Session.SetString ("payred", "1");
        //           msg="اعتبار شما کافی نیست لطفا کیف پول خو را شارژ کنید";
        //           return RedirectToAction ("pay");


        //       }
        //    }

        //    return RedirectToAction ("mapaccept","mapaccept");
        // }
    }
}