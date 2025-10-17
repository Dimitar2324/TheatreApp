using Microsoft.AspNetCore.Mvc;
using TheatreApp.Services.Core.Admin.Interfaces;
using TheatreApp.Web.ViewModels.Admin.UserManagement;

namespace TheatreApp.Web.Areas.Admin.Controllers
{
    public class UserManagementController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserManagementIndexViewModel> users = await this.userService
                .GetAllManageableUsersAsync(this.GetUserId()!);

            return View(users);
        }
    }
}
