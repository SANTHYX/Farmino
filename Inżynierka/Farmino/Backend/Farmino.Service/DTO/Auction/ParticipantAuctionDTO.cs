using Farmino.Service.DTO.Auction.NestedModels;
using System;

namespace Farmino.Service.DTO.Auction
{
    public class ParticipantAuctionDTO
    {
        public Guid Id { get; set; }
        public ParticipantDTO Participant { get; set; }
        public decimal ProposedPrice { get; set; }
    }
}
