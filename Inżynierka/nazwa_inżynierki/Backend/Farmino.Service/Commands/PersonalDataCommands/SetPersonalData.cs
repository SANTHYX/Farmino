using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.PersonalDataCommands.ValueModels;

namespace Farmino.Service.Commands.PersonalDataCommands
{
    public class SetPersonalData : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public AddressModel Address { get; set; }
    }
}
