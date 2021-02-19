using Farmino.Data.Models.Aggregations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository
    {
        Task AddAsync(Offer offer);
        Task<Offer> GetAsync(Guid id);
        IQueryable<Offer> GetAllAsync();
        void RemoveAsync(Offer offer);
        void EditAsync(Offer offer);
        Task SaveChangesAsync();
    }
}
