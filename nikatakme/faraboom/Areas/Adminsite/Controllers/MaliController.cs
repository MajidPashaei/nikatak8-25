using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Richat;
using DataLayer.Context;
using Extensions;
using faraboom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Request;
using ViewModels.AdminViewModel.Richat;
using ViewModels.AdminViewModel.User;
using ViewModels.AdminViewModel.Wallet;

namespace faraboom.Areas.Adminsite.Controllers
{
    [Area("Adminsite")]
    [Authorize]
  public class MaliController : BaseController {
    public MaliController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////index logo

    public IActionResult Index () 
    {
      return View ();
    }

    public IActionResult General()
    {  
      return View();
    }
    
    public IActionResult Partial()
    {
      List<Vm_User> us = new List<Vm_User>();
      var q = db.Tbl_User.OrderByDescending(a => a.Id).ToList();
      foreach (var item in q)
      {
        Vm_User ff = new Vm_User()
        {
          Id = item.Id,
          UserNameUs = item.UserNameUs,
          EmailUS = item.EmailUS,
          PhoneUs = item.PhoneUs,
          PasswordUs = item.PasswordUs,
          AddressUs = item.AddressUs,
          NameFamily = item.NameFamily,
          CodeMeli = item.CodeMeli,
          state = item.state,
          ProfileImageUs = item.ProfileImageUs,
        };
        us.Add(ff);
      }
      ViewBag.list = us.OrderByDescending(a => a.Id).ToList();
      return View();
    }

    public IActionResult Varizi( int id , string name , string username )
    {
      var list = db.Tbl_pays.Where(a => a.UserName == name && a.RequestId == 0 && a.Harvest == 0 ).OrderByDescending( a => a.Id ).ToList();
      List<Vm_Pay> lvp = new List<Vm_Pay>();
      foreach (var item in list)
      {
        Vm_Pay vp = new Vm_Pay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          DateTime = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      ViewBag.name = name ;
      ViewBag.username = username ;
      ViewBag.total = db.Tbl_pays.Where(a => a.UserName == name && a.RequestId == 0 && a.status == true && a.Harvest == 0  ).Select( a => a.Pay ).Sum();
      return View();
    }
    
    public IActionResult Bardashti( int id , string name , string username )
    {
      var list = db.Tbl_pays.Where(a => a.UserName == name && a.RequestId != 0 && a.Pay == 0 ).OrderByDescending( a => a.Id ).ToList();
      List<Vm_Pay> lvp = new List<Vm_Pay>();
      foreach (var item in list)
      {
        Vm_Pay vp = new Vm_Pay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          DateTime = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      ViewBag.name = name ;
      ViewBag.username = username ;
      ViewBag.total = db.Tbl_pays.Where(a => a.UserName == name && a.RequestId != 0 && a.status == true && a.Pay == 0 ).Select( a => a.Harvest ).Sum();
      return View();
    }
    public IActionResult HesabMan( int id , string name , string username )
    {
      var list = db.Tbl_Mypays.Where(a => a.UserName == name && a.RequestId != 0 && a.Harvest == 0 ).OrderByDescending( a => a.Id ).ToList();
      List<Vm_Mypay> lvp = new List<Vm_Mypay>();
      foreach (var item in list)
      {
        Vm_Mypay vp = new Vm_Mypay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          Date = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      ViewBag.name = name ;
      ViewBag.username = username ;
      ViewBag.total = db.Tbl_Mypays.Where(a => a.UserName == name && a.RequestId != 0 && a.status == true && a.Harvest == 0 ).Select( a => a.Pay ).Sum();
      return View();
    }

    public IActionResult DetailVarizi( int id , int reqid )
    {
      if ( reqid == 0 )
      {
        var listpay = db.Tbl_pays.Where( a => a.Id == id ).SingleOrDefault();
        Vm_Pay vp = new Vm_Pay()
        {
          Id = listpay.Id,
          UserName = listpay.UserName,
          Pay = listpay.Pay,
          Harvest = listpay.Harvest,
          DateTime = listpay.DateTime.ToPersianDateString(),
          status = listpay.status,
          RequestId = listpay.RequestId,
        };
        ViewBag.listpay = vp;
        return View();
      }
      else
      {
        var listreq = db.Tbl_Requests.Where( a => a.Id == reqid ).SingleOrDefault();
        List<Vm_Request> lvr = new List<Vm_Request>();
        Vm_Request vr = new Vm_Request()
        {
          Id = listreq.Id,
          UserName = listreq.UserName,
          Amount = listreq.Amount,
          Type_Request = listreq.Type_Request,
          Date1 = listreq.Date_Request.ToPersianDateString(),
          Pay_Id = listreq.Pay_Id,
          Bill_Id = listreq.Bill_Id,
          Titel_Request = listreq.Titel_Request,
        };
        lvr.Add(vr);
        ViewBag.listreq = lvr;
        return View();
      }
    }
    
    public IActionResult DetailBardashti( int id )
    {
      var list = db.Tbl_Requests.Where( a => a.Id == id ).SingleOrDefault();
      Vm_Request vp = new Vm_Request()
      {
        Id = list.Id,
        UserName = list.UserName,
        Amount = list.Amount,
        Type_Request = list.Type_Request,
        Titel_Request =  list.Titel_Request,
        Date1 = list.Date_Request.ToPersianDateString(),
        Pay_Id = list.Pay_Id,
        Bill_Id = list.Bill_Id,
      };
      ViewBag.list = vp;
      return View();
    }
    
    public IActionResult DetailHesabMan( int id )
    {
      var list = db.Tbl_Requests.Where( a => a.Id == id ).SingleOrDefault();
      Vm_Request vr = new Vm_Request()
      {
        Id = list.Id,
        UserName = list.UserName,
        Amount = list.Amount,
        Date1 = list.Date_Request.ToPersianDateString(),
        Bill_Id = list.Bill_Id,
        Pay_Id = list.Pay_Id,
      };
      ViewBag.list = vr;
      return View();
    }

    public IActionResult HesabManGe()
    {
      ViewBag.total = db.Tbl_Mypays.Where(a => a.RequestId != 0 && a.status == true && a.Harvest == 0 ).Select( a => a.Pay ).Sum();
      var list = db.Tbl_Mypays.OrderByDescending( a => a.Id).ToList();
      List<Vm_Mypay> lvp = new List<Vm_Mypay>();
      foreach (var item in list)
      {
        Vm_Mypay vp = new Vm_Mypay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          Date = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      return View();
    }

    public IActionResult VariziGe()
    {
      ViewBag.total = db.Tbl_pays.Where(a => a.RequestId == 0 && a.status == true && a.Harvest == 0  ).Select( a => a.Pay ).Sum();
      var list = db.Tbl_pays.Where( a => a.RequestId == 0 && a.status == true && a.Harvest == 0 ).OrderByDescending( a => a.Id).ToList();
      List<Vm_Pay> lvp = new List<Vm_Pay>();
      foreach (var item in list)
      {
        Vm_Pay vp = new Vm_Pay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          DateTime = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      return View();
    }

    public IActionResult BardashtiGe()
    {      
      ViewBag.total = db.Tbl_pays.Where(a => a.RequestId != 0 && a.status == true && a.Pay == 0 ).Select( a => a.Harvest ).Sum();
      var list = db.Tbl_pays.Where( a => a.RequestId != 0 && a.status == true && a.Pay == 0 ).OrderByDescending( a => a.Id).ToList();
      List<Vm_Pay> lvp = new List<Vm_Pay>();
      foreach (var item in list)
      {
        Vm_Pay vp = new Vm_Pay()
        {
          Id = item.Id,
          UserName = item.UserName,
          Pay = item.Pay,
          Harvest = item.Harvest,
          DateTime = item.DateTime.ToPersianDateString(),
          status = item.status,
          RequestId = item.RequestId,
        };
        var qreq = db.Tbl_Requests.Where( a => a.Id == item.RequestId ).SingleOrDefault();
        if ( qreq != null )
        {
          vp.Titel_Request = qreq.Titel_Request ;
          vp.Type_Request = qreq.Type_Request ;
        }
        lvp.Add(vp);
      }
      ViewBag.list = lvp;
      return View();
    }
    
  }
}