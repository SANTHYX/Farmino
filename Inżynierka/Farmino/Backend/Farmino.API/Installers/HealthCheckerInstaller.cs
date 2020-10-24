using Farmino.API.Installers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farmino.API.Installers
{
    public class HealthCheckerInstaller : IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
        }
    }
}
