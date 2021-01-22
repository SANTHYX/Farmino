using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OrderCommands
{
    public class CancelOrder : ICommand
    {
        public Guid OrderId { get; set; } 
    }
}
