using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.PersonalDataHandler
{
    public class SetPersonalDataHandler : ICommandHandler<SetPersonalData>
    {
        private readonly IPersonalDataService _service;

        public SetPersonalDataHandler(IPersonalDataService service)
        {
            _service = service;
        }
        public async Task HandleAsync(SetPersonalData command)
        {
            await _service.SetPersonalDataAsync(command.Login, command.FirstName,
                command.LastName, command.PhoneNumber);
        }
    }
}
