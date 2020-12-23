using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Extensions.Models;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEncryption _encryption;

        public UserService(IMapper mapper, IUserRepository userRepository,
            IEncryption encryption)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _encryption = encryption;
        }

        public async Task<UserDTO> GetUserAsync(string login)
        {
            var user = await _userRepository.GetAsync(login);
            return _mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task EditAsync(string login, string newLogin,
            string newPassword, string newEmail)
        {
            if (!await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);
                var salt = _encryption.GenerateSalt(newPassword);
                var newHashedPassword = _encryption.GenerateHash(newPassword, salt);

                user.SetLogin(newLogin);
                user.SetPassword(newHashedPassword);
                user.SetEmail(newEmail);

                _userRepository.EditAsync(user);
                await _userRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.LoginAlreadyTaken,
                    "This login is already taken");
        }

        public async Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string login)
        {
            if (!await _userRepository.IsUserExist(login))
            {
                return _mapper.Map<LoginAvalibility, 
                    LoginAvalibilityDTO>(LoginAvalibility.Create(true));
            }
            else return _mapper.Map<LoginAvalibility, 
                LoginAvalibilityDTO>(LoginAvalibility.Create(false));
        }
            
    }
}
