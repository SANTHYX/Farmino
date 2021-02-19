namespace Farmino.Service.Queries
{
    public class Pagination
    {
        #nullable enable
        public string? Page { get; set; }
        public string? Previous { get; set; }
        public string? Next { get; set; }
        public string? PagesNumber { get; set; }
        #nullable disable
    }
}
