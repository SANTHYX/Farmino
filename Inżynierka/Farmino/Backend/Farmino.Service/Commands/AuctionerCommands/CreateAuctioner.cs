using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.AuctionerCommands
{
    public class CreateAuctioner : ICommand
    {
        public string UserName { get; set; }
    }
}
