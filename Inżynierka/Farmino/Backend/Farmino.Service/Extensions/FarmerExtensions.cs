using Farmino.Data.Models.Aggregations;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class FarmerExtensions
    {
        public static async Task<bool> IsFarmerExist(this IFarmerRepository farmerRepository, User user) 
            => await farmerRepository.GetAsync(user.Id) != null;
    }
}
