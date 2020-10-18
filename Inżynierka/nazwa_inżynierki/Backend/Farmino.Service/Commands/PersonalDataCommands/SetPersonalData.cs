using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.PersonalDataCommands
{
    public class SetPersonalData : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
    }
}
