using Farmino.Data.Enums;
using Farmino.Data.Models;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.User
{
    public class RegisterUser : ICommand
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Email { get; protected set; }
        public Role Role { get; protected set; }
    }
}
