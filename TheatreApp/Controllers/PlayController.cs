using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheatreApp.Services.Core.Interfaces;
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
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlayInputFormModel inputPlayModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(inputPlayModel);
            }

            try
            {
                await playService.AddPlayAsync(inputPlayModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
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

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            try
            {
                PlayDeleteInformationViewModel? playToBeDeleted = await playService
                    .GetPlayDeleteInformationViewAsync(id);

                if (playToBeDeleted == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(playToBeDeleted);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PlayDeleteInformationViewModel playModel)
        {
            try
            {
                bool isDeleteOperationSuccessful = await playService.SoftDeletePlayAsync(playModel.Id);
                if (!isDeleteOperationSuccessful)
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
