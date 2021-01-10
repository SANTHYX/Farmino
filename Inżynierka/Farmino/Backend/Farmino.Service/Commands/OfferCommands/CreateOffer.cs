using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.OfferCommands.NestedModel;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class CreateOffer : ICommand
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductModel Product { get; set; }
    }
}
