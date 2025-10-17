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

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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
    }
}
