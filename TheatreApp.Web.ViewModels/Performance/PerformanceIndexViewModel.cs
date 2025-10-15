namespace TheatreApp.Web.ViewModels.Performance
{
    public class PerformanceIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string HallName { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public int AvailableTicketsCount { get; set; }
        public string PlayId { get; set; } = null!;
        public string PlayTitle { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
