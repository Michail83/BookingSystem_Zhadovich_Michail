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
            return new OpenAirBL(incoming);
        }
    }
}
