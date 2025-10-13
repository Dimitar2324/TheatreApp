using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheatreApp.Data.Models;
using static TheatreApp.Data.Constants.ModelConstants;

namespace TheatreApp.Data.Configuration
{
    public class PlayConfiguration : IEntityTypeConfiguration<Play>
    {
        public void Configure(EntityTypeBuilder<Play> entity)
        {
            entity
                .HasKey(x => x.Id);

            entity
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(PlayConstants.TitleMaxLength);

            entity
                .Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(PlayConstants.AuthorNameMaxLength);

            entity
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(PlayConstants.DescriptionMaxLength);

            entity
                .Property(e => e.Genre)
                .IsRequired()
                .HasMaxLength(PlayConstants.GenreNameMaxLength);

            entity
                .Property(e => e.Director)
                .IsRequired()
                .HasMaxLength(PlayConstants.DirectorNameMaxLength);

            entity
                .Property(e => e.ScreenWriter)
                .IsRequired()
                .HasMaxLength(PlayConstants.ScreenWriterNameMaxLength);

            entity
                .Property(e => e.Duration)
                .IsRequired();

            entity
                .Property(e => e.ReleaseDate)
                .IsRequired();

            entity
                .Property(e => e.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(PlayConstants.ImageUrlMaxLength);

            entity
                .Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted == false);

            entity
                .HasData(this.SeedData());
        }

        private List<Play> SeedData()
        {
            return new List<Play>()
    {
        new Play
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Title = "Hamlet",
            Author = "William Shakespeare",
            Description = "A tragedy exploring revenge, betrayal, and madness as Prince Hamlet seeks justice for his father's murder.",
            Genre = "Tragedy",
            Director = "Laurence Olivier",
            ScreenWriter = "Tom Stoppard",
            Duration = 160,
            ReleaseDate = new DateOnly(1601, 1, 1),
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/df/Hamlet.jpg",
            IsDeleted = false
        },
        new Play
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Title = "Les Miserables",
            Author = "Victor Hugo",
            Description = "A musical adaptation of Hugo's novel, portraying love, justice, and redemption during revolutionary France.",
            Genre = "Musical",
            Director = "Cameron Mackintosh",
            ScreenWriter = "Claude-Michel Schönberg",
            Duration = 180,
            ReleaseDate = new DateOnly(1980, 9, 24),
            ImageUrl = "https://media.londontheatredirect.com/Event/LesMiserables/event-hero-image_45974.png",
            IsDeleted = false
        },
        new Play
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Title = "A Doll's House",
            Author = "Henrik Ibsen",
            Description = "A groundbreaking play exploring gender roles and individual freedom in 19th-century society.",
            Genre = "Drama",
            Director = "Joseph Losey",
            ScreenWriter = "Christopher Hampton",
            Duration = 135,
            ReleaseDate = new DateOnly(1879, 12, 21),
            ImageUrl = "https://m.media-amazon.com/images/I/61E1XsHuy-L._UF1000,1000_QL80_.jpg",
            IsDeleted = false
        },
        new Play
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Title = "Waiting for Godot",
            Author = "Samuel Beckett",
            Description = "An absurdist play in which two men wait endlessly for someone who never arrives.",
            Genre = "Absurdist",
            Director = "Peter Hall",
            ScreenWriter = "Samuel Beckett",
            Duration = 140,
            ReleaseDate = new DateOnly(1953, 1, 5),
            ImageUrl = "https://www.hollywoodreporter.com/wp-content/uploads/2025/09/GODOT_AndyHenderson-3-H-2025.jpg?w=1296&h=730&crop=1",
            IsDeleted = false
        },
        new Play
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Title = "Death of a Salesman",
            Author = "Arthur Miller",
            Description = "A classic American tragedy about Willy Loman, a man destroyed by false dreams of success.",
            Genre = "Tragedy",
            Director = "Elia Kazan",
            ScreenWriter = "Arthur Miller",
            Duration = 150,
            ReleaseDate = new DateOnly(1949, 2, 10),
            ImageUrl = "https://mediaproxy.tvtropes.org/width/1200/https://static.tvtropes.org/pmwiki/pub/images/death_of_a_salesman_1.JPG",
            IsDeleted = false
        },
        new Play
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Title = "The Phantom of the Opera",
            Author = "Gaston Leroux",
            Description = "A haunting musical about love, obsession, and mystery beneath the Paris Opera House.",
            Genre = "Musical",
            Director = "Harold Prince",
            ScreenWriter = "Andrew Lloyd Webber",
            Duration = 175,
            ReleaseDate = new DateOnly(1986, 10, 9),
            ImageUrl = "https://assets.zyrosite.com/cdn-cgi/image/format=auto,w=375,h=501,fit=crop/YBgEp8nRLoCX8eJW/poto_s2_eventim_420_560_bg_sf-YZ92EQ6Rp5TMpRoj.jpg",
            IsDeleted = false
        },
    };
        }
    }
}
