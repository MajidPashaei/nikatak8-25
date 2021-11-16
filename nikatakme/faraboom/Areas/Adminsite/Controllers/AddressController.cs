using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using DataLayer.Context;
using DataLayer.AdminEntities.Address;
using ViewModels.AdminViewModel.Address;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Areas.Adminsite.Controllers
{
       public class  AddressController: BaseController
    {

        public AddressController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er=err;
                err=null;
            }

            ViewBag.list=db.Tbl_Adress.ToList();
            return View();
        }
        public IActionResult add(Vm_Address address)
        {
            var qaddress=db.Tbl_Adress.Where(a=>a.Language==address.Language).SingleOrDefault();
            if (qaddress != null)
            {
                err="قبلا برای این زبان آدرس ثبت شده است شما باید آن را حذف و دباره اضافه کنید";
            }
            else
            {
                Tb_Address add=new Tb_Address()
                {
                    Language=address.Language,
                   FirstAddress=address.FirstAddress,
                   SecondAddress=address.SecondAddress,
                   Tel1Ad=address.Tel1Ad,
                   Tel2Ad=address.Tel2Ad,
                   LocationAd=address.LocationAd,
                   Officetel1Ad=address.Officetel1Ad,
                   Officetel2Ad=address.Officetel2Ad,

                };
                db.Tbl_Adress.Add(add);
                db.SaveChanges();
                err="اطلاعات با موفقیت ثبت شد";
            }
            return RedirectToAction("index");
        }



        public IActionResult del(int id)
        {
          var selectadd=db.Tbl_Adress.Where(a=>a.Id==id).SingleOrDefault();
          db.Tbl_Adress.Remove(selectadd);
          db.SaveChanges();
          err="حذف با موفقیت انجام شد";
          return RedirectToAction("index");
        }

    }
}