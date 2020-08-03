using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleAuthAPI.Models;

namespace SimpleAuthAPI.Database
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PathStation>().HasKey(ps => new { ps.PathId, ps.StationId });
            builder.Entity<Busline>().HasIndex(b => b.Number).IsUnique();
            builder.Entity<Group>().HasIndex(g => g.Name).IsUnique();
            builder.Entity<Station>().HasIndex(s => s.Name).IsUnique();
            base.OnModelCreating(builder);
        }

        public DbSet<Busline> Buslines { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<PathStation> PathStations { get; set; }
    }
}
