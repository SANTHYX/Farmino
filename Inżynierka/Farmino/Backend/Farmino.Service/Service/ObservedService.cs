using AutoMapper;
using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ObservedService : IObservedService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IObservedRepository _observedRepository;
        private readonly IMapper _mapper;

        public ObservedService(IUserRepository userRepository, IOfferRepository offerRepository,
            IObservedRepository observedRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _observedRepository = observedRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task ObserveOfferAsync(string userName, Guid offerId)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var offer = await _offerRepository.GetIfExistAsync(offerId);

            if (await _observedRepository.GetAsync(user.Id, offerId) != null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AlreadyObserved,
                    "You already have that offer as observed");
            }
            if (user.Id == offer.Farmer.User.Id)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotObserveOwnOffer,
                    "You cannot observe own offer");
            }

            await _observedRepository.Add(new Observed(user, offer));
            await _observedRepository.SaveAsync();
        }

        public async Task UnobserveOfferAsync(string userName, Guid offerId)
        {
            var user = await _userRepository.GetIfExistAsync(userName);
            var observed = await _observedRepository.GetAsync(user.Id, offerId);

            if (await _observedRepository.GetAsync(user.Id, offerId) == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AlreadyObserved,
                    "Observation log dont exist");
            }

            _observedRepository.Remove(observed);
            await _observedRepository.SaveAsync();
        }
    }
}
