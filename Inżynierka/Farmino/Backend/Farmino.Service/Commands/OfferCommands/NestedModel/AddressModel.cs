using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.OfferCommands.NestedModel
{
    public class AddressModel : ICommand
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
    }
}
