using System;

namespace Farmino.Data.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public Account Account { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public Address Address { get; protected set; }
        public DateTime UpdatedOn { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
    }
}
