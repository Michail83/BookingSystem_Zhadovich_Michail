using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public string Role;
    }
}
