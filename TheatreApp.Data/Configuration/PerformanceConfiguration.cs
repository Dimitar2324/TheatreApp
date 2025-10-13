using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheatreApp.Data.Models;
using static TheatreApp.Data.Constants.ModelConstants;

namespace TheatreApp.Data.Configuration
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.StartTime)
                .IsRequired();

            entity
                .Property(e => e.HallName)
                .IsRequired()
                .HasMaxLength(PerformanceConstants.HallNameMaxLength);

            entity
                .Property(e => e.AvailableSeats)
                .IsRequired()
                .HasDefaultValue(PerformanceConstants.AvailableSeatsCountDefaultValue);

            entity
                .Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(e => e.IsDeleted == false &&
                                        e.Play.IsDeleted == false);

            entity
                .HasIndex(p => new { p.PlayId, p.StartTime })
                .IsUnique();

            entity
                .HasOne(e => e.Play)
                .WithMany(p => p.Performances)
                .HasForeignKey(e => e.PlayId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasData(this.SeedData());
        }

        private List<Performance> SeedData()
        {
            List<Performance> performances = new List<Performance>()
            {
                new Performance()
                {
                    Id = Guid.Parse("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"),
                    PlayId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    StartTime = new DateTime(2025, 10, 15, 19, 30, 0),
                    HallName = "Main Hall",
                    AvailableSeats = 120,
                    IsDeleted = false
                }, 
                new Performance()
                {
                    Id = Guid.Parse("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"),
                    PlayId = Guid.Parse("22222222-2222-2222-2222-222222222222"), 
                    StartTime = new DateTime(2025, 11, 2, 20, 0, 0),
                    HallName = "Grand Theatre",
                    AvailableSeats = 200,
                    IsDeleted = false
                },
                new Performance()
                {
                    Id = Guid.Parse("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"),
                    PlayId = Guid.Parse("66666666-6666-6666-6666-666666666666"), 
                    StartTime = new DateTime(2025, 11, 15, 20, 0, 0),
                    HallName = "Opera Hall",
                    AvailableSeats = 250,
                    IsDeleted = false
                }
            };

            return performances;
        }
    }
}
