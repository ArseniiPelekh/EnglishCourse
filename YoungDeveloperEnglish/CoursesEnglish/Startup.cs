using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Inteface;
using Data.Models.EmailModels;
using Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoursesEnglish
{
    public class Startup
    {
        private IConfigurationRoot _confSting;


        public Startup(IWebHostEnvironment host, IConfiguration configuration) // смена
        {
            _confSting = new ConfigurationBuilder().SetBasePath(host.ContentRootPath)
                .AddJsonFile("dbSettings.json")
                .AddJsonFile($"jsconfig.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

   
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _confSting.GetConnectionString("DefaultConnection");

            string appIdentitySettings = _confSting.GetConnectionString("AppIdentitySettings");

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Admin/Login");
                });

            services.Configure<AppIdentitySettings>(_confSting.GetSection("AppIdentitySettings"));
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleTypeRepository, ArticleTypeRepository>();
            services.AddTransient<IPersonRequestRepository, PersonRequestRepository>();

            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
