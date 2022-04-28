using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BookingSystem.DataLayer;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.DataLayer.EntityModels;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Services.MailService;



namespace BookingSystem.BusinessLogic
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection AddBusinessLayerAndDataLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayerService(configuration);

            services.AddScoped<IMapper<ArtEvent, ArtEventBL>, MapperArtEventToBusinesLayer>();

            services.AddScoped<IMapper<OpenAir, OpenAirBL>, MapperOpenAirToBusinessLayer>();
            services.AddScoped<IMapper<OpenAirBL, OpenAir>, MapperOpenAirBLtoDALentity>();

            services.AddScoped<IMapper<Party, PartyBL>, MapperPartyToBusinessLayer>();
            services.AddScoped<IMapper<PartyBL, Party>, MapperPartyBLtoDALentity>();

            services.AddScoped<IMapper<ClassicMusicBL, ClassicMusic>, MapperClassicMusicBLtoDALentity>();
            services.AddScoped<IMapper<ClassicMusic, ClassicMusicBL>, MapperClassicMusicToBusinessLayer>();

            services.AddScoped<IMapper<Order, OrderBL>, MapperOrdertoOrderBL>();
            services.AddScoped<IMapper<OrderBL, Order>, MapperOrderBLtoOrderDAL>();
            services.AddScoped<OrderBLService>();


            services.AddScoped<IBusinessLayerCRUDServiceAsync<ArtEventBL>, ArtEventBLService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<OpenAirBL>, OpenAirBLService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<PartyBL>, PartyBLService>();
            services.AddScoped<IBusinessLayerCRUDServiceAsync<ClassicMusicBL>, ClassicMusicBLService>();

            services.AddScoped<IEmailService, SendEmailService>();
            
            services.AddScoped<CheckCartItemService>();

            services.AddScoped<IArtEventFilter<ArtEvent>, FilterForArtEvent>();
            services.AddScoped<IArtEventSort<ArtEvent>, SortForArtEvent<ArtEvent>>();
            
            







            services.AddScoped<IDataService_TEST<ArtEventBL>, ArtEventBLService_TEST_NOASYNC>();

            return services;
        }
    }
}
