using System;

namespace Farmino.Service.DTO.Auction
{
    public class AuctionDTO
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public DateTime EndDate { get; protected set; }
    }
}
