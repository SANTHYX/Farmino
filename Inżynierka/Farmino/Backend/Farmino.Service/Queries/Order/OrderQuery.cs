using System;

namespace Farmino.Service.Queries.Order
{
    public class OrderQuery
    {
        public Guid OfferId { get; set; }
        #nullable enable
        public bool? Released { get; set; }
        public DateTime? ByDate { get; set; }
        #nullable disable
    }
}
