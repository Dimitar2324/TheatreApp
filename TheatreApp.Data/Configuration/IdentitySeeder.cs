using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using TheatreApp.Data.Models;

namespace TheatreApp.Data.Configuration
{
    public static class IdentitySeeder
    {
        private static string[] defaultRoles = { "User", "Manager", "Admin" };

        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            foreach (string role in defaultRoles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    IdentityRole<Guid> newRole = new IdentityRole<Guid>()
                    {
                        Name = role
                    };

                    IdentityResult creationResult = await roleManager
                        .CreateAsync(newRole);

                    if (creationResult != IdentityResult.Success)
                    {
                        throw new Exception($"Failed to create role {role}");
                    }
                }
            }
        }

        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            UserManager<ApplicationUser> userManager = serviceProvider
              .GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, "testUser@mail.bg", "123456", "User");
            await SeedUserAsync(userManager, "testManager@mail.bg", "123456", "Manager");
            await SeedUserAsync(userManager, "testAdmin@mail.bg", "123456", "Admin");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string email, string password, string role)
        {
            ApplicationUser? user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = email,
                    Email = email
                };

                IdentityResult userCreationResult = await userManager.CreateAsync(user, password);
                if (userCreationResult != IdentityResult.Success)
                {
                    throw new Exception($"Failed to create user {email}");
                }

                bool isInRole = await userManager.IsInRoleAsync(user, role);
                if (!isInRole)
                {
                    IdentityResult roleAssigningResult = await userManager.AddToRoleAsync(user, role);
                    if (roleAssigningResult != IdentityResult.Success)
                    {
                        throw new Exception($"Failed to assign role {role} to user {email}");
                    }
                }

            }
        }
    }
}
