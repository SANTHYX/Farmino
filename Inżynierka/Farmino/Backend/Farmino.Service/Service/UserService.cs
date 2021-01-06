using AutoMapper;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.User;
using Farmino.Service.Extensions;
using Farmino.Service.Extensions.Models;
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

        public async Task<UserDTO> GetUserAsync(string userName)
        {
            var user = await _userRepository.GetAsync(userName);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UsersDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<UsersDTO>>(users);
        }

        public async Task EditAsync(string userName, string newUserName,
            string newPassword, string newEmail)
        {
            
                var user = await _userRepository.GetIfExistAsync(userName);
                var salt = _encryption.GenerateSalt(newPassword);
                var HashedPassword = _encryption.GenerateHash(newPassword, salt);

                user.SetUserName(newUserName);
                user.SetPassword(HashedPassword);
                user.SetEmail(newEmail);

                _userRepository.EditAsync(user);
                await _userRepository.SaveChanges();
        }

        public async Task<LoginAvalibilityDTO> IsLoginAvaliableAsync(string userName)
        {
            if (!await _userRepository.IsUserExist(userName))
            {
                return _mapper.Map<LoginAvalibility, 
                    LoginAvalibilityDTO>(LoginAvalibility.Create(true));
            }
            else return _mapper.Map<LoginAvalibility, 
                LoginAvalibilityDTO>(LoginAvalibility.Create(false));
        }
            
    }
}
