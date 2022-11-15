using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.BusinessLogic.Services.AutoMapper;
using BookingSystem.BusinessLogic.Services.MailService;
using BookingSystem.DataLayer;
using BookingSystem.DataLayer.EntityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookingSystem.BusinessLogic.Services.CRUDServices;



namespace BookingSystem.BusinessLogic
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection AddBusinessLayerAndDataLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayerService(configuration);

            services.AddScoped<OrderBLService>();

            services.AddScoped<IBusinessLayerCRUDServiceAsync<ArtEventBL>, ArtEventCRUDService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<OpenAirBL>, OpenAirCRUDService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<PartyBL>, PartyCRUDService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<ClassicMusicBL>, ClassicMusicCRUDService>();

            services.AddScoped<IEmailService, SendEmailService>();
            services.AddScoped<CheckCartItemService>();

            services.AddScoped<IArtEventFilter<ArtEvent>, FilterForArtEvent>();
            services.AddScoped<IArtEventSort<ArtEvent>, SortForArtEvent<ArtEvent>>();

            return services;
        }
    }
}
