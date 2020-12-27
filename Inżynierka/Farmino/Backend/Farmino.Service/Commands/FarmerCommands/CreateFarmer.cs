using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.FarmerCommands
{
    public class CreateFarmer : ICommand
    {
        public string Login { get; set; }
    }
}
