using Microsoft.AspNetCore.Identity;

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
        public DbSet<Organizer> Organizers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Event>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Event>()
                .HasOne(o => o.Organizer)
                .WithMany(e => e.Events)
                .HasForeignKey(o => o.OrganizerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Organizer>()
                .HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<Organizer>(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
