using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.Interfaces;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.Services
{
    public class MapperClassicMusicBLtoDALentity : IMapper<ClassicMusicBL, ClassicMusic>
    {
        public ClassicMusic Map(ClassicMusicBL incoming)  //means -  incoming is validated in controller
        {
            return new ClassicMusic
            {
                Id = incoming.Id, 
                AmounOfTicket = incoming.AmountOfTickets,
                Date = incoming.Date,
                Voice = incoming.Voice,
                IventName = incoming.EventName, 
                Place = incoming.Place,
                ConcertName = incoming.ConcertName,
                Longitude = incoming.Longitude,
                Latitude = incoming.Latitude
            };
        }
    }
}
