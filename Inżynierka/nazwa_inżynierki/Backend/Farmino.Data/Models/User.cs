using System;

namespace Farmino.Data.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {}
        public User(string login, string password)
        {
            Id = Guid.NewGuid();
            SetPassword(password);
            SetLogin(login);
            Salt = "salt";
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new Exception("Name is invalid");
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
                throw new Exception("Password is invalid");
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
                throw new Exception("Salt is invalid");
            }
            if (salt == Salt)
            {
                return;
            }

            Salt = salt;
            UpdatedAt = DateTime.Now;
        }
    }
}
