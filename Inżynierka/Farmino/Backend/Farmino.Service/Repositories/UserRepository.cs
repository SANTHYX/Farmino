using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FarminoDbContext _context;

        public UserRepository(FarminoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> BrowseAsync()
            => await _context.Users.Include(x=>x.Profile).ToListAsync();

        public void EditAsync(User user)
        {
            _context.Update(user);
        }

        public async Task<User> GetAsync(string userName)
            => await _context.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.Id == id);

        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
