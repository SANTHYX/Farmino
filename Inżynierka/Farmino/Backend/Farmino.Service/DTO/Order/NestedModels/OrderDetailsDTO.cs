using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Service.DTO.Order.NestedModels
{
    public class OrderDetailsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }
}
