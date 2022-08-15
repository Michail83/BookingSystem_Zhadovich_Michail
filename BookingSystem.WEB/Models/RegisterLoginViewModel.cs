using System.ComponentModel.DataAnnotations;

namespace BookingSystem.WEB.Models


{
    public class RegisterLoginViewModel
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }

    }
}
