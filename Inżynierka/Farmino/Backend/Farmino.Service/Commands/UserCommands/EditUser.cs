using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.UserCommands
{
    public class EditUser : ICommand
    {
        public string UserName { get; set; }
        public string NewUserName { get; set; }
        public string NewPassword { get; set; }
        public string NewEmail { get; set; }
    }
}
