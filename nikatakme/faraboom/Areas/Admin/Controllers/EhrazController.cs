using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
//using Admin.Models;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EhrazController : Controller
    {
        private readonly ContextHampadco db;
        private readonly IHostingEnvironment _env;

        public EhrazController(ContextHampadco _db, IHostingEnvironment env)
        {
            db = _db;
            _env = env;

        }
        public IActionResult index()
        {
            return View();
        }
        public IActionResult CheckStatus()
        {
            var client = new RestClient("http://127.0.0.1:3001/api/home/Version");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var Is_Successful=response.IsSuccessful;
            if (Is_Successful)
            {
                var msg=response.Content;
            }
            else
            {
                var msg="false request answer";
            }

          return View();
        }
        public IActionResult Resive_Emza(string img)
        {
            
            var client = new RestClient("http://127.0.0.1:3001/api/sign/GetSignature");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("Frame",img);
            IRestResponse response = client.Execute(request);
            var Emza=JsonConvert.DeserializeObject<Root>(response.Content);
            return View();
        }

     // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SignpadResult
    {
        [JsonProperty("SignpadStatus")]
        public int SignpadStatus { get; set; }

        [JsonProperty("ResultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("Exception")]
        public object Exception { get; set; }

        [JsonProperty("ModelName")]
        public object ModelName { get; set; }

        [JsonProperty("CompanyID")]
        public object CompanyID { get; set; }

        [JsonProperty("ModelDescription")]
        public object ModelDescription { get; set; }
    }

    public class Root
    {
        [JsonProperty("SignatureImage")]
        public object SignatureImage { get; set; }

        [JsonProperty("BiometricSignatureData")]
        public object BiometricSignatureData { get; set; }

        [JsonProperty("SignatureImageString")]
        public object SignatureImageString { get; set; }

        [JsonProperty("SignpadResult")]
        public SignpadResult SignpadResult { get; set; }
    }

    public IActionResult Finish_Emza()
    {
        try
        {
            var client = new RestClient("http://127.0.0.1:3001/api/sign/Cancel");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            if (response.Content=="true")
            {
                ViewBag.msg=true;
            }
            else
            {
                ViewBag.msg=false;
            }
        }
        catch (System.Exception ex)
        {
            ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش کنید";
        }

      return View();
    }

    public IActionResult CheckEmza()
    {
        try
        {
            var client = new RestClient("http://127.0.0.1:3001/api/sign/GetStatus");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            var result=response.Content;
            if (result=="SignatureMode")
            {
                ViewBag.modeltype="ورودی پد امضا";
            }
            if (result=="NumpadMode")
            {
                ViewBag.modeltype="ورودی اعداد";
            }
            
        }
        catch (System.Exception ex)
        {
            ViewBag.modeltype="خطا در برقراری ارتباط دوباره تلاش کنید ";
        }
        
        return View();
    }

    public IActionResult ScanFinger()
    {
        try
        {
            
            var client = new RestClient("http://127.0.0.1:3001/api/finger/scanfinger");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            var resposn=JsonConvert.DeserializeObject<Rootfinger>(response.Content);
            if (resposn.ImageByte != null)
            {
                var ImgByte=resposn.ImageByte;
                ViewBag.msg="اسکن با موفقیت انجام شد";
                return View();
            }
            else
            {
                ViewBag.msg="لطفا دوباره اسکن کنید";
                return RedirectToAction("ScanFinger");
            }
        }
        catch (System.Exception ex)
        {
             ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش فرمایید";
             return RedirectToAction("ScanFinger");
        }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Rootfinger>(myJsonResponse); 
    public class ScannerResult
    {
        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("ResultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("Exception")]
        public object Exception { get; set; }

        [JsonProperty("SerialNumber")]
        public object SerialNumber { get; set; }

        [JsonProperty("ScannerType")]
        public int ScannerType { get; set; }

        [JsonProperty("SdkVersion")]
        public object SdkVersion { get; set; }

        [JsonProperty("CompanyID")]
        public object CompanyID { get; set; }
    }

    public class Rootfinger
    {
        [JsonProperty("ImageResolution")]
        public int ImageResolution { get; set; }

        [JsonProperty("ImageByte")]
        public object ImageByte { get; set; }

        [JsonProperty("ImageRAW")]
        public object ImageRAW { get; set; }

        [JsonProperty("RAW_Width")]
        public int RAWWidth { get; set; }

        [JsonProperty("RAW_Height")]
        public int RAWHeight { get; set; }

        [JsonProperty("Template")]
        public string Template { get; set; }

        [JsonProperty("TemplateSize")]
        public int TemplateSize { get; set; }

        [JsonProperty("Quality")]
        public int Quality { get; set; }

        [JsonProperty("ScannerResult")]
        public ScannerResult ScannerResult { get; set; }
    }

    public IActionResult scanfingerimage()
    {
        try
        {

            var client = new RestClient("http://127.0.0.1:3001/api/finger/scanfingerimage");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            var result=JsonConvert.DeserializeObject<RootFingerImg>(response.Content);
            if (result.ImageByte != null)
            {
                var ImgByte=result.ImageByte;
                ViewBag.msg="اسکن با موفقیت انجام شد";
                return View();
            }
            else
            {
                ViewBag.msg="لطفا دوباره اسکن کنید";
                return RedirectToAction("scanfingerimage");
            }
        }
        catch (System.Exception ex)
        {
             ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش فرمایید";
             return RedirectToAction("scanfingerimage");
        }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<RootFingerImg>(myJsonResponse); 
    public class ScannerResultFingerImg
    {
        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("ResultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("Exception")]
        public object Exception { get; set; }

        [JsonProperty("SerialNumber")]
        public object SerialNumber { get; set; }

        [JsonProperty("ScannerType")]
        public int ScannerType { get; set; }

        [JsonProperty("SdkVersion")]
        public object SdkVersion { get; set; }

        [JsonProperty("CompanyID")]
        public object CompanyID { get; set; }
    }

    public class RootFingerImg
    {
        [JsonProperty("ImageResolution")]
        public int ImageResolution { get; set; }

        [JsonProperty("ImageByte")]
        public object ImageByte { get; set; }

        [JsonProperty("ImageRAW")]
        public object ImageRAW { get; set; }

        [JsonProperty("RAW_Width")]
        public int RAWWidth { get; set; }

        [JsonProperty("RAW_Height")]
        public int RAWHeight { get; set; }

        [JsonProperty("Template")]
        public string Template { get; set; }

        [JsonProperty("TemplateSize")]
        public int TemplateSize { get; set; }

        [JsonProperty("Quality")]
        public int Quality { get; set; }

        [JsonProperty("ScannerResult")]
        public ScannerResult ScannerResult { get; set; }
    }

    public IActionResult ScanFingerImageAndTemplate()
    {
        try
        {
            var client = new RestClient("http://127.0.0.1:3001/api/finger/ScanFingerImageAndTemplate");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            var result=JsonConvert.DeserializeObject<RootScanFingerImageAndTemplate>(response.Content);
            if (result.ImageByte != null)
            {
                var ImgByte=result.ImageByte;
                ViewBag.msg="اسکن با موفقیت انجام شد";
                return View();
            }
            else
            {
                ViewBag.msg="لطفا دوباره اسکن کنید";
                return RedirectToAction("ScanFingerImageAndTemplate");
            }
        }
        catch (System.Exception ex)
        {
             ViewBag.msg="خطا در برقراری ارتباط لطفا دوباره تلاش فرمایید";
             return RedirectToAction("ScanFingerImageAndTemplate");
        }  

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<RootScanFingerImageAndTemplate>(myJsonResponse); 
    public class ScannerResultScanFingerImageAndTemplate
    {
        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("ResultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("Exception")]
        public object Exception { get; set; }

        [JsonProperty("SerialNumber")]
        public object SerialNumber { get; set; }

        [JsonProperty("ScannerType")]
        public int ScannerType { get; set; }

        [JsonProperty("SdkVersion")]
        public object SdkVersion { get; set; }

        [JsonProperty("CompanyID")]
        public object CompanyID { get; set; }
    }

    public class RootScanFingerImageAndTemplate
    {
        [JsonProperty("ImageResolution")]
        public int ImageResolution { get; set; }

        [JsonProperty("ImageByte")]
        public object ImageByte { get; set; }

        [JsonProperty("ImageRAW")]
        public object ImageRAW { get; set; }

        [JsonProperty("RAW_Width")]
        public int RAWWidth { get; set; }

        [JsonProperty("RAW_Height")]
        public int RAWHeight { get; set; }

        [JsonProperty("Template")]
        public string Template { get; set; }

        [JsonProperty("TemplateSize")]
        public int TemplateSize { get; set; }

        [JsonProperty("Quality")]
        public int Quality { get; set; }

        [JsonProperty("ScannerResult")]
        public ScannerResult ScannerResult { get; set; }
    }

    }
}