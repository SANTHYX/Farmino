using Farmino.Data.Models.Entities;
using Farmino.Service.Exceptions;
using Farmino.Service.Extensions;
using Farmino.Service.Repositories.Interfaces;
using Farmino.Service.Service.Interfaces;
using System.Threading.Tasks;

namespace Farmino.Service.Service
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUserRepository _userRepository;
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IUserRepository userRepository, IParticipantRepository participantRepository)
        {
            _userRepository = userRepository;
            _participantRepository = participantRepository;
        }

        public async Task CreateParticipant(string userName)
        {
            var user = await _userRepository.GetIfExistAsync(userName);

            if (!await _participantRepository.IsParticipantExist(userName))
            {
                await _participantRepository.AddAsync(new Participant(user));
                await _participantRepository.SaveChanges();
            }
            else throw new ServiceExceptions(ServiceErrorCodes.ParticipantAlreadyExist,
                "Participant with this userName already exist");
        }
    }
}
