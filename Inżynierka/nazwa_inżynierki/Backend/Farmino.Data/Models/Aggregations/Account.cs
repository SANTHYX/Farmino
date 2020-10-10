using Farmino.Data.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Farmino.Data.Models.Aggregations
{
    public class Account
    {
        [Required]
        public string Login { get; protected set; }
        [Required]
        public string Password { get; protected set; }
        [Required]
        public string Email { get; protected set; }
        public string Salt { get; protected set; }

        public Account(string login, string password, string email, string salt)
        {
            SetLogin(login);
            SetPassword(password);
            SetEmail(email);
            SetSalt(salt);
        }

        public void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new Exception("Invalid Email");
            }
            if (login == Login)
            {
                return;
            }

            Login = login;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Invalid Password");
            }
            if (password == Password)
            {
                return;
            }

            Password = password;
        }
        public void SetSalt(string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Invalid Salt");
            }
            if (salt == Salt)
            {
                return;
            }

            
            Salt = salt;
        }
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email dont include WhiteSpaces and cannot be empty");
            }
            if (!email.IsEmail())
            {
                throw new Exception("Email is Invalid");
            }
            if (email == Email)
            {
                return;
            }

            Email = email;
        }
        public static Account Create(string login, string password, string email, string salt)
            => new Account(login, password, email, salt);
    }
}
