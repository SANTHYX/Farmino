using Farmino.Service.Queries.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Commands.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
