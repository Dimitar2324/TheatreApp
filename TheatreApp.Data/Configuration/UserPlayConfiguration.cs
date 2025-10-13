using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheatreApp.Data.Models;

namespace TheatreApp.Data.Configuration
{
    public class UserPlayConfiguration : IEntityTypeConfiguration<UserPlay>
    {
        public void Configure(EntityTypeBuilder<UserPlay> entity)
        {
            entity
                .Property(e => e.UserId)
                .IsRequired();

            entity
                .Property(e => e.PlayId)
                .IsRequired();

            entity
                .Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasKey(e => new { e.UserId, e.PlayId });

            entity
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Play)
                .WithMany(p => p.PlayUsers)
                .HasForeignKey(e => e.PlayId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(e => e.IsDeleted == false
                                      && e.Play.IsDeleted == false);
        }
    }
}
