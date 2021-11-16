using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Blog;
using DataLayer.AdminEntities.Category;
using DataLayer.Context;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Blog;
using ViewModels.AdminViewModel.Category;

namespace faraboom.Areas.Adminsite.Controllers {
   
    public class BlogController : BaseController {
       public BlogController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index () {

            //////////////////////////////////////////////////////////////////////////////////list
            var qlist = db.tbl_category.Where (a => a.FatherIdCat == -2 || a.FatherIdCat==-3).ToList ();
            var listtb = new List<Tb_Category> ();

            if (qlist != null) {
                foreach (var item in qlist) {
                    var qselect = db.tbl_category.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count() != 0) {
                        foreach (var item1 in qselect) {
                        var b = new Tb_Category () {
                        Id = item1.Id,
                        NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
                        FatherIdCat = item1.FatherIdCat
                            };
                            listtb.Add (b);
                        }

                    } else {
                        listtb.Add (item);

                    }

                }
                ViewBag.list = new SelectList (listtb, "Id", "NameCat");
            } else {
                ViewBag.list = null;
            }

            //////////////////////////////////////////////////////////////////////////////////list
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }

            return View ();
        }

        public IActionResult updateblog (int id) {
            //////////////////////////////////////////////////////////////////////////////////list
            var qlist = db.tbl_category.Where (a => a.FatherIdCat == -2 || a.FatherIdCat == -3).ToList ();
            var listtb = new List<Tb_Category> ();

            if (qlist != null) 
            {
                foreach (var item in qlist)
                {
                    var qselect = db.tbl_category.Where (a => a.FatherIdCat == item.Id).ToList ();
                    if (qselect.Count() != 0)
                     {
                        foreach (var item1 in qselect) 
                        {
                        var b = new Tb_Category () {
                        Id = item1.Id,
                        NameCat = item1.NameCat + "  " + "-->" + "  " + item.NameCat,
                        FatherIdCat = item1.FatherIdCat
                            };
                            listtb.Add (b);
                        }

                    }
                     else {
                        listtb.Add (item);

                    }

                }
                ViewBag.list = new SelectList (listtb, "Id", "NameCat");
            }
            else
             {
                ViewBag.list = null;
              }

            //////////////////////////////////////////////////////////////////////////////////list
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }

            if (id != null) {
                Vm_Blog qblog = new Vm_Blog ();
                var list = db.Tbl_Blog.Where (a => a.Id == id).SingleOrDefault ();
                qblog.Id = list.Id;
                qblog.TitleBLo = list.TitleBLo;
                qblog.Language = list.Language;
                qblog.IdCtegoryBlo = list.IdCtegoryBlo;
                qblog.SummaryBlo = list.SummaryBlo;
                qblog.ImageMainBlo = list.ImageMainBlo;
                qblog.FullTextBlo = list.FullTextBlo;
                qblog.KeywordsBlo = list.KeywordsBlo;

                return View (qblog);
            }
            return View ();

        }

        public IActionResult list () {
            //////////////////////////////////////////////////////////////////////////////////list
            if (err != null) {
                ViewBag.er = err;
                err = null;
            }

            List<Vm_Blog> qlist = new List<Vm_Blog> ();
            var qblog = db.Tbl_Blog.OrderByDescending (a => a.Id).ToList ();
            foreach (var item in qblog) {
                var qcat = db.tbl_category.Where (a => a.Id == item.IdCtegoryBlo).SingleOrDefault ();
                if (qcat != null)
                {
                     var n = new Vm_Blog () {
                    Id = item.Id,
                    TitleBLo = item.TitleBLo,
                    Language = item.Language,
                    ImageMainBlo = item.ImageMainBlo,
                    catname = qcat.NameCat
                };
                qlist.Add (n);
                }
               

            }
            ViewBag.list = qlist.OrderByDescending (a => a.Id).ToList ();
            return View ();
        }

        public async Task<IActionResult> add (Vm_Blog blog) {
            ///////////////upload file
            string FileExtension1 = Path.GetExtension (blog.file.FileName);
            NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
            var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
            using (var stream = new FileStream (path, FileMode.Create)) {

                await blog.file.CopyToAsync (stream);

            }
            //////////////////////////end upload file 
            var b = new Tb_Blog () {
                Language = blog.Language,
                TitleBLo = blog.TitleBLo,
                IdCtegoryBlo = blog.IdCtegoryBlo,
                SummaryBlo = blog.SummaryBlo,
                ImageMainBlo = NewFileName,
                KeywordsBlo = blog.KeywordsBlo,
                FullTextBlo = blog.FullTextBlo,

            };
            db.Tbl_Blog.Add (b);
            db.SaveChanges ();
            err = "اطلاعات با موفقیت ثبت شد";

            return RedirectToAction ("index");
        }

        public async Task<IActionResult> update (Vm_Blog blog) {
            var qselect = db.Tbl_Blog.Where (a => a.Id == blog.Id).SingleOrDefault ();

            ///////////////upload file
            if (blog.file != null) {
                string FileExtension1 = Path.GetExtension (blog.file.FileName);
                NewFileName = String.Concat (Guid.NewGuid ().ToString (), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream (path, FileMode.Create)) {

                    await blog.file.CopyToAsync (stream);

                }
                ////////////////////////////////////////////
                if (qselect != null) {
                    qselect.TitleBLo = blog.TitleBLo;
                    qselect.IdCtegoryBlo = blog.IdCtegoryBlo;
                    qselect.Language = blog.Language;
                    qselect.SummaryBlo = blog.SummaryBlo;
                    qselect.ImageMainBlo = NewFileName;
                    qselect.FullTextBlo = blog.FullTextBlo;
                    qselect.KeywordsBlo = blog.KeywordsBlo;

                };
                db.Tbl_Blog.Update (qselect);
                db.SaveChanges ();
                err = "اطلاعات با موفقیت بروز رسانی شد";
                return RedirectToAction ("list");

            } else {
                ////////////////////////////////////////////
                if (qselect != null) {
                    qselect.TitleBLo = blog.TitleBLo;
                    qselect.IdCtegoryBlo = blog.IdCtegoryBlo;
                    qselect.Language = blog.Language;
                    qselect.SummaryBlo = blog.SummaryBlo;
                    qselect.FullTextBlo = blog.FullTextBlo;
                    qselect.KeywordsBlo = blog.KeywordsBlo;

                };
                db.Tbl_Blog.Update (qselect);
                db.SaveChanges ();
                err = "اطلاعات با موفقیت بروز رسانی شد";
                return RedirectToAction ("list");
            }

        }

        public IActionResult del (int id) {
            if (id != null) {
                var qselect = db.Tbl_Blog.Where (a => a.Id == id).SingleOrDefault ();
                db.Tbl_Blog.Remove (qselect);
                db.SaveChanges ();
                err = "رکورد مورد نظر با موفقیت حذف شد";
                return RedirectToAction ("list");

            }
            return RedirectToAction ("list");

        }

    }
}