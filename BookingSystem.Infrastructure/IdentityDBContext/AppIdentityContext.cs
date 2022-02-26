using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.Authentication.IdentityDBContext
{
    public class AppIdentityContext : IdentityDbContext<User>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) :base(options)
        { }
    }
}
