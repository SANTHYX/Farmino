using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IObservedService : IService
    {
        Task ObserveOfferAsync(string userName, Guid offerId);
        Task UnobserveOfferAsync(string userName, Guid offerId);
    }
}
