using Farmino.Service.Commands.AuthCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuthHandler
{
    public class RevokeTokenHandler : ICommandHandler<RevokeToken>
    {
        private readonly IAuthService _authService;

        public RevokeTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task HandleAsync(RevokeToken command)
        {
            await _authService.RevokeToken(command.Refresh);
        }
    }
}
