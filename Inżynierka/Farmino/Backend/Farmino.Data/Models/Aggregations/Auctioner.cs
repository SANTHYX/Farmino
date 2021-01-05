using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations
{
    public class Auctioner
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public IEnumerable<Auction> Auctions { get; protected set; }
        
        protected Auctioner() { }

        public Auctioner(User user)
        {
            Id = Guid.NewGuid();
            User = user;
        }
    }
}
