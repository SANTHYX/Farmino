using Farmino.Data.Models.Aggregations;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class CustomerExtensions
    {
        public static async Task<bool> IsCustomerExist(this ICustomerRepository customerRepository, User user)
            => await customerRepository.GetAsync(user.Id) != null;
    }
}
