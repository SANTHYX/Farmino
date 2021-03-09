using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.ImageManager.Interface;
using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class CreateOfferHandler : ICommandHandler<CreateOffer>
    {
        private readonly IOfferService _offerService;
        private readonly IImageManager _imageManager;

        public CreateOfferHandler(IOfferService offerService, IImageManager imageManager)
        {
            _offerService = offerService;
            _imageManager = imageManager;
        }

        public async Task HandleAsync(CreateOffer command)
        {
            var imgName = await _imageManager.SaveImage(command.Image, "Images/Offer");
            var product = Product.Create(command.Product.BasePrice, command.Product.BaseWeightUnit);

            await _offerService.CreateOffer(command.UserName, command.Title, command.Description,
                imgName ,command.MinWeightUnit, command.Category, command.Region, command.MinQuantity, product);
        }
    }
}
