﻿using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.AuthCommands
{
    public class RegisterUser : ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
