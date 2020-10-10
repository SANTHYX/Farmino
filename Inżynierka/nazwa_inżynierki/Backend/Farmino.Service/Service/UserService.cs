using Farmino.Service.DTO;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Farmino.Service.Service.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        public readonly FarminoDbContext _context;

        public UserService(FarminoDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<UserDTO>> EditUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<IEnumerable<UserDTO>>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<UserDTO>> GetUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<UserDTO>> RegisterUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}
