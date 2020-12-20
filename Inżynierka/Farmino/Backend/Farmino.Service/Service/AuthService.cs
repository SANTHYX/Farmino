using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryption _encryption;
        private readonly ITokenHandler _token;

        public AuthService(IUserRepository userRepository, IEncryption encryption,
            ITokenHandler token)
        {
            _userRepository = userRepository;
            _encryption = encryption;
            _token = token;
        }

        public async Task Login(string login, string password)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);

                if (user.Password == _encryption.GenerateHash(password,user.Salt))
                {
                    return;
                }
                else throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                  "Invalid Credentials");
            }
            else throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                  "Invalid Credentials");
        }
    }
}
