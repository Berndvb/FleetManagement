using MediatR.Cqrs.Queries;

namespace FleetManagement.ReadAPI.Features.Driver.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQuery : IQuery<GetAllDriverOverviewsQueryResult>
    {
        public bool FetchAll { get; set; }
    }
}
