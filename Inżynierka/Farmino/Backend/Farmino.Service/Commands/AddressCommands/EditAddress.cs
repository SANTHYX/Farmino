using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.AddressCommands
{
    public class EditAddress : ICommand
    {
        public string UserName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
    }
}
