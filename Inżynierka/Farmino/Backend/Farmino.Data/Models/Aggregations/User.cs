using Farmino.Data.Exceptions;
using Farmino.Data.Extensions;
using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public string Salt { get; protected set; }
        public Profile Profile { get;protected set; }
        public Farmer Farmer { get; protected set; }
        public Customer Customer { get; protected set; }
        public Auctioner Auctioner { get; protected set; }
        public Participant Participant { get; protected set; }
        public IEnumerable<RefreshToken> RefreshTokens { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User() { }

        public User(string userName, string password, string salt, string email)
        {
            Id = Guid.NewGuid();
            SetPassword(password);
            SetUserName(userName);
            SetEmail(email);
            SetSalt(salt);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new DataExceptions(DataErrorCodes.InvalidLogin,
                    "Name is invalid");
            }
            if (userName == UserName)
            {
                return;
            }

            UserName = userName;
            UpdatedAt = DateTime.Now;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DataExceptions(DataErrorCodes.InvalidPassword,
                    "Password is invalid");
            }
            if (password == Password)
            {
                return;
            }

            Password = password;
            UpdatedAt = DateTime.Now;
        }
        public void SetSalt(string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new DataExceptions(DataErrorCodes.InvalidSalt,
                    "Salt is invalid");
            }
            if (salt == Salt)
            {
                return;
            }

            Salt = salt;
            UpdatedAt = DateTime.Now;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DataExceptions(DataErrorCodes.InvalidEmail,
                    "Email cannot be empty");
            }
            if (!email.IsEmail())
            {
                throw new DataExceptions(DataErrorCodes.InvalidEmail,
                    "Invalid Email");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
            UpdatedAt = DateTime.Now;
        }
    }
}
