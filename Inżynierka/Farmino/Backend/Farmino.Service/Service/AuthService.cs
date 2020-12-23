using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenManager _tokenManager;
        private readonly IEncryption _encryption;

        public AuthService(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository,
            IEncryption encryption, ITokenManager tokenManager)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenManager = tokenManager;
            _encryption = encryption;
        }

        public async Task RegisterAsync(string login, string password, string email)
        {
            if (!await _userRepository.IsUserExist(login))
            {
                var salt = _encryption.GenerateSalt(password);
                var hashedPassword = _encryption.GenerateHash(password, salt);

                await _userRepository.RegisterAsync(new User(login, hashedPassword, salt, email));
                await _userRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserAlreadyExist,
                    $"User with login {login} already exist");
        }

        public async Task<TokenDTO> Login(string login, string password)
        {
            if (await _userRepository.IsUserExist(login))
            {
                var user = await _userRepository.GetAsync(login);

                if (user.Password == _encryption.GenerateHash(password,user.Salt))
                {
                    var generatedToken = _tokenManager.GenerateToken(user);

                    await _refreshTokenRepository.AddRefreshTokenAsync(generatedToken.RefreshToken);
                    await _refreshTokenRepository.SaveChanges();

                    return new TokenDTO
                    {
                        Token = generatedToken.Token.Token,
                        Refresh = generatedToken.RefreshToken.Token,
                        GeneratedAt = generatedToken.RefreshToken.GeneratedAt
                    };
                }
                else throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                  "Invalid Credentials");
            }
            else throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                  "Invalid Credentials");
        }

        public async Task<TokenDTO> RefreshToken(string token, string refresh)
        {
            var refreshToken = await _refreshTokenRepository.GetTokenAsync(refresh);
            var user = await _userRepository.GetAsync(refreshToken.UserId);

            if (refreshToken == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.RefreshTokenDontExist,
                    "RefreshToken is empty");
            }
            if (refreshToken.IsRevoked)
            {
                throw new ServiceExceptions(ServiceErrorCodes.RefreshTokenIsRevoked,
                    "RefreshToken is revoked");
            }
            if (refreshToken.ExpiresAt > DateTime.Now)
            {
                throw new ServiceExceptions(ServiceErrorCodes.RefreshTokenIsActive,
                    "RefreshToken is still avalivable");
            }
            var generatedToken = _tokenManager.GenerateToken(user);

            refreshToken.SetRevoke(true);
            _refreshTokenRepository.EditToken(refreshToken);

            await _refreshTokenRepository.AddRefreshTokenAsync(generatedToken.RefreshToken);
            await _refreshTokenRepository.SaveChanges();

            return new TokenDTO
            {
                Token = generatedToken.Token.Token,
                Refresh = generatedToken.RefreshToken.Token,
                GeneratedAt = generatedToken.RefreshToken.GeneratedAt
            };
        }

        public async Task RevokeToken(string refresh)
        {
            var refreshToken = await _refreshTokenRepository.GetTokenAsync(refresh);

            if (refreshToken == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.RefreshTokenDontExist,
                    "RefreshToken is empty");
            }

            refreshToken.SetRevoke(true);
            _refreshTokenRepository.EditToken(refreshToken);
            await _refreshTokenRepository.SaveChanges();
        }
    }
}
