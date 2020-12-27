using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Farmino.Data.Models.Aggregations
{
    public class Farmer
    {
        [Key]
        public Guid Id { get; protected set; }
        [Required]
        public Guid UserId { get; protected set; }
        [ForeignKey("UserId")]
        public User User { get; protected set; }

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
