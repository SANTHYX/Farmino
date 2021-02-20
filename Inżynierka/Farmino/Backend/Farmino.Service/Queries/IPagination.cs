namespace Farmino.Service.Queries
{
    public interface IPagination
    {
        public int Page { get; }
        public int ResultsPerPage { get;}
        public int PagesNumber { get;}
    }
}
