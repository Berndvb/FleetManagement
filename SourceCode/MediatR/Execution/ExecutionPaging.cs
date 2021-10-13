using FleetManagement.Domain.Infrastructure.Pagination;

namespace MediatR.Cqrs.Execution
{
    public class ExecutionPaging
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;
    }
}
