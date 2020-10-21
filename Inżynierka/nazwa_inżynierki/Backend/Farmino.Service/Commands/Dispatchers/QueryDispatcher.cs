using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Queries.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Commands.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public async Task<TResult> HandleAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var service = this._serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>)) as IQueryHandler<TQuery, TResult>;
            return await service.HandleAsync(query);
        }
    }
}
