using Farmino.Service.DTO.User;
using Farmino.Service.Queries.Interfaces;
using System.Collections.Generic;

namespace Farmino.Service.Queries.UserQueries
{
    public class BrowseUsers : IPagination, IQuery<IEnumerable<UsersDTO>>
    {
        public int Page => throw new System.NotImplementedException();

        public int ResultsPerPage => throw new System.NotImplementedException();

        public int PagesNumber => throw new System.NotImplementedException();
    }
}
