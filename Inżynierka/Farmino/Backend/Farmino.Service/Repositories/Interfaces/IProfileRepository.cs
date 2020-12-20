using Farmino.Data.Models.Entities;
using Farmino.Data.Models.Value_Objects;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IProfileRepository : IRepository
    {
        Task<Profile> GetAsync(Guid id);
        Task CreateProfile(Profile profile);
        Task EditProfile(Profile profile);
    }
}
