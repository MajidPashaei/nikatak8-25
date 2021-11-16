using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using ViewModels.AdminViewModel.User;

namespace faraboom.Areas.Adminsite.Controllers
{
    
    public class  UsersPersenelController: BaseController
    {
        
            public UsersPersenelController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }
        public IActionResult Index()
        {
            if (err != null)
            {
                ViewBag.er = err;
                err = null;
            }
           
             List<Vm_UserPersenel> us=new List<Vm_UserPersenel>();
            var q=db.Tbl_UserPersenel.OrderByDescending(a=>a.Id).ToList();
            foreach (var item in q)
            {
                var b=db.Tbl_infoPersenels.Where(a=>a.UserNameId==item.UserNameUs).SingleOrDefault();
                if (b!= null)
                {
                     string d=null;
                    if (b.Locationaddress=="ok")
                    {
                        d="ok";
                    }
                    Vm_UserPersenel ff=new Vm_UserPersenel()
                    {
                        Id=item.Id,
                        UserNameUs=item.UserNameUs,
                        EmailUS=item.EmailUS,
                        PhoneUs=item.PhoneUs,
                        PasswordUs=item.PasswordUs,
                        AddressUs=item.AddressUs,
                        NameFamily=item.NameFamily,
                        CodeMeli=item. CodeMeli,
                        state=item.state,
                        pay=d,
                        ProfileImageUs=item.ProfileImageUs,



                    };
                    us.Add(ff);

                    
                }
            }

           
            ViewBag.list=us.OrderByDescending(a=>a.Id).ToList();
            return View();
        }
         public IActionResult del(int id)
        {
            var selectdel = db.Tbl_UserPersenel.Where(a => a.Id == id).SingleOrDefault();
            db.Tbl_UserPersenel.Remove(selectdel);
            db.SaveChanges();
            err = "حذف با موفقیت انجام شد";
            return RedirectToAction("index");
        }

    }
}