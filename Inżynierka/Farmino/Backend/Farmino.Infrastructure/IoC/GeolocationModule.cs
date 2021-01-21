using Autofac;
using Farmino.Infrastructure.Geolocation.Interface;
using System.Reflection;

namespace Farmino.Infrastructure.IoC
{
    public class GeolocationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(GeolocationModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IGeolocation>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
