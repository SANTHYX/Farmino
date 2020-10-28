namespace Farmino.Service.Commands.PersonalDataCommands.ValueModels
{
    public class PersonalDataModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public AddressModel Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
