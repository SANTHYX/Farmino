using Farmino.Service.Commands.Interfaces;
using Farmino.Service.DTO;

namespace Farmino.Service.Commands.AuthCommands
{
    public class LoginModel : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public TokenDTO Token { get; set; }
    }
}
