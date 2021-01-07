using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class FarmerExtensions
    {
        public static async Task<bool> IsFarmerExistAsync(this IFarmerRepository repository, string userName) 
            => await repository.GetAsync(userName) != null;

        public static async Task<Farmer> GetIfExistAsync(this IFarmerRepository repository, string userName)
        {
            var farmer = await repository.GetAsync(userName);

            if(farmer == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.FarmerNotExist,
                    $"Farmer with login {userName} not exist");
            }

            return farmer;
        }
    }
}
