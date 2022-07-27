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
    public class MapperPartyBLtoDALentity : IMapper<PartyBL, Party>
    {
        public Party Map(PartyBL incoming)  //means -  incoming is validated in controller
        {
            return new Party
            {
                Id = incoming.Id, 
                AmountOfTickets = incoming.AmountOfTickets,
                Date = incoming.Date,
                AgeLimitation = incoming.AgeLimitation,
                EventName = incoming.EventName, 
                Place = incoming.Place,
                Longitude = incoming.Longitude,
                Latitude = incoming.Latitude
            };
        }
    }
}
