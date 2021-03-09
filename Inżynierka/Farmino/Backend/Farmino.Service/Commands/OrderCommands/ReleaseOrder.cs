using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OrderCommands
{
    public class ReleaseOrder : ICommand
    {
        public Guid OrderId { get; set; }
    }
}
