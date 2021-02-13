﻿using AutoMapper;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.DTO.Order;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Queries.Order;
using Farmino.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<OrdersDTO>> BrowseOrdersAsync(OrderQuery orderQuery)
        {
            var orders = _orderRepository.GetAllAsync();

            if (orderQuery.OfferId != null)
            {
                orders = orders.Where(x => x.OfferId == orderQuery.OfferId);
            }
            if (orderQuery.CustomerName != null)
            {
                orders = orders.Where(x => x.Customer.User.UserName == orderQuery.CustomerName);
            }
            if (orderQuery.FarmerName != null)
            {
                orders = orders.Where(x => x.Offer.Farmer.User.UserName == orderQuery.FarmerName);
            }
            if (orderQuery.Released != null)
            {
                orders = orders.Where(x => x.Released == orderQuery.Released);
            }
            if (orderQuery.Date != null)
            {
                orders = orders.Where(x => x.ReleaseDate.Date == orderQuery.Date);
            }

            var result = await orders.Include(x => x.Offer).ThenInclude(x=> x.Farmer).ThenInclude(z => z.User)
                .Include(y => y.Customer).ThenInclude(z => z.User).ThenInclude(q => q.Profile).ToListAsync();
                
            return _mapper.Map<IEnumerable<OrdersDTO>>(result);
        }

        public async Task CancelOrder(Guid orderId)
        {
            var order = await _orderRepository.GetIfExistAsync(orderId);

            if (order.Released)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotCancelReleasedOrder,
                    "Cannot cancel released order");
            }

            order.SetOrderStatus(Data.Enums.OrderStatus.Odrzucona);
            _orderRepository.Edit(order);
            await _orderRepository.SaveChanges();
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task SetupRealisationDate(Guid orderId, DateTime realisationDate)
        {
            var order = await _orderRepository.GetIfExistAsync(orderId);

            order.SetOrderStatus(Data.Enums.OrderStatus.Przyjęta);
            order.SetReleaseDate(realisationDate);
            _orderRepository.Edit(order);

            await _orderRepository.SaveChanges();
        }
    }
}
