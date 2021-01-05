using Farmino.Data.Models.Aggregations;
using Farmino.Service.Exceptions;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class AuctionerExtensions
    {
        public static async Task<bool> IsAuctionerExist(this IAuctionerRepository repository, string userName)
            => await repository.GetAsync(userName) != null;

        public static async Task<Auctioner> GetIfExist(this IAuctionerRepository repository, string userName)
        {
            var auctioner = await repository.GetAsync(userName);

            if (auctioner == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.AuctionerNotExist,
                    $"Auctioner with userName {userName} dont exist");
            }
            else return auctioner;
        }
    }
}
