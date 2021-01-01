using Farmino.Data.Models.Aggregations;
using Farmino.Service.Exceptions;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class FarmerExtensions
    {
        public static async Task<bool> IsFarmerExist(this IFarmerRepository repository, string userName) 
            => await repository.GetAsync(userName) != null;

        public static async Task<Farmer> GetIfExist(this IFarmerRepository repository, string userName)
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
