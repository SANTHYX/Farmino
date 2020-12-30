using AutoMapper;
using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class OfferService : IOfferService
    {
        private readonly IFarmerRepository _farmerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferService(IFarmerRepository farmerRepository, IProductRepository productRepository,
            IOfferRepository offerRepository, IMapper mapper)
        {
            _farmerRepository = farmerRepository;
            _productRepository = productRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task CreateOffer(string login, string title, string description, Guid productId)
        {
            if (await _farmerRepository.IsFarmerExist(login))
            {
                if (await _productRepository.IsProductExist(productId))
                {
                    try
                    {
                        var farmer = await _farmerRepository.GetAsync(login);
                        var product = await _productRepository.GetAsync(productId);

                        await _offerRepository.AddAsync(new Offer(farmer, title, description, product));
                        await _offerRepository.SaveChanges();
                    }catch(Exception e)
                    {
                        throw new Exception(e.InnerException.Message);
                    }
                }
                else throw new ServiceExceptions(ServiceErrorCodes.ProductNoExist,
                    $"Product with id {productId} not exist");
            }
            else throw new ServiceExceptions(ServiceErrorCodes.FarmerNotExist,
                $"Farmer with login {login} not exist");
        }

        public async Task<OfferDTO> GetOfferAsync(Guid id)
        {
            var offer = await _offerRepository.GetAsync(id);
            return _mapper.Map<Offer,OfferDTO>(offer);
        }

        public async Task RemoveOffer(Guid id)
        {
            if (await _offerRepository.IsOfferExist(id))
            {
                var offer = await _offerRepository.GetAsync(id);

                _offerRepository.RemoveAsync(offer);
                await _offerRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.OfferNotExist,
                "Offer dont exist");
        }
    }
}
