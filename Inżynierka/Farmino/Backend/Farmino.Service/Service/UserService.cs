using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.Exceptions;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly FarminoDbContext _context;

        public UserService(IMapper mapper, FarminoDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UserDTO> GetUserAsync(string login)
        {
            var user = await _context.Users.Include(x => x.PersonalData)
                .FirstOrDefaultAsync(x => x.Login == login);
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.Include(x=>x.PersonalData)
                .ToListAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task RegisterAsync(string login, string password, string email)
        {
            if (!_context.Users.Where(x => x.Login == login).Any())
            {
                _context.Add(new User(login, password, email));
                await _context.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserAlreadyExist,
                    $"User with login {login} already exist");
        }

        public async Task EditAsync(string login,string newLogin, 
            string newPassword, string newEmail)
        {
            if (!_context.Users.Where(x => x.Login == newLogin).Any())
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == login);

                user.SetLogin(newLogin);
                user.SetPassword(newPassword);
                user.SetEmail(newEmail);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.LoginAlreadyTaken,
                    "This login is already taken");
        }
    }
}
