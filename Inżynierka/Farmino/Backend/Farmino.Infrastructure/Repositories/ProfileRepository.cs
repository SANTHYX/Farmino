﻿using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ORM;
using Farmino.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Farmino.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly FarminoDbContext _context;

        public ProfileRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public void EditProfile(Profile profile)
        {
            _context.Profiles.Update(profile);
        }

        public async Task<Profile> GetByUserIdAsync(Guid id)
            => await _context.Profiles.FirstOrDefaultAsync(x => x.User.Id == id);

        public async Task CreateProfile(Profile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
