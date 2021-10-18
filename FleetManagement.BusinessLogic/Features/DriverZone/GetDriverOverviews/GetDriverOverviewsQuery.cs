using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.DriverZone.GetDriverOverviews
{
    public class GetDriverOverviewsQuery : IQuery<GetDriverOverviewsQueryResult>
    {
        public bool OnlyInService { get; set; }

        public PagingParameters PagingParameters { get; set; }

    }
}
