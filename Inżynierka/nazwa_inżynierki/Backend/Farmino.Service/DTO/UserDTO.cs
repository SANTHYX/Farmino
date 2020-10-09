using Farmino.Service.DTO.Aggregations;

namespace Farmino.Service.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AccountModel Account { get; set; }
        public AddressDTO Address { get; set; }
    }
}
