using Farmino.Service.DTO.Auction.NestedModels;
using System;

namespace Farmino.Service.DTO.Auction
{
    public class AuctionDTO
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public decimal StartingPrice { get; protected set; }
        public AuctionerDTO Auctioner { get; protected set; }
    }
}
