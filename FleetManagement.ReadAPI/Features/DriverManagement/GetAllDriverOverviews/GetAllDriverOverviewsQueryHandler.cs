using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetAllDriverOverviews
{
    public class GetAllDriverOverviewsQueryHandler : QueryHandler<GetAllDriverOverviewsQuery, GetAllDriverOverviewsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAllDriverOverviewsQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAllDriverOverviewsQueryResult> Handle(
            GetAllDriverOverviewsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await _driverService.GetDriverOverviews(onlyInService: false);

            return new GetAllDriverOverviewsQueryResult(driverOverviews);
        }
    }
}
