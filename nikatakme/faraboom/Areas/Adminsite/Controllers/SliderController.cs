using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Slider;
using DataLayer.Context;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Slider;

namespace faraboom.Areas.Adminsite.Controllers
{

    public class SliderController : BaseController
    {
        public SliderController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }

        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            //////////////////////////////////////////////////selector
            var qlist = db.Tbl_Blog.ToList();
            ViewBag.list = new SelectList(qlist, "Id", "TitleBLo");
            ///////////////////////////////////////////////////////////list
            return View();
        }
        public IActionResult list()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
            ViewBag.list=db.Tbl_Slider.ToList ();
            return View();
        }
            //     //////////////////////////////list
            //     var d = db.Tbl_Slider.ToList ();
            //     if (d != null) {
            //         List<Vm_Slider> s = new List<Vm_Slider> ();
            //         foreach (var item in d) {
            //             var q = db.Tbl_Product.Where (a => a.Id == item.CategoryProductIdSlid).SingleOrDefault ();
            //             if (q ==null)
            //             {
            //                 prname="محصولی ثبت نشده";
            //             }else
            //             {
            //                 prname=q.TitleProductPro;
            //             }
            //             Vm_Slider f = new Vm_Slider () {
            //                 Id = item.Id,
            //                 ImageMainSlid = item.ImageMainSlid,
            //                 Language = item.Language,
            //                 nameproduct = prname
            //             };
            //             s.Add (f);

            //         }
            //         ViewBag.list = s.OrderByDescending (a => a.Id).ToList ();
            //     }else
            //     {
            //          ViewBag.list=null;
            //     }

            //     return View ();
            // }

            public async Task<IActionResult> add(Vm_Slider ex)
            {
                ///////////////upload file
                string FileExtension1 = Path.GetExtension(ex.img.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await ex.img.CopyToAsync(stream);

                }
                //////////////////////////end upload file 
                Tb_Slider tb = new Tb_Slider()
                {

                    ImageMainSlid = NewFileName,
                    CategoryProductIdSlid = ex.CategoryProductIdSlid,
                    Language = ex.Language
                };
                db.Tbl_Slider.Add(tb);
                db.SaveChanges();
                err = "اطلاعات با موفقیت ثبت شد";
                return RedirectToAction("index");

            }

            public IActionResult del(int id)
            {
                var qdel = db.Tbl_Slider.Where(add => add.Id == id).SingleOrDefault();
                db.Tbl_Slider.Remove(qdel);
                db.SaveChanges();
                err = "حذف رکورد مورد نظر با موفقیت انجام شد";
                return RedirectToAction("list");
            }

        }
    }