using Farmino.Service.DTO;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Queries.UserQueries;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.UserHandlers
{
    public class IsLoginAvaliableHandler : IQueryHandler<CheckIfLoginIsAvaliable, LoginAvalibilityDTO>
    {
        private readonly IUserService _service;

        public IsLoginAvaliableHandler(IUserService service)
        {
            _service = service;
        }

        public async Task<LoginAvalibilityDTO> HandleAsync(CheckIfLoginIsAvaliable query)
            => await _service.IsLoginAvaliableAsync(query.Login);
    }
}
