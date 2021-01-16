using AutoMapper;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Order;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdersDTO>> BrowseOrdersAsync(Guid offerId)
        {
            var orders = await _orderRepository.GetAllAsync(offerId);
            return _mapper.Map<IEnumerable<OrdersDTO>>(orders);
        }

        public async Task CancelOrder(Guid offerId, Guid customerId)
        {
            var order = await _orderRepository.GetIfExistAsync(offerId, customerId);

            if (order.Released)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotCancelReleasedOrder,
                    "Cannot cancel released order");
            }

            _orderRepository.Remove(order);
            await _orderRepository.SaveChanges();
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(Guid offerId, Guid customerId)
        {
            var order = await _orderRepository.GetAsync(offerId, customerId);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task SetupRealisationDate(Guid offerId, Guid customerId, DateTime realisationDate)
        {
            var order = await _orderRepository.GetIfExistAsync(offerId, customerId);

            order.SetReleaseDate(realisationDate);
            _orderRepository.Edit(order);

            await _orderRepository.SaveChanges();
        }
    }
}
