using Microsoft.EntityFrameworkCore;
using ShedAndFed.Entities;

namespace ShedAndFed.Data;

public class ReptileDbContext : DbContext
{
    public ReptileDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Reptile> Reptiles { get; set; }
    public DbSet<FeedingLog> FeedingLogs { get; set; }
    public DbSet<ShedLog> ShedLogs { get; set; }
    public DbSet<WasteLog> WasteLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reptile>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity
                .HasMany(r => r.Feedings)
                .WithOne(f => f.Reptile)
                .HasForeignKey(f => f.ReptileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(r => r.Sheds)
                .WithOne(s => s.Reptile)
                .HasForeignKey(s => s.ReptileId)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasMany(r => r.Wastes)
                .WithOne(w => w.Reptile)
                .HasForeignKey(w => w.ReptileId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
