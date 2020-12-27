using Farmino.Service.Commands.FarmerCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.FarmerHandler
{
    public class CreateFarmerHandler : ICommandHandler<CreateFarmer>
    {
        private readonly IFarmerService _farmerService;

        public CreateFarmerHandler(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        public async Task HandleAsync(CreateFarmer command)
        {
            await _farmerService.CreateFarmer(command.Login);
        }
    }
}
