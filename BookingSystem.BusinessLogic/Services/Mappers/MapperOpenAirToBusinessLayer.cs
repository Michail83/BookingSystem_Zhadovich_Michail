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
    public class MapperOpenAirToBusinessLayer : IMapper<OpenAir, OpenAirBL>
    {
        public OpenAirBL Map(OpenAir incoming)
        {
            return new OpenAirBL 
            {
                Id = incoming.Id,
                EventName = incoming.EventName,
                Date = incoming.Date,
                Place = incoming.Place,
                AmountOfTickets = incoming.AmountOfTickets,
                Latitude=incoming.Latitude,
                Longitude=incoming.Longitude,
                HeadLiner=incoming.HeadLiner
            };
        }
        //public OpenAirBL Map(OpenAir incoming)
        //{
        //    return new OpenAirBL(incoming);
        //}
    }
}
