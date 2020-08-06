using Microsoft.EntityFrameworkCore;
using SimpleAuthAPI.Models.LargeModel;

namespace SimpleAuthAPI.Database
{
    public class LargeDataContext : DbContext
    {
        public LargeDataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Test>();
        }

        public DbSet<Test> Tests { get; set; }
    }
}
