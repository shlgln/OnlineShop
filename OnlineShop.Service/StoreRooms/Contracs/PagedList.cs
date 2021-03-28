using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Services.StoreRooms.Contracs
{
    public class PagedList<T>: List<T>
    {
        public int CurentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousePage => CurentPage > 1;
        public bool HasNextPage => CurentPage < TotalPages;
        public int? PreviousPageNumber => HasPreviousePage ? CurentPage - 1 : (int?)null;
        public int? NextPageNumber => HasNextPage ? CurentPage + 1 : (int?)null;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageNumber);
            AddRange(items);
        }
        public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }


    }
}
