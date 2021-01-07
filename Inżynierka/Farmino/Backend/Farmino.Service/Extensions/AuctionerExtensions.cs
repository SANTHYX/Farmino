using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class AuctionerExtensions
    {
        public static async Task<bool> IsAuctionerExistAsync(this IAuctionerRepository repository, string userName)
            => await repository.GetAsync(userName) != null;

        public static async Task<Auctioner> GetIfExistAsync(this IAuctionerRepository repository, string userName)
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
