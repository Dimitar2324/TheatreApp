using Microsoft.EntityFrameworkCore;

namespace TheatreApp.Data.Models
{
    [Comment("Play in the system")]
    public class Play
    {
        [Comment("Play identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Play title")]
        public string Title { get; set; } = null!;

        [Comment("Play Author")]
        public string Author { get; set; } = null!;

        [Comment("Play Description")]
        public string Description { get; set; } = null!;

        [Comment("Play Genre")]
        public string Genre { get; set; } = null!;

        [Comment("Play Director")]
        public string Director { get; set; } = null!;

        [Comment("Play ScreenWriter")]
        public string ScreenWriter { get; set; } = null!;

        [Comment("Play Duration")]
        public int Duration { get; set; }

        [Comment("Play Release Date")]
        public DateOnly ReleaseDate { get; set; }

        [Comment("Play Image URL")]
        public string? ImageUrl { get; set; }

        [Comment("Show whether the Play is deleted")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserPlay> PlayUsers { get; set; } = new HashSet<UserPlay>();
        public virtual ICollection<Performance> Performances { get; set; } = new HashSet<Performance>();
    }
}
