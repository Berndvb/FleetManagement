using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQuery : IQuery<GetAllDriverOverviewsQueryResult>
    {
        public bool OnlyInService { get; set; }

        public PagingParameters PagingParameters { get; set; }

    }
}
