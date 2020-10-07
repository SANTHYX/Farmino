using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Data.Models
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }
    }
}
