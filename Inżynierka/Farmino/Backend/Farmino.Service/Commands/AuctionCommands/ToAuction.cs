using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.AuctionCommands 
{
    public class ToAuction : ICommand 
    {
        public string UserName { get; set; }
        public Guid AuctionId { get; set; }
        public decimal ProposedPrice { get; set; }
    }
}
