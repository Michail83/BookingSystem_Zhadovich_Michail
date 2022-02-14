using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.EntityFramework;
using BookingSystem.DataLayer.Interfaces;
using BookingSystem.DataLayer.EntityFramework.Repository;


namespace BookingSystem.DataLayer
{
    public static class DataLayerExtension
    {
        public static IServiceCollection AddDataLayerService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<BookingSystemDBContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("defaultLocalConnection")));

            

            service.AddScoped<IRepositoryAsync<ArtEvent>, ArtEventRepository>();

            service.AddScoped<IRepositoryAsync<OpenAir>, OpenAirRepository>();   // ToDo  Change to generic

            service.AddScoped<IRepositoryAsync<Party>, GenericConcreteRepository<Party>>();
            service.AddScoped<IRepositoryAsync<ClassicMusic>, GenericConcreteRepository<ClassicMusic>>();
            



            return service;
        }

    }
}
