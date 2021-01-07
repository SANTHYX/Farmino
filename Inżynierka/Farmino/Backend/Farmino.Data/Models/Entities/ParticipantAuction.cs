using Farmino.Data.Exceptions;
using Farmino.Data.Models.Aggregations;
using System;

namespace Farmino.Data.Models.Entities
{
    public class ParticipantAuction
    {
        public Guid ParticipantId { get; protected set; }
        public Participant Participant { get; protected set; }
        public Guid AuctionId { get; protected set; }
        public Auction Auction { get; protected set; }
        public decimal ProposedPrice { get; protected set; }

        protected ParticipantAuction() { }

        public ParticipantAuction(Participant participant, Auction auction,
            decimal proposedPrice)
        {
            Participant = participant;
            Auction = auction;
            SetProposedPrice(proposedPrice);
        }

        public void SetProposedPrice(decimal proposedPrice)
        {
            if (proposedPrice <= decimal.Zero)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProposedPrice, 
                    "ProposedPrice should be greather than zero");
            }

            ProposedPrice = proposedPrice;
        }
    }
}
