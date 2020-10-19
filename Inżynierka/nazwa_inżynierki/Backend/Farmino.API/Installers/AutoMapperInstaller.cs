using AutoMapper;
using Farmino.API.Installers.Interfaces;
using Farmino.Service.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farmino.API.Installers
{
    public class AutoMapperInstaller : IInstaler
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AutoMapperCfg));
        }
    }
}
