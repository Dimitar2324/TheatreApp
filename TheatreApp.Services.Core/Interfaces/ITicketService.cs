using TheatreApp.Web.ViewModels.Ticket;

namespace TheatreApp.Services.Core.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketIndexViewModel>> GetUserTicketsAsync(string? user);
        Task<bool> BuyTicketAsync(string? userId, string? performanceId, string? seatNumber);
        Task<IEnumerable<int>> GetAvailableSeatsForPerformance(string? performanceId);
    }
}
