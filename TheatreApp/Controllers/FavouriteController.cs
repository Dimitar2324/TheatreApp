using Microsoft.AspNetCore.Mvc;

using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Favourite;

namespace TheatreApp.Web.Controllers
{
    public class FavouriteController : BaseController
    {
        private readonly IFavouriteService favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            this.favouriteService = favouriteService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = GetUserId();
                if (userId == null)
                {
                    return Forbid();
                }

                IEnumerable<FavouriteViewModel> favouritesPlays = await favouriteService
                    .GetUsersFavouritePlays(userId);

                return View(favouritesPlays);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(string? playId)
        {
            try
            {
                string? userId = GetUserId();
                if (userId == null)
                {
                    return Forbid();
                }

                bool isAdditionSuccessful = await favouriteService.AddPlayAsync(playId, userId);
                if (!isAdditionSuccessful)
                {
                    return RedirectToAction(nameof(Index), "Play");
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string? playId)
        {
            try
            {
                string? userId = GetUserId();
                if (userId == null)
                {
                    return Forbid();
                }

                bool isRemoveSuccessful = await favouriteService.RemoveFromFavouritesAsync(playId, userId);
                if (!isRemoveSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index), "Play");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
