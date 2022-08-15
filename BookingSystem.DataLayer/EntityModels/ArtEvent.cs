using System;
using System.Collections.Generic;

namespace BookingSystem.DataLayer.EntityModels
{
    public class ArtEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int AmountOfTickets { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderAndArtEvent> OrderAndArtEvents { get; set; } = new List<OrderAndArtEvent>();

    }
}
