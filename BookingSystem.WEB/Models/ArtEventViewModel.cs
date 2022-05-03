using System;

namespace BookingSystem.WEB.Models
{
    public class ArtEventViewModel
    {
        public int Id { get; set; }
        public string IventName { get; set; }
        public int AmounOfTicket { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string TypeOfArtEvent { get; set; }
        public string[] AdditionalInfo { get; set; }
    }
}
