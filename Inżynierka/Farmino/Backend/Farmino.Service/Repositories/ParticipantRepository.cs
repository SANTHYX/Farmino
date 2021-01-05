using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly FarminoDbContext _context;

        public ParticipantRepository(FarminoDbContext context)
        {
            _context = context;        }

        public async Task AddAsync(Participant participant)
        {
            await _context.Participants.AddAsync(participant);
        }

        public async Task<Participant> GetAsync(string userName)
            => await _context.Participants.Include(x => x.User)
                .Include(y => y.Auctions).FirstOrDefaultAsync(x => x.User.UserName == userName);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
