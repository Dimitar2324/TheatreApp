using TheatreApp.Data.Repository.Interfaces;
using TheatreApp.Services.Core.Interfaces;
using TheatreApp.Web.ViewModels.Ticket;

using TheatreApp.Utils.Constants;
using Microsoft.EntityFrameworkCore;
using TheatreApp.Data.Models;

namespace TheatreApp.Services.Core
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        private readonly IPerformanceRepository performanceRepository;

        public TicketService(ITicketRepository ticketRepository, IPerformanceRepository performanceRepository)
        {
            this.ticketRepository = ticketRepository;
            this.performanceRepository = performanceRepository;
        }

        public async Task<IEnumerable<TicketIndexViewModel>> GetUserTicketsAsync(string? userId)
        {
            IEnumerable<TicketIndexViewModel> tickets = new List<TicketIndexViewModel>();
            
            if (!string.IsNullOrWhiteSpace(userId))
            {
                tickets = await this.ticketRepository
                    .All()
                    .Include(t => t.Performance)
                    .ThenInclude(p => p.Play)
                    .Where(t => t.UserId != null && t.UserId.ToLower() == userId.ToLower())
                    .Select(t => new TicketIndexViewModel()
                    {
                        PlayTitle = t.Performance.Play.Title,
                        ImageUrl = t.Performance.Play.ImageUrl ?? GlobalApplicationConstants.NotExistingImageUrl,
                        SeatNumber = t.SeatNumber,
                        Price = t.Price.ToString("F2"),
                        StartTime = t.Performance.StartTime.ToString(GlobalApplicationConstants.PerformanceStartTimeFormat)
                    })
                    .ToListAsync();
            }

            return tickets;
        }

        public async Task<bool> BuyTicketAsync(string? userId, string? performanceId, string? seatNumber)
        {
            bool result = false;
            if (!string.IsNullOrWhiteSpace(performanceId) 
                && !string.IsNullOrWhiteSpace(userId)
                && !string.IsNullOrWhiteSpace(seatNumber)
                )
            {
                Performance? targetPerformance = await this.performanceRepository
                             .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == performanceId.ToLower());

                if (targetPerformance != null && targetPerformance.AvailableSeats > 0)
                {
                    int seat = int.Parse(seatNumber);
                    Ticket? ticket = await this.ticketRepository
                        .FirstOrDefaultAsync(t => t.PerformanceId == targetPerformance.Id
                                                && t.SeatNumber == seat);

                    if (ticket != null && !ticket.IsBooked)
                    {
                        ticket.UserId = userId;
                        ticket.IsBooked = true;
                        result = await this.ticketRepository.UpdateAsync(ticket);

                        targetPerformance.AvailableSeats--;
                        result = await this.performanceRepository.UpdateAsync(targetPerformance);
                    }
                }
            }

            return result;
        }

        public async Task<IEnumerable<int>> GetAvailableSeatsForPerformance(string? performanceId)
        {
            IEnumerable<int> availableSeats = new List<int>();

            if (!string.IsNullOrWhiteSpace(performanceId))
            {
                var performance = await this.performanceRepository
                    .FirstOrDefaultAsync(p => p.Id.ToString().ToLower() == performanceId.ToLower());

                if (performance != null)
                {
                    availableSeats = await this.ticketRepository
                                   .All()
                                   .Where(t => t.PerformanceId == performance.Id && !t.IsBooked)
                                   .Select(t => t.SeatNumber)
                                   .OrderBy(e => e)
                                   .ToListAsync();
                }
            }

            return availableSeats;
        }
    }
}
