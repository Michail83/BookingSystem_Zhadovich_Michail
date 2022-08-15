using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperClassicMusicBLtoDALentity : IMapper<ClassicMusicBL, ClassicMusic>
    {
        public ClassicMusic Map(ClassicMusicBL incoming)
        {
            return new ClassicMusic
            {
                Id = incoming.Id,
                AmountOfTickets = incoming.AmountOfTickets,
                Date = incoming.Date,
                Voice = incoming.Voice,
                EventName = incoming.EventName,
                Place = incoming.Place,
                ConcertName = incoming.ConcertName,
                Longitude = incoming.Longitude,
                Latitude = incoming.Latitude
            };
        }
    }
}
