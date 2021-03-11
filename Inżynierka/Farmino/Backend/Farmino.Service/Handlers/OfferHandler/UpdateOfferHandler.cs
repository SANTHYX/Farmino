using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.OfferHandler
{
    public class UpdateOfferHandler : ICommandHandler<UpdateOffer>
    {
        private readonly IOfferService _offerService;

        public UpdateOfferHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task HandleAsync(UpdateOffer command)
        {
            
        }
    }
}
