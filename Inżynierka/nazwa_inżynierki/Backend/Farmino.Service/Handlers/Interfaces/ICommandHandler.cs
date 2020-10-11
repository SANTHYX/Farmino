using Farmino.Service.Commands.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.Interfaces
{
    public interface ICommandHandler<T> where T:ICommand
    {
        Task HandleAsync(T command);
    }
}
