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


namespace BookingSystem.BusinessLogic
{
    public static class BusinessLayerExtension
    {
        public static IServiceCollection AddBusinessLayerAndDataLayerServices(this IServiceCollection servises, IConfiguration configuration)
        {
            servises.AddDataLayerService(configuration);

            servises.AddScoped<IMapper<ArtEvent, ArtEventBL>, MapperArtEventToBusinesLayer>();

            servises.AddScoped<IMapper<OpenAir, OpenAirBL>, MapperOpenAirToBusinessLayer>();
            servises.AddScoped<IMapper<OpenAirBL, OpenAir>, MapperOpenAirBLtoDALentity>();

            servises.AddScoped<IMapper<Party, PartyBL>, MapperPartyToBusinessLayer>();
            servises.AddScoped<IMapper<PartyBL, Party>, MapperPartyBLtoDALentity>();

            servises.AddScoped<IMapper<ClassicMusicBL, ClassicMusic>, MapperClassicMusicBLtoDALentity>();
            servises.AddScoped<IMapper<ClassicMusic, ClassicMusicBL>, MapperClassicMusicToBusinessLayer>();

            servises.AddScoped<IBusinessLayerCRUDServiceAsync<ArtEventBL>, ArtEventBLService>();
            servises.AddScoped<IBusinessLayerCRUDServiceAsync<OpenAirBL>, OpenAirBLService>();
            servises.AddScoped<IBusinessLayerCRUDServiceAsync<PartyBL>, PartyBLService>();
            servises.AddScoped<IBusinessLayerCRUDServiceAsync<ClassicMusicBL>, ClassicMusicBLService>();




            servises.AddScoped<IArtEventFilter<ArtEvent>, FilterForArtEvent>();
            servises.AddScoped<IArtEventSort<ArtEvent>, SortForArtEvent<ArtEvent>>();
            







            servises.AddScoped<IDataService_TEST<ArtEventBL>, ArtEventBLService_TEST_NOASYNC>();

            return servises;
        }
    }
}
