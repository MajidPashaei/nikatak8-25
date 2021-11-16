using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using DataLayer.Context;
using ViewModels.AdminViewModel.SocialNetwork;
using DataLayer.AdminEntities.SocialNetwork;
using Microsoft.AspNetCore.Hosting;

namespace faraboom.Areas.Adminsite.Controllers
{
   
    public class SocialNetworkController : BaseController
    {
        public SocialNetworkController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////index logo

        public IActionResult Index()
        {
             if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }

            var list=db.Tbl_SocialNetwork.SingleOrDefault();
            if (list != null)
            {
             var qlist=new Vm_SocialNetwork()
            {
              Instagram=list.Instagram,
              Telegram=list.Telegram,
              Aparat=list.Aparat,
              Facebook=list.Aparat,
              Whatsapp=list.Whatsapp
            };
           return View(qlist);
            }
          
            return View();
        }

        public IActionResult add(Vm_SocialNetwork soc)
        {
          var listp=db.Tbl_SocialNetwork.SingleOrDefault();
          if (listp != null)
          {
              listp.Instagram=soc.Instagram;
              listp.Aparat=soc.Aparat;
              listp.Facebook=soc.Facebook;
              listp.Telegram=soc.Telegram;
              listp.Whatsapp=soc.Whatsapp;

              db.Tbl_SocialNetwork.Update(listp);
              db.SaveChanges();

              err="اطلاعات با موفقیت بروز رسانی شد";
          }
          else
          {
              var social=new Tb_SocialNetwork()
              {
                Instagram=soc.Instagram,
                Aparat=soc.Aparat,
                Facebook=soc.Facebook,
                Telegram=soc.Telegram,
                Whatsapp=soc.Whatsapp
              };

              db.Tbl_SocialNetwork.Add(social);
              db.SaveChanges();
              err="اطلاعات با موفقیت ثبت شد";
          }
          return RedirectToAction("index");

        }

    }
}