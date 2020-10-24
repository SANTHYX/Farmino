using System.Threading.Tasks;

namespace Farmino.Service.Handlers.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
    {
        public Task<TResult> HandleAsync(TQuery query);
    }
}
