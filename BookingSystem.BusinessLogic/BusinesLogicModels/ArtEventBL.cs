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
        public string IventName { get; set; }
        public int AmounOfTicket { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public ArtEventBL()
        {            
        }
        public ArtEventBL(ArtEvent ivent)
        {
            this.Id = ivent.Id;
            this.IventName = ivent.IventName;
            this.AmounOfTicket = ivent.AmounOfTicket;
            this.Date = ivent.Date;
            this.Place = ivent.Place;
        }

        public virtual string ToJsonArtEvent()
        {
            return String.Empty;
        }
    }
}
