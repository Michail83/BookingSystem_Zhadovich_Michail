using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models
{
    public class IncomingPartyEditViewModel : IncomingBaseEditArtEventViewModel
    {
        [Required]
        public string AgeLimitation { get; set; }       
    }
}
