using Microsoft.AspNetCore.Http;
using System;

namespace BookingSystem.WEB.Models
{
    public class IncomingOpenAirArtEventViewModel : IncomingBaseArtEventViewModel
    {
        public string HeadLiner { get; set; }       
    }
}
