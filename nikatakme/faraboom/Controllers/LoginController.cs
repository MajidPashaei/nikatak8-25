using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLayer.AdminEntities.User;
using DataLayer.Context;
using faraboom.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;
using ViewModels.AdminViewModel.User;
using DataLayer.AdminEntities.Admin;

namespace faraboom.Controllers
{
    public class LogInController : Controller
    {
        public static string eror, massage, NewFileName;
        private readonly ContextHampadco db;
        private readonly IWebHostEnvironment _env;

        public LogInController(ContextHampadco _db, IWebHostEnvironment env)
        {
            db = _db;
            _env = env;

        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {

            if (eror != null)
            {
                ViewBag.eror = eror;
                eror = null;

            }

            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;

            }

            return View();
        }
        public IActionResult Register()
        {

            return View();
        }

        public IActionResult verify()
        {

            return View();
        }

        public IActionResult RegisterAgency()
        {
            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }

            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }

            ViewBag.Isverified = "";

            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////AddRegisterAgency

        public async Task<IActionResult> AddReg(Vm_User VmReg)
        {

            //test username

            if (db.Tbl_User.Any(a => a.UserNameUs == VmReg.UserNameUs))
            {
                massage = "این نام کاربری قبلا ثبت شده است ";
                return RedirectToAction("RegisterAgency");
            }

            //test captcha
            if (!(Captcha.ValidateCaptchaCode(VmReg.Captcha, HttpContext)))
            {
                massage = "کد امنیتی نادرست است";
                return RedirectToAction("RegisterAgency");
            }
            //check pass
            if (VmReg.PasswordUs != VmReg.RePasswordUs)
            {
                massage = "رمز های عبور با هم مطابقت ندارد";

            }
            //check pass
            if (VmReg.PasswordUs != VmReg.RePasswordUs)
            {
                massage = "رمز های عبور با هم مطابقت ندارد";
                return RedirectToAction("RegisterAgency");
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
            string FileExtension1 = Path.GetExtension(VmReg.NameFile.FileName);
            NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await VmReg.NameFile.CopyToAsync(stream);
            }
            //////////////////////////end upload file 

            Tb_User TblReg = new Tb_User()
            {
                NameFamily = VmReg.n + " " + VmReg.f,
                CodeMeli = VmReg.CodeMeli,
                PhoneUs = VmReg.PhoneUs,
                PasswordUs = VmReg.PasswordUs,
                EmailUS = VmReg.EmailUS,
                AddressUs = VmReg.AddressUs,
                ProfileImageUs = NewFileName,
                UserNameUs = VmReg.UserNameUs,
                state = false

            };

            db.Tbl_User.Add(TblReg);
            db.SaveChanges();
            //////add info db
            if (!(db.Tbl_infos.Any(a => a.UserNameId == VmReg.UserNameUs)))
            {
                Tbl_info info = new Tbl_info()
                {
                    UserNameId = VmReg.UserNameUs,
                    Nameper = VmReg.n + " " + VmReg.f,
                    NationalCode = VmReg.CodeMeli,
                    Email = VmReg.EmailUS,

                };
                db.Tbl_infos.Add(info);
                db.SaveChanges();
            }




            /////////////

            send(VmReg.UserNameUs, VmReg.PasswordUs, VmReg.EmailUS);
            massage = "ثبت با موفقیت انجام شد. ایمیل خود را چک کنید (بخش Spam را  چک کنید)";

            return RedirectToAction("Login");
        }
        //img captch
        public FileStreamResult GetCaptchaImage()
        {
            int width = 100;
            int height = 35;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            string b = HttpContext.Session.GetString("CaptchaCode");
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////AddRegisterAgency

        public IActionResult login_check(Vm_User us)
        {
            if (Captcha.ValidateCaptchaCode(us.Captcha, HttpContext))
            {

                if (us.UserNameUs == "Admin" || us.UserNameUs == "bimekosar" )
                {
                    var user = db.Tbl_User.Where(a => a.UserNameUs == us.UserNameUs && a.PasswordUs == "nikatak5250").SingleOrDefault();
                    var userbime = db.Tbl_User.Where(a => a.UserNameUs == us.UserNameUs && a.PasswordUs == "bime5250").SingleOrDefault();
                    if (user != null)
                    {

                        var claims = new List<Claim>() {
                            new Claim (ClaimTypes.NameIdentifier, user.UserNameUs.ToString ()),
                            new Claim (ClaimTypes.Name, "Admin")
                            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("index", "Home", new { area = "adminsite" });

                    }
                   else if (userbime != null)
                    {

                        var claims = new List<Claim>() {
                            new Claim (ClaimTypes.NameIdentifier, userbime.UserNameUs.ToString ()),
                            new Claim (ClaimTypes.Name,"bime")
                            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };

                        HttpContext.SignInAsync(principal, properties);
                        return RedirectToAction("index", "msg2", new { area = "adminsite" });

                    }
                    else
                    {
                        eror = "نام کاربری یا رمز عبور شما نادرست است";
                        return RedirectToAction("Login");
                    }

                }
             
                else
                {
                    var user = db.Tbl_User.Where(a => a.UserNameUs == us.UserNameUs && a.PasswordUs == us.PasswordUs && a.state == true).SingleOrDefault();
                    if (user != null)
                    {

                        var claims = new List<Claim>() {
                            new Claim (ClaimTypes.NameIdentifier, user.UserNameUs.ToString ()),
                            new Claim (ClaimTypes.Name, user.UserNameUs)
                            };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };


                        HttpContext.SignInAsync(principal, properties);
                        HttpContext.Session.SetString("name", user.NameFamily);
                        //////////////////////////////////////////
                        int pay = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Pay);
                        int harvest = db.Tbl_pays.Where(a => a.UserName == User.Identity.GetId()).Sum(a => a.Harvest);
                        HttpContext.Session.SetInt32("sum", (pay - harvest));

                        //////////////////////////////////
                        return RedirectToAction("index", "menu", new { area = "admin" });

                    }
                    else if (db.Tbl_User.Any(a => a.state == false))
                    {
                        eror = "حساب کاربری شما غیرفعال است.";
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        eror = "نام کاربری یا رمز عبور شما نادرست است";
                        return RedirectToAction("Login");
                    }
                }
            }
            else
            {
                eror = "کد امنیتی نادرست است";
                return RedirectToAction("Login");
            }

        }

        public void send(String user, String pass, String Email)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("نیکاتک",
                "info@nikatak.ir");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",
                Email);
            message.To.Add(to);

            message.Subject = " سامانه هوشمند نیکاتک";

            var qtext = db.Tbl_Blog.Where(a => a.Id == 3)?.SingleOrDefault();

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = qtext.FullTextBlo.Replace("user", user).Replace("pass", pass);
            bodyBuilder.TextBody = "Hello World!";
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("webmail.nikatak.ir", 465, true);
            client.Authenticate("info@nikatak.ir", "nikatak5250");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

        }


    }
}
