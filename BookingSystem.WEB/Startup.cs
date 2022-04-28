

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.IdentityModel.Tokens;

using BookingSystem.BusinessLogic;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Services;
using BookingSystem.WEB.Models;

using BookingSystem.Infrastructure.JWT;
using BookingSystem.Infrastructure;

namespace BookingSystem.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BusinessLogic.Services.MailService.MailSettings>(Configuration.GetSection("MailSettings"));

            services.ADDInfrastructureServices(Configuration);            
            services.AddAuthentication()
                .AddGoogle("google",options => 
                {
                    var authData = Configuration.GetSection("Authentication:Google");

                    options.ClientId = authData ["ClientId"];
                    options.ClientSecret = authData["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddFacebook("facebook", options=>
                {
                    var authData = Configuration.GetSection("Authentication:Facebook");

                    options.ClientId = authData["ClientId"];
                    options.ClientSecret = authData["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;                             
                });

            services.AddControllersWithViews();

            services.AddBusinessLayerAndDataLayerServices(Configuration);            

            services.AddScoped<IMapper<ArtEventBL, ArtEventViewModel>, MapperFromArtEventBLToArtEventViewModel>();

            services.AddMemoryCache();

            services.AddCors(options => 
            {
                options.AddPolicy("LocalForDevelopment", builder =>
                {
                    builder.WithOrigins("https://localhost:44324");
                });                
                options.AddPolicy("LocalForDevelopmentAllowAll", builder =>
                {
                    builder.AllowAnyOrigin()  /* WithOrigins("http://localhost:3000")   */   
                    //.AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    });
            });
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
