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
using ViewModels.AdminViewModel.Contact;
using DataLayer.AdminEntities.Contact;

namespace faraboom.Controllers
{
       public class ContactController : BaseController
    {

        
        public static string msg;
       
        ////////////////////////////////////////////////////type db
        public ContactController(ContextHampadco _db, IWebHostEnvironment env):base(_db,env)
        {
           
        }

         
        //////////////////////////////////////////////////////////
        public IActionResult Index()
        {
             setdata();
           ////////////////////////////////////////////////////////////////////////////////////////////////address
           var address=db.Tbl_Adress.Where(a=>a.Language==ln ).ToList();
            if (address != null)
            {
                  ViewBag.address=address;
                 
            }else
            {
                 ViewBag.address=null;
            }

             if (msg != null)
            {
                ViewBag.msg = msg;
                msg = null;
            }

           return View();
        }

        public IActionResult Add(Vm_Contact A)
        {
            Tbl_Contact b=new Tbl_Contact()
            {
                Email=A.Email,
                Phone=A.Phone,
                Title=A.Title,
                Text=A.Text

            };
            db.Tbl_Contacts.Add(b);
            db.SaveChanges();
            msg="پیام شما در سیستم ثبت شد و به زودی از طریق ایمیل یا شماره تماس به پیام شما پاسخ داده خواهد شد";
            

           
           return RedirectToAction("Index");
        }
        
        
        

    }
}
