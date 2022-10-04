
//using BookingSystem.Infrastructure.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;

//namespace BookingSystem.Infrastructure.IdentityDBContext
//{
//    public static class DELETE_MyIdentityDataInitializer
//    {
//        public static void SeedData(
//            UserManager<User> userManager,
//            RoleManager<IdentityRole> roleManager,
//            IConfiguration configuration)
//        {
//            SeedRoles(roleManager, configuration);
//            SeedUsers(userManager, configuration.GetSection("DefaultAdmin"));


//        }
//        public static void SeedUsers(UserManager<User> userManager, IConfigurationSection section)
//        {
//            //var defaultAdmin = configuration.GetSection("DefaultAdmin");


//            var name = section["Name"].ToLower(System.Globalization.CultureInfo.InvariantCulture);
//            var email = section["Email"].ToLower(System.Globalization.CultureInfo.InvariantCulture);
//            var password = section["Password"];
            
//            bool.TryParse(section["IsLocked"], out bool Islocked);

//            var rolessection = section.GetSection("Roles");
//            var roles = rolessection.Get<RolesList>();

//            if (userManager.FindByEmailAsync(email).Result == null)
//            {
//                User user = new User()
//                {
//                    Id = System.Guid.NewGuid().ToString(),
//                    Email = email,
//                    NormalizedEmail = email,
//                    EmailConfirmed = true,
//                    UserName = name,
//                    IsLocked = Islocked
//                };
//                IdentityResult result = userManager.CreateAsync(user, password).Result;

//                if (result.Succeeded)
//                {

//                    userManager.AddToRoleAsync(user, "admin").Wait();
//                    userManager.AddToRoleAsync(user, "user").Wait();
//                }
//            }

//        }
//        public static void SeedRoles(RoleManager<IdentityRole> roleManager, IConfiguration configuration)
//        {
//            var defaultAdmin = configuration.GetSection("DefaultAdmin");
//            //var adminRole = defaultAdmin["Name"].ToLower(System.Globalization.CultureInfo.InvariantCulture);
//            var adminRole = "admin";
//            var userRole = "user";

//            if (!roleManager.RoleExistsAsync(adminRole).Result)
//            {
//                IdentityRole role = new();
//                role.Name = adminRole;
//                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
//            }
//            if (!roleManager.RoleExistsAsync(userRole).Result)
//            {
//                IdentityRole role = new();
//                role.Name = adminRole;
//                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
//            }
//        }
//    }
//    internal class RolesList 
//    {
//        public List<string> Roles{ get; set; }
//    }
//}
