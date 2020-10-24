using Farmino.Service.DTO;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Queries.UserQueries;
using Farmino.Service.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class BrowseUsersHandler : IQueryHandler<BrowseUsers, IEnumerable<UserDTO>>
    {
        private readonly IUserService _service;

        public BrowseUsersHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<UserDTO>> HandleAsync(BrowseUsers query)
            => await _service.GetAllUsersAsync();
    }
}
