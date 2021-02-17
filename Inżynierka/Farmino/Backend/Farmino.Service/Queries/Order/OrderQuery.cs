using Farmino.Data.Enums;
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
        [FromQuery(Name = "Date")]
        public DateTime? Date { get; set; }
        [FromQuery(Name = "OrderStatus")]
        public OrderStatus? OrderStatus { get; set; }
        #nullable disable
    }
}
