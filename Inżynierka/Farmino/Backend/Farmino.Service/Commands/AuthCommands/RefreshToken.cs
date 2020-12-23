using Farmino.Service.Commands.Interfaces;
using Farmino.Service.DTO;

namespace Farmino.Service.Commands.AuthCommands
{
    public class RefreshToken : ICommand
    {
        public string Token { get; set; }
        public string Refresh { get; set; }
        public TokenDTO TokenResponse {get; set;}
    }
}
