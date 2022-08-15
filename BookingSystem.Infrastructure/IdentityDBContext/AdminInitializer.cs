using BookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace BookingSystem.Infrastructure.IdentityDBContext
{
    public class AdminInitializer
    {
        public static async Task InitializeAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var defaultAdmin = configuration.GetSection("DefaultAdmin");
            var admin = "admin";
            if (await roleManager.FindByNameAsync(admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(admin));
            }
            var currentUser = await userManager.FindByEmailAsync(defaultAdmin["Email"]);
            if (currentUser == null)
            {
                User newUser = new User { UserName = defaultAdmin["Name"], Email = defaultAdmin["Email"], EmailConfirmed = true };
                if ((await userManager.CreateAsync(newUser, defaultAdmin["Password"])).Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, admin);
                }
            }
            else
            {
                if (!(await userManager.GetRolesAsync(currentUser)).Contains(admin))
                {
                    await userManager.AddToRoleAsync(currentUser, admin);
                }
            }
        }
    }
}
