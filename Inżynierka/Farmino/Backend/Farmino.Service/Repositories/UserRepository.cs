using Farmino.Data.Models.Aggregations;
using Farmino.Service.ORM;
using Farmino.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task EditAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(string login)
            => await _context.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.Login == login);

        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
