﻿using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.PersonalDataCommands
{
    public class SetPersonalData : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
    }
}
