using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOfferRepository _offerRepository;

        public OrderService(IOrderRepository orderRepository, IOfferRepository offerRepository)
        {
            _orderRepository = orderRepository;
            _offerRepository = offerRepository;
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
    }
}
