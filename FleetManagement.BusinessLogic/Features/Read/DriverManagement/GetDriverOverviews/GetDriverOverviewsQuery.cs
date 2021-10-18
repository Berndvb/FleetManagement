using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Queries;

namespace FleetManagement.BLL.Features.Read.DriverManagement.GetAllDriverOverviews
{
    public class GetDriverOverviewsQuery : IQuery<GetDriverOverviewsQueryResult>
    {
        public bool OnlyInService { get; set; }

        public PagingParameters PagingParameters { get; set; }

    }
}
