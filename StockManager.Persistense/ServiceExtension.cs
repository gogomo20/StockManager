using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManager.Persistense.Context;

namespace StockManager.Persistense;

public static class ServiceExtension
{
    public static void ConfigureConnectionContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ConnectionContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }
}