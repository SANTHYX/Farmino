using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AddressHandler
{
    public class EditAddressHandler : ICommandHandler<EditAddress>
    {
        private readonly IAddressService _service;

        public EditAddressHandler(IAddressService service)
        {
            _service = service;
        }

        public async Task HandleAsync(EditAddress command)
        {
            await _service.EditAddressAsync(command.Login, command.City, command.Street,
                command.PostalCode, command.HouseNumber);
        }
    }
}
