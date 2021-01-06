using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO.Offer;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OfferService : IOfferService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository; 
        private readonly IMapper _mapper;

        public OfferService(IFarmerRepository farmerRepository, IProductRepository productRepository,
            IOfferRepository offerRepository, ICustomerRepository customerRepository, IMapper mapper, IOrderRepository orderRepository)
        {
            _farmerRepository = farmerRepository;
            _productRepository = productRepository;
            _offerRepository = offerRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OffersDTO>> BrowseAllAsync()
        {
            var offers = await _offerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OffersDTO>>(offers);
        }

        public async Task BuyAsync(string customerName, string farmerName, Guid offerId, Address address = null,
            int boughtQuantity, decimal priceSummary, bool customAddress)
        {
            var customer = await _customerRepository.GetIfExistAsync(customerName);
            var farmer = await _farmerRepository.GetIfExist(farmerName);
            var offer = await _offerRepository.GetIfExist(offerId);
            var product = await _productRepository.GetIfExist(offer.Product.Id);
            var order = await _orderRepository.

            product.SetQuantity(-boughtQuantity);
            await _offerRepository.AddAsync(new Offer())
            
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
            return _mapper.Map<OfferDTO>(offer);
        }

        public async Task RemoveOffer(Guid id)
        {
            var offer = await _offerRepository.GetIfExist(id);
            _offerRepository.RemoveAsync(offer);
        }
    }
}
