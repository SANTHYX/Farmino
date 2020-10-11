using AutoMapper;
using Farmino.Data.Models;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.ORM;
using Farmino.Service.Service.Interfaces;
using Farmino.Service.Service.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        private readonly FarminoDbContext _context;
        private readonly IMapper _mapper;

        public UserService(FarminoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDTO>> EditUserAsync(string firstName, string lastName,
            string login, string password, string email)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Account.Login == login);

                user.SetFirstName(firstName);
                user.SetLastName(lastName);
                user.Account.SetLogin(login);
                user.Account.SetPassword(password);
                user.Account.SetEmail(email);
                _context.Update(user);

                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = "User has been updated!";
            }
            catch (Exception error)
            {
                serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
                serviceResponse.Message = error.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<IEnumerable<UserDTO>>> GetAllUsersAsync()
        {
            ServiceResponse<IEnumerable<UserDTO>> serviceResponse = new ServiceResponse<IEnumerable<UserDTO>>();

            var usersList = await _context.Users.ToListAsync();

            serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
            serviceResponse.Data = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(usersList);
            return serviceResponse;
        }
        public async Task<ServiceResponse<UserDTO>> GetUserAsync(string login)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Account.Login == login);

            serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
            serviceResponse.Data = _mapper.Map<User, UserDTO>(user);
            return serviceResponse;
        }
        public async Task<ServiceResponse<UserDTO>> RegisterUserAsync(string firstName, string lastName, 
            string login, string password, string email/*,int role*/)
        {
            ServiceResponse<UserDTO> serviceResponse = new ServiceResponse<UserDTO>();

             var user = new User(firstName, lastName, Account.Create(login, password, email, "salty") /*,role*/);
             _context.Users.Add(user);
             await _context.SaveChangesAsync();

             serviceResponse.IsSuccess = new HttpResponseMessage().IsSuccessStatusCode;
             serviceResponse.Message = "User has been created";
             return serviceResponse;
        }
    }
}
