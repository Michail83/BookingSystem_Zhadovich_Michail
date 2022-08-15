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
                EventName = ArtEvent.EventName,
                Date = ArtEvent.Date,
                Place = ArtEvent.Place,
                AmountOfTickets = ArtEvent.AmountOfTickets,
                Latitude = ArtEvent.Latitude,
                Longitude = ArtEvent.Longitude
            };
        }
        public static ArtEventViewModel ConvertFromClassicMusicEventBLtoView(ClassicMusicBL classicMusicBL)
        {
            var result = ConvertBaseProperty(classicMusicBL);

            result.TypeOfArtEvent = "ClassicMusic";
            result.AdditionalInfo = new string[] { classicMusicBL.ConcertName, classicMusicBL.Voice };
            return result;
        }

        public static ArtEventViewModel ConvertFromOpenAirEventBLtoView(OpenAirBL openAir)
        {
            var result = ConvertBaseProperty(openAir);

            result.TypeOfArtEvent = "OpenAir";
            result.AdditionalInfo = new string[] { openAir.HeadLiner };
            return result;
        }

        public static ArtEventViewModel ConvertFromPartyEventBLtoView(PartyBL party)
        {
            var result = ConvertBaseProperty(party);

            result.TypeOfArtEvent = "Party";
            result.AdditionalInfo = new string[] { party.AgeLimitation.ToString() };
            return result;
        }

    }
}
