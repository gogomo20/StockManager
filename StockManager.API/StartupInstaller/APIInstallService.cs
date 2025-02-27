using StockManager.Aplication;
using StockManager.Persistense;
using StockManager.Repositories;

namespace StockManager.StartupInstaller;

public class APIInstallService : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAplication();
        services.ConfigureConnectionContext(configuration);
        services.AddRepositories(configuration);
    }
}