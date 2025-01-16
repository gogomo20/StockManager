using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using StockManager.Persistense.Configurations;


namespace StockManager.Persistense.Context;

public class ConnectionContext : DbContext
{
    public System.Data.Entity.DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=StockManager;Username=ge;Password=12345");
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}