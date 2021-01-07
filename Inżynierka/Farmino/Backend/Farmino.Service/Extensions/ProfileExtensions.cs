using Farmino.Data.Models.Entities;
using Farmino.Infrastructure.Repositories.Interfaces;
using Farmino.Service.Exceptions;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ProfileExtensions
    {
        public static async Task<bool> IsProfileExistAsync(this IProfileRepository repository, Guid userId)
            => await repository.GetByUserIdAsync(userId) != null;

        public static async Task<Profile> GetIfExistAsync(this IProfileRepository repository, Guid userId)
        {
            var profile = await repository.GetByUserIdAsync(userId);

            if(profile == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ProfileDontExist,
                    "Profile dont exist");
            }

            return profile;
        }
    }
}
