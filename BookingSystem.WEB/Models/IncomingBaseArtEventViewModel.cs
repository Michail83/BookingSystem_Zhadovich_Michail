using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models
{
    public class IncomingBaseArtEventViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string EventName { get; set; }
        [Required]
        [Range(1,Int32.MaxValue)]
        public int AmountOfTickets { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MinLength(2)]
        public string Place { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }   
        [Required]
        public IFormFile Image { get; set; }
    }
}
