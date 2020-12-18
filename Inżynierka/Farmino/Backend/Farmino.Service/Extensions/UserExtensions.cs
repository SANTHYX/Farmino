using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class UserExtensions
    {
        public static async Task<bool> IsUserExist(this IUserRepository repository, string login)
            => await repository.GetAsync(login) != null;
    }
}
