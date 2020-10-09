using AutoMapper;
using Farmino.Data.Models;
using Farmino.Service.DTO;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : Profile
    {
        public AutoMapperCfg()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
