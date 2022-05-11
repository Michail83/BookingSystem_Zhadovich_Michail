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
    public class MapperOpenAirBLtoDALentity : IMapper<OpenAirBL, OpenAir>
    {
        public OpenAir Map(OpenAirBL incoming)  //means -  incoming is validated
        {
            return new OpenAir 
            {
                Id = incoming.Id, 
                AmounOfTicket = incoming.AmountOfTickets,
                Date = incoming.Date,
                HeadLiner = incoming.HeadLiner, 
                IventName = incoming.EventName, 
                Place = incoming.Place,
                Longitude = incoming.Longitude,
                Latitude = incoming.Latitude
            };
        }
    }
}
