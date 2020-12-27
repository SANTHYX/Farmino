using Farmino.Service.Commands.CustomerCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.CustomerHandler
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task HandleAsync(CreateCustomer command)
        {
            await _customerService.CreateCustomer(command.Login);
        }
    }
}
