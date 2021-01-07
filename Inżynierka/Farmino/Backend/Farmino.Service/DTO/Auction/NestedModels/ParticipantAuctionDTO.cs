using System;

namespace Farmino.Service.DTO.Auction.NestedModels
{
    public class ParticipantAuctionDTO
    {
        public Guid ParticipantId { get; set; }
        public ParticipantDTO Participant { get; set; }
        public decimal ProposedPrice { get; protected set; }
    }
}
