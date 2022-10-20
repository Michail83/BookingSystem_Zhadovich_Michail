using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models


{
    public class LoginViewModel
    {

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
