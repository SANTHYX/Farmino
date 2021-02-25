using AutoMapper;
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
using Farmino.Service.DTO.DeliverOrder;
using Farmino.Data.Enums;
using Farmino.Service.Queries;
using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;

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

        public async Task<PagedResponseDTO<DeliverOrdersDTO>> BrowseDeliverOrdersAsync(PagedQuery paged,DateTime date, string userName)
        {
            var deliverOrders = _orderRepository.GetAllAsync().Include(x => x.Offer).ThenInclude(x => x.Farmer).ThenInclude(z => z.User)
                .Include(y => y.Customer).ThenInclude(z => z.User).ThenInclude(q => q.Profile)
                .Where(x => x.ReleaseDate.Date == date && x.OrderStatus == OrderStatus.Przyjeta && x.Offer.Farmer.User.UserName == userName);

            var pagedResponse = await PagedResponse<Order>.GetPagedResponse(deliverOrders, paged);

            return _mapper.Map<PagedResponseDTO<DeliverOrdersDTO>>(pagedResponse);
        }

        public async Task<PagedResponseDTO<OrdersDTO>> BrowseOrdersAsync(PagedQuery paged, OrderQuery query)
        {
            var orders = _orderRepository.GetAllAsync();

            if (query.OfferId != null)
            {
                orders = orders.Where(x => x.OfferId == query.OfferId);
            }
            if (query.CustomerName != null)
            {
                orders = orders.Where(x => x.Customer.User.UserName == query.CustomerName);
            }
            if (query.FarmerName != null)
            {
                orders = orders.Where(x => x.Offer.Farmer.User.UserName == query.FarmerName);
            }
            if (query.Phrase != null)
            {
                orders = orders.Where(x => x.Offer.Title.ToLower().Contains(query.Phrase.ToLower()));
            }
            if (query.OrderStatus != null)
            {
                orders = orders.Where(x => x.OrderStatus == query.OrderStatus);
            }
            if (query.Date != null)
            {
                orders = orders.Where(x => x.ReleaseDate.Date == query.Date);
            }

            var result = orders.Include(x => x.Offer).ThenInclude(x => x.Farmer).ThenInclude(z => z.User)
                .Include(y => y.Customer).ThenInclude(z => z.User).ThenInclude(q => q.Profile);
            var pagedResponse = await PagedResponse<Order>.GetPagedResponse(result, paged);
                
            return _mapper.Map<PagedResponseDTO<OrdersDTO>>(pagedResponse);
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

        public async Task ReleaseOrder(Guid orderId)
        {
            var order = await _orderRepository.GetIfExistAsync(orderId);

            if (order.Released)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CannotCancelReleasedOrder,
                    "Already released order");
            }

            order.SetOrderStatus(Data.Enums.OrderStatus.Dostarczona);
            _orderRepository.Edit(order); 
            await _orderRepository.SaveChanges();
        }

        public async Task SetupRealisationDate(Guid orderId, DateTime realisationDate)
        {
            var order = await _orderRepository.GetIfExistAsync(orderId);

            order.SetOrderStatus(Data.Enums.OrderStatus.Przyjeta);
            order.SetReleaseDate(realisationDate);
            _orderRepository.Edit(order);

            await _orderRepository.SaveChanges();
        }
    }
}
