using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.ParticipantCommands
{
    public class CreateParticipant : ICommand
    {
        public string UserName { get; set; }
    }
}
