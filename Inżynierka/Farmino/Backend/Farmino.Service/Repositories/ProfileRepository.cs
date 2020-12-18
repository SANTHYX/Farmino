using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly FarminoDbContext _context;

        public ProfileRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task EditProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> GetAsync(Guid id)
            => await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);

        public async Task SetProfile(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();
        }
    }
}
