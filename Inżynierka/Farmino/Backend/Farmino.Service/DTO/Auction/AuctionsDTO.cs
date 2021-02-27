using Farmino.Service.DTO.Auction.NestedModels;
using System;

namespace Farmino.Service.DTO.Auction
{
    public class AuctionsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public AuctionerDTO Auctioner { get; set; }
        public DateTime EndDate { get; set; }
    }
}
