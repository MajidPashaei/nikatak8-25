using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Bimeh;
using DataLayer.AdminEntities.Bimeh;

namespace Mobile.Controllers {
    [Area ("Mobile")]
    public class BimehController : BaseController {
        public static string eror, massage, NewFileName, NewFileName2, NewFileName3, NewFileName4, NewFileName5;
        private readonly ContextHampadco db;
        private readonly IWebHostEnvironment _env;

        // public LoginNewController(ContextHampadco _db, IWebHostEnvironment env)
        // {
        //     db = _db;
        //     _env = env;

        // }
        public BimehController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }
        public IActionResult Index () {

            return View ();
        }
        public IActionResult Azmon () {

            return View ();
        }
        public IActionResult sales () {

            return View ();
        }
        public IActionResult Badaneh () {

            return View ();
        }
        public IActionResult Motor () {

            return View ();
        }
        public IActionResult Zelzeleh () {

            return View ();
        }
        public IActionResult AtashSoozi () {

            return View ();
        }
        public IActionResult Mosaferati () {

            return View ();
        }
        public IActionResult Pezeshki () {

            return View ();
        }
        public IActionResult Darmani () {

            return View ();
        }
        public IActionResult Omr () {

            return View ();
        }
        public IActionResult kosar () {

            return View ();
        }


        public IActionResult bsales () {

            return View ();
        }

        public IActionResult bbadane () {

            return View ();
        }

        // public async Task<IActionResult> Sabt (Vm_Bimeh vb)
        // {
        //      ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     string FileExtension1 = Path.GetExtension(vb.FCartMashin1.FileName);
        //     NewFileName = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
        //     var path = $"{_env.WebRootPath}\\fileupload\\{NewFileName}";
        //     using (var stream = new FileStream(path, FileMode.Create))
        //     {
        //         await vb.FCartMashin1.CopyToAsync(stream);
        //     }
        //     //////////////////////////end upload file 
        //     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     string FileExtension2 = Path.GetExtension(vb.FCartMashin2.FileName);
        //     NewFileName2 = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
        //     var path2 = $"{_env.WebRootPath}\\fileupload\\{NewFileName2}";
        //     using (var stream = new FileStream(path2, FileMode.Create))
        //     {
        //         await vb.FCartMashin2.CopyToAsync(stream);
        //     }
        //     //////////////////////////end upload file 
        //     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     string FileExtension3 = Path.GetExtension(vb.FBimehNameh.FileName);
        //     NewFileName3 = String.Concat(Guid.NewGuid().ToString(), FileExtension3);
        //     var path3 = $"{_env.WebRootPath}\\fileupload\\{NewFileName3}";
        //     using (var stream = new FileStream(path3, FileMode.Create))
        //     {
        //         await vb.FBimehNameh.CopyToAsync(stream);
        //     }
        //      //////////////////////////end upload file 
        //     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     string FileExtension4 = Path.GetExtension(vb.FGhovahiNameh1.FileName);
        //     NewFileName4 = String.Concat(Guid.NewGuid().ToString(), FileExtension4);
        //     var path4 = $"{_env.WebRootPath}\\fileupload\\{NewFileName4}";
        //     using (var stream = new FileStream(path4, FileMode.Create))
        //     {
        //         await vb.FGhovahiNameh1.CopyToAsync(stream);
        //     }
        //      //////////////////////////end upload file 
        //     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     string FileExtension5 = Path.GetExtension(vb.FGhovahiNameh2.FileName);
        //     NewFileName5 = String.Concat(Guid.NewGuid().ToString(), FileExtension5);
        //     var path5 = $"{_env.WebRootPath}\\fileupload\\{NewFileName5}";
        //     using (var stream = new FileStream(path5, FileMode.Create))
        //     {
        //         await vb.FGhovahiNameh2.CopyToAsync(stream);
        //     }
        //      //////////////////////////end upload file 
        //     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
        //     Tbl_Bimeh tb = new Tbl_Bimeh
        //     {
        //         CartMashin1 = vb.CartMashin1,
        //         CartMashin2 = vb.CartMashin2,
        //         BimehNameh  = vb.BimehNameh ,
        //         GhovahiNameh1 = vb.GhovahiNameh1,
        //         GhovahiNameh2 = vb.GhovahiNameh2,
        //     };
        //     db.Tbl_Bimehs.Add(tb);
        //     db.SaveChanges();
        //     return View ();
        // }
    }
}