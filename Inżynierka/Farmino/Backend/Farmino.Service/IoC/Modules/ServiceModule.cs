using Autofac;
using Farmino.Service.Service.Interfaces;
using System.Reflection;

namespace Farmino.Service.IoC.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
