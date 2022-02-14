using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class OpenAirBL : ArtEventBL
    {
        public string HeadLiner { get; set; }

        public OpenAirBL():base()  
        { }
        public OpenAirBL(OpenAir openAir) : base(openAir)
        {
            this.HeadLiner = openAir.HeadLiner;
        }        
    }
}
