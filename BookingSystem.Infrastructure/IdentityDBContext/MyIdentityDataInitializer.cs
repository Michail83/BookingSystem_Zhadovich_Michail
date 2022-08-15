
using BookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BookingSystem.Infrastructure.IdentityDBContext
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedData(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            SeedRoles(roleManager, configuration);
            SeedUsers(userManager, configuration);
        }
        public static void SeedUsers(UserManager<User> userManager, IConfiguration configuration)
        {
            var defaultAdmin = configuration.GetSection("DefaultAdmin");
            var adminName = defaultAdmin["Name"].ToLower(System.Globalization.CultureInfo.InvariantCulture);
            var adminEmail = defaultAdmin["Email"].ToLower(System.Globalization.CultureInfo.InvariantCulture);
            var password = defaultAdmin["Password"];

            if (userManager.FindByNameAsync(adminName).Result == null)
            {
                User user = new User()
                {
                    Id = System.Guid.NewGuid().ToString(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail,
                    EmailConfirmed = true,
                    UserName = adminName
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, adminName).Wait();
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var defaultAdmin = configuration.GetSection("DefaultAdmin");
            var adminRole = defaultAdmin["Name"].ToLower(System.Globalization.CultureInfo.InvariantCulture);

            if (!roleManager.RoleExistsAsync(adminRole).Result)
            {
                IdentityRole role = new();
                role.Name = adminRole;
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
