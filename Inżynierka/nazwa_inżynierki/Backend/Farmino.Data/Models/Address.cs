using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Data.Models
{
    public class Address
    {
        public string City { get; protected set; }
        public string  PostalCode { get; protected set; }
        public string Street { get; protected set; }
        public int Number { get; protected set; }
    }
}
