using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using ViewModels.AdminViewModel.Job;
using DataLayer.AdminEntities.Job;
using System.IO;
using faraboom.Models;
using Extensions;

namespace faraboom.Areas.Adminsite.Controllers
{
    public class JobsController : BaseController
    {

        public JobsController(ContextHampadco _db,IWebHostEnvironment  env) :base(_db,env)
        {
        }

        public IActionResult Index()
        {
            var quser = db.Tbl_JobUsers.OrderByDescending( a => a.Id).ToList();
            List<Vm_JobUser> lvju = new List<Vm_JobUser>();
            if (quser != null)
            {
                foreach (var item in quser)
                {
                    Vm_JobUser vju = new Vm_JobUser()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Family = item.Family,
                        CodeMeli = item.CodeMeli,
                        FatherName = item.FatherName,
                        Telphone = item.Telphone,
                        Mobile = item.Mobile,
                        Email = item.Email,
                        Post = item.Post,
                        Address = item.Address,
                        City = item.City,
                        Ostan = item.Ostan,
                        Rand = item.Rand,
                        Tahsilat = item.Tahsilat,
                        Reshte = item.Reshte,
                        Img_CartMeli = item.Img_CartMeli,
                        Img_MadrakTahsili = item.Img_MadrakTahsili,
                        Img_PayanKH = item.Img_PayanKH,
                        Img_Shenasname = item.Img_Shenasname,
                        // Img_Aks = item.Img_Aks,
                        tavalood = item.Tavalood.ToPersianDateString(),
                        time = item.DateTime.ToPersianDateString(),
                    };
                    lvju.Add(vju);
                }
            }
            ViewBag.user = lvju;
            return View();
        }

    }
}