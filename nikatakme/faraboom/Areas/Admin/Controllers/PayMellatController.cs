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
using ServiceReference2;
using Microsoft.AspNetCore.Http.Extensions;
using System.IO;
using DataLayer.AdminEntities.wallet;

namespace Admin.Controllers
{
    [Area("Admin")]
   
    public class PayMellatController :  BaseController
    {
      

          private IPaymentGateway BankMellatServiceClient = new PaymentGatewayClient();

       

        public PayMellatController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
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
            return RedirectToAction("Payment");
        }

        
        
        public async Task<IActionResult> Payment()
        {
            string url = UriHelper.GetDisplayUrl(Request);



            string scheme = Request.Scheme;
            HostString host = Request.Host;
            string domain = scheme + System.Uri.SchemeDelimiter + host;
            string bankcallback = "@IP/admin/PayMellat/CompletedBank".Replace("@IP", domain);

            #region انتخاب شماره ترمینال

            const long mellatterminalid = 6030253;
            var mellatusername = "nikatak777";
            var mellatpassword = "36128091";

            #endregion

            bpPayRequestResponse result;
            bpPayRequest req = new bpPayRequest();
            req.Body = new bpPayRequestBody();
            //bpPayRequest req = bpPayRequestBody(mellatterminalid, mellatusername,mellatpassword, Int64.Parse("8795489"), 1000, DateTime.UtcNow.Date.ToString("yyyy/MM/dd").Replace("/", ""), DateTime.UtcNow.ToString("hh:mm:ss").Replace(":", ""), PaymentUtility.GetRandomString(8, PaymentUtility.CharCaseStatus.Both,
            // PaymentUtility.RandomStringType.OnlyNumbers).ToString() + "," + 1000 + "," + Int64.Parse("0") + ";", bankcallback, "0");

            //may data
            var quser = db.Tbl_User.Where(a => a.UserNameUs == (User.Identity.GetId())).SingleOrDefault();
            var qpay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
            sumshop = qpay.Pay;
            int Rn;
            var R=new Random();
            Rn=R.Next(100000, 999999);
            var Prn=Convert.ToString(Rn)+quser.Id;
              
             


            //
            req.Body.payerId = "0";

            req.Body.callBackUrl = bankcallback;
            req.Body.localDate = DateTime.UtcNow.Date.ToString("yyyy/MM/dd").Replace("/", "");
            req.Body.localTime = DateTime.UtcNow.ToString("hh:mm:ss").Replace(":", "");
            req.Body.amount = qpay.Pay*10;
            req.Body.terminalId = mellatterminalid;
            req.Body.userName = mellatusername;
            req.Body.userPassword = mellatpassword;
            req.Body.orderId = Convert.ToInt64(Prn);
            req.Body.additionalData =quser.NameFamily;
                // PaymentUtility.GetRandomString(8, PaymentUtility.CharCaseStatus.Both,
                //     PaymentUtility.RandomStringType.OnlyNumbers).ToString() + "," + 1000 + "," + Int64.Parse("0") + ";";


            result = await BankMellatServiceClient.bpPayRequestAsync(req);
            //result.Body.@return "421"
            String[] resultArray = result.Body.@return.Split(',');
            if (resultArray[0] == "0")
            {
                CheckOutRedirectInfoModel _benSell = new CheckOutRedirectInfoModel();
                _benSell.RefId = resultArray[1].ToString();
                _benSell.MobileNo = quser.PhoneUs;

                //_orderProcessingService.MobileGetWay_Insert(FactorNumber, _OrderId, "Mellat", "FromSite", string.Empty);
                return View("PaymentMellat", _benSell);
            }


            return View("Payment");

        }

        
        public async Task<IActionResult> CompletedBank(string RefId, string ResCode, string SaleOrderId,
        
            string SaleReferenceId, string CardHolderInfo = "", string CardHolderPan = "", string FinalAmount = "")
        {

           var user = db.Tbl_User.Where(a => a.Id == Convert.ToInt64(SaleOrderId.Substring(6)) ).SingleOrDefault().UserNameUs;

           if (ResCode == "0")
            {
                const long mellatterminalid = 6030253;
                var mellatusername = "nikatak777";
                var mellatpassword = "36128091";

                //if (refId == _benSell.RefId && SaleOrderId == req.Body.orderId)
                
                //(if) check in DB for that verify is done
                bpVerifyRequest verifyRequest=new bpVerifyRequest();
                verifyRequest.Body = new bpVerifyRequestBody();
                verifyRequest.Body.orderId=Convert.ToInt64(SaleOrderId);
                verifyRequest.Body.terminalId = mellatterminalid;
                verifyRequest.Body.userName = mellatusername;
                verifyRequest.Body.userPassword = mellatpassword;
                verifyRequest.Body.saleReferenceId=Convert.ToInt64(SaleReferenceId);
                verifyRequest.Body.saleOrderId =Convert.ToInt64(SaleOrderId);
                var resultVerify = await BankMellatServiceClient.bpVerifyRequestAsync(verifyRequest);

                if (resultVerify.ToString() =="0")
                {
                    //(if) check in DB for that settle is done
                    bpSettleRequest SettleRequest=new bpSettleRequest();
                    SettleRequest.Body = new bpSettleRequestBody();
                    SettleRequest.Body.terminalId = mellatterminalid;
                    SettleRequest.Body.userName = mellatusername;
                    SettleRequest.Body.userPassword = mellatpassword;
                    SettleRequest.Body.saleReferenceId=Convert.ToInt64(SaleReferenceId);
                    SettleRequest.Body.saleOrderId =Convert.ToInt64(SaleOrderId);
                    SettleRequest.Body.orderId=Convert.ToInt64(SaleOrderId);
                    var resultSettle = await BankMellatServiceClient.bpSettleRequestAsync(SettleRequest);
                }
                

                ///log to db
                /// log veryfy

                var q = db.Tbl_pays.Where(a=> a.UserName==user).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                if (Convert.ToInt32(FinalAmount) ==q.Pay*10 )
                {
                    q.status = true;
                    db.Tbl_pays.Update(q);
                    db.SaveChanges();
                    msg = "پرداخت با موفقیت انجام شد";
                    if (HttpContext.Session.GetString("payred") == "1")
                    {
                        HttpContext.Session.SetString("pay", Diposit().ToString());
                        return RedirectToAction("index", "Wallet");
                    }
                     Diposit();
                    return RedirectToAction("index", "Wallet");
                }
                else
                {
                    
                    q.status = false;
                    db.Tbl_pays.Remove(q);
                    db.SaveChanges();
                    msg = "پرداخت نا موفق بوده است ";
                    Diposit();
                    return RedirectToAction("index", "Wallet");
                }
            }
            else
            {
                var q = db.Tbl_pays.Where(a=> a.UserName==user).OrderByDescending(a => a.Id ).Take(1).SingleOrDefault();
                q.status = false;
                db.Tbl_pays.Remove(q);
                db.SaveChanges();
                msg = "پرداخت نا موفق بوده است ";
                 Diposit();
                return RedirectToAction("index", "Wallet");
            }
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