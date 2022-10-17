using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookingSystem.DataLayer.EntityModels
{    
    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public bool IsPaid { get; set; } = false;
        [Newtonsoft.Json.JsonIgnore]
        public string PaidOrder { get; set; }

        public List<ArtEvent> ArtEvents { get; set; } = new List<ArtEvent>();
        public List<OrderAndArtEvent> OrderAndArtEvents { get; set; } = new List<OrderAndArtEvent>();
    }
}