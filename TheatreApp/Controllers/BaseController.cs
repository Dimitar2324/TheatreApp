using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;

namespace TheatreApp.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        protected bool IsUserAuthenticated()
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
