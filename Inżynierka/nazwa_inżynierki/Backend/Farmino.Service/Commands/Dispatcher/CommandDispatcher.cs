using Autofac;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Handlers.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Commands.Dispatcher
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command: '{typeof(T).Name}' cannot be null");
            }

            var handler = _componentContext.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
