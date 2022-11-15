using BookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Infrastructure.IdentityDBContext
{
    public class AppIdentityContext : IdentityDbContext<User>
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
