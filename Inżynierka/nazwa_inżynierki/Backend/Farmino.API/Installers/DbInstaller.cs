using Farmino.API.Installers.Interfaces;
using Farmino.Service.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farmino.API.Installers
{
    public class DbInstaller : IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FarminoDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Farmino.Service")));
        }
    }
}
