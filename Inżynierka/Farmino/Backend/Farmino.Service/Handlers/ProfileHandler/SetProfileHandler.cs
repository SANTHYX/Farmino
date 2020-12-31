using Farmino.Service.Commands.ProfileCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ProfileHandler
{
    public class SetProfileHandler : ICommandHandler<SetProfil>
    {
        private readonly IProfileService _service;

        public SetProfileHandler(IProfileService service)
        {
            _service = service;
        }

        public async Task HandleAsync(SetProfil command)
        {
            await _service.CreateProfileAsync(command.UserName, command.FirstName,
                command.LastName, command.PhoneNumber);
        }
    }
}
