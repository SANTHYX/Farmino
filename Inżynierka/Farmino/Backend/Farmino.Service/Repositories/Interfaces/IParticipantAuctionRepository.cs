using Farmino.Data.Models.Entities;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories.Interfaces
{
    public interface IParticipantAuctionRepository : IRepository
    {
        Task AddAsync(ParticipantAuction participantAuction);
        void Remove(ParticipantAuction participantAuction);
        Task<decimal> GetHighestPriceAsync(Guid auctionId);
        Task SaveChangesAsync();
    }
}
