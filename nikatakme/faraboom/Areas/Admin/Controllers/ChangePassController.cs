using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.User;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.User;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ChangePass : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;
        public static string massage, massage1;
        public ChangePass(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;
        }
        public IActionResult index(Vm_UserPersenel us)
        {

            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }
            if (massage1 != null)
            {
                ViewBag.msg1 = massage1;
                massage1 = null;
            }
            return View();
        }
        public IActionResult Change(Vm_User pass)
        {
            var user = db.Tbl_User.Where(a => a.UserNameUs == User.Identity.GetId()).SingleOrDefault();
            if (user.PasswordUs != pass.n)
            {
                massage = "رمز عبور قبلی نادرست است .";
            }
            else if (pass.PasswordUs != pass.RePasswordUs)
            {
                massage = "رمز های ورودی جدید مطابقت ندارند .";
            }
            else
            {
                user.PasswordUs = pass.PasswordUs;
                db.Tbl_User.Update(user);
                db.SaveChanges();
                massage1 = " رمزعبور با موفقیت تغییر یافت .";
            }
            return RedirectToAction("index");
        }
    }
}