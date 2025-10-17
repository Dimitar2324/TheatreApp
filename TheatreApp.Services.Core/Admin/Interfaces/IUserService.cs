using TheatreApp.Web.ViewModels.Admin.UserManagement;

namespace TheatreApp.Services.Core.Admin.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserManagementIndexViewModel>> GetAllManageableUsersAsync(string userId);
    }
}
