using Farmino.Service.Commands.AddressCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AddressHandler
{
    public class SetAddressHandler : ICommandHandler<SetAddress>
    {
        private readonly IAddressService _service;

        public SetAddressHandler(IAddressService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(SetAddress command)
        {
            await _service.SetAddressAsync(command.Login, command.City,
                command.Street, command.PostalCode, command.HouseNumber);
        }
    }
}
