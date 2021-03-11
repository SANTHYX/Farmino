using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class DeactiveOffer : ICommand
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}
