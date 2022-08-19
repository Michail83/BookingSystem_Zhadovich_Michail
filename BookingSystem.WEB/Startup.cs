using BookingSystem.BusinessLogic;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services.AutoMapper;
using BookingSystem.Infrastructure;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.Services;
using BookingSystem.WEB.Services.AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace BookingSystem.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private Task MakeHttps(RedirectContext<OAuthOptions> arg)
        {
            if (!arg.RedirectUri.Contains("redirect_uri=https", StringComparison.OrdinalIgnoreCase))
            {
                arg.RedirectUri = arg.RedirectUri.Replace("redirect_uri=http", "redirect_uri=https", StringComparison.OrdinalIgnoreCase);
            }

            arg.HttpContext.Response.Redirect(arg.RedirectUri);

            return Task.CompletedTask;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BysinessLayerAutoMapperProfile), typeof(WebAutoMapperProfile));
            services.Configure<BusinessLogic.Services.MailService.MailSettings>(Configuration.GetSection("MailSettings"));

            services.ADDInfrastructureServices(Configuration);
            
            services.AddAuthentication()
                .AddGoogle("google", options =>
                 {
                     var authData = Configuration.GetSection("Authentication:Google");

                     options.ClientId = authData["ClientId"];
                     options.ClientSecret = authData["ClientSecret"];
                     options.SignInScheme = IdentityConstants.ExternalScheme;
                     options.CallbackPath = new PathString("/signin-rnuto45");

                     options.Events.OnRedirectToAuthorizationEndpoint = MakeHttps;
                     
                 })
                .AddFacebook("facebook", options =>
                {
                    var authData = Configuration.GetSection("Authentication:Facebook");

                    options.ClientId = authData["ClientId"];
                    options.ClientSecret = authData["ClientSecret"];
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                    options.CallbackPath = new PathString("/signin-hfuema");
                });

            services.AddControllersWithViews();

            services.AddBusinessLayerAndDataLayerServices(Configuration);

            services.AddScoped<IMapper<ArtEventBL, ArtEventViewModel>, AutoMapperArtEventBLToArtEventViewModel<ArtEventBL, ArtEventViewModel>>();
            services.AddScoped<IMapper<OrderBL, OrderViewModel>, AutoMapperArtEventBLToArtEventViewModel<OrderBL, OrderViewModel>>();


            services.AddMemoryCache();

            services.AddCors(options =>
            {
                //options.AddPolicy("LocalForDevelopment", builder =>
                //{
                //    builder.WithOrigins("https://localhost:44324");
                //});
                options.AddPolicy("LocalForDevelopmentAllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}

