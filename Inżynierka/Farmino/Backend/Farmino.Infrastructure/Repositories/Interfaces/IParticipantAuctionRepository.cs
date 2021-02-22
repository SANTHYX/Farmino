using Farmino.Data.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories.Interfaces
{
    public interface IParticipantAuctionRepository : IRepository
    {
        Task AddAsync(ParticipantAuction participantAuction);
        void Remove(ParticipantAuction participantAuction);
        Task<decimal> GetHighestPriceAsync(Guid auctionId);
        IQueryable<ParticipantAuction> GetAll();
        Task SaveChangesAsync();
    }
}
