using AutoMapper;
using Farmino.Data.Enums;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Offer;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Offer;
using Farmino.Service.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task<PagedResponseDTO<OffersDTO>> BrowseAllAsync(PagedQuery paged, OfferQuery query)
        {
            var offers = _offerRepository.GetAllAsync();

            if (query.FarmerName != null)
            {
                offers = offers.Where(x => x.Farmer.User.UserName == query.FarmerName);
            }
            if (query.Phrase != null)
            {
                offers = offers.Where(x => x.Title.ToLower().Contains(query.Phrase.ToLower()));
            }
            if (query.PriceFrom != null)
            {
                offers = offers.Where(x => x.Product.BasePrice >= query.PriceFrom);
            }
            if (query.PriceTo != null)
            {
                offers = offers.Where(x => x.Product.BasePrice <= query.PriceTo);
            }
            if (query.City != null)
            {
                offers = offers.Where(x => x.Farmer.User.Profile.Address.City == query.City);
            }
            if (query.Region != null)
            {
                offers = offers.Where(x => x.Region == query.Region);
            }
            if (query.Category != null)
            {
                offers = offers.Where(x => x.Category == query.Category);
            }
            if (query.IsActive != null)
            {
                offers = offers.Where(x => x.IsActive == query.IsActive);
            }

            var result = offers.Include(x => x.Product)
                .Include(y => y.Farmer)
                .ThenInclude(z => z.User)
                .ThenInclude(y=>y.Profile)
                .ThenInclude(z => z.Address);

            var pagedResponse = await PagedResponse<Offer>.GetPagedResponse(result, paged);

            return _mapper.Map<PagedResponseDTO<OffersDTO>>(pagedResponse);
        }

        public async Task CreateOffer(string userName, string title, string description, string imageName, 
            WeightUnits minUnit,Categories category, Regions region, double minQuantity, Product product)
        {
            var farmer = await _farmerRepository.GetIfExistAsync(userName);

            await _offerRepository.AddAsync(new Offer(farmer, title, description, minUnit, region, category,
                minQuantity, imageName, product));
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
            else await _orderRepository.AddAsync(new Order(offer, customer, OrderDetails
                .Create(customer.User.Profile.FirstName,
                customer.User.Profile.LastName,customer.User.Profile.PhoneNumber,
                customer.User.Profile.Address), orderQuantity, summaryPrice, customAddress));

            await _orderRepository.SaveChanges();
        }

        public async Task DeactivateOffer(Guid id, string userName)
        {
            var offer = await _offerRepository.GetIfExistAsync(id);
            
            if(offer.Farmer.User.UserName != userName)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotDeactiveOffer,
                    "Invalid Creedentials");
            }

            offer.SetActivity(false);
            _offerRepository.EditAsync(offer);
            await _offerRepository.SaveChangesAsync();
        }

        public async Task UpdateOffer(Guid id, string userName, string title, string description,
            WeightUnits minUnit, double minQuantity, Product product)
        {
            var offer = await _offerRepository.GetIfExistAsync(id);
            var farmer = await _farmerRepository.GetIfExistAsync(userName);

            offer.SetTitle(title);
            offer.SetDescription(description);
            offer.SetMinWeightUnit(minUnit);
            offer.SetMinQuantity(minQuantity);
            offer.SetProduct(product);

            _offerRepository.EditAsync(offer);
            await _offerRepository.SaveChangesAsync();
        }

        public async Task<PagedResponseDTO<OffersDTO>> GetObservedsAsync(string userName, PagedQuery paged)
        {
            var offer = _offerRepository.GetAllAsync()
                .Where(x => x.Observeds.Any(y => y.User.UserName == userName));

            var pagedResponse = await PagedResponse<Offer>.GetPagedResponse(offer, paged);
            return _mapper.Map<PagedResponseDTO<OffersDTO>>(pagedResponse);
        }

    }
}
