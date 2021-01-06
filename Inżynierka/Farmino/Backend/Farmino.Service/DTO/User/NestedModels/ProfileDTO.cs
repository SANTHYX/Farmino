namespace Farmino.Service.DTO.User.NestedModels
{
    public class ProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public int PhoneNumber { get; set; }
    }
}
