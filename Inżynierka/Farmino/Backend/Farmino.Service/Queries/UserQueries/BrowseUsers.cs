using Farmino.Service.DTO;
using Farmino.Service.Queries.Interfaces;
using System.Collections.Generic;

namespace Farmino.Service.Queries.UserQueries
{
    public class BrowseUsers : Pagination, IQuery<IEnumerable<UserDTO>>
    {
    }
}
