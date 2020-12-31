using Farmino.Service.Commands.Interfaces;

namespace Farmino.Service.Commands.CustomerCommands
{
    public class CreateCustomer : ICommand
    {
        public string UserName { get; set; }
    }
}
