using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
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
            var driverOverviews = await _driverService.GetDriverOverviews(onlyInService: request.OnlyInService, request.PagingParameters);
            if (driverOverviews.Count == 0)
            {
                var warning = new ExecutionWarning("We couldn't find and retrieve any driver-overview data.", Constants.WarningCodes.NoData);
                return SuccesWithNoData(warning);
            }

            return new GetAllDriverOverviewsQueryResult(driverOverviews);
        }
    }
}
