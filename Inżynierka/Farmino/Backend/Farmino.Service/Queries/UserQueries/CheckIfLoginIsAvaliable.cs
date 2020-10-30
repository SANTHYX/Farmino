using Farmino.Service.DTO;
using Farmino.Service.Queries.Interfaces;

namespace Farmino.Service.Queries.UserQueries
{
    public class CheckIfLoginIsAvaliable :IQuery<LoginAvalibilityDTO>
    {
        public string Login { get; set; }
    }
}
