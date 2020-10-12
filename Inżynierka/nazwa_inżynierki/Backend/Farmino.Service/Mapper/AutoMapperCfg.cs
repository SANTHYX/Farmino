using AutoMapper;
using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Service.DTO;

namespace Farmino.Service.Mapper
{
    public class AutoMapperCfg : Profile
    {
        public AutoMapperCfg()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<PersonalData, PersonalDataDTO>().ReverseMap();
        }
    }
}
