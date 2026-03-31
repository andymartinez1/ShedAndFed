using Microsoft.EntityFrameworkCore;
using ShedAndFed.Entities;

namespace ShedAndFed.Data;

public class ReptileDbContext : DbContext
{
    public ReptileDbContext(DbContextOptions<ReptileDbContext> options)
        : base(options)
    {
    }

    public DbSet<Reptile> Reptiles { get; set; }
    public DbSet<FeedingLog> FeedingLogs { get; set; }
    public DbSet<ShedLog> ShedLogs { get; set; }
    public DbSet<WasteLog> WasteLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Key explicitly specified because of the abstract ReptileLogBase entity
        modelBuilder.Entity<FeedingLog>().HasKey(f => f.LogId);
        modelBuilder.Entity<ShedLog>().HasKey(s => s.LogId);
        modelBuilder.Entity<WasteLog>().HasKey(w => w.LogId);

        modelBuilder.Entity<Reptile>(entity =>
        {
            entity.HasKey(r => r.ReptileId);

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