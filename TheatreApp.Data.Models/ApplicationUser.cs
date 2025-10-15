using Microsoft.AspNetCore.Identity;

namespace TheatreApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual ICollection<UserPlay> UserFavourites { get; set; } = new HashSet<UserPlay>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
