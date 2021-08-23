using dots_server_v2.Models;
using Microsoft.EntityFrameworkCore;

namespace dots_server_v2.Data
{
    public class DotsContext : DbContext
    {
        public DotsContext(DbContextOptions<DotsContext> options) : base(options) { }

        public DbSet<DotsUser> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<App> Apps { get; set; }
        public DbSet<AppPackage> AppPackages { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppPackage>()
                .HasKey(ap => new { ap.AppId, ap.PackageId });
            base.OnModelCreating(modelBuilder);
        }
    }
}