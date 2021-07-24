namespace PlovdivEventManager.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PlovdivEventManager.Data.Models;

    public class PlovdivEventManagerDbContext : IdentityDbContext
    {
        public PlovdivEventManagerDbContext(DbContextOptions<PlovdivEventManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; init; }
        public DbSet<Category> Categories { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Event>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
