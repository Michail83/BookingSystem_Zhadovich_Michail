using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BookingSystem.DataLayer.EntityModels;

namespace BookingSystem.BusinessLogic.BusinesLogicModels
{
    public class ArtEventBL
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int AmountOfTickets { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public ArtEventBL()
        {            
        }
        public ArtEventBL(ArtEvent ivent)
        {
            this.Id = ivent.Id;
            this.EventName = ivent.IventName;
            this.AmountOfTickets = ivent.AmounOfTicket;
            this.Date = ivent.Date;
            this.Place = ivent.Place;
            this.Latitude = ivent.Latitude; 
            this.Longitude = ivent.Longitude;
        }

        public virtual string ToJsonArtEvent()
        {
            return String.Empty;
        }
    }
}
