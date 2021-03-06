using Farmino.Service.Commands.ObservedCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ObserveHandler
{
    public class UnobserveOfferHandler : ICommandHandler<UnobserveOffer>
    {
        private readonly IObservedService _observedService;

        public UnobserveOfferHandler(IObservedService observedService)
        {
            _observedService = observedService;
        }

        public async Task HandleAsync(UnobserveOffer command)
        {
            await _observedService.UnobserveOfferAsync(command.UserName, command.OfferId);
        }
    }
}
