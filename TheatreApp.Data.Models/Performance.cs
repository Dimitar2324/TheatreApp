using Microsoft.EntityFrameworkCore;

namespace TheatreApp.Data.Models
{
    [Comment("Perfomance in the system")]
    public class Performance
    {
        [Comment("Performance identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Foreign key to the Play which will be performed")]
        public Guid PlayId { get; set; }
        public virtual Play Play { get; set; } = null!;

        [Comment("Shows start time of the performance")]
        public DateTime StartTime { get; set; }

        [Comment("The name of the hall in which the performance will be done")]
        public string HallName { get; set; } = null!;

        [Comment("The count of the available seats for the performance")]
        public int AvailableSeats { get; set; }

        [Comment("Shows whether performance is deleted")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
