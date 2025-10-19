using Microsoft.AspNetCore.Mvc;
using TheatreApp.Services.Core.Admin.Interfaces;
using TheatreApp.Web.ViewModels.Admin.PlayManagement;

namespace TheatreApp.Web.Areas.Admin.Controllers
{
    public class PlayManagementController : BaseAdminController
    {
        private readonly IPlayManagementService playManagementService;

        public PlayManagementController(IPlayManagementService playManagementService)
        {
            this.playManagementService = playManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            IEnumerable<PlayManagementIndexViewModel> allPlays = await this.playManagementService
                .GetPlaysDashBoardInformationAsync();

            return View(allPlays);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlayInputFormModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            try
            {
                await this.playManagementService.AddPlayAsync(inputModel);

                return this.RedirectToAction(nameof(Manage));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return this.RedirectToAction(nameof(Manage));
            }
        }

        [HttpGet]
        public async Task<IActionResult> ToggleDelete(string? id)
        {
            Tuple<bool, bool> operationResult = await this.playManagementService
                .DeleteOrRestoreMovieAsync(id);

            bool success = operationResult.Item1;
            bool isRestored = operationResult.Item2;

            if (!success)
            {
                Console.WriteLine("Play could not be found or updated!");
            }
            else
            {
                string operation = isRestored ? "restored" : "deleted";
            }

            return this.RedirectToAction(nameof(Manage));
        }
    }
}
