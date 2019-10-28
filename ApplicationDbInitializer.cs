using Microsoft.AspNetCore.Identity;
using ReadyTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyTask
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ReadyTaskUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@test.com").Result == null)
            {
                ReadyTaskUser user = new ReadyTaskUser
                {
                    FirstName = "Admin",
                    LastName = "",
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
