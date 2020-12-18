using Farmino.Data.Exceptions;
using Farmino.Data.Extensions;
using Farmino.Data.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Farmino.Data.Models.Aggregations
{
    public class User
    {
        [Key]
        public Guid Id { get; protected set; }
        [Required]
        public string Login { get; protected set; }
        [Required]
        public string Password { get; protected set; }
        [Required]
        public string Email { get; protected set; }
        [Required]
        public string Salt { get; protected set; }
        public Profile Profile { get;protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        { }
        public User(string login, string password, string email)
        {
            Id = Guid.NewGuid();
            SetPassword(password);
            SetLogin(login);
            SetEmail(email);
            Salt = "salt";
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new DataExceptions(DataErrorCodes.InvalidLogin,
                    "Name is invalid");
            }
            if (login == Login)
            {
                return;
            }

            Login = login;
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
            if (string.IsNullOrWhiteSpace(email) && !email.IsEmail())
            {
                throw new DataExceptions(DataErrorCodes.InvalidEmail,
                    "Email is invalid");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
            UpdatedAt = DateTime.Now;
        }
        public void SetProfile(Profile profile)
        {
            Profile = profile;
        }
    }
}
