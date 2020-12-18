using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Extensions.Models;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDTO> GetUserAsync(string login)
        {
            var user = await _repository.GetAsync(login);
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repository.BrowseAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task RegisterAsync(string login, string password, string email)
        {
            if (!await _repository.IsUserExist(login))
            {
                await _repository.RegisterAsync(new User(login, password, email));
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserAlreadyExist,
                    $"User with login {login} already exist");
        }

        public async Task EditAsync(string login, string newLogin,
            string newPassword, string newEmail)
        {
            if (!await _repository.IsUserExist(login))
            {
                var user = await _repository.GetAsync(login);
                user.SetLogin(newLogin);
                user.SetPassword(newPassword);
                user.SetEmail(newEmail);
                await _repository.EditAsync(user);
            }
            else throw new ServiceExceptions(ServiceErrorCodes.LoginAlreadyTaken,
                    "This login is already taken");
        }

        public async Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string login)
        {
            if (await _repository.IsUserExist(login))
            {
                return _mapper.Map<LoginAvalibility, LoginAvalibilityDTO>(LoginAvalibility.Create(true));
            }
            else
            {
                return _mapper.Map<LoginAvalibility, LoginAvalibilityDTO>(LoginAvalibility.Create(false));
            }
        }
            
    }
}
