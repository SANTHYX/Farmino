namespace Farmino.Service.Commands.ProfileCommands.ValueModels
{
    public class ProfilModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public AddressModel Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
