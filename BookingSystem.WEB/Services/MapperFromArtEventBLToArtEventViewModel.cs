using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.StaticClasses;

namespace BookingSystem.WEB.Services

{
    public class MapperFromArtEventBLToArtEventViewModel : IMapper<ArtEventBL, ArtEventViewModel>
    {
        public ArtEventViewModel Map(ArtEventBL artEventBL) => artEventBL.GetType().ToString() switch
        {
            "BookingSystem.BusinessLogic.BusinesLogicModels.ClassicMusicBL" => StaticMapperElements.ConvertFromClassicMusicEventBLtoView((ClassicMusicBL)artEventBL),
            "BookingSystem.BusinessLogic.BusinesLogicModels.OpenAirBL" => StaticMapperElements.ConvertFromOpenAirEventBLtoView((OpenAirBL)artEventBL),
            "BookingSystem.BusinessLogic.BusinesLogicModels.PartyBL" => StaticMapperElements.ConvertFromPartyEventBLtoView((PartyBL)artEventBL),
            _ => throw new System.Exception("Type not found")
        };
    }
}
