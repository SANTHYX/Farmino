using Farmino.Service.Commands.AuctionerCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuctionerHandler
{
    public class CreateAuctionerHandler : ICommandHandler<CreateAuctioner>
    {
        private readonly IAuctionerService _auctionerService;

        public CreateAuctionerHandler(IAuctionerService auctionerService)
        {
            _auctionerService = auctionerService;
        }

        public async Task HandleAsync(CreateAuctioner command)
        {
            await _auctionerService.CreateAuctioner(command.UserName);
        }
    }
}
