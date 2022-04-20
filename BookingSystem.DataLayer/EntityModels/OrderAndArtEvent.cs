using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataLayer.EntityModels
{
    public class OrderAndArtEvent
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int NumberOfBookedTicket { get; set; }

        public int ArtEventId { get; set; }
        public ArtEvent ArtEvent { get; set; }
    }
}
