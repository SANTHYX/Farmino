using Farmino.Data.Exceptions;
using System;

namespace Farmino.Data.Models.Aggregations
{
    public class RefreshToken
    {
        public Guid Id { get; protected set; }
        public string Token { get; protected set; }
        public bool IsRevoked { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public DateTime GeneratedAt { get; protected set; }
        public DateTime ExpiresAt { get; protected set; }

        protected RefreshToken() { }

        public RefreshToken(Guid id,string token, User user, double expirationTime)
        {
            Id = id;
            SetRefreshToken(token);
            SetUser(user);
            SetRevoke(false);
            GeneratedAt = DateTime.Now;
            ExpiresAt = DateTime.Now.AddMinutes(expirationTime);
        }

        public void SetRevoke(bool value)
        {
            if (IsRevoked == value)
            {
                return;
            }

            IsRevoked = value;
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public void SetRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new DataExceptions(DataErrorCodes.InvalidToken, 
                    "Token cannot be empty");
            }
            if(Token == token)
            {
                return;
            }

            Token = token;
        }
    }
}
