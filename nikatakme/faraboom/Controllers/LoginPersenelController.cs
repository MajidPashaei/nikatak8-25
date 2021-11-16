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

namespace faraboom.Controllers {
        public class LoginPersenelController : Controller {
            public static string eror, massage, NewFileName;
            private readonly ContextHampadco db;
            private readonly IWebHostEnvironment _env;

            public LoginPersenelController (ContextHampadco _db, IWebHostEnvironment env) {
                db = _db;
                _env = env;

            }

            public IActionResult Index () {

                return View ();
            }
            public IActionResult Login () {
                
                if (eror != null) {
                   ViewBag.eror = eror;
                    eror = null;

                }

                if (massage != null) {
                    ViewBag.msg = massage;
                    massage = null;

                }
                
                 
                return View ();
            }
            public IActionResult Register () {

                return View ();
            }

            public IActionResult verify () {

                return View ();
            }

            public IActionResult RegisterAgency () {
                if (massage != null) {
                    ViewBag.msg = massage;
                    massage = null;

                }

                if (massage != null) {
                    ViewBag.msg = massage;
                    massage = null;

                }

                ViewBag.Isverified = "";

                return View ();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////AddRegisterAgency

            public async Task<IActionResult> AddReg (Vm_UserPersenel VmReg) {

                //test username

                if (db.Tbl_UserPersenel.Any (a => a.UserNameUs == VmReg.UserNameUs)) {
                    massage = "این نام کاربری قبلا ثبت شده است ";
                    return RedirectToAction ("RegisterAgency");
                }

                //test captcha
                if (!(Captcha.ValidateCaptchaCode (VmReg.Captcha, HttpContext))) {
                    massage = "کد امنیتی نادرست است";
                    return RedirectToAction ("RegisterAgency");
                }
                //check pass
                if (VmReg.PasswordUs != VmReg.RePasswordUs) {
                    massage = "رمز های عبور با هم مطابقت ندارد";

                }
                //check pass
                if (VmReg.PasswordUs != VmReg.RePasswordUs) {
                    massage = "رمز های عبور با هم مطابقت ندارد";
                    return RedirectToAction ("RegisterAgency");
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension1 = Path.GetExtension (VmReg.NameFile.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {
                    await VmReg.NameFile.CopyToAsync (stream);
                }
                //////////////////////////end upload file 

                Tb_UserPersenel TblReg = new Tb_UserPersenel () {
                    NameFamily = VmReg.NameFamily,
                    CodeMeli = VmReg.CodeMeli,
                    PhoneUs = VmReg.PhoneUs,
                    PasswordUs = VmReg.PasswordUs,
                    EmailUS = VmReg.EmailUS,
                    AddressUs = VmReg.AddressUs,
                    ProfileImageUs = NewFileName,
                    UserNameUs = VmReg.UserNameUs,
                    state = false

                };
                
                db.Tbl_UserPersenel.Add (TblReg);
                db.SaveChanges ();
                //////add info db
                if(!(db.Tbl_infoPersenels.Any(a=>a.UserNameId==VmReg.UserNameUs)))
            {
                Tbl_infoPersenel info =new Tbl_infoPersenel()
                {
                    UserNameId=VmReg.UserNameUs,
                    State=VmReg.State,
                    City=VmReg.City,
                    NationalCode=VmReg.CodeMeli,

                                        };
                db.Tbl_infoPersenels.Add (info);
                db.SaveChanges ();
            }
                

            

                /////////////

                send (VmReg.UserNameUs, VmReg.PasswordUs, VmReg.EmailUS);
                massage = "ثبت با موفقیت انجام شد. ایمیل خود را چک کنید (بخش Spam را  چک کنید)";
                return RedirectToAction ("Login","LoginPersenel");
            }
            //img captch
            public FileStreamResult GetCaptchaImage () {
                int width = 100;
                int height = 35;
                var captchaCode = Captcha.GenerateCaptchaCode ();
                var result = Captcha.GenerateCaptchaImage (width, height, captchaCode);
                HttpContext.Session.SetString ("CaptchaCode", result.CaptchaCode);
                string b = HttpContext.Session.GetString ("CaptchaCode");
                Stream s = new MemoryStream (result.CaptchaByteData);
                return new FileStreamResult (s, "image/png");
            }
            ////////////////////////////////////////////////////////////////////////////////////////////AddRegisterAgency

            public IActionResult login_check (Vm_UserPersenel us) {

                if (Captcha.ValidateCaptchaCode (us.Captcha, HttpContext))
                 {
                    
                        var user = db.Tbl_UserPersenel.Where (a => a.UserNameUs == us.UserNameUs && a.PasswordUs == us.PasswordUs).SingleOrDefault ();

                        if (user != null) {

                            var claims = new List<Claim> () {
                            new Claim (ClaimTypes.NameIdentifier, user.UserNameUs.ToString ()),
                            new Claim (ClaimTypes.Name, "Persenel")
                            };

                            var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var principal = new ClaimsPrincipal (identity);

                            var properties = new AuthenticationProperties {
                                IsPersistent = true
                            };

                            HttpContext.SignInAsync (principal, properties);

                            HttpContext.Session.SetString("name",user.NameFamily);
                            return RedirectToAction ("form", "Persenel", new { area = "Persenel" });

                        } 
                        else {
                            eror = "نام کاربری یا رمز عبور شما نادرست است";
                            return RedirectToAction ("Login","LoginPersenel");
                        }

                 } 
                   else {
                        eror = "کد امنیتی نادرست است";
                        return RedirectToAction ("Login","LoginPersenel");
                    }

                
            }

                public void send (String user, String pass, String Email) {
                    MimeMessage message = new MimeMessage ();

                    MailboxAddress from = new MailboxAddress ("نیکاتک",
                        "info@nikatak.ir");
                    message.From.Add (from);

                    MailboxAddress to = new MailboxAddress ("User",
                        Email);
                    message.To.Add (to);

                    message.Subject = " سامانه هوشمند نیکاتک";

                    var qtext = db.Tbl_Blog.Where (a => a.Id == 3)?.SingleOrDefault ();

                    BodyBuilder bodyBuilder = new BodyBuilder ();
                    bodyBuilder.HtmlBody = qtext.FullTextBlo.Replace ("user", user).Replace ("pass", pass);
                    bodyBuilder.TextBody = "Hello World!";
                    message.Body = bodyBuilder.ToMessageBody ();

                    SmtpClient client = new SmtpClient ();
                    client.Connect ("webmail.nikatak.ir", 465, true);
                    client.Authenticate ("info@nikatak.ir", "12345@Iran");
                    client.Send (message);
                    client.Disconnect (true);
                    client.Dispose ();

                }

            }
        }
