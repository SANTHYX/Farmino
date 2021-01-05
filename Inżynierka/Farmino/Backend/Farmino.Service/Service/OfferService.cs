using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Service.DTO;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OfferService : IOfferService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferService(IFarmerRepository farmerRepository, IProductRepository productRepository,
            IOfferRepository offerRepository, IMapper mapper)
        {
            _farmerRepository = farmerRepository;
            _productRepository = productRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task CreateOffer(string userName, string title, string description, Guid productId)
        {
            var farmer = await _farmerRepository.GetIfExist(userName);
            var product = await _productRepository.GetIfExist(productId);

            await _offerRepository.AddAsync(new Offer(farmer, title, description, product));
            await _offerRepository.SaveChangesAsync();
        }

        public async Task<OfferDTO> GetOfferAsync(Guid id)
        {
            var offer = await _offerRepository.GetAsync(id);
            return _mapper.Map<Offer,OfferDTO>(offer);
        }

        public async Task RemoveOffer(Guid id)
        {
            var offer = await _offerRepository.GetIfExist(id);
            _offerRepository.RemoveAsync(offer);
        }
    }
}
