using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IOfferRepository : IRepository
    {
        Task AddAsync(Offer offer);
        Task<Offer> GetAsync(Guid id);
        Task<IEnumerable<Offer>> GetAllAsync();
        void EditAsync(Offer offer);
        Task SaveChanges();
    }
}
