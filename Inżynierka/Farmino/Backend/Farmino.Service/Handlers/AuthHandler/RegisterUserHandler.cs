using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuthHandler
{
    public class RegisterUserHandler : ICommandHandler<RegisterUser>
    {
        private readonly IAuthService _service;

        public RegisterUserHandler(IAuthService service)
        {
            _service = service;
        }

        public async Task HandleAsync(RegisterUser command)
        {
            await _service.RegisterAsync(command.UserName, command.Password, command.Email);
        }
    }
}
