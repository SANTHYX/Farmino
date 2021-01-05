using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Extensions
{
    public static class ParticipantExtensions
    {
        public static async Task<bool> IsParticipantExist(this IParticipantRepository repository, string userName)
            => await repository.GetAsync(userName) != null;

        public static async Task<Participant> GetIfExist(this IParticipantRepository repository, string userName)
        {
            var participant = await repository.GetAsync(userName);

            if (participant == null)
            {
                throw new ServiceExceptions(ServiceErrorCodes.ParticipantNotExist,
                    $"Participant with userName {userName} not exist");
            }

            return participant;
        }
    }
}
