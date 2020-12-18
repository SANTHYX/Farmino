using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.ProfileCommands
{
    public class EditProfile : ICommand
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
