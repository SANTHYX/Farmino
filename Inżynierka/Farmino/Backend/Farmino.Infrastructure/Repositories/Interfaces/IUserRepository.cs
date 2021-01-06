using Farmino.Data.Models.Aggregations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task RegisterAsync(User user);
        void EditAsync(User user);
        Task<User> GetAsync(string userName);
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> BrowseAsync();
        Task SaveChanges();
    }
}
