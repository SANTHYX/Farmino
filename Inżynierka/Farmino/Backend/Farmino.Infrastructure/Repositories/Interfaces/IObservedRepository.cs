using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IObservedRepository : IRepository
    {
        Task Add(Observed observed);
        Task<Observed> GetAsync(Guid userId, Guid offerId);
        void Remove(Observed observed);
        Task SaveAsync();
    }
}
