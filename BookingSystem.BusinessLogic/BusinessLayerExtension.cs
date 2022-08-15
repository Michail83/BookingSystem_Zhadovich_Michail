using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.Services;
using BookingSystem.BusinessLogic.Services.AutoMapper;
using BookingSystem.BusinessLogic.Services.MailService;
using BookingSystem.DataLayer;
using BookingSystem.DataLayer.EntityModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace BookingSystem.BusinessLogic
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection AddBusinessLayerAndDataLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayerService(configuration);

            //services.AddScoped<IMapper<ArtEvent, ArtEventBL>, MapperArtEventToBusinesLayer>();

            //services.AddScoped<IMapper<OpenAir, OpenAirBL>, MapperOpenAirToBusinessLayer>();
            //services.AddScoped<IMapper<OpenAirBL, OpenAir>, MapperOpenAirBLtoDALentity>();

            //services.AddScoped<IMapper<Party, PartyBL>, MapperPartyToBusinessLayer>();
            //services.AddScoped<IMapper<PartyBL, Party>, MapperPartyBLtoDALentity>();

            //services.AddScoped<IMapper<ClassicMusicBL, ClassicMusic>, MapperClassicMusicBLtoDALentity>();
            //services.AddScoped<IMapper<ClassicMusic, ClassicMusicBL>, MapperClassicMusicToBusinessLayer>();

            //services.AddScoped<IMapper<Order, OrderBL>, MapperOrdertoOrderBL>();
            //services.AddScoped<IMapper<OrderBL, Order>, MapperOrderBLtoOrderDAL>();

            services.AddScoped<IMapper<ArtEvent, ArtEventBL>, AutoMapperArtEventToBusinesLayer>();

            services.AddScoped<IMapper<OpenAir, OpenAirBL>, AutoMapperBetweenDLandBLlayer<OpenAir, OpenAirBL>>();
            services.AddScoped<IMapper<OpenAirBL, OpenAir>, AutoMapperBetweenDLandBLlayer<OpenAirBL, OpenAir>>();

            services.AddScoped<IMapper<Party, PartyBL>, AutoMapperBetweenDLandBLlayer<Party, PartyBL>>();
            services.AddScoped<IMapper<PartyBL, Party>, AutoMapperBetweenDLandBLlayer<PartyBL, Party>>();

            services.AddScoped<IMapper<ClassicMusicBL, ClassicMusic>, AutoMapperBetweenDLandBLlayer<ClassicMusicBL, ClassicMusic>>();
            services.AddScoped<IMapper<ClassicMusic, ClassicMusicBL>, AutoMapperBetweenDLandBLlayer<ClassicMusic, ClassicMusicBL>>();

            services.AddScoped<IMapper<Order, OrderBL>, AutoMapperBetweenDLandBLlayer<Order, OrderBL>>();
            services.AddScoped<IMapper<OrderBL, Order>, AutoMapperBetweenDLandBLlayer<OrderBL, Order>>();

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
