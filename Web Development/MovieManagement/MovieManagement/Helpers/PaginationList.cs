using Microsoft.EntityFrameworkCore;

namespace MovieManagement.Helpers
{
    public class PaginationList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginationList()
        {
        }

        public PaginationList(IQueryable<T> sourceItems, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(sourceItems.Count() / (double)pageSize);
            var items = sourceItems.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }
}
