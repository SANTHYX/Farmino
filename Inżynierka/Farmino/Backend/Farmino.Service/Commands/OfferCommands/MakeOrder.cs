using Farmino.Data.Enums;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.OfferCommands.NestedModel;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class MakeOrder : ICommand
    {
        public Guid OfferId { get; set; }
        public string CustomerName { get; set; }
        public double OrderQuantity { get; set; }
        public WeightUnits OrderUnit { get; set; }
        public bool CustomAddress { get; set; }
        #nullable enable
        public OrderDetailsCommand? OrderDetails { get; set; }
        #nullable disable
    }
}
