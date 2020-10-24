using Farmino.API.Installers.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Farmino.API.Installers
{
    public static class MainInstaller
    {
        public static void InstallServiceConfiguration(IServiceCollection services, IConfiguration Configuration)
        {
            var installer = typeof(Startup).Assembly.ExportedTypes.Where(x =>
              typeof(IInstaler).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
              .Select(Activator.CreateInstance).Cast<IInstaler>().ToList();

            installer.ForEach(installer => installer.InstallServices(services, Configuration));
        }
    }
}
