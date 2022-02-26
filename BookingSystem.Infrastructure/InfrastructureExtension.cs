using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

using BookingSystem.Infrastructure.Authentication.IdentityDBContext;
using BookingSystem.Infrastructure.Models;
using BookingSystem.Infrastructure.Interfaces;
using BookingSystem.Infrastructure.Services;


namespace BookingSystem.Infrastructure.Authentication
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection ADDInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<AppIdentityContext>(opt=>opt.UseSqlServer(configuration.GetConnectionString("identityLocalConnection")));

            services.AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<AppIdentityContext>();
            services.AddScoped<IJWTTokenProvider, JwtService>();

            return services;
        }

    }
}
