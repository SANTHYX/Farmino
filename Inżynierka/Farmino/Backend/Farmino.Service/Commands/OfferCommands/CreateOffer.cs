using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class CreateOffer : ICommand
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
    }
}
