using System;
using System.Collections.Generic;

namespace FleetManager.EFCore.Infrastructure.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int PageNumber { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; set; }

        public PaginatedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            PageSize = pageSize;
            TotalCount = totalCount;

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
