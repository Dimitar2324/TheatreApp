using Microsoft.AspNetCore.Mvc;
using TheatreApp.Services.Core.Interfaces;

namespace TheatreApp.Web.Controllers
{
    public class PerformanceController : BaseController
    {
        private readonly IPerformanceService performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            this.performanceService = performanceService;
        }

        public async Task<IActionResult> Index()
        {
            var performances = await this.performanceService
                                .GetAllPerformancesAsync();

            return View(performances);
        }
    }
}
