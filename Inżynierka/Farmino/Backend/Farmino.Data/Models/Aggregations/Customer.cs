using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public IEnumerable<Order> Orders { get; protected set; }

        protected Customer() { }

        public Customer(User user)
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
