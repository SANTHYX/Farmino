using Microsoft.AspNetCore.Mvc;

namespace Farmino.Service.Queries.Auctions
{
    public class AuctionsQuery
    {
        #nullable enable
        [FromQuery(Name = "Phrase")]
        public string? Phrase { get; set; }
        #nullable disable
    }
}
