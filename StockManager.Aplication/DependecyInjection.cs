using Microsoft.Extensions.DependencyInjection;
using StockManager.Persistense.Context;
using System.Runtime.CompilerServices;

namespace StockManager.Aplication
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependecyInjection).Assembly));
            services.AddDbContext<ConnectionContext>();
            return services;
        }
    }
}
