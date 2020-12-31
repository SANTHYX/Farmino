using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class FarmerExtensions
    {
        public static async Task<bool> IsFarmerExist(this IFarmerRepository farmerRepository, string userName) 
            => await farmerRepository.GetAsync(userName) != null;
    }
}
