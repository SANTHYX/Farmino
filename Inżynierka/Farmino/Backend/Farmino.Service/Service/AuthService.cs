﻿using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Token;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
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

        public async Task RegisterAsync(string userName, string password, string email)
        {
            if (!await _userRepository.IsUserExistAsync(userName))
            {
                var salt = _encryption.GenerateSalt(password);
                var hashedPassword = _encryption.GenerateHash(password, salt);

                await _userRepository.RegisterAsync(new User(userName, hashedPassword, salt, email));
                await _userRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.UserAlreadyExist,
                    $"User with login {userName} already exist");
        }

        public async Task<TokenDTO> Login(string userName, string password)
        {
            var user = await _userRepository.GetForAuthAsync(userName);

            if (user.Password != _encryption.GenerateHash(password,user.Salt))
            {
                throw new ServiceExceptions(ServiceErrorCodes.InvalidCredentials,
                    "Invalid Credentials");
            }
            var generatedToken = _tokenManager.GenerateToken(user);

            await _refreshTokenRepository.AddRefreshTokenAsync(generatedToken.RefreshToken);
            await _refreshTokenRepository.SaveChanges();

            return new TokenDTO
            {
                Token = generatedToken.Token.Token,
                Refresh = generatedToken.RefreshToken.Token,
                ExpiresAt = generatedToken.RefreshToken.ExpiresAt
            };
        }

        public async Task<TokenDTO> RefreshToken(string refresh)
        {
            var refreshToken = await _refreshTokenRepository.GetIfExistAsync(refresh);

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
            var user = await _userRepository.GetAsync(refreshToken.UserId);
            var generatedToken = _tokenManager.GenerateToken(user);

            refreshToken.SetRevoke(true);
            _refreshTokenRepository.EditToken(refreshToken);

            await _refreshTokenRepository.AddRefreshTokenAsync(generatedToken.RefreshToken);
            await _refreshTokenRepository.SaveChanges();

            return new TokenDTO
            {
                Token = generatedToken.Token.Token,
                Refresh = generatedToken.RefreshToken.Token,
                ExpiresAt = generatedToken.RefreshToken.GeneratedAt
            };
        }

        public async Task RevokeToken(string refresh)
        {
            var refreshToken = await _refreshTokenRepository.GetIfExistAsync(refresh);

            refreshToken.SetRevoke(true);
            _refreshTokenRepository.EditToken(refreshToken);

            await _refreshTokenRepository.SaveChanges();
        }
    }
}
