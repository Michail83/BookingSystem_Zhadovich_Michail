using Microsoft.AspNetCore.Http;
using System;

namespace BookingSystem.WEB.Models
{
    public class IncomingPartyArtEventViewModel : IncomingBaseArtEventViewModel
    {
        public string AgeLimitation { get; set; }       
    }
}
