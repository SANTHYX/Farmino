using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IProfileRepository : IRepository
    {
        Task<Profile> GetByUserIdAsync(Guid id);
        Task CreateProfile(Profile profile);
        void EditProfile(Profile profile);
        Task SaveChanges();
    }
}
