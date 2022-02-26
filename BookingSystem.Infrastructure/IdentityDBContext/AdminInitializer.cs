using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BookingSystem.Infrastructure.Models;

namespace BookingSystem.Infrastructure.IdentityDBContext
{
    public class AdminInitializer
    {
        public static async Task InitializeAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = "admin";
            if (await roleManager.FindByNameAsync(admin) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(admin));
            }
            if (await userManager.FindByNameAsync(admin)==null)
            {
                User user = new User { UserName = admin };
                if ((await userManager.CreateAsync(user, admin+"1")).Succeeded)
                {
                    await userManager.AddToRoleAsync(user, admin);
                }
            }

        }
    }
}
