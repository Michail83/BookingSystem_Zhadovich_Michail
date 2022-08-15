using System;
using System.Collections.Generic;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{

    public class OrderBL
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public List<CartWithQuantityBL> ListOfReservedEventTickets { get; set; }
    }
}
