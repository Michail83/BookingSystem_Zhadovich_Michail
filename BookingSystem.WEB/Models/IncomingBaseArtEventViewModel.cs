using Microsoft.AspNetCore.Http;
using System;

namespace BookingSystem.WEB.Models
{
    public class IncomingBaseArtEventViewModel
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int AmountOfTickets { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }   
        public IFormFile Image { get; set; }
    }
}
