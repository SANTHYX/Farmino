using Farmino.Data.Models.Aggregations;
using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class UserExtensions
    {
        public static async Task<User> GetIfExistAsync(this IUserRepository repository, string userName)
        {
            var user = await repository.GetAsync(userName);

            if (user == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.UserDontExist,
                    $"User with username:{userName} dont exist");
            }
            
            return user;
        }

        public static async Task<bool> IsUserExist(this IUserRepository repository, string userName)
            => await repository.GetAsync(userName) != null;
    }
}
