
using BookingSystem.Infrastructure.IdentityDBContext;
using BookingSystem.Infrastructure.Interfaces;
using BookingSystem.Infrastructure.Models;
using BookingSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection ADDInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            //services.AddDbContext<AppIdentityContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("identityLocalConnection")));
            services.AddDbContext<AppIdentityContext>(opt => opt.UseInMemoryDatabase("identityLocalConnection"));

            services.AddIdentity<User, IdentityRole>(options =>
                    {
                        options.Password.RequiredLength = 4;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireDigit = true;

                        options.SignIn.RequireConfirmedEmail = true;
                        options.User.RequireUniqueEmail = true;
                        options.User.AllowedUserNameCharacters = null;
                    })
                    .AddEntityFrameworkStores<AppIdentityContext>()
                    .AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(12); 
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(180);
                
                options.SlidingExpiration = true;
                options.Cookie.Expiration = TimeSpan.FromMinutes(180);

                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };

            });


            services.AddScoped<IJWTTokenProvider, JwtService>();

            return services;
        }

    }
}
