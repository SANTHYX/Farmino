using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.OfferCommands.NestedModel;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class Buy : ICommand
    {
        public string CustomerName { get; set; } 
        public Guid OfferId { get; set; }
        public int BoughtQuantity { get; set; }
        public bool CustomAddress { get; set; }
        #nullable enable
        public AddressModel? Address { get; set; }
        #nullable disable
    }
}
