using Farmino.Service.DTO.Auction.NestedModels;
using System;

namespace Farmino.Service.DTO.Auction
{
    public class AuctionDTO
    {
        public Guid Id { get;  set; }
        public string Title { get;  set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartingPrice { get; set; }
        public AuctionerDTO Auctioner { get; set; }
        public string ImageName { get; set; }
    }
}
