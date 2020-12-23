using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuthHandler
{
    public class RefreshTokenHandler : ICommandHandler<RefreshToken>
    {
        private readonly IAuthService _authService;

        public RefreshTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task HandleAsync(RefreshToken command)
        {
            command.TokenResponse = await _authService.RefreshToken(command.Token, command.Refresh);
        }
    }
}
