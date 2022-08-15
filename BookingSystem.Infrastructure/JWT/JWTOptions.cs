using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookingSystem.Infrastructure.JWT
{
    public class JWTOptions
    {
        public const string ISSUER = "BookingSystem";
        public const string AUDIENCE = "BookingSystem";
        const string KEY = "My super and very secret secretkey!123 and one time My super and very secret secretkey!123 ";
        public const int LIFETIME = 30;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
