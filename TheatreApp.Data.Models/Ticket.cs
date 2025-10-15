using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TheatreApp.Data.Models
{
    [Comment("Ticket in the system")]
    public class Ticket
    {
        [Comment("Ticket identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Ticket price")]
        public decimal Price { get; set; }

        [Comment("SeatNumber in the theatre")]
        public int SeatNumber { get; set; }

        [Comment("Foreign key to the performance")]
        public Guid PerformanceId { get; set; }
        public virtual Performance Performance { get; set; } = null!;

        [Comment("Foreign key to the user")]
        public Guid? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public bool IsBooked { get; set; }
    }
}
