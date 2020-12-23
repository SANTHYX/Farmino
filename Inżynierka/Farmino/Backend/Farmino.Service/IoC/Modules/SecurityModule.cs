using Autofac;
using Farmino.Service.Security.Interfaces;
using System.Reflection;

namespace Farmino.Service.IoC.Modules
{
    public class SecurityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SecurityModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IEncryption>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<ITokenManager>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
