using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.Extensions.Models;
using Farmino.Service.Queries;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : AutoMapper.Profile
    {
        public AutoMapperCfg()
        {
            CreateMap<User, DTO.User.UserDTO>();
            CreateMap<User, DTO.User.UsersDTO>();
            CreateMap<User, DTO.Offer.NestedModels.UserDTO>();
            CreateMap<User, DTO.Offer.NestedModels.UserDTO>();
            CreateMap<Profile, DTO.User.NestedModels.ProfileDTO>();
            CreateMap<Profile, DTO.Offer.NestedModels.ProfileDTO>();
            CreateMap<Address, DTO.Offer.NestedModels.AddressDTO>();
            CreateMap<Address, DTO.User.NestedModels.AddressDTO>();
            CreateMap<Address, DTO.Order.NestedModels.AddressDTO>();
            CreateMap<Address, DTO.DeliverOrder.NestedModels.AddressDTO>();
            CreateMap<Node, DTO.User.NestedModels.NodeDTO>();
            CreateMap<Node, DTO.Order.NestedModels.NodeDTO>();
            CreateMap<Node, DTO.Offer.NestedModels.NodeDTO>();
            CreateMap<Node, DTO.DeliverOrder.NestedModels.NodeDTO>();
            CreateMap<RefreshToken, DTO.Token.TokenDTO>();
            CreateMap<Offer, DTO.Offer.OfferDTO>();
            CreateMap<Offer, DTO.Offer.OffersDTO>();
            CreateMap<Offer, DTO.Order.NestedModels.OfferDTO>();
            CreateMap<Offer, DTO.DeliverOrder.NestedModels.OfferDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Product, DTO.Product.ProductDTO>();
            CreateMap<Product, DTO.Order.NestedModels.ProductDTO>();
            CreateMap<Farmer, DTO.Offer.NestedModels.FarmerDTO>();
            CreateMap<Product, DTO.Offer.NestedModels.ProductDTO>();
            CreateMap<Farmer, DTO.Farmer.FarmerDTO>();
            CreateMap<Customer, DTO.Customer.CustomerDTO>();
            CreateMap<Order, DTO.Order.OrderDTO>();
            CreateMap<Order, DTO.Order.OrdersDTO>();
            CreateMap<Order, DTO.DeliverOrder.DeliverOrdersDTO>();
            CreateMap<OrderDetails, DTO.Order.NestedModels.OrderDetailsDTO>();
            CreateMap<OrderDetails, DTO.DeliverOrder.NestedModels.OrderDetailsDTO>();
            CreateMap<LoginAvalibility, DTO.User.LoginAvalibilityDTO>();
            CreateMap<Farmer, DTO.Order.NestedModels.FarmerDTO>();
            CreateMap<User, DTO.Order.NestedModels.UserDTO>();
            CreateMap<Profile, DTO.Order.NestedModels.ProfileDTO>();
            CreateMap(typeof(PagedResponse<>), typeof(DTO.PagedResponseDTO<>)) ;
        }
    }
}
