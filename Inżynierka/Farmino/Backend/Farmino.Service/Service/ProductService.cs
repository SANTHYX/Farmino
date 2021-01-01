using AutoMapper;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddProductAsync(string name, decimal price, int quantity,
            int unit, double value)
        {
            var weight = Weight.Create(unit, value);
            await _productRepository.AddAsync(new Product(name, price, quantity, weight));
            await _productRepository.SaveChanges();
        }
        
        public async Task<ProductDTO> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return _mapper.Map<Product, ProductDTO>(product);
        }
    }
}
