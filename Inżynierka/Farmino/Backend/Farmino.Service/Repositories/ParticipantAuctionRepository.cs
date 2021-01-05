using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
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
