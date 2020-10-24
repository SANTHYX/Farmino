using Autofac;
using Farmino.Service.Handlers.Interfaces;
using System.Reflection;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.Dispatchers;

namespace Farmino.Service.IoC.Modules
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(QueryModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
