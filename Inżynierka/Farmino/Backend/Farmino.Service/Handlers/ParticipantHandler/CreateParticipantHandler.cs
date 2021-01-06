using Farmino.Service.Commands.ParticipantCommands;
using Farmino.Service.Handlers.Interfaces;
using Farmino.Service.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace Farmino.Service.Handlers.ParticipantHandler
{
    public class CreateParticipantHandler : ICommandHandler<CreateParticipant>
    {
        private readonly IParticipantService _participantService;

        public CreateParticipantHandler(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        public async Task HandleAsync(CreateParticipant command)
        {
            await _participantService.CreateParticipant(command.UserName);
        }
    }
}
