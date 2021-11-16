using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Threading.Tasks;
using DataLayer.AdminEntities.Admin;
using DataLayer.Context;
using DataLayer.Context;
using faraboom.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Admin;

namespace Admin.Controllers {

    [Area ("Admin")]

    public class ContactController : Controller

    {
        public static string msg,Fphotos,FNationalcard,FNationalcardback,FCertificate,FShaba,FDegreeeducation,FPostalcodeDoc,FDocument,FBadbackground,FReceipt;
        private readonly ContextHampadco db;
        private readonly IWebHostEnvironment _env;
        public ContactController (ContextHampadco _db, IWebHostEnvironment env) {
            db = _db;
            _env = env;

        }
        public IActionResult Index () {
           



           
            return View ();
        }

        public  async Task<IActionResult> Add (Vm_info Q) {

            var quser = db.Tbl_infos.Where (a => a.UserNameId == (User.Identity.GetId ())).SingleOrDefault();
            ///upload data
            ///FNationalcard data///////////
            if (Q.FNationalcard!=null)
            {
              
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension1 = Path.GetExtension(Q.Fphotos.FileName);
                 Fphotos = String.Concat(Guid.NewGuid().ToString(), FileExtension1);
                var path = $"{_env.WebRootPath}\\filetest\\{Fphotos}";
                using (var stream = new FileStream(path, FileMode.Create))
                {

                    await Q.Fphotos.CopyToAsync(stream);



                }
                
                //////////////////////////end upload file 
            }
            
            ///FNationalcard data///////////
            if (Q.FNationalcard !=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension2 = Path.GetExtension(Q.FNationalcard.FileName);
                 FNationalcard = String.Concat(Guid.NewGuid().ToString(), FileExtension2);
                var path2 = $"{_env.WebRootPath}\\filetest\\{FNationalcard}";
                using (var stream = new FileStream(path2, FileMode.Create))
                {

                    await Q.FNationalcard.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }
        
            //FNationalcardback////////////
            if (Q.FNationalcardback!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension3 = Path.GetExtension(Q.FNationalcardback.FileName);
                 FNationalcardback = String.Concat(Guid.NewGuid().ToString(), FileExtension3);
                var path3 = $"{_env.WebRootPath}\\filetest\\{FNationalcardback}";
                using (var stream = new FileStream(path3, FileMode.Create))
                {

                    await Q.FNationalcardback.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

            //FCertificate////////////
            if (Q.FCertificate!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension4 = Path.GetExtension(Q.FCertificate.FileName);
                 FCertificate = String.Concat(Guid.NewGuid().ToString(), FileExtension4);
                var path4 = $"{_env.WebRootPath}\\filetest\\{FCertificate}";
                using (var stream = new FileStream(path4, FileMode.Create))
                {

                    await Q.FCertificate.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

            
            //FShaba////////////
            if (Q.FShaba!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension5 = Path.GetExtension(Q.FShaba.FileName);
                 FShaba = String.Concat(Guid.NewGuid().ToString(), FileExtension5);
                var path5 = $"{_env.WebRootPath}\\filetest\\{FShaba}";
                using (var stream = new FileStream(path5, FileMode.Create))
                {

                    await Q.FShaba.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

            //FDegreeeducation////////////
            if (Q.FDegreeeducation!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension6 = Path.GetExtension(Q.FDegreeeducation.FileName);
                 FDegreeeducation = String.Concat(Guid.NewGuid().ToString(), FileExtension6);
                var path6 = $"{_env.WebRootPath}\\filetest\\{FDegreeeducation}";
                using (var stream = new FileStream(path6, FileMode.Create))
                {

                    await Q.FDegreeeducation.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }
              
            //FPostalcodeDoc////////////
            if (Q.FPostalcodeDoc!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension7 = Path.GetExtension(Q.FPostalcodeDoc.FileName);
                 FPostalcodeDoc = String.Concat(Guid.NewGuid().ToString(), FileExtension7);
                var path7 = $"{_env.WebRootPath}\\filetest\\{FPostalcodeDoc}";
                using (var stream = new FileStream(path7, FileMode.Create))
                {

                    await Q.FPostalcodeDoc.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }
            
            //FPostalcodeDoc////////////
            if (Q.FPostalcodeDoc!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension7 = Path.GetExtension(Q.FPostalcodeDoc.FileName);
                 FPostalcodeDoc = String.Concat(Guid.NewGuid().ToString(), FileExtension7);
                var path7 = $"{_env.WebRootPath}\\filetest\\{FPostalcodeDoc}";
                using (var stream = new FileStream(path7, FileMode.Create))
                {

                    await Q.FPostalcodeDoc.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

         //FDocument////////////
            if (Q.FDocument!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension8 = Path.GetExtension(Q.FDocument.FileName);
                 FDocument = String.Concat(Guid.NewGuid().ToString(), FileExtension8);
                var path8 = $"{_env.WebRootPath}\\filetest\\{FDocument}";
                using (var stream = new FileStream(path8, FileMode.Create))
                {

                    await Q.FDocument.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

         //FBadbackground////////////
            if (Q.FBadbackground!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension9 = Path.GetExtension(Q.FBadbackground.FileName);
                 FBadbackground = String.Concat(Guid.NewGuid().ToString(), FileExtension9);
                var path9 = $"{_env.WebRootPath}\\filetest\\{FBadbackground}";
                using (var stream = new FileStream(path9, FileMode.Create))
                {

                    await Q.FBadbackground.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }

            //FReceipt////////////
            if (Q.FReceipt!=null)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////upload file
                string FileExtension10 = Path.GetExtension(Q.FReceipt.FileName);
                 FReceipt = String.Concat(Guid.NewGuid().ToString(), FileExtension10);
                var path10 = $"{_env.WebRootPath}\\filetest\\{FReceipt}";
                using (var stream = new FileStream(path10, FileMode.Create))
                {

                    await Q.FReceipt.CopyToAsync(stream);



                }
                //////////////////////////end upload file 

                
            }
           
           
            ///
            if (quser != null) {
                quser.photos=Fphotos;
                quser.Nationalcard=FNationalcard;
                quser.Nationalcardback=FNationalcardback;
                quser.Certificate=FCertificate;
                quser.Shaba=FShaba;
                quser.Degreeeducation=FDegreeeducation;
                quser.PostalcodeDoc=FPostalcodeDoc;
                quser.Document=FDocument;
                quser.Badbackground=FBadbackground;
                quser.Receipt=FReceipt;
                quser.Nameper = Q.Nameper;
                quser.Familyper = Q.Familyper;
                quser.Fathernameper = Q.Fathernameper;
                quser.Nameen = Q.Nameen;
                quser.Familyen = Q.Familyen;
                quser.Fathernameen = Q.Fathernameen;
                quser.Place = Q.Place;
                quser.Serial = Q.Serial;
                quser.Religion = Q.Religion;
                quser.Email = Q.Email;
                quser.Yers = Q.Yers;
                quser.Mont = Q.Mont;
                quser.Day = Q.Day;
                quser.Gender = Q.Gender;
                quser.maritalstatus = Q.maritalstatus;
                quser.Bankname = Q.Bankname;
                quser.Bankcode = Q.Bankcode;
                quser.Branchname = Q.Branchname;
                quser.Accounttype = Q.Accounttype;
                quser.cardnumber = Q.cardnumber;
                quser.Shabanumber = Q.Shabanumber;
                quser.accountnumber = Q.accountnumber;
                quser.AccountName = Q.AccountName;
                quser.PostalcodeBank = Q.PostalcodeBank;
                quser.Address = Q.Address;
                quser.Phone = Q.Phone;
                quser.PhoneHome = Q.PhoneHome;
                quser.PhonelocationN = Q.PhonelocationN;
                quser.PhoneNikatak = Q.PhoneNikatak;
                quser.State = Q.State;
                quser.City = Q.City;
                quser.Postalcode = Q.Postalcode;
                quser.homeaddress = Q.homeaddress;
                quser.Locationaddress = Q.Locationaddress;
                quser.DiplomDate = Q.DiplomDate;
                quser.DiplomLocation = Q.DiplomLocation;
                quser.KardaniDate = Q.KardaniDate;
                quser.KardaniLocation = Q.KardaniLocation;
                quser.KarshenasiDate = Q.KarshenasiDate;
                quser.KarshenasiLocation = Q.KarshenasiLocation;
                quser.ArshadDate = Q.ArshadDate;
                quser.ArshadLocation = Q.ArshadLocation;
                quser.DoktoraDate = Q.DoktoraDate;
                quser.DoktoraLocation = Q.DoktoraLocation;
                quser.Companyname = Q.Companyname;
                quser.start = Q.start;
                quser.End = Q.End;
                quser.Typeactivity = Q.Typeactivity;
                quser.NationalCode = Q.NationalCode;
                db.Tbl_infos.Update (quser);
                db.SaveChanges ();
                return RedirectToAction ("form", "Home", new { area = "admin", id = 1 });

            }
            return RedirectToAction ("form", "Home", new { area = "admin", id = 0 });
        }
    }
}