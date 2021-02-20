using System.Collections.Generic;

namespace Farmino.Service.DTO
{
    public class PagedResponseDTO<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Page { get; set; }
        public int ResultsPerPage { get; set; }
        public int PagesNumber { get; set; }
    }
}
