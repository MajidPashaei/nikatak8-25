using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using  faraboom.Models;
using DataLayer.Context;
using ViewModels.AdminViewModel.User;
using DataLayer.AdminEntities.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.Message;
using ViewModels.AdminViewModel.Message;
using  faraboom.Models;
using Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kavenegar;

namespace Mobile.Controllers
{
   [Area ("Mobile")]
       public class MsgController : Controller
    {
        ////////////////////////////////////////////////////type db
     public readonly ContextHampadco db;
         public readonly IWebHostEnvironment  _env;
        public static string ln="fa",eror,suc,err = null, NewFileName,prname,NewFileName1;
        
        
        public MsgController( ContextHampadco _db,IWebHostEnvironment  env)
        {
            
             db = _db;
             _env=env;

        }
        //////////////////////////////////////////////////////////


       public IActionResult Index()
        {
             ViewBag.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
              ViewBag.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess==User.Identity.GetId()).Count();
             var quser=db.Tbl_Message.Where(a=>a.ResiverMess== User.Identity.GetId() ).ToList();
             List<Vm_Message> qlist=new List<Vm_Message>();
             foreach (var item in quser)
             {
                 Vm_Message us =new Vm_Message()
             {
                 Id=item.Id,
                 SubjectMess=item.SubjectMess,
                 TextMess=item.TextMess,
                 pathfile=item.pathfile,
                 DateMess=item.DateMess.ToPersianDateString(), 
                 StateMess=item.StateMess,               
                 
             };
             qlist.Add(us);
             }
             
             ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
            return View();
        }
        


        public async Task<IActionResult> add_msg(Vm_Message msg)
        {
             ///////////////////////////////////////////////////////////////////////////////////////////////////////////count msg
            ViewBag.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
            ViewBag.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess==User.Identity.GetId()).Count();



            ////////////////////////////////////////////////////////////////////////////////////////////////////end count msg
            if (msg.file != null)
            {
                 ///////////////upload file
                string FileExtension1 = Path.GetExtension(msg.file.FileName);
                NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await msg.file.CopyToAsync(stream);



                }
                Tb_Message message=new Tb_Message()
                {
                    SenderMess=User.Identity.GetId(),
                    ResiverMess="admin",
                    DateMess=DateTime.Today,
                    SubjectMess=msg.SubjectMess,
                    TextMess=msg.TextMess,
                    StateMess=false,
                    Language="fa",
                    pathfile=NewFileName


                };
                db.Tbl_Message.Add(message);
                db.SaveChanges();
                eror="تم ارسال الرسالة بنجاح";
                //////////////////////////end upload file 

            }
            else
            {
                Tb_Message message=new Tb_Message()
                {
                    SenderMess=User.Identity.GetId(),
                    ResiverMess="admin",
                    DateMess=DateTime.Today,
                    SubjectMess=msg.SubjectMess,
                    TextMess=msg.TextMess,
                    StateMess=false,
                    Language="fa",
                   


                };
                db.Tbl_Message.Add(message);
                db.SaveChanges();
                eror="تم ارسال الرسالة بنجاح";
            }
             var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
                 api.VerifyLookup("09121181980", "tel:09149501938", "deliverylink");
                    api.VerifyLookup("09128683930", "tel:09149501938", "deliverylink");
                       api.VerifyLookup("09124635143", "tel:09149501938", "deliverylink");
                        api.VerifyLookup("09149501938", "tel:09149501938", "deliverylink");
               
             
            return RedirectToAction("index");
        }
    

         public IActionResult Details(int id)
         {
              ///////////////////////////////////////////////////////////////////////////////////////////////////////////count msg
             ViewBag.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
              ViewBag.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess==User.Identity.GetId()).Count();



            ////////////////////////////////////////////////////////////////////////////////////////////////////end count msg
               ///////////////////////////////////////////////////////////////////////////logo & titel
            var logo=db.Tbl_Logo.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                  ViewBag.logo=logo.ImageLogo;
                  ViewBag.Title=logo.TitleLogo;
                 
            }else
            {
                ViewBag.logo=null;
                 ViewBag.Title=null;
            }
          ////////////////////////////////////////////////////////////////////////////////social network
           var social=db.Tbl_SocialNetwork.ToList();
            if (social != null)
            {
                  ViewBag.social=social;
                 
            }else
            {
                 ViewBag.social=null;
            }
          ////////////////////////////////////////////////////////////////////////////////////////////////
             ////////////////////////////////////////////////////////////////////////////////////////////////////menu
             var qmenu=db.tbl_category.ToList();
             if (qmenu != null)
             {
                 ViewBag.menu=qmenu;
             }




            /////////////////////////////////////////////////////////////////////////////////////////////////////eror message
            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }
             var quser=db.Tbl_Message.Where(a=>a.Id==id ).ToList();
             List<Vm_Message> qlist=new List<Vm_Message>();
             foreach (var item in quser)
             {
                 Vm_Message us =new Vm_Message()
             {
                 Id=item.Id,
                 SubjectMess=item.SubjectMess,
                 TextMess=item.TextMess,
                 pathfile=item.pathfile,
                 DateMess=item.DateMess.ToPersianDateString(), 
                 StateMess=item.StateMess,               
                 
             };
             qlist.Add(us);
             }
             
             ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
             var q=db.Tbl_Message.Where(a=>a.Id==id ).SingleOrDefault();
             q.StateMess=true;
             db.Tbl_Message.Update(q);
             db.SaveChanges();
            return View();
           
         }
       
           public IActionResult Detailssnd(int id)
         {
              ///////////////////////////////////////////////////////////////////////////////////////////////////////////count msg
             ViewBag.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
              ViewBag.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess==User.Identity.GetId()).Count();



            ////////////////////////////////////////////////////////////////////////////////////////////////////end count msg
               ///////////////////////////////////////////////////////////////////////////logo & titel
            var logo=db.Tbl_Logo.Where(a=>a.Language==ln).SingleOrDefault();
            if (logo != null)
            {
                  ViewBag.logo=logo.ImageLogo;
                  ViewBag.Title=logo.TitleLogo;
                 
            }else
            {
                ViewBag.logo=null;
                 ViewBag.Title=null;
            }
          ////////////////////////////////////////////////////////////////////////////////social network
           var social=db.Tbl_SocialNetwork.ToList();
            if (social != null)
            {
                  ViewBag.social=social;
                 
            }else
            {
                 ViewBag.social=null;
            }
          ////////////////////////////////////////////////////////////////////////////////////////////////
             ////////////////////////////////////////////////////////////////////////////////////////////////////menu
             var qmenu=db.tbl_category.ToList();
             if (qmenu != null)
             {
                 ViewBag.menu=qmenu;
             }




            /////////////////////////////////////////////////////////////////////////////////////////////////////eror message
            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }
             var quser=db.Tbl_Message.Where(a=>a.Id==id ).ToList();
             List<Vm_Message> qlist=new List<Vm_Message>();
             foreach (var item in quser)
             {
                 Vm_Message us =new Vm_Message()
             {
                 Id=item.Id,
                 SubjectMess=item.SubjectMess,
                 TextMess=item.TextMess,
                 pathfile=item.pathfile,
                 DateMess=item.DateMess.ToPersianDateString(), 
                 StateMess=item.StateMess,               
                 
             };
             qlist.Add(us);
             }
             
             ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
             
            return View();
           
         }
       
         
         public IActionResult del(int id)
         {

             var qselect=db.Tbl_Message.Where(a=>a.Id==id).SingleOrDefault();
             db.Tbl_Message.Remove(qselect);
             db.SaveChanges();
              eror="تم حذف الرسالة بنجاح";
             return RedirectToAction("index");

         }




   public IActionResult send()
        {
            
             ///////////////////////////////////////////////////////////////////////////////////////////////////////////count msg
             ViewBag.resiver=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess=="admin").Count();
              ViewBag.sender=db.Tbl_Message.Where(a=>a.StateMess==false && a.SenderMess==User.Identity.GetId()).Count();



            /////////////////////////////////////////////////////////////////////////////////////////////////////eror message
            if (eror != null)
            {
                ViewBag.err=eror;
                eror=null;
            }
             var quser=db.Tbl_Message.Where(a=>a.SenderMess== User.Identity.GetId() ).ToList();
             var qname=db.Tbl_User.Where(a=>a.UserNameUs== (User.Identity.GetId())).SingleOrDefault();
             List<Vm_Message> qlist=new List<Vm_Message>();
             foreach (var item in quser)
             {
                 
                 Vm_Message us =new Vm_Message()
             {
                 Id=item.Id,
                 SubjectMess=item.SubjectMess,
                 TextMess=item.TextMess,
                 pathfile=item.pathfile,
                 DateMess=item.DateMess.ToPersianDateString(), 
                 StateMess=item.StateMess, 
                 namesender=qname.UserNameUs              
                 
             };
             qlist.Add(us);
             }

            
             ViewBag.msg=qlist.OrderByDescending(a=>a.Id).ToList();
            return View();
        }
        







    }
}
