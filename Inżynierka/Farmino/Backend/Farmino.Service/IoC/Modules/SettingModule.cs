using Autofac;
using Farmino.Service.Settings;
using Microsoft.Extensions.Configuration;

namespace Farmino.Service.IoC.Modules
{
    public class SettingModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSection("Security"))
                .As<SecuritySettings>();
        }
    }
}
