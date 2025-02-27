using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockManager.Repositories.JWTRepository;

namespace StockManager.Aplication
{
    public static class DependecyInjection
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly));
        }
    }
}
