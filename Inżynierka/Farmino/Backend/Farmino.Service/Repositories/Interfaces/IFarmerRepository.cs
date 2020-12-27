using Farmino.Data.Models.Aggregations;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IFarmerRepository : IRepository
    {
        Task AddAsync(Farmer farmer);
        Task<Farmer> GetAsync(Guid userId);
        Task SaveAsync();
    }
}
