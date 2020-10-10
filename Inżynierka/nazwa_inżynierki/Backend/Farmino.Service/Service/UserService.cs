using AutoMapper;
using Farmino.Data.Models;
using Farmino.Service.DTO;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Farmino.Service.Service.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        public readonly FarminoDbContext _context;
        public readonly IMapper _mapper;

        public UserService(FarminoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDTO>> EditUserAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<UserDTO>>> GetAllUsersAsync()
        {
            ServiceResponse<IEnumerable<UserDTO>> serviceResponse = new ServiceResponse<IEnumerable<UserDTO>>();

            var usersList = await _context.Users.ToListAsync();

            serviceResponse.Data = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(usersList);
            return serviceResponse;
        }
        public async Task<ServiceResponse<UserDTO>> GetUserAsync(string login)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Account.Login == login);

            serviceResponse.Data = _mapper.Map<User, UserDTO>(user);
            return serviceResponse;
        }
        public async Task<ServiceResponse<UserDTO>> RegisterUserAsync(string firstName, string lastName, 
            string login, string password, string email, int role)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();
            try
            {
                var user = new User(firstName, lastName, login, password, email, role);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
