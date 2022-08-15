using BookingSystem.Infrastructure.Models;


namespace BookingSystem.Infrastructure.Interfaces
{
    public interface IJWTTokenProvider
    {
        public string GetSecurityToken(User user);
    }
}
