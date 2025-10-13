using Microsoft.AspNetCore.Mvc;

using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Ticket;

namespace TheatreApp.Web.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = this.GetUserId();
            IEnumerable<TicketIndexViewModel> allUserTickets = await this.ticketService
                                 .GetUserTicketsAsync(userId);

            return View(allUserTickets);
        }

        [HttpGet]
        public async Task<IActionResult> Buy(string? performanceId)
        {
            if (string.IsNullOrWhiteSpace(performanceId))
            {
                return RedirectToAction("Index", "Performance");
            }

            var availableSeats = await this.ticketService.GetAvailableSeatsForPerformance(performanceId);

            var model = new BuyTicketViewModel()
            {
                PerformanceId = performanceId,
                AvailableSeats = availableSeats.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(BuyTicketViewModel buyForm)
        {
            if (!ModelState.IsValid)
            {
                return View("Buy", buyForm);
            }

            var userId = this.GetUserId();
            bool result = await ticketService.BuyTicketAsync(userId, buyForm.PerformanceId, buyForm.SeatNumber);

            if (result)
            {
                return RedirectToAction(nameof(Index), "Ticket");
            }

            return View(buyForm);
        }
    }
}
