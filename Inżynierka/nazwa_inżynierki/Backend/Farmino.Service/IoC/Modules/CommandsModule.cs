using Autofac;
using Farmino.Service.Commands.Dispatchers;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Handlers.Interfaces;
using System.Reflection;

namespace Farmino.Service.IoC.Modules
{
    public class CommandsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandsModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
