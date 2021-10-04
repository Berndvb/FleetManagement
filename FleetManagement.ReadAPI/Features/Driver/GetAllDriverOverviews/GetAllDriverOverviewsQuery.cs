using MediatR.Queries;

namespace FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQuery : IQuery<GetAllDriverOverviewsQueryResult>
    {
        public bool InService { get; set; }
    }
}
