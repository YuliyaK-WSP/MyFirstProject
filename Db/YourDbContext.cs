using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Models;
using System.Configuration;

public class YourDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Provider> Providers { get; set; }

    public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json")
       .Build();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("SqlConnect"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Определение связей между таблицами
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Provider)
            .WithMany()
            .HasForeignKey(o => o.ProviderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId);
    }
}
