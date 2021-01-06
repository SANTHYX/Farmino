using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(IAuctionRepository auctionRepository, ICustomerRepository customerRepository)
        {
            _auctionRepository = auctionRepository;
            _customerRepository = customerRepository;
        }

        public Task CancelOrder()
        {
            throw new System.NotImplementedException();
        }

        public Task EditOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}
