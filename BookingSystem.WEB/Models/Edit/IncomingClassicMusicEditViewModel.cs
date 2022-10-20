using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models
{
    public class IncomingClassicMusicEditViewModel : IncomingBaseEditArtEventViewModel
    {
        [Required]
        public string Voice { get; set; }
        [Required]
        public string ConcertName { get; set; }
    }
}
