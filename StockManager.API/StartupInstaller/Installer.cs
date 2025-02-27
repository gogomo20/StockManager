namespace StockManager.StartupInstaller;

public interface Installer
{
    /// <summary>
    /// Install services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}