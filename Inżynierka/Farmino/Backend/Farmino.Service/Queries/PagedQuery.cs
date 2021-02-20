using Microsoft.AspNetCore.Mvc;

namespace Farmino.Service.Queries
{
    public class PagedQuery
    {
#nullable enable
        [FromQuery(Name = "Page")]
        public int Page { get; set; } = 1;
        [FromQuery(Name = "Results")]
        public int Results { get; set; } = 5;
        #nullable disable
    }
}
