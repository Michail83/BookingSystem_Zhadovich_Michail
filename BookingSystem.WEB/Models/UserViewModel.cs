namespace BookingSystem.WEB.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; } = false;
        public int OrdersCount { get; set; } = 0;
        public bool HasPassword { get; set; } = true;

    }
}
