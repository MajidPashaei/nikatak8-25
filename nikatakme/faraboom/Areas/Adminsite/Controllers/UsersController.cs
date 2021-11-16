using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.User;


namespace faraboom.Areas.Adminsite.Controllers
{

    public class UsersController : BaseController
    {

        public UsersController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env) { }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            List<Vm_User> us = new List<Vm_User>();
            var q = db.Tbl_User.OrderByDescending(a => a.Id).ToList();
            foreach (var item in q)
            {
                var b = db.Tbl_infos.Where(a => a.UserNameId == item.UserNameUs).SingleOrDefault();
                if (b != null)
                {
                    string d = null;
                    if (b.Locationaddress == "ok")
                    {
                        d = "ok";
                    }
                    Vm_User ff = new Vm_User()
                    {
                        Id = item.Id,
                        UserNameUs = item.UserNameUs,
                        EmailUS = item.EmailUS,
                        PhoneUs = item.PhoneUs,
                        PasswordUs = item.PasswordUs,
                        AddressUs = item.AddressUs,
                        NameFamily = item.NameFamily,
                        CodeMeli = item.CodeMeli,
                        state = item.state,
                        pay = d,
                        ProfileImageUs = item.ProfileImageUs,
                    };
                    us.Add(ff);

                }
            }



            ViewBag.list = us.OrderByDescending(a => a.Id).ToList();
            return View();
        }
        public IActionResult del(int id)
        {
            var selectdel = db.Tbl_User.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_User.Remove(selectdel);
            db.SaveChanges();
            err = "حذف با موفقیت انجام شد";
            return RedirectToAction("index");
        }

        public IActionResult confirm(int id)
        {
            var selectdel = db.Tbl_User.Where(a => a.Id == id).SingleOrDefault();
            selectdel.state = true;
            db.Tbl_User.Update(selectdel);
            db.SaveChanges();
            err = "تایید با موفقیت انجام شد";
            return RedirectToAction("index");
        }

        public IActionResult confirm2(int id)
        {
            var selectdel = db.Tbl_User.Where(a => a.Id == id).SingleOrDefault();
            selectdel.state = false;
            db.Tbl_User.Update(selectdel);
            db.SaveChanges();
            err = " عدم تایید با موفقیت انجام شد ";
            return RedirectToAction("index");
        }


        public IActionResult Membership()
        { 
        if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.Membership = db.Tbl_Memberships.ToList();
            return View();
        }
        public IActionResult del2(int id)
        {
            var del = db.Tbl_Memberships.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_Memberships.Remove(del);
            db.SaveChanges();
            err = "حذف با موفقیت انجام شد";
            return RedirectToAction("Membership");
        }

    }
}