using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ProfileExtensions
    {
        public static async Task<Profile> GetIfExistAsync(this IProfileRepository repository, Guid id)
        {
            var profile = await repository.GetByUserIdAsync(id);

            if(profile == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ProfileDontExist,
                    "Profile dont exist");
            }

            return profile;
        }
    }
}
