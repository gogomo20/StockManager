
using Microsoft.Extensions.DependencyInjection;
using StockManager.Repositories.JWTRepository;

namespace StockManager.Repositories;

public static class RepositoriesInjection
{
    public static void AddRepositories(this IServiceCollection services, Iconfigura configuration)
    {
        services.Configure<JwtKey>(configuration.GetSection("JwtKeyConfiguration"));
    }
}