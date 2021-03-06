using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.ObservedCommands
{
    public class UnobserveOffer : ICommand 
    {
        public string UserName { get; set; }
        public Guid OfferId { get; set; }
    }
}
