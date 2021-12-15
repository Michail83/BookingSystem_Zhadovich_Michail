using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;
using BookingSystem.WEB.StaticClasses;

namespace BookingSystem.WEB.Services

{
    public class MapperFromArtEventToArtEventViewModel : IMapper<ArtEventBL, ArtEventViewModel>
    {
        public ArtEventViewModel Map(ArtEventBL artEventBL) => artEventBL.GetType().ToString() switch
        {
            "BookingSystem.BusinessLogic.BusinesLogicModels.ClassicMusicBL" => StaticMapperElements.ConvertFromClassicMusicEventBL((ClassicMusicBL)artEventBL),
            "BookingSystem.BusinessLogic.BusinesLogicModels.OpenAirBL" => StaticMapperElements.ConvertFromOpenAirEventBL((OpenAirBL)artEventBL),
            "BookingSystem.BusinessLogic.BusinesLogicModels.PartyBL" => StaticMapperElements.ConvertFromPartyEventBL((PartyBL)artEventBL),
            _ => throw new System.Exception("Type not found")
        };

        //private ArtEventViewModel ConvertBaseProperty(ArtEventBL ArtEvent)
        //{
        //    return new ArtEventViewModel
        //    {
        //        Id = ArtEvent.Id,
        //        IventName = ArtEvent.IventName,
        //        Date = ArtEvent.Date,
        //        Place = ArtEvent.Place,
        //        AmounOfTicket = ArtEvent.AmounOfTicket
        //    };
        //}
        //private ArtEventViewModel ConvertFromClassicMusicEventBL(ClassicMusicBL classicMusicBL)
        //{
        //    var result = (ArtEventViewModel)ConvertBaseProperty(classicMusicBL);

        //    result.TypeOfArtEvent = "ClassicMusic";
        //    result.AdditionalInfo = new string[] { classicMusicBL.ConcertName, classicMusicBL.Voice};
        //    return result;
        //}

        //private ArtEventViewModel ConvertFromOpenAirEventBL(OpenAirBL openAir)
        //{
        //    var result = (ArtEventViewModel)ConvertBaseProperty(openAir);

        //    result.TypeOfArtEvent = "OpenAir";
        //    result.AdditionalInfo = new string[] { openAir.HeadLiner};
        //    return result;
        //}

        //private ArtEventViewModel ConvertFromPartyEventBL(PartyBL party)
        //{
        //    var result = (ArtEventViewModel)ConvertBaseProperty(party);

        //    result.TypeOfArtEvent = "Party";
        //    result.AdditionalInfo = new string[] { party.AgeLimitation.ToString() };
        //    return result;
        //}



    }
}
