using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farmino.API.Installers.Interfaces
{
    public interface IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
