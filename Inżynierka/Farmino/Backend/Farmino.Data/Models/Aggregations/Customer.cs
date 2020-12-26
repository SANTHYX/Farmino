using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmino.Data.Models.Aggregations
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        [Required]
        public Guid UserId { get; protected set; }
        [ForeignKey("UserId")]
        public User User { get; protected set; }

        protected Customer() { }

        public Customer(User user)
        {
            Id = Guid.NewGuid();
            SetUser(user);
        }

        public void SetUser(User user)
        {
            if (User == user)
            {
                return;
            }

            User = user;
        }
    }
}
