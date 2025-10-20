using TheatreApp.Web.ViewModels.Admin.UserManagement;

namespace TheatreApp.Services.Core.Admin.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserManagementIndexViewModel>> GetAllManageableUsersAsync(string userId);

        Task<bool> AssignToRoleAsync(RoleSelectionViewModel roleSelectionInputModel);
        Task<bool> RemoveRoleAsync(RoleSelectionViewModel roleSelectionViewModel);
        Task<bool> DeleteUserAsync(string userId);
    }
}
