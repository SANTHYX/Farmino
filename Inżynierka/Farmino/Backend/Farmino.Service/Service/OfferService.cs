using AutoMapper;
using Farmino.Data.Enums;
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
        private readonly IOfferRepository _offerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository; 
        private readonly IMapper _mapper;

        public OfferService(IFarmerRepository farmerRepository, IOfferRepository offerRepository,
            ICustomerRepository customerRepository, IMapper mapper, IOrderRepository orderRepository)
        {
            _farmerRepository = farmerRepository;
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

        public async Task CreateOffer(string userName, string title, string description, WeightUnits minUnit,
            double minQuantity, Product product)
        {
            var farmer = await _farmerRepository.GetIfExistAsync(userName);

            await _offerRepository.AddAsync(new Offer(farmer, title, description, minUnit,
                minQuantity ,product));
            await _offerRepository.SaveChangesAsync();
        }

        public async Task<OfferDTO> GetOfferAsync(Guid id)
        {
            var offer = await _offerRepository.GetAsync(id);

            return _mapper.Map<OfferDTO>(offer);
        }

        public async Task MakeOrder(Guid offerId, string customerName, double orderQuantity,
            bool customAddress, OrderDetails orderDetails = null)
        {
            var offer = await _offerRepository.GetIfExistAsync(offerId);
            var customer = await _customerRepository.GetIfExistAsync(customerName);
            
            if (customer.User.Id == offer.Farmer.UserId)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotBuyFromOwnOffer,
                    "Cannot make order of your own offer");
            }
            if (orderQuantity < offer.MinQuantity)
            {
                throw new ServiceExceptions(ServiceErrorCodes.InvalidOrder,
                    "Cannot buy lower than min quantity");
            }
            if (customer.User.Profile == null && customAddress == false)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ProfileDontExist,
                    "Profile dont exist");
            }

            var summaryPrice = offer.Product.BasePrice * (decimal)orderQuantity;

            if (customAddress)
            {
                await _orderRepository.AddAsync(new Order(offer, customer, orderDetails,
                    orderQuantity, summaryPrice, customAddress));
            }
            else await _orderRepository.AddAsync(new Order(offer, customer, OrderDetails.Create(customer.User.Profile.FirstName,
                customer.User.Profile.LastName,customer.User.Profile.PhoneNumber,
                customer.User.Profile.Address), orderQuantity, summaryPrice, customAddress));

            await _orderRepository.SaveChanges();
        }

        public async Task RemoveOffer(Guid id)
        {
            var offer = await _offerRepository.GetIfExistAsync(id);

            _offerRepository.RemoveAsync(offer);
            await _offerRepository.SaveChangesAsync();
        }
    }
}
