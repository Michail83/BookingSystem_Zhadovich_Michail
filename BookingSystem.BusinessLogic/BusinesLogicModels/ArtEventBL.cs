using System;


namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class ArtEventBL
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int AmountOfTickets { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public byte[] Image { get; set; }

    }
}
