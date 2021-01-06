using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Data.Models.ValueObjects;
using Farmino.Service.DTO;
using Farmino.Service.DTO.Offer;
using Farmino.Service.DTO.Offer.NestedModels;
using Farmino.Service.DTO.Token;
using Farmino.Service.DTO.User;
using Farmino.Service.DTO.User.NestedModels;
using Farmino.Service.Extensions.Models;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : AutoMapper.Profile
    {
        public AutoMapperCfg()
        {
            //Models
            CreateMap<User, DTO.User.UserDTO>();
            CreateMap<User, UsersDTO>();
            CreateMap<Data.Models.Entities.Profile, ProfileDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<RefreshToken, TokenDTO>();
            CreateMap<Offer, OfferDTO>();
            CreateMap<Offer, OffersDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Weight, WeightDTO>();
            CreateMap<Farmer, FarmerDTO>();

            //Extensions
            CreateMap<LoginAvalibility, LoginAvalibilityDTO>().ReverseMap();
        }
    }
}
