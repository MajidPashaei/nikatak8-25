using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Controllers
{
       public class GalleryController : BaseController
    {
       ////////////////////////////////////////////////////type db
         public GalleryController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {
            
        }
         
        //////////////////////////////////////////////////////////
        public IActionResult Index()
        {
            setdata();
           ////////////////////////////////////////////////////////////////////////////////////////////////address
          
           var gallery=db.Tbl_Gallery.Where(a=>a.Language==ln).OrderByDescending(a=>a.Id).ToList();
            if (gallery != null)
            {
                  ViewBag.gallery=gallery;
                 
            }else
            {
                 ViewBag.gallery=null;
            }
           return View();
        }


        public IActionResult details(int? id)
        {
           ////////////////////////////////////////////////////////////////////////////////////////////////address
          
           var gallery=db.tb_ImageGalleries.OrderByDescending(a=>a.Id).ToList();
            
                  ViewBag.gallery=gallery;
            
           return View();
        }
        
        public IActionResult gallery()
        {
           return View();
        }
        

    }
}
