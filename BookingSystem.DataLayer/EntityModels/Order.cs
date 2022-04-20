using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.DataLayer.EntityModels
{

    public class Order
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeOfCreation { get; set; }

        public List<ArtEvent> ArtEvents { get; set; } = new List<ArtEvent>();
        public List<OrderAndArtEvent> OrderAndArtEvents { get; set; } = new List<OrderAndArtEvent>();
    }
}
