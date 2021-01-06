using Farmino.Service.DTO;
using Farmino.Service.DTO.User;
using Farmino.Service.Queries.Interfaces;

namespace Farmino.Service.Queries.UserQueries
{
    public class GetUser : IQuery<UserDTO>
    {
        public string Login { get; set; }
    }
}
