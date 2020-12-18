using Autofac;
using Farmino.Service.Repositories.Interfaces;
using System.Reflection;

namespace Farmino.Service.IoC.Modules
{
    public class RepositoryModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
