using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations
{
    public class Farmer
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public IEnumerable<Offer> Offers { get; protected set; }

        protected Farmer() { }

        public Farmer(User user)
        {
            Id = Guid.NewGuid();
            SetUser(user);
        }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}
