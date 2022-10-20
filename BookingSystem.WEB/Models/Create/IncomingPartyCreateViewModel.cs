using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models
{
    public class IncomingPartyCreateViewModel : IncomingBaseCreateArtEventViewModel
    {
        [Required]
        public string AgeLimitation { get; set; }       
    }
}
