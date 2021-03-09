using Farmino.Data.Enums;
using Farmino.Service.Commands.Interfaces;
using Farmino.Service.Commands.OfferCommands.NestedModel;
using Microsoft.AspNetCore.Http;

namespace Farmino.Service.Commands.OfferCommands
{
    public class CreateOffer : ICommand
    {
        public string UserName { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; }
        public WeightUnits MinWeightUnit { get; set; }
        public Regions Region { get; set; }
        public Categories Category { get; set; }
        public double MinQuantity { get; set; }
        public IFormFile Image { get; set; }
        public ProductCommand Product { get; set; }
    }
}
