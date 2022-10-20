using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models
{
    public class IncomingOpenAirEditViewModel : IncomingBaseEditArtEventViewModel
    {
        [Required]
        [MinLength(2)]
        public string HeadLiner { get; set; }       
    }
}
