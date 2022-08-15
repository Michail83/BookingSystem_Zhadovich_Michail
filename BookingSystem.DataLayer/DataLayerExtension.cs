
using BookingSystem.DataLayer.EntityFramework;
using BookingSystem.DataLayer.EntityFramework.Repository;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookingSystem.DataLayer
{
    public static class DataLayerExtension
    {
        public static IServiceCollection AddDataLayerService(this IServiceCollection service, IConfiguration configuration)
        {
            //service.AddDbContext<BookingSystemDBContext>(option =>
            //option.UseSqlServer(configuration.GetConnectionString("defaultLocalConnection")));
            service.AddDbContext<BookingSystemDBContext>(option =>
            option.UseInMemoryDatabase("defaultLocalConnection"));



            service.AddScoped<IRepositoryAsync<ArtEvent>, ArtEventRepository>();

            service.AddScoped<IRepositoryAsync<OpenAir>, OpenAirRepository>();   // ToDo  Change to generic

            service.AddScoped<IRepositoryAsync<Party>, GenericConcreteRepository<Party>>();

            service.AddScoped<IRepositoryAsync<ClassicMusic>, GenericConcreteRepository<ClassicMusic>>();

            service.AddScoped<IOrderRepositoryAsync, OrderRepositoryInMemory>();




            return service;
        }

    }
}
