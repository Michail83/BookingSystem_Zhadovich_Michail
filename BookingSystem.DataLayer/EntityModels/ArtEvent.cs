using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DataLayer.EntityModels
{
    public class ArtEvent
    {
        public int Id { get; set; }
        public string IventName { get; set; }
        public int AmounOfTicket { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
    }
}
