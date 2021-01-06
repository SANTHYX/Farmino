using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.AuctionCommands
{
    public class CreateAuction : ICommand
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartingPrice { get; set; }
    }
}
