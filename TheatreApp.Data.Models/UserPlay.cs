using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TheatreApp.Data.Models
{
    [Comment("User's favourites entry in the system")]
    public class UserPlay
    {
        [Comment("Foreign key to the user")]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        [Comment("Foreign key to the play")]
        public Guid PlayId { get; set; }
        public virtual Play Play { get; set; } = null!;

        [Comment("Shows whether UserPlay entry is deleted")]
        public bool IsDeleted { get; set; }
    }
}
