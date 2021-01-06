using Farmino.Service.Commands.AuctionCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuctionHandler
{
    public class ToAuctionHandler : ICommandHandler<ToAuction>
    {
        private readonly IAuctionService _auctionService;

        public ToAuctionHandler(IAuctionService auctionerService)
        {
            _auctionService = auctionerService;
        }

        public async Task HandleAsync(ToAuction command)
        {
            await _auctionService.ToAuction(command.UserName, command.AuctionId, command.ProposedPrice);
        }
    }
}
