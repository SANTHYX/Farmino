using Farmino.Data.Enums;
using Farmino.Data.Models.Aggregations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Farmino.Data.Models
{
    public class User
    {
        [NotNull, Required]
        public Guid Id { get; protected set; }
        [Required]
        public string FirstName { get; protected set; }
        [Required]
        public string LastName { get; protected set; }
        [Required]
        public Account Account { get; protected set; }
        [Required]
        public Address Address { get; protected set; }
        [Required]
        public Role Role { get; protected set; }
        [Required]
        public DateTime UpdatedOn { get; protected set; }
        [Required]
        public DateTime CreatedOn { get; protected set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedOn = UpdatedOn = DateTime.Now;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("FirstName cannot be empty");
            }
            if (firstName == FirstName)
            {
                return;
            }

            FirstName = firstName;
            UpdatedOn = DateTime.Now;
        }
        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("LastName cannot be empty");
            }
            if (lastName == LastName)
            {
                return;
            }

            LastName = lastName;
            UpdatedOn = DateTime.Now;
        }
        public void SetAccount(Account account)
        {
            Account = account;
        }
    }
}
