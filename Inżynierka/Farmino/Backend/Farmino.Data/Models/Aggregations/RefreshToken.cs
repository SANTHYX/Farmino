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
            SetRevoke(false);
            User = user;
            GeneratedAt = DateTime.Now;
            ExpiresAt = DateTime.Now.AddMinutes(expirationTime);
        }

        public void SetRevoke(bool value)
        {
            IsRevoked = value;
        }

        public void SetRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new DataExceptions(DataErrorCodes.InvalidToken, 
                    "Token cannot be empty");
            }

            Token = token;
        }
    }
}
