using Farmino.Data.Models.Aggregations;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository
    {
        Task AddAsync(Customer customer);
        Task SaveAsync();
    }
}
