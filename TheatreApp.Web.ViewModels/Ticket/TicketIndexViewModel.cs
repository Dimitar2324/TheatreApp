namespace TheatreApp.Web.ViewModels.Ticket
{
    public class TicketIndexViewModel
    {
        public string PlayTitle { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int SeatNumber { get; set; }
        public string Price { get; set; } = null!;
        public string StartTime { get; set; } = null!;
    }
}
