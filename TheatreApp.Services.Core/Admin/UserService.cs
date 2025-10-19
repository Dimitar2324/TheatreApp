using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TheatreApp.Data.Models;
using TheatreApp.Services.Core.Admin.Interfaces;
using TheatreApp.Web.ViewModels.Admin.UserManagement;

namespace TheatreApp.Services.Core.Admin
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<IEnumerable<UserManagementIndexViewModel>> GetAllManageableUsersAsync(string userId)
        {
            IEnumerable<UserManagementIndexViewModel> users = await this.userManager.Users
                .Where(u => u.Id.ToString().ToLower() != userId.ToLower())
                .Select(u => new UserManagementIndexViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email!,
                    Roles = userManager.GetRolesAsync(u).GetAwaiter().GetResult()
                })
                .ToListAsync();

            return users;
        }
        public async Task<bool> AssignToRoleAsync(RoleSelectionViewModel roleInputModel)
        {
            ApplicationUser? targetUser = await this.userManager.FindByIdAsync(roleInputModel.UserId);
            if (targetUser == null)
            {
                throw new ArgumentException("Invalid error");
            }

            bool roleExists = await this.roleManager.RoleExistsAsync(roleInputModel.Role);
            if (!roleExists)
            {
                throw new ArgumentException($"Cannot assign user to role {roleInputModel.Role}");
            }

            bool result = false;
            IdentityResult assignOperationResult = await this.userManager.AddToRoleAsync(targetUser, roleInputModel.Role);

            if (assignOperationResult == IdentityResult.Success)
            {
                result = true;
            }

            return result;
        }
    }
}
