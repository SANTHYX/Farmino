using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Security.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuthHandler
{
    public class LoginHandler : ICommandHandler<LoginModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public LoginHandler(IAuthService authService,
            IUserService userService, ITokenHandler tokenHandler)
        {
            _authService = authService;
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task HandleAsync(LoginModel command)
        {
            await _authService.Login(command.Login, command.Password);
            var user = await _userService.GetUserAsync(command.Login);
            command.Token = _tokenHandler.GenerateToken(user);
        }
    }
}
