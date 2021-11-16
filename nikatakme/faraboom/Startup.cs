using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace faraboom {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            

            services.AddControllersWithViews ();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddMvc ().AddRazorRuntimeCompilation ();
            services.AddDbContext<ContextHampadco> (option => {
            option.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection"));
            });
            /////////////auto
            services.AddAuthentication (options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie (options => {
                options.LoginPath = "/Home/index";
                options.LogoutPath = "/Home/index";
                options.ExpireTimeSpan = TimeSpan.FromMinutes (43200);
            });
            
            /////////////////////
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
            //   app.UseExceptionHandler ("/Home/Error");
                // // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // // app.UseHsts ();
                 app.UseDeveloperExceptionPage ();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                ForwardedHeaders.XForwardedProto
            });  
        
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseRouting ();
            app.UseAuthentication ();
            app.UseAuthorization ();
            app.UseSession();
          
            

            // app.UseEndpoints (endpoints => {
            //     endpoints.MapControllerRoute (
            //         name: "areas",
            //         pattern: "{Admin:exists}/{controller=menu}/{action=form}/{id?}");
            // });
            //  app.UseEndpoints (endpoints => {
            //     endpoints.MapControllerRoute (
            //         name: "areas",
            //         pattern: "{Adminsite:exists}/{controller=Home}/{action=Index}/{id?}");
            // });

            // app.UseEndpoints (endpoints => {
            //     endpoints.MapControllerRoute (
            //         name: "default",
            //         pattern: "{controller=home}/{action=index}/{id?}");
            // });
            app.UseEndpoints (endpoints => {

                endpoints.MapAreaControllerRoute (
                    name: "Areas",
                    areaName:"Admin",
                    pattern: "Admin/{controller=Menu}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute (
                    name: "Areas",
                    areaName:"Adminsite",
                    pattern: "Adminsite/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute (
                    name: "Areas",
                    areaName:"Kasabeyar",
                    pattern: "Kasabeyar/{controller=log}/{action=login}/{id?}");

                     endpoints.MapAreaControllerRoute (
                    name: "Areas",
                    areaName:"Mobile",
                    pattern: "Mobile/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
               
            });
                
        }
    }
}