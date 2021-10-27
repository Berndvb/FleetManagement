using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Framework.Paging;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.EFCore.Infrastructure.Pagination
{
    internal static class PaginationExtentions
    {
        internal static async Task<PaginatedList<T>> GetPaginatedAsync<T>(
            this IQueryable<T> source,
            int PageNumber,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var count = await source.CountAsync(cancellationToken);

            var pagedItems = await source
                .Skip((PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PaginatedList<T>(pagedItems, count, PageNumber, pageSize);
        }
    }
}
