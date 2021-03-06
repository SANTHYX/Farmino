using Autofac;
using Farmino.Infrastructure.IoC.Modules;

namespace Farmino.Infrastructure.IoC
{
    public class InfractructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<GeolocationModule>();
            builder.RegisterModule<ImageManagmentModule>();
        }
    }
}
