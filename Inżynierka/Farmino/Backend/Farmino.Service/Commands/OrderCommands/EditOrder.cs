using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OrderCommands
{
    public class EditOrder : ICommand
    {
        public Guid OfferId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
