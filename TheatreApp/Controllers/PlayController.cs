using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Utils.Constants;
using TheatreApp.Web.ViewModels.Play;

namespace TheatreApp.Web.Controllers
{
    public class PlayController : BaseController
    {
        private readonly IPlayService playService;

        public PlayController(IPlayService playService)
        {
            this.playService = playService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllPlaysIndexViewModel> plays = await playService.GetAllPlaysAsync();
            return View(plays);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string? id)
        {
            try
            {
                PlayDetailsViewModel? playDetails = await playService
                    .GetPlayDetailsByIdAsync(id);

                if (playDetails == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(playDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{GlobalApplicationConstants.ManagerRoleName}, {GlobalApplicationConstants.AdminRoleName}")]
        public async Task<IActionResult> Edit(string? id)
        {
            try
            {
                PlayEditFormModel? editablePlay = await playService
                    .GetPlayEditableInformationAsync(id);

                if (editablePlay == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(editablePlay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Authorize(Roles = $"{GlobalApplicationConstants.ManagerRoleName}, {GlobalApplicationConstants.AdminRoleName}")]
        public async Task<IActionResult> Edit(PlayEditFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            try
            {
                bool isSuccessful = await playService.EditPlayAsync(formModel);
                if (!isSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Details), new { formModel.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
