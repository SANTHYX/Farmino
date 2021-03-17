using Farmino.Service.Commands.Interfaces;
using Farmino.Service.DTO.Token;

namespace Farmino.Service.Commands.AuthCommands
{
    public class RefreshToken : ICommand
    {
        public string Refresh { get; set; }
        public TokenDTO TokenResponse {get; set;}
    }
}
