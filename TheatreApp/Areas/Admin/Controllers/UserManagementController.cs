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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserManagementIndexViewModel> users = await this.userService
                .GetAllManageableUsersAsync(this.GetUserId()!);

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleSelectionViewModel roleSelectionInputModel)
        {
            try
            {
                await this.userService.AssignToRoleAsync(roleSelectionInputModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}
