using System;
using System.Collections.Generic;

namespace BookingSystem.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public bool IsPaid { get; set; }       
        public List<CartWithQuantityViewModel> ListOfReservedEventTickets { get; set; }
    }
}