using Farmino.Data.Models.Entities;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IParticipantRepository : IRepository
    {
        Task AddAsync(Participant participant);
        Task<Participant> GetAsync(string userName);
        Task SaveChanges();
    }
}
