using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Infrastructure.Models;


namespace BookingSystem.Infrastructure.Interfaces
{
    public interface IJWTTokenProvider
    {
        public string GetSecurityToken(User user);
    }
}
