using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.PersonalDataCommands
{
    public class EditPersonalAddress : ICommand
    {
        public string Login { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
    }
}
