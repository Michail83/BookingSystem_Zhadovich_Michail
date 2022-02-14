using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BookingSystem.BusinessLogic.BusinesLogicModels;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class PartyBL : ArtEventBL
    {
        public int AgeLimitation { get; set; }
        public PartyBL() : base()
        { }

        public PartyBL(Party party) : base(party)
        {
            this.AgeLimitation = party.AgeLimitation;
        }
        
    }
}
