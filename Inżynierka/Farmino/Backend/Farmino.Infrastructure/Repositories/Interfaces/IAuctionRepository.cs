using Farmino.Data.Models.Aggregations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IAuctionRepository : IRepository
    {
        Task AddAsync(Auction auction);
        Task<IEnumerable<Auction>> GetAllAsync();
        Task<Auction> GetAsync(Guid id);
        void Remove(Auction auction);
        Task SaveChangesAsync();
    }
}
