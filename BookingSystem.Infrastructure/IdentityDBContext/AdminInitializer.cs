using BookingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.IdentityDBContext
{
    public class AdminInitializer
    {
        public static async Task InitializeAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            foreach (var role in new[] {"admin","user" })
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var defaultUser = configuration.GetSection("DefaultUsers");
            var users = defaultUser.Get<List<SeededUser>>();

            if (users?.Count !=0)
            {
                foreach (var user in users)
                {
                    if (await userManager.FindByEmailAsync(user.Email)==null)
                    {
                        User newUser = new User
                        {
                            UserName = user.Name,
                            Email = user.Email,
                            EmailConfirmed = true,
                            IsLocked = user.IsLocked                            
                        };
                        if ((await userManager.CreateAsync(newUser, user.Password)).Succeeded)
                        {
                            foreach (var role in user.Roles)
                            {
                                await userManager.AddToRoleAsync(newUser, role);
                            }
                        }
                    }
                }
            }             
        }
    }

    internal class SeededUser
    {
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public List<string> Roles{ get; set; }
    
    }
}