using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuthHandler
{
    public class LoginHandler : ICommandHandler<LoginModel>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task HandleAsync(LoginModel command)
        {
            command.Token = await _authService.Login(command.UserName, command.Password);           
        }
    }
}
