using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class ParticipantAuctionRepository : IParticipantAuctionRepository
    {
        private readonly FarminoDbContext _context;

        public ParticipantAuctionRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ParticipantAuction participantAuction)
        {
            await _context.ParticipantAuctions.AddAsync(participantAuction);
        }

        public async Task<decimal> GetHighestPriceAsync(Guid auctionId)
            => await _context.ParticipantAuctions.Where(x => x.AuctionId == auctionId)
                .MaxAsync(z => z.ProposedPrice);

        public void Remove(ParticipantAuction participantAuction)
        {
            _context.Remove(participantAuction);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
