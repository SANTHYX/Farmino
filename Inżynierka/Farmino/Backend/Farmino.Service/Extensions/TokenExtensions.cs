using Farmino.Data.Models.Aggregations;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class TokenExtensions 
    {
        public static async Task<RefreshToken> GetIfExistAsync(this IRefreshTokenRepository repository, string refresh)
        {
            var refreshToken = await repository.GetTokenAsync(refresh);

            if(refreshToken == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.RefreshTokenDontExist,
                    "RefreshToken is empty");
            }

            return refreshToken;
        }
    }
}
