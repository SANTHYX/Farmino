using Farmino.Service.Commands.AuctionCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuctionHandler
{
    public class CreateAuctionHandler : ICommandHandler<CreateAuction>
    {
        private readonly IAuctionService _auctionService;

        public CreateAuctionHandler(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        public async Task HandleAsync(CreateAuction command)
        {
            await _auctionService.CreateAuction(command.UserName, command.Title,
                command.Description, command.StartDate, command.EndDate, command.StartingPrice);
        }
    }
}
