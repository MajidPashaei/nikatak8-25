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
using ServiceReference;
using ViewModels.AdminViewModel.Charge;

namespace Admin.Controllers {
    [Area ("Admin")]

    public class ChargeController : BaseController
    {
        public ChargeController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {
        }
        ///      صفحه گرفتن پارامتر ها
        public IActionResult Parametrs()
        {
            return View();
        }
        ///    صفحه اعمال شارژ  
        public IActionResult DoSharge(Vm_Charge charge)
        {
            //check mojodi
            if (HttpContext.Session.GetInt32("sum") >= (Convert.ToInt32(charge.TotalAmount)/10))
            {
                try
                {
                    int Rn;
                    var R=new Random();
                    Rn=R.Next(100000, 999999);
                    ChargeSrvClient client = new ChargeSrvClient();
                    ///     ارسال پارمتر ها
                    var result=client.ReserveChargeAsync
                    (new RequestModel
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
                            ///// قیمت-
                            TotalAmount=charge.TotalAmount,
                            //// نوع شارژ-
                            ChargeType=charge.ChargeType,
                            //// درگاه خرید ثابت-
                            DeviceType=05,
                            //// اپراتور-
                            OperatorId=charge.OperatorId,
                        }
                    ).Result;
                    if (result.Status==true)
                    {
                        ///    چک کردن پارامتر ها و اعمال شارژ
                        var SendRefrense=client.ApproveAsync
                        (new RequestModel
                            {
                                Username="nikatakuser",
                                Password="n!K@T@k",
                                LocalDateTime=DateTime.Now,
                                ReserveNumber=result.ReserveNumber,
                                ReferenceNumber=result.ReferenceNumber,
                                CardNumber="6037701607760128",
                                NationalCode="2851868012",
                            }
                        ).Result;
                        /// pay Fish
                            Tbl_Request tb1 = new Tbl_Request
                            {
                                UserName = User.Identity.GetId(),
                                Type_Request = "خرید شارژ"+" "+ SendRefrense.Operator,
                                Bill_Id = Convert.ToString(result.ReserveNumber),
                                Pay_Id = Convert.ToString(result.ReferenceNumber),
                                Amount =charge.TotalAmount/10,
                                Titel_Request =charge.CellNumber,
                                Date_Request = DateTime.UtcNow,
                            };
                            db.Tbl_Requests.Add(tb1);
                            db.SaveChanges();
                                var qfinal1 = db.Tbl_Requests.Where(a => a.UserName == User.Identity.GetId()).OrderByDescending(a => a.Id).Take(1).SingleOrDefault();
                                Diposit();
                                proccesscharge(charge.TotalAmount/10,charge.TotalAmount/10, qfinal1.Id);
                        ViewBag.mesage="شارژ با موفقیت انجام شد";
                        ViewBag.LocalDateTime=SendRefrense.LocalDateTime;
                        ViewBag.Operator=SendRefrense.Operator;
                        ViewBag.ReferenceNumber=SendRefrense.ReferenceNumber;
                        ViewBag.ReserveNumber=SendRefrense.ReserveNumber;
                        ViewBag.ReturnMsg=SendRefrense.ReturnMsg;
                        ViewBag.CellNumber=charge.CellNumber;
                        ViewBag.TotalAmount=charge.TotalAmount;
                    }
                    else
                    {
                        ViewBag.mesagee="شارژ ناموفق مجددا امتحان کنید";
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
        public IActionResult CheckRequest()
        {
            return View();
        }
        public IActionResult CheckRequestResult(Vm_Charge charge)
        {
            //ایجاد و استفاده از سرویس پیگیری سفارش 
            ChargeSrvClient client = new ChargeSrvClient();
             var result=client.CheckRequestAsync
                    (new RequestModel
                        {
                            Username="nikatakuser",
                            Password="n!K@T@k",
                            LocalDateTime=DateTime.Now,
                            ReferenceNumber=charge.Reference,
                            ReserveNumber=charge.Reserve,
                        }
                    ).Result;
            ViewBag.Description=result.Description;
            ///    بستن سرویس
            client.Close();
            return View();
        }
    }
}