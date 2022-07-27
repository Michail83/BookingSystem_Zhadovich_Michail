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
                Voice= incoming.Voice,
                ConcertName= incoming.ConcertName
            };
        }
        //public ClassicMusicBL Map(ClassicMusic incoming)    //incoming from base -  
        //{
        //    return new ClassicMusicBL(incoming);
        //}
    }
}
