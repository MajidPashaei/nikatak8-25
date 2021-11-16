using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.AdminEntities.Originality;
using ViewModels.AdminViewModel.Originality;

namespace faraboom.Areas.Adminsite.Controllers
{
    
    public class  OriginalityController: BaseController
    {
       public OriginalityController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
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
            var qlist=db.Tbl_Product.ToList();
            ViewBag.list=new SelectList(qlist,"Id","TitleProductPro");
            ///////////////////////////////////////////////////////////list
            var orgin =db.Tbl_Originality.ToList();
            if (orgin.Count() != 0)
            {
                List<Vm_Originality>  originality=new  List<Vm_Originality>();
            foreach (var item in orgin)
            {
                var product=db.Tbl_Product.Where(a=>a.Id==item.IdProductOri).SingleOrDefault();
                if (product != null)
                {
                     Vm_Originality  origin1=new Vm_Originality()
                 {
                     Id=item.Id,
                     nameproduct=product.TitleProductPro,
                     HologramCodeOri=item.HologramCodeOri,
                     NumberProductOri=item.NumberProductOri,
                     Language=item.Language,
                     DateCreateOri=item.DateCreateOri
                 };
                 originality.Add(origin1);
                }

                

            }
            
            ViewBag.listp=originality.OrderByDescending(a=>a.Id).ToList();
                
            }else
            {
                            ViewBag.listp=null;
            }
            
            //////////////////////////////////////////////////////////
            return View();
        }

        public IActionResult add(Vm_Originality og)
        {
            if (db.Tbl_Originality.Any(a=>a.NumberProductOri==og.NumberProductOri || a.HologramCodeOri==og.HologramCodeOri))
            {
                err="این شماره هولوگرام یا کد کالا قبلا ثبت شده است";
               return RedirectToAction("index");
            }
            else
            {
                 Tb_Originality qlist=new Tb_Originality()
            {
                IdProductOri=og.IdProductOri,
                NumberProductOri=og.NumberProductOri,
                HologramCodeOri=og.HologramCodeOri,
                Language=og.Language,
                DateCreateOri=DateTime.Today

            };

            db.Tbl_Originality.Add(qlist);
            db.SaveChanges();
            err="اطلاعات با موفقیت ثبت شد.";
            return RedirectToAction("index");
            }
           


        }
        



        public IActionResult del(int id)
        {
            var qselect=db.Tbl_Originality.Where(a=>a.Id==id).SingleOrDefault();
            db.Tbl_Originality.Remove(qselect);
            db.SaveChanges();
            err="اطلاعات با موفقیت حذف شد";
            return RedirectToAction("index");
            
        }


    }
}