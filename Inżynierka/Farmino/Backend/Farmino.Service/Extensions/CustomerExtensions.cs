using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class CustomerExtensions
    {
        public static async Task<bool> IsCustomerExistAsync(this ICustomerRepository repository, string userName)
            => await repository.GetAsync(userName) != null;

        public static async Task<Customer> GetIfExistAsync(this ICustomerRepository repository, string userName)
        {
            var customer = await repository.GetAsync(userName);

            if (customer == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.CustomerDontExist,
                    $"Customer with userName {userName} dont exist");
            }
            else return customer;
        }
    }
}
