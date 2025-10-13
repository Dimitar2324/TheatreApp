using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

using TheatreApp.Data.Models;

namespace TheatreApp.Data
{
    public class TheatreAppDbContext : IdentityDbContext
    {
        public TheatreAppDbContext(DbContextOptions<TheatreAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Play> Plays { get; set; }
        public DbSet<UserPlay> UsersPlays { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Performance> Performances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
