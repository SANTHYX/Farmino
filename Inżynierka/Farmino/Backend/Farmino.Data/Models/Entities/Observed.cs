using Farmino.Data.Models.Aggregations;
using System;

namespace Farmino.Data.Models.Entities
{
    public class Observed
    {
        public Guid UserId{ get; protected set; }
        public User User { get; protected set; }
        public Guid OfferId { get; protected set; }
        public Offer Offer { get; protected set; }
        protected Observed() { }

        public Observed(User user, Offer offer)
        {

            User = user;
            Offer = offer;
        }
    }
}
