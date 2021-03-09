using Farmino.Data.Enums;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Offer;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Offer;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service.Interfaces
{
    public interface IOfferService : IService
    {
        Task CreateOffer(string userName, string title, string description, string imageName, WeightUnits minWeight, 
            Categories category, Regions region, double minQuantity, Product product);
        Task MakeOrder(Guid offerId, string customerName, double orderQuantity,
            bool customAddress, OrderDetails orderDetails = null);
        Task RemoveOffer(Guid id);
        Task<OfferDTO> GetOfferAsync(Guid id);
        Task<PagedResponseDTO<OffersDTO>> BrowseAllAsync(PagedQuery paged, OfferQuery query);
        Task<PagedResponseDTO<OffersDTO>> GetObservedsAsync(string userName, PagedQuery paged);
    }
}
