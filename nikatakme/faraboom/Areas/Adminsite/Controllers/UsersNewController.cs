using System.Collections.Generic;
using System.Linq;
using DataLayer.Context;
using Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Admin;

namespace faraboom.Areas.Adminsite.Controllers
{

    public class UsersNewController : BaseController
    {

        public UsersNewController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env) { }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            // List<Vm_User> us = new List<Vm_User> ();
            // var q = db.Tbl_User.OrderByDescending (a => a.Id).ToList ();
            // foreach (var item in q) {
            //     var b = db.Tbl_infos.Where (a => a.UserNameId == item.UserNameUs).SingleOrDefault ();
            //     if (b != null) {
            //         string d = null;
            //         if (b.Locationaddress == "ok") {
            //             d = "ok";
            //         }
            //         Vm_User ff = new Vm_User () {
            //             Id = item.Id,
            //             UserNameUs = item.UserNameUs,
            //             EmailUS = item.EmailUS,
            //             PhoneUs = item.PhoneUs,
            //             PasswordUs = item.PasswordUs,
            //             AddressUs = item.AddressUs,
            //             NameFamily = item.NameFamily,
            //             CodeMeli = item.CodeMeli,
            //             state = item.state,
            //             pay = d,
            //             ProfileImageUs=item.ProfileImageUs,

            //         };
            //         us.Add (ff);

            //     }
            // }

            // ViewBag.list = us.OrderByDescending (a => a.Id).ToList ();
            List<Vm_info> us = new List<Vm_info>();
            var dbl = db.Tbl_infos.Where(a => a.Typeactivity == "Request").ToList();
            if (dbl != null)
            {
                foreach (var item in dbl)
                {
                    Vm_info ff = new Vm_info()
                    {
                        Id = item.Id,
                        Nameper = item.Nameper,
                        Familyper = item.Familyper,
                        NationalCode = item.NationalCode,
                        code = item.code,
                        PhoneHome = item.PhoneHome,
                        Phone = item.Phone,
                        State = item.State,
                        City = item.City,
                        Postalcode = item.Postalcode,
                        DateRegister = item.DateRegister.ToPersianDateString(),
                        Nationalcard = item.Nationalcard,
                        Certificate = item.Certificate,
                        Degreeeducation = item.Degreeeducation,
                        Document = item.Document,
                    };
                    us.Add (ff);
                }
                ViewBag.list = us ;
            }
            return View();
        }
        public IActionResult del(int id)
        {
            var selectdel = db.Tbl_infos.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_infos.Remove(selectdel);
            db.SaveChanges();
            err = "حذف با موفقیت انجام شد";
            return RedirectToAction("index");
        }
    }
}