using Farmino.Data.Models.Aggregations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IAuctionRepository : IRepository
    {
        Task AddAsync(Auction auction);
        IQueryable<Auction> GetAllAsync();
        Task<Auction> GetAsync(Guid id);
        void Remove(Auction auction);
        Task SaveChangesAsync();
    }
}
