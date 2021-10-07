using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
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
            if (driverOverviews.Count == 0)
            {
                var dataError = new ExecutionError("We couldn't find and retrieve any data for that specifiek query.", Constants.ErrorCodes.DataNotFound);
                return NotFound(dataError);
            }

            return new GetActiveDriverOverviewsQueryResult(driverOverviews);
        }
    }
}
