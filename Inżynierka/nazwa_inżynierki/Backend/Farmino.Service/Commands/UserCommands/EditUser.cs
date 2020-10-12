using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.UserCommands
{
    public class EditUser : ICommand
    {
        public string Login { get; set; }
        public string NewLogin { get; set; }
        public string NewPassword { get; set; }
    }
}
