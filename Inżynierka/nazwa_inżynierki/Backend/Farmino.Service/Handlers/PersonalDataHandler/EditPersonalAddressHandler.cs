using Farmino.Service.Commands.PersonalDataCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.PersonalDataHandler
{
    public class EditPersonalAddressHandler : ICommandHandler<EditPersonalAddress>
    {
        private readonly IPersonalDataService _service;

        public EditPersonalAddressHandler(IPersonalDataService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(EditPersonalAddress command)
        {
            await _service.EditPersonalAddressAsync(command.Login, command.City,
                command.Street, command.PostalCode, command.HouseNumber);
        }
    }
}
