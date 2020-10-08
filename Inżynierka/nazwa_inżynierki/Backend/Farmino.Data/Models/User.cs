using Farmino.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Farmino.Data.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        [Required]
        public Account Account { get; protected set; }
        [Required]
        public string FirstName { get; protected set; }
        [Required]
        public string LastName { get; protected set; }
        [Required]
        public Address Address { get; protected set; }
        [Required]
        public Role Role { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
    }
}
