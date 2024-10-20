using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Infrastructure.Persistence;

internal class SazanowineDbContext(DbContextOptions<SazanowineDbContext> options) : IdentityDbContext(options)
{
    internal DbSet<Wine> Wines { get; set; }
    internal DbSet<Order> Orders { get; set; }
    internal DbSet<OrderItem> OrderWines { get; set; }
    internal DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Wine)
            .WithMany()
            .HasForeignKey(oi => oi.WineId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Wine>()
            .Property(w => w.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrderItem>()
            .Property(ow => ow.PriceAtOrder)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Room>()
            .OwnsOne(r => r.Description);

        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasMaxLength(255); 

        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .HasMaxLength(255);
    }
}
