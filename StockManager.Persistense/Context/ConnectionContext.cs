using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using StockManager.Persistense.Configurations;


namespace StockManager.Persistense.Context;

public class ConnectionContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}