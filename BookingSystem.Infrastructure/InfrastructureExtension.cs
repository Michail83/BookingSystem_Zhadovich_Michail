
using BookingSystem.Infrastructure.IdentityDBContext;
using BookingSystem.Infrastructure.Interfaces;
using BookingSystem.Infrastructure.Models;
using BookingSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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


            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //    })
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "888637803632-1f5fpip1a2dpfimfdj0nfaojeb20m4rd.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    });

            services.AddScoped<IJWTTokenProvider, JwtService>();

            return services;
        }

    }
}
