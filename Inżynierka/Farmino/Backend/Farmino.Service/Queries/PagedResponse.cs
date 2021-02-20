using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmino.Service.Queries
{
    public class PagedResponse<T> : IPagination 
    {
        public IEnumerable<T> Data { get; protected set; }
        public int Page { get; protected set; }
        public int ResultsPerPage { get; protected set; }
        public int PagesNumber { get; protected set; }

        protected PagedResponse() { }

        public PagedResponse(IEnumerable<T> data, int page, 
            int resultsPerPage, int pagesNumber)
        {
            Data = data;
            Page = page > pagesNumber ? pagesNumber : page;
            ResultsPerPage = resultsPerPage;
            PagesNumber = pagesNumber;
        }

        public async static Task<PagedResponse<T>> GetPagedResponse(IQueryable<T> context, PagedQuery paged)
        {
            int _page = paged.Page;
            int _resultPerPage = paged.Results;

            if (_page <= 0)
            {
                _page = 1;
            }
            if (_resultPerPage <= 0)
            {
                _resultPerPage = 5;
            }

            var _data = await context.Skip((_page - 1) * _resultPerPage)
                .Take(paged.Results).ToListAsync();

            var _pagesNumber = (int)Math.Ceiling((decimal)await context.CountAsync()/_resultPerPage);

            return new PagedResponse<T>(_data, _page, _resultPerPage, _pagesNumber);
        }
    }
}
