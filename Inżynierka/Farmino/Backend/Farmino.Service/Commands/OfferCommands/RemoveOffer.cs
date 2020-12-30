using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OfferCommands
{
    public class RemoveOffer : ICommand
    {
        public Guid Id { get; set; }
    }
}
