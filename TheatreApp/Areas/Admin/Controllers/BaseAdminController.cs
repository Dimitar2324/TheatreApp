using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TheatreApp.Utils.Constants;

namespace TheatreApp.Web.Areas.Admin.Controllers
{
    [Area(GlobalApplicationConstants.AdminAreaName)]
    [Authorize(Roles = GlobalApplicationConstants.AdminRoleName)]
    public abstract class BaseAdminController : Controller
    {
        private bool IsUserAuthenticated()
        {
            bool result = false;
            if (User.Identity != null)
            {
                result = User.Identity.IsAuthenticated;
            }

            return result;
        }

        protected string? GetUserId()
        {
            string? userId = null;
            if (IsUserAuthenticated())
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return userId;
        }
    }
}
