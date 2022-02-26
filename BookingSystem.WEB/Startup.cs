using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Google

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookingSystem.BusinessLogic;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.WEB.Services;
using BookingSystem.WEB.Models;
using BookingSystem.Infrastructure.Authentication;

using BookingSystem.Infrastructure.JWT;

using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;

namespace BookingSystem.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //extract
            var secret = Configuration.GetSection("JwtConfig").GetSection("secret").Value;

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration.GetSection("JwtConfig").GetSection("issuer").Value,
                    ValidAudience = Configuration.GetSection("JwtConfig").GetSection("audience").Value
                };
            });

            services.AddControllersWithViews();
            services.AddBusinessLayerAndDataLayerServices(Configuration);
            services.ADDInfrastructureServices(Configuration);


            services.AddScoped<IMapper<ArtEventBL, ArtEventViewModel>, MapperFromArtEventToArtEventViewModel>();

            services.AddMemoryCache();

            services.AddCors(options => 
            {
                options.AddPolicy("LocalForDevelopment", builder =>
                {
                    builder.WithOrigins("https://localhost:44324");
                });
                
                options.AddPolicy("LocalForDevelopmentAllowAll", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                  
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    });
            });
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddReact();
            //services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
        }
    }
}
