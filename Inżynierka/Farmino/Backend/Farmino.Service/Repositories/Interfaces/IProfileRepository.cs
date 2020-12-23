using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IProfileRepository : IRepository
    {
        Task<Profile> GetAsync(Guid id);
        Task CreateProfile(Profile profile);
        void EditProfile(Profile profile);
        Task SaveChanges();
    }
}
