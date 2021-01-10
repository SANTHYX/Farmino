using AutoMapper;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Order;
using Farmino.Service.Exceptions;
using Farmino.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOfferRepository offerRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDTO>> BrowseOrdersAsync(Guid offerId)
        {
            var orders = await _orderRepository.GetAllAsync(offerId);
            return _mapper.Map<IEnumerable<OrdersDTO>>(orders);
        }

        public async Task CancelOrder(Guid offerId, Guid customerId)
        {
            var order = await _orderRepository.GetAsync(offerId, customerId);
            var offer = await _offerRepository.GetAsync(offerId);

            if (order.Released)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotCancelReleasedOrder,
                    "Cannot cancel released order");
            }

            offer.Product.SetQuantity(offer.Product.Quantity + order.BoughtQuantity);

            _orderRepository.Remove(order);
            await _orderRepository.SaveChanges();
        }

        public async Task EditOrder(Guid offerId, Guid customerId, int quantity)
        {
            var order = await _orderRepository.GetAsync(offerId, customerId);

            if (order.Released)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotCancelReleasedOrder,
                    "Cannot edit released order");
            }

            var offer = await _offerRepository.GetAsync(offerId);

            offer.Product.SetQuantity(quantity);
            order.SetPriceSummary(offer.Product.Price * quantity);
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(Guid offerId, Guid customerId)
        {
            var order = await _orderRepository.GetAsync(offerId, customerId);
            return _mapper.Map<OrderDTO>(order);
        }
    }
}
