using Microsoft.AspNetCore.Mvc;
using System;

namespace Farmino.Service.Queries.Order
{
    public class OrderQuery
    {
        #nullable enable
        [FromQuery(Name = "OfferId")]
        public Guid? OfferId { get; set; }
        [FromQuery(Name = "FarmerName")]
        public string? FarmerName { get; set; }
        [FromQuery(Name = "CustomerName")]
        public string? CustomerName { get; set; }
        [FromQuery(Name = "Released")]
        public bool? Released { get; set; }
        [FromQuery(Name = "ByDate")]
        public DateTime? ByDate { get; set; }
        #nullable disable
    }
}
