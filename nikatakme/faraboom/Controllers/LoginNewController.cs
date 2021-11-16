using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer.AdminEntities.Admin;
using ViewModels.AdminViewModel.Admin;
using ViewModels.AdminViewModel.Membership;
using DataLayer.AdminEntities.Membership;

namespace faraboom.Controllers
{
    public class LoginNewController : Controller
    {
        public static string eror, massage, NewFileName, NewFileName2, NewFileName3, NewFileName4;
        private readonly ContextHampadco db;
        private readonly IWebHostEnvironment _env;

        public LoginNewController(ContextHampadco _db, IWebHostEnvironment env)
        {
            db = _db;
            _env = env;

        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Membership(Vm_Membership vm)
        {
            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }
            Tbl_Membership tm = new Tbl_Membership
            {
                Name = vm.Name,
                Family = vm.Family,
                NationalCode = vm.NationalCode,
                Phone = vm.Phone,
                Code = vm.Code,
                State = vm.State,
                City = vm.City,
            };
            db.Tbl_Memberships.Add(tm);
            db.SaveChanges();
            massage = "عضویت شما با موفقیت ثبت شد";
            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;
            }
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



        public IActionResult RegisterAgency()
        {
            if (massage != null)
            {
                ViewBag.msg = massage;
                massage = null;

            }



            ViewBag.Isverified = "";

            return View();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////AddRegisterAgency

        public async Task<IActionResult> AddReg(Vm_info VmReg)
        {
            if (!(Captcha.ValidateCaptchaCode(VmReg.Serial, HttpContext)))
            {
                massage = "کد امنیتی نادرست است";
                return RedirectToAction("RegisterAgency");
            }

            //test username


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
            string FileExtension1 = Path.GetExtension(VmReg.FNationalcard.FileName);
            NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await VmReg.FNationalcard.CopyToAsync(stream);
            }
            //////////////////////////end upload file 
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
            string FileExtension2 = Path.GetExtension(VmReg.FCertificate.FileName);
            NewFileName2 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
            var path2 = $"{_env.WebRootPath}\\fileupload\\{NewFileName2}";
            using (var stream = new FileStream(path2, FileMode.Create))
            {
                await VmReg.FCertificate.CopyToAsync(stream);
            }
            //////////////////////////end upload file 
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
            string FileExtension3 = Path.GetExtension(VmReg.FDegreeeducation.FileName);
            NewFileName3 = String.Concat(Guid.NewGuid().ToString(), FileExtension3);
            var path3 = $"{_env.WebRootPath}\\fileupload\\{NewFileName3}";
            using (var stream = new FileStream(path3, FileMode.Create))
            {
                await VmReg.FDegreeeducation.CopyToAsync(stream);
            }
            //////////////////////////end upload file 
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
            if (VmReg.FDocument != null)
            {
                string FileExtension4 = Path.GetExtension(VmReg.FDocument.FileName);
                NewFileName4 = String.Concat(Guid.NewGuid().ToString(), FileExtension4);
                var path4 = $"{_env.WebRootPath}\\fileupload\\{NewFileName4}";
                using (var stream = new FileStream(path4, FileMode.Create))
                {
                    await VmReg.FDocument.CopyToAsync(stream);
                }
            }
            //////////////////////////end upload file  


            Tbl_info TblReg = new Tbl_info()
            {
                Nameper = VmReg.Nameper,
                Familyper = VmReg.Familyper,
                NationalCode = VmReg.NationalCode,
                PhoneHome = VmReg.PhoneHome,
                Phone = VmReg.Phone,
                code = VmReg.code,
                Email = VmReg.Email,
                DateRegister = DateTime.UtcNow,
                Postalcode = VmReg.Postalcode,
                Nationalcard = NewFileName,
                Certificate = NewFileName2,
                Degreeeducation = NewFileName3,
                Document = NewFileName4,
                State = VmReg.State,
                City = VmReg.City,
                Typeactivity = "Request"

            };

            db.Tbl_infos.Add(TblReg);
            db.SaveChanges();
            //////add info db





            /////////////

            // send (VmReg.UserNameUs, VmReg.PasswordUs, VmReg.EmailUS);
            massage = "درخواست شما با موفقیت ارسال شد";
            return RedirectToAction("RegisterAgency");
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



    }
}
