using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.WEB.Models;

namespace BookingSystem.WEB.StaticClasses

{
    public static class StaticMapperElements
    {
        private static ArtEventViewModel ConvertBaseProperty(ArtEventBL ArtEvent)
        {
            return new ArtEventViewModel
            {
                Id = ArtEvent.Id,
                IventName = ArtEvent.IventName,
                Date = ArtEvent.Date,
                Place = ArtEvent.Place,
                AmounOfTicket = ArtEvent.AmounOfTicket
            };
        }
        public static ArtEventViewModel ConvertFromClassicMusicEventBL(ClassicMusicBL classicMusicBL)
        {
            var result = (ArtEventViewModel)ConvertBaseProperty(classicMusicBL);

            result.TypeOfArtEvent = "ClassicMusic";
            result.AdditionalInfo = new string[] { classicMusicBL.ConcertName, classicMusicBL.Voice };
            return result;
        }

        public static ArtEventViewModel ConvertFromOpenAirEventBL(OpenAirBL openAir)
        {
            var result = (ArtEventViewModel)ConvertBaseProperty(openAir);

            result.TypeOfArtEvent = "OpenAir";
            result.AdditionalInfo = new string[] { openAir.HeadLiner };
            return result;
        }

        public static ArtEventViewModel ConvertFromPartyEventBL(PartyBL party)
        {
            var result = (ArtEventViewModel)ConvertBaseProperty(party);

            result.TypeOfArtEvent = "Party";
            result.AdditionalInfo = new string[] { party.AgeLimitation.ToString() };
            return result;
        }

    }
}
