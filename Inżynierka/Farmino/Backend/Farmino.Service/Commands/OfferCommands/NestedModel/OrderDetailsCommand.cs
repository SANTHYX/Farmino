using Farmino.Service.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Service.Commands.OfferCommands.NestedModel
{
    public class OrderDetailsCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressCommand Address { get; set; }
    }
}
