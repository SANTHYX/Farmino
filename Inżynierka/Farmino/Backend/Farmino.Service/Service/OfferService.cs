using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Offer;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
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

        public async Task BuyAsync(string customerName, Guid offerId,
            int boughtQuantity, bool customAddress, Address address = null)
        {
            var offer = await _offerRepository.GetIfExistAsync(offerId);
            var customer = await _customerRepository.GetIfExistAsync(customerName);

            if (offer.Farmer.UserId == customer.UserId)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotBuyFromOwnOffer,
                    "Customer cannot make order of own offer");
            }
            if (offer.Product.Quantity - boughtQuantity <= 0)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ProductStorageIsEmpty,
                    "Storage is empty or you try buy with quantity being out of avalivable range");
            }
            if (customer.User.Profile.Address == null && !customAddress)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AddressNotExist,
                    "Your profile address is empty");
            }

            var priceSummary = offer.Product.Price * boughtQuantity;

            if (!customAddress)
            {
                await _orderRepository.AddAsync(new Order(offer, customer,
                    customer.User.Profile.Address, boughtQuantity, priceSummary, customAddress));
            }
            else await _orderRepository.AddAsync(new Order(offer, customer,
                    address, boughtQuantity, priceSummary, customAddress));

            offer.Product.DecreaseQuantity(boughtQuantity);
            await _orderRepository.SaveChanges();
        }

        public async Task CreateOffer(string userName, string title, string description, Guid productId)
        {
            var farmer = await _farmerRepository.GetIfExistAsync(userName);
            var product = await _productRepository.GetIfExistAsync(productId);

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
            var offer = await _offerRepository.GetIfExistAsync(id);

            _offerRepository.RemoveAsync(offer);
            await _offerRepository.SaveChangesAsync();
        }
    }
}
