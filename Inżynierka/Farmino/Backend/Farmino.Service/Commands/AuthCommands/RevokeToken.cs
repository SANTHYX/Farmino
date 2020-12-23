using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.AuthCommands
{
    public class RevokeToken : ICommand
    {
        public string Refresh { get; set; }
    }
}
