using Farmino.Service.DTO;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Queries.UserQueries;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class GetUserHandler : IQueryHandler<GetUser, UserDTO>
    {
        private readonly IUserService _service;

        public GetUserHandler(IUserService service)
        {
            _service = service;
        }

        async Task<UserDTO> IQueryHandler<GetUser, UserDTO>.HandleAsync(GetUser query)
            => await _service.GetUserAsync(query.Login);
    }
}
