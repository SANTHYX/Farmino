using Farmino.Data.Models.Aggregations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task RegisterAsync(User user);
        Task EditAsync(User user);
        Task<User> GetAsync(string login);
        Task<IEnumerable<User>> BrowseAsync();
    }
}
