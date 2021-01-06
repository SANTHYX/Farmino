using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IFarmerRepository : IRepository
    {
        Task AddAsync(Farmer farmer);
        Task<Farmer> GetAsync(string userName);
        Task SaveAsync();
    }
}
