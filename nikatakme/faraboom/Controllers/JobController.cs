using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using ViewModels.AdminViewModel.Job;
using DataLayer.AdminEntities.Job;
using System.IO;
using faraboom.Models;
using Extensions;

namespace faraboom.Controllers
{
    public class JobController : BaseController
    {
        public JobController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult SabtNam()
        {
            return View();
        }

        public async Task<IActionResult> Add( Vm_JobUser vju )
        {
            var quser = db.Tbl_JobUsers.Where( a => a.CodeMeli == vju.CodeMeli).SingleOrDefault();
            if ( quser != null)
            {
                ViewBag.er = " این کدملی قبلا ثبت شده است . ";
            }
            else
            {
                var qpay = db.Tbl_JobPays.Where(a => a.Rand == vju.Rand).SingleOrDefault();
                if (qpay != null)
                {
                    try
                    {
                        if (qpay.statususe == false)
                        {
                            Tbl_JobUser tju = new Tbl_JobUser();
                            tju.Name = vju.Name;
                            tju.Family = vju.Family;
                            tju.CodeMeli = vju.CodeMeli;
                            tju.FatherName = vju.FatherName;
                            tju.Telphone = vju.Telphone;
                            tju.Mobile = vju.Mobile;
                            tju.Email = vju.Email;
                            tju.Post = vju.Post;
                            tju.Address = vju.Address;
                            tju.City = vju.City;
                            tju.Ostan = vju.Ostan;
                            tju.Rand = vju.Rand;
                            tju.Tahsilat = vju.Tahsilat;
                            tju.Reshte = vju.Reshte;
                            tju.DateTime = DateTime.Now;
                            tju.Tavalood = vju.tavalood.ToGeorgianDateTime();

                            if (vju.img_cartmeli != null)
                            {
                                string FileExtension1 = Path.GetExtension(vju.img_cartmeli.FileName);
                                string NewFileName1 = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                                var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName1}";
                                using (var stream = new FileStream(path1, FileMode.Create))
                                {
                                    await vju.img_cartmeli.CopyToAsync(stream);
                                }
                                tju.Img_CartMeli = NewFileName1;
                            }
                            if (vju.img_madraktahsili != null)
                            {
                                string FileExtension2 = Path.GetExtension(vju.img_madraktahsili.FileName);
                                string NewFileName2 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                                var path2 = $"{_env.WebRootPath}\\fileupload\\{NewFileName2}";
                                using (var stream = new FileStream(path2, FileMode.Create))
                                {
                                    await vju.img_madraktahsili.CopyToAsync(stream);
                                }
                                tju.Img_MadrakTahsili = NewFileName2;
                            }
                            if (vju.img_payankh != null)
                            {
                                string FileExtension3 = Path.GetExtension(vju.img_payankh.FileName);
                                string NewFileName3 = String.Concat(Guid.NewGuid().ToString(), FileExtension3);
                                var path3 = $"{_env.WebRootPath}\\fileupload\\{NewFileName3}";
                                using (var stream = new FileStream(path3, FileMode.Create))
                                {
                                    await vju.img_payankh.CopyToAsync(stream);
                                }
                                tju.Img_PayanKH = NewFileName3;
                            }
                            if (vju.img_shenasname != null)
                            {
                                string FileExtension4 = Path.GetExtension(vju.img_shenasname.FileName);
                                string NewFileName4 = String.Concat(Guid.NewGuid().ToString(), FileExtension4);
                                var path4 = $"{_env.WebRootPath}\\fileupload\\{NewFileName4}";
                                using (var stream = new FileStream(path4, FileMode.Create))
                                {
                                    await vju.img_shenasname.CopyToAsync(stream);
                                }
                                tju.Img_Shenasname = NewFileName4;
                            }
                            // if (vju.img_aks != null)
                            // {
                            //     string FileExtension5 = Path.GetExtension(vju.img_aks.FileName);
                            //     string NewFileName5 = String.Concat(Guid.NewGuid().ToString(), FileExtension5);
                            //     var path5 = $"{_env.WebRootPath}\\fileupload\\{NewFileName5}";
                            //     using (var stream = new FileStream(path5, FileMode.Create))
                            //     {
                            //         await vju.img_aks.CopyToAsync(stream);
                            //     }
                            //     tju.Img_Aks = NewFileName5;
                            // }
                            db.Tbl_JobUsers.Add(tju);

                            var qp = db.Tbl_JobPays.Where(a => a.Rand == vju.Rand).SingleOrDefault();
                            qp.statususe = true;
                            db.Tbl_JobPays.Update(qp);

                            db.SaveChanges();

                            ViewBag.ok = " ثبت با موفقیت انجام شد  .";
                        }
                        else
                        {
                            ViewBag.er = " این کد پیگیری قبلا ثبت شده است . ";
                        }
                        
                    }
                    catch (System.Exception ex)
                    {
                        ViewBag.er = "خطا در پارامتر های ورودی لطفا ورودی ها و تاریخ تولد خود را چک نمایید . ";
                    }
                }
                else
                {
                    ViewBag.er = "  کد پیگیری اشتباه است . ";
                }
            }
            return View();
        }

        public IActionResult Peyghiri()
        {
            return View();
        }
        public IActionResult doc()
        {
            
            return View();
        }

        public IActionResult Azmoon()
        {
            
            return View();
        }

        public IActionResult ResPey( Vm_JobUser vju )
        {
            var quser = db.Tbl_JobUsers.SingleOrDefault(a => a.Rand == vju.Rand && a.CodeMeli == vju.CodeMeli);
            if ( quser != null)
            {
                ViewBag.ok = $" کاربر با کدملی  { vju.CodeMeli }  و کد پیگیری  { vju.Rand }  با موفقیت ثبت شده است . ";
            }
            else
            {
                ViewBag.er = $" کاربری با کد ملی  { vju.CodeMeli }  و کد پیگیری  { vju.Rand }  یافت نشد . ";
            }
            return View();
        }
        
        public IActionResult req()
        {
            return View();
        }
        
        public async Task<IActionResult> Edit( Vm_JobUser vju )
        {
            var quser = db.Tbl_JobUsers.SingleOrDefault(a => a.Rand == vju.Rand && a.CodeMeli == vju.CodeMeli);
            if ( quser != null )
            {
                Vm_JobUser vj = new Vm_JobUser()
                {  
                    Id = quser.Id ,
                    Name = quser.Name ,
                    Family = quser.Family ,
                    CodeMeli = quser.CodeMeli ,
                    FatherName = quser.FatherName ,
                    Telphone = quser.Telphone ,
                    Mobile = quser.Mobile ,
                    Email = quser.Email ,
                    Post = quser.Post ,
                    Address = quser.Address ,
                    Rand = quser.Rand ,
                    Reshte = quser.Reshte ,
                    tavalood = quser.Tavalood.ToPersianDateString() ,
                    Tahsilat =  quser.Tahsilat ,
                    City = quser.City ,
                    Ostan = quser.Ostan ,
                };
                ViewBag.rand = vju.Rand;
                ViewBag.codemeli = vju.CodeMeli;
                return View(vj);
            }
            else
            {
                ViewBag.er = $" کاربری با کد ملی  { vju.CodeMeli }  و کد پیگیری  { vju.Rand }  یافت نشد . "; 
                return View();
            }

        }

        public async Task<IActionResult> Editres( Vm_JobUser vju )
        {
            var quser = db.Tbl_JobUsers.SingleOrDefault( a => a.CodeMeli == vju.CodeMeli && a.Rand == vju.Rand );
            try
            {
                quser.Name = vju.Name;
                quser.Family = vju.Family;
                quser.FatherName = vju.FatherName;
                quser.Telphone = vju.Telphone;
                quser.Mobile = vju.Mobile;
                quser.Email = vju.Email;
                quser.Post = vju.Post;
                quser.Address = vju.Address;
                quser.City = vju.City;
                quser.Ostan = vju.Ostan;
                quser.Tahsilat = vju.Tahsilat;
                quser.Reshte = vju.Reshte;
                quser.DateTime = DateTime.Now;
                quser.Tavalood = vju.tavalood.ToGeorgianDateTime();

                if (vju.img_cartmeli != null)
                {
                    string FileExtension1 = Path.GetExtension(vju.img_cartmeli.FileName);
                    string NewFileName1 = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                    var path1 = $"{_env.WebRootPath}\\fileupload\\{NewFileName1}";
                    using (var stream = new FileStream(path1, FileMode.Create))
                    {
                        await vju.img_cartmeli.CopyToAsync(stream);
                    }
                    quser.Img_CartMeli = NewFileName1;
                }

                if (vju.img_madraktahsili != null)
                {
                    string FileExtension2 = Path.GetExtension(vju.img_madraktahsili.FileName);
                    string NewFileName2 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                    var path2 = $"{_env.WebRootPath}\\fileupload\\{NewFileName2}";
                    using (var stream = new FileStream(path2, FileMode.Create))
                    {
                        await vju.img_madraktahsili.CopyToAsync(stream);
                    }
                    quser.Img_MadrakTahsili = NewFileName2;
                }

                if (vju.img_payankh != null)
                {
                    string FileExtension3 = Path.GetExtension(vju.img_payankh.FileName);
                    string NewFileName3 = String.Concat(Guid.NewGuid().ToString(), FileExtension3);
                    var path3 = $"{_env.WebRootPath}\\fileupload\\{NewFileName3}";
                    using (var stream = new FileStream(path3, FileMode.Create))
                    {
                        await vju.img_payankh.CopyToAsync(stream);
                    }
                    quser.Img_PayanKH = NewFileName3;
                }

                if (vju.img_shenasname != null)
                {
                    string FileExtension4 = Path.GetExtension(vju.img_shenasname.FileName);
                    string NewFileName4 = String.Concat(Guid.NewGuid().ToString(), FileExtension4);
                    var path4 = $"{_env.WebRootPath}\\fileupload\\{NewFileName4}";
                    using (var stream = new FileStream(path4, FileMode.Create))
                    {
                        await vju.img_shenasname.CopyToAsync(stream);
                    }
                    quser.Img_Shenasname = NewFileName4;
                }

                db.Tbl_JobUsers.Update(quser);
                db.SaveChanges();

                ViewBag.ok = " ثبت با موفقیت انجام شد  .";
                

            }
            catch ( System.Exception ex )
            {
                ViewBag.er = "خطا در پارامتر های ورودی لطفا ورودی ها و تاریخ تولد خود را چک نمایید . ";
            }

            return View();
        }
        

    }
}