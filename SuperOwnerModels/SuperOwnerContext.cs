using Microsoft.EntityFrameworkCore;

namespace SuperOwnerModels
{
    public class SuperOwnerContext : DbContext
    {
        public SuperOwnerContext()
        {

        }
        public SuperOwnerContext(DbContextOptions<SuperOwnerContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasIndex(x => x.Permalink).IsUnique();
            modelBuilder.Entity<Building>().HasIndex(x => new { x.ProjectId, x.Permalink }).IsUnique();
        }
    }
}
