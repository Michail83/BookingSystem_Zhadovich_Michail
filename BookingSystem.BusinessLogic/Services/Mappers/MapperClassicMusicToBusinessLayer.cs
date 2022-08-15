using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperClassicMusicToBusinessLayer : IMapper<ClassicMusic, ClassicMusicBL>
    {
        public ClassicMusicBL Map(ClassicMusic incoming)    //incoming from base -  
        {
            return new ClassicMusicBL
            {
                Id = incoming.Id,
                EventName = incoming.EventName,
                Date = incoming.Date,
                Place = incoming.Place,
                AmountOfTickets = incoming.AmountOfTickets,
                Latitude = incoming.Latitude,
                Longitude = incoming.Longitude,
                Voice = incoming.Voice,
                ConcertName = incoming.ConcertName
            };
        }
        //public ClassicMusicBL Map(ClassicMusic incoming)    //incoming from base -  
        //{
        //    return new ClassicMusicBL(incoming);
        //}
    }
}
