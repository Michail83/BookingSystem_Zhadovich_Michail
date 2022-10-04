using Microsoft.AspNetCore.Identity;
using System;

namespace BookingSystem.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public string Role;
        public DateTime? ConfirmationTokenCreationTime { get; set; } = null;
        public bool IsLocked { get; set; } = false;
    }
}
