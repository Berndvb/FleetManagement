using MediatR.Queries;

namespace FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQuery : IQuery<GetAllDriverOverviewsQueryResult>
    {
        public bool OnlyInService { get; set; }
    }
}
