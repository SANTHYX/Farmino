using Farmino.Data.Models.Aggregations;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Entities
{
    public class Participant
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public IEnumerable<ParticipantAuction> Auctions { get; protected set; }

        protected Participant() { }

        public Participant(User user)
        {
            Id = Guid.NewGuid();
            User = user;
        }
    }
}
