using Farmino.Service.Commands.Interfaces;
using System;

namespace Farmino.Service.Commands.OrderCommands
{
    public class SetRealisationDate : ICommand
    {
        public Guid OrderId { get; set; }
        public DateTime RealisationDate { get; set; }
    }
}
