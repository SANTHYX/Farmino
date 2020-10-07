using System;

namespace Farmino.Data.Models
{
    public class Account
    {
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }

        public Account(string login, string password, string salt)
        {
            SetLogin(login);
            SetPassword(password);
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
        public static Account Create(string login, string password, string salt)
            => new Account(login, password, salt);
    }
}
