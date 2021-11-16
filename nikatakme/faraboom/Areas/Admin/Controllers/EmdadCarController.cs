using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Admin.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using DataLayer.AdminEntities.Request;
using ViewModels.AdminViewModel.Emdad;
using faraboom.Models;
//using Admin.Models;

namespace Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EmdadCarController : BaseController
    {
        public EmdadCarController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
        {
          
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult searchByChassisNumber()
        {
            return View();
        }

        public IActionResult searchByChassisNumberResult(Vm_Emdad vm_Emdad)
        {   var client = new RestClient("http://096440.com:8080/api/site/public/searchByChassisNumber");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body =
                "{" 
                  + "\"chassisNumber\":\""+vm_Emdad.chassisNumber+"\""
                + "}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var x = JsonConvert.DeserializeObject<RootsearchByChassisNumber>(response.Content);
            if (x.Settings.Success=="1")
            {
                ViewBag.Details=x.Data;
            }
            if (x.Settings.Success=="0")
            {
                 ViewBag.msg=x.Settings.Message;
            }
            return View();
        }
        public IActionResult serviceCard()
        {
            return View();
        }
        
        public IActionResult serviceCardResult(Vm_Emdad vm_Emdad)
        {
            var client = new RestClient("https://096440.com/api/site/public/service/serviceCard");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body ="{\"filters\":[{\"field\":\"chassisNumber\",\"type\":\"equal\",\"search\":\""+vm_Emdad.chassisNumber+"\"},{\"field\":\"kilometer\",\"type\":\"equal\",\"search\":"+vm_Emdad.kilometer+"},{\"field\":\"realOrLegal\",\"type\":\"equal\",\"search\":\""+vm_Emdad.realOrLegal+"\"},{\"field\":\"offCode\",\"type\":\"equal\",\"search\":\""+vm_Emdad.offCode+"\"},{\"field\":\"carPackageId\",\"type\":\"equal\",\"search\":"+vm_Emdad.carPackageId+"},{\"field\":\"buildYear\",\"type\":\"equal\",\"search\":"+vm_Emdad.buildYear+"},{\"field\":\"subscriptionStatus\",\"type\":\"equal\",\"search\":"+vm_Emdad.subscriptionStatus+"}],\"sortOrders\":[],\"pagination\":1,\"maxResults\":30}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse responseserviceCard = client.Execute(request);
            var xserviceCard = JsonConvert.DeserializeObject<RootserviceCard>(responseserviceCard.Content);
            if (xserviceCard.Settings.Success=="1")
            {
                ViewBag.Details=xserviceCard.DataserviceCard;
                ViewBag.list=xserviceCard.DataserviceCard.ServiceCardList.ToList();
            }
            if (xserviceCard.Settings.Success=="0")
            {
                 ViewBag.msg=xserviceCard.Settings.Message;
            }
            return View();
        }
        public IActionResult Ostan()
        {
            var client = new RestClient("https://096440.com/api/site/public/state/ops/show");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body ="{\"filters\":[],\"sortOrders\":[{\"sortField\":\"name\",\"sortType\":\"asc\"}],\"pagination\":1,\"maxResults\":50}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse responseostan = client.Execute(request);
            var xostan = JsonConvert.DeserializeObject<Rootostan>(responseostan.Content);
            if (xostan.Settingsostan.Success=="1")
            {
                ViewBag.ostan=xostan.Datumostan.ToList();
            }
            if (xostan.Settingsostan.Success=="0")
            {
                ViewBag.msg=xostan.Settingsostan.Message;
            }
            return View();
        }
        public IActionResult City(string ostan)
        {   
            var client = new RestClient("https://096440.com/api/site/public/city/ops/show");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body ="{\"filters\":[{\"field\":\"stateId\",\"type\":\"equal\",\"search\":\""+ostan+"\"}],\"sortOrders\":[{\"sortField\":\"cityName\",\"sortType\":\"asc\"}],\"pagination\":1,\"maxResults\":10000}";
            request.AddParameter("application/json", body,  ParameterType.RequestBody);
            IRestResponse responsecity = client.Execute(request);
            var xcity = JsonConvert.DeserializeObject<Rootcity>(responsecity.Content);
            if (xcity.Settingscity.Success=="1")
            {
                ViewBag.city=xcity.Datumcity.ToList();
            }
            if (xcity.Settingscity.Success=="0")
            {
                ViewBag.msg=xcity.Settingscity.Message;
            }
            return View();
        }
        




        
        // دیسریالایز استعلام استعلام بررسی داشتن اشتراک خودرو               ///////////////////////////////////
        public class SettingssearchByChassisNumber
        {
            [JsonProperty("success")]
            public string Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public class DatasearchByChassisNumber
        {
            [JsonProperty("eshterak")]
            public string Eshterak { get; set; }

            [JsonProperty("chassisNumber")]
            public string ChassisNumber { get; set; }

            [JsonProperty("startDate")]
            public object StartDate { get; set; }

            [JsonProperty("endDate")]
            public string EndDate { get; set; }

            [JsonProperty("customerName")]
            public string CustomerName { get; set; }

            [JsonProperty("buildYear")]
            public string BuildYear { get; set; }

            [JsonProperty("office")]
            public string Office { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("condition")]
            public string Condition { get; set; }

            [JsonProperty("isSubscriber")]
            public string IsSubscriber { get; set; }

            [JsonProperty("carGroup")]
            public string CarGroup { get; set; }

            [JsonProperty("serviceType")]
            public string ServiceType { get; set; }

            [JsonProperty("carType")]
            public string CarType { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("numberPlate")]
            public object NumberPlate { get; set; }

            [JsonProperty("statusEshterak")]
            public int StatusEshterak { get; set; }

            [JsonProperty("moshtarakyesno")]
            public int Moshtarakyesno { get; set; }

            [JsonProperty("usageid")]
            public string Usageid { get; set; }
        }

        public class RootsearchByChassisNumber
        {
            [JsonProperty("settings")]
            public SettingssearchByChassisNumber Settings { get; set; }

            [JsonProperty("data")]
            public DatasearchByChassisNumber Data { get; set; }
        }


        //     دیسریالایز استعلام اشتراک خودرو                 //////////////////////////////////////////////
        public class SettingsserviceCard
        {
            [JsonProperty("success")]
            public string Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public class ServiceDetailDtoserviceCard
        {
            [JsonProperty("hasRelief")]
            public bool HasRelief { get; set; }

            [JsonProperty("hasBodyInsurance")]
            public bool HasBodyInsurance { get; set; }

            [JsonProperty("hasNaturalDisasters")]
            public bool HasNaturalDisasters { get; set; }

            [JsonProperty("hasPeriodicalService")]
            public bool HasPeriodicalService { get; set; }

            [JsonProperty("hasRepairs")]
            public bool HasRepairs { get; set; }

            [JsonProperty("hasTiresAndTimingBelts")]
            public bool HasTiresAndTimingBelts { get; set; }
        }

        public class ServiceCardListserviceCard
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("selected")]
            public bool Selected { get; set; }

            [JsonProperty("basePrice")]
            public int BasePrice { get; set; }

            [JsonProperty("price")]
            public int Price { get; set; }

            [JsonProperty("priceWithDiscount")]
            public int PriceWithDiscount { get; set; }

            [JsonProperty("enable")]
            public bool Enable { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("postId")]
            public int PostId { get; set; }

            [JsonProperty("starCount")]
            public int StarCount { get; set; }

            [JsonProperty("payable")]
            public int Payable { get; set; }

            [JsonProperty("tax")]
            public int Tax { get; set; }

            [JsonProperty("serviceId")]
            public int ServiceId { get; set; }

            [JsonProperty("discountEffect")]
            public bool DiscountEffect { get; set; }

            [JsonProperty("discountId")]
            public object DiscountId { get; set; }

            [JsonProperty("serviceDetailDto")]
            public ServiceDetailDtoserviceCard ServiceDetailDto { get; set; }
        }

        public class DataserviceCard
        {
            [JsonProperty("currentService")]
            public string CurrentService { get; set; }

            [JsonProperty("endDateOfSubscription")]
            public string EndDateOfSubscription { get; set; }

            [JsonProperty("discountId")]
            public object DiscountId { get; set; }

            [JsonProperty("currentServiceCost")]
            public string CurrentServiceCost { get; set; }

            [JsonProperty("buyRequestType")]
            public string BuyRequestType { get; set; }

            [JsonProperty("marketerId")]
            public object MarketerId { get; set; }

            [JsonProperty("serviceCardList")]
            public List<ServiceCardListserviceCard> ServiceCardList { get; set; }
        }

        public class RootserviceCard
        {
            [JsonProperty("settings")]
            public SettingsserviceCard Settings { get; set; }

            [JsonProperty("data")]
            public DataserviceCard DataserviceCard { get; set; }
        }


        // دیسریالایز استان ها          //////////////////////////////////////////
        public class Settingsostan
        {
            [JsonProperty("success")]
            public string Success { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public class Datumostan
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("stateLargeId")]
            public string StateLargeId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Rootostan
        {
            [JsonProperty("settings")]
            public Settingsostan Settingsostan { get; set; }

            [JsonProperty("data")]
            public List<Datumostan> Datumostan { get; set; }

            [JsonProperty("totalCount")]
            public int TotalCount { get; set; }
        }
        // دیسریالایز کلاس های شهرستان ها                      ///////////////////////////////////////
        public class Settingscity
        {
            [JsonProperty("success")]
            public string Success { get; set; }
    
            [JsonProperty("message")]
            public string Message { get; set; }
        }
    
        public class Datumcity
        {
            [JsonProperty("id")]
            public string Id { get; set; }
    
            [JsonProperty("cityName")]
            public string CityName { get; set; }
    
            [JsonProperty("cityId")]
            public string CityId { get; set; }
    
            [JsonProperty("stateId")]
            public string StateId { get; set; }
    
            [JsonProperty("stateOfficeId")]
            public string StateOfficeId { get; set; }
        }
    
        public class Rootcity
        {
            [JsonProperty("settings")]
            public Settingscity Settingscity { get; set; }
    
            [JsonProperty("data")]
            public List<Datumcity> Datumcity { get; set; }
    
            [JsonProperty("totalCount")]
            public int TotalCount { get; set; }
        } 
    }
}