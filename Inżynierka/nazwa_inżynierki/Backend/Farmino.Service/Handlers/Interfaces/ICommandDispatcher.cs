using Farmino.Service.Commands.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.Interfaces
{
    public interface ICommandDispatcher : ICommand
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
