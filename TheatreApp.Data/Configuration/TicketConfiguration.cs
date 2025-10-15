using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheatreApp.Data.Models;

namespace TheatreApp.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.UserId)
                .IsRequired(false);

            entity
                .Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            entity
                .Property(e => e.SeatNumber)
                .IsRequired();

            entity
                .HasOne(e => e.Performance)
                .WithMany(p => p.Tickets)
                .HasForeignKey(e => e.PerformanceId);

            entity
                .Property(e => e.IsBooked)
                .HasDefaultValue(false);

            entity
                .HasOne(e => e.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(e => e.UserId);

            entity
                .HasQueryFilter(e => e.Performance.IsDeleted == false);

            entity
                .HasData(this.SeedData());
        }

        private List<Ticket> SeedData()
        {
            List<Ticket> tickets = new List<Ticket>()
            {
                
                new Ticket()
                {
                    Id = Guid.Parse("f4a2b638-cc0d-4ff8-8053-5210453cecc4"),
                    PerformanceId = Guid.Parse("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"),
                    SeatNumber = 1,
                    Price = 25.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("7ca523d3-e6bb-4ea4-a97e-5a4d19c0bf99"),
                    PerformanceId = Guid.Parse("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"),
                    SeatNumber = 2,
                    Price = 25.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("cf24e7cf-e4a3-41dd-bb75-4823c5bd95a2"),
                    PerformanceId = Guid.Parse("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"),
                    SeatNumber = 3,
                    Price = 25.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("f267c41d-03db-406b-8bcc-78ad094f4411"),
                    PerformanceId = Guid.Parse("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"),
                    SeatNumber = 10,
                    Price = 30.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("e17bed71-3daf-43b0-b4d3-0b96763f50b5"),
                    PerformanceId = Guid.Parse("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"),
                    SeatNumber = 11,
                    Price = 30.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("ca435dc3-7d25-420e-bd88-3d40062e80dd"),
                    PerformanceId = Guid.Parse("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"),
                    SeatNumber = 12,
                    Price = 30.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("5d07c7a8-7724-4e46-aa87-51a02178a865"),
                    PerformanceId = Guid.Parse("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"),
                    SeatNumber = 21,
                    Price = 35.00m,
                    IsBooked = false,
                    UserId = null
                },
                new Ticket()
                {
                    Id = Guid.Parse("5d8a338d-bd09-4894-b045-641a65fd3a55"),
                    PerformanceId = Guid.Parse("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"),
                    SeatNumber = 22,
                    Price = 35.00m,
                    IsBooked = false,
                    UserId = null
                }
            };

            return tickets;
        }
    }
}
