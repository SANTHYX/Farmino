using Farmino.Infrastructure.ImageManager.Interface;
using Farmino.Service.Commands.AuctionCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.AuctionHandler
{
    public class CreateAuctionHandler : ICommandHandler<CreateAuction>
    {
        private readonly IAuctionService _auctionService;
        private readonly IImageManager _imageManager;

        public CreateAuctionHandler(IAuctionService auctionService, IImageManager imageManager)
        {
            _auctionService = auctionService;
            _imageManager = imageManager;
        }

        public async Task HandleAsync(CreateAuction command)
        {
            var imgName = await _imageManager.SaveImage(command.Image, "Images/Auction");
            await _auctionService.CreateAuction(command.UserName, command.Title,
                command.Description, command.StartDate, command.EndDate, imgName ,command.StartingPrice);
        }
    }
}
