using Farmino.Data.Models.Aggregations;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IAuctionerRepository : IRepository
    {
        Task AddAsync(Auctioner auctioner);
        Task<Auctioner> GetAsync(string userName);
        Task SaveChangesAsync();
    }
}
