using Microsoft.AspNetCore.Http;
using System;

namespace BookingSystem.WEB.Models
{
    public class IncomingClassicMusicArtEventViewModel : IncomingBaseArtEventViewModel
    {
        public string Voice { get; set; }
        public string ConcertName { get; set; }
    }
}
