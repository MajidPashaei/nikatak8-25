using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Richat;
using DataLayer.Context;
using  faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.Richat;

namespace faraboom.Areas.Adminsite.Controllers {

  public class RayChatController : BaseController {
    public RayChatController (ContextHampadco _db, IWebHostEnvironment env) : base (_db, env) { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////index logo

    public IActionResult Index () {
      if (err != null) {
        ViewBag.er = err;
        err = null;
      }

      var list = db.Tbl_Richats.SingleOrDefault ();
      if (list != null) {
        var qlist = new Vm_Richat () {
        ScriptChat = list.ScriptChat,
        zarinpal = list.zarinpal,
        website = list.website,
        enemad = list.enemad,
        sms = list.sms,
        paternsms = list.paternsms
        };
        return View (qlist);
      }

      return View ();
    }

    public IActionResult add (Vm_Richat soc) {
      var listp = db.Tbl_Richats.SingleOrDefault ();
      if (listp != null) {

        listp.ScriptChat = soc.ScriptChat;
        listp.zarinpal = soc.zarinpal;
        listp.website = soc.website;
        listp.enemad = soc.enemad;
        listp.sms = soc.sms;
        listp.paternsms = soc.paternsms;

        db.Tbl_Richats.Update (listp);
        db.SaveChanges ();

        err = "اطلاعات با موفقیت بروز رسانی شد";
      } else {
        var social = new Tbl_Richat () {
          ScriptChat = soc.ScriptChat,
          zarinpal = soc.zarinpal,
          website = soc.website,
          enemad = soc.enemad,
          sms = soc.sms,
          paternsms = soc.paternsms,

        };

        db.Tbl_Richats.Add (social);
        db.SaveChanges ();
        err = "اطلاعات با موفقیت ثبت شد";
      }
      return RedirectToAction ("index");

    }

  }
}