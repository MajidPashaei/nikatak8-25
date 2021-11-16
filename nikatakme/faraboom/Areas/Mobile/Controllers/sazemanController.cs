using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Mobile.Controllers {
    [Area ("Mobile")]
    public class sazemanController : BaseController {
        public sazemanController(ContextHampadco _db, IWebHostEnvironment env) : base(_db, env)
        {
        }


        public IActionResult index () {

            return View ();
        }
        public IActionResult charge () {

            return View ();
        }

        // ******************************************چک 
        public IActionResult check () {

            return View ();
        }

          public IActionResult sabt () {

            return View ();
        }

         public IActionResult estelam () {

            return View ();
        }
        //**************************************************املاک
        public IActionResult amlak () {

            return View ();
        }

        public IActionResult siteamlak () {

            return View ();
        }
    

        //************************************************بورس و فرابورس
        public IActionResult bors () {

            return View ();
        } 
        
         public IActionResult agah () {

            return View ();
        }

         public IActionResult ati () {

            return View ();
        }

        
         public IActionResult farabi () {

            return View ();
        }

        public IActionResult mofid () {

            return View ();
        }

        public IActionResult sajameagah () {

            return View ();
        }

        public IActionResult sajameati () {

            return View ();
        }

        public IActionResult sajamefarabi () {

            return View ();
        }

        public IActionResult sajamemofid () {

            return View ();
        }

        public IActionResult estelameazadsazisaham () {

            return View ();
        }

         public IActionResult foroshesaham () {

            return View ();
        }

        public IActionResult saham () {

            return View ();
        }
        

        
        //************************************************یارانه
        public IActionResult yarane () {

            return View ();
        }

        public IActionResult elamniaz () {

            return View ();
        }

        public IActionResult residegi () {

            return View ();
        }
      
        //***************************************************اظهارنامه مالیاتی 
        public IActionResult malyat () {

            return View ();
        }

        public IActionResult ezharname () {

            return View ();
        }

        //******************************************************سامانه ثنا 
        public IActionResult sana () {

            return View ();
        }

        public IActionResult adamesoepishine () {

            return View ();
        }

        public IActionResult agahigazaei () {

            return View ();
        }

        public IActionResult barresihoviat () {

            return View ();
        }

        public IActionResult darkhasteafv () {

            return View ();
        }

        public IActionResult eblageelectronikegazaei () {

            return View ();
        }

        public IActionResult estelamedavi () {

            return View ();
        }

        public IActionResult estelamekarshenas () {

            return View ();
        }

        public IActionResult estelamemadarekegazaei () {

            return View ();
        }

        public IActionResult estelamevokala () {

            return View ();
        }

        public IActionResult faramoshiramz () {

            return View ();
        }

        public IActionResult hazinedadrasi () {

            return View ();
        }

        public IActionResult pardakhteinterneti () {

            return View ();
        }

        public IActionResult sabtenamebarkhat () {

            return View ();
        }

        public IActionResult sabtenamebarkhatehogogi () {

            return View ();
        }

        public IActionResult tagireettelaat () {

            return View ();
        }

        public IActionResult tagireramz () {

            return View ();
        }

        public IActionResult tarefekhadamat () {

            return View ();
        }


        public IActionResult vahedegazaei () {

            return View ();
        }



        //********************************************** ثبت احوال

        public IActionResult sabteahval () {

            return View ();
        }

        public IActionResult peygirikartemelli () {

            return View ();
        }

        public IActionResult sabtenamekartemelli () {

            return View ();
        }

        public IActionResult tagiereneshani () {

            return View ();
        }

        

        //******************************************** موجودی
        public IActionResult mojodibank () {

            return View ();
        }

        public IActionResult mojodibankkeshavarzi () {

            return View ();
        }

        public IActionResult mojodibankrefah () {

            return View ();
        }


        //***************************************** وام ازدواج


         public IActionResult vam () {

            return View ();
        }
        public IActionResult vamezdevaj () {

            return View ();
        }


    
        //***************************************** بنیاد شهید و امور ایثارگران
        public IActionResult shahid () {

            return View ();
        }

        public IActionResult darkhastesodorekart () {

            return View ();
        }  

        public IActionResult fishehogog () {

            return View ();
        }  

        public IActionResult sabtvapeigiridarkhastha () {

            return View ();
        }  

         public IActionResult hogogekarkonan () {

            return View ();
        }

         public IActionResult vorodbesamanekhadamat () {

            return View ();
        }  

        public IActionResult estelameisargar () {

            return View ();
        }  

        public IActionResult madaressajam () {

            return View ();
        } 
        public IActionResult madares()
        {
            // TODO: Your code here
            return View();
        }
         

        public IActionResult masoulin () {

            return View ();
        }  


        //***************************************** نظام وظیفه

        public IActionResult vazife () {

            return View ();
        }

        public IActionResult nezamvazife () {

            return View ();
        }


        //********************************************** آموزش و پرورش
        public IActionResult parvaresh () {

            return View ();
        }

        public IActionResult peigiri () {

            return View ();
        }

        public IActionResult sabtenam () {

            return View ();
        }

        public IActionResult pada () {

            return View ();
        }


        //************************************************ بازنشستگان 

          public IActionResult bazneshaste () {

            return View ();
        }

        public IActionResult bazneshastegankeshvari () {

            return View ();
        }

        public IActionResult bazneshastegannirohayemosallah () {

            return View ();
        }

        public IActionResult bazneshastegantamin () {

            return View ();
        }

        


        //********************************************** نسخه الکترونیک
        public IActionResult electronic () {

            return View ();
        }

        public IActionResult electronicsalamat () {

            return View ();
        }


        //********************************************** برگه تردد


        public IActionResult taradod () {

            return View ();
        }

        public IActionResult bargetaradod () {

            return View ();
        }

        //********************************************* خدمات برق
        public IActionResult bargi () {

            return View ();
        }

        public IActionResult bargeag () {

            return View ();
        }

        public IActionResult bargeash () {

            return View ();
        }

        //******************************************** پست


          public IActionResult posti () {

            return View ();
        }

        public IActionResult marsole () {

            return View ();
        }

        public IActionResult postex () {

            return View ();
        }

        public IActionResult tipax () {

            return View ();
        }


        //***************************************** حمل و نقل
        public IActionResult hamlonagl () {

            return View ();
        }

        public IActionResult hamlonagldorehamozeshi () {

            return View ();
        }

         public IActionResult estelamecartehoshmandebari () {

            return View ();
        }

        public IActionResult estelamecartehoshmandemosaferi()
        {
        
            return View();
        }

        public IActionResult estelam_cart_hoshmand_ranande()
        {
        
            return View();
        }

        public IActionResult estelam_cart_hoshmand_yadak()
        {
        
            return View();
        }

        public IActionResult estelam_cart_salamat()
        {
        
            return View();
        }

        public IActionResult estelam_doreh_amozeshi()
        {
        
            return View();
        }

        public IActionResult estelam_mojaveze_rah()
        {
        
            return View();
        }

        public IActionResult estelam_peymaesh()
        {
        
            return View();
        }

         public IActionResult sabt_nimeh_yadak()
        {
        
            return View();
        }

        public IActionResult sabt_vanetbar_navghan()
        {
        
            return View();
        }

        public IActionResult tamdid_cart_hoshmand()
        {
        
            return View();
        }


        //***************************************** بیمه سلامت

          public IActionResult salamati () {

            return View ();
        }

        public IActionResult salamat () {

            return View ();
        }
        
        public IActionResult tamin () {

            return View ();
        }


        //**************************************** آب و فاضلاب
        public IActionResult abi () {

            return View ();
        }

        public IActionResult abiag () {

            return View ();
        }

        public IActionResult abiash () {

            return View ();
        }

        public IActionResult bargekur () {

            return View ();
        }

    }
}