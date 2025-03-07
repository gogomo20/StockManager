using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManager.Persistense.Context;
using StockManager.Repositories;


namespace StockManager.Persistense;

public static class ServiceExtension
{
    public static void ConfigureConnectionContext(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ConnectionContext>(options =>
            options.UseNpgsql(conn));
        services.AddScoped<IUnitOfWork>(provider =>
        {
            var dbContext = provider.GetRequiredService<ConnectionContext>();
            return new UnitOfWork<ConnectionContext>(dbContext);
        });
        services.AddHttpContextAccessor();
        // services.AddUnitOfWork<ConnectionContext>();
    }
}