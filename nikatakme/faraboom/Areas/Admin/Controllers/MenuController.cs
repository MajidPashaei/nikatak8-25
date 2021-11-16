using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace Admin.Controllers {
    [Area ("Admin")]
    [Authorize]
    public class MenuController : BaseController
    { 

  public MenuController(ContextHampadco _db,IWebHostEnvironment env):base(_db,env)
      {
          
      }

      
   public IActionResult Index () {

            var token=db.Tbl_TokenValues.SingleOrDefault();
            if (token != null)
            {
                    var Timer=DateTime.Today;
                     if (Timer==token.LifeTime)
                     {
                        var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
                        request.AddHeader("Cookie", "boomrangid=s%3AU9An7QDHKh5XZfCqCT9EB2A4qV8CrlYH.vfyR%2FZUYgqXGY5lJVXTx09Fs2vamhGgaYW5MYHmaJqk");
                        var body =
                        "{" +
                            "\"grant_type\":\"refresh_token\","
                            + "\"token_type\":\"CLIENT-CREDENTIAL\","
                             + "\"refresh_token\":\""+token.Refresh+"\""
                            + "}";
                        request.AddParameter("application/json", body,  ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        var value2 = JsonConvert.DeserializeObject<Root>(response.Content);
                        var NewToken=value2.Result.Value;
                        var NewRefresh=value2.Result.RefreshToken;
                        var NewTime=token.LifeTime.AddDays(9);
                        
                        token.Token=NewToken;
                        token.Refresh=NewRefresh;
                        token.LifeTime=NewTime;
                        db.Tbl_TokenValues.Update(token);
                        db.SaveChanges();
                     }
            }

            ///         paygabz token
            var tokenpay=db.Tbl_TokenPayGabzValues.SingleOrDefault();
            if (tokenpay != null)
            {
                    var Timer=DateTime.Today;
                     if (tokenpay.LifeTime == Timer)
                     {
                        var client = new RestClient("https://apibeta.finnotech.ir/dev/v2/oauth2/token");
                        client.Timeout = -1;
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("Authorization", "Basic bmlrYXRhazUyNTA6aEhYdjJDbGs3RHpuTTB5S1QwTjc=");
                        request.AddHeader("Cookie", "boomrangid=s%3AU9An7QDHKh5XZfCqCT9EB2A4qV8CrlYH.vfyR%2FZUYgqXGY5lJVXTx09Fs2vamhGgaYW5MYHmaJqk");
                        var body =
                        "{" +
                            "\"grant_type\":\"refresh_token\","
                            + "\"bank\":\"062\","
                            + "\"token_type\":\"CODE\","
                            + "\"refresh_token\":\""+tokenpay.Refresh+"\""
                            + "}";
                        request.AddParameter("application/json", body,  ParameterType.RequestBody);
                        IRestResponse response = client.Execute(request);
                        var value2 = JsonConvert.DeserializeObject<Root>(response.Content);
                        var NewToken=value2.Result.Value;
                        var NewRefresh=value2.Result.RefreshToken;
                        var NewTime=token.LifeTime.AddDays(9);
                        
                        tokenpay.Token=NewToken;
                        tokenpay.Refresh=NewRefresh;
                        tokenpay.LifeTime=NewTime;
                        db.Tbl_TokenPayGabzValues.Update(tokenpay);
                        db.SaveChanges();
                     }
            }
             Diposit();
            return View ();
        }


        //reslt
        public class Result
            {
                [JsonProperty("value")]
                public string Value { get; set; }
                [JsonProperty("scopes")]
                public List<string> Scopes { get; set; }
                [JsonProperty("userId")]
                public string UserId { get; set; }
                [JsonProperty("refreshToken")]
                public string RefreshToken { get; set; }
                [JsonProperty("creationDate")]
                public string CreationDate { get; set; }
                [JsonProperty("lifeTime")]
                public int LifeTime { get; set; }
            }

            public class Root
            {
                [JsonProperty("result")]
                public Result Result { get; set; }
                [JsonProperty("status")]
                public string Status { get; set; }
            }

        public IActionResult Index2 () {
             Diposit();
            return View ();
        }
      

    }
}