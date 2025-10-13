using System.ComponentModel.DataAnnotations;

namespace TheatreApp.Web.ViewModels.Ticket
{
    public class BuyTicketViewModel
    {
        [Required(ErrorMessage = "PerformanceId is required")]
        public string PerformanceId { get; set; } = null!;

        [Required(ErrorMessage = "Please select a seat number.")]
        public string SeatNumber { get; set; } = null!;
        public List<int> AvailableSeats { get; set; } = new List<int>();
    }
}

