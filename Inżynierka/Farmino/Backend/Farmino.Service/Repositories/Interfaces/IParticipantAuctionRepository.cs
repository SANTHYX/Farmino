using Farmino.Data.Models.Entities;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IParticipantAuctionRepository : IRepository
    {
        Task AddAsync(ParticipantAuction participantAuction);
        void Remove(ParticipantAuction participantAuction);
        Task SaveChangesAsync();
    }
}
