using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetActiveDriverOverviews
{
    public class GetActiveDriverOverviewsQueryHandler : QueryHandler<GetActiveDriverOverviewsQuery, GetActiveDriverOverviewsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetActiveDriverOverviewsQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetActiveDriverOverviewsQueryResult> Handle(
            GetActiveDriverOverviewsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await _driverService.GetDriverOverviews(onlyInService: true);

            return new GetActiveDriverOverviewsQueryResult(driverOverviews);
        }
    }
}
